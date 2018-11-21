using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UOData
{
    public enum Notoriety : short
    {
        None = 0,
        Innocent = 1,
        Guild = 2,
        Neutral = 3,
        Criminal = 4,
        Enemy = 5,
        Murderer = 6,
        Invulnerable = 7,
    }

    public class Character
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public Int32 Uid
        {
            get;
            set;
        }
        public Int16 CharModel { get; set; }
        public Int16 X { get; set; }
        public Int16 Y { get; set; }
        public byte Z { get; set; }
        public byte Direction { get; set; }
        public Int16 Notoriety { get; set; }


        public Character()
        {
            
        }
    }
}
