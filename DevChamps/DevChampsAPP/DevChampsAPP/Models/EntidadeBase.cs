using System;
using SQLite;

namespace DevChampsAPP
{
    public class EntidadeBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
