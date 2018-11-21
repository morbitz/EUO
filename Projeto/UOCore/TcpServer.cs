using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UOCore;
using UOPackets;
using UOPackets.ServerPackets;

namespace UOCore
{
    using UOData;

    public delegate void ClientEventHandler(object sender, ClientEventArgs e);
    public class ClientEventArgs : EventArgs
    {
        public TcpClient ClientConnected { get; set; }
        public ClientEventArgs(TcpClient data)
        {
            ClientConnected = data;
        }
    }
	public class TcpServer
	{
		public static ManualResetEvent TcpClientConnected = new ManualResetEvent(false);
		private TcpListener m_Server;
		private List<TcpClient> m_Clients;
        private byte[] m_Buffer = new byte[8196];
		public IPAddress ServIP { get; set; }
		public Int32 ServPort { get; set; }
        public DatabaseDataContext DB = new DatabaseDataContext();
		public List<TcpClient> Clients
		{
			get { return m_Clients; }
			set { m_Clients = value; }
		}
        
        public event ClientEventHandler ClientConnected;
        public event AccountEventHandler AccountLogged;
        

		private Boolean m_Running = false;
		private Int32 m_MaxQueue = 10;
		/// <summary>
		/// Gets or sets the Integer specifying the maximum clients in the queue to be attended.
		/// </summary>
		public Int32 MaxQueue
		{
			get
			{
				return m_MaxQueue;
			}
			set
			{
				m_MaxQueue = value;
			}
		}
		/// <summary>
		/// Creates a TcpServer listening on all IPs in this machine on the default port 2593.
		/// </summary>
		public TcpServer()
		{
			//m_Server = new TcpListener(IPAddress.Any, 2593);
			//ServIP = IPAddress.Any;
			//ServPort = 2593;
			Initialize();
		}
		/// <summary>
		/// Creates a TcpServer listening on all IPs in this machine.
		/// </summary>
		/// <param name="port">The port number the server will listen.</param>
		public TcpServer(Int32 port)
		{
			m_Server = new TcpListener(IPAddress.Any, port);
			ServIP = IPAddress.Any;
			ServPort = port;
			Initialize();
		}
		/// <summary>
		/// Creates a TcpServer listening on the specified IP Address.
		/// </summary>
		/// <param name="address">The IP Address the server will listen.</param>
		/// <param name="port">The port number the server will listen.</param>
		public TcpServer(IPAddress address, Int32 port)
		{
			ServIP = address;
			ServPort = port;
			m_Server = new TcpListener(address, port);
			Initialize();
		}
		private void Initialize()
		{
			if (m_Running)
			{
				Stop();
			}
			m_Clients = new List<TcpClient>();
		}
		/// <summary>
		/// Starts the TCP Server.
		/// </summary>
		public void Start()
		{
			if (!m_Running)
			{
				m_Server.Start(m_MaxQueue);
				m_Running = true;
			}
		}
		/// <summary>
		/// Stops the TCP Server.
		/// </summary>
		public void Stop()
		{
			if (m_Running)
			{
				m_Server.Stop();
				m_Running = false;
			}
		}
		/// <summary>
		/// Restarts the TCP Server.
		/// </summary>
		public void Restart()
		{
			if (m_Running)
			{
				Stop();
			}
			Start();
		}
		/// <summary>
		/// Resets the server data.
		/// </summary>
		public void Reset()
		{
			Initialize();
		}
		/// <summary>
		/// Callback function for accepting asynchronous TCP Connection.
		/// </summary>
		/// <param name="ar">The asynchronous connection result.</param>
		public void DoAcceptTcpClientCallback(IAsyncResult ar)
		{
            try
            {
                m_Server = (TcpListener) ar.AsyncState;
                TcpClient new_client = m_Server.EndAcceptTcpClient(ar);
                m_Clients.Add(new_client);
                TcpClientConnected.Set();
                ClientConnected(this, new ClientEventArgs(new_client));

                //Receive the useless first packet
                new_client.Client.Receive(new byte[4]);

                //Receive the second packet (login packet)
                byte[] loginData = new byte[62];
                new_client.Client.Receive(loginData);

                LoginRequestShardList loginPacket = new LoginRequestShardList(loginData);
                Account newAccount = new Account();
                //Validate the account and password
                //if (Account.Authenticate(loginPacket.AccountName, loginPacket.AccountPassword))
                //TODO: Mudar para LINQ
                var acct = from a in DB.accounts where a.username == loginPacket.AccountName && a.passwd == loginPacket.AccountPassword select a;
                if (acct.Count() == 1)
                {
                    newAccount = new Account(new_client,loginPacket.AccountName,loginPacket.AccountPassword);

                    //MainForm.Core.LoggedAccounts.Add(newAccount);
                    AccountLogged(this, new AccountEventArgs(newAccount));
					
                    ServerList serverList = new ServerList();
                    serverList.Build();
                    new_client.Client.Send(serverList.Data);
                    
                }
                else
                {
					AccountLoginRejection rej = new AccountLoginRejection{RejectionReason530 = RejectionReason53.Invalid};
                	rej.Build();
					//rej.FixSize();
					rej.Compress();
					rej.Send(new_client.GetStream());
                    //TODO: Enviar pacote de login ou senha incorretos
                }
                /*
                byte[] data = new byte[200];
                new_client.Client.Receive(data);

                IPAddress addr;
                Int16 port;
                addr = ((IPEndPoint)new_client.Client.LocalEndPoint).Address;
                port = Int16.Parse(((IPEndPoint)new_client.Client.LocalEndPoint).Port.ToString());
                ServerConnect serverConnect = new ServerConnect(addr, port, newAccount.AccountID) { GameServerIp = IPAddress.Parse(((IPEndPoint)new_client.Client.RemoteEndPoint).Address.ToString()) };
                serverConnect.Build();

                new_client.Client.Send(serverConnect.Data);

                data = new byte[200];
                new_client.Client.Receive(data);

                newAccount.LoadChars();
                CharacterList characterList = new CharacterList(newAccount.CharList);

                characterList.Build();

                new_client.Client.Send(characterList.Data);

                */
				

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
		}


        public void DoReceiveCallback(IAsyncResult ar)
        {
            
        }

		/// <summary>
		/// Accepts a TCP Client connection.
		/// </summary>
		public void DoBeginAcceptTcpClient()
		{
			if (m_Server.Pending())
			{
				TcpClientConnected.Reset();
				m_Server.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), m_Server);
				TcpClientConnected.WaitOne();
			}
            
		}
	}
}
