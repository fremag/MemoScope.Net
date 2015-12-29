using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using WinFwk.UITools.Log;
using System;

namespace MemoScope.Core.Cache
{
    public class ClrDumpCache
    {
        ClrDump ClrDump { get; }
        public bool DataExists { get; private set; }

        private SQLiteConnection cxion;
        private SQLiteTransaction transaction;

        // Statement: insert into table Types
        private SQLiteCommand cmdInsertType;
        private SQLiteParameter paramId_InsertType;
        private SQLiteParameter paramName_InsertType;
        private SQLiteParameter paramMethodTable_InsertType;
        private SQLiteParameter paramCount_InsertType;
        private SQLiteParameter paramTotalSize_InsertType;

        // Statement: insert into table Instances
        private SQLiteCommand cmdInsertInstance;
        private SQLiteParameter paramAddress_InsertInstance;
        private SQLiteParameter paramTypeId_InsertInstance;

        // Statement: insert into table References
        private SQLiteCommand cmdInsertReference;
        private SQLiteParameter paramRefByAddress_InsertReference;
        private SQLiteParameter paramInstanceAddress_InsertReference;

        public ClrDumpCache(ClrDump clrDump)
        {
            ClrDump = clrDump;
        }

        public void Init()
        {
            string dbPath = GetCachePath();
            if (File.Exists(dbPath))
            {
                ClrDump.MessageBus.Log(this, $"Opening cache: {dbPath}");
                Open(dbPath);
                return;
            }
            ClrDump.MessageBus.Log(this, $"Creating cache: {dbPath}");
            Open(dbPath);

            ClrDump.MessageBus.Log(this, $"Creating tables...");
            CreateTables();
            ClrDump.MessageBus.Log(this, $"Storing data...");
            StoreData();
            ClrDump.MessageBus.Log(this, $"Creating indices...");
            CreateIndices();
        }

        private void StoreData()
        {
            ClrDump.MessageBus.Log(this, "Initializing cache...");
            BeginUpdate();
            int n = 0;
            Dictionary<ClrType, ClrTypeStats> stats = new Dictionary<ClrType, ClrTypeStats>();
            foreach (var address in ClrDump.Heap.EnumerateObjectAddresses())
            {
                ClrType type = ClrDump.Heap.GetObjectType(address);
                if (type == null)
                {
                    continue;
                }
                ulong size = type.GetSize(address);

                ClrTypeStats stat;
                if (!stats.TryGetValue(type, out stat))
                {
                    stat = new ClrTypeStats(stats.Count, type);
                    stats[type] = stat;
                }

                stat.Inc(size);
                InsertInstances(stat.Id, address);

                type.EnumerateRefsOfObject(address, delegate (ulong child, int offset)
                {
                    InsertReferences(address, child);
                });

                n++;
            }
            ClrDump.MessageBus.Log(this, "Inserting type stats...");
            foreach (var stat in stats.Values)
            {
                InsertTypeStat(stat);
            }

            EndUpdate();
            ClrDump.MessageBus.Log(this, "Initializing cache...");
        }
        #region TypeStats

        public void InsertTypeStat(ClrTypeStats stats)
        {
            paramId_InsertType.Value = stats.Id;
            paramName_InsertType.Value = stats.Type.Name;
            paramMethodTable_InsertType.Value = stats.MethodTable;
            paramTotalSize_InsertType.Value = stats.TotalSize;
            paramCount_InsertType.Value = stats.NbInstances;
            cmdInsertType.ExecuteNonQuery();
        }

        public List<ClrTypeStats> LoadTypeStat()
        {
            var list = new List<ClrTypeStats>();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = "SELECT Id, Name, MethodTable, Count, TotalSize FROM Types";
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                var name = dr.GetString(1);
                ulong methodTable = (ulong)dr.GetInt64(2);
                var count = dr.GetInt64(3);
                var totalSize = (ulong)dr.GetInt64(4);

                var type = ClrDump.GetType(methodTable);
                var clrTypeStats = new ClrTypeStats(id, type, count, totalSize);
                list.Add(clrTypeStats);
            }
            return list;
        }

        public int GetTypeId(string name)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = $"SELECT Id FROM Types WHERE name='{name}'";
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                return id;
            }
            return -1;
        }

        #endregion

        #region Instances
        public void InsertInstances(int typeId, ulong address)
        {
            paramTypeId_InsertInstance.Value = typeId;
            paramAddress_InsertInstance.Value = address;
            cmdInsertInstance.ExecuteNonQuery();
        }

        public List<ulong> LoadInstances(int typeId)
        {
            var list = new List<ulong>();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = "SELECT Address FROM Instances WHERE TypeId=" + typeId;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var address = (ulong)dr.GetInt64(0);
                list.Add(address);
            }
            return list;
        }

        #endregion

        #region References
        public void InsertReferences(ulong instanceAddress, ulong refByAddress)
        {
            paramInstanceAddress_InsertReference.Value = instanceAddress;
            paramRefByAddress_InsertReference.Value = refByAddress;
            cmdInsertReference.ExecuteNonQuery();
        }

        public List<ulong> LoadReferences(ulong instanceAddress)
        {
            var list = new List<ulong>();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = "SELECT RefByAddress FROM InstanceReferences WHERE InstanceAddress=" + instanceAddress;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var address = (ulong)dr.GetInt64(0);
                list.Add(address);
            }
            return list;
        }

        #endregion

        private void CreateIndices()
        {
            ClrDump.MessageBus.Log(this, "Creating Indexes...");
            RunCommand("CREATE UNIQUE INDEX IdxTypes ON Types (Id)");
            RunCommand("CREATE INDEX IdxInstances ON Instances (TypeId)");
            RunCommand("CREATE INDEX IdxReferences ON InstanceReferences (InstanceAddress)");
        }

        private void CreateTables()
        {
            // Table : Types
            RunCommand("CREATE TABLE Types (Id INTEGER, Name TEXT, MethodTable INTEGER, Count INT, TotalSize INTEGER)");

            cmdInsertType = cxion.PrepareCommand("INSERT INTO Types(Id, Name, MethodTable, Count, TotalSize) VALUES (@Id, @Name, @MethodTable, @Count, @TotalSize)");
            paramId_InsertType = cmdInsertType.CreateParameter("Id");
            paramName_InsertType = cmdInsertType.CreateParameter("Name");
            paramMethodTable_InsertType = cmdInsertType.CreateParameter("MethodTable");
            paramCount_InsertType = cmdInsertType.CreateParameter("Count");
            paramTotalSize_InsertType = cmdInsertType.CreateParameter("TotalSize");

            // Table : Instances
            RunCommand("CREATE TABLE Instances (TypeId INTEGER, Address INTEGER)");

            cmdInsertInstance = cxion.PrepareCommand("INSERT INTO Instances(TypeId, Address) VALUES (@TypeId, @Address)");
            paramTypeId_InsertInstance = cmdInsertInstance.CreateParameter("TypeId");
            paramAddress_InsertInstance = cmdInsertInstance.CreateParameter("Address");

            // Table: References
            RunCommand("CREATE TABLE InstanceReferences (InstanceAddress INTEGER, RefByAddress INTEGER)");
            cmdInsertReference = cxion.PrepareCommand("INSERT INTO InstanceReferences(InstanceAddress, RefByAddress ) VALUES (@InstanceAddress, @RefByAddress)");
            paramInstanceAddress_InsertReference = cmdInsertReference.CreateParameter("InstanceAddress");
            paramRefByAddress_InsertReference = cmdInsertReference.CreateParameter("RefByAddress");
        }

        #region SQL 
        private void Open(string dbPath)
        {
            string cxionString = $"Data Source={dbPath};Version=3;Cache Size=2000000;Page Size=8192;journal_mode=OFF;synchronous=OFF;count_changes=OFF;temp_store=MEMORY";
            cxion = new SQLiteConnection(cxionString);
            cxion.Open();
        }

        private void RunCommand(string sql)
        {
            var cmd = cxion.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void BeginUpdate()
        {
            transaction = cxion.BeginTransaction();
        }
        public void EndUpdate()
        {
            transaction.Commit();
        }

        public string GetCachePath()
        {
            string dumpPath = ClrDump.DumpPath;
            var sqlitePath = Path.ChangeExtension(dumpPath, "sqlite");
            return sqlitePath;
        }

        #endregion    }
    }
}
