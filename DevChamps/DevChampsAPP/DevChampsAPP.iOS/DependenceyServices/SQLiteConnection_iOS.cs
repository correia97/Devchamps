using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DevChampsAPP.iOS.SQLiteConnection_iOS))]
namespace DevChampsAPP.iOS
{
    public class SQLiteConnection_iOS : ISQLiteConnection
    {
       public SQLite.SQLiteConnection GetPlataformSpecificConnection()
        {
            try
            {
                var sqliteFilename = "DevChampsAPP.db3";
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libraryPath = Path.Combine(documentsPath, "..", "Library");
                var path = Path.Combine(libraryPath, sqliteFilename);
                var conn = new SQLite.SQLiteConnection(path);
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}