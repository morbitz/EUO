using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UOData;
using UOPackets;
using UOPackets.ServerPackets;

namespace UOCore
{
    public class PacketHandler
    {
        public PacketHandler()
        {
            
        }
		public void SetBuffer(Packet p, ref Account a)
		{
			a.TcpClient.SendBufferSize = p.PacketSize;
			a.TcpClient.Client.SendBufferSize = p.PacketSize;
			a.TcpClient.SendTimeout = 10;
			a.TcpClient.Client.SendTimeout = 10;
			a.TcpClient.Client.NoDelay = true;
			a.TcpClient.NoDelay = true;
			a.TcpClient.Client.Blocking = false;
		}
        public void Process(byte[] packet, Account a)
        {
            //a.TcpClient.NoDelay = true;
            //a.TcpClient.Client.DontFragment = true;
            //a.TcpClient.Client.NoDelay = false;
            //a.TcpClient.Client.SendBufferSize = 74;
            //a.TcpClient.LingerState = new LingerOption(false, 0);
            //a.TcpClient.SendTimeout = 0;
            //a.TcpClient.Client.SendTimeout = 0;
            //a.TcpClient.Client.LingerState = new LingerOption(false, 0);
            try
            {
                switch (packet[0])
                {
                    case 0x80:
                        ServerList serverList = new ServerList();
                        serverList.Build();
                        //serverList.Send(a.TcpClient);
                        a.NetworkStream.Write(serverList.Data, 0, serverList.PacketSize);
                        break;

                    case 0xA0:
                        if (a.TcpClient.Client.LocalEndPoint != null)
                        {
                            IPAddress addr = ((IPEndPoint)a.TcpClient.Client.LocalEndPoint).Address;
                            Int16 port = Int16.Parse(((IPEndPoint)a.TcpClient.Client.LocalEndPoint).Port.ToString());
                            ServerConnect serverConnect = new ServerConnect(addr, port, a.AccountID)
                                                            {
                                                                GameServerIp =
                                                                    IPAddress.Parse(
                                                                    ((IPEndPoint)a.TcpClient.Client.RemoteEndPoint).Address.ToString())
                                                            };
                            serverConnect.Build();
                            a.NetworkStream.Write(serverConnect.Data, 0, serverConnect.PacketSize);
                        }
                        break;

                    case 0x91:
                        a.LoadChars();
                        CharacterList characterList = new CharacterList(a.CharList);

                        characterList.Build();

                        a.NetworkStream.Write(characterList.Data, 0, characterList.PacketSize);
                        break;

                    case 0x5D:
                        ClientVersion clientVersion = new ClientVersion();
                        clientVersion.Build();
                        clientVersion.Compress();
                        clientVersion.Send(a.NetworkStream);
                        break;

     

                    case 0xBD:

                        UOPackets.ServerPackets.LoginConfirm loginConfirm = new UOPackets.ServerPackets.LoginConfirm();
                        loginConfirm.Body = 400;
                        loginConfirm.Direction131 = Direction13.North;
                        loginConfirm.X = 2520;
                        loginConfirm.Y = 521;
                        loginConfirm.Z = 0;
                        loginConfirm.MapHeight = 4096;
                        loginConfirm.MapWidth = 7168;
                        loginConfirm.Serial = 2420;
                        loginConfirm.Build();
                        loginConfirm.Compress();

                        loginConfirm.Send(a.NetworkStream);


                        MapChange mapChange = new MapChange();
                        mapChange.MapId = Map102.felucca;
                        mapChange.Build();
                        mapChange.Compress();

                        mapChange.Send(a.NetworkStream);


                        MapPatches mapPatches = new MapPatches();
                        mapPatches.MapsCount = 4;
                        mapPatches.Build();
                        mapPatches.Compress();

                        mapPatches.Send(a.NetworkStream);


                        SeasonChange seasonChange = new SeasonChange();
                        seasonChange.Season750 = Season75.summer;
                        seasonChange.PlayMusic761 = PlayMusic76.yes;
                        seasonChange.Build();
                        seasonChange.Compress();

                        seasonChange.Send(a.NetworkStream);


                        Int16 feat = 0x00;
                        SupportedFeatures supportedFeatures = new SupportedFeatures();
                        feat = (Int16)Flags73.enablethirddownfeatures;
                        feat += (Int16)Flags73.enableT2Afeatureschatbuttonregions;
                        feat += (Int16)Flags73.enableMLfeatureselvenracespellsskills;
                        feat += (Int16)Flags73.enableAOSfeaturesskillsspellsmapfightbook;
                        feat += (Int16)Flags73.enablerenaissancefeatures;
                        feat += (Int16)Flags73.enableLBRfeaturesskillsmap;
                        supportedFeatures.Flags730 = feat;
                        supportedFeatures.Build();
                        supportedFeatures.Compress();

                        supportedFeatures.Send(a.NetworkStream);


                        MobileUpdate mobileUpdate = new MobileUpdate();
                        mobileUpdate.Direction163 = Direction16.North;
                        mobileUpdate.Flags151 = Flags15.WarMode;
                        mobileUpdate.Hue = 33770;
                        mobileUpdate.X = 2520;
                        mobileUpdate.Y = 521;
                        mobileUpdate.Z = 0;
                        mobileUpdate.Serial = 2420;
                        mobileUpdate.Body = 400;
                        mobileUpdate.Build();
                        mobileUpdate.Compress();

                        mobileUpdate.Send(a.NetworkStream);
                        mobileUpdate.Send(a.NetworkStream);


                        GlobalLight globalLight = new GlobalLight();
                        globalLight.LightLevel240 = LightLevel24.Bright;
                        globalLight.Build();
                        globalLight.Compress();

                        globalLight.Send(a.NetworkStream);


                        Infravision infraVision = new Infravision();
                        infraVision.Active = 0x00;
                        infraVision.Serial = 2420;
                        infraVision.Build();
                        infraVision.Compress();

                        infraVision.Send(a.NetworkStream);


                        mobileUpdate.Send(a.NetworkStream);



                        //TODO: Pegar tudo do BD
                        MobileIncoming mobileIncoming = new MobileIncoming();
                        mobileIncoming.Body = 400;
                        mobileIncoming.Direction490 = (Direction49)((short)(Direction49.Running) + (short)(Direction49.Up));
                        mobileIncoming.Flags501 = Flags50.Hidden;
                        mobileIncoming.Notoriety512 = Notoriety51.Canbeattacked;
                        mobileIncoming.Serial = 2420;
                        mobileIncoming.X = 2520;
                        mobileIncoming.Y = 521;
                        mobileIncoming.Z = 0;
                        mobileIncoming.Hue = 0x83ea;
                        mobileIncoming.Items3.Add(new Items() { ItemSerial = 0x40000380, ItemID = 0x0e7c, ItemLayer = ItemLayer8.Bank, ItemHue = 0x00 });
                        mobileIncoming.Items3.Add(new Items() { ItemSerial = 0x7fffd62f, ItemID = 0xa03b, ItemLayer = ItemLayer8.Hair, ItemHue = 0x044e });
                        mobileIncoming.Items3.Add(new Items() { ItemSerial = 0x66666666, ItemID = 0xa03b, ItemLayer = ItemLayer8.Hair, ItemHue = 0x044e });
                        mobileIncoming.Build();
                        mobileIncoming.Compress();

                        mobileIncoming.Send(a.NetworkStream);


                        MobileStatus mobileStatus = new MobileStatus();
                        mobileStatus.Serial = 2420;
                        mobileStatus.Name = "lokis                         ".ToCharArray();
                        mobileStatus.HitPoints = 0x50;
                        mobileStatus.MaximumHitPoints = 0x50;
                        mobileStatus.AllowNameChange50 = AllowNameChange5.no;
                        mobileStatus.SupportedFeatures61 = SupportedFeatures6.MLattributes;
                        mobileStatus.Gender = 0x00;
                        mobileStatus.Strength = 0x3c;
                        mobileStatus.Dexterity = 0x0a;
                        mobileStatus.Intelligence = 0x0a;
                        mobileStatus.Stamina = 0x0a;
                        mobileStatus.MaximumStamina = 0x0a;
                        mobileStatus.Mana = 0x0a;
                        mobileStatus.MaximumMana = 0x0a;
                        mobileStatus.Gold = 0;
                        mobileStatus.ArmorRating = 0;
                        mobileStatus.Weight = 0x0e;
                        mobileStatus.MaximumWeight = 0x0136;
                        mobileStatus.Race72 = Race7.Human;
                        mobileStatus.StatCap = 0xe1;
                        mobileStatus.Followers = 0;
                        mobileStatus.MaximumFollowers = 5;
                        mobileStatus.FireResistance = 0;
                        mobileStatus.ColdResistance = 0;
                        mobileStatus.PoisonResistance = 0;
                        mobileStatus.EnergyResistance = 0;
                        mobileStatus.Luck = 0;
                        mobileStatus.MinimumWeaponDamage = 1;
                        mobileStatus.MaximumWeaponDamage = 5;
                        mobileStatus.TithingPoints = 0;
                        mobileStatus.Build();
                        mobileStatus.Compress();

                        mobileStatus.Send(a.NetworkStream);


                        WarMode warMode = new WarMode();
                        warMode.Warmode = 0x00;
                        warMode.Build();
                        warMode.Compress();

                        warMode.Send(a.NetworkStream);


                        OPLInfo oplInfo2 = new OPLInfo();
                        oplInfo2.Serial = 2420;
                        oplInfo2.Hash = 0x400f9705;
                        oplInfo2.Build();
                        oplInfo2.Compress();
                        oplInfo2.Send(a.NetworkStream);


                        //mobileIncoming.Send(a.TcpClient);

                        OPLInfo oplInfo = new OPLInfo();
                        //oplInfo.Serial = 2420;
                        oplInfo.Serial = 0x40013082;
                        //oplInfo.Hash = 0x4301baee;
                        oplInfo.Hash = 0x400f9705;
                        oplInfo.Build();
                        oplInfo.Compress();

                        oplInfo.Send(a.NetworkStream);
                        oplInfo2.Send(a.NetworkStream);


                        supportedFeatures.Send(a.NetworkStream);
                        mobileUpdate.Send(a.NetworkStream);
                        mobileStatus.Send(a.NetworkStream);
                        warMode.Send(a.NetworkStream);
                        mobileIncoming.Send(a.NetworkStream);

                        //oplInfo2.Send(a.NetworkStream);

                        LoginConfirmed loginConfirmed = new LoginConfirmed();
                        loginConfirmed.Build();
                        loginConfirmed.Compress();

                        loginConfirmed.Send(a.NetworkStream);


                        GameTime gameTime = new GameTime();
                        gameTime.Hour = Convert.ToByte(DateTime.Now.Hour);
                        gameTime.Minute = Convert.ToByte(DateTime.Now.Minute);
                        gameTime.Second = Convert.ToByte(DateTime.Now.Second);
                        gameTime.Build();
                        gameTime.Compress();

                        gameTime.Send(a.NetworkStream);


                        seasonChange.Send(a.NetworkStream);


                        mapChange.Send(a.NetworkStream);


                        /*globalLight.Send(a.NetworkStream);
                        infraVision.Send(a.NetworkStream);
                        gameTime.Send(a.NetworkStream);

                        DisplayPaperdoll displayPaperdoll = new DisplayPaperdoll();
                        displayPaperdoll.Flags550 = Flags55.CanLift;
                        displayPaperdoll.Serial = 400;
                        displayPaperdoll.Text = "lokis, Apprentice smith                                    ".ToCharArray();
                        displayPaperdoll.Build();
                        displayPaperdoll.Compress();


                        displayPaperdoll.Send(a.NetworkStream);

                        oplInfo.Send(a.NetworkStream);

                        //break;

                        //case 0xD6:
                        globalLight = new GlobalLight();
                        globalLight.LightLevel240 = LightLevel24.Bright;
                        globalLight.Build();
                        globalLight.Compress();

                        infraVision = new Infravision();
                        infraVision.Active = 0x00;
                        infraVision.Serial = 2420;
                        infraVision.Build();
                        infraVision.Compress();

                        mapChange = new MapChange();
                        mapChange.MapId = Map102.felucca;
                        mapChange.Build();
                        mapChange.Compress();

                        mapChange.Send(a.NetworkStream);
                        infraVision.Send(a.NetworkStream);
                        globalLight.Send(a.NetworkStream);


                        mobileUpdate.Send(a.NetworkStream);
                        mobileStatus.Send(a.NetworkStream);

                        warMode.Send(a.NetworkStream);
                        mobileIncoming.Send(a.NetworkStream);
                        oplInfo.Send(a.NetworkStream);

                        SkillsUpdate skillsUpdate = new SkillsUpdate();
                        skillsUpdate.ListType220 = ListType22.capped;


                        for (int i = 0; i < 55; i++)
                        {
                            Random rand = new Random();
                            Int16 skillBaseValue = 100;
                            Int16 skillCappedValue = 100;
                            Int16 skillValue = 100;

                            skillsUpdate.Skills.Add(new Skills() { SkillID = (SkillName)i, LockStatus = 0x00, SkillBaseValue = skillBaseValue, SkillCappedValue = skillCappedValue, SkillValue = skillValue });
                        }

                        skillsUpdate.Build();
                        skillsUpdate.Compress();
                        skillsUpdate.Send(a.NetworkStream);*/


                        DisplayPaperdoll displayPaperdoll = new DisplayPaperdoll();
                        displayPaperdoll.Flags550 = Flags55.CanLift;
                        displayPaperdoll.Serial = 2420;
                        displayPaperdoll.Text = "LoKiS, Apprentice smith";
                        displayPaperdoll.Build();
                        displayPaperdoll.Compress();


                        displayPaperdoll.Send(a.NetworkStream);

                        break;

                    case 0x34:

                        SkillsUpdate skillsUpdate = new SkillsUpdate();
                        skillsUpdate.ListType220 = ListType22.capped;


                        for (int i = 0; i < 55; i++)
                        {
                            Random rand = new Random();
                            Int16 skillBaseValue = 100;
                            Int16 skillCappedValue = 100;
                            Int16 skillValue = 100;

                            skillsUpdate.Skills.Add(new Skills() { SkillID = (SkillName)i+1, LockStatus = 0x00, SkillBaseValue = skillBaseValue, SkillCappedValue = skillCappedValue, SkillValue = skillValue });
                        }

                        skillsUpdate.Build();
                        skillsUpdate.Compress();
                        skillsUpdate.Send(a.NetworkStream);

                        break;

                    case 0x02:
                        MovementAccepted movAccepted = new MovementAccepted();

                        movAccepted.Sequence = packet[2];
                        movAccepted.Status = 0x03;
                        movAccepted.Build();
                        movAccepted.Compress();

                        movAccepted.Send(a.NetworkStream);



                        /*AsciiMessage asciiMessage = new AsciiMessage();
                        asciiMessage.Serial = 0xFFFFFFFF;
                        asciiMessage.Hue = 0x3b2;
                        asciiMessage.Graphic = 0xFFFF;
                        asciiMessage.Font = 3;
                        asciiMessage.Name = "PELUPELUPELUPELUPELUPELUPELUU".ToCharArray();
                        asciiMessage.TextMessage = "PELUDO";
                        asciiMessage.MessageType140 = MessageType14.System;
                        asciiMessage.Build();
                        asciiMessage.Compress();
                        asciiMessage.Send(a.NetworkStream);*/



                        /* Pacotes
                         * 5D - PlayCharacter CS
                         * BD - ClientVersion SC
                         * BD - ClientVersion CS
                         * 1B - LoginConfirm SC
                         * 34 - MobileQuery CS
                         * BD - ClientVersion CS
                         * BF.05 - ScreenSize CS
                         * BF.0B - ClientLanguage CS
                         * BF.0F - ClientInfo CS
                         * BF.08 - MapChange SC
                         * BF.18 - MapPatches SC
                         * BC - SeasonChange SC
                         * B9 - SupportedFeatures SC
                         * 20 - MobileUpdate SC
                         * 20 - MobileUpdate SC
                         * 4F - GlobalBright SC
                         * 4E - Infravision SC
                         * 20 - MobileUpdate SC
                         * 78 - MobileIncoming SC
                         * 11 - MobileStatus SC
                         * 72 - Warmode SC
                         * 78 - MobileIncoming SC
                         * DC - OPLInfo SC
                         * B9 - SupportedFeatures SC
                         * 20 - MobileUpdate SC
                         * 11 - MobileStatus SC
                         * 72 - Warmode SC
                         * 78 - MobileIncoming SC
                         * 55 - LoginConfirmed SC
                         * 06 - DoubleClick CS
                         * 5B - GameTime SC
                         * BC - SeasonChange SC
                         * BF - MapChange SC
                         * 4F - GlobalBright SC
                         * 4E - Infravision SC
                         * AE - UnicodeMessage SC
                         * D6 - BatchQueryProperties CS
                         * 1C - AsciiMessage SC
                         * 3A - SkillsUpdate SC
                         * 88 - DisplayPaperdoll SC
                         * DC - OPLInfo SC
                         * D6 - BatchQueryProperties CS
                         * BF.24 - Unknown CS
                         */

                        /* Ordem da DoLogin():
                         * LoginConfirm -
                         * MapChange -
                         * SeasonChange -
                         * SupportedFeatures -
                         * MobileUpdate-
                         * MobileUpdate-
                         * MobileUpdate-
                         * MobileIncoming
                         * MobileStatus -
                         * SetWarMode -
                         * SupportedFeatures -
                         * MobileUpdate -
                         * MobileStatus -
                         * MobileIncoming
                         * LoginComplete -
                         * CurrentTime
                         * SeasonChange -
                         * MapChange-
                         * LoginEventArgs
                         */
                        /*
                        LoginConfirm loginConfirm = new LoginConfirm( a.CharList[0] );
                        loginConfirm.Build();
                        loginConfirm.Send(a.TcpClient);
					
					
                        UOPackets.ServerPackets.LoginConfirm loginConfirm = new UOPackets.ServerPackets.LoginConfirm();
                        loginConfirm.Body = 0;
                        loginConfirm.Direction131 = Direction13.North;
                        loginConfirm.X = 2520;
                        loginConfirm.Y = 521;
                        loginConfirm.Z = 0;
					


                        //a.TcpClient.Client.Send(loginConfirm.Data, 0, loginConfirm.PacketSize, SocketFlags.None);

                        CharacterMapChange characterMapChange = new CharacterMapChange(0x01);
                        characterMapChange.Build();
                        Subcommands subCommands = new Subcommands(characterMapChange);
                        subCommands.Build();

                        characterMapChange.Send(a.TcpClient);
                        //a.TcpClient.Client.Send(characterMapChange.Data, 0, characterMapChange.PacketSize, SocketFlags.None);

                        UOPackets.ServerPackets.SeasonChange seasonChange = new UOPackets.ServerPackets.SeasonChange();
                        seasonChange.PlayMusic761 = PlayMusic76.yes;
                        seasonChange.Season750 = Season75.summer;
                        seasonChange.Build();
                        seasonChange.Compress();
                        seasonChange.Send(a.TcpClient);

                        UOPackets.ServerPackets.SupportedFeatures supportedFeatures = new UOPackets.ServerPackets.SupportedFeatures();
                        supportedFeatures.Flags730 = Flags73.enableAOSfeaturesskillsspellsmapfightbook;
                        supportedFeatures.Build();
                        supportedFeatures.Compress();
                        supportedFeatures.Send(a.TcpClient);

                        UOPackets.ServerPackets.MobileUpdate mobileUpdate = new UOPackets.ServerPackets.MobileUpdate();
                        mobileUpdate.Body = 0;
                        mobileUpdate.Direction163 = Direction16.North;
                        mobileUpdate.Flags151 = 0;
                        mobileUpdate.Hue = 0;
                        mobileUpdate.X = 2520;
                        mobileUpdate.Y = 521;
                        mobileUpdate.Z = 0;
                        mobileUpdate.Serial = 0;
                        mobileUpdate.Build();
                        mobileUpdate.Compress();
                        mobileUpdate.Send(a.TcpClient);
                        mobileUpdate.Send(a.TcpClient);
                        mobileUpdate.Send(a.TcpClient);


                        UOPackets.ServerPackets.MobileStatus mobileStatus = new UOPackets.ServerPackets.MobileStatus();
                        mobileStatus.Serial = 0;
                        mobileStatus.Name = "teste".ToCharArray();
                        mobileStatus.HitPoints = 100;
                        mobileStatus.MaximumHitPoints = 100;
                        mobileStatus.AllowNameChange50 = AllowNameChange5.yes;
                        mobileStatus.SupportedFeatures61 = SupportedFeatures6.AOSattributes;
                        mobileStatus.Gender = 0;
                        mobileStatus.Strength = 100;
                        mobileStatus.Dexterity = 100;
                        mobileStatus.Intelligence = 100;
                        mobileStatus.Stamina = 100;
                        mobileStatus.MaximumStamina = 100;
                        mobileStatus.Mana = 100;
                        mobileStatus.MaximumMana = 100;
                        mobileStatus.Gold = 500;
                        mobileStatus.ArmorRating = 100;
                        mobileStatus.Weight = 50;
                        mobileStatus.StatCap = 300;
                        mobileStatus.Followers = 0;
                        mobileStatus.MaximumFollowers = 6;
                        mobileStatus.FireResistance = 0;
                        mobileStatus.ColdResistance = 0;
                        mobileStatus.PoisonResistance = 0;
                        mobileStatus.EnergyResistance = 0;
                        mobileStatus.Luck = 0;
                        mobileStatus.MinimumWeaponDamage = 0;
                        mobileStatus.MaximumWeaponDamage = 100;
                        mobileStatus.TithingPoints = 0;
                        mobileStatus.Build();
                        mobileStatus.Compress();
                        mobileStatus.Send(a.TcpClient);
					
					
                        UOPackets.ServerPackets.WarMode setWarMode = new UOPackets.ServerPackets.WarMode();
                        setWarMode.Warmode = 0;
                        setWarMode.Build();
                        setWarMode.Compress();
                        setWarMode.Send(a.TcpClient);


                        supportedFeatures.Send(a.TcpClient);
                        mobileUpdate.Send(a.TcpClient);
                        mobileStatus.Send(a.TcpClient);


                        UOPackets.LoginComplete loginComplete = new LoginComplete();
                        loginComplete.Build();
                        loginComplete.Send(a.TcpClient);


                        seasonChange.Send(a.TcpClient);
                        UOPackets.ServerPackets.MapChange mapChange = new UOPackets.ServerPackets.MapChange();
                        mapChange.Build();
                        mapChange.Send(a.TcpClient);


					

                        //ClientFeatures clientFeatures = new ClientFeatures();
                        //clientFeatures.Build();

                        //a.TcpClient.Client.Send(clientFeatures.m_Data, 0, clientFeatures.PacketSize, SocketFlags.None);
                        /*
                        CharacterWarmode characterWarmode = new CharacterWarmode();
                        characterWarmode.Build();

                        a.TcpClient.Client.Send( characterWarmode.Data, 0, characterWarmode.PacketSize, SocketFlags.None );

                    

                        a.TcpClient.Client.Send(subCommands.Data, 0, subCommands.PacketSize, SocketFlags.None);


                        CharacterSync characterSync = new CharacterSync(a.CharList[0]);
                        characterSync.Build();

                        a.TcpClient.Client.Send(characterSync.Data, 0, characterSync.PacketSize, SocketFlags.None);

                        LoginComplete loginComplete = new LoginComplete();
                        loginComplete.Build();

                        a.TcpClient.Client.Send(loginComplete.Data, 0, loginComplete.PacketSize, SocketFlags.None);

                        */
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
