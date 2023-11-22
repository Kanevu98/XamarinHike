using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XamarinMHike
{
    public class HikeModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
        public int isParking { get; set; }
        public float length { get; set; }
        public string level { get; set; }
        public string vehicle { get; set; }
        public int member { get; set; }
        public string description { get; set; }
    }
}
