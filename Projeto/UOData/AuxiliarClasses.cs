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
namespace UOData
{
	public enum ClientFlags0 : int { FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100 };
	public enum GenderandRace1 : byte { humanmale = 0x00, humanfemale = 0x01, humanmale2 = 0x02, humanfemale2 = 0x03, elfmale = 0x04, elffemale = 0x05, gargoylemale = 0x06, gargoylefemale = 0x07 };
	public enum Direction2 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum Mode3 : byte { say = 0x00, system = 0x01, emote = 0x02, label = 0x06, focus = 0x07, whipser = 0x08, yell = 0x09, spell = 0x10, guild = 0x13, alliance = 0x14, GM = 0x15, encodedcommands = 0xC0 };
	public enum OnOff4 : byte { off = 0x00, on = 0x01 };
	public enum AllowNameChange5 : byte { yes = 0x01, no = 0x00 };
	public enum SupportedFeatures6 : byte { T2Aattributes = 0x02, Renaissanceattributes = 0x03, AOSattributes = 0x04, MLattributes = 0x05, KRattributes = 0x06 };
	public enum Race7 : byte { Human = 0x01, Elf = 0x02, Gargoyle = 0x03, };
	public enum ItemLayer8 : byte { Invalid = 0x00, OneHanded = 0x01, ThoHanded = 0x02, Shoes = 0x03, Pants = 0x04, Shirt = 0x05, Helm = 0x06, Gloves = 0x07, Ring = 0x08, Talisman = 0x09, Neck = 0x0A, Hair = 0x0B, Waist = 0x0C, InnerTorso = 0x0D, Bracelet = 0x0E, Face = 0x0F, FacialHair = 0x10, MiddleTorso = 0x11, Earrings = 0x12, Arms = 0x13, Cloak = 0x14, Backpack = 0x15, OuterTorso = 0x16, OuterLegs = 0x17, InnerLegs = 0x18, Mount = 0x19, ShopBuy = 0x1A, ShopResale = 0x1B, ShopSell = 0x1C, Bank = 0x1D, ShopMax = 0x1E };
	public enum StatusColor9 : short { Green = 0x01, Yellow = 0x02, Red = 0x03 };
	public enum Flag10 : byte { RemoveStatusColor = 0x00, EnableStatusColor = 0x01 };
	public enum Direction11 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum Flags12 : byte { ShowProperties = 0x20, Hidden = 0x80 };
	public enum Direction13 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum MessageType14 : byte { Regular = 0x00, System = 0x01, Emote = 0x02, Label = 0x06, Focus = 0x07, Whisper = 0x08, Yell = 0x09, Spell = 0x0A, Guild = 0x0D, Alliance = 0x0E, GMRequest = 0x0F, GMResponse = 0x10, Special = 0x20, Encoded = 0xC0 };
	public enum Flags15 : byte { Female = 0x02, Flying = 0x04, YellowHealthBar = 0x08, WarMode = 0x40, Hidden = 0x80 };
	public enum Direction16 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum Direction17 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum Reason18 : byte { CannotLift = 0x00, OutOfRange = 0x01, OutOfSight = 0x02, TryToSteel = 0x03, AreHolding = 0x04, Inspecific = 0x05 };
	public enum Status19 : byte { Dead = 0x00, Alive = 0x02 };
	public enum Layer20 : byte { Invalid = 0x00, OneHanded = 0x01, ThoHanded = 0x02, Shoes = 0x03, Pants = 0x04, Shirt = 0x05, Helm = 0x06, Gloves = 0x07, Ring = 0x08, Talisman = 0x09, Neck = 0x0A, Hair = 0x0B, Waist = 0x0C, InnerTorso = 0x0D, Bracelet = 0x0E, Face = 0x0F, FacialHair = 0x10, MiddleTorso = 0x11, Earrings = 0x12, Arms = 0x13, Cloak = 0x14, Backpack = 0x15, OuterTorso = 0x16, OuterLegs = 0x17, InnerLegs = 0x18, Mount = 0x19, ShopBuy = 0x1A, ShopResale = 0x1B, ShopSell = 0x1C, Bank = 0x1D, ShopMax = 0x1E };
	public enum Type21 : byte { GodClientCommand = 0x00, StatsRequest = 0x04, SkillsRequest = 0x05 };
	public enum ListType22 : byte { capped = 0x02, delta = 0xDF, noloop = 0xFF };
	public enum Flag23 : byte { noitems = 0x00, itemslist = 0x02 };
	public enum LightLevel24 : byte { Bright = 0x00, Night = 0x09, Black = 0x1F };
	public enum Message25 : byte { badpassshort = 0x00, nocharacter = 0x01, characterexists = 0x02, characteralreadyinworld = 0x05, loginproblem = 0x06, idle = 0x07, charactertransfer = 0x09, invalidname = 0x10 };
	public enum Action26 : byte { addpin = 0x01, insertpin = 0x02, changepin = 0x03, removepin = 0x04, clearmap = 0x05, toggleeditmap = 0x06 };
	public enum ClientFlags27 : int { FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100 };
	public enum WeatherType28 : byte { rain = 0x00, fiercestorm = 0x01, snow = 0x02, storm = 0x03, settemperature = 0xFE, stopallweather = 0xFF };
	public enum TargetType29 : byte { ObjectTarget = 0x00, TileTarget = 0x01 };
	public enum Flags30 : byte { None = 0x00, Harmful = 0x01, Beneficial = 0x02 };
	public enum X31 : short { canceltarget = 0xFFF };
	public enum Y32 : short { canceltarget = 0xFFF };
	public enum Graphic33 : short { LandTarget = 0x00 };
	public enum Forward34 : byte { forward = 0x00, backward = 0x01 };
	public enum Repeat35 : byte { norepeat = 0x00, repeat = 0x01 };
	public enum Delay36 : byte { fast = 0x00, slow = 0xFF };
	public enum Action37 : byte { start = 0x00, cancel = 0x01, update = 0x02 };
	public enum FirstContainerSerial38 : int { ifAction = 0x00 };
	public enum SecondContainerSerial39 : int { ifAction = 0x00 };
	public enum DisplayName40 : byte { No = 0x00, Yes = 0x01 };
	public enum Type41 : byte { fromsourcetodestination = 0x00, lightningstrike = 0x01, staywithdestination = 0x02, staywithsource = 0x03 };
	public enum FixedDirection42 : byte { No = 0x00, Yes = 0x01 };
	public enum Explode43 : byte { No = 0x00, Yes = 0x01 };
	public enum ContainerSerial44 : int { toplevel = 0x00 };
	public enum ReplyMessageSerial45 : int { nomessage = 0x00 };
	public enum Direction46 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum Flags47 : byte { Female = 0x02, Flying = 0x04, YellowHealthBar = 0x08, WarMode = 0x40, Hidden = 0x80 };
	public enum Notoriety48 : byte { Innocent = 0x01, Ally = 0x02, Canbeattacked = 0x03, Criminal = 0x04, Enemy = 0x05, Murderer = 0x06, Invulnerable = 0x07 };
	public enum Direction49 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum Flags50 : byte { Female = 0x02, Flying = 0x04, YellowHealthBar = 0x08, WarMode = 0x40, Hidden = 0x80 };
	public enum Notoriety51 : byte { Innocent = 0x01, Ally = 0x02, Canbeattacked = 0x03, Criminal = 0x04, Enemy = 0x05, Murderer = 0x06, Invulnerable = 0x07 };
	public enum ToggleGodViewQuery52 : byte { Off = 0x00, On = 0x01 };
	public enum RejectionReason53 : byte { Invalid = 0x00, AccountInUse = 0x01, AccountBlocked = 0x02, WrongPassshort = 0x03, IGR = 0x06, CharacterTransfer = 0x09, TimeOut = 0xFE, BadCommunication = 0xFF };
	public enum DeleteResult54 : byte { BadPassshort = 0x00, CharacterNotExists = 0x01, CharacterInGame = 0x02, CharacterTooYoung = 0x03, CharacterQueeed = 0x04, BadRequest = 0x05 };
	public enum Flags55 : byte { WarMode = 0x01, CanLift = 0x02 };
	public enum ClientFlags56 : byte { FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0xFF };
	public enum Gender57 : byte { male = 0x00, female = 0x01 };
	public enum Race58 : byte { human = 0x01, elf = 0x02, gargoyle = 0x03 };
	public enum Editable59 : byte { No = 0x00, Yes = 0x01 };
	public enum Direction60 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum TargetType61 : byte { ObjectTarget = 0x00, TileTarget = 0x01 };
	public enum Flags62 : byte { None = 0x00, Harmful = 0x01, Beneficial = 0x02 };
	public enum Type63 : int { Cancel = 0x00, Response = 0x01 };
	public enum Flags64 : int { unknownflag1 = 0x01, overwriteconfigurationbutton = 0x02, limit1characterperaccount = 0x04, enablecontextmenus = 0x08, limitcharacterslots = 0x10, paladinandnecromancerclasses = 0x20, sixthcharacterslot = 0x40, samuraiandninjaclasses = 0x80, elvenrace = 0x100, unknownflag2 = 0x200, sendUO3Dclienttype = 0x400, clientwillsend0xE1packet = 0x800, unknownflag3 = 0x1000, seventhcharacterslot = 0x2000, };
	public enum Style65 : byte { none = 0x00, normal = 0x01, numerical = 0x02 };
	public enum Mode66 : byte { cancel = 0x00, ok = 0x01 };
	public enum Mode67 : byte { say = 0x00, system = 0x01, emote = 0x02, label = 0x06, focus = 0x07, whipser = 0x08, yell = 0x09, spell = 0x10, guild = 0x13, alliance = 0x14, GM = 0x15, encodedcommands = 0xC0 };
	public enum Mode68 : byte { say = 0x00, system = 0x01, emote = 0x02, label = 0x06, focus = 0x07, whipser = 0x08, yell = 0x09, spell = 0x10, guild = 0x13, alliance = 0x14, GM = 0x15, encodedcommands = 0xC0 };
	public enum SwitchesCount69 : int { OnlyifGumpID = 0x1CD };
	public enum Action70 : short { ChangeChannelPassshort = 0x41, UO3DKick = 0x42, UO3DLeaveChannel = 0x43, UO3DJoinChannel = 0x44, UO3DJoinNewChannel = 0x45, UO3DAddFriend = 0x46, UO3DRemoveFriend = 0x47, UO3DListChannelPlayers = 0x49, LeaveChat = 0x58, ChannelMessage = 0x61, JoinChannel = 0x62, JoinNewChannel = 0x63, RenameChannel = 0x64, PrivateMessage = 0x65, AddIgnore = 0x66, RemoveIgnore = 0x67, ToggleIgnore = 0x68, AddVoice = 0x69, RemoveVoice = 0x6A, ToggleVoice = 0x6B, AddModerator = 0x6C, RemoveModerator = 0x6D, ToggleModerator = 0x6E, AllowPrivateMessages = 0x6F, DisallowPrivateMessages = 0x70, TogglePrivateMessages = 0x71, ShowCharacterName = 0x72, HideCharacterName = 0x73, ToggleCharacterName = 0x74, QueryWhois = 0x75, Kick = 0x76, EnableDefaultVoice = 0x77, DisableDefaultVoice = 0x78, ToggleDefaultVoice = 0x79, EmoteMessage = 0x7A };
	public enum Mode71 : byte { display = 0x00, edit = 0x01 };
	public enum Unknown72 : short { ifMode = 0x01 };
	public enum Flags73 : short { enableT2Afeatureschatbuttonregions = 0x01, enablerenaissancefeatures = 0x02, enablethirddownfeatures = 0x04, enableLBRfeaturesskillsmap = 0x08, enableAOSfeaturesskillsspellsmapfightbook = 0x10, enable6thcharacterslot = 0x20, enableSEfeaturesspellsskillsmap = 0x40, enableMLfeatureselvenracespellsskills = 0x80, enableTheEightAgesplashscreen = 0x100, enableTheNinthAgesplashscreen = 0x200, enableTheTenthAge = 0x400, enableincreasedhousingandbankstorage = 0x800, enable7thcharacterslot = 0x1000, enableroleplayfaces = 0x2000, trialaccount = 0x4000 };
	public enum Active74 : byte { no = 0x00, yes = 0x01 };
	public enum Season75 : byte { spring = 0x00, summer = 0x01, fall = 0x02, winter = 0x03, desolation = 0x04 };
	public enum PlayMusic76 : byte { no = 0x00, yes = 0x01 };
	public enum CanLoot77 : byte { no = 0x00, yes = 0x01 };
	public enum RightClick78 : byte { yes = 0x01, no = 0x00 };
	public enum ClientFlags79 : int { FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100 };
	public enum ContextMenuEntryFlags80 : short { Enabled = 0x00, Disabled = 0x01, Highlighted = 0x04, Colored = 0x20 };
	public enum ContextMenuEntryHue81 : short { IfFlags = 0x20, };
	public enum Command82 : int { PaperdollWindow = 0x01, StatusWindow = 0x02, ProfileWindow = 0x08, ContainerWindow = 0x0C };
	public enum ObjectSerial83 : int { containerserial = 0x0C, mobileserial = 0x00 };
	public enum Display84 : byte { no = 0x00, yes = 0x01 };
	public enum Dead85 : byte { no = 0x00, yes = 0x01 };
	public enum Dead86 : byte { no = 0x00, yes = 0x01 };
	public enum StatType87 : byte { Str = 0x00, Dex = 0x01, Int = 0x02 };
	public enum LockValue88 : byte { Up = 0x00, Down = 0x01, Locked = 0x02 };
	public enum Type89 : short { nospellbook = 0x00, hasspell = 0x01, hasspellbook = 0x02, };
	public enum SpellbookSerial90 : int { onlyifType = 0x01 };
	public enum Enable91 : byte { no = 0x00, yes = 0x01 };
	public enum Mode92 : byte { Normal = 0x00, Fast = 0x01, Slow = 0x02, Hybrid = 0x03 };
	public enum Gender93 : byte { male = 0x00, female = 0x01 };
	public enum Race94 : byte { human = 0x01, elf = 0x02, gargoyle = 0x03, invalid = 0xFF };
	public enum Command95 : short { ddefault = 0x63, changepublic_private = 0x65, convertintocustomizable = 0x66, relocationmovingcrate = 0x68, changesignhouse = 0x69, changesignhanger = 0x6A, changesignpost = 0x6B, changefoundationstyle = 0x6C, renamehouse = 0x6D, demolishhouse = 0x6E, tradehouse = 0x6F, makeprimary = 0x70, changetocoowner = 0x71, changetofriend = 0x72, changetoaccess = 0x73, ban = 0x74, removecoowner = 0x75, removefriend = 0x76, removeaccess = 0x77, removeban = 0x78, clearcoownerslist = 0x79, clearfriendslist = 0x7A, clearaccesslist = 0x7B, clearbanslist = 0x7C, addaccess = 0x7D, validaddaccess = 0x7E, invalidaddaccess = 0x7F, customizehouse = 0x80 };
	public enum ResourceType96 : short { ore = 0x00, sand = 0x01, wood = 0x02, graves = 0x03, redmushrooms = 0x04 };
	public enum Type97 : byte { fromsourcetodestination = 0x00, lightningstrike = 0x01, staywithdestination = 0x02, staywithsource = 0x03 };
	public enum FixedDirection98 : byte { No = 0x00, Yes = 0x01 };
	public enum Explode99 : byte { No = 0x00, Yes = 0x01 };
	public enum MessageType100 : byte { Regular = 0x00, System = 0x01, Emote = 0x02, Label = 0x06, Focus = 0x07, Whisper = 0x08, Yell = 0x09, Spell = 0x0A, Guild = 0x0D, Alliance = 0x0E, GMRequest = 0x0F, GMResponse = 0x10, Special = 0x20, Encoded = 0xC0 };
	public enum Type101 : int { Cancel = 0x00, Response = 0x01 };
	public enum Map102 : int { felucca = 0x00, trammel = 0x01, ilshenar = 0x02, malas = 0x03, tokuno = 0x04, termur = 0x05 };
	public enum Enable103 : byte { no = 0x00, yes = 0x01 };
	public enum Type104 : byte { fromsourcetodestination = 0x00, lightningstrike = 0x01, staywithdestination = 0x02, staywithsource = 0x03 };
	public enum FixedDirection105 : byte { No = 0x00, Yes = 0x01 };
	public enum Explode106 : byte { No = 0x00, Yes = 0x01 };
	public enum Type107 : byte { Filler4 = 0xFF, Filler5 = 0x03 };
	public enum MessageType108 : byte { Regular = 0x00, System = 0x01, Emote = 0x02, Label = 0x06, Focus = 0x07, Whisper = 0x08, Yell = 0x09, Spell = 0x0A, Guild = 0x0D, Alliance = 0x0E, GMRequest = 0x0F, GMResponse = 0x10, Special = 0x20, Encoded = 0xC0 };
	public enum AffixType109 : byte { Append = 0x00, Prepend = 0x01, System = 0x02 };
	public enum LogOut110 : byte { yes = 0x01, no = 0x00 };
	public enum CompressionType111 : byte { atpresenttime = 0x03 };
	public enum EnableResponse112 : byte { yes = 0x01, no = 0x00 };
	public enum ClientType113 : byte { clientversionbefore401a = 0x01, clientversionaboveorequal401a = 0x02 };
	public enum DealerPosition114 : byte { yes = 0x01, no = 0x02 };
	public enum Public115 : int { yes = 0x01, no = 0x00 };
	public enum PlayerInGame116 : byte { no = 0x01, yes = 0x00 };
	public enum Direction117 : byte { Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03 };
	public enum Flipped118 : byte { yes = 0x10, no = 0x00 };
	public enum Direction119 : byte { Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03 };
	public enum Flipped120 : byte { yes = 0x10, no = 0x00 };
	public enum DealerIndicatorWind121 : byte { North = 0x00, East = 0x01, South = 0x02, West = 0x03 };
	public enum DialerIndicatorDirection122 : byte { Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03 };
	public enum Options123 : int { ShowScores = 0x01, SpectatorVision = 0x02 };
	public enum PublicHand124 : int { yes = 0x01, no = 0x00 };
	public enum CurrentDirection125 : byte { Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03 };
	public enum NewDirection126 : byte { Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03 };
	public enum Direction127 : byte { Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03 };
	public enum Wind128 : byte { North = 0x00, East = 0x01, South = 0x02, West = 0x03 };
	public enum BugCategory129 : short { WorldEnvironment = 0x01, Wearables = 0x02, Combat = 0x03, UI = 0x04, Crash = 0x05, Stuck = 0x06, Animations = 0x07, Performance = 0x08, NPCs = 0x09, Creatures = 0x0A, Pets = 0x0B, Housing = 0x0C, LostItem = 0x0D, Exploit = 0x0E, Other = 0x0F };
	public enum ClientType130 : int { KR = 0x02, SA = 0x03 };
	public enum ObjectType131 : short { None = 0x00, Corpse = 0x01, Party = 0x02, Quest = 0x04, QuestDestination = 0x05, Resurrection = 0x06 };
	public enum IngoreObjectSerial132 : byte { yes = 0x01, no = 0x00 };
	public enum Enable133 : short { yes = 0x01, no = 0x00 };
	public enum Type134 : byte { spell = 0x1, weaponability = 0x2, skill = 0x3, item = 0x4, scroll = 0x5 };
	public enum DataType135 : byte { useTileData = 0x00, useMultiData = 0x02 };
	public enum ItemDirection136 : byte { North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80 };
	public enum Flag137 : byte { ShowProperties = 0x20, Hidden = 0x80 };

    public enum SkillName : short
    {
        Alchemy = 0,
        Anatomy = 1,
        AnimalLore = 2,
        ItemID = 3,
        ArmsLore = 4,
        Parry = 5,
        Begging = 6,
        Blacksmith = 7,
        Fletching = 8,
        Peacemaking = 9,
        Camping = 10,
        Carpentry = 11,
        Cartography = 12,
        Cooking = 13,
        DetectHidden = 14,
        Discordance = 15,
        EvalInt = 16,
        Healing = 17,
        Fishing = 18,
        Forensics = 19,
        Herding = 20,
        Hiding = 21,
        Provocation = 22,
        Inscribe = 23,
        Lockpicking = 24,
        Magery = 25,
        MagicResist = 26,
        Tactics = 27,
        Snooping = 28,
        Musicianship = 29,
        Poisoning = 30,
        Archery = 31,
        SpiritSpeak = 32,
        Stealing = 33,
        Tailoring = 34,
        AnimalTaming = 35,
        TasteID = 36,
        Tinkering = 37,
        Tracking = 38,
        Veterinary = 39,
        Swords = 40,
        Macing = 41,
        Fencing = 42,
        Wrestling = 43,
        Lumberjacking = 44,
        Mining = 45,
        Meditation = 46,
        Stealth = 47,
        RemoveTrap = 48,
        Necromancy = 49,
        Focus = 50,
        Chivalry = 51,
        Bushido = 52,
        Ninjitsu = 53,
        Spellweaving = 54
    }

	public class Pets
	{
		public DWord PetSerial { get; set; }
		public Byte Filler0 { get; set; }
		public Pets()
		{
			Filler0 = 0x01;
		}
	}
	

	public class Skill
	{
        public SkillName SkillID { get; set; }
        public Word SkillValue { get; set; }
        public Word SkillBaseValue { get; set; }
        public Byte LockStatus { get; set; }
        public Word SkillCappedValue { get; set; }
		public Skill()
		{
		}
	}
	
	public class Item
	{
		public UWord ItemID { get; set; }
		public ItemLayer8 ItemLayer { get; set; }
		public DWord ItemSerial { get; set; }
		public Word ItemAmount { get; set; }
		public UWord ItemHue { get; set; }

		public Item()
		{
		}
	}
	
	public class StaticTiles
	{
		public Word TileID { get; set; }
		public Byte TileX { get; set; }
		public Byte TileY { get; set; }
		public SByte TileZ { get; set; }
		public Word TileHue { get; set; }
		public StaticTiles()
		{
		}
	}
	
	public class LandTiles
	{
		public Word TileID { get; set; }
		public SByte TileZ { get; set; }
		public LandTiles()
		{
		}
	}
	
	public class Pages
	{
		public Word PageIndex { get; set; }
		public Word LinesCount { get; set; }
        public List<Lines> Lines {get; set; }
		public Pages()
		{
		}
	}

    public class Lines
    {
        public String Text { get; set; }
        public Lines()
        {

        }
    }
	
	public class Messages
	{
		public Word MessageBody { get; set; }
		public Word MessageHue { get; set; }
		public Messages()
		{
		}
	}
	
	public class Line
	{
		public Byte LineLength { get; set; }
		public String LineText { get; set; }
		public Line()
		{
		}
	}
	
	public class Characters
	{
		public Char[] CharacterName { get; set; }
		public Char[] Password { get; set; }
		public Characters()
		{
			CharacterName = new Char [30];
			Password = new Char [30];
		}
	}
	
	public class Servers
	{
		public Word ServerIndex { get; set; }
		public Char[] ServerName { get; set; }
		public Byte ServerPercentFull { get; set; }
		public SByte ServerTimeZone { get; set; }
		public DWord ServerIP { get; set; }
		public Servers()
		{
			ServerName = new Char [32];
		}
	}
	
	public class Cities
	{
		public Byte CityIndex { get; set; }
		public Char[] CityName { get; set; }
		public Char[] BuildingName { get; set; }
		public Cities()
		{
			CityName = new Char [31];
			BuildingName = new Char [31];
		}
	}
	
	public class Switches
	{
		public DWord SwitchID { get; set; }
		public Switches()
		{
		}
	}
	
	public class TextEntries
	{
		public Word TextEntryID { get; set; }
		public Word TextEntryLength { get; set; }
		public String TextEntryText { get; set; }
		public TextEntries()
		{
		}
	}
	
	public class Members
	{
		public DWord MemberSerial { get; set; }
		public Members()
		{
		}
	}
	
	public class Attribute
	{
		public DWord Number { get; set; }
		public Word Charges { get; set; }
		public Attribute()
		{
		}
	}
	
	public class ContextMenuEntries
	{
		public Word ContextMenuEntryIndex { get; set; }
		public Word ContextMenuEntryNumber { get; set; }
		public ContextMenuEntryFlags80 ContextMenuEntryFlags800 { get; set; }
		public ContextMenuEntryHue81 ContextMenuEntryHue811 { get; set; }
		public ContextMenuEntries()
		{
		}
	}
	
	public class Maps
	{
		public DWord NumberOfMapPatches { get; set; }
		public DWord NumberOfStaticPatches { get; set; }
		public Maps()
		{
		}
	}
	
	public class UOProperties
	{
		public DWord Number { get; set; }
		public Word ArgumentsLength { get; set; }
		public String Arguments { get; set; }
		public UOProperties()
		{
		}
	}
	
	public class Planes
	{
		public Byte PlaneIndex { get; set; }
		public Byte PlaneSize { get; set; }
		public Byte PlaneLength { get; set; }
		public Byte Flags { get; set; }
		public List<Byte> PlaneBuffer { get; set; }
		public Planes()
		{
			PlaneBuffer = new List<Byte>();
		}
	}
	
	public class Stairs
	{
		public Byte PlaneIndex { get; set; }
		public Byte StairSize { get; set; }
		public Byte StairLength { get; set; }
		public Byte Flags { get; set; }
		public List<Byte> StairBuffer { get; set; }
		public Stairs()
		{
			StairBuffer = new List<Byte>();
		}
	}
	
	public class PlayerSeats
	{
		public DWord PlayerSerial { get; set; }
		public DealerPosition114 DealerPosition1140 { get; set; }
		public Byte PlayerIndex { get; set; }
		public DWord PlayerScore { get; set; }
		public Public115 Public1151 { get; set; }
		public Char[] PlayerName { get; set; }
		public PlayerInGame116 PlayerInGame1162 { get; set; }
		public PlayerSeats()
		{
			PlayerName = new Char [30];
		}
	}
	
	public class Tiles
	{
		public Byte TileNumber { get; set; }
		public Byte TileValue { get; set; }
		public Word X { get; set; }
		public Word Y { get; set; }
		public Byte StackLevel { get; set; }
		public Direction119 Direction1190 { get; set; }
		public Flipped120 Flipped1201 { get; set; }
		public Tiles()
		{
		}
	}
	
	public class ItemProperties
	{
		public DWord ItemSerial { get; set; }
		public DWord ItemBlockLength8 { get; set; }
		public DWord ItemLabelNumber { get; set; }
		public Word Length { get; set; }
		public String Arguments { get; set; }
		public ItemProperties()
		{
		}
	}
	
	public class CharacterCombatants
	{
		public DWord CharacterCombatantSerial { get; set; }
		public CharacterCombatants()
		{
		}
	}
	
	public class IfArgumentsMode0x01
	{
		public DWord Filler0 { get; set; }
		public Word BuffIconID { get; set; }
		public Word Filler1 { get; set; }
		public DWord Filler2 { get; set; }
		public Word BuffDurationinseconds { get; set; }
		public Byte[] Filler3 { get; set; }
		public DWord BuffTitleCliloc { get; set; }
		public DWord BuffSecondaryCliloc { get; set; }
		public DWord Filler4 { get; set; }
		public Word ArgumentsMode { get; set; }
		public Word Filler5 { get; set; }
		public IfArgumentsMode0x01()
		{
			Filler0 = 0x00;
			Filler1 = 0x01;
			Filler2 = 0x00;
			Filler3 = new Byte [3];
			for (Int32 i=0; i<Filler3.Length; i++)
			{
				Filler3[i] = 0x00;
			}
			Filler4 = 0x00;
			Filler5 = 0x00;
		}
	}
	
	public class Adresses
	{
		public DWord AddressValue { get; set; }
		public Adresses()
		{
		}
	}
}
