using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UOData
{
    using MySql.Data.MySqlClient;

    public class Attributes
    {
        public Int32 Strength { get; set; }
        public Int32 Dexterity { get; set; }
        public Int32 Intelligence { get; set; }
        public Attributes()
        {
        }
        public Attributes(DB db, Int32 id)
        {
            if (db.IsConnected)
            {
                MySqlDataReader dr = db.ExecuteQuery("SELECT * FROM attributes WHERE id = " + id);
                while (dr.Read())
                {
                    Strength = (int)dr["strength"];
                    Dexterity = (int)dr["dexterity"];
                    Intelligence = (int)dr["intelligence"];
                }
                dr.Close();
            }
        }
    }
}
