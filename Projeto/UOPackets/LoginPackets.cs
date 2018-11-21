using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using UOData;

namespace UOPackets
{
    public class Encryption
    {
        public static string HashMD5(string pass)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
            {
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            }
            return sb.ToString();
        }
    }

    public class LoginRequestShardList : Packet
    {
        private String m_AccountName;
        private String m_AccountPassword;

        public string AccountName
        {
            get { return m_AccountName; }
            set { m_AccountName = value; }
        }
        public string AccountPassword
        {
            get { return m_AccountPassword; }
            set { m_AccountPassword = value; }
        }

        public LoginRequestShardList() : base (0x80)
        {
            Data = new byte[62];
        }

        public LoginRequestShardList(byte[] data) : base(0x80)
        {
            Data = data;
            m_AccountName = System.Text.Encoding.GetEncoding("utf-8").GetString(data, 1, 30);
            m_AccountPassword = System.Text.Encoding.GetEncoding("utf-8").GetString(data, 31, 30);

            m_AccountName = m_AccountName.Trim('\0');
            m_AccountPassword = Encryption.HashMD5(m_AccountPassword.Trim('\0'));

        }

    }

    public class ServerList : Packet
    {
        private byte m_Flag = 0xFF;
        private Int16 m_NumberOfServers = 1;
        private Int16 m_ServerNumber = 0;
        private String m_ServerName = "EUO";
        private Int16 m_Unknown1 = 0;
        private byte m_PercentFull = 50;
        private sbyte m_TimeZone = -3;
        private byte[] m_ServerIpAddress = new byte[4];

        public byte Flag
        {
            get { return m_Flag; }
            set { m_Flag = value; }
        }
        public short NumberOfServers
        {
            get { return m_NumberOfServers; }
            set { m_NumberOfServers = value; }
        }
        public short ServerNumber
        {
            get { return m_ServerNumber; }
            set { m_ServerNumber = value; }
        }
        public string ServerName
        {
            get { return m_ServerName; }
            set { m_ServerName = value; }
        }
        public short Unknown1
        {
            get { return m_Unknown1; }
            set { m_Unknown1 = value; }
        }
        public byte PercentFull
        {
            get { return m_PercentFull; }
            set { m_PercentFull = value; }
        }
        public sbyte TimeZone
        {
            get { return m_TimeZone; }
            set { m_TimeZone = value; }
        }
        public byte[] ServerIpAddress
        {
            get { return m_ServerIpAddress; }
            set { m_ServerIpAddress = value; }
        }


        public ServerList() : base(0xA8)
        {
            Data = new byte[46];
        }

		public override void Build()
        {
            //Set the packet Id
            Data[0] = Id;
            PacketSize++;
            
            //Start inserting the data
            Insert(PacketSize);
            Insert(m_Flag);
            Insert(m_NumberOfServers);
            Insert(m_ServerNumber);
            Insert(m_ServerName, 30);
            Insert(m_Unknown1);
            Insert(m_PercentFull);
            Insert((byte)m_TimeZone);
            Insert(new byte[] {0x01, 0x00, 0xa8, 0xc0});

            Data[1] = BitConverter.GetBytes(PacketSize)[1];
            Data[2] = BitConverter.GetBytes(PacketSize)[0];

        }

    }

    public class ServerConnect : Packet
    {
    	public IPAddress GameServerIp { get; set; }

    	public Int16 GamePort { get; set; }

    	public Int32 AccountUid { get; set; }

    	public ServerConnect(IPAddress serv, Int16 port, Int32 accid) : base(0x8C)
        {
            Data = new byte[11];
            GameServerIp = serv;
            GamePort = port;
            AccountUid = accid;
        }

		public override void Build()
        {
            Data[0] = Id;
            PacketSize++;

            InsertByte(GameServerIp.GetAddressBytes());
            InsertInt16(GamePort);
            InsertInt32(AccountUid);
        }
    }

    public class CharacterList : Packet
    {
    	private List<Character> m_Characters;

    	public byte NumberOfChars { get; set; }

    	public List<Character> Characters
        {
            get { return m_Characters; }
            set { m_Characters = value; }
        }

        public CharacterList( List<Character> chars ) : base(0xA9)
        {
            m_Characters = chars;
            Data = new byte[1024];
        }

		public override void Build()
        {
            Data[0] = Id;
            PacketSize++;

            InsertInt16(PacketSize);
            InsertByte(0x01);

            foreach (Character character in m_Characters)
            {
                InsertString(character.Name, 30);
                InsertString(character.Password, 30);
            }

            InsertByte(Convert.ToByte(m_Characters.Count-1));
			InsertByte(0x00);
            InsertString("Minoc", 31);
            InsertString("Bank", 31);
            InsertDWord(0x04);
			InsertWord(0x00);

            Data[1] = BitConverter.GetBytes(PacketSize)[1];
            Data[2] = BitConverter.GetBytes(PacketSize)[0];


            byte[] Aux = new byte[PacketSize];
            for (int i = 0; i < PacketSize; i++)
            {
                Aux[i] = Data[i];
            }
            Data = Aux;


           int  size = PacketSize;

            Data = Compression.Compress(Data, 0, size, ref size);



            PacketSize = (short)size;
        }
    }

    public class LoginConfirm : Packet
    {
        public Character m_Char;

        public LoginConfirm(Character c) : base(0x1B)
        {
            Data = new byte[37];
            m_Char = c;
        }

		public override void Build()
        {
            Data[0] = Id;
            PacketSize++;

            InsertInt32( m_Char.Uid );
            InsertInt32( 0x00 );
            InsertInt16( m_Char.CharModel );
            InsertInt16( m_Char.X );
            InsertInt16(m_Char.Y);
            InsertByte( 0x00 );
            InsertByte(m_Char.Z);
            InsertByte(m_Char.Direction);
            InsertInt32( 0 );
            InsertInt32( 0 );
            InsertByte( 0x00 );
            InsertInt16( 6200 );
            InsertInt16(4096);
            InsertInt16( 0x00 );
            InsertInt32( 0x00 );

            int size = Data.Length;

            //m_Data = Compression.Compress(m_Data, 0, size, ref size);

            //PacketSize = (short)size;
        }
    }

    public class ClientFeatures : Packet
    {
        public ClientFeatures() : base(0xB9)
        {
            Data = new byte[3];
        }

		public override void Build()
        {
            Data[0] = Id;
            PacketSize++;

            Insert((short) 0x02  );

            Compress();
        }


    }

    public class CharacterWarmode : Packet
    {
        public CharacterWarmode() : base (0x72)
        {
            Data = new byte[5];
        }

		public override void Build()
        {
            Data[0] = Id;
            PacketSize++;

            InsertByte( 0x00 );
            InsertByte( 0x00 );
            InsertByte( 0x32 );
            InsertByte( 0x00 );

            Compress();
        }
    }

    public class CharacterMapChange : Packet
    {
    	private readonly Byte m_MapFlag;
        public CharacterMapChange(Byte mapflag) : base (0x08)
        {
            Data = new byte[3];
			m_MapFlag = mapflag;
        }

		public override void Build()
        {
            Data[0] = Id;
            PacketSize++;
			InsertByte(0x00);
            InsertByte(m_MapFlag);
        }
    }

	public class AddKeyFastWalkStack : Packet
	{
		private readonly Int32 m_NewKey;
		public AddKeyFastWalkStack(Int32 newkey) : base(0x02)
		{
			Data = new byte[6];
			m_NewKey = newkey;
		}

		public override void Build()
		{
			Data[0] = Id;
			PacketSize++;
			InsertByte(0x00);
			InsertInt32(m_NewKey);
		}
	}

    public class CharacterSync : Packet
    {
        private Character m_Char;

        public CharacterSync(Character c) : base (0x20)
        {
            Data = new byte[19];
            m_Char = c;
        }

        public override void Build()
        {
            Data[0] = Id;
            PacketSize++;

            InsertInt32( m_Char.Uid );
            InsertInt16( m_Char.CharModel );
            InsertByte( 0x00 );
            InsertInt16( 0x4000 );
            InsertByte( 0x00 );
            InsertInt16( m_Char.X );
            InsertInt16( m_Char.Y );
            InsertByte( 0 );
            InsertByte( m_Char.Direction );
            InsertByte( m_Char.Z );

            Compress();
        }

    }

    public class LoginComplete : Packet
    {
        public LoginComplete() : base(0x55)
        {
            Data = new byte[1];
        }

        public override void Build()
        {
            Data[0] = Id;
            PacketSize++;
        }
    }

	public class Subcommands : Packet
	{
		private readonly Packet m_Subcommand;
			public Subcommands(Packet sub) : base(0xBF)
		{
			m_Subcommand = new Packet(sub.Id);
			m_Subcommand.Data = sub.Data;
			m_Subcommand.PacketSize = sub.PacketSize;
			
			Data = new byte[sub.PacketSize + 3];
		}
		public override void Build()
		{
			Data[0] = Id;
			PacketSize++;
			InsertInt16(m_Subcommand.PacketSize);
			m_Subcommand.Build();
			for (int i = 0; i < m_Subcommand.Data.Length; i++)
			{
				
				Data[PacketSize] = m_Subcommand.Data[i];
				PacketSize++;
			}
			Compress();
		}
	}

    public class Features : Packet
    {
        Int16 m_Flags = 0;
        public Features() : base(0xB9)
        {
            
        }
        /// <summary>
        /// Features to enable
        /// </summary>
        /// <param name="flags"></param>
        public Features(Int16 flags)
        {
            m_Flags = flags;
        }
        public override void Build()
        {
            InsertByte(Id);
            InsertInt16(m_Flags);
            Compress();
        }
    }
}
