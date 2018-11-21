using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UOData
{
    using MySql.Data.MySqlClient;

    public class Style
    {
        public Int32 ID { get; set; }
        public Style()
        {
        }
        public Style(DB db, Int32 id)
        {
            MySqlDataReader dr = db.ExecuteQuery("SELECT * FROM styles WHERE id = " + id);
            while (dr.Read())
            {
                ID = (int)dr["id"];
            }
            dr.Close();
        }
    }
}
