using System;
using System.IO;
using SQLite;

namespace DevChampsAPP.Droid
{
    public class SQLiteConnection_Droid : ISQLiteConnection
    {
        public SQLiteConnection_Droid()
        {
        }

        public SQLite.SQLiteConnection GetPlataformSpecificConnection()
        {
            var sqliteFilename = "Devchamps.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
