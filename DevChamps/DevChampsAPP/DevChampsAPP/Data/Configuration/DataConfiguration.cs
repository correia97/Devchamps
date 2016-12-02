using Prism.Services;

namespace DevChampsAPP
{
    public sealed class DataConfiguration
    {
        static volatile DataConfiguration instance;
        static readonly object syncLock = new object();
        static SQLite.SQLiteConnection conn = null;

        DataConfiguration()
        {
            conn = new DependencyService().Get<ISQLiteConnection>().GetPlataformSpecificConnection();
        }

        public static SQLite.SQLiteConnection GetDatabaseConnection
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new DataConfiguration();
                    }
                }

                return conn;
            }
        }
    }
}