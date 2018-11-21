using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace UOPackets
{
    public enum Sex
    {
        Male = 0,
        Female = 1,
    }

    public enum Skill
    {
        
    }

    public class CreateCharacter : Packet
    {
        private Int64 m_Pattern1;
        private Int64 m_Pattern2;
        private byte m_Pattern3;
        private String m_CharName;
        private String m_CharPassword;
        private Sex m_Gender;
        private Int32 m_Str;
        private Int32 m_Dex;
        private Int32 m_Int;
        private Skill m_Skill1;
        private Double m_Skill1Value;
        private Skill m_Skill2;
        private Double m_Skill2Value;
        private Skill m_Skill3;
        private Double m_Skill3Value;
        private Int32 m_SkinColor;
        private Int32 m_HairStyle;
        private Int32 m_HairColor;
        private Int32 m_FacialHairStyle;
        private Int32 m_FacialHairColor;
        private Int32 m_StartLocation;
        private Int32 m_Unknown1;
        private Int32 m_SlotNumber;
        private Int64 m_ClientIp;
        private Int32 m_ShirtColor;
        private Int32 m_PantsColor;

        public CreateCharacter() : base(0x00)
        {
			
        }

        public void ReceivePacket(byte[] data)
        {
            Data = data;

            m_Pattern1 = data[1];
            m_Pattern2 = data[5];
            m_Pattern3 = data[9];
            m_CharName = BitConverter.ToString(data, 10, 30 );
            m_CharName = BitConverter.ToString(data, 40, 30);
            //m_Gender = 
        }



        /// <summary>
        /// always 0xedededed
        /// </summary>
        public long Pattern1
        {
            get { return m_Pattern1; }
            set { m_Pattern1 = value; }
        }

        /// <summary>
        /// always 0xffffffff
        /// </summary>
        public long Pattern2
        {
            get { return m_Pattern2; }
            set { m_Pattern2 = value; }
        }

        /// <summary>
        /// always 0x00
        /// </summary>
        public byte Pattern3
        {
            get { return m_Pattern3; }
            set { m_Pattern3 = value; }
        }

        /// <summary>
        /// Character name
        /// </summary>
        public string CharName
        {
            get { return m_CharName; }
            set { m_CharName = value; }
        }

        /// <summary>
        /// Character password
        /// </summary>
        public string CharPassword
        {
            get { return m_CharPassword; }
            set { m_CharPassword = value; }
        }

        /// <summary>
        /// Male or Female
        /// </summary>
        public Sex Gender
        {
            get { return m_Gender; }
            set { m_Gender = value; }
        }

        /// <summary>
        /// Strengh
        /// </summary>
        public int Str
        {
            get { return m_Str; }
            set { m_Str = value; }
        }

        /// <summary>
        /// Dextery
        /// </summary>
        public int Dex
        {
            get { return m_Dex; }
            set { m_Dex = value; }
        }

        /// <summary>
        /// Intelligence
        /// </summary>
        public int Int
        {
            get { return m_Int; }
            set { m_Int = value; }
        }

        /// <summary>
        /// First skill
        /// </summary>
        public Skill Skill1
        {
            get { return m_Skill1; }
            set { m_Skill1 = value; }
        }

        /// <summary>
        /// First skill value
        /// </summary>
        public double Skill1Value
        {
            get { return m_Skill1Value; }
            set { m_Skill1Value = value; }
        }

        /// <summary>
        /// Second skill
        /// </summary>
        public Skill Skill2
        {
            get { return m_Skill2; }
            set { m_Skill2 = value; }
        }

        /// <summary>
        /// Second skill value
        /// </summary>
        public double Skill2Value
        {
            get { return m_Skill2Value; }
            set { m_Skill2Value = value; }
        }

        /// <summary>
        /// Third skill
        /// </summary>
        public Skill Skill3
        {
            get { return m_Skill3; }
            set { m_Skill3 = value; }
        }

        /// <summary>
        /// Third skill value
        /// </summary>
        public double Skill3Value
        {
            get { return m_Skill3Value; }
            set { m_Skill3Value = value; }
        }

        /// <summary>
        /// Skin color hue number
        /// </summary>
        public int SkinColor
        {
            get { return m_SkinColor; }
            set { m_SkinColor = value; }
        }

        /// <summary>
        /// Hair style number
        /// </summary>
        public int HairStyle
        {
            get { return m_HairStyle; }
            set { m_HairStyle = value; }
        }

        /// <summary>
        /// Hair color hue number
        /// </summary>
        public int HairColor
        {
            get { return m_HairColor; }
            set { m_HairColor = value; }
        }

        /// <summary>
        /// Facial hair style number
        /// </summary>
        public int FacialHairStyle
        {
            get { return m_FacialHairStyle; }
            set { m_FacialHairStyle = value; }
        }

        /// <summary>
        /// Skin color hue number
        /// </summary>
        public int FacialHairColor
        {
            get { return m_FacialHairColor; }
            set { m_FacialHairColor = value; }
        }

        /// <summary>
        /// Selected location
        /// </summary>
        public int StartLocation
        {
            get { return m_StartLocation; }
            set { m_StartLocation = value; }
        }

        /// <summary>
        /// Unknown
        /// </summary>
        public int Unknown1
        {
            get { return m_Unknown1; }
            set { m_Unknown1 = value; }
        }

        /// <summary>
        /// Character slot number
        /// </summary>
        public int SlotNumber
        {
            get { return m_SlotNumber; }
            set { m_SlotNumber = value; }
        }

        /// <summary>
        /// Client Ip
        /// </summary>
        public long ClientIp
        {
            get { return m_ClientIp; }
            set { m_ClientIp = value; }
        }

        /// <summary>
        /// Shirt color hue number
        /// </summary>
        public int ShirtColor
        {
            get { return m_ShirtColor; }
            set { m_ShirtColor = value; }
        }

        /// <summary>
        /// Pants color hue number
        /// </summary>
        public int PantsColor
        {
            get { return m_PantsColor; }
            set { m_PantsColor = value; }
        }
    }

}