using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using QWord = System.Int64;
using DWord = System.Int32;
using Word = System.Int16;
using UOData;
namespace UOPackets
{
	/// <summary>
	/// Animate Packet.
	/// </summary>
	public class Animate : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown packet */
		public Animate() : base (0x1E)
		{
			Data = new Byte [4];
			UnknownData = new Byte [3];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Explode Packet.
	/// </summary>
	public class Explode : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown packet */
		public Explode() : base (0x1F)
		{
			Data = new Byte [8];
			UnknownData = new Byte [7];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unused Packet.
	/// </summary>
	public class Unused : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public Unused() : base (0x8F)
		{
			UnknownData = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// System Info Packet.
	/// </summary>
	public class SystemInfo : Packet
	{
		public Byte[] UnknownData { get; set; }
		public SystemInfo() : base (0xA4)
		{
			Data = new Byte [149];
			UnknownData = new Byte [148];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Unknown { get; set; }
		public Unknown() : base (0xBF)
		{
			Filler0 = 0x24;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Unknown() : base (0xBF)
		{
			Filler0 = 0x27;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Unknown() : base (0xCD)
		{
			Data = new Byte [1];
		}
		public void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public Unknown() : base (0xCE)
		{
			UnknownData = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Unknown() : base (0xCF)
		{
			Data = new Byte [78];
			UnknownData = new Byte [77];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public Unknown() : base (0xD0)
		{
			UnknownData = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Unknown() : base (0xD2)
		{
			Data = new Byte [25];
			UnknownData = new Byte [24];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public Unknown() : base (0xD3)
		{
			UnknownData = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public Unknown() : base (0xD5)
		{
			UnknownData = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Unknown() : base (0xEE)
		{
			Data = new Byte [10];
			UnknownData = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
}
