using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System;
using WinFwk.UITools.Log;

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
        private SQLiteParameter paramId;
        private SQLiteParameter paramName;
        private SQLiteParameter paramCount;
        private SQLiteParameter paramTotalSize;

        public ClrDumpCache(ClrDump clrDump)
        {
            ClrDump = clrDump;
        }

        public void Init()
        {
            string dbPath = GetCachePath();
            if ( File.Exists(dbPath))
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

        private void Open(string dbPath)
        {
            string cxionString = $"Data Source={dbPath};Version=3;Cache Size=2000000;Page Size=8192;journal_mode=OFF;synchronous=OFF;count_changes=OFF;temp_store=MEMORY";
            cxion = new SQLiteConnection(cxionString);
            cxion.Open();
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
                    stat = new ClrTypeStats(type);
                    stats[type] = stat;
                }
                stat.Inc(size);
                n++;
            }
            ClrDump.MessageBus.Log(this, $"Inserting type stats...");
            foreach (var stat in stats.Values)
            {
                InsertTypeStat(stat);
            }

            EndUpdate();
            ClrDump.MessageBus.Log(this, "Initializing cache...");
        }

        public void InsertTypeStat(ClrTypeStats stats)
        {
            paramId.Value = stats.MethodTable;
            paramName.Value = stats.Type.Name;
            paramTotalSize.Value = stats.TotalSize;
            paramCount.Value = stats.NbInstances;
            cmdInsertType.ExecuteNonQuery();
        }

        public List<ClrTypeStats> LoadTypeStat()
        {
            var list = new List<ClrTypeStats>();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = "SELECT Id, Name, Count, TotalSize From Types";
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ulong methodTable = (ulong)dr.GetInt64(0);
                var name = dr.GetString(1);
                var count = dr.GetInt64(2);
                var totalSize = (ulong)dr.GetInt64(3);
                var type = ClrDump.GetType(methodTable);
                var clrTypeStats = new ClrTypeStats(type, count, totalSize);
                list.Add(clrTypeStats);
            }
            return list;
        }

        private void RunCommand(string sql)
        {
            var cmd = cxion.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        private void CreateIndices()
        {
            RunCommand("CREATE UNIQUE INDEX IdxTypes ON Types (Id)");
        }
        private void CreateTables()
        {
            RunCommand("CREATE TABLE Types (Id INTEGER, Name TEXT, Count INT, TotalSize INTEGER)");
            cmdInsertType = cxion.PrepareCommand("INSERT INTO Types(Id, Name, Count, TotalSize) VALUES (@Id, @Name, @Count, @TotalSize)");

            paramId = cmdInsertType.CreateParameter("Id");
            paramName = cmdInsertType.CreateParameter("Name");
            paramCount = cmdInsertType.CreateParameter("Count");
            paramTotalSize = cmdInsertType.CreateParameter("TotalSize");
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
    }
}
