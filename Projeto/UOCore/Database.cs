using MySql.Data.MySqlClient;
using System.IO;
using System.Xml;
using System.Data;
using System;

namespace UOCore
{
    public class Database
    {
        private string m_Server;
        /// <summary>
        /// Atribui ou retorna o host do banco de dados
        /// </summary>
        public string Server
        {
            get { return m_Server; }
            set { m_Server = value; }
        }

        private string m_Port;
        /// <summary>
        /// Atribui ou retorna a porta da conexão
        /// </summary>
        public string Port
        {
            get { return m_Port; }
            set { m_Port = value; }
        }

        private string m_User;
        /// <summary>
        /// Atribui ou retorna o usuário
        /// </summary>
        public string User
        {
            get { return m_User; }
            set { m_User = value; }
        }

        private string m_Password;
        /// <summary>
        /// Atribui ou retorna a senha do usuário
        /// </summary>
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        private string m_DatabaseName;
        /// <summary>
        /// Atribui ou retorna o nome da database
        /// </summary>
        public string DatabaseName
        {
            get { return m_DatabaseName; }
            set { m_DatabaseName = value; }
        }

        private MySqlConnection m_Connection;
        /// <summary>
        /// Retorna o objeto da conexão
        /// </summary>
        public MySqlConnection Connection
        {
            get { return m_Connection; }
            set { m_Connection = value; }
        }

        public Database()
        {
            this.Load();
            this.Connect();
        }

        /// <summary>
        /// Save the database properties
        /// </summary>
        public void Save()
        {

        }

        /// <summary>
        /// Connect to the database
        /// </summary>
        public void Connect()
        {
            string connString = "Server = " + m_Server + "; Port = " + m_Port + "; Database = " + m_DatabaseName + "; Uid = " + m_User + "; Pwd = " + m_Password + "";

            m_Connection = new MySqlConnection(connString);
            m_Connection.Open();
        }
        /// <summary>
        /// Disconnects the current database session.
        /// </summary>
        public void Disconnect()
        {
            m_Connection.Close();
        }
        /// <summary>
        /// Gets a value telling if database connector is currently connected to database.
        /// </summary>
        public Boolean IsConnected
        {
            get
            {
                if (m_Connection.State != ConnectionState.Broken && m_Connection.State != ConnectionState.Closed)
                    return true;
                else
                    return false;
            }
        }
        public MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, m_Connection);

            return command.ExecuteReader();
        }

        /// <summary>
        /// Execute a query
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="dataReader">Return a datareader</param>
        public void ExecuteQuery(string query, out MySqlDataReader dataReader)
        {
            MySqlCommand command = new MySqlCommand(query, m_Connection);

            dataReader = command.ExecuteReader();
        }

        /// <summary>
        /// Execute a query
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="dataReader">Return a datatable</param>
        public void ExecuteQuery(string query, out DataTable dataTable)
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, m_Connection);
            DataSet dts = new DataSet("dataset");

            dataAdapter.Fill(dts);
            if (dts.Tables[0].Rows.Count > 0)
            {
                dataTable = dts.Tables[0];
            }
            else
            {
                dataTable = null;
            }
        }

        public void ExecuteNonQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, m_Connection);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Load the database properties
        /// </summary>
        public void Load()
        {
            string filePath = "Database.xml";

            if (!File.Exists(filePath))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlElement root = doc["Database"];

            m_Server = root.ChildNodes[0].InnerText;
            m_Port = root.ChildNodes[1].InnerText;
            m_User = root.ChildNodes[2].InnerText;
            m_Password = root.ChildNodes[3].InnerText;
            m_DatabaseName = root.ChildNodes[4].InnerText;
        }
    }
}
