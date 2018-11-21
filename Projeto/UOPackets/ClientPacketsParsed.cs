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
using UQWord = System.UInt64;
using UDWord = System.UInt32;
using UWord = System.UInt16;
using UOData;
namespace UOPackets.ClientPackets
{
	/// <summary>
	/// Create a new character (2D clients).
	/// </summary>
	public class CharacterCreation : Packet
	{
		public UDWord Filler0 { get; set; }
		public UDWord Filler1 { get; set; }
		public Byte Filler2 { get; set; }
		public Char[] CharacterName { get; set; }
		public Word Filler3 { get; set; }
		public ClientFlags0 ClientFlags04 { get; set; }
		public DWord Filler5 { get; set; }
		public DWord ClientLoginCount { get; set; }
		public Byte Profession { get; set; }
		public Byte[] Filler6 { get; set; }
		public GenderandRace1 GenderandRace17 { get; set; }
		public Byte Strength { get; set; }
		public Byte Dexterity { get; set; }
		public Byte Intelligence { get; set; }
		public Byte Skill1 { get; set; }
		public Byte Skill1Amount { get; set; }
		public Byte Skill2 { get; set; }
		public Byte Skill2Amount { get; set; }
		public Byte Skill3 { get; set; }
		public Byte Skill3Amount { get; set; }
		public Word SkinColor { get; set; }
		public Word HairStyle { get; set; }
		public Word HairColor { get; set; }
		public Word BeardStyle { get; set; }
		public Word BeardColor { get; set; }
		public Byte ShardIndex { get; set; }
		public Byte StartingCity { get; set; }
		public DWord CharacterSlot { get; set; }
		public DWord ClientIP { get; set; }
		public Word ShirtColor { get; set; }
		public Word PantsColor { get; set; }
		public CharacterCreation() : base (0x00)
		{
			Data = new Byte [104];
			Filler0 = 0xEDEDEDED;
			Filler1 = 0xFFFFFFFF;
            Filler2 = 0x00;
			CharacterName = new Char [30];
			Filler3 = 0x00;
			Filler5 = 0x01;
			Filler6 = new Byte [15];
			for (Int32 i=0; i<Filler6.Length; i++)
			{
				Filler6[i] = 0x00;
			}
		}
		public CharacterCreation( Byte[] pktdata ) : base (0x00)
		{
			Filler0 = (uint)BitConverter.ToInt32(pktdata[1]);
			Filler1 = (uint)BitConverter.ToInt32(pktdata[5]);
			Filler2 = (Byte)pktdata[9];
			Filler3 = (short)BitConverter.ToInt16(pktdata[10]);
			ClientFlags04 = (int)BitConverter.ToInt32(pktdata[12]);
			Filler5 = (int)BitConverter.ToInt32(pktdata[16]);
			ClientLoginCount = (int)BitConverter.ToInt32(pktdata[20]);
			Profession = (Byte)pktdata[24];
			GenderandRace17 = (byte)pktdata[25];
			Strength = (Byte)pktdata[26];
			Dexterity = (Byte)pktdata[27];
			Intelligence = (Byte)pktdata[28];
			Skill1 = (Byte)pktdata[29];
			Skill1Amount = (Byte)pktdata[30];
			Skill2 = (Byte)pktdata[31];
			Skill2Amount = (Byte)pktdata[32];
			Skill3 = (Byte)pktdata[33];
			Skill3Amount = (Byte)pktdata[34];
			SkinColor = (short)BitConverter.ToInt16(pktdata[35]);
			HairStyle = (short)BitConverter.ToInt16(pktdata[37]);
			HairColor = (short)BitConverter.ToInt16(pktdata[39]);
			BeardStyle = (short)BitConverter.ToInt16(pktdata[41]);
			BeardColor = (short)BitConverter.ToInt16(pktdata[43]);
			ShardIndex = (Byte)pktdata[45];
			StartingCity = (Byte)pktdata[46];
			CharacterSlot = (int)BitConverter.ToInt32(pktdata[47]);
			ClientIP = (int)BitConverter.ToInt32(pktdata[51]);
			ShirtColor = (short)BitConverter.ToInt16(pktdata[55]);
			PantsColor = (short)BitConverter.ToInt16(pktdata[57]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertUDWord(Filler0);
			InsertUDWord(Filler1);
			InsertByte(Filler2);
			InsertChar(CharacterName);
			InsertWord(Filler3);
			InsertDWord((DWord)ClientFlags04);
			InsertDWord(Filler5);
			InsertDWord(ClientLoginCount);
			InsertByte(Profession);
			InsertByte(Filler6);
			InsertByte((Byte)GenderandRace17);
			InsertByte(Strength);
			InsertByte(Dexterity);
			InsertByte(Intelligence);
			InsertByte(Skill1);
			InsertByte(Skill1Amount);
			InsertByte(Skill2);
			InsertByte(Skill2Amount);
			InsertByte(Skill3);
			InsertByte(Skill3Amount);
			InsertWord(SkinColor);
			InsertWord(HairStyle);
			InsertWord(HairColor);
			InsertWord(BeardStyle);
			InsertWord(BeardColor);
			InsertByte(ShardIndex);
			InsertByte(StartingCity);
			InsertDWord(CharacterSlot);
			InsertDWord(ClientIP);
			InsertWord(ShirtColor);
			InsertWord(PantsColor);
		}
	}
	/// <summary>
	/// Character returns to main menu from character select menu.
	/// </summary>
	public class Logout : Packet
	{
		public UDWord Filler0 { get; set; }
		public Logout() : base (0x01)
		{
			Data = new Byte [5];
            Filler0 = 0xFFFFFFFF;
		}
		public Logout( Byte[] pktdata ) : base (0x01)
		{
			Filler0 = (uint)BitConverter.ToInt32(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertUDWord(Filler0);
		}
	}
	/// <summary>
	/// Ask the server if we can walk.
	/// </summary>
	public class MovementRequest : Packet
	{
		public Direction2 Direction20 { get; set; }
		public Byte SequenceNumber { get; set; }
		public DWord FastwalkPreventionKey { get; set; }
		public MovementRequest() : base (0x02)
		{
			Data = new Byte [7];
		}
		public MovementRequest( Byte[] pktdata ) : base (0x02)
		{
			Direction20 = (byte)pktdata[1];
			SequenceNumber = (Byte)pktdata[2];
			FastwalkPreventionKey = (int)BitConverter.ToInt32(pktdata[3]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Direction20);
			InsertByte(SequenceNumber);
			InsertDWord(FastwalkPreventionKey);
		}
    }
	/// <summary>
	/// Send ascii speech to the server.
	/// </summary>
	public class AsciiSpeech : Packet
	{
		public Word SizeofPacket { get; set; }
		public Mode3 Mode30 { get; set; }
		public Word TextColor { get; set; }
		public Word Font { get; set; }
		public String Text { get; set; }
		public AsciiSpeech() : base (0x03)
		{
		}
		public AsciiSpeech( Byte[] pktdata ) : base (0x03)
		{
			SizeofPacket = (short)BitConverter.ToInt16(pktdata[1]);
			Mode30 = (byte)pktdata[3];
			TextColor = (short)BitConverter.ToInt16(pktdata[4]);
			Font = (short)BitConverter.ToInt16(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(SizeofPacket);
			InsertByte((Byte)Mode30);
			InsertWord(TextColor);
			InsertWord(Font);
			InsertString(Text);
		}
	}
	/// <summary>
	/// God Mode Request Packet.
	/// </summary>
	public class ToggleGodModeRequest : Packet
	{
		public Byte GodModeOn_Off { get; set; }
		public ToggleGodModeRequest() : base (0x04)
		{
			Data = new Byte [2];
		}
		public ToggleGodModeRequest( Byte[] pktdata ) : base (0x04)
		{
			GodModeOn_Off = (Byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(GodModeOn_Off);
		}
	}
	/// <summary>
	/// Send attack request to server.
	/// </summary>
	public class AttackRequest : Packet
	{
		public DWord CombatantSerial { get; set; }
		/* If Last Attack and combatant is null, send owner's serial. */
		public AttackRequest() : base (0x05)
		{
			Data = new Byte [5];
		}
		public AttackRequest( Byte[] pktdata ) : base (0x05)
		{
			CombatantSerial = (int)BitConverter.ToInt32(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(CombatantSerial);
		}
	}
	/// <summary>
	/// Ask the server if we can use an object (double click).
	/// </summary>
	public class UseRequest : Packet
	{
		public DWord ItemSerial { get; set; }
		public UseRequest() : base (0x06)
		{
			Data = new Byte [5];
		}
		public UseRequest( Byte[] pktdata ) : base (0x06)
		{
			ItemSerial = (int)BitConverter.ToInt32(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ItemSerial);
		}
	}
	/// <summary>
	/// Ask the server if we can lift an object.
	/// </summary>
	public class LiftRequest : Packet
	{
		public DWord ItemSerial { get; set; }
		public Word ItemAmount { get; set; }
		public LiftRequest() : base (0x07)
		{
			Data = new Byte [7];
		}
		public LiftRequest( Byte[] pktdata ) : base (0x07)
		{
			ItemSerial = (int)BitConverter.ToInt32(pktdata[1]);
			ItemAmount = (short)BitConverter.ToInt16(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ItemSerial);
			InsertWord(ItemAmount);
		}
	}
	/// <summary>
	/// Ask the server if we can lift an object.
	/// </summary>
	public class DropRequest : Packet
	{
		public DWord ItemSerial { get; set; }
		public Word ItemX { get; set; }
		public Word ItemY { get; set; }
		public SByte ItemZ { get; set; }
		public Byte GridLocation { get; set; }
		public DWord ContainerSerial { get; set; }
		/* Grid Location only since 6.0.1.7 2D and 2.45.5.6 UO3D */
		public DropRequest() : base (0x08)
		{
			Data = new Byte [15];
		}
		public DropRequest( Byte[] pktdata ) : base (0x08)
		{
			ItemSerial = (int)BitConverter.ToInt32(pktdata[1]);
			ItemX = (short)BitConverter.ToInt16(pktdata[5]);
			ItemY = (short)BitConverter.ToInt16(pktdata[7]);
			ItemZ = (SByte)pktdata[9];
			GridLocation = (Byte)pktdata[10];
			ContainerSerial = (int)BitConverter.ToInt32(pktdata[11]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ItemSerial);
			InsertWord(ItemX);
			InsertWord(ItemY);
			InsertSByte(ItemZ);
			InsertByte(GridLocation);
			InsertDWord(ContainerSerial);
		}
	}
	/// <summary>
	/// Ask the server to look at an item (single click).
	/// </summary>
	public class LookRequest : Packet
	{
		public DWord ItemSerial { get; set; }
		public LookRequest() : base (0x09)
		{
			Data = new Byte [5];
		}
		public LookRequest( Byte[] pktdata ) : base (0x09)
		{
			ItemSerial = (int)BitConverter.ToInt32(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ItemSerial);
		}
	}
	/// <summary>
	/// Edit npcs, dynamic and static items.
	/// </summary>
	public class EditItem : Packet
	{
		public Byte Type { get; set; }
		public Word ItemX { get; set; }
		public Word ItemY { get; set; }
		public Word ItemID { get; set; }
		public SByte ItemZ { get; set; }
		public Word ItemHue { get; set; }
		/* Types are: 0x04 = Dynamic Item, 0x07 = NPC, 0x0A = Static Item, 0x0B = Add New Static Item (Force Static Creation) */
		public EditItem() : base (0x0A)
		{
			Data = new Byte [11];
		}
		public EditItem( Byte[] pktdata ) : base (0x0A)
		{
			Type = (Byte)pktdata[1];
			ItemX = (short)BitConverter.ToInt16(pktdata[2]);
			ItemY = (short)BitConverter.ToInt16(pktdata[4]);
			ItemID = (short)BitConverter.ToInt16(pktdata[6]);
			ItemZ = (SByte)pktdata[8];
			ItemHue = (short)BitConverter.ToInt16(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Type);
			InsertWord(ItemX);
			InsertWord(ItemY);
			InsertWord(ItemID);
			InsertSByte(ItemZ);
			InsertWord(ItemHue);
		}
	}
	/// <summary>
	/// Hack Mover Request Packet.
	/// </summary>
	public class HackMoverRequest : Packet
	{
		public Byte Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public OnOff4 OnOff42 { get; set; }
		public Byte[] Filler3 { get; set; }
		public HackMoverRequest() : base (0x0A)
		{
			Data = new Byte [11];
			Filler0 = 0x06;
			Filler1 = 0x00;
			Filler3 = new Byte [7];
			for (Int32 i=0; i<Filler3.Length; i++)
			{
				Filler3[i] = 0x00;
			}
		}
		public HackMoverRequest( Byte[] pktdata ) : base (0x0A)
		{
			Filler0 = (Byte)pktdata[1];
			Filler1 = (Byte)pktdata[2];
			OnOff42 = (byte)pktdata[3];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Filler0);
			InsertByte(Filler1);
			InsertByte((Byte)OnOff42);
			InsertByte(Filler3);
		}
	}
	/// <summary>
	/// Text Command Packet.
	/// </summary>
	public class TextCommand : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		public TextCommand() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public TextCommand( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Filler0 = (Byte)pktdata[4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(Arguments);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Go to location Packet.
	/// </summary>
	public class Gotolocation : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String X { get; set; }
		public Char Whitespace { get; set; }
		public String Y { get; set; }
		public Char Whitespace2 { get; set; }
		public String Z { get; set; }
		public Byte Filler0 { get; set; }
		/* God Client packet */
		public Gotolocation() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public Gotolocation( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Whitespace = (Char)pktdata[4];
			Whitespace2 = (Char)pktdata[5];
			Filler0 = (Byte)pktdata[6];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(X);
			InsertChar(Whitespace);
			InsertString(Y);
			InsertChar(Whitespace2);
			InsertString(Z);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Use Skill/LastSkill Packet.
	/// </summary>
	public class UseSkill_LastSkill : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		public UseSkill_LastSkill() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public UseSkill_LastSkill( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Whitespace = (Char)pktdata[4];
			Filler0 = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Cast Skill from the spellbook Packet.
	/// </summary>
	public class CastSkillfromthespellbook : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String SpellID { get; set; }
		public Char Whitespace { get; set; }
		public String SpellbookSerial { get; set; }
		public Byte Filler0 { get; set; }
		/* Old clients packet */
		public CastSkillfromthespellbook() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public CastSkillfromthespellbook( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Whitespace = (Char)pktdata[4];
			Filler0 = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(SpellID);
			InsertChar(Whitespace);
			InsertString(SpellbookSerial);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Open Spellbook Packet.
	/// </summary>
	public class OpenSpellbook : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		public OpenSpellbook() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public OpenSpellbook( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Filler0 = (Byte)pktdata[4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Change Hue Packet.
	/// </summary>
	public class ChangeHue : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String Hue { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		/* God Client packet */
		public ChangeHue() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public ChangeHue( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Whitespace = (Char)pktdata[4];
			Filler0 = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(Hue);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Cast Skill from macro Packet.
	/// </summary>
	public class CastSkillfrommacro : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String SpellID { get; set; }
		public Byte Filler0 { get; set; }
		/* Old clients packet */
		public CastSkillfrommacro() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public CastSkillfrommacro( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Filler0 = (Byte)pktdata[4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(SpellID);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Open Door Packet.
	/// </summary>
	public class OpenDoor : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		public OpenDoor() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public OpenDoor( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Filler0 = (Byte)pktdata[4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// GM Menu Packet.
	/// </summary>
	public class GMMenu : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String Command { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Char Whitespace2 { get; set; }
		public String Arguments2 { get; set; }
		public Byte Filler0 { get; set; }
		/* God Client packet */
		public GMMenu() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public GMMenu( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Whitespace = (Char)pktdata[4];
			Whitespace2 = (Char)pktdata[5];
			Filler0 = (Byte)pktdata[6];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(Command);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertChar(Whitespace2);
			InsertString(Arguments2);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Action Packet.
	/// </summary>
	public class Action : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String ActionName { get; set; }
		public Byte Filler0 { get; set; }
		public Action() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public Action( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Filler0 = (Byte)pktdata[4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(ActionName);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// GM Page Request Packet.
	/// </summary>
	public class GMPageRequest : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		/* God Client packet */
		public GMPageRequest() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public GMPageRequest( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Filler0 = (Byte)pktdata[4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// GM Page Response Packet.
	/// </summary>
	public class GMPageResponse : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public String Arguments { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments2 { get; set; }
		public Char Whitespace2 { get; set; }
		public String Arguments3 { get; set; }
		public Byte Filler0 { get; set; }
		/* God Client packet */
		public GMPageResponse() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public GMPageResponse( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Whitespace = (Char)pktdata[4];
			Whitespace2 = (Char)pktdata[5];
			Filler0 = (Byte)pktdata[6];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertString(Arguments);
			InsertChar(Whitespace);
			InsertString(Arguments2);
			InsertChar(Whitespace2);
			InsertString(Arguments3);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Invoke Virtue Packet.
	/// </summary>
	public class InvokeVirtue : Packet
	{
		public Word Packetsize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		public InvokeVirtue() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public InvokeVirtue( Byte[] pktdata ) : base (0x12)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			CommandType = (Byte)pktdata[3];
			Filler0 = (Byte)pktdata[4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(CommandType);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Ask the server if we can equip an object.
	/// </summary>
	public class EquipRequest : Packet
	{
		public DWord ItemSerial { get; set; }
		public ItemLayer8 ItemLayer80 { get; set; }
		public DWord ContainerSerial { get; set; }
		public EquipRequest() : base (0x13)
		{
			Data = new Byte [10];
		}
		public EquipRequest( Byte[] pktdata ) : base (0x13)
		{
			ItemSerial = (int)BitConverter.ToInt32(pktdata[1]);
			ItemLayer80 = (byte)pktdata[5];
			ContainerSerial = (int)BitConverter.ToInt32(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ItemSerial);
			InsertByte((Byte)ItemLayer80);
			InsertDWord(ContainerSerial);
		}
	}
	/// <summary>
	/// Change Tile Z Packet.
	/// </summary>
	public class ChangeTileZ : Packet
	{
		public Word X { get; set; }
		public Word Y { get; set; }
		public SByte Z { get; set; }
		/* God Client packet */
		public ChangeTileZ() : base (0x14)
		{
			Data = new Byte [6];
		}
		public ChangeTileZ( Byte[] pktdata ) : base (0x14)
		{
			X = (short)BitConverter.ToInt16(pktdata[1]);
			Y = (short)BitConverter.ToInt16(pktdata[3]);
			Z = (SByte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(X);
			InsertWord(Y);
			InsertSByte(Z);
		}
	}
	/// <summary>
	/// Remove Object Packet.
	/// </summary>
	public class RemoveObject : Packet
	{
		public DWord ObjectSerial { get; set; }
		public RemoveObject() : base (0x1D)
		{
			Data = new Byte [5];
		}
		public RemoveObject( Byte[] pktdata ) : base (0x1D)
		{
			ObjectSerial = (int)BitConverter.ToInt32(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ObjectSerial);
		}
	}
	/// <summary>
	/// Movement Accepted Packet.
	/// </summary>
	public class MovementAccepted : Packet
	{
		public Byte Sequence { get; set; }
		public Byte Status { get; set; }
		public MovementAccepted() : base (0x22)
		{
			Data = new Byte [3];
		}
		public MovementAccepted( Byte[] pktdata ) : base (0x22)
		{
			Sequence = (Byte)pktdata[1];
			Status = (Byte)pktdata[2];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Sequence);
			InsertByte(Status);
		}
	}
	/// <summary>
	/// Death Status Packet.
	/// </summary>
	public class DeathStatus : Packet
	{
		public Status19 Status190 { get; set; }
		public DeathStatus() : base (0x2C)
		{
			Data = new Byte [2];
		}
		public DeathStatus( Byte[] pktdata ) : base (0x2C)
		{
			Status190 = (byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Status190);
		}
	}
	/// <summary>
	/// Toggle Hack Mover Packet.
	/// </summary>
	public class ToggleHackMover : Packet
	{
		public Byte On_Off { get; set; }
		/* God Client Packet */
		public ToggleHackMover() : base (0x32)
		{
			Data = new Byte [2];
		}
		public ToggleHackMover( Byte[] pktdata ) : base (0x32)
		{
			On_Off = (Byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(On_Off);
		}
	}
	/// <summary>
	/// Group Command Packet.
	/// </summary>
	public class GroupCommand : Packet
	{
		public Byte Command { get; set; }
		/* God Client Packet */
		public GroupCommand() : base (0x33)
		{
			Data = new Byte [2];
		}
		public GroupCommand( Byte[] pktdata ) : base (0x33)
		{
			Command = (Byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Mobile Query Packet.
	/// </summary>
	public class MobileQuery : Packet
	{
		public UDWord Filler0 { get; set; }
		public Type21 Type211 { get; set; }
		public DWord Serial { get; set; }
		public MobileQuery() : base (0x34)
		{
			Data = new Byte [10];
            Filler0 = 0xEDEDEDED;
		}
		public MobileQuery( Byte[] pktdata ) : base (0x34)
		{
			Filler0 = (uint)BitConverter.ToInt32(pktdata[1]);
			Type211 = (byte)pktdata[5];
			Serial = (int)BitConverter.ToInt32(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertUDWord(Filler0);
			InsertByte((Byte)Type211);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Move Object Packet.
	/// </summary>
	public class MoveObject : Packet
	{
		public DWord ObjectSerial { get; set; }
		public Byte ZOffset { get; set; }
		public Byte YOffset { get; set; }
		public Byte XOffset { get; set; }
		/* God Client Packet. */
		public MoveObject() : base (0x37)
		{
			Data = new Byte [8];
		}
		public MoveObject( Byte[] pktdata ) : base (0x37)
		{
			ObjectSerial = (int)BitConverter.ToInt32(pktdata[1]);
			ZOffset = (Byte)pktdata[5];
			YOffset = (Byte)pktdata[6];
			XOffset = (Byte)pktdata[7];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ObjectSerial);
			InsertByte(ZOffset);
			InsertByte(YOffset);
			InsertByte(XOffset);
		}
	}
	/// <summary>
	/// Skills Update Packet.
	/// </summary>
	public class SkillsUpdate : Packet
	{
		public Word Packetsize { get; set; }
		public Word SkillID { get; set; }
		public Byte LockStatus { get; set; }
		public SkillsUpdate() : base (0x3A)
		{
		}
		public SkillsUpdate( Byte[] pktdata ) : base (0x3A)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			SkillID = (short)BitConverter.ToInt16(pktdata[3]);
			LockStatus = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(SkillID);
			InsertByte(LockStatus);
		}
	}
	/// <summary>
	/// Vendor Interaction Packet.
	/// </summary>
	public class VendorInteraction : Packet
	{
		public Word Packetsize { get; set; }
		public DWord VendorSerial { get; set; }
		public Flag23 Flag230 { get; set; }
		Item Items1 { get; set; }
		public VendorInteraction() : base (0x3B)
		{
			Items1 = new Item();
		}
		public VendorInteraction( Byte[] pktdata ) : base (0x3B)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			VendorSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Flag230 = (byte)pktdata[7];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(VendorSerial);
			InsertByte((Byte)Flag230);
		}
	}
	/// <summary>
	/// New Terrain Packet.
	/// </summary>
	public class NewTerrain : Packet
	{
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word ID { get; set; }
		public Word Width { get; set; }
		public Word Height { get; set; }
		/* God Client Packet */
		public NewTerrain() : base (0x47)
		{
			Data = new Byte [11];
		}
		public NewTerrain( Byte[] pktdata ) : base (0x47)
		{
			X = (short)BitConverter.ToInt16(pktdata[1]);
			Y = (short)BitConverter.ToInt16(pktdata[3]);
			ID = (short)BitConverter.ToInt16(pktdata[5]);
			Width = (short)BitConverter.ToInt16(pktdata[7]);
			Height = (short)BitConverter.ToInt16(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(ID);
			InsertWord(Width);
			InsertWord(Height);
		}
	}
	/// <summary>
	/// Destroy Art Packet.
	/// </summary>
	public class DestroyArt : Packet
	{
		public DWord ArtID { get; set; }
		/* God Client Packet */
		public DestroyArt() : base (0x4A)
		{
			Data = new Byte [5];
		}
		public DestroyArt( Byte[] pktdata ) : base (0x4A)
		{
			ArtID = (int)BitConverter.ToInt32(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(ArtID);
		}
	}
	/// <summary>
	/// New Region Packet.
	/// </summary>
	public class NewRegion : Packet
	{
		public Char[] RegionName { get; set; }
		public DWord Filler0 { get; set; }
		public Word StartX { get; set; }
		public Word StartY { get; set; }
		public Word Width { get; set; }
		public Word Height { get; set; }
		public Word StartZ { get; set; }
		public Word EndZ { get; set; }
		public Char[] RegionDescription { get; set; }
		public Word SoundFX { get; set; }
		public Word Music { get; set; }
		public Word NightFX { get; set; }
		public Byte Dungeon { get; set; }
		public Word Light { get; set; }
		/* God Client Packet */
		public NewRegion() : base (0x58)
		{
			Data = new Byte [106];
			RegionName = new Char [40];
			Filler0 = 0x00;
			RegionDescription = new Char [40];
		}
		public NewRegion( Byte[] pktdata ) : base (0x58)
		{
			Filler0 = (int)BitConverter.ToInt32(pktdata[1]);
			StartX = (short)BitConverter.ToInt16(pktdata[5]);
			StartY = (short)BitConverter.ToInt16(pktdata[7]);
			Width = (short)BitConverter.ToInt16(pktdata[9]);
			Height = (short)BitConverter.ToInt16(pktdata[11]);
			StartZ = (short)BitConverter.ToInt16(pktdata[13]);
			EndZ = (short)BitConverter.ToInt16(pktdata[15]);
			SoundFX = (short)BitConverter.ToInt16(pktdata[17]);
			Music = (short)BitConverter.ToInt16(pktdata[19]);
			NightFX = (short)BitConverter.ToInt16(pktdata[21]);
			Dungeon = (Byte)pktdata[23];
			Light = (short)BitConverter.ToInt16(pktdata[24]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertChar(RegionName);
			InsertDWord(Filler0);
			InsertWord(StartX);
			InsertWord(StartY);
			InsertWord(Width);
			InsertWord(Height);
			InsertWord(StartZ);
			InsertWord(EndZ);
			InsertChar(RegionDescription);
			InsertWord(SoundFX);
			InsertWord(Music);
			InsertWord(NightFX);
			InsertByte(Dungeon);
			InsertWord(Light);
		}
	}
	/// <summary>
	/// Destroy Static Packet.
	/// </summary>
	public class DestroyStatic : Packet
	{
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word Z { get; set; }
		public Word ID { get; set; }
		/* God Client Packet */
		public DestroyStatic() : base (0x61)
		{
			Data = new Byte [9];
		}
		public DestroyStatic( Byte[] pktdata ) : base (0x61)
		{
			X = (short)BitConverter.ToInt16(pktdata[1]);
			Y = (short)BitConverter.ToInt16(pktdata[3]);
			Z = (short)BitConverter.ToInt16(pktdata[5]);
			ID = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(Z);
			InsertWord(ID);
		}
	}
	/// <summary>
	/// Move Static Packet.
	/// </summary>
	public class MoveStatic : Packet
	{
		public Word OldX { get; set; }
		public Word OldY { get; set; }
		public Word OldZ { get; set; }
		public Word ID { get; set; }
		public Word XOffset { get; set; }
		public Word YOffset { get; set; }
		public Word ZOffset { get; set; }
		/* God Client Packet */
		public MoveStatic() : base (0x62)
		{
			Data = new Byte [15];
		}
		public MoveStatic( Byte[] pktdata ) : base (0x62)
		{
			OldX = (short)BitConverter.ToInt16(pktdata[1]);
			OldY = (short)BitConverter.ToInt16(pktdata[3]);
			OldZ = (short)BitConverter.ToInt16(pktdata[5]);
			ID = (short)BitConverter.ToInt16(pktdata[7]);
			XOffset = (short)BitConverter.ToInt16(pktdata[9]);
			YOffset = (short)BitConverter.ToInt16(pktdata[11]);
			ZOffset = (short)BitConverter.ToInt16(pktdata[13]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(OldX);
			InsertWord(OldY);
			InsertWord(OldZ);
			InsertWord(ID);
			InsertWord(XOffset);
			InsertWord(YOffset);
			InsertWord(ZOffset);
		}
	}
	/// <summary>
	/// Area Load Request Packet.
	/// </summary>
	public class AreaLoadRequest : Packet
	{
		/* God Client Packet */
		public AreaLoadRequest() : base (0x64)
		{
			Data = new Byte [1];
		}
		public AreaLoadRequest( Byte[] pktdata ) : base (0x64)
		{
		}
		public override void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Book page Packet.
	/// </summary>
	public class BookPage : Packet
	{
		public Word Packetsize { get; set; }
		public DWord BookSerial { get; set; }
		public Word PagesCount { get; set; }
		Pages Pages0 { get; set; }
		public BookPage() : base (0x66)
		{
			Pages0 = new Pages();
		}
		public BookPage( Byte[] pktdata ) : base (0x66)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			BookSerial = (int)BitConverter.ToInt32(pktdata[3]);
			PagesCount = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(BookSerial);
			InsertWord(PagesCount);
		}
	}
	/// <summary>
	/// Target Packet.
	/// </summary>
	public class Target : Packet
	{
		public TargetType29 TargetType290 { get; set; }
		public DWord SenderSerial { get; set; }
		public Flags30 Flags301 { get; set; }
		public DWord ObjectSerial { get; set; }
		public X31 X312 { get; set; }
		public Y32 Y323 { get; set; }
		public Word Z { get; set; }
		public Graphic33 Graphic334 { get; set; }
		public Target() : base (0x6C)
		{
			Data = new Byte [19];
		}
		public Target( Byte[] pktdata ) : base (0x6C)
		{
			TargetType290 = (byte)pktdata[1];
			SenderSerial = (int)BitConverter.ToInt32(pktdata[2]);
			Flags301 = (byte)pktdata[6];
			ObjectSerial = (int)BitConverter.ToInt32(pktdata[7]);
			X312 = (short)BitConverter.ToInt16(pktdata[11]);
			Y323 = (short)BitConverter.ToInt16(pktdata[13]);
			Z = (short)BitConverter.ToInt16(pktdata[15]);
			Graphic334 = (short)BitConverter.ToInt16(pktdata[17]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)TargetType290);
			InsertDWord(SenderSerial);
			InsertByte((Byte)Flags301);
			InsertDWord(ObjectSerial);
			InsertWord((Word)X312);
			InsertWord((Word)Y323);
			InsertWord(Z);
			InsertWord((Word)Graphic334);
		}
	}
	/// <summary>
	/// Bulletin Board Packet.
	/// </summary>
	public class BulletinBoard : Packet
	{
		public Word Packetsize { get; set; }
		public Byte Command { get; set; }
		public BulletinBoard() : base (0x71)
		{
		}
		public BulletinBoard( Byte[] pktdata ) : base (0x71)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Command = (Byte)pktdata[3];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Get Message Bulletin Board Packet.
	/// </summary>
	public class GetMessageBulletinBoard : Packet
	{
		public Word Packetsize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public GetMessageBulletinBoard() : base (0x71)
		{
			Filler0 = 0x03;
		}
		public GetMessageBulletinBoard( Byte[] pktdata ) : base (0x71)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (Byte)pktdata[3];
			BoardSerial = (int)BitConverter.ToInt32(pktdata[4]);
			MessageSerial = (int)BitConverter.ToInt32(pktdata[8]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertDWord(MessageSerial);
		}
	}
	/// <summary>
	/// Get Message Summary Bulletin Board Packet.
	/// </summary>
	public class GetMessageSummaryBulletinBoard : Packet
	{
		public Word Packetsize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public GetMessageSummaryBulletinBoard() : base (0x71)
		{
			Filler0 = 0x04;
		}
		public GetMessageSummaryBulletinBoard( Byte[] pktdata ) : base (0x71)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (Byte)pktdata[3];
			BoardSerial = (int)BitConverter.ToInt32(pktdata[4]);
			MessageSerial = (int)BitConverter.ToInt32(pktdata[8]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertDWord(MessageSerial);
		}
	}
	/// <summary>
	/// Post Message Bulletin Board Packet.
	/// </summary>
	public class PostMessageBulletinBoard : Packet
	{
		public Word Packetsize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public ReplyMessageSerial45 ReplyMessageSerial451 { get; set; }
		public Byte SubjectLength { get; set; }
		public String Subject { get; set; }
		public Byte NumberLines { get; set; }
		Line Line2 { get; set; }
		public PostMessageBulletinBoard() : base (0x71)
		{
			Filler0 = 0x05;
			Line2 = new Line();
		}
		public PostMessageBulletinBoard( Byte[] pktdata ) : base (0x71)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (Byte)pktdata[3];
			BoardSerial = (int)BitConverter.ToInt32(pktdata[4]);
			ReplyMessageSerial451 = (int)BitConverter.ToInt32(pktdata[8]);
			SubjectLength = (Byte)pktdata[12];
			NumberLines = (Byte)pktdata[13];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertDWord((DWord)ReplyMessageSerial451);
			InsertByte(SubjectLength);
			InsertString(Subject);
			InsertByte(NumberLines);
		}
	}
	/// <summary>
	/// Delete Message Bulletin Board Packet.
	/// </summary>
	public class DeleteMessageBulletinBoard : Packet
	{
		public Word Packetsize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public DeleteMessageBulletinBoard() : base (0x71)
		{
			Filler0 = 0x06;
		}
		public DeleteMessageBulletinBoard( Byte[] pktdata ) : base (0x71)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (Byte)pktdata[3];
			BoardSerial = (int)BitConverter.ToInt32(pktdata[4]);
			MessageSerial = (int)BitConverter.ToInt32(pktdata[8]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertDWord(MessageSerial);
		}
	}
	/// <summary>
	/// War Mode Packet.
	/// </summary>
	public class WarMode : Packet
	{
		public Byte Warmode { get; set; }
		public Byte Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public WarMode() : base (0x72)
		{
			Data = new Byte [5];
			Filler0 = 0x32;
			Filler1 = 0x00;
		}
		public WarMode( Byte[] pktdata ) : base (0x72)
		{
			Warmode = (Byte)pktdata[1];
			Filler0 = (Byte)pktdata[2];
			Filler1 = (Byte)pktdata[3];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Warmode);
			InsertByte(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Ping Packet.
	/// </summary>
	public class Ping : Packet
	{
		public Byte Value { get; set; }
		public Ping() : base (0x73)
		{
			Data = new Byte [2];
		}
		public Ping( Byte[] pktdata ) : base (0x73)
		{
			Value = (Byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Value);
		}
	}
	/// <summary>
	/// Rename Request Packet.
	/// </summary>
	public class RenameRequest : Packet
	{
		public DWord Serial { get; set; }
		public Char[] Name { get; set; }
		public RenameRequest() : base (0x75)
		{
			Data = new Byte [35];
			Name = new Char [30];
		}
		public RenameRequest( Byte[] pktdata ) : base (0x75)
		{
			Serial = (int)BitConverter.ToInt32(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertChar(Name);
		}
	}
	/// <summary>
	/// God View Query Packet.
	/// </summary>
	public class GodViewQuery : Packet
	{
		public ToggleGodViewQuery52 ToggleGodViewQuery520 { get; set; }
		public GodViewQuery() : base (0x7E)
		{
			Data = new Byte [2];
		}
		public GodViewQuery( Byte[] pktdata ) : base (0x7E)
		{
			ToggleGodViewQuery520 = (byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)ToggleGodViewQuery520);
		}
	}
	/// <summary>
	/// Account Login Request Packet.
	/// </summary>
	public class AccountLoginRequest : Packet
	{
		public Char[] AccountName { get; set; }
		public Char[] Password { get; set; }
		public Byte Command { get; set; }
		public AccountLoginRequest() : base (0x80)
		{
			Data = new Byte [62];
			AccountName = new Char [30];
			Password = new Char [30];
		}
		public AccountLoginRequest( Byte[] pktdata ) : base (0x80)
		{
			Command = (Byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertChar(AccountName);
			InsertChar(Password);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Delete Character Packet.
	/// </summary>
	public class DeleteCharacter : Packet
	{
		public Char[] Password { get; set; }
		public DWord CharacterIndex { get; set; }
		public DWord ClientIP { get; set; }
		public DeleteCharacter() : base (0x83)
		{
			Data = new Byte [39];
			Password = new Char [30];
		}
		public DeleteCharacter( Byte[] pktdata ) : base (0x83)
		{
			CharacterIndex = (int)BitConverter.ToInt32(pktdata[1]);
			ClientIP = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertChar(Password);
			InsertDWord(CharacterIndex);
			InsertDWord(ClientIP);
		}
	}
	/// <summary>
	/// Create New Character (3D clients).
	/// </summary>
	public class UO3DCreateCharacter : Packet
	{
		public Word Packetsize { get; set; }
		public UDWord Filler0 { get; set; }
		public DWord CharacterSlot { get; set; }
		public Char[] CharacterName { get; set; }
		public Char[] Unknown { get; set; }
		public Byte Profession { get; set; }
		public ClientFlags56 ClientFlags561 { get; set; }
		public Gender57 Gender572 { get; set; }
		public Race58 Race583 { get; set; }
		public Byte Strength { get; set; }
		public Byte Dexterity { get; set; }
		public Byte Intelligence { get; set; }
		public Word SkinColor { get; set; }
		public DWord Filler4 { get; set; }
		public DWord Filler5 { get; set; }
		public Byte Skill1 { get; set; }
		public Byte Skill1Amount { get; set; }
		public Byte Skill2 { get; set; }
		public Byte Skill2Amount { get; set; }
		public Byte Skill3 { get; set; }
		public Byte Skill3Amount { get; set; }
		public Byte Skill4 { get; set; }
		public Byte Skill4Amount { get; set; }
		public Byte[] Filler6 { get; set; }
		public Byte Filler7 { get; set; }
		public Word HairColor { get; set; }
		public Word HairStyle { get; set; }
		public Byte Filler8 { get; set; }
		public DWord Filler9 { get; set; }
		public Byte Filler10 { get; set; }
		public Word ShirtColor { get; set; }
		public Word ShirtItemID { get; set; }
		public Byte Filler11 { get; set; }
		public Word FaceColor { get; set; }
		public Word FaceItemID { get; set; }
		public Byte Filler12 { get; set; }
		public Word BeardColor { get; set; }
		public Word BeardStyle { get; set; }
		public UO3DCreateCharacter() : base (0x8D)
		{
			Filler0 = 0xEDEDEDED;
			CharacterName = new Char [30];
			Unknown = new Char [30];
			Filler4 = 0x00;
			Filler5 = 0x00;
			Filler6 = new Byte [25];
			for (Int32 i=0; i<Filler6.Length; i++)
			{
				Filler6[i] = 0x00;
			}
			Filler7 = 0x0B;
			Filler8 = 0x0C;
			Filler9 = 0x00;
			Filler10 = 0x0D;
			Filler11 = 0x0F;
			Filler12 = 0x10;
		}
		public UO3DCreateCharacter( Byte[] pktdata ) : base (0x8D)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (uint)BitConverter.ToInt32(pktdata[3]);
			CharacterSlot = (int)BitConverter.ToInt32(pktdata[7]);
			Profession = (Byte)pktdata[11];
			ClientFlags561 = (byte)pktdata[12];
			Gender572 = (byte)pktdata[13];
			Race583 = (byte)pktdata[14];
			Strength = (Byte)pktdata[15];
			Dexterity = (Byte)pktdata[16];
			Intelligence = (Byte)pktdata[17];
			SkinColor = (short)BitConverter.ToInt16(pktdata[18]);
			Filler4 = (int)BitConverter.ToInt32(pktdata[20]);
			Filler5 = (int)BitConverter.ToInt32(pktdata[24]);
			Skill1 = (Byte)pktdata[28];
			Skill1Amount = (Byte)pktdata[29];
			Skill2 = (Byte)pktdata[30];
			Skill2Amount = (Byte)pktdata[31];
			Skill3 = (Byte)pktdata[32];
			Skill3Amount = (Byte)pktdata[33];
			Skill4 = (Byte)pktdata[34];
			Skill4Amount = (Byte)pktdata[35];
			Filler7 = (Byte)pktdata[36];
			HairColor = (short)BitConverter.ToInt16(pktdata[37]);
			HairStyle = (short)BitConverter.ToInt16(pktdata[39]);
			Filler8 = (Byte)pktdata[41];
			Filler9 = (int)BitConverter.ToInt32(pktdata[42]);
			Filler10 = (Byte)pktdata[46];
			ShirtColor = (short)BitConverter.ToInt16(pktdata[47]);
			ShirtItemID = (short)BitConverter.ToInt16(pktdata[49]);
			Filler11 = (Byte)pktdata[51];
			FaceColor = (short)BitConverter.ToInt16(pktdata[52]);
			FaceItemID = (short)BitConverter.ToInt16(pktdata[54]);
			Filler12 = (Byte)pktdata[56];
			BeardColor = (short)BitConverter.ToInt16(pktdata[57]);
			BeardStyle = (short)BitConverter.ToInt16(pktdata[59]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertUDWord(Filler0);
			InsertDWord(CharacterSlot);
			InsertChar(CharacterName);
			InsertChar(Unknown);
			InsertByte(Profession);
			InsertByte((Byte)ClientFlags561);
			InsertByte((Byte)Gender572);
			InsertByte((Byte)Race583);
			InsertByte(Strength);
			InsertByte(Dexterity);
			InsertByte(Intelligence);
			InsertWord(SkinColor);
			InsertDWord(Filler4);
			InsertDWord(Filler5);
			InsertByte(Skill1);
			InsertByte(Skill1Amount);
			InsertByte(Skill2);
			InsertByte(Skill2Amount);
			InsertByte(Skill3);
			InsertByte(Skill3Amount);
			InsertByte(Skill4);
			InsertByte(Skill4Amount);
			InsertByte(Filler6);
			InsertByte(Filler7);
			InsertWord(HairColor);
			InsertWord(HairStyle);
			InsertByte(Filler8);
			InsertDWord(Filler9);
			InsertByte(Filler10);
			InsertWord(ShirtColor);
			InsertWord(ShirtItemID);
			InsertByte(Filler11);
			InsertWord(FaceColor);
			InsertWord(FaceItemID);
			InsertByte(Filler12);
			InsertWord(BeardColor);
			InsertWord(BeardStyle);
		}
	}
	/// <summary>
	/// Book Change Header Packet.
	/// </summary>
	public class BookChangeHeader : Packet
	{
		public DWord BookSerial { get; set; }
		public Editable59 Editable590 { get; set; }
		public Byte Filler1 { get; set; }
		public Word NumberOfPages { get; set; }
		public Char[] Title { get; set; }
		public Char[] Author { get; set; }
		/* Old Clients packet. */
		public BookChangeHeader() : base (0x93)
		{
			Data = new Byte [99];
			Filler1 = 0x01;
			Title = new Char [60];
			Author = new Char [30];
		}
		public BookChangeHeader( Byte[] pktdata ) : base (0x93)
		{
			BookSerial = (int)BitConverter.ToInt32(pktdata[1]);
			Editable590 = (byte)pktdata[5];
			Filler1 = (Byte)pktdata[6];
			NumberOfPages = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(BookSerial);
			InsertByte((Byte)Editable590);
			InsertByte(Filler1);
			InsertWord(NumberOfPages);
			InsertChar(Title);
			InsertChar(Author);
		}
	}
	/// <summary>
	/// Hue Picker Packet.
	/// </summary>
	public class HuePicker : Packet
	{
		public DWord Serial { get; set; }
		public Word ItemId { get; set; }
		public Word Hue { get; set; }
		public HuePicker() : base (0x95)
		{
			Data = new Byte [9];
		}
		public HuePicker( Byte[] pktdata ) : base (0x95)
		{
			Serial = (int)BitConverter.ToInt32(pktdata[1]);
			ItemId = (short)BitConverter.ToInt16(pktdata[5]);
			Hue = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(ItemId);
			InsertWord(Hue);
		}
	}
	/// <summary>
	/// Mobile Name Packet.
	/// </summary>
	public class MobileName : Packet
	{
		public Word Packetsize { get; set; }
		public DWord MobileSerial { get; set; }
		public Char[] Mobilename { get; set; }
		public MobileName() : base (0x98)
		{
			Mobilename = new Char [30];
		}
		public MobileName( Byte[] pktdata ) : base (0x98)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			MobileSerial = (int)BitConverter.ToInt32(pktdata[3]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(MobileSerial);
			InsertChar(Mobilename);
		}
	}
	/// <summary>
	/// Ascii Prompt Response Packet.
	/// </summary>
	public class AsciiPromptResponse : Packet
	{
		public Word Packetsize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord PromptID { get; set; }
		public Type63 Type630 { get; set; }
		public String Text { get; set; }
		public AsciiPromptResponse() : base (0x9A)
		{
		}
		public AsciiPromptResponse( Byte[] pktdata ) : base (0x9A)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			SenderSerial = (int)BitConverter.ToInt32(pktdata[3]);
			PromptID = (int)BitConverter.ToInt32(pktdata[7]);
			Type630 = (int)BitConverter.ToInt32(pktdata[11]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(SenderSerial);
			InsertDWord(PromptID);
			InsertDWord((DWord)Type630);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Help Gump Request Packet.
	/// </summary>
	public class HelpGumpRequest : Packet
	{
		public Byte[] Filler0 { get; set; }
		public HelpGumpRequest() : base (0x9B)
		{
			Data = new Byte [258];
			Filler0 = new Byte [257];
			for (Int32 i=0; i<Filler0.Length; i++)
			{
				Filler0[i] = 0x00;
			}
		}
		public HelpGumpRequest( Byte[] pktdata ) : base (0x9B)
		{
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Shop Offer Packet.
	/// </summary>
	public class ShopOffer : Packet
	{
		public Word Packetsize { get; set; }
		public DWord VendorSerial { get; set; }
		public Word ItemsCount { get; set; }
		Item Items0 { get; set; }
		public ShopOffer() : base (0x9F)
		{
			Items0 = new Item();
		}
		public ShopOffer( Byte[] pktdata ) : base (0x9F)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			VendorSerial = (int)BitConverter.ToInt32(pktdata[3]);
			ItemsCount = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(VendorSerial);
			InsertWord(ItemsCount);
		}
	}
	/// <summary>
	/// Play Server Packet.
	/// </summary>
	public class PlayServer : Packet
	{
		public Word ServerIndex { get; set; }
		public PlayServer() : base (0xA0)
		{
			Data = new Byte [3];
		}
		public PlayServer( Byte[] pktdata ) : base (0xA0)
		{
			ServerIndex = (short)BitConverter.ToInt16(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(ServerIndex);
		}
	}
	/// <summary>
	/// Request Scroll Message Packet.
	/// </summary>
	public class RequestScrollMessage : Packet
	{
		public Word LastTipNumber { get; set; }
		public Byte FontType { get; set; }
		public RequestScrollMessage() : base (0xA7)
		{
			Data = new Byte [4];
		}
		public RequestScrollMessage( Byte[] pktdata ) : base (0xA7)
		{
			LastTipNumber = (short)BitConverter.ToInt16(pktdata[1]);
			FontType = (Byte)pktdata[3];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(LastTipNumber);
			InsertByte(FontType);
		}
	}
	/// <summary>
	/// String Query Packet.
	/// </summary>
	public class StringQuery : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Byte ParentID { get; set; }
		public Byte ButtonID { get; set; }
		public Word TextLength { get; set; }
		public String Text { get; set; }
		public Style65 Style650 { get; set; }
		public DWord MaxLength { get; set; }
		public Word LabelLength { get; set; }
		public String Label { get; set; }
		public StringQuery() : base (0xAB)
		{
		}
		public StringQuery( Byte[] pktdata ) : base (0xAB)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			ParentID = (Byte)pktdata[7];
			ButtonID = (Byte)pktdata[8];
			TextLength = (short)BitConverter.ToInt16(pktdata[9]);
			Style650 = (byte)pktdata[11];
			MaxLength = (int)BitConverter.ToInt32(pktdata[12]);
			LabelLength = (short)BitConverter.ToInt16(pktdata[16]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertByte(ParentID);
			InsertByte(ButtonID);
			InsertWord(TextLength);
			InsertString(Text);
			InsertByte((Byte)Style650);
			InsertDWord(MaxLength);
			InsertWord(LabelLength);
			InsertString(Label);
		}
	}
	/// <summary>
	/// Unicode Speech Packet.
	/// </summary>
	public class UnicodeSpeech : Packet
	{
		public Word Packetsize { get; set; }
		public Mode67 Mode670 { get; set; }
		public Word TextColor { get; set; }
		public Word Font { get; set; }
		public Char[] Language { get; set; }
		public List<Byte> Keywords { get; set; }
		public String Text { get; set; }
		/* If Mode = 0xC0 then there are keywords (from speech.mul) present. Keywords are using in UO since 2.0.7 client. Keywords: The first 12 bits = the number of keywords present. The keywords are included right after this, each one is 12 bits also. The keywords are padded to the closest byte. For example, if there are 2 keywords, it will take up 5 bytes. 12 bits for the number, and 12 bits for each keyword. 12+12+12=36. Which will be padded 4 bits to 40 bits or 5 bytes. */
		public UnicodeSpeech() : base (0xAD)
		{
			Language = new Char [4];
			Keywords = new List<Byte>();
		}
		public UnicodeSpeech( Byte[] pktdata ) : base (0xAD)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Mode670 = (byte)pktdata[3];
			TextColor = (short)BitConverter.ToInt16(pktdata[4]);
			Font = (short)BitConverter.ToInt16(pktdata[6]);
			for (Int32 i = 8; i < (PacketSize - 0); i+= 1)
			{
				Keywords.Add((pktdata[i]));
			}
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte((Byte)Mode670);
			InsertWord(TextColor);
			InsertWord(Font);
			InsertChar(Language);
			InsertByte(Keywords);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Gump Response Packet.
	/// </summary>
	public class GumpResponse : Packet
	{
		public Word Packetsize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord GumpID { get; set; }
		public DWord ButtonID { get; set; }
		public DWord SwitchesCount { get; set; }
		Switches Switches0 { get; set; }
		public DWord TextEntriesCount { get; set; }
		TextEntries TextEntries1 { get; set; }
		public SwitchesCount69 SwitchesCount692 { get; set; }
		public GumpResponse() : base (0xB1)
		{
			Switches0 = new Switches();
			TextEntries1 = new TextEntries();
		}
		public GumpResponse( Byte[] pktdata ) : base (0xB1)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			SenderSerial = (int)BitConverter.ToInt32(pktdata[3]);
			GumpID = (int)BitConverter.ToInt32(pktdata[7]);
			ButtonID = (int)BitConverter.ToInt32(pktdata[11]);
			SwitchesCount = (int)BitConverter.ToInt32(pktdata[15]);
			TextEntriesCount = (int)BitConverter.ToInt32(pktdata[19]);
			SwitchesCount692 = (int)BitConverter.ToInt32(pktdata[23]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(SenderSerial);
			InsertDWord(GumpID);
			InsertDWord(ButtonID);
			InsertDWord(SwitchesCount);
			InsertDWord(TextEntriesCount);
			InsertDWord((DWord)SwitchesCount692);
		}
	}
	/// <summary>
	/// Chat Action Packet.
	/// </summary>
	public class ChatAction : Packet
	{
		public Word Packetsize { get; set; }
		public Char[] Language { get; set; }
		public Action70 Action700 { get; set; }
		public String Parameters { get; set; }
		public ChatAction() : base (0xB3)
		{
			Language = new Char [4];
		}
		public ChatAction( Byte[] pktdata ) : base (0xB3)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Action700 = (short)BitConverter.ToInt16(pktdata[3]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertChar(Language);
			InsertWord((Word)Action700);
			InsertString(Parameters);
		}
	}
	/// <summary>
	/// Chat Open Request Packet.
	/// </summary>
	public class ChatOpenRequest : Packet
	{
		public Byte Filler0 { get; set; }
		public Char[] ChatName { get; set; }
		public ChatOpenRequest() : base (0xB5)
		{
			Data = new Byte [64];
			Filler0 = 0x00;
			ChatName = new Char [31];
		}
		public ChatOpenRequest( Byte[] pktdata ) : base (0xB5)
		{
			Filler0 = (Byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Filler0);
			InsertChar(ChatName);
		}
	}
	/// <summary>
	/// Object Help Request Packet.
	/// </summary>
	public class ObjectHelpRequest : Packet
	{
		public DWord HelpObjectSerial { get; set; }
		public Byte LanguageNumber { get; set; }
		public Char[] Language { get; set; }
		public ObjectHelpRequest() : base (0xB6)
		{
			Data = new Byte [9];
			Language = new Char [3];
		}
		public ObjectHelpRequest( Byte[] pktdata ) : base (0xB6)
		{
			HelpObjectSerial = (int)BitConverter.ToInt32(pktdata[1]);
			LanguageNumber = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(HelpObjectSerial);
			InsertByte(LanguageNumber);
			InsertChar(Language);
		}
	}
	/// <summary>
	/// Profile Request Packet.
	/// </summary>
	public class ProfileRequest : Packet
	{
		public Word Packetsize { get; set; }
		public Mode71 Mode710 { get; set; }
		public DWord Serial { get; set; }
		public Unknown72 Unknown721 { get; set; }
		public Word TextLength { get; set; }
		public String Text { get; set; }
		public ProfileRequest() : base (0xB8)
		{
		}
		public ProfileRequest( Byte[] pktdata ) : base (0xB8)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Mode710 = (byte)pktdata[3];
			Serial = (int)BitConverter.ToInt32(pktdata[4]);
			Unknown721 = (short)BitConverter.ToInt16(pktdata[8]);
			TextLength = (short)BitConverter.ToInt16(pktdata[10]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte((Byte)Mode710);
			InsertDWord(Serial);
			InsertWord((Word)Unknown721);
			InsertWord(TextLength);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Messenger Packet.
	/// </summary>
	public class Messenger : Packet
	{
		public DWord SourceID { get; set; }
		public DWord DestinationID { get; set; }
		public Messenger() : base (0xBB)
		{
			Data = new Byte [9];
		}
		public Messenger( Byte[] pktdata ) : base (0xBB)
		{
			SourceID = (int)BitConverter.ToInt32(pktdata[1]);
			DestinationID = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(SourceID);
			InsertDWord(DestinationID);
		}
	}
	/// <summary>
	/// Client Version Packet.
	/// </summary>
	public class ClientVersion : Packet
	{
		//public Word Packetsize { get; set; }
		public String Version { get; set; }
		/* Only in 2D/UOTD clients. */
		public ClientVersion() : base (0xBD)
		{
			Data = new byte[4096];
		}
		public ClientVersion( Byte[] pktdata ) : base (0xBD)
		{
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertString(Version);

		}
	}
	/// <summary>
	/// Assistance Version Packet.
	/// </summary>
	public class AssistanceVersion : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public String Version { get; set; }
		public AssistanceVersion() : base (0xBE)
		{
		}
		public AssistanceVersion( Byte[] pktdata ) : base (0xBE)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertString(Version);
		}
	}
	/// <summary>
	/// Extended Command Packet.
	/// </summary>
	public class ExtendedCommand : Packet
	{
		public Word Packetsize { get; set; }
		public Word Command { get; set; }
		public ExtendedCommand() : base (0xBF)
		{
		}
		public ExtendedCommand( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Command = (short)BitConverter.ToInt16(pktdata[3]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Command);
		}
	}
	/// <summary>
	/// Party Packet.
	/// </summary>
	public class Party : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte PartyCommand { get; set; }
		public Party() : base (0xBF)
		{
			Filler0 = 0x06;
		}
		public Party( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			PartyCommand = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(PartyCommand);
		}
	}
	/// <summary>
	/// Party Add Member Packet.
	/// </summary>
	public class PartyAddMember : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public PartyAddMember() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x01;
		}
		public PartyAddMember( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Party Remove Member Packet.
	/// </summary>
	public class PartyRemoveMember : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord RemovedMemberSerial { get; set; }
		public PartyRemoveMember() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x02;
		}
		public PartyRemoveMember( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
			RemovedMemberSerial = (int)BitConverter.ToInt32(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(RemovedMemberSerial);
		}
	}
	/// <summary>
	/// Party Private Message Packet.
	/// </summary>
	public class PartyPrivateMessage : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord MemberSerial { get; set; }
		public String Message { get; set; }
		public PartyPrivateMessage() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x03;
		}
		public PartyPrivateMessage( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
			MemberSerial = (int)BitConverter.ToInt32(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(MemberSerial);
			InsertString(Message);
		}
	}
	/// <summary>
	/// Party Chat Packet.
	/// </summary>
	public class PartyChat : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public String Message { get; set; }
		public PartyChat() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x04;
		}
		public PartyChat( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertString(Message);
		}
	}
	/// <summary>
	/// Party Set Can Loot Packet.
	/// </summary>
	public class PartySetCanLoot : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public CanLoot77 CanLoot772 { get; set; }
		public PartySetCanLoot() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x06;
		}
		public PartySetCanLoot( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
			CanLoot772 = (byte)pktdata[6];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertByte((Byte)CanLoot772);
		}
	}
	/// <summary>
	/// Party Accept Invitation Packet.
	/// </summary>
	public class PartyAcceptInvitation : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord PartyLeaderSerial { get; set; }
		public PartyAcceptInvitation() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x08;
		}
		public PartyAcceptInvitation( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
			PartyLeaderSerial = (int)BitConverter.ToInt32(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(PartyLeaderSerial);
		}
	}
	/// <summary>
	/// Party Decline Invitation Packet.
	/// </summary>
	public class PartyDeclineInvitation : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord PartyLeaderSerial { get; set; }
		public PartyDeclineInvitation() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x09;
		}
		public PartyDeclineInvitation( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
			PartyLeaderSerial = (int)BitConverter.ToInt32(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(PartyLeaderSerial);
		}
	}
	/// <summary>
	/// Quest Arrow Packet.
	/// </summary>
	public class QuestArrow : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public RightClick78 RightClick781 { get; set; }
		public QuestArrow() : base (0xBF)
		{
			Filler0 = 0x07;
		}
		public QuestArrow( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			RightClick781 = (byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte((Byte)RightClick781);
		}
	}
	/// <summary>
	/// Disarm Request Packet.
	/// </summary>
	public class DisarmRequest : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Filler2 { get; set; }
		public Word Filler3 { get; set; }
		public DisarmRequest() : base (0xBF)
		{
			Filler0 = 0x09;
			Filler1 = 0x02;
			Filler2 = 0x06;
			Filler3 = 0x00;
		}
		public DisarmRequest( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
			Filler2 = (int)BitConverter.ToInt32(pktdata[6]);
			Filler3 = (short)BitConverter.ToInt16(pktdata[10]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Filler2);
			InsertWord(Filler3);
		}
	}
	/// <summary>
	/// Stun Request Packet.
	/// </summary>
	public class StunRequest : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public List<Byte> Unknown { get; set; }
		public StunRequest() : base (0xBF)
		{
			Filler0 = 0x0A;
			Unknown = new List<Byte>();
		}
		public StunRequest( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			for (Int32 i = 5; i < (PacketSize - 0); i+= 1)
			{
				Unknown.Add((pktdata[i]));
			}
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Client Language Packet.
	/// </summary>
	public class ClientLanguage : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Char[] Language { get; set; }
		public ClientLanguage() : base (0xBF)
		{
			Filler0 = 0x0B;
			Language = new Char [4];
		}
		public ClientLanguage( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertChar(Language);
		}
	}
	/// <summary>
	/// Close Status Packet.
	/// </summary>
	public class CloseStatus : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public CloseStatus() : base (0xBF)
		{
			Filler0 = 0x0C;
		}
		public CloseStatus( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Serial = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Animate Packet.
	/// </summary>
	public class Animate : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Action { get; set; }
		public Animate() : base (0xBF)
		{
			Filler0 = 0x0E;
		}
		public Animate( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Action = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(Action);
		}
	}
	/// <summary>
	/// Client Info Packet.
	/// </summary>
	public class ClientInfo : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public ClientFlags79 ClientFlags792 { get; set; }
		/* Only 2D client packet. Additional way to say server how many facets 2D client has. */
		public ClientInfo() : base (0xBF)
		{
			Filler0 = 0x0F;
			Filler1 = 0x0A;
		}
		public ClientInfo( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (Byte)pktdata[5];
			ClientFlags792 = (int)BitConverter.ToInt32(pktdata[6]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord((DWord)ClientFlags792);
		}
	}
	/// <summary>
	/// Query Properties Packet.
	/// </summary>
	public class QueryProperties : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public QueryProperties() : base (0xBF)
		{
			Filler0 = 0x10;
		}
		public QueryProperties( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Serial = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Context Menu Request Packet.
	/// </summary>
	public class ContextMenuRequest3 : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public ContextMenuRequest3() : base (0xBF)
		{
			Filler0 = 0x13;
		}
		public ContextMenuRequest3( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Serial = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Context Menu Request Packet.
	/// </summary>
	public class ContextMenuRequest2 : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public Word ContextMenuEntryIndex { get; set; }
		public ContextMenuRequest2() : base (0xBF)
		{
			Filler0 = 0x15;
		}
		public ContextMenuRequest2( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Serial = (int)BitConverter.ToInt32(pktdata[5]);
			ContextMenuEntryIndex = (short)BitConverter.ToInt16(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(Serial);
			InsertWord(ContextMenuEntryIndex);
		}
	}
	/// <summary>
	/// Stat Lock Change Packet.
	/// </summary>
	public class StatLockChange : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public StatType87 StatType871 { get; set; }
		public LockValue88 LockValue882 { get; set; }
		public StatLockChange() : base (0xBF)
		{
			Filler0 = 0x1A;
		}
		public StatLockChange( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			StatType871 = (byte)pktdata[5];
			LockValue882 = (byte)pktdata[6];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte((Byte)StatType871);
			InsertByte((Byte)LockValue882);
		}
	}
	/// <summary>
	/// Cast Spell Packet.
	/// </summary>
	public class CastSpell : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Type89 Type891 { get; set; }
		public SpellbookSerial90 SpellbookSerial902 { get; set; }
		/* In latest clients, type is always 0x02. */
		public CastSpell() : base (0xBF)
		{
			Filler0 = 0x1C;
		}
		public CastSpell( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Type891 = (short)BitConverter.ToInt16(pktdata[5]);
			SpellbookSerial902 = (int)BitConverter.ToInt32(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertWord((Word)Type891);
			InsertDWord((DWord)SpellbookSerial902);
		}
	}
	/// <summary>
	/// Query Design Details Packet.
	/// </summary>
	public class QueryDesignDetails : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public QueryDesignDetails() : base (0xBF)
		{
			Filler0 = 0x1E;
		}
		public QueryDesignDetails( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			HouseFoundationSerial = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(HouseFoundationSerial);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Unknown2 { get; set; }
		public Unknown() : base (0xBF)
		{
			Filler0 = 0x24;
		}
		public Unknown( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Unknown2 = (Byte)pktdata[5];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertByte(Unknown2);
		}
	}
	/// <summary>
	/// Change Race Request Packet.
	/// </summary>
	public class ChangeRaceRequest : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Word Hue { get; set; }
		public Word HairID { get; set; }
		public Word HairHue { get; set; }
		public Word FacialHairID { get; set; }
		public Word FacialHairHue { get; set; }
		public ChangeRaceRequest() : base (0xBF)
		{
			Filler0 = 0x2A;
		}
		public ChangeRaceRequest( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Hue = (short)BitConverter.ToInt16(pktdata[5]);
			HairID = (short)BitConverter.ToInt16(pktdata[7]);
			HairHue = (short)BitConverter.ToInt16(pktdata[9]);
			FacialHairID = (short)BitConverter.ToInt16(pktdata[11]);
			FacialHairHue = (short)BitConverter.ToInt16(pktdata[13]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertWord(Hue);
			InsertWord(HairID);
			InsertWord(HairHue);
			InsertWord(FacialHairID);
			InsertWord(FacialHairHue);
		}
	}
	/// <summary>
	/// Use Targeted Item Packet.
	/// </summary>
	public class UseTargetedItem : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord ItemSerial { get; set; }
		public DWord TargetSerial { get; set; }
		public UseTargetedItem() : base (0xBF)
		{
			Filler0 = 0x2C;
		}
		public UseTargetedItem( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			ItemSerial = (int)BitConverter.ToInt32(pktdata[5]);
			TargetSerial = (int)BitConverter.ToInt32(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(ItemSerial);
			InsertDWord(TargetSerial);
		}
	}
	/// <summary>
	/// Cast Targeted Spell Packet.
	/// </summary>
	public class CastTargetedSpell : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord TargetSerial { get; set; }
		public CastTargetedSpell() : base (0xBF)
		{
			Filler0 = 0x2D;
		}
		public CastTargetedSpell( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			TargetSerial = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(TargetSerial);
		}
	}
	/// <summary>
	/// Use Targeted Skill Packet.
	/// </summary>
	public class UseTargetedSkill : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Word SkillID { get; set; }
		public DWord TargetSerial { get; set; }
		public UseTargetedSkill() : base (0xBF)
		{
			Filler0 = 0x2E;
		}
		public UseTargetedSkill( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			SkillID = (short)BitConverter.ToInt16(pktdata[5]);
			TargetSerial = (int)BitConverter.ToInt32(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertWord(SkillID);
			InsertDWord(TargetSerial);
		}
	}
	/// <summary>
	/// KR House Menu Response Packet.
	/// </summary>
	public class KRHouseMenuResponse : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord MobileSerial { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public Command95 Command951 { get; set; }
		public DWord Parameter { get; set; }
		/* Parameter = 0x00 for command = 0x63, 0x65, client-side 0x66, client-side 0x68, client-side 0x6D, client-side 0x6E, client-side 0x6F, client-side 0x70, 0x74, client-side 0x79, client-side 0x7A, client-side 0x7B, client-side 0x7C, 0x7D, 0x7F, client-side 0x80. Parameter = 0x01 for command = server-side 0x66, server-side 0x68, server-side 0x6D, server-side 0x6E, server-side 0x6F, server-side 0x70, server-side 0x79, server-side 0x7A, server-side 0x7B, server-side 0x7C. Parameter = Sign Item ID for command = 0x69, Sign Hanger Item ID for command 0x6A, Sign Post Item ID for command 0x6B, Foundation Item ID for command 0x6C, House Foundation Serial for server-side command 0x80. Parameter = Player Serial for command = 0x71, 0x72, 0x73, 0x75, 0x76, 0x77, 0x78, 0x7E. */
		public KRHouseMenuResponse() : base (0xBF)
		{
			Filler0 = 0x2F;
		}
		public KRHouseMenuResponse( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			MobileSerial = (int)BitConverter.ToInt32(pktdata[5]);
			HouseFoundationSerial = (int)BitConverter.ToInt32(pktdata[9]);
			Command951 = (short)BitConverter.ToInt16(pktdata[13]);
			Parameter = (int)BitConverter.ToInt32(pktdata[15]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(MobileSerial);
			InsertDWord(HouseFoundationSerial);
			InsertWord((Word)Command951);
			InsertDWord(Parameter);
		}
	}
	/// <summary>
	/// UO3D Target By Resource Macro Packet.
	/// </summary>
	public class UO3DTargetByResourceMacro : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public DWord ToolSerial { get; set; }
		public ResourceType96 ResourceType961 { get; set; }
		public UO3DTargetByResourceMacro() : base (0xBF)
		{
			Filler0 = 0x30;
		}
		public UO3DTargetByResourceMacro( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			ToolSerial = (int)BitConverter.ToInt32(pktdata[5]);
			ResourceType961 = (short)BitConverter.ToInt16(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord(ToolSerial);
			InsertWord((Word)ResourceType961);
		}
	}
	/// <summary>
	/// Toggle Gargoyle Flying Packet.
	/// </summary>
	public class ToggleGargoyleFlying : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Word Filler1 { get; set; }
		public DWord Filler2 { get; set; }
		public ToggleGargoyleFlying() : base (0xBF)
		{
			Filler0 = 0x32;
			Filler1 = 0x01;
			Filler2 = 0x00;
		}
		public ToggleGargoyleFlying( Byte[] pktdata ) : base (0xBF)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (short)BitConverter.ToInt16(pktdata[5]);
			Filler2 = (int)BitConverter.ToInt32(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertWord(Filler1);
			InsertDWord(Filler2);
		}
	}
	/// <summary>
	/// Unicode Prompt Packet.
	/// </summary>
	public class UnicodePrompt : Packet
	{
		public Word Packetsize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord PromptID { get; set; }
		public Type101 Type1010 { get; set; }
		public Char[] Language { get; set; }
		public String Text { get; set; }
		public UnicodePrompt() : base (0xC2)
		{
			Language = new Char [4];
		}
		public UnicodePrompt( Byte[] pktdata ) : base (0xC2)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			SenderSerial = (int)BitConverter.ToInt32(pktdata[3]);
			PromptID = (int)BitConverter.ToInt32(pktdata[7]);
			Type1010 = (int)BitConverter.ToInt32(pktdata[11]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(SenderSerial);
			InsertDWord(PromptID);
			InsertDWord((DWord)Type1010);
			InsertChar(Language);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Update Range Change Packet.
	/// </summary>
	public class UpdateRangeChange : Packet
	{
		public Byte Distance { get; set; }
		public UpdateRangeChange() : base (0xC8)
		{
			Data = new Byte [2];
		}
		public UpdateRangeChange( Byte[] pktdata ) : base (0xC8)
		{
			Distance = (Byte)pktdata[1];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Distance);
		}
	}
	/// <summary>
	/// Trip Time Packet.
	/// </summary>
	public class TripTime : Packet
	{
		public Byte Value { get; set; }
		public DWord Ticks { get; set; }
		public TripTime() : base (0xC9)
		{
			Data = new Byte [6];
		}
		public TripTime( Byte[] pktdata ) : base (0xC9)
		{
			Value = (Byte)pktdata[1];
			Ticks = (int)BitConverter.ToInt32(pktdata[2]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Value);
			InsertDWord(Ticks);
		}
	}
	/// <summary>
	/// UTrip Time Packet.
	/// </summary>
	public class UTripTime : Packet
	{
		public Byte Value { get; set; }
		public DWord Ticks { get; set; }
		public UTripTime() : base (0xCA)
		{
			Data = new Byte [6];
		}
		public UTripTime( Byte[] pktdata ) : base (0xCA)
		{
			Value = (Byte)pktdata[1];
			Ticks = (int)BitConverter.ToInt32(pktdata[2]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Value);
			InsertDWord(Ticks);
		}
	}
	/// <summary>
	/// Logout Request Packet.
	/// </summary>
	public class LogoutRequest : Packet
	{
		public LogoutRequest() : base (0xD1)
		{
			Data = new Byte [1];
		}
		public LogoutRequest( Byte[] pktdata ) : base (0xD1)
		{
		}
		public override void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Book Header Packet.
	/// </summary>
	public class BookHeader : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Byte Filler0 { get; set; }
		public Byte Writeable { get; set; }
		public Word PagesCount { get; set; }
		public Word TitleLength { get; set; }
		public String Title { get; set; }
		public Word AuthorLength { get; set; }
		public String Author { get; set; }
		public BookHeader() : base (0xD4)
		{
			Filler0 = 0x01;
		}
		public BookHeader( Byte[] pktdata ) : base (0xD4)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (Byte)pktdata[7];
			Writeable = (Byte)pktdata[8];
			PagesCount = (short)BitConverter.ToInt16(pktdata[9]);
			TitleLength = (short)BitConverter.ToInt16(pktdata[11]);
			AuthorLength = (short)BitConverter.ToInt16(pktdata[13]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertByte(Filler0);
			InsertByte(Writeable);
			InsertWord(PagesCount);
			InsertWord(TitleLength);
			InsertString(Title);
			InsertWord(AuthorLength);
			InsertString(Author);
		}
	}
	/// <summary>
	/// Batch Query Properties Packet.
	/// </summary>
	public class BatchQueryProperties : Packet
	{
		public Word Packetsize { get; set; }
		Item Items0 { get; set; }
		public BatchQueryProperties() : base (0xD6)
		{
			Items0 = new Item();
		}
		public BatchQueryProperties( Byte[] pktdata ) : base (0xD6)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
		}
	}
	/// <summary>
	/// Encoded Command Packet.
	/// </summary>
	public class EncodedCommand : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Command { get; set; }
		public EncodedCommand() : base (0xD7)
		{
		}
		public EncodedCommand( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Command = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Command);
		}
	}
	/// <summary>
	/// Designer Backup Packet.
	/// </summary>
	public class DesignerBackup : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerBackup() : base (0xD7)
		{
			Filler0 = 0x02;
			Filler1 = 0x0A;
		}
		public DesignerBackup( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Designer Restore Packet.
	/// </summary>
	public class DesignerRestore : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerRestore() : base (0xD7)
		{
			Filler0 = 0x03;
			Filler1 = 0x0A;
		}
		public DesignerRestore( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Designer Commit Packet.
	/// </summary>
	public class DesignerCommit : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerCommit() : base (0xD7)
		{
			Filler0 = 0x04;
			Filler1 = 0x0A;
		}
		public DesignerCommit( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Designer Delete Packet.
	/// </summary>
	public class DesignerDelete : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord ItemID { get; set; }
		public Byte Filler2 { get; set; }
		public DWord X { get; set; }
		public Byte Filler3 { get; set; }
		public DWord Y { get; set; }
		public Byte Filler4 { get; set; }
		public DWord Z { get; set; }
		public Byte Filler5 { get; set; }
		public DesignerDelete() : base (0xD7)
		{
			Filler0 = 0x05;
			Filler1 = 0x00;
			Filler2 = 0x00;
			Filler3 = 0x00;
			Filler4 = 0x00;
			Filler5 = 0x0A;
		}
		public DesignerDelete( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
			ItemID = (int)BitConverter.ToInt32(pktdata[10]);
			Filler2 = (Byte)pktdata[14];
			X = (int)BitConverter.ToInt32(pktdata[15]);
			Filler3 = (Byte)pktdata[19];
			Y = (int)BitConverter.ToInt32(pktdata[20]);
			Filler4 = (Byte)pktdata[24];
			Z = (int)BitConverter.ToInt32(pktdata[25]);
			Filler5 = (Byte)pktdata[29];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(ItemID);
			InsertByte(Filler2);
			InsertDWord(X);
			InsertByte(Filler3);
			InsertDWord(Y);
			InsertByte(Filler4);
			InsertDWord(Z);
			InsertByte(Filler5);
		}
	}
	/// <summary>
	/// Designer Build Packet.
	/// </summary>
	public class DesignerBuild : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord ItemID { get; set; }
		public Byte Filler2 { get; set; }
		public DWord X { get; set; }
		public Byte Filler3 { get; set; }
		public DWord Y { get; set; }
		public Byte Filler4 { get; set; }
		public DesignerBuild() : base (0xD7)
		{
			Filler0 = 0x06;
			Filler1 = 0x00;
			Filler2 = 0x00;
			Filler3 = 0x00;
			Filler4 = 0x0A;
		}
		public DesignerBuild( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
			ItemID = (int)BitConverter.ToInt32(pktdata[10]);
			Filler2 = (Byte)pktdata[14];
			X = (int)BitConverter.ToInt32(pktdata[15]);
			Filler3 = (Byte)pktdata[19];
			Y = (int)BitConverter.ToInt32(pktdata[20]);
			Filler4 = (Byte)pktdata[24];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(ItemID);
			InsertByte(Filler2);
			InsertDWord(X);
			InsertByte(Filler3);
			InsertDWord(Y);
			InsertByte(Filler4);
		}
	}
	/// <summary>
	/// Designer Close Packet.
	/// </summary>
	public class DesignerClose : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerClose() : base (0xD7)
		{
			Filler0 = 0x0C;
			Filler1 = 0x0A;
		}
		public DesignerClose( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Designer Stairs Packet.
	/// </summary>
	public class DesignerStairs : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord StairID { get; set; }
		public Byte Filler2 { get; set; }
		public DWord X { get; set; }
		public Byte Filler3 { get; set; }
		public DWord Y { get; set; }
		public Byte Filler4 { get; set; }
		public DesignerStairs() : base (0xD7)
		{
			Filler0 = 0x0D;
			Filler1 = 0x00;
			Filler2 = 0x00;
			Filler3 = 0x00;
			Filler4 = 0x0A;
		}
		public DesignerStairs( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
			StairID = (int)BitConverter.ToInt32(pktdata[10]);
			Filler2 = (Byte)pktdata[14];
			X = (int)BitConverter.ToInt32(pktdata[15]);
			Filler3 = (Byte)pktdata[19];
			Y = (int)BitConverter.ToInt32(pktdata[20]);
			Filler4 = (Byte)pktdata[24];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(StairID);
			InsertByte(Filler2);
			InsertDWord(X);
			InsertByte(Filler3);
			InsertDWord(Y);
			InsertByte(Filler4);
		}
	}
	/// <summary>
	/// Designer Synch Packet.
	/// </summary>
	public class DesignerSynch : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerSynch() : base (0xD7)
		{
			Filler0 = 0x0E;
			Filler1 = 0x0A;
		}
		public DesignerSynch( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Designer Action 2D Packet.
	/// </summary>
	public class DesignerAction2D : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		/* Client sends this packet only if Enable Response is set to 0x01 in 0xD8 packet */
		public DesignerAction2D() : base (0xD7)
		{
			Filler0 = 0x0F;
			Filler1 = 0x0A;
		}
		public DesignerAction2D( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Designer Action 3D Packet.
	/// </summary>
	public class DesignerAction3D : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public QWord Filler1 { get; set; }
		/* Client sends this packet only if Enable Response is set to 0x01 in 0xD8 packet */
		public DesignerAction3D() : base (0xD7)
		{
			Filler0 = 0x0F;
			Filler1 = 0xFF;
		}
		public DesignerAction3D( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (long)BitConverter.ToInt64(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertQWord(Filler1);
		}
	}
	/// <summary>
	/// Designer Clear Packet.
	/// </summary>
	public class DesignerClear : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerClear() : base (0xD7)
		{
			Filler0 = 0x10;
			Filler1 = 0x0A;
		}
		public DesignerClear( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Designer Level Packet.
	/// </summary>
	public class DesignerLevel : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Level { get; set; }
		public Byte Filler2 { get; set; }
		public DesignerLevel() : base (0xD7)
		{
			Filler0 = 0x12;
			Filler1 = 0x00;
			Filler2 = 0x0A;
		}
		public DesignerLevel( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
			Level = (int)BitConverter.ToInt32(pktdata[10]);
			Filler2 = (Byte)pktdata[14];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Level);
			InsertByte(Filler2);
		}
	}
	/// <summary>
	/// Designer Roof Packet.
	/// </summary>
	public class DesignerRoof : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord ItemID { get; set; }
		public Byte Filler2 { get; set; }
		public DWord X { get; set; }
		public Byte Filler3 { get; set; }
		public DWord Y { get; set; }
		public Byte Filler4 { get; set; }
		public DWord Z { get; set; }
		public Byte Filler5 { get; set; }
		public DesignerRoof() : base (0xD7)
		{
			Filler0 = 0x13;
			Filler1 = 0x00;
			Filler2 = 0x00;
			Filler3 = 0x00;
			Filler4 = 0x00;
			Filler5 = 0x0A;
		}
		public DesignerRoof( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
			ItemID = (int)BitConverter.ToInt32(pktdata[10]);
			Filler2 = (Byte)pktdata[14];
			X = (int)BitConverter.ToInt32(pktdata[15]);
			Filler3 = (Byte)pktdata[19];
			Y = (int)BitConverter.ToInt32(pktdata[20]);
			Filler4 = (Byte)pktdata[24];
			Z = (int)BitConverter.ToInt32(pktdata[25]);
			Filler5 = (Byte)pktdata[29];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(ItemID);
			InsertByte(Filler2);
			InsertDWord(X);
			InsertByte(Filler3);
			InsertDWord(Y);
			InsertByte(Filler4);
			InsertDWord(Z);
			InsertByte(Filler5);
		}
	}
	/// <summary>
	/// Designer Roof Delete Packet.
	/// </summary>
	public class DesignerRoofDelete : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord ItemID { get; set; }
		public Byte Filler2 { get; set; }
		public DWord X { get; set; }
		public Byte Filler3 { get; set; }
		public DWord Y { get; set; }
		public Byte Filler4 { get; set; }
		public DWord Z { get; set; }
		public Byte Filler5 { get; set; }
		public DesignerRoofDelete() : base (0xD7)
		{
			Filler0 = 0x14;
			Filler1 = 0x00;
			Filler2 = 0x00;
			Filler3 = 0x00;
			Filler4 = 0x00;
			Filler5 = 0x0A;
		}
		public DesignerRoofDelete( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
			ItemID = (int)BitConverter.ToInt32(pktdata[10]);
			Filler2 = (Byte)pktdata[14];
			X = (int)BitConverter.ToInt32(pktdata[15]);
			Filler3 = (Byte)pktdata[19];
			Y = (int)BitConverter.ToInt32(pktdata[20]);
			Filler4 = (Byte)pktdata[24];
			Z = (int)BitConverter.ToInt32(pktdata[25]);
			Filler5 = (Byte)pktdata[29];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(ItemID);
			InsertByte(Filler2);
			InsertDWord(X);
			InsertByte(Filler3);
			InsertDWord(Y);
			InsertByte(Filler4);
			InsertDWord(Z);
			InsertByte(Filler5);
		}
	}
	/// <summary>
	/// Set Weapon Ability Packet.
	/// </summary>
	public class SetWeaponAbility : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord AbilityIndex { get; set; }
		public Byte Filler2 { get; set; }
		public SetWeaponAbility() : base (0xD7)
		{
			Filler0 = 0x19;
			Filler1 = 0x00;
			Filler2 = 0x0A;
		}
		public SetWeaponAbility( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
			AbilityIndex = (int)BitConverter.ToInt32(pktdata[10]);
			Filler2 = (Byte)pktdata[14];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(AbilityIndex);
			InsertByte(Filler2);
		}
	}
	/// <summary>
	/// Design Revert Packet.
	/// </summary>
	public class DesignRevert : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignRevert() : base (0xD7)
		{
			Filler0 = 0x1A;
			Filler1 = 0x0A;
		}
		public DesignRevert( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Equip Last Weapon Packet.
	/// </summary>
	public class EquipLastWeapon : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public EquipLastWeapon() : base (0xD7)
		{
			Filler0 = 0x1E;
			Filler1 = 0x0A;
		}
		public EquipLastWeapon( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Guild Button Request Packet.
	/// </summary>
	public class GuildButtonRequest : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public GuildButtonRequest() : base (0xD7)
		{
			Filler0 = 0x28;
			Filler1 = 0x0A;
		}
		public GuildButtonRequest( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Quests Button Request Packet.
	/// </summary>
	public class QuestsButtonRequest : Packet
	{
		public Word Packetsize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public QuestsButtonRequest() : base (0xD7)
		{
			Filler0 = 0x32;
			Filler1 = 0x0A;
		}
		public QuestsButtonRequest( Byte[] pktdata ) : base (0xD7)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Serial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Filler1 = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(Serial);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Hardware Info Packet.
	/// </summary>
	public class HardwareInfo : Packet
	{
		public ClientType113 ClientType1130 { get; set; }
		public DWord InstanceID { get; set; }
		public DWord OSMajor { get; set; }
		public DWord OSMinor { get; set; }
		public DWord OSRevision { get; set; }
		public Byte CPUManifacture { get; set; }
		public DWord CPUFamily { get; set; }
		public DWord CPUModel { get; set; }
		public DWord CPUClockSpeed { get; set; }
		public Byte CPUQuantity { get; set; }
		public DWord PhysicalMemory { get; set; }
		public DWord ScreenWidth { get; set; }
		public DWord ScreenHeight { get; set; }
		public DWord ScreenDepth { get; set; }
		public Word DirectXMajor { get; set; }
		public Word DirectXMinor { get; set; }
		public Char[] VideoCardDescription { get; set; }
		public DWord VideoCardVendorID { get; set; }
		public DWord VideoCardDeviceID { get; set; }
		public DWord VideoCardMemory { get; set; }
		public Byte Distribution { get; set; }
		public Byte ClientsRunning { get; set; }
		public Byte ClientsInstalled { get; set; }
		public Byte ClientsPartialInstalled { get; set; }
		public Char[] Language { get; set; }
		public Char[] Unknown { get; set; }
		public HardwareInfo() : base (0xD9)
		{
			Data = new Byte [268];
			VideoCardDescription = new Char [64];
			Language = new Char [4];
			Unknown = new Char [32];
		}
		public HardwareInfo( Byte[] pktdata ) : base (0xD9)
		{
			ClientType1130 = (byte)pktdata[1];
			InstanceID = (int)BitConverter.ToInt32(pktdata[2]);
			OSMajor = (int)BitConverter.ToInt32(pktdata[6]);
			OSMinor = (int)BitConverter.ToInt32(pktdata[10]);
			OSRevision = (int)BitConverter.ToInt32(pktdata[14]);
			CPUManifacture = (Byte)pktdata[18];
			CPUFamily = (int)BitConverter.ToInt32(pktdata[19]);
			CPUModel = (int)BitConverter.ToInt32(pktdata[23]);
			CPUClockSpeed = (int)BitConverter.ToInt32(pktdata[27]);
			CPUQuantity = (Byte)pktdata[31];
			PhysicalMemory = (int)BitConverter.ToInt32(pktdata[32]);
			ScreenWidth = (int)BitConverter.ToInt32(pktdata[36]);
			ScreenHeight = (int)BitConverter.ToInt32(pktdata[40]);
			ScreenDepth = (int)BitConverter.ToInt32(pktdata[44]);
			DirectXMajor = (short)BitConverter.ToInt16(pktdata[48]);
			DirectXMinor = (short)BitConverter.ToInt16(pktdata[50]);
			VideoCardVendorID = (int)BitConverter.ToInt32(pktdata[52]);
			VideoCardDeviceID = (int)BitConverter.ToInt32(pktdata[56]);
			VideoCardMemory = (int)BitConverter.ToInt32(pktdata[60]);
			Distribution = (Byte)pktdata[64];
			ClientsRunning = (Byte)pktdata[65];
			ClientsInstalled = (Byte)pktdata[66];
			ClientsPartialInstalled = (Byte)pktdata[67];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)ClientType1130);
			InsertDWord(InstanceID);
			InsertDWord(OSMajor);
			InsertDWord(OSMinor);
			InsertDWord(OSRevision);
			InsertByte(CPUManifacture);
			InsertDWord(CPUFamily);
			InsertDWord(CPUModel);
			InsertDWord(CPUClockSpeed);
			InsertByte(CPUQuantity);
			InsertDWord(PhysicalMemory);
			InsertDWord(ScreenWidth);
			InsertDWord(ScreenHeight);
			InsertDWord(ScreenDepth);
			InsertWord(DirectXMajor);
			InsertWord(DirectXMinor);
			InsertChar(VideoCardDescription);
			InsertDWord(VideoCardVendorID);
			InsertDWord(VideoCardDeviceID);
			InsertDWord(VideoCardMemory);
			InsertByte(Distribution);
			InsertByte(ClientsRunning);
			InsertByte(ClientsInstalled);
			InsertByte(ClientsPartialInstalled);
			InsertChar(Language);
			InsertChar(Unknown);
		}
	}
	/// <summary>
	/// Mahjong Game Command Packet.
	/// </summary>
	public class MahjongGameCommand : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Command { get; set; }
		public MahjongGameCommand() : base (0xDA)
		{
		}
		public MahjongGameCommand( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Command = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Command);
		}
	}
	/// <summary>
	/// Mahjong Leave Game Packet.
	/// </summary>
	public class MahjongLeaveGame : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongLeaveGame() : base (0xDA)
		{
			Filler0 = 0x06;
		}
		public MahjongLeaveGame( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Give Points Packet.
	/// </summary>
	public class MahjongGivePoints : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Position { get; set; }
		public DWord Points { get; set; }
		public MahjongGivePoints() : base (0xDA)
		{
			Filler0 = 0x0A;
		}
		public MahjongGivePoints( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Position = (Byte)pktdata[9];
			Points = (int)BitConverter.ToInt32(pktdata[10]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte(Position);
			InsertDWord(Points);
		}
	}
	/// <summary>
	/// Mahjong Game Roll Dices Packet.
	/// </summary>
	public class MahjongGameRollDices : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongGameRollDices() : base (0xDA)
		{
			Filler0 = 0x0B;
		}
		public MahjongGameRollDices( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Game Build Walls Packet.
	/// </summary>
	public class MahjongGameBuildWalls : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongGameBuildWalls() : base (0xDA)
		{
			Filler0 = 0x0C;
		}
		public MahjongGameBuildWalls( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Game Reset Scores Packet.
	/// </summary>
	public class MahjongGameResetScores : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongGameResetScores() : base (0xDA)
		{
			Filler0 = 0x0D;
		}
		public MahjongGameResetScores( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Assist Dealer Packet.
	/// </summary>
	public class MahjongAssistDealer : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Position { get; set; }
		public MahjongAssistDealer() : base (0xDA)
		{
			Filler0 = 0x0F;
		}
		public MahjongAssistDealer( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Position = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte(Position);
		}
	}
	/// <summary>
	/// Mahjong Game Open Seat Packet.
	/// </summary>
	public class MahjongGameOpenSeat : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte SeatPosition { get; set; }
		public MahjongGameOpenSeat() : base (0xDA)
		{
			Filler0 = 0x10;
		}
		public MahjongGameOpenSeat( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			SeatPosition = (Byte)pktdata[9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte(SeatPosition);
		}
	}
	/// <summary>
	/// Mahjong Game Change Options Packet.
	/// </summary>
	public class MahjongGameChangeOptions : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Options123 Options1231 { get; set; }
		public MahjongGameChangeOptions() : base (0xDA)
		{
			Filler0 = 0x11;
		}
		public MahjongGameChangeOptions( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Options1231 = (int)BitConverter.ToInt32(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertDWord((DWord)Options1231);
		}
	}
	/// <summary>
	/// Mahjong Game Move Wall Break Indicator Packet.
	/// </summary>
	public class MahjongGameMoveWallBreakIndicator : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Word Y { get; set; }
		public Word X { get; set; }
		public MahjongGameMoveWallBreakIndicator() : base (0xDA)
		{
			Filler0 = 0x15;
		}
		public MahjongGameMoveWallBreakIndicator( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Y = (short)BitConverter.ToInt16(pktdata[9]);
			X = (short)BitConverter.ToInt16(pktdata[11]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertWord(Y);
			InsertWord(X);
		}
	}
	/// <summary>
	/// Mahjong Game Toggle Public Hand Packet.
	/// </summary>
	public class MahjongGameTogglePublicHand : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public PublicHand124 PublicHand1241 { get; set; }
		public MahjongGameTogglePublicHand() : base (0xDA)
		{
			Filler0 = 0x16;
		}
		public MahjongGameTogglePublicHand( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			PublicHand1241 = (int)BitConverter.ToInt32(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertDWord((DWord)PublicHand1241);
		}
	}
	/// <summary>
	/// Mahjong Game Move Tile Packet.
	/// </summary>
	public class MahjongGameMoveTile : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Number { get; set; }
		public CurrentDirection125 CurrentDirection1251 { get; set; }
		public NewDirection126 NewDirection1262 { get; set; }
		public Word Flip { get; set; }
		public Word CurrentY { get; set; }
		public Word CurrentX { get; set; }
		public Byte Filler3 { get; set; }
		public Word NewY { get; set; }
		public Word NewX { get; set; }
		public Byte Filler4 { get; set; }
		public MahjongGameMoveTile() : base (0xDA)
		{
			Filler0 = 0x17;
			Filler3 = 0x01;
			Filler4 = 0x00;
		}
		public MahjongGameMoveTile( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Number = (Byte)pktdata[9];
			CurrentDirection1251 = (byte)pktdata[10];
			NewDirection1262 = (byte)pktdata[11];
			Flip = (short)BitConverter.ToInt16(pktdata[12]);
			CurrentY = (short)BitConverter.ToInt16(pktdata[14]);
			CurrentX = (short)BitConverter.ToInt16(pktdata[16]);
			Filler3 = (Byte)pktdata[18];
			NewY = (short)BitConverter.ToInt16(pktdata[19]);
			NewX = (short)BitConverter.ToInt16(pktdata[21]);
			Filler4 = (Byte)pktdata[23];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte(Number);
			InsertByte((Byte)CurrentDirection1251);
			InsertByte((Byte)NewDirection1262);
			InsertWord(Flip);
			InsertWord(CurrentY);
			InsertWord(CurrentX);
			InsertByte(Filler3);
			InsertWord(NewY);
			InsertWord(NewX);
			InsertByte(Filler4);
		}
	}
	/// <summary>
	/// Mahjong Game Move Dealer Indicator Packet.
	/// </summary>
	public class MahjongGameMoveDealerIndicator : Packet
	{
		public Word Packetsize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Direction127 Direction1271 { get; set; }
		public Wind128 Wind1282 { get; set; }
		public Word Y { get; set; }
		public Word X { get; set; }
		public MahjongGameMoveDealerIndicator() : base (0xDA)
		{
			Filler0 = 0x18;
		}
		public MahjongGameMoveDealerIndicator( Byte[] pktdata ) : base (0xDA)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			GameSerial = (int)BitConverter.ToInt32(pktdata[3]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[7]);
			Direction1271 = (byte)pktdata[9];
			Wind1282 = (byte)pktdata[10];
			Y = (short)BitConverter.ToInt16(pktdata[11]);
			X = (short)BitConverter.ToInt16(pktdata[13]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte((Byte)Direction1271);
			InsertByte((Byte)Wind1282);
			InsertWord(Y);
			InsertWord(X);
		}
	}
	/// <summary>
	/// Bug Report Packet.
	/// </summary>
	public class BugReport : Packet
	{
		public Word Packetsize { get; set; }
		public Char[] Language { get; set; }
		public BugCategory129 BugCategory1292 { get; set; }
		public String BugDescription { get; set; }
		public BugReport() : base (0xE0)
		{
			Language = new Char [4];
		}
		public BugReport( Byte[] pktdata ) : base (0xE0)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			BugCategory1292 = (short)BitConverter.ToInt16(pktdata[3]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertChar(Language);
			InsertWord((Word)BugCategory1292);
			InsertString(BugDescription);
		}
	}
	/// <summary>
	/// UO3D Client Type Packet.
	/// </summary>
	public class UO3DClientType : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public ClientType130 ClientType1301 { get; set; }
		public UO3DClientType() : base (0xE1)
		{
			Filler0 = 0x01;
		}
		public UO3DClientType( Byte[] pktdata ) : base (0xE1)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			ClientType1301 = (int)BitConverter.ToInt32(pktdata[5]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertDWord((DWord)ClientType1301);
		}
	}
	/// <summary>
	/// KR Encryption Response Packet.
	/// </summary>
	public class KREncryptionResponse : Packet
	{
		public Word Packetsize { get; set; }
		public DWord PublicKeyLength { get; set; }
		public List<Byte> PublicKey { get; set; }
		public KREncryptionResponse() : base (0xE4)
		{
			PublicKey = new List<Byte>();
		}
		public KREncryptionResponse( Byte[] pktdata ) : base (0xE4)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			PublicKeyLength = (int)BitConverter.ToInt32(pktdata[3]);
			for (Int32 i = 7; i < (PacketSize - 0); i+= 1)
			{
				PublicKey.Add((pktdata[i]));
			}
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertDWord(PublicKeyLength);
			InsertByte(PublicKey);
		}
	}
	/// <summary>
	/// UO3D Remove Highlight UI-Element Packet.
	/// </summary>
	public class UO3DRemoveHighlightUIElement : Packet
	{
		public DWord MobileSerial { get; set; }
		public Word UIElementID { get; set; }
		public DWord DestinationObjectSerial { get; set; }
		public Byte Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		/* Response to E7 packet. */
		public UO3DRemoveHighlightUIElement() : base (0xE8)
		{
			Data = new Byte [13];
			Filler0 = 0x01;
			Filler1 = 0x01;
		}
		public UO3DRemoveHighlightUIElement( Byte[] pktdata ) : base (0xE8)
		{
			MobileSerial = (int)BitConverter.ToInt32(pktdata[1]);
			UIElementID = (short)BitConverter.ToInt16(pktdata[5]);
			DestinationObjectSerial = (int)BitConverter.ToInt32(pktdata[7]);
			Filler0 = (Byte)pktdata[11];
			Filler1 = (Byte)pktdata[12];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(MobileSerial);
			InsertWord(UIElementID);
			InsertDWord(DestinationObjectSerial);
			InsertByte(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// UO3D Use Hotbar Response Packet.
	/// </summary>
	public class UO3DUseHotbarResponse : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Word Filler1 { get; set; }
		public Type134 Type1342 { get; set; }
		public Byte Filler3 { get; set; }
		public DWord ObjectID_Serial { get; set; }
		/* Client sends this packet only if server sent EA packet before. Object ID: serial for item, id for other types. Always in reversed mode. Note: since KR 2.46.*.*  Object ID is serial for scroll too. Sometimes between 2.48.0.3 and 2.59.0.2 they changed it again: now type is always 0x06. */
		public UO3DUseHotbarResponse() : base (0xEB)
		{
			Filler0 = 0x01;
			Filler1 = 0x06;
			Filler3 = 0x00;
		}
		public UO3DUseHotbarResponse( Byte[] pktdata ) : base (0xEB)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			Filler0 = (short)BitConverter.ToInt16(pktdata[3]);
			Filler1 = (short)BitConverter.ToInt16(pktdata[5]);
			Type1342 = (byte)pktdata[7];
			Filler3 = (Byte)pktdata[8];
			ObjectID_Serial = (int)BitConverter.ToInt32(pktdata[9]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
			InsertWord(Filler1);
			InsertByte((Byte)Type1342);
			InsertByte(Filler3);
			InsertDWord(ObjectID_Serial);
		}
	}
	/// <summary>
	/// UO3D Equip Items Macro Packet.
	/// </summary>
	public class UO3DEquipItemsMacro : Packet
	{
		public Word Packetsize { get; set; }
		public Byte ItemsCount { get; set; }
		Item Items0 { get; set; }
		public UO3DEquipItemsMacro() : base (0xEC)
		{
			Items0 = new Item();
		}
		public UO3DEquipItemsMacro( Byte[] pktdata ) : base (0xEC)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			ItemsCount = (Byte)pktdata[3];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(ItemsCount);
		}
	}
	/// <summary>
	/// UO3D Unequip Items Macro Packet.
	/// </summary>
	public class UO3DUnequipItemsMacro : Packet
	{
		public Word Packetsize { get; set; }
		public Byte ItemsCount { get; set; }
		Item Items0 { get; set; }
		public UO3DUnequipItemsMacro() : base (0xED)
		{
			Items0 = new Item();
		}
		public UO3DUnequipItemsMacro( Byte[] pktdata ) : base (0xED)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			ItemsCount = (Byte)pktdata[3];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(ItemsCount);
		}
	}
	/// <summary>
	/// New Client Version Packet.
	/// </summary>
	public class NewClientVersion : Packet
	{
		public DWord Seed { get; set; }
		public DWord VersionMajor { get; set; }
		public DWord VersionMinor { get; set; }
		public DWord VersionRevision { get; set; }
		public DWord VersionBuild { get; set; }
		public NewClientVersion() : base (0xEF)
		{
			Data = new Byte [21];
		}
		public NewClientVersion( Byte[] pktdata ) : base (0xEF)
		{
			Seed = (int)BitConverter.ToInt32(pktdata[1]);
			VersionMajor = (int)BitConverter.ToInt32(pktdata[5]);
			VersionMinor = (int)BitConverter.ToInt32(pktdata[9]);
			VersionRevision = (int)BitConverter.ToInt32(pktdata[13]);
			VersionBuild = (int)BitConverter.ToInt32(pktdata[17]);
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(Seed);
			InsertDWord(VersionMajor);
			InsertDWord(VersionMinor);
			InsertDWord(VersionRevision);
			InsertDWord(VersionBuild);
		}
	}
	/// <summary>
	/// UO3D Crash Report Packet.
	/// </summary>
	public class UO3DCrashReportPacket : Packet
	{
		public Word Packetsize { get; set; }
		public Byte ClientVersionMajor { get; set; }
		public Byte ClientVersionMinor { get; set; }
		public Byte ClientVersionRevision { get; set; }
		public Byte ClientVersionBuild { get; set; }
		public Word CharacterX { get; set; }
		public Word CharacterY { get; set; }
		public SByte CharacterZ { get; set; }
		public Byte CharacterMap { get; set; }
		public Char[] AccountName { get; set; }
		public Char[] CharacterName { get; set; }
		public DWord ExceptionCode { get; set; }
		public Char[] ProcessName { get; set; }
		public Char[] CrashReport { get; set; }
		public Byte Filler0 { get; set; }
		public DWord ExceptionOffset { get; set; }
		public Byte AdressesCount { get; set; }
		Adresses Adresses1 { get; set; }
		/* Only for UO3D clients. */
		public UO3DCrashReportPacket() : base (0xF4)
		{
			AccountName = new Char [32];
			CharacterName = new Char [32];
			ProcessName = new Char [100];
			CrashReport = new Char [100];
			Filler0 = 0x00;
			Adresses1 = new Adresses();
		}
		public UO3DCrashReportPacket( Byte[] pktdata ) : base (0xF4)
		{
			Packetsize = (short)BitConverter.ToInt16(pktdata[1]);
			ClientVersionMajor = (Byte)pktdata[3];
			ClientVersionMinor = (Byte)pktdata[4];
			ClientVersionRevision = (Byte)pktdata[5];
			ClientVersionBuild = (Byte)pktdata[6];
			CharacterX = (short)BitConverter.ToInt16(pktdata[7]);
			CharacterY = (short)BitConverter.ToInt16(pktdata[9]);
			CharacterZ = (SByte)pktdata[11];
			CharacterMap = (Byte)pktdata[12];
			ExceptionCode = (int)BitConverter.ToInt32(pktdata[13]);
			Filler0 = (Byte)pktdata[17];
			ExceptionOffset = (int)BitConverter.ToInt32(pktdata[18]);
			AdressesCount = (Byte)pktdata[22];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(ClientVersionMajor);
			InsertByte(ClientVersionMinor);
			InsertByte(ClientVersionRevision);
			InsertByte(ClientVersionBuild);
			InsertWord(CharacterX);
			InsertWord(CharacterY);
			InsertSByte(CharacterZ);
			InsertByte(CharacterMap);
			InsertChar(AccountName);
			InsertChar(CharacterName);
			InsertDWord(ExceptionCode);
			InsertChar(ProcessName);
			InsertChar(CrashReport);
			InsertByte(Filler0);
			InsertDWord(ExceptionOffset);
			InsertByte(AdressesCount);
		}
	}
}
