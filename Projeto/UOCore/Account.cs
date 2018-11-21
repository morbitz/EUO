using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;
using UOData;

namespace UOCore
{
    public class Account
    {
		public Int32 AccountID { get; set; }
        private String m_Password;
        public DB db { get; set; }
    	public string AccountName { get; set; }

    	public Dictionary<String, Character> CharList {get;set;}
        public TcpClient TcpClient {get;set;}

        private byte[] m_Buffer = new byte[4096];
        private PacketHandler packetHandler = new PacketHandler();

		public NetworkStream NetworkStream { get; set; }

        public Account()
        {
            
        }

        public Account(TcpClient tcpClient)
        {
            TcpClient = tcpClient;
            
        }

        public Account(TcpClient tcpClient, String accountName, String accountPassword)
        {
            TcpClient = tcpClient;
            AccountName = accountName;
            m_Password = accountPassword;
            Initialize();
        }

        public Account(String accountName, String accountPassword)
        {
            AccountName = accountName;
            m_Password = accountPassword;
            Initialize();
        }

        /// <summary>
        /// Authenticate the username and password for the account
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <param name="accountPassword">Account password</param>
        /// <returns>Returns true if the account name and password are correct</returns>
        public static bool Authenticate(String accountName, String accountPassword)
        {
            DB data = new DB();
            string query = "SELECT * FROM account WHERE username = '" + accountName + "' AND passwd = '" + accountPassword + "';";
            MySqlDataReader result = data.ExecuteQuery(query);

            if (result.HasRows)
            {
                result.Close();
                data.Disconnect();
                return true;
            }

            result.Close();
            data.Disconnect();
            return false;

        }
        private Boolean Initialize()
        {
            CharList = new Dictionary<String, Character>(6);
            db = new DB();
            string query = "SELECT * FROM account WHERE username = '" + AccountName + "' AND passwd = '" + m_Password + "';";
            MySqlDataReader result = db.ExecuteQuery(query);

            if (result.HasRows)
            {
                result.Read();
                AccountID = Int32.Parse(result.GetValue(0).ToString());
                result.Close();
                return true;
            }
			result.Close();
			db.Disconnect();

            AccountID = 0x01;

			return false;
		}

        public Boolean LoadChars()
        {
            
            if (db.IsConnected)
            {
                DatabaseDataContext data = new UOData.DatabaseDataContext();
                string query = "SELECT player.id, mobile.name, mobile.model, mobile.direction, mobile.notoriety, mobile.x, mobile.y, mobile.z FROM mobile INNER JOIN player ON (mobile.id = player.mobile_id) WHERE mobile.account_id = " + AccountID + ";";
                var players = from pl in data.players where pl.account_id == AccountID select pl;
                
                foreach (var pl in players)
                {
                    var chars = from ch in data.mobiles where ch.id == pl.mobile_id select ch;
                    foreach (var ch in chars)
                    {
                        CharList.Add(new Character()
                        {
                            Uid = ch.id,
                            Name = ch.name,
                            CharModel = (short)ch.model,
                            Direction = (byte)ch.direction,
                            Notoriety = (short)ch.notoriety,
                            X = (short)ch.x,
                            Y = (short)ch.y,
                            Z = (byte)ch.z,
                            Password = m_Password

                        });
                    }
                    

                }
            
                MySqlDataReader result = db.ExecuteQuery(query);

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Character temp = new Character();
                        temp.Uid = Int32.Parse(result.GetValue(0).ToString());
                        temp.Name = result.GetValue(1).ToString();
                        temp.CharModel = Int16.Parse(result.GetValue(2).ToString());
                        temp.Direction = Byte.Parse(result.GetValue(3).ToString());
                        temp.Notoriety = short.Parse(result.GetValue(4).ToString());
                        temp.X = Int16.Parse(result.GetValue(5).ToString());
                        temp.Y = Int16.Parse(result.GetValue(6).ToString());
                        temp.Z = Byte.Parse(result.GetValue(7).ToString());
                        temp.Password = m_Password;
                        CharList.Add(temp);
                    }
                    return true;
                }
            }
            return false;
            CharList = new List<Character>();
            Character temp1 = new Character();
            temp1.Name = "metal";
            temp1.Password = "metal";
            CharList.Add(temp1);
            return true;
        }

        private Thread m_ThreadReceivePacket;

        public void BeginReceive()
        {
            m_ThreadReceivePacket = new Thread(new ThreadStart(DoReceive));
            m_ThreadReceivePacket.Start();
            //m_TcpClient.Client.BeginReceive(m_Buffer, 0, m_Buffer.Length, SocketFlags.None,
            //                                 new AsyncCallback(DoReceiveCallback), m_TcpClient.Client);

            NetworkStream = TcpClient.GetStream();
  
        }

        public void DoReceive()
        {
            
            while (TcpClient.Client.Connected)
            {
                try
                {
					if (NetworkStream.DataAvailable)
					{
						NetworkStream.Read(m_Buffer, 0, m_Buffer.Length);
						packetHandler.Process(m_Buffer, this);
					}
                	Thread.Sleep(10);
                }
                catch (Exception e) { }
            }
        }
    }
}
