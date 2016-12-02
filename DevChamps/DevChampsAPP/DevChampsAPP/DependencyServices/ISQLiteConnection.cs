using System;

namespace DevChampsAPP
{
    public interface ISQLiteConnection
    {
        SQLite.SQLiteConnection GetPlataformSpecificConnection();
    }
}
