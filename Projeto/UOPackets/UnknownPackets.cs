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
namespace UOPackets
{
	/// <summary>
	/// Edit TileData Packet.
	/// </summary>
	public class EditTileData : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* God Client packet, unknown data */
		public EditTileData() : base (0x0C)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Edit NPC Data Packet.
	/// </summary>
	public class EditNPCData : Packet
	{
		public Byte[] Unknown { get; set; }
		/* God Client packet, unknown data */
		public EditNPCData() : base (0x0D)
		{
			Data = new Byte [3];
			Unknown = new Byte [2];
		}
		public override void Build()
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
		public Word Packetsize { get; set; }
		public List<Byte> Unknown { get; set; }
		/* God Client packet, unknown data */
		public EditTemplateData() : base (0x0E)
		{
			Unknown = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Paperdoll.
	/// </summary>
	public class Paperdoll : Packet
	{
		public Byte[] Unknown { get; set; }
		/* God Client packet, unknown data */
		public Paperdoll() : base (0x0F)
		{
			Data = new Byte [61];
			Unknown = new Byte [60];
		}
		public override void Build()
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
		/* God Client packet, unknown data */
		public EditHueData() : base (0x10)
		{
			Data = new Byte [215];
			Unknown = new Byte [214];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(Unknown);
		}
	}
	/// <summary>
	/// Script Names Packet.
	/// </summary>
	public class ScriptNames2 : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* God Client packet, unknown data */
		public ScriptNames2() : base (0x16)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Add Script Packet.
	/// </summary>
	public class AddScript : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* God Client packet, unknown data */
		public AddScript() : base (0x18)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Edit NPC Speech Packet.
	/// </summary>
	public class EditNPCSpeech : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* God Client packet, unknown data */
		public EditNPCSpeech() : base (0x19)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
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
		public override void Build()
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
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Resource Type Packet.
	/// </summary>
	public class ResourceType : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet. */
		public ResourceType() : base (0x35)
		{
			Data = new Byte [653];
			UnknownData = new Byte [652];
		}
		public override void Build()
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
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet. */
		public ResourceTileData() : base (0x36)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Groups Packet.
	/// </summary>
	public class Groups : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Groups() : base (0x39)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public Ship() : base (0x3D)
		{
			Data = new Byte [2];
		}
		public override void Build()
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
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Versions() : base (0x3E)
		{
			Data = new Byte [25];
			UnknownData = new Byte [24];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update Terrains Packet.
	/// </summary>
	public class UpdateTerrains : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public UpdateTerrains() : base (0x41)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update Art Packet.
	/// </summary>
	public class UpdateArt : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public UpdateArt() : base (0x42)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update Animation Packet.
	/// </summary>
	public class UpdateAnimation : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public UpdateAnimation() : base (0x43)
		{
			Data = new Byte [553];
			UnknownData = new Byte [552];
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public UpdateHues() : base (0x44)
		{
			Data = new Byte [713];
			UnknownData = new Byte [712];
		}
		public override void Build()
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
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public VersionOK() : base (0x45)
		{
			Data = new Byte [5];
			UnknownData = new Byte [4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// New Art Packet.
	/// </summary>
	public class NewArt : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public NewArt() : base (0x46)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// New Animation Packet.
	/// </summary>
	public class NewAnimation : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public NewAnimation() : base (0x48)
		{
			Data = new Byte [73];
			UnknownData = new Byte [72];
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public NewHues() : base (0x49)
		{
			Data = new Byte [93];
			UnknownData = new Byte [92];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Destroy Art Packet.
	/// </summary>
	public class CheckVersion : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public CheckVersion() : base (0x4B)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Destroy Art Packet.
	/// </summary>
	public class ScriptNames : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public ScriptNames() : base (0x4C)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Edit Script Packet.
	/// </summary>
	public class EditScript : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public EditScript() : base (0x4D)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Board Header Packet.
	/// </summary>
	public class BoardHeader : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Old Client Packet */
		public BoardHeader() : base (0x50)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Board Message Packet.
	/// </summary>
	public class BoardMessage : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Old Client Packet */
		public BoardMessage() : base (0x51)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Post Board Message Packet.
	/// </summary>
	public class PostBoardMessage : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Old Client Packet */
		public PostBoardMessage() : base (0x52)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update Regions Packet.
	/// </summary>
	public class UpdateRegions : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public UpdateRegions() : base (0x57)
		{
			Data = new Byte [110];
			UnknownData = new Byte [109];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// New Content FX Packet.
	/// </summary>
	public class NewContentFX : Packet
	{
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public NewContentFX() : base (0x59)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public UpdateContentFX() : base (0x5A)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public RestartVersion() : base (0x5C)
		{
			Data = new Byte [2];
		}
		public override void Build()
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
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public ServersList() : base (0x5E)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Add Server Packet.
	/// </summary>
	public class AddServer : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public AddServer() : base (0x5F)
		{
			Data = new Byte [49];
			UnknownData = new Byte [48];
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public RemoveServer() : base (0x60)
		{
			Data = new Byte [5];
			UnknownData = new Byte [4];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Area Load Packet.
	/// </summary>
	public class AreaLoad : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public AreaLoad() : base (0x63)
		{
			Data = new Byte [13];
			UnknownData = new Byte [12];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Simped Packet.
	/// </summary>
	public class Simped : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Simped() : base (0x67)
		{
			Data = new Byte [21];
			UnknownData = new Byte [20];
		}
		public override void Build()
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
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public ScriptAttach() : base (0x68)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Friends Packet.
	/// </summary>
	public class Friends : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Friends() : base (0x69)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Notify Friend Packet.
	/// </summary>
	public class NotifyFriend : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public NotifyFriend() : base (0x6A)
		{
			Data = new Byte [3];
			UnknownData = new Byte [2];
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public KeyUse() : base (0x6B)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Resource Query Packet.
	/// </summary>
	public class ResourceQuery : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client packet. */
		public ResourceQuery() : base (0x79)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public override void Build()
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
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client packet. */
		public ResourceData() : base (0x7A)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// God View Data Packet.
	/// </summary>
	public class GodViewData : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client packet. */
		public GodViewData() : base (0x7F)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Change Password Packet.
	/// </summary>
	public class ChangePassword : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public ChangePassword() : base (0x84)
		{
			Data = new Byte [69];
			UnknownData = new Byte [68];
		}
		public override void Build()
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
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public SendResources() : base (0x87)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Trigger Edit Packet.
	/// </summary>
	public class TriggerEdit : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public TriggerEdit() : base (0x8A)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Move Character Packet.
	/// </summary>
	public class MoveCharacter : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public MoveCharacter() : base (0x8E)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unused Packet.
	/// </summary>
	public class Unused : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown Packet */
		public Unused() : base (0x8F)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update MultiData Packet.
	/// </summary>
	public class UpdateMultiData : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client packet */
		public UpdateMultiData() : base (0x92)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Update Skills Packet.
	/// </summary>
	public class UpdateSkills : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client packet */
		public UpdateSkills() : base (0x94)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Game Central Monitor Packet.
	/// </summary>
	public class GameCentralMonitor : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client packet */
		public GameCentralMonitor() : base (0x96)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Assistance Request Packet.
	/// </summary>
	public class AssistanceRequest : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public AssistanceRequest() : base (0x9C)
		{
			Data = new Byte [309];
			UnknownData = new Byte [308];
		}
		public override void Build()
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
		/* Unknown God Client Packet */
		public GMSingle() : base (0x9D)
		{
			Data = new Byte [51];
			UnknownData = new Byte [50];
		}
		public override void Build()
		{
			InsertByte(Id);
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
		public override void Build()
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
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public TargetObjectList() : base (0xB4)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown2 : Packet
	{
		public Word Packetsize { get; set; }
		public Word Filler0 { get; set; }
		public Unknown2() : base (0xBF)
		{
			Filler0 = 0x27;
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertWord(Filler0);
		}
	}
	/// <summary>
	/// Invalid Map Packet.
	/// </summary>
	public class InvalidMap : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client packet. */
		public InvalidMap() : base (0xC5)
		{
			Data = new Byte [203];
			UnknownData = new Byte [202];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown3 : Packet
	{
		/* Unknown God Client Packet */
		public Unknown3() : base (0xCD)
		{
			Data = new Byte [1];
		}
		public override void Build()
		{
			InsertByte(Id);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown4 : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Unknown4() : base (0xCE)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown5 : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Unknown5() : base (0xCF)
		{
			Data = new Byte [78];
			UnknownData = new Byte [77];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown6 : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Unknown6() : base (0xD0)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown7 : Packet
	{
		public Byte[] UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Unknown7() : base (0xD2)
		{
			Data = new Byte [25];
			UnknownData = new Byte [24];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown8 : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Unknown8() : base (0xD3)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown9 : Packet
	{
		public Word Packetsize { get; set; }
		public List<Byte> UnknownData { get; set; }
		/* Unknown God Client Packet */
		public Unknown9() : base (0xD5)
		{
			UnknownData = new List<Byte>();
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertWord(Packetsize);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown10 : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Unknown10() : base (0xEE)
		{
			Data = new Byte [10];
			UnknownData = new Byte [9];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown11 : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Unknown11() : base (0xF0)
		{
			Data = new Byte [19];
			UnknownData = new Byte [18];
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertByte(UnknownData);
		}
	}
	/// <summary>
	/// Unknown Packet.
	/// </summary>
	public class Unknown12 : Packet
	{
		public Byte[] UnknownData { get; set; }
		public Unknown12() : base (0xF1)
		{
			Data = new Byte [9];
			UnknownData = new Byte [8];
		}
		public override void Build()
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
		public DWord Filler0 { get; set; }
		public Word A { get; set; }
		public Word B { get; set; }
		public DWord Filler1 { get; set; }
		public Word A2 { get; set; }
		public Word C { get; set; }
		public DWord Filler2 { get; set; }
		public Word A3 { get; set; }
		public Word C2 { get; set; }
		/* A, B and C – unknown values. A is increment value, so may be it’s global counter. Server sends this packet without client request. Only KR packet since 2.48.0.3 */
		public Unknown() : base (0xF2)
		{
			Data = new Byte [25];
			Filler0 = 0x116;
			Filler1 = 0x116;
			Filler2 = 0x116;
		}
		public override void Build()
		{
			InsertByte(Id);
			InsertDWord(Filler0);
			InsertWord(A);
			InsertWord(B);
			InsertDWord(Filler1);
			InsertWord(A2);
			InsertWord(C);
			InsertDWord(Filler2);
			InsertWord(A3);
			InsertWord(C2);
		}
	}
}
