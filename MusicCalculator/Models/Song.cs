using System;
using SQLite;

namespace MusicCalculator
{
    public class Song
    {        [PrimaryKey, AutoIncrement]        public int ID { get; set; }        public string Title { get; set; }        public int Tempo { get; set; }    }
}
