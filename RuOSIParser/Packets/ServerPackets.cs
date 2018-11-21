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
	/// Damage Packet.
	/// </summary>
	public class DamagePacket : Packet
	{
		public DWord Serial { get; set; }
		public Word DamageAmount { get; set; }
		/* Before 4.0.7a 2D client, was an Edit Area packet */
		public DamagePacket() : base (0x0B)
		{
			Data = new Byte [7];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(DamageAmount);
		}
	}
	/// <summary>
	/// Status of character.
	/// </summary>
	public class MobileStatus : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Char[] Name { get; set; }
		public Word HitPoints { get; set; }
		public Word MaximumHitPoints { get; set; }
		public AllowNameChange5 AllowNameChange50 { get; set; }
		public SupportedFeatures6 SupportedFeatures61 { get; set; }
		public Byte Gender { get; set; }
		public Word Strength { get; set; }
		public Word Dexterity { get; set; }
		public Word Intelligence { get; set; }
		public Word Stamina { get; set; }
		public Word MaximumStamina { get; set; }
		public Word Mana { get; set; }
		public Word MaximumMana { get; set; }
		public DWord Gold { get; set; }
		public Word ArmorRating { get; set; }
		public Word Weight { get; set; }
		public Word MaximumWeight { get; set; }
		public Race7 Race72 { get; set; }
		public Word StatCap { get; set; }
		public Byte Followers { get; set; }
		public Byte MaximumFollowers { get; set; }
		public Word FireResistance { get; set; }
		public Word ColdResistance { get; set; }
		public Word PoisonResistance { get; set; }
		public Word EnergyResistance { get; set; }
		public Word Luck { get; set; }
		public Word MinimumWeaponDamage { get; set; }
		public Word MaximumWeaponDamage { get; set; }
		public DWord TithingPoints { get; set; }
		public Word HitChanceIncrease { get; set; }
		public Word SwingSpeedIncrease { get; set; }
		public Word DamageChanceIncrease { get; set; }
		public Word LowerReagentCost { get; set; }
		public Word HitPointsRegeneration { get; set; }
		public Word StaminaRegeneration { get; set; }
		public Word ManaRegeneration { get; set; }
		public Word ReflectPhysicalDamage { get; set; }
		public Word EnhancePotions { get; set; }
		public Word DefenseChanceIncrease { get; set; }
		public Word SpellDamageIncrease { get; set; }
		public Word FasterCastRecovery { get; set; }
		public Word FasterCasting { get; set; }
		public Word LowerManaCost { get; set; }
		public Word StrengthIncrease { get; set; }
		public Word DexterityIncrease { get; set; }
		public Word IntelligenceIncrease { get; set; }
		public Word HitPointsIncrease { get; set; }
		public Word StaminaIncrease { get; set; }
		public Word ManaIncrease { get; set; }
		public Word MaximumHitPointsIncrease { get; set; }
		public Word MaximumStaminaIncrease { get; set; }
		public Word MaximumManaIncrease { get; set; }
		public MobileStatus() : base (0x11)
		{
			Name = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertChar(Name);
			InsertWord(HitPoints);
			InsertWord(MaximumHitPoints);
			InsertByte((Byte)AllowNameChange50);
			InsertByte((Byte)SupportedFeatures61);
			InsertByte(Gender);
			InsertWord(Strength);
			InsertWord(Dexterity);
			InsertWord(Intelligence);
			InsertWord(Stamina);
			InsertWord(MaximumStamina);
			InsertWord(Mana);
			InsertWord(MaximumMana);
			InsertDWord(Gold);
			InsertWord(ArmorRating);
			InsertWord(Weight);
			InsertWord(MaximumWeight);
			InsertByte((Byte)Race72);
			InsertWord(StatCap);
			InsertByte(Followers);
			InsertByte(MaximumFollowers);
			InsertWord(FireResistance);
			InsertWord(ColdResistance);
			InsertWord(PoisonResistance);
			InsertWord(EnergyResistance);
			InsertWord(Luck);
			InsertWord(MinimumWeaponDamage);
			InsertWord(MaximumWeaponDamage);
			InsertDWord(TithingPoints);
			InsertWord(HitChanceIncrease);
			InsertWord(SwingSpeedIncrease);
			InsertWord(DamageChanceIncrease);
			InsertWord(LowerReagentCost);
			InsertWord(HitPointsRegeneration);
			InsertWord(StaminaRegeneration);
			InsertWord(ManaRegeneration);
			InsertWord(ReflectPhysicalDamage);
			InsertWord(EnhancePotions);
			InsertWord(DefenseChanceIncrease);
			InsertWord(SpellDamageIncrease);
			InsertWord(FasterCastRecovery);
			InsertWord(FasterCasting);
			InsertWord(LowerManaCost);
			InsertWord(StrengthIncrease);
			InsertWord(DexterityIncrease);
			InsertWord(IntelligenceIncrease);
			InsertWord(HitPointsIncrease);
			InsertWord(StaminaIncrease);
			InsertWord(ManaIncrease);
			InsertWord(MaximumHitPointsIncrease);
			InsertWord(MaximumStaminaIncrease);
			InsertWord(MaximumManaIncrease);
		}
	}
	/// <summary>
	/// Follow Character Packet.
	/// </summary>
	public class FollowCharacter : Packet
	{
		public DWord Serial1 { get; set; }
		public DWord Serial2 { get; set; }
		public FollowCharacter() : base (0x15)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial1);
			InsertDWord(Serial2);
		}
	}
	/// <summary>
	/// UO3D Mobile New Health Bar Status.
	/// </summary>
	public class UO3DMobileNewHealthBarStatus : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Extended { get; set; }
		public StatusColor9 StatusColor92 { get; set; }
		public Flag10 Flag105 { get; set; }
		/* If mobile is poisoned, flag value > 0x00 - poison level. Since 4.0.7.0/7.0.7.0, sends to both 2d and 3d but works only in 3d. Server sends it as response for 0x34 Mobile Status Query. */
		public UO3DMobileNewHealthBarStatus() : base (0x16)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertWord(Extended);
			InsertWord((Word)StatusColor92);
			InsertByte((Byte)Flag105);
		}
	}
	/// <summary>
	/// Mobile Health Bar Status Update.
	/// </summary>
	public class MobileHealthBarStatusUpdate : Packet
	{
		public Word PacketSize { get; set; }
		public DWord MobileSerial { get; set; }
		public Word Filler0 { get; set; }
		public StatusColor11 StatusColor111 { get; set; }
		public Flag12 Flag122 { get; set; }
		/* If mobile is poisoned, flag value > 0x00 - poison level */
		public MobileHealthBarStatusUpdate() : base (0x17)
		{
			Filler0 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(MobileSerial);
			InsertWord(Filler0);
			InsertWord((Word)StatusColor111);
			InsertByte((Byte)Flag122);
		}
	}
	/// <summary>
	/// World Item Packet.
	/// </summary>
	public class WorldItem : Packet
	{
		public Word PacketSize { get; set; }
		public Serial13 Serial132 { get; set; }
		public Word Amount { get; set; }
		public X14 X143 { get; set; }
		public Y15 Y157 { get; set; }
		public Byte LightLevel { get; set; }
		public SByte Z { get; set; }
		public Word Hue { get; set; }
		public Flags16 Flags1610 { get; set; }
		/* No longer used since UO:SA. */
		public WorldItem() : base (0x1A)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord((DWord)Serial132);
			InsertWord(Amount);
			InsertWord((Word)X143);
			InsertWord((Word)Y157);
			InsertByte(LightLevel);
			InsertSByte(Z);
			InsertWord(Hue);
			InsertByte((Byte)Flags1610);
		}
	}
	/// <summary>
	/// Login Confirm Packet.
	/// </summary>
	public class LoginConfirm : Packet
	{
		public DWord Serial { get; set; }
		public DWord Filler0 { get; set; }
		public Word Body { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word Z { get; set; }
		public Direction17 Direction171 { get; set; }
		public Byte Filler2 { get; set; }
		public DWord Filler3 { get; set; }
		public Word Filler4 { get; set; }
		public Word Filler5 { get; set; }
		public Word MapWidth { get; set; }
		public Word MapHeight { get; set; }
		public Byte[] Filler6 { get; set; }
		public LoginConfirm() : base (0x1B)
		{
			Data = new Byte [37];
			Filler0 = 0x00;
			Filler2 = 0x00;
			Filler3 = 0xFFFFFFFF;
			Filler4 = 0x00;
			Filler5 = 0x00;
			Filler6 = new Byte [6];
			for (Int32 i=0; i<Filler6.Length; i++)
			{
				Filler6[i] = 0x00;
			}
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertDWord(Filler0);
			InsertWord(Body);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(Z);
			InsertByte((Byte)Direction171);
			InsertByte(Filler2);
			InsertDWord(Filler3);
			InsertWord(Filler4);
			InsertWord(Filler5);
			InsertWord(MapWidth);
			InsertWord(MapHeight);
			InsertByte(Filler6);
		}
	}
	/// <summary>
	/// Ascii Message Packet.
	/// </summary>
	public class AsciiMessage : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Graphic { get; set; }
		public MessageType18 MessageType180 { get; set; }
		public Word Hue { get; set; }
		public Word Font { get; set; }
		public Char[] Name { get; set; }
		public String TextMessage { get; set; }
		public AsciiMessage() : base (0x1C)
		{
			Name = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertWord(Graphic);
			InsertByte((Byte)MessageType180);
			InsertWord(Hue);
			InsertWord(Font);
			InsertChar(Name);
			InsertString(TextMessage);
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
	/// Mobile Update Packet.
	/// </summary>
	public class MobileUpdate : Packet
	{
		public DWord Serial { get; set; }
		public Word Body { get; set; }
		public Byte Filler0 { get; set; }
		public Word Hue { get; set; }
		public Flags19 Flags191 { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word Filler2 { get; set; }
		public Direction20 Direction203 { get; set; }
		public SByte Z { get; set; }
		public MobileUpdate() : base (0x20)
		{
			Data = new Byte [19];
			Filler0 = 0x00;
			Filler2 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(Body);
			InsertByte(Filler0);
			InsertWord(Hue);
			InsertByte((Byte)Flags191);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(Filler2);
			InsertByte((Byte)Direction203);
			InsertSByte(Z);
		}
	}
	/// <summary>
	/// Movement Rejected Packet.
	/// </summary>
	public class MovementRejected : Packet
	{
		public Byte Sequence { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Direction21 Direction210 { get; set; }
		public SByte Z { get; set; }
		public MovementRejected() : base (0x21)
		{
			Data = new Byte [8];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Sequence);
			InsertWord(X);
			InsertWord(Y);
			InsertByte((Byte)Direction210);
			InsertSByte(Z);
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
	/// Drag Effect Packet.
	/// </summary>
	public class DragEffect : Packet
	{
		public Word ItemID { get; set; }
		public Byte Filler0 { get; set; }
		public Word Hue { get; set; }
		public Word Amount { get; set; }
		public DWord SourceSerial { get; set; }
		public Word SourceX { get; set; }
		public Word SourceY { get; set; }
		public SByte SourceZ { get; set; }
		public DWord TargetSerial { get; set; }
		public Word TargetX { get; set; }
		public Word TargetY { get; set; }
		public SByte TargetZ { get; set; }
		public DragEffect() : base (0x23)
		{
			Data = new Byte [26];
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(ItemID);
			InsertByte(Filler0);
			InsertWord(Hue);
			InsertWord(Amount);
			InsertDWord(SourceSerial);
			InsertWord(SourceX);
			InsertWord(SourceY);
			InsertSByte(SourceZ);
			InsertDWord(TargetSerial);
			InsertWord(TargetX);
			InsertWord(TargetY);
			InsertSByte(TargetZ);
		}
	}
	/// <summary>
	/// Container Display Packet.
	/// </summary>
	public class ContainerDisplay : Packet
	{
		public DWord Serial { get; set; }
		public Word GumpID { get; set; }
		public ContainerType22 ContainerType222 { get; set; }
		/* Container Type was added in UO:HS clients. */
		public ContainerDisplay() : base (0x24)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(GumpID);
			InsertWord((Word)ContainerType222);
		}
	}
	/// <summary>
	/// Container Content Update Packet.
	/// </summary>
	public class ContainerContentUpdate : Packet
	{
		public DWord Serial { get; set; }
		public Word ItemID { get; set; }
		public Byte ItemIDOffset { get; set; }
		public Word Amount { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Byte GridLocation { get; set; }
		public DWord ParentSerial { get; set; }
		public Word Hue { get; set; }
		/* Grid Location only since 6.0.1.7 2D and 2.45.5.6 UO3D */
		public ContainerContentUpdate() : base (0x25)
		{
			Data = new Byte [21];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(ItemID);
			InsertByte(ItemIDOffset);
			InsertWord(Amount);
			InsertWord(X);
			InsertWord(Y);
			InsertByte(GridLocation);
			InsertDWord(ParentSerial);
			InsertWord(Hue);
		}
	}
	/// <summary>
	/// Lift Rejected Packet.
	/// </summary>
	public class LiftRejected : Packet
	{
		public Reason23 Reason230 { get; set; }
		public LiftRejected() : base (0x27)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Reason230);
		}
	}
	/// <summary>
	/// Drop Rejected Packet.
	/// </summary>
	public class DropRejected : Packet
	{
		public Word X { get; set; }
		public Word Y { get; set; }
		public DropRejected() : base (0x28)
		{
			Data = new Byte [5];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(X);
			InsertWord(Y);
		}
	}
	/// <summary>
	/// Drop Accepted Packet.
	/// </summary>
	public class DropAccepted : Packet
	{
		public DropAccepted() : base (0x29)
		{
			Data = new Byte [1];
		}
		public void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Blood Mode Packet.
	/// </summary>
	public class BloodMode : Packet
	{
		public DWord Serial { get; set; }
		public BloodMode() : base (0x2A)
		{
			Data = new Byte [5];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
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
	/// Mobile Attributes Packet.
	/// </summary>
	public class MobileAttributes : Packet
	{
		public DWord Serial { get; set; }
		public Word HitPointsMax { get; set; }
		public Word HitPoints { get; set; }
		public Word ManaMax { get; set; }
		public Word Mana { get; set; }
		public Word StaminaMax { get; set; }
		public Word Stamina { get; set; }
		public MobileAttributes() : base (0x2D)
		{
			Data = new Byte [17];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(HitPointsMax);
			InsertWord(HitPoints);
			InsertWord(ManaMax);
			InsertWord(Mana);
			InsertWord(StaminaMax);
			InsertWord(Stamina);
		}
	}
	/// <summary>
	/// Equip Update Packet.
	/// </summary>
	public class EquipUpdate : Packet
	{
		public DWord Serial { get; set; }
		public Word ItemID { get; set; }
		public Byte Filler0 { get; set; }
		public Layer25 Layer251 { get; set; }
		public DWord ParentSerial { get; set; }
		public Word Hue { get; set; }
		public EquipUpdate() : base (0x2E)
		{
			Data = new Byte [15];
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(ItemID);
			InsertByte(Filler0);
			InsertByte((Byte)Layer251);
			InsertDWord(ParentSerial);
			InsertWord(Hue);
		}
	}
	/// <summary>
	/// Swing Packet.
	/// </summary>
	public class Swing : Packet
	{
		public Byte Filler0 { get; set; }
		public DWord AttackerSerial { get; set; }
		public DWord DefenderSerial { get; set; }
		public Swing() : base (0x2F)
		{
			Data = new Byte [10];
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Filler0);
			InsertDWord(AttackerSerial);
			InsertDWord(DefenderSerial);
		}
	}
	/// <summary>
	/// Attack Granted Packet.
	/// </summary>
	public class AttackGranted : Packet
	{
		public DWord Serial { get; set; }
		public AttackGranted() : base (0x30)
		{
			Data = new Byte [5];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
		}
	}
	/// <summary>
	/// UO3D Pet Window Packet.
	/// </summary>
	public class UO3DPetWindow : Packet
	{
		public Word PacketSize { get; set; }
		public DWord OwnerSerial { get; set; }
		public Byte PetsCount { get; set; }
		Pets Pets0 { get; set; }
		public UO3DPetWindow() : base (0x31)
		{
			Pets0 = new Pets();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(OwnerSerial);
			InsertByte(PetsCount);
		}
	}
	/// <summary>
	/// Pathfind Packet.
	/// </summary>
	public class Pathfind : Packet
	{
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word Z { get; set; }
		public Pathfind() : base (0x38)
		{
			Data = new Byte [7];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(Z);
		}
	}
	/// <summary>
	/// Skills Update Packet.
	/// </summary>
	public class SkillsUpdate : Packet
	{
		public Word PacketSize { get; set; }
		public ListType27 ListType270 { get; set; }
		Skills Skills1 { get; set; }
		public Word Filler2 { get; set; }
		public SkillsUpdate() : base (0x3A)
		{
			Skills1 = new Skills();
			Filler2 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte((Byte)ListType270);
			InsertWord(Filler2);
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
	/// Container Content Packet.
	/// </summary>
	public class ContainerContent : Packet
	{
		public Word PacketSize { get; set; }
		public Word ItemsCount { get; set; }
		Items Items0 { get; set; }
		/* Also old packet for Spellbook Content with spells instead of items: spell serial = 0x7FFFFFFF - spell index, Item ID = Direction = X = Y = Hue = 0, Amount = Index + Spell Offset */
		public ContainerContent() : base (0x3C)
		{
			Items0 = new Items();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(ItemsCount);
		}
	}
	/// <summary>
	/// Infravision Packet.
	/// </summary>
	public class Infravision : Packet
	{
		public DWord Serial { get; set; }
		public Byte Active { get; set; }
		public Infravision() : base (0x4E)
		{
			Data = new Byte [6];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertByte(Active);
		}
	}
	/// <summary>
	/// Global Light Packet.
	/// </summary>
	public class GlobalLight : Packet
	{
		public LightLevel29 LightLevel290 { get; set; }
		public GlobalLight() : base (0x4F)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)LightLevel290);
		}
	}
	/// <summary>
	/// Popup Message Packet.
	/// </summary>
	public class PopupMessage : Packet
	{
		public 0x0030 0x00300 { get; set; }
		public PopupMessage() : base (0x53)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)0x00300);
		}
	}
	/// <summary>
	/// Play Sound Packet.
	/// </summary>
	public class PlaySound : Packet
	{
		public Byte Flags { get; set; }
		public Word SoundID { get; set; }
		public Word Volume { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word Z { get; set; }
		public PlaySound() : base (0x54)
		{
			Data = new Byte [12];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Flags);
			InsertWord(SoundID);
			InsertWord(Volume);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(Z);
		}
	}
	/// <summary>
	/// Login Confirmed Packet.
	/// </summary>
	public class LoginConfirmed : Packet
	{
		public LoginConfirmed() : base (0x55)
		{
			Data = new Byte [1];
		}
		public void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Map Plot Packet.
	/// </summary>
	public class MapPlot : Packet
	{
		public DWord Serial { get; set; }
		public Action31 Action310 { get; set; }
		public Byte PinID { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public MapPlot() : base (0x56)
		{
			Data = new Byte [11];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertByte((Byte)Action310);
			InsertByte(PinID);
			InsertWord(X);
			InsertWord(Y);
		}
	}
	/// <summary>
	/// Game Time Packet.
	/// </summary>
	public class GameTime : Packet
	{
		public Byte Hour { get; set; }
		public Byte Minute { get; set; }
		public Byte Second { get; set; }
		public GameTime() : base (0x5B)
		{
			Data = new Byte [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Hour);
			InsertByte(Minute);
			InsertByte(Second);
		}
	}
	/// <summary>
	/// Change Weather Packet.
	/// </summary>
	public class ChangeWeather : Packet
	{
		public WeatherType33 WeatherType330 { get; set; }
		public Byte Density { get; set; }
		public Byte Temperature { get; set; }
		public ChangeWeather() : base (0x65)
		{
			Data = new Byte [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)WeatherType330);
			InsertByte(Density);
			InsertByte(Temperature);
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
	/// Play Music Packet.
	/// </summary>
	public class PlayMusic : Packet
	{
		public Word MusicID { get; set; }
		public PlayMusic() : base (0x6D)
		{
			Data = new Byte [3];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(MusicID);
		}
	}
	/// <summary>
	/// Secure Trade Packet.
	/// </summary>
	public class SecureTrade : Packet
	{
		public Word PacketSize { get; set; }
		public Action42 Action420 { get; set; }
		public DWord Serial { get; set; }
		public FirstContainerSerial43 FirstContainerSerial431 { get; set; }
		public SecondContainerSerial44 SecondContainerSerial442 { get; set; }
		public DisplayName45 DisplayName453 { get; set; }
		public Char[] Name { get; set; }
		public SecureTrade() : base (0x6F)
		{
			Name = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte((Byte)Action420);
			InsertDWord(Serial);
			InsertDWord((DWord)FirstContainerSerial431);
			InsertDWord((DWord)SecondContainerSerial442);
			InsertByte((Byte)DisplayName453);
			InsertChar(Name);
		}
	}
	/// <summary>
	/// Graphical Effect Packet.
	/// </summary>
	public class GraphicalEffect : Packet
	{
		public Type46 Type460 { get; set; }
		public DWord CharacterSerial { get; set; }
		public DWord TargetSerial { get; set; }
		public Word SourceX { get; set; }
		public Word SourceY { get; set; }
		public SByte SourceZ { get; set; }
		public Word DestinationX { get; set; }
		public Word DestinationY { get; set; }
		public SByte DestinationZ { get; set; }
		public Byte Speed { get; set; }
		public Byte Duration { get; set; }
		public Word Filler1 { get; set; }
		public FixedDirection47 FixedDirection472 { get; set; }
		public Explode48 Explode483 { get; set; }
		/* Since UO:SA this packet can be used for special effects. */
		public GraphicalEffect() : base (0x70)
		{
			Data = new Byte [28];
			Filler1 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Type460);
			InsertDWord(CharacterSerial);
			InsertDWord(TargetSerial);
			InsertWord(SourceX);
			InsertWord(SourceY);
			InsertSByte(SourceZ);
			InsertWord(DestinationX);
			InsertWord(DestinationY);
			InsertSByte(DestinationZ);
			InsertByte(Speed);
			InsertByte(Duration);
			InsertWord(Filler1);
			InsertByte((Byte)FixedDirection472);
			InsertByte((Byte)Explode483);
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
	/// Draw Bulletin Board Packet.
	/// </summary>
	public class DrawBulletinBoard : Packet
	{
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public Char[] BoardName { get; set; }
		public DWord ID { get; set; }
		public DWord Filler1 { get; set; }
		public DrawBulletinBoard() : base (0x71)
		{
			Filler0 = 0x00;
			BoardName = new Char [15];
			Filler1 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertChar(BoardName);
			InsertDWord(ID);
			InsertDWord(Filler1);
		}
	}
	/// <summary>
	/// Message List Bulletin Board Packet.
	/// </summary>
	public class MessageListBulletinBoard : Packet
	{
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public ContainerSerial49 ContainerSerial491 { get; set; }
		public Byte NameLength { get; set; }
		public String Name { get; set; }
		public Byte SubjectLength { get; set; }
		public String Subject { get; set; }
		public Byte TimeLength { get; set; }
		public String Time { get; set; }
		public MessageListBulletinBoard() : base (0x71)
		{
			Filler0 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertDWord(MessageSerial);
			InsertDWord((DWord)ContainerSerial491);
			InsertByte(NameLength);
			InsertString(Name);
			InsertByte(SubjectLength);
			InsertString(Subject);
			InsertByte(TimeLength);
			InsertString(Time);
		}
	}
	/// <summary>
	/// Message Bulletin Board Packet.
	/// </summary>
	public class MessageBulletinBoard : Packet
	{
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public DWord BoardSerial { get; set; }
		public DWord MessageSerial { get; set; }
		public Byte NameLength { get; set; }
		public String Name { get; set; }
		public Byte SubjectLength { get; set; }
		public String Subject { get; set; }
		public Byte TimeLength { get; set; }
		public String Time { get; set; }
		public Word MessageBody { get; set; }
		public Word MessageHue { get; set; }
		public Byte MessagesLength { get; set; }
		Messages Messages1 { get; set; }
		public Byte NumberLines { get; set; }
		Line Line2 { get; set; }
		public MessageBulletinBoard() : base (0x71)
		{
			Filler0 = 0x02;
			Messages1 = new Messages();
			Line2 = new Line();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(Filler0);
			InsertDWord(BoardSerial);
			InsertDWord(MessageSerial);
			InsertByte(NameLength);
			InsertString(Name);
			InsertByte(SubjectLength);
			InsertString(Subject);
			InsertByte(TimeLength);
			InsertString(Time);
			InsertWord(MessageBody);
			InsertWord(MessageHue);
			InsertByte(MessagesLength);
			InsertByte(NumberLines);
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
	/// Shop List Packet.
	/// </summary>
	public class ShopList : Packet
	{
		public Word PacketSize { get; set; }
		public DWord VendorSerial { get; set; }
		public Byte ItemsCount { get; set; }
		Items Items0 { get; set; }
		public ShopList() : base (0x74)
		{
			Items0 = new Items();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(VendorSerial);
			InsertByte(ItemsCount);
		}
	}
	/// <summary>
	/// Server Change Packet.
	/// </summary>
	public class ServerChange : Packet
	{
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word Z { get; set; }
		public Byte Filler0 { get; set; }
		public Word ServerBoundryX { get; set; }
		public Word ServerBoundryY { get; set; }
		public Word ServerBoundryWidth { get; set; }
		public Word ServerBoundryHeight { get; set; }
		public ServerChange() : base (0x76)
		{
			Data = new Byte [16];
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(Z);
			InsertByte(Filler0);
			InsertWord(ServerBoundryX);
			InsertWord(ServerBoundryY);
			InsertWord(ServerBoundryWidth);
			InsertWord(ServerBoundryHeight);
		}
	}
	/// <summary>
	/// Mobile Moving Packet.
	/// </summary>
	public class MobileMoving : Packet
	{
		public DWord Serial { get; set; }
		public Word Body { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public SByte Z { get; set; }
		public Direction51 Direction510 { get; set; }
		public Word Hue { get; set; }
		public Flags52 Flags521 { get; set; }
		public Notoriety53 Notoriety532 { get; set; }
		public MobileMoving() : base (0x77)
		{
			Data = new Byte [17];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(Body);
			InsertWord(X);
			InsertWord(Y);
			InsertSByte(Z);
			InsertByte((Byte)Direction510);
			InsertWord(Hue);
			InsertByte((Byte)Flags521);
			InsertByte((Byte)Notoriety532);
		}
	}
	/// <summary>
	/// Mobile Incoming Packet.
	/// </summary>
	public class MobileIncoming : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Body { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public SByte Z { get; set; }
		public Direction54 Direction540 { get; set; }
		public Word Hue { get; set; }
		public Flags55 Flags551 { get; set; }
		public Notoriety56 Notoriety562 { get; set; }
		Items Items3 { get; set; }
		public DWord Filler4 { get; set; }
		public MobileIncoming() : base (0x78)
		{
			Items3 = new Items();
			Filler4 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertWord(Body);
			InsertWord(X);
			InsertWord(Y);
			InsertSByte(Z);
			InsertByte((Byte)Direction540);
			InsertWord(Hue);
			InsertByte((Byte)Flags551);
			InsertByte((Byte)Notoriety562);
			InsertDWord(Filler4);
		}
	}
	/// <summary>
	/// Sequence Packet.
	/// </summary>
	public class Sequence : Packet
	{
		public Byte Value { get; set; }
		public Sequence() : base (0x7B)
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
	/// Display Item List Menu Packet.
	/// </summary>
	public class DisplayItemListMenu : Packet
	{
		public Word PacketSize { get; set; }
		public DWord SenderSerial { get; set; }
		public Word GumpID { get; set; }
		public Byte TitleLength { get; set; }
		public String Title { get; set; }
		public Byte NumberOfLines { get; set; }
		Lines Lines0 { get; set; }
		public DisplayItemListMenu() : base (0x7C)
		{
			Lines0 = new Lines();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(SenderSerial);
			InsertWord(GumpID);
			InsertByte(TitleLength);
			InsertString(Title);
			InsertByte(NumberOfLines);
		}
	}
	/// <summary>
	/// Item List Menu Response Packet.
	/// </summary>
	public class ItemListMenuResponse : Packet
	{
		public DWord SenderSerial { get; set; }
		public Word GumpID { get; set; }
		public Word Index { get; set; }
		public Word ItemID { get; set; }
		public Word Hue { get; set; }
		public ItemListMenuResponse() : base (0x7D)
		{
			Data = new Byte [13];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(SenderSerial);
			InsertWord(GumpID);
			InsertWord(Index);
			InsertWord(ItemID);
			InsertWord(Hue);
		}
	}
	/// <summary>
	/// Change Character Packet.
	/// </summary>
	public class ChangeCharacter : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CharactersCount { get; set; }
		public Byte Command { get; set; }
		Characters Characters0 { get; set; }
		public ChangeCharacter() : base (0x81)
		{
			Characters0 = new Characters();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CharactersCount);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Account Login Rejection Packet.
	/// </summary>
	public class AccountLoginRejection : Packet
	{
		public RejectionReason58 RejectionReason580 { get; set; }
		public AccountLoginRejection() : base (0x82)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)RejectionReason580);
		}
	}
	/// <summary>
	/// Character Delete Result Packet.
	/// </summary>
	public class CharacterDeleteResult : Packet
	{
		public DeleteResult59 DeleteResult590 { get; set; }
		public CharacterDeleteResult() : base (0x85)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)DeleteResult590);
		}
	}
	/// <summary>
	/// Character List Update Packet.
	/// </summary>
	public class CharacterListUpdate : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CharactersCount { get; set; }
		Characters Characters0 { get; set; }
		public CharacterListUpdate() : base (0x86)
		{
			Characters0 = new Characters();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CharactersCount);
		}
	}
	/// <summary>
	/// Display Paperdoll Packet.
	/// </summary>
	public class DisplayPaperdoll : Packet
	{
		public DWord Serial { get; set; }
		public Char[] Text { get; set; }
		public Flags60 Flags600 { get; set; }
		public DisplayPaperdoll() : base (0x88)
		{
			Data = new Byte [66];
			Text = new Char [60];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertChar(Text);
			InsertByte((Byte)Flags600);
		}
	}
	/// <summary>
	/// Corpse Equip Packet.
	/// </summary>
	public class CorpseEquip : Packet
	{
		public Word PacketSize { get; set; }
		public DWord ContainerSerial { get; set; }
		Items Items0 { get; set; }
		public Byte Filler1 { get; set; }
		public CorpseEquip() : base (0x89)
		{
			Items0 = new Items();
			Filler1 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(ContainerSerial);
			InsertByte(Filler1);
		}
	}
	/// <summary>
	/// Display Sign Gump Packet.
	/// </summary>
	public class DisplaySignGump : Packet
	{
		public Word PacketSize { get; set; }
		public DWord SenderSerial { get; set; }
		public Word GumpID { get; set; }
		public Word TextLength { get; set; }
		public String Text { get; set; }
		public Word CaptionLength { get; set; }
		public String Caption { get; set; }
		public DisplaySignGump() : base (0x8B)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(SenderSerial);
			InsertWord(GumpID);
			InsertWord(TextLength);
			InsertString(Text);
			InsertWord(CaptionLength);
			InsertString(Caption);
		}
	}
	/// <summary>
	/// Play Server Accept Packet.
	/// </summary>
	public class PlayServerAccept : Packet
	{
		public DWord ServerIP { get; set; }
		public Word ServerPort { get; set; }
		public DWord AuthID { get; set; }
		public PlayServerAccept() : base (0x8C)
		{
			Data = new Byte [11];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(ServerIP);
			InsertWord(ServerPort);
			InsertDWord(AuthID);
		}
	}
	/// <summary>
	/// Map Details Packet.
	/// </summary>
	public class MapDetails : Packet
	{
		public DWord Serial { get; set; }
		public Word CornerImage { get; set; }
		public Word X1 { get; set; }
		public Word Y1 { get; set; }
		public Word X2 { get; set; }
		public Word Y2 { get; set; }
		public Word Width { get; set; }
		public Word Height { get; set; }
		public MapDetails() : base (0x90)
		{
			Data = new Byte [19];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(CornerImage);
			InsertWord(X1);
			InsertWord(Y1);
			InsertWord(X2);
			InsertWord(Y2);
			InsertWord(Width);
			InsertWord(Height);
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
	/// Player Move Packet.
	/// </summary>
	public class PlayerMove : Packet
	{
		public Direction65 Direction650 { get; set; }
		public PlayerMove() : base (0x97)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Direction650);
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
	/// Multi Target Packet.
	/// </summary>
	public class MultiTarget : Packet
	{
		public TargetType66 TargetType660 { get; set; }
		public DWord SenderSerial { get; set; }
		public Flags67 Flags671 { get; set; }
		public Byte[] Filler2 { get; set; }
		public Word Graphic { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word Z { get; set; }
		public DWord Hue { get; set; }
		/* Hue was added in UO:HS clients */
		public MultiTarget() : base (0x99)
		{
			Data = new Byte [30];
			Filler2 = new Byte [11];
			for (Int32 i=0; i<Filler2.Length; i++)
			{
				Filler2[i] = 0x00;
			}
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)TargetType660);
			InsertDWord(SenderSerial);
			InsertByte((Byte)Flags671);
			InsertByte(Filler2);
			InsertWord(Graphic);
			InsertWord(X);
			InsertWord(Y);
			InsertWord(Z);
			InsertDWord(Hue);
		}
	}
	/// <summary>
	/// Shop Sell Packet.
	/// </summary>
	public class ShopSell : Packet
	{
		public Word PacketSize { get; set; }
		public DWord VendorSerial { get; set; }
		public Word ItemsCount { get; set; }
		Items Items0 { get; set; }
		public ShopSell() : base (0x9E)
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
	/// Mobile Hits Packet.
	/// </summary>
	public class MobileHits : Packet
	{
		public DWord Serial { get; set; }
		public Word HitPointsMax { get; set; }
		public Word HitPoints { get; set; }
		public MobileHits() : base (0xA1)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(HitPointsMax);
			InsertWord(HitPoints);
		}
	}
	/// <summary>
	/// Mobile Mana Packet.
	/// </summary>
	public class MobileMana : Packet
	{
		public DWord Serial { get; set; }
		public Word ManaMax { get; set; }
		public Word Mana { get; set; }
		public MobileMana() : base (0xA2)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(ManaMax);
			InsertWord(Mana);
		}
	}
	/// <summary>
	/// Mobile Stamina Packet.
	/// </summary>
	public class MobileStamina : Packet
	{
		public DWord Serial { get; set; }
		public Word StaminaMax { get; set; }
		public Word Stamina { get; set; }
		public MobileStamina() : base (0xA3)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(StaminaMax);
			InsertWord(Stamina);
		}
	}
	/// <summary>
	/// Launch Browser Packet.
	/// </summary>
	public class LaunchBrowser : Packet
	{
		public Word PacketSize { get; set; }
		public String URL { get; set; }
		public LaunchBrowser() : base (0xA5)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertString(URL);
		}
	}
	/// <summary>
	/// Scroll Message Packet.
	/// </summary>
	public class ScrollMessage : Packet
	{
		public Word PacketSize { get; set; }
		public Byte FontType { get; set; }
		public DWord TipNumber { get; set; }
		public Word MessageLength { get; set; }
		public String Message { get; set; }
		public ScrollMessage() : base (0xA6)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(FontType);
			InsertDWord(TipNumber);
			InsertWord(MessageLength);
			InsertString(Message);
		}
	}
	/// <summary>
	/// Servers List Packet.
	/// </summary>
	public class ServersList : Packet
	{
		public Word PacketSize { get; set; }
		public Byte Filler0 { get; set; }
		public Word ServersCount { get; set; }
		Servers Servers1 { get; set; }
		public ServersList() : base (0xA8)
		{
			Filler0 = 0x00;
			Servers1 = new Servers();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(Filler0);
			InsertWord(ServersCount);
		}
	}
	/// <summary>
	/// Characters List Packet.
	/// </summary>
	public class CharactersList : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CharactersCount { get; set; }
		Characters Characters0 { get; set; }
		public Byte CitiesCount { get; set; }
		Cities Cities1 { get; set; }
		public Flags69 Flags693 { get; set; }
		public Word LastCharacterSlot { get; set; }
		/* Each flag is for each feature, if you need to combine features, you need to summ flags. Unknown Flag1 never was sent by OSI. Unknown Flag 2 was added with UO:KR launch. Unknown Flag 3 was added sometimes between UO:KR and UO:SA launch. Flag 4 was added with UO:SA launch. All 4 flags are useless: no client reaction. Last character slot for SA 3D clients: it will highlight last character used. 0x8000 flag is used for unlocking new Felucca factions areas, note that you have to use "_x" versions of map/statics if you want to move through new areas. */
		/* Since 7.0.13.0 and 4.0.13.0 City Name and Building Name have length of 32 chars, also added city x,y,z,map,cliloc description and dword 0 to city structure. */
		public CharactersList() : base (0xA9)
		{
			Characters0 = new Characters();
			Cities1 = new Cities();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CharactersCount);
			InsertByte(CitiesCount);
			InsertDWord((DWord)Flags693);
			InsertWord(LastCharacterSlot);
		}
	}
	/// <summary>
	/// Change Combatant Packet.
	/// </summary>
	public class ChangeCombatant : Packet
	{
		public DWord CombatantSerial { get; set; }
		public ChangeCombatant() : base (0xAA)
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
	/// String Response Packet.
	/// </summary>
	public class StringResponse : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Byte ParentID { get; set; }
		public Byte ButtonID { get; set; }
		public Mode71 Mode710 { get; set; }
		public Word TextLength { get; set; }
		public String Text { get; set; }
		public StringResponse() : base (0xAC)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertByte(ParentID);
			InsertByte(ButtonID);
			InsertByte((Byte)Mode710);
			InsertWord(TextLength);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Unicode Text Packet.
	/// </summary>
	public class UnicodeText : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Graphic { get; set; }
		public Mode73 Mode730 { get; set; }
		public Word TextColor { get; set; }
		public Word Font { get; set; }
		public Char[] Language { get; set; }
		public Char[] Name { get; set; }
		public String Text { get; set; }
		public UnicodeText() : base (0xAE)
		{
			Language = new Char [4];
			Name = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertWord(Graphic);
			InsertByte((Byte)Mode730);
			InsertWord(TextColor);
			InsertWord(Font);
			InsertChar(Language);
			InsertChar(Name);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Death Animation Packet.
	/// </summary>
	public class DeathAnimation : Packet
	{
		public DWord VictimSerial { get; set; }
		public DWord CorpseSerial { get; set; }
		public DWord Filler0 { get; set; }
		public DeathAnimation() : base (0xAF)
		{
			Data = new Byte [13];
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(VictimSerial);
			InsertDWord(CorpseSerial);
			InsertDWord(Filler0);
		}
	}
	/// <summary>
	/// Generic Gump Packet.
	/// </summary>
	public class GenericGump : Packet
	{
		public Word PacketSize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord GumpID { get; set; }
		public DWord X { get; set; }
		public DWord Y { get; set; }
		public Word LayoutLength { get; set; }
		public String Layout { get; set; }
		public Word NumberOfLines { get; set; }
		Lines Lines0 { get; set; }
		/* Gump ID is special type id. See link below for more information. */
		public GenericGump() : base (0xB0)
		{
			Lines0 = new Lines();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(SenderSerial);
			InsertDWord(GumpID);
			InsertDWord(X);
			InsertDWord(Y);
			InsertWord(LayoutLength);
			InsertString(Layout);
			InsertWord(NumberOfLines);
		}
	}
	/// <summary>
	/// Chat Message Packet.
	/// </summary>
	public class ChatMessage : Packet
	{
		public Word PacketSize { get; set; }
		public Word MessageNumber { get; set; }
		public Char[] Language { get; set; }
		public String Param1 { get; set; }
		public String Param2 { get; set; }
		public ChatMessage() : base (0xB2)
		{
			Language = new Char [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(MessageNumber);
			InsertChar(Language);
			InsertString(Param1);
			InsertString(Param2);
		}
	}
	/// <summary>
	/// Object Help Response Packet.
	/// </summary>
	public class ObjectHelpResponse : Packet
	{
		public Word PacketSize { get; set; }
		public DWord HelpObjectSerial { get; set; }
		public String HelpText { get; set; }
		public ObjectHelpResponse() : base (0xB7)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(HelpObjectSerial);
			InsertString(HelpText);
		}
	}
	/// <summary>
	/// Profile Response Packet.
	/// </summary>
	public class ProfileResponse : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public String Header { get; set; }
		public String Body { get; set; }
		public String Footer { get; set; }
		public ProfileResponse() : base (0xB8)
		{
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertString(Header);
			InsertString(Body);
			InsertString(Footer);
		}
	}
	/// <summary>
	/// Supported Features Packet.
	/// </summary>
	public class SupportedFeatures : Packet
	{
		public Flags78 Flags7818 { get; set; }
		/* Each flag is for each feature, if you need to combine features, you need to summ flags. This packet is send immediately after login. on OSI  servers this controls features: OSI enables/disables it via “upgrade codes.” since UO:SA launch it’s 5 bytes packet, not 3 bytes. */
		public SupportedFeatures() : base (0xB9)
		{
			Data = new Byte [5];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord((DWord)Flags7818);
		}
	}
	/// <summary>
	/// Display Quest Pointer Packet.
	/// </summary>
	public class DisplayQuestPointer : Packet
	{
		public Active79 Active790 { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public DWord TargetSerial { get; set; }
		/* Target Serial was added in UO:HS clients. */
		public DisplayQuestPointer() : base (0xBA)
		{
			Data = new Byte [10];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Active790);
			InsertWord(X);
			InsertWord(Y);
			InsertDWord(TargetSerial);
		}
	}
	/// <summary>
	/// Season Change Packet.
	/// </summary>
	public class SeasonChange : Packet
	{
		public Season80 Season800 { get; set; }
		public PlayMusic81 PlayMusic811 { get; set; }
		public SeasonChange() : base (0xBC)
		{
			Data = new Byte [3];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Season800);
			InsertByte((Byte)PlayMusic811);
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
	/// Fast Walk Packet.
	/// </summary>
	public class FastWalk : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord[] KeyStack { get; set; }
		/* Cycle's through the keys in the stack when walking. */
		public FastWalk() : base (0xBF)
		{
			Filler0 = 0x01;
			KeyStack = new DWord [6];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(KeyStack);
		}
	}
	/// <summary>
	/// Add Walk Key Packet.
	/// </summary>
	public class AddWalkKey : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Key { get; set; }
		/* Add a key to the top of the Walk Stack. */
		public AddWalkKey() : base (0xBF)
		{
			Filler0 = 0x02;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Key);
		}
	}
	/// <summary>
	/// Close Gump Packet.
	/// </summary>
	public class CloseGump : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord GumpID { get; set; }
		public DWord ButtonID { get; set; }
		public CloseGump() : base (0xBF)
		{
			Filler0 = 0x04;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(GumpID);
			InsertDWord(ButtonID);
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
	/// Party Display Members List Packet.
	/// </summary>
	public class PartyDisplayMembersList : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public Byte MembersCount { get; set; }
		Members Members2 { get; set; }
		public PartyDisplayMembersList() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x01;
			Members2 = new Members();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertByte(MembersCount);
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
		public Byte MembersCount { get; set; }
		public DWord RemovedMemberSerial { get; set; }
		Members Members2 { get; set; }
		public PartyRemoveMember() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x02;
			Members2 = new Members();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertByte(MembersCount);
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
		public DWord MemberSerial { get; set; }
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
			InsertDWord(MemberSerial);
			InsertString(Message);
		}
	}
	/// <summary>
	/// Party Invitation Packet.
	/// </summary>
	public class PartyInvitation : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord PartyLeaderSerial { get; set; }
		public PartyInvitation() : base (0xBF)
		{
			Filler0 = 0x06;
			Filler1 = 0x07;
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
	/// Map Change Packet.
	/// </summary>
	public class MapChange : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public MapChange() : base (0xBF)
		{
			Filler0 = 0x08;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Display Equipment Info Packet.
	/// </summary>
	public class DisplayEquipmentInfo : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public DWord InfoNumber { get; set; }
		public DWord Filler1 { get; set; }
		public Word OwnerNameLength { get; set; }
		public String OwnerName { get; set; }
		public DWord Filler2 { get; set; }
		Attribute Attribute3 { get; set; }
		public DWord Filler4 { get; set; }
		public DisplayEquipmentInfo() : base (0xBF)
		{
			Filler0 = 0x10;
			Attribute3 = new Attribute();
			Filler4 = 0xFFFFFFFF;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Serial);
			InsertDWord(InfoNumber);
			InsertDWord(Filler1);
			InsertWord(OwnerNameLength);
			InsertString(OwnerName);
			InsertDWord(Filler2);
			InsertDWord(Filler4);
		}
	}
	/// <summary>
	/// Display Context Menu Packet.
	/// </summary>
	public class DisplayContextMenu : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Word Filler1 { get; set; }
		public DWord Serial { get; set; }
		public Byte Length { get; set; }
		ContextMenuEntries ContextMenuEntries2 { get; set; }
		/* Appearance: KR -> SA3D -> 2D post 7.0.0.0 */
		public DisplayContextMenu() : base (0xBF)
		{
			Filler0 = 0x14;
			Filler1 = 0x02;
			ContextMenuEntries2 = new ContextMenuEntries();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord(Filler1);
			InsertDWord(Serial);
			InsertByte(Length);
		}
	}
	/// <summary>
	/// Close User Interface Window Packet.
	/// </summary>
	public class CloseUserInterfaceWindow : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Command87 Command871 { get; set; }
		public ObjectSerial88 ObjectSerial884 { get; set; }
		public CloseUserInterfaceWindow() : base (0xBF)
		{
			Filler0 = 0x16;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord((DWord)Command871);
			InsertDWord((DWord)ObjectSerial884);
		}
	}
	/// <summary>
	/// Display Help Topic Packet.
	/// </summary>
	public class DisplayHelpTopic : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord TopicID { get; set; }
		public Display89 Display892 { get; set; }
		public DisplayHelpTopic() : base (0xBF)
		{
			Filler0 = 0x17;
			Filler1 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(TopicID);
			InsertByte((Byte)Display892);
		}
	}
	/// <summary>
	/// Map Patches Packet.
	/// </summary>
	public class MapPatches : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord MapsCount { get; set; }
		Maps Maps1 { get; set; }
		public MapPatches() : base (0xBF)
		{
			Filler0 = 0x18;
			Maps1 = new Maps();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(MapsCount);
		}
	}
	/// <summary>
	/// Miscellaneous status Packet.
	/// </summary>
	public class Miscellaneousstatus : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Command { get; set; }
		public Miscellaneousstatus() : base (0xBF)
		{
			Filler0 = 0x19;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Stat Lock Info Packet.
	/// </summary>
	public class StatLockInfo : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Serial { get; set; }
		public Byte Filler2 { get; set; }
		public Byte LockFlags { get; set; }
		/* StrLock = StrLock left-shift 4. DexLock = DexLock left-shift 2. */
		public StatLockInfo() : base (0xBF)
		{
			Filler0 = 0x19;
			Filler1 = 0x02;
			Filler2 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Serial);
			InsertByte(Filler2);
			InsertByte(LockFlags);
		}
	}
	/// <summary>
	/// UO3D Stat Lock Info Packet.
	/// </summary>
	public class UO3DStatLockInfo : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Serial { get; set; }
		public Byte Filler2 { get; set; }
		public Byte LockFlags { get; set; }
		public Byte[] Filler3 { get; set; }
		/* StrLock = StrLock left-shift 4. DexLock = DexLock left-shift 2. */
		public UO3DStatLockInfo() : base (0xBF)
		{
			Filler0 = 0x19;
			Filler1 = 0x05;
			Filler2 = 0x00;
			Filler3 = new Byte [5];
			for (Int32 i=0; i<Filler3.Length; i++)
			{
				Filler3[i] = 0x00;
			}
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Serial);
			InsertByte(Filler2);
			InsertByte(LockFlags);
			InsertByte(Filler3);
		}
	}
	/// <summary>
	/// Update Mobile Status Animation Packet.
	/// </summary>
	public class UpdateMobileStatusAnimation : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Serial { get; set; }
		public Byte Filler2 { get; set; }
		public Byte Filler3 { get; set; }
		public Byte Status { get; set; }
		public Word Animation { get; set; }
		public Word Frame { get; set; }
		/* OSI uses this packet for updating character statues. */
		public UpdateMobileStatusAnimation() : base (0xBF)
		{
			Filler0 = 0x19;
			Filler1 = 0x05;
			Filler2 = 0x00;
			Filler3 = 0xFF;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Serial);
			InsertByte(Filler2);
			InsertByte(Filler3);
			InsertByte(Status);
			InsertWord(Animation);
			InsertWord(Frame);
		}
	}
	/// <summary>
	/// New Bonded Status Packet.
	/// </summary>
	public class NewBondedStatus : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Serial { get; set; }
		public Dead91 Dead912 { get; set; }
		public Byte Filler3 { get; set; }
		public Byte Filler4 { get; set; }
		public Word Filler5 { get; set; }
		public Word Filler6 { get; set; }
		public Word Filler7 { get; set; }
		/* OSI uses this packet for sending pet's bonded status. It replaced the original 0xBF.0x19.0x00 bonded status packet. */
		public NewBondedStatus() : base (0xBF)
		{
			Filler0 = 0x19;
			Filler1 = 0x05;
			Filler3 = 0xFF;
			Filler4 = 0x00;
			Filler5 = 0x00;
			Filler6 = 0x00;
			Filler7 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Serial);
			InsertByte((Byte)Dead912);
			InsertByte(Filler3);
			InsertByte(Filler4);
			InsertWord(Filler5);
			InsertWord(Filler6);
			InsertWord(Filler7);
		}
	}
	/// <summary>
	/// Spellbook Content Packet.
	/// </summary>
	public class SpellbookContent : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Word Filler1 { get; set; }
		public DWord SpellbookSerial { get; set; }
		public Word Graphic { get; set; }
		public Word Offset { get; set; }
		public QWord SpellbookContent { get; set; }
		public SpellbookContent() : base (0xBF)
		{
			Filler0 = 0x1B;
			Filler1 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord(Filler1);
			InsertDWord(SpellbookSerial);
			InsertWord(Graphic);
			InsertWord(Offset);
			InsertQWord(SpellbookContent);
		}
	}
	/// <summary>
	/// Design House Packet.
	/// </summary>
	public class DesignHouse : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public DWord Revision { get; set; }
		public DesignHouse() : base (0xBF)
		{
			Filler0 = 0x1D;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(HouseFoundationSerial);
			InsertDWord(Revision);
		}
	}
	/// <summary>
	/// House Customization Packet.
	/// </summary>
	public class HouseCustomization : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public Byte Command { get; set; }
		public HouseCustomization() : base (0xBF)
		{
			Filler0 = 0x20;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(HouseFoundationSerial);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Update House Customization Packet.
	/// </summary>
	public class UpdateHouseCustomization : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public Byte Filler1 { get; set; }
		public Word TileID { get; set; }
		public Word TileX { get; set; }
		public Word TileY { get; set; }
		public Byte TileZ { get; set; }
		public UpdateHouseCustomization() : base (0xBF)
		{
			Filler0 = 0x20;
			Filler1 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(HouseFoundationSerial);
			InsertByte(Filler1);
			InsertWord(TileID);
			InsertWord(TileX);
			InsertWord(TileY);
			InsertByte(TileZ);
		}
	}
	/// <summary>
	/// Begin House Customization Packet.
	/// </summary>
	public class BeginHouseCustomization : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public Byte Filler1 { get; set; }
		public Word Filler2 { get; set; }
		public Word Filler3 { get; set; }
		public Word Filler4 { get; set; }
		public Byte Filler5 { get; set; }
		public BeginHouseCustomization() : base (0xBF)
		{
			Filler0 = 0x20;
			Filler1 = 0x04;
			Filler2 = 0x00;
			Filler3 = 0xFF;
			Filler4 = 0xFF;
			Filler5 = 0xFF;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(HouseFoundationSerial);
			InsertByte(Filler1);
			InsertWord(Filler2);
			InsertWord(Filler3);
			InsertWord(Filler4);
			InsertByte(Filler5);
		}
	}
	/// <summary>
	/// End House Customization Packet.
	/// </summary>
	public class EndHouseCustomization : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public Byte Filler1 { get; set; }
		public Word Filler2 { get; set; }
		public Word Filler3 { get; set; }
		public Word Filler4 { get; set; }
		public Byte Filler5 { get; set; }
		public EndHouseCustomization() : base (0xBF)
		{
			Filler0 = 0x20;
			Filler1 = 0x05;
			Filler2 = 0x00;
			Filler3 = 0xFF;
			Filler4 = 0xFF;
			Filler5 = 0xFF;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(HouseFoundationSerial);
			InsertByte(Filler1);
			InsertWord(Filler2);
			InsertWord(Filler3);
			InsertWord(Filler4);
			InsertByte(Filler5);
		}
	}
	/// <summary>
	/// Clear Weapon Ability Packet.
	/// </summary>
	public class ClearWeaponAbility : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public ClearWeaponAbility() : base (0xBF)
		{
			Filler0 = 0x21;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Toggle Special Moves Packet.
	/// </summary>
	public class ToggleSpecialMoves : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Enable96 Enable961 { get; set; }
		public ToggleSpecialMoves() : base (0xBF)
		{
			Filler0 = 0x25;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte((Byte)Enable961);
		}
	}
	/// <summary>
	/// Movement Speed Mode Packet.
	/// </summary>
	public class MovementSpeedMode : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Mode97 Mode971 { get; set; }
		public MovementSpeedMode() : base (0xBF)
		{
			Filler0 = 0x26;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte((Byte)Mode971);
		}
	}
	/// <summary>
	/// Change Race Response Packet.
	/// </summary>
	public class ChangeRaceResponse : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Gender98 Gender981 { get; set; }
		public Race99 Race992 { get; set; }
		public ChangeRaceResponse() : base (0xBF)
		{
			Filler0 = 0x2A;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte((Byte)Gender981);
			InsertByte((Byte)Race992);
		}
	}
	/// <summary>
	/// Set Mobile Animation Packet.
	/// </summary>
	public class SetMobileAnimation : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Word Serial { get; set; }
		public Byte AnimationID { get; set; }
		public Byte FrameCount { get; set; }
		/* Serial is word, it's not a typo. OSI sends last two bytes of serial. */
		public SetMobileAnimation() : base (0xBF)
		{
			Filler0 = 0x2B;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord(Serial);
			InsertByte(AnimationID);
			InsertByte(FrameCount);
		}
	}
	/// <summary>
	/// UO3D Start Hotbar Slot Timer Packet.
	/// </summary>
	public class UO3DStartHotbarSlotTimer : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Word Filler1 { get; set; }
		public DWord ItemID { get; set; }
		public DWord Duration { get; set; }
		/* Start timer for hotbar slot with object having ItemID from packet. Timer will work for all slot with objects having ItemID from packet. 2.48.0.7 KR only bandages itemid works, ItemIDs are 0xE21 and 0xEE9. */
		public UO3DStartHotbarSlotTimer() : base (0xBF)
		{
			Filler0 = 0x31;
			Filler1 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertWord(Filler1);
			InsertDWord(ItemID);
			InsertDWord(Duration);
		}
	}
	/// <summary>
	/// Hued Effect Packet.
	/// </summary>
	public class HuedEffect : Packet
	{
		public Type102 Type1020 { get; set; }
		public DWord CharacterSerial { get; set; }
		public DWord TargetSerial { get; set; }
		public Word ObjectID { get; set; }
		public Word SourceX { get; set; }
		public Word SourceY { get; set; }
		public SByte SourceZ { get; set; }
		public Word DestinationX { get; set; }
		public Word DestinationY { get; set; }
		public SByte DestinationZ { get; set; }
		public Byte Speed { get; set; }
		public Byte Duration { get; set; }
		public Word Filler1 { get; set; }
		public FixedDirection103 FixedDirection1032 { get; set; }
		public Explode104 Explode1043 { get; set; }
		public DWord Hue { get; set; }
		public HuedEffect() : base (0xC0)
		{
			Data = new Byte [36];
			Filler1 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Type1020);
			InsertDWord(CharacterSerial);
			InsertDWord(TargetSerial);
			InsertWord(ObjectID);
			InsertWord(SourceX);
			InsertWord(SourceY);
			InsertSByte(SourceZ);
			InsertWord(DestinationX);
			InsertWord(DestinationY);
			InsertSByte(DestinationZ);
			InsertByte(Speed);
			InsertByte(Duration);
			InsertWord(Filler1);
			InsertByte((Byte)FixedDirection1032);
			InsertByte((Byte)Explode1043);
			InsertDWord(Hue);
		}
	}
	/// <summary>
	/// Localized Message Packet.
	/// </summary>
	public class LocalizedMessage : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Graphic { get; set; }
		public MessageType105 MessageType1050 { get; set; }
		public Word Hue { get; set; }
		public Word Font { get; set; }
		public DWord MessageNumber { get; set; }
		public Char[] Name { get; set; }
		public String Arguments { get; set; }
		public LocalizedMessage() : base (0xC1)
		{
			Name = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertWord(Graphic);
			InsertByte((Byte)MessageType1050);
			InsertWord(Hue);
			InsertWord(Font);
			InsertDWord(MessageNumber);
			InsertChar(Name);
			InsertString(Arguments);
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
	/// GQ Request Packet.
	/// </summary>
	public class GQRequest : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Filler0 { get; set; }
		public DWord ID { get; set; }
		public DWord CustomerID { get; set; }
		public DWord Serial { get; set; }
		public DWord Filler1 { get; set; }
		public Word Length { get; set; }
		public String ServerName { get; set; }
		public DWord CallTime { get; set; }
		public Map107 Map1072 { get; set; }
		public DWord X { get; set; }
		public DWord Y { get; set; }
		public DWord Z { get; set; }
		public DWord Volume { get; set; }
		public DWord Rank { get; set; }
		public DWord Filler3 { get; set; }
		public DWord Type { get; set; }
		public Byte Filler4 { get; set; }
		public Byte Filler5 { get; set; }
		public Char[] Language { get; set; }
		public String Text { get; set; }
		public GQRequest() : base (0xC3)
		{
			Filler0 = 0x01;
			Filler1 = 0x00;
			Filler3 = 0xFFFFFFFF;
			Filler4 = 0x01;
			Filler5 = 0x01;
			Language = new Char [3];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Filler0);
			InsertDWord(ID);
			InsertDWord(CustomerID);
			InsertDWord(Serial);
			InsertDWord(Filler1);
			InsertWord(Length);
			InsertString(ServerName);
			InsertDWord(CallTime);
			InsertDWord((DWord)Map1072);
			InsertDWord(X);
			InsertDWord(Y);
			InsertDWord(Z);
			InsertDWord(Volume);
			InsertDWord(Rank);
			InsertDWord(Filler3);
			InsertDWord(Type);
			InsertByte(Filler4);
			InsertByte(Filler5);
			InsertChar(Language);
			InsertString(Text);
		}
	}
	/// <summary>
	/// Semi Visible Packet.
	/// </summary>
	public class SemiVisible : Packet
	{
		public DWord Serial { get; set; }
		public Enable108 Enable1080 { get; set; }
		public SemiVisible() : base (0xC4)
		{
			Data = new Byte [6];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertByte((Byte)Enable1080);
		}
	}
	/// <summary>
	/// Invalid Map Enable Packet.
	/// </summary>
	public class InvalidMapEnable : Packet
	{
		public InvalidMapEnable() : base (0xC6)
		{
			Data = new Byte [1];
		}
		public void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Particle Effect Packet.
	/// </summary>
	public class ParticleEffectEnable : Packet
	{
		public Type109 Type1090 { get; set; }
		public DWord CharacterSerial { get; set; }
		public DWord TargetSerial { get; set; }
		public Word ObjectID { get; set; }
		public Word SourceX { get; set; }
		public Word SourceY { get; set; }
		public SByte SourceZ { get; set; }
		public Word DestinationX { get; set; }
		public Word DestinationY { get; set; }
		public SByte DestinationZ { get; set; }
		public Byte Speed { get; set; }
		public Byte Duration { get; set; }
		public Word Filler1 { get; set; }
		public FixedDirection110 FixedDirection1102 { get; set; }
		public Explode111 Explode1113 { get; set; }
		public DWord Hue { get; set; }
		public DWord RenderMode { get; set; }
		public Word EffectID { get; set; }
		public Word ExplodeEffectID { get; set; }
		public Word ExplodeSound { get; set; }
		public DWord Serial { get; set; }
		public Type112 Type1124 { get; set; }
		public Word Filler5 { get; set; }
		public ParticleEffectEnable() : base (0xC7)
		{
			Data = new Byte [49];
			Filler1 = 0x00;
			Filler5 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)Type1090);
			InsertDWord(CharacterSerial);
			InsertDWord(TargetSerial);
			InsertWord(ObjectID);
			InsertWord(SourceX);
			InsertWord(SourceY);
			InsertSByte(SourceZ);
			InsertWord(DestinationX);
			InsertWord(DestinationY);
			InsertSByte(DestinationZ);
			InsertByte(Speed);
			InsertByte(Duration);
			InsertWord(Filler1);
			InsertByte((Byte)FixedDirection1102);
			InsertByte((Byte)Explode1113);
			InsertDWord(Hue);
			InsertDWord(RenderMode);
			InsertWord(EffectID);
			InsertWord(ExplodeEffectID);
			InsertWord(ExplodeSound);
			InsertDWord(Serial);
			InsertByte((Byte)Type1124);
			InsertWord(Filler5);
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
	/// GQ Count Packet.
	/// </summary>
	public class GQCount : Packet
	{
		public Word Value { get; set; }
		public DWord Count { get; set; }
		public GQCount() : base (0xCB)
		{
			Data = new Byte [7];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(Value);
			InsertDWord(Count);
		}
	}
	/// <summary>
	/// Message Localized Affix Packet.
	/// </summary>
	public class MessageLocalizedAffix : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Serial { get; set; }
		public Word Graphic { get; set; }
		public MessageType113 MessageType1130 { get; set; }
		public Word Hue { get; set; }
		public Word Font { get; set; }
		public DWord MessageNumber { get; set; }
		public AffixType114 AffixType1141 { get; set; }
		public Char[] Name { get; set; }
		public String Affix { get; set; }
		public String Arguments { get; set; }
		public MessageLocalizedAffix() : base (0xCC)
		{
			Name = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Serial);
			InsertWord(Graphic);
			InsertByte((Byte)MessageType1130);
			InsertWord(Hue);
			InsertWord(Font);
			InsertDWord(MessageNumber);
			InsertByte((Byte)AffixType1141);
			InsertChar(Name);
			InsertString(Affix);
			InsertString(Arguments);
		}
	}
	/// <summary>
	/// Logout Response Packet.
	/// </summary>
	public class LogoutResponse : Packet
	{
		public LogOut115 LogOut1150 { get; set; }
		public LogoutResponse() : base (0xD1)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)LogOut1150);
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
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public Word Filler1 { get; set; }
		public DWord Hash { get; set; }
		Properties Properties2 { get; set; }
		public BatchQueryProperties() : base (0xD6)
		{
			Filler0 = 0x01;
			Filler1 = 0x00;
			Properties2 = new Properties();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Serial);
			InsertWord(Filler1);
			InsertDWord(Hash);
		}
	}
	/// <summary>
	/// Design State Detailed Packet.
	/// </summary>
	public class DesignStateDetailed : Packet
	{
		public Word PacketSize { get; set; }
		public CompressionType116 CompressionType1160 { get; set; }
		public EnableResponse117 EnableResponse1171 { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public DWord Revision { get; set; }
		public Word TilesLength { get; set; }
		public Word BufferLength { get; set; }
		public Byte PlanesCount { get; set; }
		Planes Planes2 { get; set; }
		Stairs Stairs3 { get; set; }
		/* Flags = (((Size right_shift 4) and 0xF0) | ((Length right_shift 8) and 0xF)) ) */
		public DesignStateDetailed() : base (0xD8)
		{
			Planes2 = new Planes();
			Stairs3 = new Stairs();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte((Byte)CompressionType1160);
			InsertByte((Byte)EnableResponse1171);
			InsertDWord(HouseFoundationSerial);
			InsertDWord(Revision);
			InsertWord(TilesLength);
			InsertWord(BufferLength);
			InsertByte(PlanesCount);
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
	/// Mahjong Players Info Packet.
	/// </summary>
	public class MahjongPlayersInfo : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Word PlayerSeatsCount { get; set; }
		PlayerSeats PlayerSeats1 { get; set; }
		public MahjongPlayersInfo() : base (0xDA)
		{
			Filler0 = 0x02;
			PlayerSeats1 = new PlayerSeats();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertWord(PlayerSeatsCount);
		}
	}
	/// <summary>
	/// Mahjong Game Tile Info Packet.
	/// </summary>
	public class MahjongGameTileInfo : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte TileNumber { get; set; }
		public Byte TileValue { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Byte StackLevel { get; set; }
		public Direction122 Direction1221 { get; set; }
		public Flipped123 Flipped1232 { get; set; }
		public MahjongGameTileInfo() : base (0xDA)
		{
			Filler0 = 0x03;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte(TileNumber);
			InsertByte(TileValue);
			InsertWord(X);
			InsertWord(Y);
			InsertByte(StackLevel);
			InsertByte((Byte)Direction1221);
			InsertByte((Byte)Flipped1232);
		}
	}
	/// <summary>
	/// Mahjong Game Tiles Info Packet.
	/// </summary>
	public class MahjongGameTilesInfo : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public Byte TilesLength { get; set; }
		Tiles Tiles1 { get; set; }
		public MahjongGameTilesInfo() : base (0xDA)
		{
			Filler0 = 0x04;
			Tiles1 = new Tiles();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertByte(TilesLength);
		}
	}
	/// <summary>
	/// Mahjong Game General Info Packet.
	/// </summary>
	public class MahjongGameGeneralInfo : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public DWord Options { get; set; }
		public Byte FirstDices { get; set; }
		public Byte SecondDices { get; set; }
		public DealerIndicatorWind126 DealerIndicatorWind1261 { get; set; }
		public Word DealerIndicatorY { get; set; }
		public Word DealerIndicatorX { get; set; }
		public DialerIndicatorDirection127 DialerIndicatorDirection1272 { get; set; }
		public Word WallBreakIndicatorY { get; set; }
		public Word WallBreakIndicatorX { get; set; }
		public MahjongGameGeneralInfo() : base (0xDA)
		{
			Filler0 = 0x05;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(GameSerial);
			InsertWord(Filler0);
			InsertDWord(Options);
			InsertByte(FirstDices);
			InsertByte(SecondDices);
			InsertByte((Byte)DealerIndicatorWind1261);
			InsertWord(DealerIndicatorY);
			InsertWord(DealerIndicatorX);
			InsertByte((Byte)DialerIndicatorDirection1272);
			InsertWord(WallBreakIndicatorY);
			InsertWord(WallBreakIndicatorX);
		}
	}
	/// <summary>
	/// Mahjong Join Game Packet.
	/// </summary>
	public class MahjongJoinGame : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongJoinGame() : base (0xDA)
		{
			Filler0 = 0x19;
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
	/// Mahjong Game Relieve Packet.
	/// </summary>
	public class MahjongGameRelieve : Packet
	{
		public Word PacketSize { get; set; }
		public DWord GameSerial { get; set; }
		public Word Filler0 { get; set; }
		public MahjongGameRelieve() : base (0xDA)
		{
			Filler0 = 0x1A;
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
	/// Character Transfer Log Packet.
	/// </summary>
	public class CharacterTransferLog : Packet
	{
		public Word PacketSize { get; set; }
		public DWord Filler0 { get; set; }
		public DWord PacketSize11 { get; set; }
		public DWord TransferID { get; set; }
		public DWord TransferDateTicks { get; set; }
		public DWord Filler1 { get; set; }
		Items Items2 { get; set; }
		ItemProperties ItemProperties3 { get; set; }
		public DWord Filler4 { get; set; }
		/* After receiving this packet, client will generate translog.txt in it's directory. */
		public CharacterTransferLog() : base (0xDB)
		{
			Filler0 = 0xBB;
			Filler1 = 0x00;
			Items2 = new Items();
			ItemProperties3 = new ItemProperties();
			Filler4 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(Filler0);
			InsertDWord(PacketSize11);
			InsertDWord(TransferID);
			InsertDWord(TransferDateTicks);
			InsertDWord(Filler1);
			InsertDWord(Filler4);
		}
	}
	/// <summary>
	/// OPL Info Packet.
	/// </summary>
	public class OPLInfo : Packet
	{
		public DWord Serial { get; set; }
		public DWord Hash { get; set; }
		/* Since 4.0.5a client, replaced BF.10 */
		public OPLInfo() : base (0xDC)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertDWord(Hash);
		}
	}
	/// <summary>
	/// Compressed Gump Packet.
	/// </summary>
	public class CompressedGump : Packet
	{
		public Word PacketSize { get; set; }
		public DWord SenderSerial { get; set; }
		public DWord GumpID { get; set; }
		public DWord X { get; set; }
		public DWord Y { get; set; }
		public DWord EntriesLength+4 { get; set; }
		public DWord LayoutLength { get; set; }
		public List<Byte> CompressedEntries { get; set; }
		public DWord LinesCount { get; set; }
		public DWord StringsLength+4 { get; set; }
		public DWord UncompressedStringsLength { get; set; }
		public List<Byte> CompressedStrings { get; set; }
		/* Since 5.0.0a client. Use ZLib compression with Z_BEST_SPEED compression level. */
		/* Gump ID is special type id. See link below for more information. */
		public CompressedGump() : base (0xDD)
		{
			CompressedEntries = new List<Byte>();
			CompressedStrings = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(SenderSerial);
			InsertDWord(GumpID);
			InsertDWord(X);
			InsertDWord(Y);
			InsertDWord(EntriesLength+4);
			InsertDWord(LayoutLength);
			InsertByte(CompressedEntries);
			InsertDWord(LinesCount);
			InsertDWord(StringsLength+4);
			InsertDWord(UncompressedStringsLength);
			InsertByte(CompressedStrings);
		}
	}
	/// <summary>
	/// Update Character Combatants Packet.
	/// </summary>
	public class UpdateCharacterCombatants : Packet
	{
		public Word PacketSize { get; set; }
		public DWord CharacterSerial { get; set; }
		public Byte CharacterCombatantsCount { get; set; }
		CharacterCombatants CharacterCombatants0 { get; set; }
		public UpdateCharacterCombatants() : base (0xDE)
		{
			CharacterCombatants0 = new CharacterCombatants();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(CharacterSerial);
			InsertByte(CharacterCombatantsCount);
		}
	}
	/// <summary>
	/// Buffs And Attributes Packet.
	/// </summary>
	public class BuffsAndAttributes : Packet
	{
		public Word PacketSize { get; set; }
		public DWord PlayerSerial { get; set; }
		public BuffType134 BuffType1340 { get; set; }
		public Word BuffsCount { get; set; }
		Buffs Buffs1 { get; set; }
		public BuffsAndAttributes() : base (0xDF)
		{
			Buffs1 = new Buffs();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(PlayerSerial);
			InsertWord((Word)BuffType1340);
			InsertWord(BuffsCount);
		}
	}
	/// <summary>
	/// New Mobile Animation Packet.
	/// </summary>
	public class NewMobileAnimation : Packet
	{
		public DWord MobileSerial { get; set; }
		public Word AnimationType { get; set; }
		public Word Action { get; set; }
		public Byte Delay { get; set; }
		/* Replaces 0x6E packet. Since 7.0.0.0 in 2D, was in UO:KR clients, now in UO:SA clients. Action is optional parameter for some types: attack, emote, spell. */
		public NewMobileAnimation() : base (0xE2)
		{
			Data = new Byte [10];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(MobileSerial);
			InsertWord(AnimationType);
			InsertWord(Action);
			InsertByte(Delay);
		}
	}
	/// <summary>
	/// KR Encryption Request Packet.
	/// </summary>
	public class KREncryptionRequest : Packet
	{
		public Word PacketSize { get; set; }
		public DWord BaseLength { get; set; }
		public List<Byte> Base { get; set; }
		public DWord PrimeLength { get; set; }
		public List<Byte> Prime { get; set; }
		public DWord PublicKeyLength { get; set; }
		public List<Byte> PublicKey { get; set; }
		public DWord Filler0 { get; set; }
		public DWord IVLength { get; set; }
		public List<Byte> IV { get; set; }
		public KREncryptionRequest() : base (0xE3)
		{
			Base = new List<Byte>();
			Prime = new List<Byte>();
			PublicKey = new List<Byte>();
			Filler0 = 0x20;
			IV = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(BaseLength);
			InsertByte(Base);
			InsertDWord(PrimeLength);
			InsertByte(Prime);
			InsertDWord(PublicKeyLength);
			InsertByte(PublicKey);
			InsertDWord(Filler0);
			InsertDWord(IVLength);
			InsertByte(IV);
		}
	}
	/// <summary>
	/// UO3D Display Waypoint Packet.
	/// </summary>
	public class UO3DDisplayWaypoint : Packet
	{
		public Word PacketSize { get; set; }
		public DWord ObjectSerial { get; set; }
		public Word ObjectX { get; set; }
		public Word ObjectY { get; set; }
		public SByte ObjectZ { get; set; }
		public Byte ObjectMapID { get; set; }
		public ObjectType137 ObjectType1370 { get; set; }
		public IngoreObjectSerial138 IngoreObjectSerial1381 { get; set; }
		public DWord ObjectClilocDescription { get; set; }
		public String ObjectClilocDescriptionArguments { get; set; }
		public Word Filler2 { get; set; }
		/* If Ignore Object Serial is true, client will use coordinates from packet and will ignore serial object coordinates. */
		public UO3DDisplayWaypoint() : base (0xE5)
		{
			Filler2 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(ObjectSerial);
			InsertWord(ObjectX);
			InsertWord(ObjectY);
			InsertSByte(ObjectZ);
			InsertByte(ObjectMapID);
			InsertWord((Word)ObjectType1370);
			InsertByte((Byte)IngoreObjectSerial1381);
			InsertDWord(ObjectClilocDescription);
			InsertString(ObjectClilocDescriptionArguments);
			InsertWord(Filler2);
		}
	}
	/// <summary>
	/// UO3D Hide Waypoint Packet.
	/// </summary>
	public class UO3DHideWaypoint : Packet
	{
		public DWord ObjectSerial { get; set; }
		public UO3DHideWaypoint() : base (0xE6)
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
	/// UO3D Continue Highlight UI-Element Packet.
	/// </summary>
	public class UO3DContinueHighlightUIElement : Packet
	{
		public DWord MobileSerial { get; set; }
		public Word UIElementID { get; set; }
		public DWord DestinationObjectSerial { get; set; }
		public Byte Filler0 { get; set; }
		public UO3DContinueHighlightUIElement() : base (0xE7)
		{
			Data = new Byte [12];
			Filler0 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(MobileSerial);
			InsertWord(UIElementID);
			InsertDWord(DestinationObjectSerial);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// UO3D Toggle Highlight UI-Element Packet.
	/// </summary>
	public class UO3DToggleHighlightUIElement : Packet
	{
		public Word UIElementID { get; set; }
		public DWord MobileSerial { get; set; }
		public Char[] Description { get; set; }
		public DWord CommandID { get; set; }
		/* Description types: ”ToggleInventory”, ”TogglePaperdoll”, ”ToggleMap”, ”” */
		public UO3DToggleHighlightUIElement() : base (0xE9)
		{
			Data = new Byte [75];
			Description = new Char [64];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(UIElementID);
			InsertDWord(MobileSerial);
			InsertChar(Description);
			InsertDWord(CommandID);
		}
	}
	/// <summary>
	/// UO3D Enable Hotbar Packet.
	/// </summary>
	public class UO3DEnableHotbar : Packet
	{
		public Enable139 Enable1390 { get; set; }
		public UO3DEnableHotbar() : base (0xEA)
		{
			Data = new Byte [3];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord((Word)Enable1390);
		}
	}
	/// <summary>
	/// Client-Server Time Synchronization Response Packet.
	/// </summary>
	public class ClientServerTimeSynchronizationResponse : Packet
	{
		public QWord DateTime1 { get; set; }
		public QWord DateTime2 { get; set; }
		public QWord DateTime3 { get; set; }
		/* DateTime1, DateTime2 and DateTime3 - ticks from Unix time divided by 10000. Server sends this packet after client's request (0xF1). Can be enabled with 0x4000 flag in 0xA9 packet. */
		public ClientServerTimeSynchronizationResponse() : base (0xF2)
		{
			Data = new Byte [25];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertQWord(DateTime1);
			InsertQWord(DateTime2);
			InsertQWord(DateTime3);
		}
	}
	/// <summary>
	/// New World Object Packet.
	/// </summary>
	public class NewWorldObjectPacket : Packet
	{
		public Word Filler0 { get; set; }
		public DataType142 DataType1421 { get; set; }
		public DWord Serial { get; set; }
		public Word ObjectID { get; set; }
		public Byte ObjectIDOffset { get; set; }
		public Word Amount { get; set; }
		public Word Amount { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public SByte Z { get; set; }
		public Byte LightLevel { get; set; }
		public Word Hue { get; set; }
		public Flag143 Flag1432 { get; set; }
		public Access144 Access1443 { get; set; }
		/* First appearance in UO:SA clients, replaces 0x1A packet. */
		public NewWorldObjectPacket() : base (0xF3)
		{
			Data = new Byte [26];
			Filler0 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(Filler0);
			InsertByte((Byte)DataType1421);
			InsertDWord(Serial);
			InsertWord(ObjectID);
			InsertByte(ObjectIDOffset);
			InsertWord(Amount);
			InsertWord(Amount);
			InsertWord(X);
			InsertWord(Y);
			InsertSByte(Z);
			InsertByte(LightLevel);
			InsertWord(Hue);
			InsertByte((Byte)Flag1432);
			InsertWord((Word)Access1443);
		}
	}
	/// <summary>
	/// New Map Details Packet.
	/// </summary>
	public class NewMapDetailsPacket : Packet
	{
		public DWord Serial { get; set; }
		public Word CornerImage { get; set; }
		public Word X1 { get; set; }
		public Word Y1 { get; set; }
		public Word X2 { get; set; }
		public Word Y2 { get; set; }
		public Word Width { get; set; }
		public Word Height { get; set; }
		public Word Map { get; set; }
		public NewMapDetailsPacket() : base (0xF5)
		{
			Data = new Byte [21];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(CornerImage);
			InsertWord(X1);
			InsertWord(Y1);
			InsertWord(X2);
			InsertWord(Y2);
			InsertWord(Width);
			InsertWord(Height);
			InsertWord(Map);
		}
	}
	/// <summary>
	/// Boat Moving Packet.
	/// </summary>
	public class BoatMovingPacket : Packet
	{
		public Word PacketSize { get; set; }
		public DWord BoatSerial { get; set; }
		public BoatSpeed145 BoatSpeed1450 { get; set; }
		public Byte MovingDirection { get; set; }
		public Byte FacingDirection { get; set; }
		public Word BoatX { get; set; }
		public Word BoatY { get; set; }
		public Word BoatZ { get; set; }
		public Word BoatObjectsCount { get; set; }
		BoatObjects BoatObjects1 { get; set; }
		/* Was added in UO:HS clients. Moving Direction = Facing Direction + Command Direction. */
		public BoatMovingPacket() : base (0xF6)
		{
			BoatObjects1 = new BoatObjects();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(BoatSerial);
			InsertByte((Byte)BoatSpeed1450);
			InsertByte(MovingDirection);
			InsertByte(FacingDirection);
			InsertWord(BoatX);
			InsertWord(BoatY);
			InsertWord(BoatZ);
			InsertWord(BoatObjectsCount);
		}
	}
	/// <summary>
	/// Packet Container Packet.
	/// </summary>
	public class PacketContainerPacket : Packet
	{
		public Word PacketSize { get; set; }
		public Word InnerPacketsCount { get; set; }
		InnerPackets InnerPackets0 { get; set; }
		/* Was added in UO:HS clients. Currently uses for multis, contains F3 packets. */
		public PacketContainerPacket() : base (0xF7)
		{
			InnerPackets0 = new InnerPackets();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(InnerPacketsCount);
		}
	}
}
