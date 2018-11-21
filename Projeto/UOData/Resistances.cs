using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UOData
{
    using MySql.Data.MySqlClient;

    public class Resistances
    {
        public Int32 ID { get; set; }
        public Resistances(DB db, Int32 id)
        {
            MySqlDataReader dr = db.ExecuteQuery("SELECT * FROM resistances WHERE id = " + id);
            while (dr.Read())
            {
                ID = (int)dr["id"];
            }
            dr.Close();
        }
    }
}
