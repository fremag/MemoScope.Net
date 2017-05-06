using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using WinFwk.UITools.Log;
using System;
using WinFwk.UIModules;
using System.Threading;

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
        private SQLiteCommand cmdCountReferences;
        private SQLiteParameter paramInstanceAddress_CountReferences;

        public ClrDumpCache(ClrDump clrDump)
        {
            ClrDump = clrDump;
        }

        long n = 0;
        DateTime startTime ;

        public void Init(CancellationToken token)
        {
            string dbPath = GetCachePath(ClrDump.DumpPath);
            if (File.Exists(dbPath))
            {
                ClrDump.MessageBus.Log(this, $"Opening cache: {dbPath}");
                Open(dbPath);
                return;
            }
            startTime = DateTime.Now;
            n = 0;
            ClrDump.MessageBus.Status("Initializing cache...");
            Open(dbPath);

            ClrDump.MessageBus.Status($"Creating tables...");
            CreateTables();
            ClrDump.MessageBus.Status($"Storing data...");
            StoreData(token);
            if( token.IsCancellationRequested)
            {
                ClrDump.MessageBus.EndTask("Cache Initialization cancelled.");
                return;
            }
            ClrDump.MessageBus.Status($"Creating indices...");
            CreateIndices();
            ClrDump.MessageBus.Status($"Cache Initialized: {GetStats()}", StatusType.EndTask);
        }

        internal void Destroy()
        {
            Dispose();
            string dbPath = GetCachePath(ClrDump.DumpPath);
            if (File.Exists(dbPath))
            {
                ClrDump.MessageBus.Log(this, $"Deleting cache: {dbPath}");
                File.Delete(dbPath);
            }
        }

        internal void Dispose()
        {
            cmdInsertInstance?.Dispose();
            cmdInsertReference?.Dispose();
            cmdInsertType?.Dispose();
            cxion.Dispose();
        }

        private void StoreData(CancellationToken token)
        {
            BeginUpdate();
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
                    InsertReferences(child, address);
                });

                n++;
                if( n % 1024*64==0)
                {
                    if( token.IsCancellationRequested)
                    {
                        return;
                    }
                    ClrDump.MessageBus.Status(GetStats());
                }
            }


            ClrDump.MessageBus.Log(this, "Inserting type stats...");
            foreach (var stat in stats.Values)
            {
                InsertTypeStat(stat);
            }

            EndUpdate();
            ClrDump.MessageBus.Status("Cache Initialized.", StatusType.EndTask);
        }

        private string GetStats()
        {
            var now = DateTime.Now;
            var elapsed = now - startTime;
            return $"# instances: {n:###,###,###,###}, inst/sec: {n / elapsed.TotalSeconds:###,###,##0}, time: {elapsed:hh\\:mm\\:ss}";
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

                ClrType type = ClrDump.GetType(methodTable);
                if (type == null)
                {
                    type = ClrDump.GetType(name);
                }
                if ( type == null)
                {
                    type = new ClrTypeError(name);
                }
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

        public string GetTypeName(int id)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = $"SELECT Name FROM Types WHERE id='{id}'";
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(0);
                return name;
            }
            return null;
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
            int nb = 0;
            string name = null;
            CancellationTokenSource token = null;

            name = GetTypeName(typeId);
            token = new CancellationTokenSource();
            ClrDump.MessageBus.BeginTask($"Loading instances: {name}", token);
            nb = CountInstances(typeId);

            int max = 10 * 1000 * 1000;
            var list = new List<ulong>();
            n = 0;
            foreach(ulong address in EnumerateInstances(typeId))
            {
                list.Add(address);
                n++;
                if(n==max)
                {
                    break;
                }
                if( n % 1024 == 0)
                {
                    ClrDump.MessageBus.Status($"Loading instances: {name}: {n:###,###,###,###} / {nb:###,###,###,###}...");
                    if( token.IsCancellationRequested)
                    {
                        ClrDump.MessageBus.EndTask($"Loading instances: {name}: Cancelled !");
                        return list;
                    }
                }
            }
            ClrDump.MessageBus.EndTask($"Instances loaded: {name} = {n:###,###,###,###}");
            return list;
        }

        public IEnumerable<ulong> EnumerateInstances(int typeId)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = "SELECT Address FROM Instances WHERE TypeId=" + typeId;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read() )
            {
                var address = (ulong)dr.GetInt64(0);
                yield return address;
            }
        }

        public int CountInstances(int typeId)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cxion;
            cmd.CommandText = "SELECT count(*) FROM Instances WHERE TypeId=" + typeId;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var count = (int)dr.GetInt64(0);
                return count;
            }
            return 0;
        }

        #endregion

        #region References
        public void InsertReferences(ulong instanceAddress, ulong refByAddress)
        {
            paramInstanceAddress_InsertReference.Value = instanceAddress;
            paramRefByAddress_InsertReference.Value = refByAddress;
            cmdInsertReference.ExecuteNonQuery();
        }

        public IEnumerable<ulong> EnumerateReferers(ulong instanceAddress)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.Connection = cxion;
                cmd.CommandText = "SELECT RefByAddress FROM InstanceReferences WHERE InstanceAddress=" + instanceAddress;
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var address = (ulong)dr.GetInt64(0);
                    yield return address;
                }
            }
        }

        public List<ulong> LoadReferers(ulong instanceAddress)
        {
            var list = new List<ulong>(EnumerateReferers(instanceAddress));
            return list;
        }

        public int CountReferers(ulong instanceAddress)
        {
            lock (cmdCountReferences)
            {
                paramInstanceAddress_CountReferences.Value = instanceAddress;
                using (SQLiteDataReader dr = cmdCountReferences.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var count = dr.GetInt32(0);
                        return count;
                    }
                }
                return 0;
            }
        }
        #endregion

        private void CreateIndices()
        {
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
            string cxionString = $"Data Source={dbPath};Version=3;Page Size=65536;journal_mode=OFF;synchronous=OFF;count_changes=OFF;temp_store=MEMORY";
            cxion = new SQLiteConnection(cxionString);
            cxion.Open();

            cmdCountReferences = cxion.PrepareCommand("SELECT count(*) FROM InstanceReferences WHERE InstanceAddress= @instanceAddress");
            paramInstanceAddress_CountReferences = cmdCountReferences.CreateParameter("@instanceAddress");
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

        public static string GetCachePath(string dumpFileName)
        {
            string dumpPath = dumpFileName;
            var sqlitePath = Path.ChangeExtension(dumpPath, "sqlite");
            return sqlitePath;
        }
        #endregion
    }
}
