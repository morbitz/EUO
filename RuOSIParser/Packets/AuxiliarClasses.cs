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
namespace UOData
{
	public enum ClientFlags0 : DWord {FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100};
	public enum GenderandRace:1 : Byte {humanmale = 0x00, humanfemale = 0x01, humanmale = 0x02, humanfemale = 0x03, elfmale = 0x04, elffemale = 0x05, gargoylemale = 0x06, gargoylefemale = 0x07};
	public enum Direction2 : Byte {North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80};
	public enum Mode3 : Byte {say = 0x00, system = 0x01, emote = 0x02, label = 0x06, focus = 0x07, whipser = 0x08, yell = 0x09, spell = 0x10, guild = 0x13, alliance = 0x14, GM = 0x15, special = 0x20, encodedcommands = 0xC0};
	public enum OnOff4 : Byte {off = 0x00, on = 0x01};
	public enum AllowNameChange5 : Byte {yes = 0x01, no = 0x00};
	public enum SupportedFeatures6 : Byte {T2Aattributes = 0x02, Renaissanceattributes = 0x03, AOSattributes = 0x04, MLattributes = 0x05, KRattributes = 0x06};
	public enum Race7 : Byte {Human = 0x01, Elf = 0x02, Gargoyle = 0x03, };
	public enum ItemLayer8 : Byte {Invalid = 0x00, OneHanded = 0x01, ThoHanded = 0x02, Shoes = 0x03, Pants = 0x04, Shirt = 0x05, Helm = 0x06, Gloves = 0x07, Ring = 0x08, Talisman = 0x09, Neck = 0x0A, Hair = 0x0B, Waist = 0x0C, InnerTorso = 0x0D, Bracelet = 0x0E, Face = 0x0F, FacialHair = 0x10, MiddleTorso = 0x11, Earrings = 0x12, Arms = 0x13, Cloak = 0x14, Backpack = 0x15, OuterTorso = 0x16, OuterLegs = 0x17, InnerLegs = 0x18, Mount = 0x19, ShopBuy = 0x1A, ShopResale = 0x1B, ShopSell = 0x1C, Bank = 0x1D, ShopMax = 0x1E};
	public enum StatusColor9 : Word {Green = 0x01, Yellow = 0x02, Filler0 = sendsonlyifextended, Filler1 = 1};
	public enum Flag10 : Byte {RemoveStatusColor = 0x00, EnableStatusColor = 0x01, Filler3 = sendsonlyifextended, Filler4 = 1};
	public enum StatusColor11 : Word {Green = 0x01, Yellow = 0x02, Red = 0x03};
	public enum Flag12 : Byte {RemoveStatusColor = 0x00, EnableStatusColor = 0x01};
	public enum Serial13 : DWord {Filler0 = ifAmount!, Filler1 = 0add0x80000000};
	public enum X14 : Word {};
	public enum Y15 : Word {Filler4 = ifhue!, Filler5 = 0add0x8000ifflags!, Filler6 = 0add0x4000};
	public enum Flags16 : Byte {ShowProperties = 0x20, Hidden = 0x80, Filler8 = onlyifFlags!, Filler9 = 0};
	public enum Direction17 : Byte {North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80};
	public enum MessageType18 : Byte {Regular = 0x00, System = 0x01, Emote = 0x02, Label = 0x06, Focus = 0x07, Whisper = 0x08, Yell = 0x09, Spell = 0x0A, Guild = 0x0D, Alliance = 0x0E, GMRequest = 0x0F, GMResponse = 0x10, Special = 0x20, Encoded = 0xC0};
	public enum Flags19 : Byte {Frozen = 0x01, Female = 0x02, Flying = 0x04, YellowHealthBar = 0x08, IgnoreMobiles = 0x10, WarMode = 0x40, Hidden = 0x80};
	public enum Direction20 : Byte {North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80};
	public enum Direction21 : Byte {North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80};
	public enum ContainerType22 : Word {Filler0 = 0x00forvendors, Filler1 = 0x7Dforspellbooksandcontainers};
	public enum Reason23 : Byte {CannotLift = 0x00, OutOfRange = 0x01, OutOfSight = 0x02, TryToSteel = 0x03, AreHolding = 0x04, Inspecific = 0x05};
	public enum Status24 : Byte {Dead = 0x00, Alive = 0x02};
	public enum Layer25 : Byte {Invalid = 0x00, OneHanded = 0x01, ThoHanded = 0x02, Shoes = 0x03, Pants = 0x04, Shirt = 0x05, Helm = 0x06, Gloves = 0x07, Ring = 0x08, Talisman = 0x09, Neck = 0x0A, Hair = 0x0B, Waist = 0x0C, InnerTorso = 0x0D, Bracelet = 0x0E, Face = 0x0F, FacialHair = 0x10, MiddleTorso = 0x11, Earrings = 0x12, Arms = 0x13, Cloak = 0x14, Backpack = 0x15, OuterTorso = 0x16, OuterLegs = 0x17, InnerLegs = 0x18, Mount = 0x19, ShopBuy = 0x1A, ShopResale = 0x1B, ShopSell = 0x1C, Bank = 0x1D, ShopMax = 0x1E};
	public enum Type26 : Byte {GodClientCommand = 0x00, StatsRequest = 0x04, SkillsRequest = 0x05};
	public enum ListType27 : Byte {capped = 0x02, delta = 0xDF, noloop = 0xFF};
	public enum Flag28 : Byte {noitems = 0x00, itemslist = 0x02};
	public enum LightLevel29 : Byte {Bright = 0x00, Night = 0x09, Black = 0x1F};
	public enum 0x0030 : Byte {badpassword = 0x01, nocharacter = 0x02, characterexists = 0x05, characteralreadyinworld = 0x06, loginproblem = 0x07, idle = 0x09, charactertransfer = 0x10, };
	public enum Action31 : Byte {addpin = 0x01, insertpin = 0x02, changepin = 0x03, removepin = 0x04, clearmap = 0x05, toggleeditmap = 0x06};
	public enum ClientFlags32 : DWord {FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100};
	public enum WeatherType33 : Byte {rain = 0x00, fiercestorm = 0x01, snow = 0x02, storm = 0x03, settemperature = 0xFE, stopallweather = 0xFF};
	public enum TargetType34 : Byte {ObjectTarget = 0x00, TileTarget = 0x01};
	public enum Flags35 : Byte {None = 0x00, Harmful = 0x01, Beneficial = 0x02, CancelTarget = 0x03};
	public enum X36 : Word {canceltarget = 0xFFFF};
	public enum Y37 : Word {canceltarget = 0xFFFF};
	public enum Graphic38 : Word {LandTarget = 0x00};
	public enum Forward39 : Byte {forward = 0x00, backward = 0x01};
	public enum Repeat40 : Byte {norepeat = 0x00, repeat = 0x01};
	public enum Delay41 : Byte {fast = 0x00, slow = 0xFF};
	public enum Action42 : Byte {start = 0x00, cancel = 0x01, update = 0x02};
	public enum FirstContainerSerial43 : DWord {ifAction = 0x00};
	public enum SecondContainerSerial44 : DWord {ifAction = 0x00};
	public enum DisplayName45 : Byte {No = 0x00, Yes = 0x01};
	public enum Type46 : Byte {fromsourcetodestination = 0x00, lightningstrike = 0x01, staywithdestination = 0x02, staywithsource = 0x03, specialeffects = 0x04};
	public enum FixedDirection47 : Byte {No = 0x00, Yes = 0x01};
	public enum Explode48 : Byte {No = 0x00, Yes = 0x01};
	public enum ContainerSerial49 : DWord {toplevel = 0x00};
	public enum ReplyMessageSerial50 : DWord {nomessage = 0x00};
	public enum Direction51 : Byte {North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80};
	public enum Flags52 : Byte {Frozen = 0x01, Female = 0x02, Flying = 0x04, YellowHealthBar = 0x08, IgnoreMobiles = 0x10, WarMode = 0x40, Hidden = 0x80};
	public enum Notoriety53 : Byte {Innocent = 0x01, Ally = 0x02, Canbeattacked = 0x03, Criminal = 0x04, Enemy = 0x05, Murderer = 0x06, Invulnerable = 0x07};
	public enum Direction54 : Byte {North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80};
	public enum Flags55 : Byte {Frozen = 0x01, Female = 0x02, Flying = 0x04, YellowHealthBar = 0x08, IgnoreMobiles = 0x10, WarMode = 0x40, Hidden = 0x80};
	public enum Notoriety56 : Byte {Innocent = 0x01, Ally = 0x02, Canbeattacked = 0x03, Criminal = 0x04, Enemy = 0x05, Murderer = 0x06, Invulnerable = 0x07};
	public enum ToggleGodViewQuery57 : Byte {Off = 0x00, On = 0x01};
	public enum RejectionReason58 : Byte {Invalid = 0x00, AccountInUse = 0x01, AccountBlocked = 0x02, WrongPassword = 0x03, IGR = 0x06, CharacterTransfer = 0x09, TimeOut = 0xFE, BadCommunication = 0xFF};
	public enum DeleteResult59 : Byte {BadPassword = 0x00, CharacterNotExists = 0x01, CharacterInGame = 0x02, CharacterTooYoung = 0x03, CharacterQueeed = 0x04, BadRequest = 0x05};
	public enum Flags60 : Byte {WarMode = 0x01, CanLift = 0x02};
	public enum ClientFlags61 : Byte {FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100};
	public enum Gender62 : Byte {male = 0x00, female = 0x01};
	public enum Race63 : Byte {human = 0x01, elf = 0x02, gargoyle = 0x03};
	public enum Editable64 : Byte {No = 0x00, Yes = 0x01};
	public enum Direction65 : Byte {North = 0x00, Right = 0x01, East = 0x02, Down = 0x03, South = 0x04, Left = 0x05, West = 0x06, Up = 0x07, Running = 0x80};
	public enum TargetType66 : Byte {ObjectTarget = 0x00, TileTarget = 0x01};
	public enum Flags67 : Byte {None = 0x00, Harmful = 0x01, Beneficial = 0x02, CancelTarget = 0x03};
	public enum Type68 : DWord {Cancel = 0x00, Response = 0x01};
	public enum Flags69 : DWord {unknownflag1 = 0x01, overwriteconfigurationbutton = 0x02, limit1characterperaccount = 0x04, enablecontextmenus = 0x08, limitcharacterslots = 0x10, paladinandnecromancerclasses = 0x20, tooltips = 0x40, 6thcharacterslot = 0x80, samuraiandninjaclasses = 0x100, elvenrace = 0x200, unknownflag2 = 0x400, Filler2 = sendUO3Dclienttype, clientwillsend0xE1packet = 0x800, unknownflag3 = 0x1000, 7thcharacterslot = 0x2000, unknownflag4 = 0x4000, newmovementsystem = 0x8000, };
	public enum Style70 : Byte {none = 0x00, normal = 0x01, numerical = 0x02};
	public enum Mode71 : Byte {cancel = 0x00, ok = 0x01};
	public enum Mode72 : Byte {say = 0x00, system = 0x01, emote = 0x02, label = 0x06, focus = 0x07, whipser = 0x08, yell = 0x09, spell = 0x10, guild = 0x13, alliance = 0x14, GM = 0x15, encodedcommands = 0xC0};
	public enum Mode73 : Byte {say = 0x00, system = 0x01, emote = 0x02, label = 0x06, focus = 0x07, whipser = 0x08, yell = 0x09, spell = 0x10, guild = 0x13, alliance = 0x14, GM = 0x15, encodedcommands = 0xC0};
	public enum SwitchesCount74 : DWord {OnlyifGumpID = 0x1CD};
	public enum Action75 : Word {ChangeChannelPassword = 0x41, UO3DKick = 0x42, UO3DLeaveChannel = 0x43, UO3DJoinChannel = 0x44, UO3DJoinNewChannel = 0x45, UO3DAddFriend = 0x46, UO3DRemoveFriend = 0x47, UO3DListChannelPlayers = 0x49, LeaveChat = 0x58, ChannelMessage = 0x61, JoinChannel = 0x62, JoinNewChannel = 0x63, RenameChannel = 0x64, PrivateMessage = 0x65, AddIgnore = 0x66, RemoveIgnore = 0x67, ToggleIgnore = 0x68, AddVoice = 0x69, RemoveVoice = 0x6A, ToggleVoice = 0x6B, AddModerator = 0x6C, RemoveModerator = 0x6D, ToggleModerator = 0x6E, AllowPrivateMessages = 0x6F, DisallowPrivateMessages = 0x70, TogglePrivateMessages = 0x71, ShowCharacterName = 0x72, HideCharacterName = 0x73, ToggleCharacterName = 0x74, QueryWhois = 0x75, Kick = 0x76, EnableDefaultVoice = 0x77, DisableDefaultVoice = 0x78, ToggleDefaultVoice = 0x79, EmoteMessage = 0x7A};
	public enum Mode76 : Byte {display = 0x00, edit = 0x01};
	public enum Unknown77 : Word {ifMode = 0x01};
	public enum Flags78 : DWord {enableT2Afeatures:chatbutton = 0x01, regions = 0x02, enablerenaissancefeatures = 0x04, enablethirddownfeatures = 0x08, Filler0 = enableLBRfeatures:skills, map = 0x10, Filler1 = enableAOSfeatures:skills, Filler2 = spells, Filler3 = map, Filler4 = fightbook, housingtiles = 0x20, enable6thcharacterslot = 0x40, Filler5 = enableSEfeatures:spells, Filler6 = skills, Filler7 = map, housingtiles = 0x80, Filler8 = enableMLfeatures:elvenrace, Filler9 = spells, Filler10 = skills, housingtiles = 0x100, enableTheEightAgesplashscreen = 0x200, enableTheNinthAgesplashscreenandcrystal_shadowhousingtiles = 0x400, enableTheTenthAge = 0x800, enableincreasedhousingandbankstorage = 0x1000, enable7thcharacterslot = 0x2000, enableroleplayfaces = 0x4000, trialaccount = 0x8000, Filler11 = nontrial, Filler12 = live, account = 0x10000, Filler13 = enableSAfeatures:gargoylerace, Filler14 = spells, Filler15 = skills, housingtiles = 0x20000enableHSfeatures, Filler16 = 0x40000enableGothichousingtiles, Filler17 = 0x80000enableRustichousingtiles};
	public enum Active79 : Byte {no = 0x00, yes = 0x01};
	public enum Season80 : Byte {spring = 0x00, summer = 0x01, fall = 0x02, winter = 0x03, desolation = 0x04};
	public enum PlayMusic81 : Byte {no = 0x00, yes = 0x01};
	public enum CanLoot82 : Byte {no = 0x00, yes = 0x01};
	public enum RightClick83 : Byte {yes = 0x01, no = 0x00};
	public enum ClientFlags84 : DWord {FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100};
	public enum ContextMenuEntryFlags85 : Word {Enabled = 0x00, Disabled = 0x01, Highlighted = 0x04, Colored = 0x20};
	public enum ContextMenuEntryHue86 : Word {IfFlags = 0x20, };
	public enum Command87 : DWord {PaperdollWindow = 0x01, StatusWindow = 0x02, ProfileWindow = 0x08, ContainerWindow = 0x0C};
	public enum ObjectSerial88 : DWord {Filler2 = for0x0Ccontainerserial, Filler3 = forothertypesmobileserial};
	public enum Display89 : Byte {no = 0x00, yes = 0x01};
	public enum Dead90 : Byte {no = 0x00, yes = 0x01};
	public enum Dead91 : Byte {no = 0x00, yes = 0x01};
	public enum StatType92 : Byte {Str = 0x00, Dex = 0x01, Int = 0x02};
	public enum LockValue93 : Byte {Up = 0x00, Down = 0x01, Locked = 0x02};
	public enum Type94 : Word {nospellbook = 0x00, hasspell = 0x01, hasspellbook = 0x02, };
	public enum SpellbookSerial95 : DWord {onlyifType = 0x01};
	public enum Enable96 : Byte {no = 0x00, yes = 0x01};
	public enum Mode97 : Byte {Normal = 0x00, Fast = 0x01, Slow = 0x02, Hybrid = 0x03+};
	public enum Gender98 : Byte {male = 0x00, female = 0x01};
	public enum Race99 : Byte {human = 0x01, elf = 0x02, gargoyle = 0x03, invalid = 0xFF};
	public enum Command100 : Word {default = 0x63, changepublic_private = 0x65, convertintocustomizable = 0x66, relocationmovingcrate = 0x68, changesignhouse = 0x69, changesignhanger = 0x6A, changesignpost = 0x6B, changefoundationstyle = 0x6C, renamehouse = 0x6D, demolishhouse = 0x6E, tradehouse = 0x6F, makeprimary = 0x70, changetocoowner = 0x71, changetofriend = 0x72, changetoaccess = 0x73, ban = 0x74, removecoowner = 0x75, removefriend = 0x76, removeaccess = 0x77, removeban = 0x78, clearcoownerslist = 0x79, clearfriendslist = 0x7A, clearaccesslist = 0x7B, clearbanslist = 0x7C, addaccess = 0x7D, validaddaccess = 0x7E, invalidaddaccess = 0x7F, customizehouse = 0x80};
	public enum ResourceType101 : Word {ore = 0x00, sand = 0x01, wood = 0x02, graves = 0x03, redmushrooms = 0x04};
	public enum Type102 : Byte {fromsourcetodestination = 0x00, lightningstrike = 0x01, staywithdestination = 0x02, staywithsource = 0x03};
	public enum FixedDirection103 : Byte {No = 0x00, Yes = 0x01};
	public enum Explode104 : Byte {No = 0x00, Yes = 0x01};
	public enum MessageType105 : Byte {Regular = 0x00, System = 0x01, Emote = 0x02, Label = 0x06, Focus = 0x07, Whisper = 0x08, Yell = 0x09, Spell = 0x0A, Guild = 0x0D, Alliance = 0x0E, GMRequest = 0x0F, GMResponse = 0x10, Special = 0x20, Encoded = 0xC0};
	public enum Type106 : DWord {Cancel = 0x00, Response = 0x01};
	public enum Map107 : DWord {felucca = 0x00, trammel = 0x01, ilshenar = 0x02, malas = 0x03, tokuno = 0x04, termur = 0x05};
	public enum Enable108 : Byte {no = 0x00, yes = 0x01};
	public enum Type109 : Byte {fromsourcetodestination = 0x00, lightningstrike = 0x01, staywithdestination = 0x02, staywithsource = 0x03};
	public enum FixedDirection110 : Byte {No = 0x00, Yes = 0x01};
	public enum Explode111 : Byte {No = 0x00, Yes = 0x01};
	public enum Type112 : Byte {};
	public enum MessageType113 : Byte {Regular = 0x00, System = 0x01, Emote = 0x02, Label = 0x06, Focus = 0x07, Whisper = 0x08, Yell = 0x09, Spell = 0x0A, Guild = 0x0D, Alliance = 0x0E, GMRequest = 0x0F, GMResponse = 0x10, Special = 0x20, Encoded = 0xC0};
	public enum AffixType114 : Byte {Append = 0x00, Prepend = 0x01, System = 0x02};
	public enum LogOut115 : Byte {yes = 0x01, no = 0x00};
	public enum CompressionType116 : Byte {atpresenttime = 0x03};
	public enum EnableResponse117 : Byte {yes = 0x01, no = 0x00};
	public enum ClientType118 : Byte {clientversionbefore401a = 0x01, clientversionaboveorequal401a = 0x02};
	public enum DealerPosition119 : Byte {yes = 0x01, no = 0x02};
	public enum Public120 : DWord {yes = 0x01, no = 0x00};
	public enum PlayerInGame121 : Byte {no = 0x01, yes = 0x00};
	public enum Direction122 : Byte {Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03};
	public enum Flipped123 : Byte {yes = 0x10, no = 0x00};
	public enum Direction124 : Byte {Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03};
	public enum Flipped125 : Byte {yes = 0x10, no = 0x00};
	public enum DealerIndicatorWind126 : Byte {North = 0x00, East = 0x01, South = 0x02, West = 0x03};
	public enum DialerIndicatorDirection127 : Byte {Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03};
	public enum Options128 : DWord {ShowScores = 0x01, SpectatorVision = 0x02};
	public enum PublicHand129 : DWord {yes = 0x01, no = 0x00};
	public enum CurrentDirection130 : Byte {Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03};
	public enum NewDirection131 : Byte {Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03};
	public enum Direction132 : Byte {Up = 0x00, Down = 0x01, Left = 0x02, Right = 0x03};
	public enum Wind133 : Byte {North = 0x00, East = 0x01, South = 0x02, West = 0x03};
	public enum BuffType134 : Word {BonusStr = 0x01, BonusDex = 0x02, BonusInt = 0x03, BonusHits = 0x07, BonusStamina = 0x08, BonusMana = 0x09, RegenHits = 0x0A, RegenStam = 0x0B, RegenMana = 0x0C, NightSight = 0x0D, Luck = 0x0E, ReflectPhysical = 0x10, EnhancePotions = 0x11, AttackChance = 0x12, DefendChance = 0x13, SpellDamage = 0x14, CastRecovery = 0x15, CastSpeed = 0x16, ManaCost = 0x17, ReagentCost = 0x18, WeaponSpeed = 0x19, WeaponDamage = 0x1A, PhysicalResistance = 0x1B, FireResistance = 0x1C, ColdResistance = 0x1D, PoisonResistance = 0x1E, EnergyResistance = 0x1F, MaxPhysicalResistance = 0x20, MaxFireResistance = 0x21, MaxColdResistance = 0x22, MaxPoisonResistance = 0x23, MaxEnergyResistance = 0x24, AmmoCost = 0x26, KarmaLoss = 0x28, bufficons = 0x3EA+};
	public enum BugCategory135 : Word {Filler0 = 0x01WorldEnvironment, Wearables = 0x02, Combat = 0x03, UI = 0x04, Crash = 0x05, Stuck = 0x06, Animations = 0x07, Performance = 0x08, NPCs = 0x09, Creatures = 0x0A, Pets = 0x0B, Housing = 0x0C, Filler1 = 0x0DLostItem, Exploit = 0x0E, Other = 0x0F};
	public enum ClientType136 : DWord {KR = 0x02, SA = 0x03};
	public enum ObjectType137 : Word {None = 0x00, Corpse = 0x01, Party = 0x02, Quest = 0x04, QuestDestination = 0x05, Resurrection = 0x06};
	public enum IngoreObjectSerial138 : Byte {yes = 0x01, no = 0x00};
	public enum Enable139 : Word {yes = 0x01, no = 0x00};
	public enum Type140 : Byte {spell = 0x1, weaponability = 0x2, skill = 0x3, item = 0x4, scroll = 0x5};
	public enum MovementType141 : DWord {normal = 0x01, run = 0x02};
	public enum DataType142 : Byte {useTileData = 0x00, useBodyData = 0x01, useMultiData = 0x02};
	public enum Flag143 : Byte {ShowProperties = 0x20, Hidden = 0x80};
	public enum Access144 : Word {foritemsonly = 0x01, PlayerItem = 0x00, };
	public enum BoatSpeed145 : Byte {onetile = 0x01, rowboat = 0x02, slow = 0x03, fast = 0x04};
	public enum ClientFlags146 : DWord {FeluccaFacet = 0x01, TrammelFacet = 0x02, IlshenarFacet = 0x04, MalasFacet = 0x08, TokunoFacet = 0x10, TerMurFacet = 0x20, UO3DClient = 0x40, ReservedforFacet06 = 0x80, UOTD = 0x100};
	public enum GenderandRace:147 : Byte {humanmale = 0x00, humanfemale = 0x01, humanmale = 0x02, humanfemale = 0x03, elfmale = 0x04, elffemale = 0x05, gargoylemale = 0x06, gargoylefemale = 0x07};
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
		public void Build()
		{
			InsertByte(Id);
			InsertByte(GodModeOn_Off);
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
		public void Build()
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
		public Byte[] Ox00 { get; set; }
		public HackMoverRequest() : base (0x0A)
		{
			Data = new Byte [11];
			Filler0 = 0x06;
			Filler1 = 0x00;
			Ox00 = new Byte [7];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Filler0);
			InsertByte(Filler1);
			InsertByte((Byte)OnOff42);
			InsertByte(Ox00);
		}
	}
	/// <summary>
	/// Edit TileData Packet.
	/// </summary>
	public class EditTileData : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public EditTileData() : base (0x0C)
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
	/// Edit NPC Data Packet.
	/// </summary>
	public class EditNPCData : Packet
	{
		public Byte[] Unknown { get; set; }
		public EditNPCData() : base (0x0D)
		{
			Data = new Byte [3];
			Unknown = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Edit Template Data Packet.
	/// </summary>
	public class EditTemplateData : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> Unknown { get; set; }
		public EditTemplateData() : base (0x0E)
		{
			Unknown = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Paperdoll.
	/// </summary>
	public class Paperdoll : Packet
	{
		public Byte[] Unknown { get; set; }
		public Paperdoll() : base (0x0F)
		{
			Data = new Byte [61];
			Unknown = new Byte [60];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Edit Hue Data Packet.
	/// </summary>
	public class EditHueData : Packet
	{
		public Byte[] Unknown { get; set; }
		public EditHueData() : base (0x10)
		{
			Data = new Byte [215];
			Unknown = new Byte [214];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Go to location Packet.
	/// </summary>
	public class Gotolocation : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String X { get; set; }
		public Char Whitespace { get; set; }
		public String Y { get; set; }
		public Char Whitespace { get; set; }
		public String Z { get; set; }
		public Byte Filler0 { get; set; }
		public Gotolocation() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(X);
			InsertChar(Whitespace);
			InsertString(Y);
			InsertChar(Whitespace);
			InsertString(Z);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Cast Skill from the spellbook Packet.
	/// </summary>
	public class CastSkillfromthespellbook : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String SpellID { get; set; }
		public Char Whitespace { get; set; }
		public String SpellbookSerial { get; set; }
		public Byte Filler0 { get; set; }
		public CastSkillfromthespellbook() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(SpellID);
			InsertChar(Whitespace);
			InsertString(SpellbookSerial);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// Change Hue Packet.
	/// </summary>
	public class ChangeHue : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String Hue { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		public ChangeHue() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
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
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String SpellID { get; set; }
		public Byte Filler0 { get; set; }
		public CastSkillfrommacro() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(SpellID);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// GM Menu Packet.
	/// </summary>
	public class GMMenu : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String Command { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		public GMMenu() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(Command);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertByte(Filler0);
		}
	}
	/// <summary>
	/// GM Page Request Packet.
	/// </summary>
	public class GMPageRequest : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public Byte Filler0 { get; set; }
		public GMPageRequest() : base (0x12)
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
	/// GM Page Response Packet.
	/// </summary>
	public class GMPageResponse : Packet
	{
		public Word PacketSize { get; set; }
		public Byte CommandType { get; set; }
		public String Arguments { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Char Whitespace { get; set; }
		public String Arguments { get; set; }
		public Byte Filler0 { get; set; }
		public GMPageResponse() : base (0x12)
		{
			Filler0 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertByte(CommandType);
			InsertString(Arguments);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertChar(Whitespace);
			InsertString(Arguments);
			InsertByte(Filler0);
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
		public ChangeTileZ() : base (0x14)
		{
			Data = new Byte [6];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(X);
			InsertWord(Y);
			InsertSByte(Z);
		}
	}
	/// <summary>
	/// Add Script Packet.
	/// </summary>
	public class AddScript : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public AddScript() : base (0x18)
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
	/// Edit NPC Speech Packet.
	/// </summary>
	public class EditNPCSpeech : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public EditNPCSpeech() : base (0x19)
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
	/// Kick Client Packet.
	/// </summary>
	public class KickClient : Packet
	{
		public DWord GMSerial { get; set; }
		public KickClient() : base (0x26)
		{
			Data = new Byte [5];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(GMSerial);
		}
	}
	/// <summary>
	/// Toggle God Mode Response Packet.
	/// </summary>
	public class ToggleGodModeResponse : Packet
	{
		public Byte GodModeOn_Off { get; set; }
		public ToggleGodModeResponse() : base (0x2B)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(GodModeOn_Off);
		}
	}
	/// <summary>
	/// Toggle Hack Mover Packet.
	/// </summary>
	public class ToggleHackMover : Packet
	{
		public Byte On_Off { get; set; }
		public ToggleHackMover() : base (0x32)
		{
			Data = new Byte [2];
		}
		public void Build()
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
		public GroupCommand() : base (0x33)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(Command);
		}
	}
	/// <summary>
	/// Resource Type Packet.
	/// </summary>
	public class ResourceType : Packet
	{
		public Byte[] UnknownData { get; set; }
		public ResourceType() : base (0x35)
		{
			Data = new Byte [653];
			UnknownData = new Byte [652];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Resource Tile Data Packet.
	/// </summary>
	public class ResourceTileData : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public ResourceTileData() : base (0x36)
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
	/// Move Object Packet.
	/// </summary>
	public class MoveObject : Packet
	{
		public DWord ObjectSerial { get; set; }
		public Byte ZOffset { get; set; }
		public Byte YOffset { get; set; }
		public Byte XOffset { get; set; }
		public MoveObject() : base (0x37)
		{
			Data = new Byte [8];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(ObjectSerial);
			InsertByte(ZOffset);
			InsertByte(YOffset);
			InsertByte(XOffset);
		}
	}
	/// <summary>
	/// Groups Packet.
	/// </summary>
	public class Groups : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Groups() : base (0x39)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Ship Packet.
	/// </summary>
	public class Ship : Packet
	{
		public Byte UnknownData { get; set; }
		public Ship() : base (0x3D)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Versions Packet.
	/// </summary>
	public class Versions : Packet
	{
		public DWord IndexNumber { get; set; }
		public DWord[] Versions { get; set; }
		/* Client returns 0x4B - Check Version with dword indexNumber + 7 and dword versionNumber for that index */
		/* This packet requires an EditServer login to function properly. */
		public Versions() : base (0x3E)
		{
			Data = new Byte [37];
			Versions = new DWord [8];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(IndexNumber);
			InsertDWord(Versions);
		}
	}
	/// <summary>
	/// Update Statics Packet.
	/// </summary>
	public class UpdateStatics : Packet
	{
		public Word PacketSize { get; set; }
		public DWord BlocksNumber { get; set; }
		public DWord StaticTilesCount { get; set; }
		public DWord ExtraValues { get; set; }
		StaticTiles StaticTiles0 { get; set; }
		/* Blocks Number = X / 8 * 512 + Y / 8 */
		public UpdateStatics() : base (0x3F)
		{
			StaticTiles0 = new StaticTiles();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertDWord(BlocksNumber);
			InsertDWord(StaticTilesCount);
			InsertDWord(ExtraValues);
		}
	}
	/// <summary>
	/// Update Terrains Packet.
	/// </summary>
	public class UpdateTerrains : Packet
	{
		public DWord BlocksNumber { get; set; }
		LandTiles LandTiles0 { get; set; }
		public DWord Header { get; set; }
		/* Blocks Number = X / 8 * 512 + Y / 8 */
		public UpdateTerrains() : base (0x40)
		{
			Data = new Byte [201];
			LandTiles0 = new LandTiles();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(BlocksNumber);
			InsertDWord(Header);
		}
	}
	/// <summary>
	/// Update Terrains Packet.
	/// </summary>
	public class UpdateTerrains : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public UpdateTerrains() : base (0x41)
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
	/// Update Art Packet.
	/// </summary>
	public class UpdateArt : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public UpdateArt() : base (0x42)
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
	/// Update Animation Packet.
	/// </summary>
	public class UpdateAnimation : Packet
	{
		public Byte[] UnknownData { get; set; }
		public UpdateAnimation() : base (0x43)
		{
			Data = new Byte [553];
			UnknownData = new Byte [552];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update Hues Packet.
	/// </summary>
	public class UpdateHues : Packet
	{
		public Byte[] UnknownData { get; set; }
		public UpdateHues() : base (0x44)
		{
			Data = new Byte [713];
			UnknownData = new Byte [712];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Version OK Packet.
	/// </summary>
	public class VersionOK : Packet
	{
		public DWord Index { get; set; }
		/* From Server to Godclient. */
		/* This packet requires an EditServer login to function properly. */
		public VersionOK() : base (0x45)
		{
			Data = new Byte [5];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Index);
		}
	}
	/// <summary>
	/// New Art Packet.
	/// </summary>
	public class NewArt : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public NewArt() : base (0x46)
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
	/// New Terrain Packet.
	/// </summary>
	public class NewTerrain : Packet
	{
		public Word X { get; set; }
		public Word Y { get; set; }
		public Word ID { get; set; }
		public Word Width { get; set; }
		public Word Height { get; set; }
		public NewTerrain() : base (0x47)
		{
			Data = new Byte [11];
		}
		public void Build()
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
	/// New Animation Packet.
	/// </summary>
	public class NewAnimation : Packet
	{
		public Byte[] UnknownData { get; set; }
		public NewAnimation() : base (0x48)
		{
			Data = new Byte [73];
			UnknownData = new Byte [72];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// New Hues Packet.
	/// </summary>
	public class NewHues : Packet
	{
		public Byte[] UnknownData { get; set; }
		public NewHues() : base (0x49)
		{
			Data = new Byte [93];
			UnknownData = new Byte [92];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Destroy Art Packet.
	/// </summary>
	public class DestroyArt : Packet
	{
		public DWord ArtID { get; set; }
		public DestroyArt() : base (0x4A)
		{
			Data = new Byte [5];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(ArtID);
		}
	}
	/// <summary>
	/// Destroy Art Packet.
	/// </summary>
	public class CheckVersion : Packet
	{
		public DWord LookupNumber { get; set; }
		public DWord VersionNumber { get; set; }
		/* Server should send 0x45 - Version OK with matching lookup. Client will send another 0x4B with lookup - 1, until 0x45 w/ 0 lookup is met. */
		/* This packet requires an EditServer login to function properly. */
		public CheckVersion() : base (0x4B)
		{
			Data = new Byte [9];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(LookupNumber);
			InsertDWord(VersionNumber);
		}
	}
	/// <summary>
	/// Destroy Art Packet.
	/// </summary>
	public class ScriptNames : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public ScriptNames() : base (0x4C)
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
	/// Edit Script Packet.
	/// </summary>
	public class EditScript : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public EditScript() : base (0x4D)
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
	/// Board Header Packet.
	/// </summary>
	public class BoardHeader : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public BoardHeader() : base (0x50)
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
	/// Board Message Packet.
	/// </summary>
	public class BoardMessage : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public BoardMessage() : base (0x51)
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
	/// Post Board Message Packet.
	/// </summary>
	public class PostBoardMessage : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public PostBoardMessage() : base (0x52)
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
	/// Update Regions Packet.
	/// </summary>
	public class UpdateRegions : Packet
	{
		public Byte[] UnknownData { get; set; }
		public UpdateRegions() : base (0x57)
		{
			Data = new Byte [110];
			UnknownData = new Byte [109];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
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
		public NewRegion() : base (0x58)
		{
			Data = new Byte [106];
			RegionName = new Char [40];
			Filler0 = 0x00;
			RegionDescription = new Char [40];
		}
		public void Build()
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
	/// New Content FX Packet.
	/// </summary>
	public class NewContentFX : Packet
	{
		public List<Byte> UnknownData { get; set; }
		public NewContentFX() : base (0x59)
		{
			UnknownData = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update Content FX Packet.
	/// </summary>
	public class UpdateContentFX : Packet
	{
		public List<Byte> UnknownData { get; set; }
		public UpdateContentFX() : base (0x5A)
		{
			UnknownData = new List<Byte>();
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Restart Version Packet.
	/// </summary>
	public class RestartVersion : Packet
	{
		public Byte UnknownData { get; set; }
		public RestartVersion() : base (0x5C)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Servers List Packet.
	/// </summary>
	public class ServersList : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public ServersList() : base (0x5E)
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
	/// Add Server Packet.
	/// </summary>
	public class AddServer : Packet
	{
		public Byte[] UnknownData { get; set; }
		public AddServer() : base (0x5F)
		{
			Data = new Byte [49];
			UnknownData = new Byte [48];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Remove Server Packet.
	/// </summary>
	public class RemoveServer : Packet
	{
		public Byte[] UnknownData { get; set; }
		public RemoveServer() : base (0x60)
		{
			Data = new Byte [5];
			UnknownData = new Byte [4];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
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
		public DestroyStatic() : base (0x61)
		{
			Data = new Byte [9];
		}
		public void Build()
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
		public MoveStatic() : base (0x62)
		{
			Data = new Byte [15];
		}
		public void Build()
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
	/// Area Load Packet.
	/// </summary>
	public class AreaLoad : Packet
	{
		public Byte[] UnknownData { get; set; }
		public AreaLoad() : base (0x63)
		{
			Data = new Byte [13];
			UnknownData = new Byte [12];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Area Load Request Packet.
	/// </summary>
	public class AreaLoadRequest : Packet
	{
		public AreaLoadRequest() : base (0x64)
		{
			Data = new Byte [1];
		}
		public void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Simped Packet.
	/// </summary>
	public class Simped : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Simped() : base (0x67)
		{
			Data = new Byte [21];
			UnknownData = new Byte [20];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Simped Attach Packet.
	/// </summary>
	public class ScriptAttach : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public ScriptAttach() : base (0x68)
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
	/// Friends Packet.
	/// </summary>
	public class Friends : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public Friends() : base (0x69)
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
	/// Notify Friend Packet.
	/// </summary>
	public class NotifyFriend : Packet
	{
		public Byte[] UnknownData { get; set; }
		public NotifyFriend() : base (0x6A)
		{
			Data = new Byte [3];
			UnknownData = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Key Use Packet.
	/// </summary>
	public class KeyUse : Packet
	{
		public Byte[] UnknownData { get; set; }
		public KeyUse() : base (0x6B)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Animation Packet.
	/// </summary>
	public class Animation : Packet
	{
		public DWord Serial { get; set; }
		public Word Action { get; set; }
		public Word FrameCount { get; set; }
		public Word RepeatTimes { get; set; }
		public Forward39 Forward390 { get; set; }
		public Repeat40 Repeat401 { get; set; }
		public Delay41 Delay412 { get; set; }
		/* No longer used since UO:SA launch */
		public Animation() : base (0x6E)
		{
			Data = new Byte [14];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(Serial);
			InsertWord(Action);
			InsertWord(FrameCount);
			InsertWord(RepeatTimes);
			InsertByte((Byte)Forward390);
			InsertByte((Byte)Repeat401);
			InsertByte((Byte)Delay412);
		}
	}
	/// <summary>
	/// Resource Query Packet.
	/// </summary>
	public class ResourceQuery : Packet
	{
		public Byte[] UnknownData { get; set; }
		public ResourceQuery() : base (0x79)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Resource Data Packet.
	/// </summary>
	public class ResourceData : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public ResourceData() : base (0x7A)
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
	/// God View Query Packet.
	/// </summary>
	public class GodViewQuery : Packet
	{
		public ToggleGodViewQuery57 ToggleGodViewQuery570 { get; set; }
		public GodViewQuery() : base (0x7E)
		{
			Data = new Byte [2];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte((Byte)ToggleGodViewQuery570);
		}
	}
	/// <summary>
	/// God View Data Packet.
	/// </summary>
	public class GodViewData : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public GodViewData() : base (0x7F)
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
	/// Change Password Packet.
	/// </summary>
	public class ChangePassword : Packet
	{
		public Byte[] UnknownData { get; set; }
		public ChangePassword() : base (0x84)
		{
			Data = new Byte [69];
			UnknownData = new Byte [68];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Send Resources Packet.
	/// </summary>
	public class SendResources : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public SendResources() : base (0x87)
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
	/// Trigger Edit Packet.
	/// </summary>
	public class TriggerEdit : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public TriggerEdit() : base (0x8A)
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
	/// Move Character Packet.
	/// </summary>
	public class MoveCharacter : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public MoveCharacter() : base (0x8E)
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
	/// Update MultiData Packet.
	/// </summary>
	public class UpdateMultiData : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public UpdateMultiData() : base (0x92)
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
	/// Book Change Header Packet.
	/// </summary>
	public class BookChangeHeader : Packet
	{
		public DWord BookSerial { get; set; }
		public Editable64 Editable640 { get; set; }
		public Byte Filler1 { get; set; }
		public Word NumberOfPages { get; set; }
		public Char[] Title { get; set; }
		public Char[] Author { get; set; }
		public BookChangeHeader() : base (0x93)
		{
			Data = new Byte [99];
			Filler1 = 0x01;
			Title = new Char [60];
			Author = new Char [30];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(BookSerial);
			InsertByte((Byte)Editable640);
			InsertByte(Filler1);
			InsertWord(NumberOfPages);
			InsertChar(Title);
			InsertChar(Author);
		}
	}
	/// <summary>
	/// Update Skills Packet.
	/// </summary>
	public class UpdateSkills : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public UpdateSkills() : base (0x94)
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
	/// Game Central Monitor Packet.
	/// </summary>
	public class GameCentralMonitor : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public GameCentralMonitor() : base (0x96)
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
	/// Assistance Request Packet.
	/// </summary>
	public class AssistanceRequest : Packet
	{
		public Byte[] UnknownData { get; set; }
		public AssistanceRequest() : base (0x9C)
		{
			Data = new Byte [309];
			UnknownData = new Byte [308];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// GM Single Packet.
	/// </summary>
	public class GMSingle : Packet
	{
		public Byte[] UnknownData { get; set; }
		public GMSingle() : base (0x9D)
		{
			Data = new Byte [51];
			UnknownData = new Byte [50];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Target Object List Packet.
	/// </summary>
	public class TargetObjectList : Packet
	{
		public Word PacketSize { get; set; }
		public List<Byte> UnknownData { get; set; }
		public TargetObjectList() : base (0xB4)
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
		public void Build()
		{
			InsertByte(Id);
			InsertDWord(SourceID);
			InsertDWord(DestinationID);
		}
	}
	/// <summary>
	/// OPL Info Packet.
	/// </summary>
	public class OPLInfo : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord Serial { get; set; }
		public DWord Hash { get; set; }
		public OPLInfo() : base (0xBF)
		{
			Filler0 = 0x10;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(Serial);
			InsertDWord(Hash);
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
		/* Discontinued in new 3D client, later in 2d client. */
		public DisplayContextMenu() : base (0xBF)
		{
			Filler0 = 0x14;
			Filler1 = 0x01;
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
	/// Bonded status Packet.
	/// </summary>
	public class Bondedstatus : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Serial { get; set; }
		public Dead90 Dead902 { get; set; }
		public Bondedstatus() : base (0xBF)
		{
			Filler0 = 0x19;
			Filler1 = 0x00;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Serial);
			InsertByte((Byte)Dead902);
		}
	}
	/// <summary>
	/// Damage Packet Packet.
	/// </summary>
	public class DamagePacket : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public Byte Filler1 { get; set; }
		public DWord Serial { get; set; }
		public Byte Amount { get; set; }
		public DamagePacket() : base (0xBF)
		{
			Filler0 = 0x22;
			Filler1 = 0x01;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertByte(Filler1);
			InsertDWord(Serial);
			InsertByte(Amount);
		}
	}
	/// <summary>
	/// KR House Menu Response Packet.
	/// </summary>
	public class KRHouseMenuResponse : Packet
	{
		public Word PacketSize { get; set; }
		public Word Filler0 { get; set; }
		public DWord MobileSerial { get; set; }
		public DWord HouseFoundationSerial { get; set; }
		public Command100 Command1001 { get; set; }
		public DWord Parameter { get; set; }
		/* Parameter = 0x00 for command = 0x63, 0x65, client-side 0x66, client-side 0x68, client-side 0x6D, client-side 0x6E, client-side 0x6F, client-side 0x70, 0x74, client-side 0x79, client-side 0x7A, client-side 0x7B, client-side 0x7C, 0x7D, 0x7F, client-side 0x80. Parameter = 0x01 for command = server-side 0x66, server-side 0x68, server-side 0x6D, server-side 0x6E, server-side 0x6F, server-side 0x70, server-side 0x79, server-side 0x7A, server-side 0x7B, server-side 0x7C. Parameter = Sign Item ID for command = 0x69, Sign Hanger Item ID for command 0x6A, Sign Post Item ID for command 0x6B, Foundation Item ID for command 0x6C, House Foundation Serial for server-side command 0x80. Parameter = Player Serial for command = 0x71, 0x72, 0x73, 0x75, 0x76, 0x77, 0x78, 0x7E. */
		public KRHouseMenuResponse() : base (0xBF)
		{
			Filler0 = 0x2F;
		}
		public void Build()
		{
			InsertByte(Id);
			InsertWord(PacketSize);
			InsertWord(Filler0);
			InsertDWord(MobileSerial);
			InsertDWord(HouseFoundationSerial);
			InsertWord((Word)Command1001);
			InsertDWord(Parameter);
		}
	}
	/// <summary>
	/// Invalid Map Packet.
	/// </summary>
	public class InvalidMap : Packet
	{
		public Byte[] UnknownData { get; set; }
		public InvalidMap() : base (0xC5)
		{
			Data = new Byte [203];
			UnknownData = new Byte [202];
		}
		public void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
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
	
	public class Skills
	{
		public Word SkillID { get; set; }
		public Word SkillValue { get; set; }
		public Word SkillBaseValue { get; set; }
		public Byte LockStatus { get; set; }
		public Word SkillCappedValue { get; set; }
		public Skills()
		{
		}
	}
	
	public class Items
	{
		public Byte ItemLayer { get; set; }
		public DWord ItemSerial { get; set; }
		public Word ItemAmount { get; set; }
		public Items()
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
	
	public class Lines
	{
		public Word PageIndex { get; set; }
		public Word LinesCount { get; set; }
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
		public DWord CityX { get; set; }
		public DWord CityY { get; set; }
		public DWord CityZ { get; set; }
		public DWord CityMap { get; set; }
		public DWord CityClilocDescription { get; set; }
		public DWord 0 { get; set; }
		public Cities()
		{
			CityName = new Char [32];
			BuildingName = new Char [32];
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
		public ContextMenuEntryFlags85 ContextMenuEntryFlags850 { get; set; }
		public ContextMenuEntryHue86 ContextMenuEntryHue861 { get; set; }
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
	
	public class Properties
	{
		public DWord Number { get; set; }
		public Word ArgumentsLength { get; set; }
		public String Arguments { get; set; }
		public Properties()
		{
		}
	}
	
	public class Planes
	{
		public Byte Filler0 { get; set; }
		public Byte PlaneSize { get; set; }
		public Byte PlaneLength { get; set; }
		public Byte Flags { get; set; }
		public List<Byte> PlaneBuffer { get; set; }
		public Planes()
		{
			Filler0 = PlaneIndex|0x20;
			PlaneBuffer = new List<Byte>();
		}
	}
	
	public class Stairs
	{
		public Byte PlaneIndex+9 { get; set; }
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
		public DealerPosition119 DealerPosition1190 { get; set; }
		public Byte PlayerIndex { get; set; }
		public DWord PlayerScore { get; set; }
		public Public120 Public1201 { get; set; }
		public Char[] PlayerName { get; set; }
		public PlayerInGame121 PlayerInGame1212 { get; set; }
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
		public Direction124 Direction1240 { get; set; }
		public Flipped125 Flipped1251 { get; set; }
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
	
	public class Buffs
	{
		public Word SourceType { get; set; }
		public Word Filler0 { get; set; }
		public Word BuffQueueIndex { get; set; }
		public DWord Filler1 { get; set; }
		public Word BuffDurationinseconds { get; set; }
		public Byte[] Filler2 { get; set; }
		public DWord BuffTitleCliloc { get; set; }
		public DWord BuffSecondaryCliloc { get; set; }
		public DWord BuffThirdCliloc { get; set; }
		public Word PrimaryClilocArgumentsLength { get; set; }
		public String PrimaryClilocArguments { get; set; }
		public Word SecondaryClilocArgumentsLength { get; set; }
		public String SecondaryClilocArguments { get; set; }
		public Word ThirdClilocArgumentsLength { get; set; }
		public String ThirdClilocArguments { get; set; }
		public Buffs()
		{
			Filler0 = 0x00;
			Filler1 = 0x00;
			Filler2 = new Byte [3];
			for (Int32 i=0; i<Filler2.Length; i++)
			{
				Filler2[i] = 0x00;
			}
		}
	}
	
	public class MovementRequests
	{
		public QWord DateTime1 { get; set; }
		public QWord DateTime2 { get; set; }
		public Byte Sequence { get; set; }
		public Byte Direction { get; set; }
		public MovementType141 MovementType1410 { get; set; }
		public DWord X { get; set; }
		public DWord Y { get; set; }
		public DWord Z { get; set; }
		public MovementRequests()
		{
		}
	}
	
	public class Adresses
	{
		public DWord AddressValue { get; set; }
		public Adresses()
		{
		}
	}
	
	public class BoatObjects
	{
		public DWord BoatObjectSerial { get; set; }
		public Word BoatObjectX { get; set; }
		public Word BoatObjectY { get; set; }
		public Word BoatObjectZ { get; set; }
		public BoatObjects()
		{
		}
	}
	
	public class InnerPackets
	{
		public List<Byte> InnerPacketstructure { get; set; }
		public InnerPackets()
		{
			InnerPacketstructure = new List<Byte>();
		}
	}
}
