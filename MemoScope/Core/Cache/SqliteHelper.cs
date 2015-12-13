using System.Data.SQLite;

namespace MemoScope.Core.Cache
{
    public static class SqliteHelper
    {
        public static SQLiteParameter CreateParameter(this SQLiteCommand cmd, string paramName)
        {
            SQLiteParameter param = cmd.CreateParameter();
            param.ParameterName = paramName;
            cmd.Parameters.Add(param);
            return param;
        }

        public static SQLiteCommand PrepareCommand(this SQLiteConnection cxion, string sqlCmd)
        {
            var cmd = cxion.CreateCommand();
            cmd.CommandText = sqlCmd;
            cmd.Prepare();
            return cmd;
        }
    }
}
