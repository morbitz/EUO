using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UOCore;

namespace UOCore
{
    public delegate void AccountEventHandler(object sender, AccountEventArgs e);
    
    public class AccountEventArgs : EventArgs
    {
        public Account Account { get; set; }

        public AccountEventArgs(Account data)
        {
            Account = data;
        }
    }
    
    public class Core
    {
        public TcpServer m_Server;
        private List<Account> m_LoggedAccounts;
        public List<Account> LoggedAccounts
        {
            get { return m_LoggedAccounts; }
            set { m_LoggedAccounts = value; }
        }

        //public event AccountEventHandler AccountLogged;
        
        public Core()
        {
            m_LoggedAccounts = new List<Account>();
            m_Server = new TcpServer();
            //AccountLogged +=new AccountEventHandler(Core_AccountLogged);
        }

        public void Core_AccountLogged(object sender, AccountEventArgs e)
        {
            //TODO: PAN
            e.Account.BeginReceive();
        }


    }
}
