using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UOData;
using UOPackets;
using System.Windows.Forms;
using UOCore;
using UOPackets.ClientPackets;

namespace EUO
{
    public partial class MainForm : Form
    {
        public static Core Core;
		private Thread m_Monitor;
		public delegate void DelAddLog(String data);
		public delegate void DelSetCount(Int32 count);
        public delegate void DelClientClear();
        
        public MainForm()
        {
			Icon = Properties.Resources.UO_Icon;
            InitializeComponent();
            comboBoxIPListen.Items.Add(IPAddress.Any.ToString());
            foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                comboBoxIPListen.Items.Add(ip.ToString());
            }
            if (comboBoxIPListen.Items.Count != 0)
            {
                comboBoxIPListen.SelectedIndex = comboBoxIPListen.Items.Count - 1;
            }
        }

        private void m_Server_ClientConnected(object sender, ClientEventArgs e)
        {
            try
            {
                ClientAdd(IPAddress.Parse(((IPEndPoint)(e.ClientConnected.Client).RemoteEndPoint).Address.ToString()) + ":" + ((IPEndPoint)(e.ClientConnected.Client).RemoteEndPoint).Port.ToString());
                LogAdd("Client logged: " + IPAddress.Parse(((IPEndPoint)(e.ClientConnected.Client).RemoteEndPoint).Address.ToString()) + " on port " + ((IPEndPoint)(e.ClientConnected.Client).RemoteEndPoint).Port.ToString());
                SetUserCount(Core.m_Server.Clients.Count);
            }
            catch (Exception ex) { }            
        }

		private void buttonStartServer_Click(object sender, EventArgs e)
		{
			if (buttonStartServer.Text == "Start Server")
			{
				StartServer();
                comboBoxIPListen.Enabled = false;
                textBoxPortListen.Enabled = false;
			}
			else if (buttonStartServer.Text == "Stop Server")
			{
				StopServer();
                comboBoxIPListen.Enabled = true;
                textBoxPortListen.Enabled = true;
			}
		}

		private void StopServer()
		{
			if (m_Monitor != null && m_Monitor.ThreadState == ThreadState.Running || m_Monitor.ThreadState == ThreadState.Background || m_Monitor.ThreadState == ThreadState.WaitSleepJoin)
			{
				m_Monitor.Abort();
				buttonStartServer.Text = "Start Server";
				Core.m_Server.Stop();
				LogAdd("Server stopped.");
			}
		}

		private void StartServer()
		{
            Core = new Core();
			(Core.m_Server = new TcpServer(IPAddress.Parse(comboBoxIPListen.Text), Int32.Parse(textBoxPortListen.Text))).Start();
            Core.m_Server.ClientConnected += new ClientEventHandler(m_Server_ClientConnected);
		    Core.m_Server.AccountLogged += new AccountEventHandler(Core.Core_AccountLogged);
            Core.m_Server.AccountLogged += new AccountEventHandler(m_Server_AccountLogged);
			if (m_Monitor == null || m_Monitor.ThreadState == ThreadState.Unstarted || m_Monitor.ThreadState == ThreadState.Aborted || m_Monitor.ThreadState == ThreadState.Stopped)
			{
				(m_Monitor = new Thread(new ThreadStart(ThreadMonitor))).Start();
			}
			LogAdd("Server started on address " + Core.m_Server.ServIP + " on port " + Core.m_Server.ServPort + ".");
			buttonStartServer.Text = "Stop Server";
		}

        private void m_Server_AccountLogged(object sender, AccountEventArgs e)
        {
            try
            {
                AccountAdd("'" + e.Account.AccountName + "' on " + IPAddress.Parse(((IPEndPoint)(e.Account.TcpClient.Client).RemoteEndPoint).Address.ToString()) + ":" + ((IPEndPoint)(e.Account.TcpClient.Client).RemoteEndPoint).Port.ToString());
                LogAdd("Account Logged: '" + e.Account.AccountName + "' on " + IPAddress.Parse(((IPEndPoint)(e.Account.TcpClient.Client).RemoteEndPoint).Address.ToString()) + ":" + ((IPEndPoint)(e.Account.TcpClient.Client).RemoteEndPoint).Port.ToString());
                SetAccountCount(Core.LoggedAccounts.Count);
            }
            catch { }
        }

    	private void ThreadMonitor()
		{
			while (true)
			{
				Int32 count = Core.m_Server.Clients.Count;
				Core.m_Server.DoBeginAcceptTcpClient();
				Thread.Sleep(1000);
                if (listBoxClients.Items.Count != Core.m_Server.Clients.Count)
                {
                    ClientClear();
                    foreach (TcpClient client in Core.m_Server.Clients)
                    {
                        ClientAdd(IPAddress.Parse(((IPEndPoint)(client.Client).RemoteEndPoint).Address.ToString()) + ":" + ((IPEndPoint)(client.Client).RemoteEndPoint).Port.ToString());
                    }
                }
                if (listBoxAccounts.Items.Count != Core.LoggedAccounts.Count)
                {
                    /*AccountClear();
                    foreach (Account acc in Core.LoggedAccounts)
                    {
                        AccountAdd(acc.AccountName + " on " + IPAddress.Parse(((IPEndPoint)(acc.TcpClient.Client).RemoteEndPoint).Address.ToString()) + ":" + ((IPEndPoint)(acc.TcpClient.Client).RemoteEndPoint).Port.ToString());
                    }*/
                }
			}
		}

    	private void LogAdd(String data)
		{
			if (listBoxLog.InvokeRequired)
			{
				listBoxLog.Invoke(new DelAddLog(LogAdd), data);
			}
			else
			{
				listBoxLog.Items.Add(data);
				if (checkBoxAutoScroll.Checked)
				{
					listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
				}
			}
		}

        private void ClientAdd(String data)
        {
            if (listBoxClients.InvokeRequired)
            {
                listBoxClients.Invoke(new DelAddLog(ClientAdd), data);
            }
            else
            {
                listBoxClients.Items.Add(data);
            }
        }

        private void ClientClear()
        {
            if (listBoxClients.InvokeRequired)
            {
                listBoxClients.Invoke(new DelClientClear(ClientClear));
            }
            else
            {
                listBoxClients.Items.Clear();
            }
        }

        private void AccountAdd(String data)
        {
            if (listBoxAccounts.InvokeRequired)
            {
                listBoxAccounts.Invoke(new DelAddLog(AccountAdd), data);
            }
            else
            {
                listBoxAccounts.Items.Add(data);
            }
        }

        private void AccountClear()
        {
            if (listBoxAccounts.InvokeRequired)
            {
                listBoxAccounts.Invoke(new DelClientClear(AccountClear));
            }
            else
            {
                listBoxAccounts.Items.Clear();
            }
        }

		private void SetUserCount(Int32 count)
		{
			if (labelClients.InvokeRequired)
			{
                labelClients.Invoke(new DelSetCount(SetUserCount), count);
			}
			else
			{
                labelClients.Text = "Clients: " + count;
			}
		}

        private void SetAccountCount(Int32 count)
        {
            if (labelAccounts.InvokeRequired)
            {
                labelAccounts.Invoke(new DelSetCount(SetAccountCount), count);
            }
            else
            {
                labelAccounts.Text = "Accounts: " + count;
            }
        }

        private void SetCharCount(Int32 count)
        {
            if (labelChars.InvokeRequired)
            {
                labelChars.Invoke(new DelSetCount(SetCharCount), count);
            }
            else
            {
                labelChars.Text = "Characters: " + count;
            }
        }

		private void listBoxLog_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (checkBoxAutoScroll.Checked)
			{
				if (listBoxLog.SelectedIndex != listBoxLog.Items.Count - 1)
				{
					listBoxLog.SetSelected(listBoxLog.Items.Count - 1, true);
				}
			}
            if (listBoxLog.Items.Count != 0)
            {
                buttonClearLog.Enabled = true;
            }
            else
            {
                buttonClearLog.Enabled = false;
            }
		}

		private void MainForm_Disposed(object sender, System.EventArgs e)
		{
			StopServer();
		}

        private void checkBoxAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoScroll.Checked)
            {
                listBoxLog.SetSelected(listBoxLog.Items.Count - 1, true);
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
            listBoxLog.SelectedIndex = -1;
        }

        private void buttonKickUser_Click(object sender, EventArgs e)
        {
            //TODO: consertar a lista de clientes. por algum motivo ao desconectar um cliente, ele continua na lista de clients do Core.m_Server
            if (listBoxClients.SelectedIndex != -1)
            {
                try
                {
                    //Core.m_Server.Clients.Find(delegate(TcpClient cl) { return (((IPEndPoint)(cl.Client).RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)(cl.Client).RemoteEndPoint).Port.ToString() == listBoxClients.SelectedItem.ToString()); }).Client.Disconnect(true);

                    TcpClient tcp = Core.m_Server.Clients.Find(delegate(TcpClient cl) { return (((IPEndPoint)(cl.Client).RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)(cl.Client).RemoteEndPoint).Port.ToString() == listBoxClients.SelectedItem.ToString()); });
                    LogAdd("Client " + listBoxClients.SelectedItem.ToString() + " disconnected.");

                    //Core.LoggedAccounts.Remove(Core.LoggedAccounts.Find(delegate(Account ac) { return ac.TcpClient == tcp; }));
                    //listBoxAccounts.Items.RemoveAt(listBoxAccounts.FindString(IPAddress.Parse(((IPEndPoint)(tcp.Client).RemoteEndPoint).Address.ToString()) + ":" + ((IPEndPoint)(tcp.Client).RemoteEndPoint).Port.ToString()));
                    Core.m_Server.Clients.Remove(tcp);
                    tcp.Client.Close();
                    
                    
                    //m_Server_ClientConnected(sender, e);
                }
                catch { }
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedIndex != -1)
            {
                buttonKickUser.Enabled = true;
                try
                {
                    listBoxAccounts.SelectedIndex = listBoxAccounts.FindString(listBoxClients.SelectedItem.ToString());
                }
                catch { }
            }
            else
            {
                listBoxAccounts.SelectedIndex = -1;
                buttonKickUser.Enabled = false;
            }
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAccounts.SelectedIndex != -1)
            {
                try
                {
                    listBoxChars.Items.Clear();
                    Account acct = Core.LoggedAccounts.Find(delegate(Account ac) { return listBoxAccounts.SelectedItem.ToString().Contains(ac.AccountName); });
                    Dictionary<String,Character> charlist = acct.CharList;
                    foreach (KeyValuePair<String,Character> ch in charlist)
                    {
                        listBoxChars.Items.Add("'" + ch.Value.Name + "'");
                    }
                    SetCharCount(charlist.Count);
                    listBoxClients.SelectedIndex = listBoxClients.FindString(IPAddress.Parse(((IPEndPoint)(acct.TcpClient.Client).RemoteEndPoint).Address.ToString()) + ":" + ((IPEndPoint)(acct.TcpClient.Client).RemoteEndPoint).Port.ToString());
                    
                }
                catch { }
            }
            else
            {
                try
                {
                    listBoxChars.Items.Clear();
                }
                catch { }
            }
        }
    }
}
