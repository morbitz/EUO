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
	/// Create a new character (2D clients).
	/// </summary>
	public class CharacterCreation : Packet
	{
		public DWord Filler0 { get; set; }
		public DWord Filler1 { get; set; }
		public Byte Filler2 { get; set; }
		public Char[] CharacterName { get; set; }
		public Word Filler3 { get; set; }
		public ClientFlags0 ClientFlags04 { get; set; }
		public DWord 1 { get; set; }
		public DWord ClientLoginCount { get; set; }
		public Byte Profession { get; set; }
		public Byte[] Filler5 { get; set; }
		public GenderandRace:1 GenderandRace:16 { get; set; }
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
			Filler5 = new Byte [15];
			for (Int32 i=0; i<Filler5.Length; i++)
			{
				Filler5[i] = 0x00;
			}
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Filler0);
			InsertDWord(Filler1);
			InsertByte(Filler2);
			InsertChar(CharacterName);
			InsertWord(Filler3);
			InsertDWord((DWord)ClientFlags04);
			InsertDWord(1);
			InsertDWord(ClientLoginCount);
			InsertByte(Profession);
			InsertByte(Filler5);
			InsertByte((Byte)GenderandRace:16);
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
		public DWord Filler0 { get; set; }
		public Logout() : base (0x01)
		{
			Data = new Byte [5];
			Filler0 = 0xFFFFFFFF;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Filler0);
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
		public void Build()
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
		public void Build()
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
		public void Build()
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
		public void Build()
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
		public void Build()
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
		public void Build()
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
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(ItemSerial);
		}
	}
	/// <summary>
	/// Text Command Packet.
	/// </summary>
	public class TextCommand : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		public TextCommand() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(Arguments);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Use Skill/LastSkill Packet.
	/// </summary>
	public class UseSkill_LastSkill : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		public UseSkill_LastSkill() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Use Scroll Packet.
	/// </summary>
	public class UseScroll : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String ScrollSerial { get; set; }
		public Char Whitespace { get; set; }
		public String ScrollTargetX { get; set; }
		public Char Whitespace { get; set; }
		public String ScrollTargetY { get; set; }
		public Char Whitespace { get; set; }
		public String ScrollTargetZ { get; set; }
		public Char Whitespace { get; set; }
		/* Self-dclick and target packet. If item has 0xEF3 itemid (scroll) and you will double click it, 2D client will create internal target and when you targeted something, server get this packet. Note: no dclick/target packets for server - just internal work. */
		public UseScroll() : base (0x12)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(ScrollSerial);
			InsertChar(Whitespace);
			InsertString(ScrollTargetX);
			InsertChar(Whitespace);
			InsertString(ScrollTargetY);
			InsertChar(Whitespace);
			InsertString(ScrollTargetZ);
			InsertChar(Whitespace);
		}
	}
	/// <summary>
	/// Open Spellbook Packet.
	/// </summary>
	public class OpenSpellbook : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		public OpenSpellbook() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Open Door Packet.
	/// </summary>
	public class OpenDoor : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		public OpenDoor() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Action Packet.
	/// </summary>
	public class Action : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String ActionName { get; set; }
		public Byte Filler0 { get; set; }
		public Action() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(ActionName);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Invoke Virtue Packet.
	/// </summary>
	public class InvokeVirtue : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		public InvokeVirtue() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(ItemSerial);
			InsertByte((Byte)ItemLayer80);
			InsertDWord(ContainerSerial);
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
		public void Build()
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
		public void Build()
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
		public Status24 Status240 { get; set; }
		public DeathStatus() : base (0x2C)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Status240);
		}
	}
	/// <summary>
	/// Mobile Query Packet.
	/// </summary>
	public class MobileQuery : Packet
	{
		public DWord Filler0 { get; set; }
		public Type26 Type261 { get; set; }
		public DWord Serial { get; set; }
		public MobileQuery() : base (0x34)
		{
			Data = new Byte [10];
			Filler0 = 0xEDEDEDED;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Filler0);
			InsertByte((Byte)Type261);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Skills Update Packet.
	/// </summary>
	public class SkillsUpdate : Packet
	{
		public Word PacketSize { get; set; }
		public Word SkillID { get; set; }
		public Byte LockStatus { get; set; }
		public SkillsUpdate() : base (0x3A)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(SkillID);
			InsertByte(LockStatus);
		}
	}
	/// <summary>
	/// Vendor Interaction Packet.
	/// </summary>
	public class VendorInteraction : Packet
	{
		public Word PacketSize { get; set; }
		public DWord VendorSerial { get; set; }
		public Flag28 Flag280 { get; set; }
		Items Items1 { get; set; }
		public VendorInteraction() : base (0x3B)
		{
			Items1 = new Items();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(VendorSerial);
			InsertByte((Byte)Flag280);
		}
	}
	/// <summary>
	/// Play Character Packet.
	/// </summary>
	public class PlayCharacter : Packet
	{
		public DWord Filler0 { get; set; }
		public Char[] CharacterName { get; set; }
		public Word Filler1 { get; set; }
		public ClientFlags32 ClientFlags322 { get; set; }
		public DWord Filler3 { get; set; }
		public DWord ClientLoginCount { get; set; }
		public DWord Filler4 { get; set; }
		public DWord Filler5 { get; set; }
		public DWord Filler6 { get; set; }
		public DWord Filler7 { get; set; }
		public DWord CharacterSlot { get; set; }
		public DWord ClientIP { get; set; }
		public PlayCharacter() : base (0x5D)
		{
			Data = new Byte [73];
			Filler0 = 0xEDEDEDED;
			CharacterName = new Char [30];
			Filler1 = 0x00;
			Filler3 = 0x00;
			Filler4 = 0x00;
			Filler5 = 0x00;
			Filler6 = 0x00;
			Filler7 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Filler0);
			InsertChar(CharacterName);
			InsertWord(Filler1);
			InsertDWord((DWord)ClientFlags322);
			InsertDWord(Filler3);
			InsertDWord(ClientLoginCount);
			InsertDWord(Filler4);
			InsertDWord(Filler5);
			InsertDWord(Filler6);
			InsertDWord(Filler7);
			InsertDWord(CharacterSlot);
			InsertDWord(ClientIP);
		}
	}
	/// <summary>
	/// Book page Packet.
	/// </summary>
	public class BookPage : Packet
	{
		public Word PacketSize { get; set; }
		public DWord BookSerial { get; set; }
		public Word PagesCount { get; set; }
		Pages Pages0 { get; set; }
		Lines Lines1 { get; set; }
		public BookPage() : base (0x66)
		{
			Pages0 = new Pages();
			Lines1 = new Lines();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(BookSerial);
			InsertWord(PagesCount);
		}
	}
	/// <summary>
	/// Target Packet.
	/// </summary>
	public class Target : Packet
	{
		public TargetType34 TargetType340 { get; set; }
		public DWord SenderSerial { get; set; }
		public Flags35 Flags351 { get; set; }
		public DWord ObjectSerial { get; set; }
		public X36 X362 { get; set; }
		public Y37 Y373 { get; set; }
		public Word Z { get; set; }
		public Graphic38 Graphic384 { get; set; }
		public Target() : base (0x6C)
		{
			Data = new Byte [19];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)TargetType340);
			InsertDWord(SenderSerial);
			InsertByte((Byte)Flags351);
			InsertDWord(ObjectSerial);
			InsertWord((Word)X362);
			InsertWord((Word)Y373);
			InsertWord(Z);
			InsertWord((Word)Graphic384);
		}
	}
	/// <summary>
	/// Bulletin Board Packet.
	/// </summary>
	public class BulletinBoard : Packet
	{
		public Word PacketSize { get; set; }
		public Byte Command { get; set; }
		public BulletinBoard() : base (0x71)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Get Message Bulletin Board Packet.
	/// </summary>
	public class GetMessageBulletinBoard : Packet
	{
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public GetMessageBulletinBoard() : base (0x71)
		{
			Filler0 = 0x03;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public GetMessageSummaryBulletinBoard() : base (0x71)
		{
			Filler0 = 0x04;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public ReplyMessageSerial50 ReplyMessageSerial501 { get; set; }
		public Byte SubjectLength { get; set; }
		public String Subject { get; set; }
		public Byte NumberLines { get; set; }
		Line Line2 { get; set; }
		public PostMessageBulletinBoard() : base (0x71)
		{
			Filler0 = 0x05;
			Line2 = new Line();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertDWord((DWord)ReplyMessageSerial501);
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
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public DeleteMessageBulletinBoard() : base (0x71)
		{
			Filler0 = 0x06;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Byte WarMode { get; set; }
		public Byte Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public WarMode() : base (0x72)
		{
			Data = new Byte [5];
			Filler0 = 0x32;
			Filler1 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(WarMode);
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
		public void Build()
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
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertChar(Name);
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
		public void Build()
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
		public void Build()
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
		public Word PacketSize { get; set; }
		public DWord Filler0 { get; set; }
		public DWord CharacterSlot { get; set; }
		public Char[] CharacterName { get; set; }
		public Char[] Unknown { get; set; }
		public Byte Profession { get; set; }
		public ClientFlags61 ClientFlags611 { get; set; }
		public Gender62 Gender622 { get; set; }
		public Race63 Race633 { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Filler0);
			InsertDWord(CharacterSlot);
			InsertChar(CharacterName);
			InsertChar(Unknown);
			InsertByte(Profession);
			InsertByte((Byte)ClientFlags611);
			InsertByte((Byte)Gender622);
			InsertByte((Byte)Race633);
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
	/// Game Server Login Packet.
	/// </summary>
	public class GameServerLogin : Packet
	{
		public DWord AuthID { get; set; }
		public Char[] AccountName { get; set; }
		public Char[] Password { get; set; }
		public GameServerLogin() : base (0x91)
		{
			Data = new Byte [65];
			AccountName = new Char [30];
			Password = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(AuthID);
			InsertChar(AccountName);
			InsertChar(Password);
		}
	}
	/// <summary>
	/// Hue Picker Packet.
	/// </summary>
	public class HuePicker : Packet
	{
		public DWord Serial { get; set; }
		public Word ItemID { get; set; }
		public Word Hue { get; set; }
		public HuePicker() : base (0x95)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(ItemID);
			InsertWord(Hue);
		}
	}
	/// <summary>
	/// Mobile Name Packet.
	/// </summary>
	public class MobileName : Packet
	{
		public Word PacketSize { get; set; }
		public DWord MobileSerial { get; set; }
		public Char[] MobileName { get; set; }
		public MobileName() : base (0x98)
		{
			MobileName = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(MobileSerial);
			InsertChar(MobileName);
		}
	}
	/// <summary>
	/// Ascii Prompt Response Packet.
	/// </summary>
	public class AsciiPromptResponse : Packet
	{
		public Word PacketSize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord PromptID { get; set; }
		public Type68 Type680 { get; set; }
		public String Text { get; set; }
		/* Prompt ID is special type id. See link below for more information. */
		public AsciiPromptResponse() : base (0x9A)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(SenderSerial);
			InsertDWord(PromptID);
			InsertDWord((DWord)Type680);
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
		public void Build()
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
		public Word PacketSize { get; set; }
		public DWord VendorSerial { get; set; }
		public Word ItemsCount { get; set; }
		Items Items0 { get; set; }
		public ShopOffer() : base (0x9F)
		{
			Items0 = new Items();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public void Build()
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
		public void Build()
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Byte ParentID { get; set; }
		public Byte ButtonID { get; set; }
		public Word TextLength { get; set; }
		public String Text { get; set; }
		public Style70 Style700 { get; set; }
		public DWord MaxLength { get; set; }
		public Word LabelLength { get; set; }
		public String Label { get; set; }
		public StringQuery() : base (0xAB)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertByte(ParentID);
			InsertByte(ButtonID);
			InsertWord(TextLength);
			InsertString(Text);
			InsertByte((Byte)Style700);
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
		public Word PacketSize { get; set; }
		public Mode72 Mode720 { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte((Byte)Mode720);
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
		public Word PacketSize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord GumpID { get; set; }
		public DWord ButtonID { get; set; }
		public DWord SwitchesCount { get; set; }
		Switches Switches0 { get; set; }
		public DWord TextEntriesCount { get; set; }
		TextEntries TextEntries1 { get; set; }
		public SwitchesCount74 SwitchesCount742 { get; set; }
		public GumpResponse() : base (0xB1)
		{
			Switches0 = new Switches();
			TextEntries1 = new TextEntries();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(SenderSerial);
			InsertDWord(GumpID);
			InsertDWord(ButtonID);
			InsertDWord(SwitchesCount);
			InsertDWord(TextEntriesCount);
			InsertDWord((DWord)SwitchesCount742);
		}
	}
	/// <summary>
	/// Chat Action Packet.
	/// </summary>
	public class ChatAction : Packet
	{
		public Word PacketSize { get; set; }
		public Char[] Language { get; set; }
		public Action75 Action750 { get; set; }
		public String Parameters { get; set; }
		public ChatAction() : base (0xB3)
		{
			Language = new Char [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertChar(Language);
			InsertWord((Word)Action750);
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
		public void Build()
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
		public void Build()
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
		public Word PacketSize { get; set; }
		public Mode76 Mode760 { get; set; }
		public DWord Serial { get; set; }
		public Unknown77 Unknown771 { get; set; }
		public Word TextLength { get; set; }
		public String Text { get; set; }
		public ProfileRequest() : base (0xB8)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte((Byte)Mode760);
			InsertDWord(Serial);
			InsertWord((Word)Unknown771);
			InsertWord(TextLength);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Client Version Packet.
	/// </summary>
	public class ClientVersion : Packet
	{
		public Word PacketSize { get; set; }
		public String Version { get; set; }
		/* Only in 2D/UOTD clients. */
		public ClientVersion() : base (0xBD)
		{
		}
		public void Build()
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public String Version { get; set; }
		public AssistanceVersion() : base (0xBE)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertString(Version);
		}
	}
	/// <summary>
	/// Extended Command Packet.
	/// </summary>
	public class ExtendedCommand : Packet
	{
		public Word PacketSize { get; set; }
		public Word Command { get; set; }
		public ExtendedCommand() : base (0xBF)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Command);
		}
	}
	/// <summary>
	/// Screen Size Packet.
	/// </summary>
	public class ScreenSize : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Width { get; set; }
		public DWord Height { get; set; }
		public ScreenSize() : base (0xBF)
		{
			Filler0 = 0x05;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Width);
			InsertDWord(Height);
		}
	}
	/// <summary>
	/// Party Packet.
	/// </summary>
	public class Party : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte PartyCommand { get; set; }
		public Party() : base (0xBF)
		{
			Filler0 = 0x06;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(PartyCommand);
		}
	}
	/// <summary>
	/// Party Add Member Packet.
	/// </summary>
	public class PartyAddMember : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public PartyAddMember() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Party Remove Member Packet.
	/// </summary>
	public class PartyRemoveMember : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord RemovedMemberSerial { get; set; }
		public PartyRemoveMember() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x02;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord MemberSerial { get; set; }
		public String Message { get; set; }
		public PartyPrivateMessage() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x03;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public String Message { get; set; }
		public PartyChat() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x04;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public CanLoot82 CanLoot822 { get; set; }
		public PartySetCanLoot() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x06;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertByte((Byte)CanLoot822);
		}
	}
	/// <summary>
	/// Party Accept Invitation Packet.
	/// </summary>
	public class PartyAcceptInvitation : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord PartyLeaderSerial { get; set; }
		public PartyAcceptInvitation() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x08;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord PartyLeaderSerial { get; set; }
		public PartyDeclineInvitation() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x09;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public RightClick83 RightClick831 { get; set; }
		public QuestArrow() : base (0xBF)
		{
			Filler0 = 0x07;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte((Byte)RightClick831);
		}
	}
	/// <summary>
	/// Disarm Request Packet.
	/// </summary>
	public class DisarmRequest : Packet
	{
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public List<Byte> Unknown { get; set; }
		public StunRequest() : base (0xBF)
		{
			Filler0 = 0x0A;
			Unknown = new List<Byte>();
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
	/// Client Language Packet.
	/// </summary>
	public class ClientLanguage : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Char[] Language { get; set; }
		public ClientLanguage() : base (0xBF)
		{
			Filler0 = 0x0B;
			Language = new Char [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertChar(Language);
		}
	}
	/// <summary>
	/// Close Status Packet.
	/// </summary>
	public class CloseStatus : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public CloseStatus() : base (0xBF)
		{
			Filler0 = 0x0C;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Animate Packet.
	/// </summary>
	public class Animate : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Action { get; set; }
		public Animate() : base (0xBF)
		{
			Filler0 = 0x0E;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Action);
		}
	}
	/// <summary>
	/// Client Info Packet.
	/// </summary>
	public class ClientInfo : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public ClientFlags84 ClientFlags842 { get; set; }
		/* Only 2D client packet. Additional way to say server how many facets 2D client has. */
		public ClientInfo() : base (0xBF)
		{
			Filler0 = 0x0F;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord((DWord)ClientFlags842);
		}
	}
	/// <summary>
	/// Query Properties Packet.
	/// </summary>
	public class QueryProperties : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public QueryProperties() : base (0xBF)
		{
			Filler0 = 0x10;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Context Menu Request Packet.
	/// </summary>
	public class ContextMenuRequest : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public ContextMenuRequest() : base (0xBF)
		{
			Filler0 = 0x13;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// Context Menu Request Packet.
	/// </summary>
	public class ContextMenuRequest : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public Word ContextMenuEntryIndex { get; set; }
		public ContextMenuRequest() : base (0xBF)
		{
			Filler0 = 0x15;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public StatType92 StatType921 { get; set; }
		public LockValue93 LockValue932 { get; set; }
		public StatLockChange() : base (0xBF)
		{
			Filler0 = 0x1A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte((Byte)StatType921);
			InsertByte((Byte)LockValue932);
		}
	}
	/// <summary>
	/// Cast Spell Packet.
	/// </summary>
	public class CastSpell : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Type94 Type941 { get; set; }
		public SpellbookSerial95 SpellbookSerial952 { get; set; }
		/* In latest clients, type is always 0x02. */
		public CastSpell() : base (0xBF)
		{
			Filler0 = 0x1C;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord((Word)Type941);
			InsertDWord((DWord)SpellbookSerial952);
		}
	}
	/// <summary>
	/// Query Design Details Packet.
	/// </summary>
	public class QueryDesignDetails : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public QueryDesignDetails() : base (0xBF)
		{
			Filler0 = 0x1E;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(HouseFoundationSerial);
		}
	}
	/// <summary>
	/// Change Race Request Packet.
	/// </summary>
	public class ChangeRaceRequest : Packet
	{
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord ItemSerial { get; set; }
		public DWord TargetSerial { get; set; }
		public UseTargetedItem() : base (0xBF)
		{
			Filler0 = 0x2C;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord TargetSerial { get; set; }
		public CastTargetedSpell() : base (0xBF)
		{
			Filler0 = 0x2D;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(TargetSerial);
		}
	}
	/// <summary>
	/// Use Targeted Skill Packet.
	/// </summary>
	public class UseTargetedSkill : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Word SkillID { get; set; }
		public DWord TargetSerial { get; set; }
		public UseTargetedSkill() : base (0xBF)
		{
			Filler0 = 0x2E;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord(SkillID);
			InsertDWord(TargetSerial);
		}
	}
	/// <summary>
	/// UO3D Target By Resource Macro Packet.
	/// </summary>
	public class UO3DTargetByResourceMacro : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord ToolSerial { get; set; }
		public ResourceType101 ResourceType1011 { get; set; }
		public UO3DTargetByResourceMacro() : base (0xBF)
		{
			Filler0 = 0x30;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(ToolSerial);
			InsertWord((Word)ResourceType1011);
		}
	}
	/// <summary>
	/// Toggle Gargoyle Flying Packet.
	/// </summary>
	public class ToggleGargoyleFlying : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Word Filler1 { get; set; }
		public DWord Filler2 { get; set; }
		public ToggleGargoyleFlying() : base (0xBF)
		{
			Filler0 = 0x32;
			Filler1 = 0x01;
			Filler2 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord(Filler1);
			InsertDWord(Filler2);
		}
	}
	/// <summary>
	/// Wheel Boat Moving Packet.
	/// </summary>
	public class WheelBoatMoving : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord PlayerSerial { get; set; }
		public Byte FacingDirection { get; set; }
		public Byte MovingDirection { get; set; }
		public Byte BoatSpeed { get; set; }
		/* Was added in UO:HS clients. Moving Direction = Facing Direction + Command Direction. Normal Movement - fast for all ships except of rowboats. */
		public WheelBoatMoving() : base (0xBF)
		{
			Filler0 = 0x33;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(PlayerSerial);
			InsertByte(FacingDirection);
			InsertByte(MovingDirection);
			InsertByte(BoatSpeed);
		}
	}
	/// <summary>
	/// Unicode Prompt Packet.
	/// </summary>
	public class UnicodePrompt : Packet
	{
		public Word PacketSize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord PromptID { get; set; }
		public Type106 Type1060 { get; set; }
		public Char[] Language { get; set; }
		public String Text { get; set; }
		/* Prompt ID is special type id. See link below for more information. */
		public UnicodePrompt() : base (0xC2)
		{
			Language = new Char [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(SenderSerial);
			InsertDWord(PromptID);
			InsertDWord((DWord)Type1060);
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
		public void Build()
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
		public void Build()
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
		public void Build()
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
		public void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Book Header Packet.
	/// </summary>
	public class BookHeader : Packet
	{
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		Items Items0 { get; set; }
		public BatchQueryProperties() : base (0xD6)
		{
			Items0 = new Items();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
		}
	}
	/// <summary>
	/// Encoded Command Packet.
	/// </summary>
	public class EncodedCommand : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Command { get; set; }
		public EncodedCommand() : base (0xD7)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertWord(Command);
		}
	}
	/// <summary>
	/// Designer Backup Packet.
	/// </summary>
	public class DesignerBackup : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerBackup() : base (0xD7)
		{
			Filler0 = 0x02;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerRestore() : base (0xD7)
		{
			Filler0 = 0x03;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerCommit() : base (0xD7)
		{
			Filler0 = 0x04;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerClose() : base (0xD7)
		{
			Filler0 = 0x0C;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerSynch() : base (0xD7)
		{
			Filler0 = 0x0E;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		/* Client sends this packet only if Enable Response is set to 0x01 in 0xD8 packet */
		public DesignerAction2D() : base (0xD7)
		{
			Filler0 = 0x0F;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public QWord Filler1 { get; set; }
		/* Client sends this packet only if Enable Response is set to 0x01 in 0xD8 packet */
		public DesignerAction3D() : base (0xD7)
		{
			Filler0 = 0x0F;
			Filler1 = 0xFF;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignerClear() : base (0xD7)
		{
			Filler0 = 0x10;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DesignRevert() : base (0xD7)
		{
			Filler0 = 0x1A;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public EquipLastWeapon() : base (0xD7)
		{
			Filler0 = 0x1E;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public GuildButtonRequest() : base (0xD7)
		{
			Filler0 = 0x28;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public QuestsButtonRequest() : base (0xD7)
		{
			Filler0 = 0x32;
			Filler1 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public ClientType118 ClientType1180 { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)ClientType1180);
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
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Command { get; set; }
		public MahjongGameCommand() : base (0xDA)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Command);
		}
	}
	/// <summary>
	/// Mahjong Leave Game Packet.
	/// </summary>
	public class MahjongLeaveGame : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongLeaveGame() : base (0xDA)
		{
			Filler0 = 0x06;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Give Points Packet.
	/// </summary>
	public class MahjongGivePoints : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Position { get; set; }
		public DWord Points { get; set; }
		public MahjongGivePoints() : base (0xDA)
		{
			Filler0 = 0x0A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongGameRollDices() : base (0xDA)
		{
			Filler0 = 0x0B;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Game Build Walls Packet.
	/// </summary>
	public class MahjongGameBuildWalls : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongGameBuildWalls() : base (0xDA)
		{
			Filler0 = 0x0C;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Game Reset Scores Packet.
	/// </summary>
	public class MahjongGameResetScores : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongGameResetScores() : base (0xDA)
		{
			Filler0 = 0x0D;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Mahjong Assist Dealer Packet.
	/// </summary>
	public class MahjongAssistDealer : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Position { get; set; }
		public MahjongAssistDealer() : base (0xDA)
		{
			Filler0 = 0x0F;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte SeatPosition { get; set; }
		public MahjongGameOpenSeat() : base (0xDA)
		{
			Filler0 = 0x10;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Options128 Options1281 { get; set; }
		public MahjongGameChangeOptions() : base (0xDA)
		{
			Filler0 = 0x11;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertDWord((DWord)Options1281);
		}
	}
	/// <summary>
	/// Mahjong Game Move Wall Break Indicator Packet.
	/// </summary>
	public class MahjongGameMoveWallBreakIndicator : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Word Y { get; set; }
		public Word X { get; set; }
		public MahjongGameMoveWallBreakIndicator() : base (0xDA)
		{
			Filler0 = 0x15;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public PublicHand129 PublicHand1291 { get; set; }
		public MahjongGameTogglePublicHand() : base (0xDA)
		{
			Filler0 = 0x16;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertDWord((DWord)PublicHand1291);
		}
	}
	/// <summary>
	/// Mahjong Game Move Tile Packet.
	/// </summary>
	public class MahjongGameMoveTile : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte Number { get; set; }
		public CurrentDirection130 CurrentDirection1301 { get; set; }
		public NewDirection131 NewDirection1312 { get; set; }
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
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte(Number);
			InsertByte((Byte)CurrentDirection1301);
			InsertByte((Byte)NewDirection1312);
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
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Direction132 Direction1321 { get; set; }
		public Wind133 Wind1332 { get; set; }
		public Word Y { get; set; }
		public Word X { get; set; }
		public MahjongGameMoveDealerIndicator() : base (0xDA)
		{
			Filler0 = 0x18;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte((Byte)Direction1321);
			InsertByte((Byte)Wind1332);
			InsertWord(Y);
			InsertWord(X);
		}
	}
	/// <summary>
	/// Bug Report Packet.
	/// </summary>
	public class BugReport : Packet
	{
		public Word PacketSize { get; set; }
		public Char[] Language { get; set; }
		public BugCategory135 BugCategory1352 { get; set; }
		public String BugDescription { get; set; }
		public BugReport() : base (0xE0)
		{
			Language = new Char [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertChar(Language);
			InsertWord((Word)BugCategory1352);
			InsertString(BugDescription);
		}
	}
	/// <summary>
	/// UO3D Client Type Packet.
	/// </summary>
	public class UO3DClientType : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public ClientType136 ClientType1361 { get; set; }
		public UO3DClientType() : base (0xE1)
		{
			Filler0 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord((DWord)ClientType1361);
		}
	}
	/// <summary>
	/// KR Encryption Response Packet.
	/// </summary>
	public class KREncryptionResponse : Packet
	{
		public Word PacketSize { get; set; }
		public DWord PublicKeyLength { get; set; }
		public List<Byte> PublicKey { get; set; }
		public KREncryptionResponse() : base (0xE4)
		{
			PublicKey = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public void Build()
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
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Word Filler1 { get; set; }
		public Type140 Type1402 { get; set; }
		public Byte Filler3 { get; set; }
		public DWord ObjectID_Serial { get; set; }
		/* Client sends this packet only if server sent EA packet before. Object ID: serial for item, id for other types. Always in reversed mode. Note: since KR 2.46.*.*  Object ID is serial for scroll too. Sometimes between 2.48.0.3 and 2.59.0.2 they changed it again: now type is always 0x06. */
		public UO3DUseHotbarResponse() : base (0xEB)
		{
			Filler0 = 0x01;
			Filler1 = 0x06;
			Filler3 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord(Filler1);
			InsertByte((Byte)Type1402);
			InsertByte(Filler3);
			InsertDWord(ObjectID_Serial);
		}
	}
	/// <summary>
	/// UO3D Equip Items Macro Packet.
	/// </summary>
	public class UO3DEquipItemsMacro : Packet
	{
		public Word PacketSize { get; set; }
		public Byte ItemsCount { get; set; }
		Items Items0 { get; set; }
		public UO3DEquipItemsMacro() : base (0xEC)
		{
			Items0 = new Items();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(ItemsCount);
		}
	}
	/// <summary>
	/// UO3D Unequip Items Macro Packet.
	/// </summary>
	public class UO3DUnequipItemsMacro : Packet
	{
		public Word PacketSize { get; set; }
		public Byte ItemsCount { get; set; }
		Items Items0 { get; set; }
		public UO3DUnequipItemsMacro() : base (0xED)
		{
			Items0 = new Items();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public void Build()
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
	/// New Movement Request Packet.
	/// </summary>
	public class NewMovementRequest : Packet
	{
		public Word PacketSize { get; set; }
		public Byte MovementRequestsCount { get; set; }
		MovementRequests MovementRequests0 { get; set; }
		/* DateTime1 and DateTime2 - ticks from Unix time divided by 10000. Client sends this packet on movement attempt. Can be enabled with 0x4000 flag in 0xA9 packet. */
		public NewMovementRequest() : base (0xF0)
		{
			MovementRequests0 = new MovementRequests();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(MovementRequestsCount);
		}
	}
	/// <summary>
	/// Client-Server Time Synchronization Request Packet.
	/// </summary>
	public class ClientServerTimeSynchronizationRequest : Packet
	{
		public QWord DateTime { get; set; }
		/* DateTime - ticks from Unix time divided by 10000. Client sends this packet each minute. Can be enabled with 0x4000 flag in 0xA9 packet. */
		public ClientServerTimeSynchronizationRequest() : base (0xF1)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertQWord(DateTime);
		}
	}
	/// <summary>
	/// Crash Report Packet.
	/// </summary>
	public class CrashReportPacket : Packet
	{
		public Word PacketSize { get; set; }
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
		public Char[] IPAddress { get; set; }
		public DWord Unknown { get; set; }
		public DWord ExceptionCode { get; set; }
		public Char[] ProcessName { get; set; }
		public Char[] CrashReport { get; set; }
		public Byte Filler0 { get; set; }
		public DWord ExceptionOffset { get; set; }
		public Byte AdressesCount { get; set; }
		Adresses Adresses1 { get; set; }
		/* Was only for UO3D clients. Since 7.0.8.0 it's also for 2d clients with slightly changed format. */
		public CrashReportPacket() : base (0xF4)
		{
			AccountName = new Char [32];
			CharacterName = new Char [32];
			IPAddress = new Char [15];
			ProcessName = new Char [100];
			CrashReport = new Char [100];
			Filler0 = 0x00;
			Adresses1 = new Adresses();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
			InsertChar(IPAddress);
			InsertDWord(Unknown);
			InsertDWord(ExceptionCode);
			InsertChar(ProcessName);
			InsertChar(CrashReport);
			InsertByte(Filler0);
			InsertDWord(ExceptionOffset);
			InsertByte(AdressesCount);
		}
	}
	/// <summary>
	/// Create a new character (2D clients since 7.0.16.0).
	/// </summary>
	public class NewCharacterCreation : Packet
	{
		public DWord Filler0 { get; set; }
		public DWord Filler1 { get; set; }
		public Byte Filler2 { get; set; }
		public Char[] CharacterName { get; set; }
		public Word Filler3 { get; set; }
		public ClientFlags146 ClientFlags1464 { get; set; }
		public DWord 1 { get; set; }
		public DWord ClientLoginCount { get; set; }
		public Byte Profession { get; set; }
		public Byte[] Filler5 { get; set; }
		public GenderandRace:147 GenderandRace:1476 { get; set; }
		public Byte Strength { get; set; }
		public Byte Dexterity { get; set; }
		public Byte Intelligence { get; set; }
		public Byte Skill1 { get; set; }
		public Byte Skill1Amount { get; set; }
		public Byte Skill2 { get; set; }
		public Byte Skill2Amount { get; set; }
		public Byte Skill3 { get; set; }
		public Byte Skill3Amount { get; set; }
		public Byte Skill4 { get; set; }
		public Byte Skill4Amount { get; set; }
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
		/* Was added in 7.0.16.0 client. Replaced 0x00 packet. Has 2 more bytes for skill #4 */
		public NewCharacterCreation() : base (0xF8)
		{
			Data = new Byte [106];
			Filler0 = 0xEDEDEDED;
			Filler1 = 0xFFFFFFFF;
			Filler2 = 0x00;
			CharacterName = new Char [30];
			Filler3 = 0x00;
			Filler5 = new Byte [15];
			for (Int32 i=0; i<Filler5.Length; i++)
			{
				Filler5[i] = 0x00;
			}
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Filler0);
			InsertDWord(Filler1);
			InsertByte(Filler2);
			InsertChar(CharacterName);
			InsertWord(Filler3);
			InsertDWord((DWord)ClientFlags1464);
			InsertDWord(1);
			InsertDWord(ClientLoginCount);
			InsertByte(Profession);
			InsertByte(Filler5);
			InsertByte((Byte)GenderandRace:1476);
			InsertByte(Strength);
			InsertByte(Dexterity);
			InsertByte(Intelligence);
			InsertByte(Skill1);
			InsertByte(Skill1Amount);
			InsertByte(Skill2);
			InsertByte(Skill2Amount);
			InsertByte(Skill3);
			InsertByte(Skill3Amount);
			InsertByte(Skill4);
			InsertByte(Skill4Amount);
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
}
