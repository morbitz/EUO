using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace UOData
{
    using MySql.Data.MySqlClient;

    public class Mobile
	{
		public Int32 ID { get; set; }
		public String Name { get; set; }
        public Int16 AccessLevel { get; set; }
        public Boolean Alive { get; set; }
        public Int32 Backpack { get; set; }
        public Attributes Attributes { get; set; }
        public Resistances Resistances { get; set; }
        public Gears Gears { get; set; }
        public Style Style { get; set; }
        public Int32 Model { get; set; }
        public Point3D Position { get; set; }
        public Byte Direction { get; set; }
        public Int16 Notoriety { get; set; }
        public Mobile()
        {
            
        }
        public Mobile(DB db, Int32 id)
        {
            if (db.IsConnected)
            {
                MySqlDataReader dr = db.ExecuteQuery("SELECT * FROM mobile WHERE id = " + id);
                while (dr.Read())
                {
                    ID = (int)dr["id"];
                    Name = (string)dr["name"];
                    Alive = (int)dr["alive"] == 0 ? false : true;
                    Backpack = (int)dr["backpack_id"];
                    Attributes = new Attributes(db, (int)dr["attributes_id"]);
                    Resistances = new Resistances(db, (int)dr["resistances_id"]);
                    Gears = new Gears(db, (int)dr["gears_id"]);
                    Style = new Style(db, (int)dr["styles_id"]);
                    Model = (int)dr["model"];
                    Position = new Point3D((int)dr["x"], (int)dr["y"], (int)dr["z"]);
                    Direction = (byte)dr["direction"];
                    Notoriety = (short)dr["notoriety"];
                }
                dr.Close();
            }
        }
        public Mobile(DatabaseDataContext db, Int32 id)
        {
            try
            {
                var mob = from m in db.mobiles where m.id == id select m;
            }
            catch (Exception e)
            {
            }
        }

	}
}
