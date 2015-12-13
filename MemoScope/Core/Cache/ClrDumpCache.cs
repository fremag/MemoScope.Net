using System.Data.SQLite;
using System.IO;

namespace MemoScope.Core.Cache
{
    public class ClrDumpCache
    {
        ClrDump ClrDump { get; }
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
                return;
            }
            string cxionString = $"Data Source={dbPath};Version=3;Cache Size=2000000;Page Size=8192;journal_mode=OFF;synchronous=OFF;count_changes=OFF;temp_store=MEMORY";
            cxion = new SQLiteConnection(cxionString);
            cxion.Open();
            CreateTables();
            CreateIndices();
        }
        public void InsertTypeStat(ClrTypeStats stats)
        {
            paramId.Value = stats.Id;
            paramName.Value = stats.Type.Name;
            paramTotalSize.Value = stats.TotalSize;
            paramCount.Value = stats.NbInstances;
            cmdInsertType.ExecuteNonQuery();
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
