using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UOData
{
    using MySql.Data.MySqlClient;

    public class Gears
    {
        public Int32 ID { get; set; }
        public Int32 Head { get; set; }
        public Int32 Chest { get; set; }
        public Int32 Arms { get; set; }
        public Int32 Gloves { get; set; }
        public Int32 Legs { get; set; }
        public Int32 Shoes { get; set; }
        public Int32 Ring { get; set; }
        public Int32 LeftHand { get; set; }
        public Int32 RightHand { get; set; }
        public Int32 Bracelet { get; set; }
        public Gears()
        {
        }
        public Gears(DB db, Int32 id)
        {
            MySqlDataReader dr = db.ExecuteQuery("SELECT * FROM gears WHERE id = " + id);
            while (dr.Read())
            {
                ID = (int)dr["id"];
                Head = (int)dr["head"];
                Chest = (int)dr["chest"];
                Arms = (int)dr["arms"];
                Gloves = (int)dr["gloves"];
                Legs = (int)dr["legs"];
                Shoes = (int)dr["shoes"];
                Ring = (int)dr["ring"];
                LeftHand = (int)dr["lefthand"];
                RightHand = (int)dr["righthand"];
                Bracelet = (int)dr["bracelet"];
            }
            dr.Close();
        }
    }
}
