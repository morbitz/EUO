// Copyright (C) 2004-2007 MySQL AB
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 2 as published by
// the Free Software Foundation
//
// There are special exceptions to the terms and conditions of the GPL 
// as it is applied to this software. View the full text of the 
// exception in file EXCEPTIONS in the directory of this software 
// distribution.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Specialized;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using MySql.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

namespace MySql.Data.MySqlClient
{
    /// <include file='docs/MySqlConnection.xml' path='docs/ClassSummary/*'/>
#if !PocketPC
    [System.Drawing.ToolboxBitmap(typeof(MySqlConnection), "MySqlClient.resources.connection.bmp")]
    [System.ComponentModel.DesignerCategory("Code")]
    [ToolboxItem(true)]
#endif
    public sealed class MySqlConnection : DbConnection, ICloneable
    {
        internal ConnectionState connectionState;
        internal Driver driver;
        private MySqlDataReader dataReader;
        private MySqlConnectionStringBuilder settings;
        private UsageAdvisor advisor;
        private bool hasBeenOpen;
        private SchemaProvider schemaProvider;
        private ProcedureCache procedureCache;
        private PerformanceMonitor perfMonitor;
        private MySqlPromotableTransaction currentTransaction;
        private bool isExecutingBuggyQuery;
        private string database;

        /// <include file='docs/MySqlConnection.xml' path='docs/InfoMessage/*'/>
        public event MySqlInfoMessageEventHandler InfoMessage;

        private static Cache connectionStringCache = new Cache(0, 25);

#if MONO2
        /// <include file='docs/MySqlConnection.xml' path='docs/StateChange/*'/>
        public event StateChangeEventHandler StateChange;
#endif

        /// <include file='docs/MySqlConnection.xml' path='docs/DefaultCtor/*'/>
        public MySqlConnection()
        {
            //TODO: add event data to StateChange docs
            settings = new MySqlConnectionStringBuilder();
            advisor = new UsageAdvisor(this);
            database = String.Empty;
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/Ctor1/*'/>
        public MySqlConnection(string connectionString)
            : this()
        {
            ConnectionString = connectionString;
        }

        #region Interal Methods & Properties

        internal MySqlPromotableTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }

        internal ProcedureCache ProcedureCache
        {
            get { return procedureCache; }
        }

        internal MySqlConnectionStringBuilder Settings
        {
            get { return settings; }
        }

        internal MySqlDataReader Reader
        {
            get { return dataReader; }
            set { dataReader = value; }
        }

        internal char ParameterMarker
        {
            get { if (settings.UseOldSyntax) return '@'; return '?'; }
        }

        internal void OnInfoMessage(MySqlInfoMessageEventArgs args)
        {
            if (InfoMessage != null)
            {
                InfoMessage(this, args);
            }
        }

        internal PerformanceMonitor PerfMonitor
        {
            get { return perfMonitor; }
        }

        internal bool IsExecutingBuggyQuery
        {
            get { return isExecutingBuggyQuery; }
            set { isExecutingBuggyQuery = value; }
        }

        #endregion

        #region Properties

#if !PocketPC
        [Browsable(false)]
#endif
        internal UsageAdvisor UsageAdvisor
        {
            get { return advisor; }
        }

        /// <summary>
        /// Returns the id of the server thread this connection is executing on
        /// </summary>
#if !PocketPC
        [Browsable(false)]
#endif
        public int ServerThread
        {
            get { return driver.ThreadID; }
        }

        /// <summary>
        /// Gets the name of the MySQL server to which to connect.
        /// </summary>
#if !PocketPC
        [Browsable(true)]
#endif
        public override string DataSource
        {
            get { return settings.Server; }
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/ConnectionTimeout/*'/>
#if !PocketPC
        [Browsable(true)]
#endif
        public override int ConnectionTimeout
        {
            get { return (int)settings.ConnectionTimeout; }
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/Database/*'/>
#if !PocketPC
        [Browsable(true)]
#endif
        public override string Database
        {
            get { return database; }
        }

        /// <summary>
        /// Indicates if this connection should use compression when communicating with the server.
        /// </summary>
#if !PocketPC
        [Browsable(false)]
#endif
        public bool UseCompression
        {
            get { return settings.UseCompression; }
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/State/*'/>
#if !PocketPC
        [Browsable(false)]
#endif
        public override ConnectionState State
        {
            get { return connectionState; }
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/ServerVersion/*'/>
#if !PocketPC
        [Browsable(false)]
#endif
        public override string ServerVersion
        {
            get { return driver.Version.ToString(); }
        }

        internal Encoding Encoding
        {
            get
            {
                if (driver == null)
                    return System.Text.Encoding.Default;
                else
                    return driver.Encoding;
            }
        }


        /// <include file='docs/MySqlConnection.xml' path='docs/ConnectionString/*'/>
#if !PocketPC
        [Editor("MySql.Data.MySqlClient.Design.ConnectionStringTypeEditor,MySqlClient.Design", typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true)]
        [Category("Data")]
        [Description("Information used to connect to a DataSource, such as 'Server=xxx;UserId=yyy;Password=zzz;Database=dbdb'.")]
#endif
        public override string ConnectionString
        {
            get
            {
                // Always return exactly what the user set.
                // Security-sensitive information may be removed.
                return settings.GetConnectionString(!hasBeenOpen || settings.PersistSecurityInfo);
            }
            set
            {
                if (this.State != ConnectionState.Closed)
                    throw new MySqlException(
                        "Not allowed to change the 'ConnectionString' property while the connection (state=" + State +
                        ").");

                MySqlConnectionStringBuilder newSettings;
                lock (connectionStringCache)
                {
                    newSettings = (MySqlConnectionStringBuilder)connectionStringCache[value];
                    if (null == newSettings)
                    {
                        newSettings = new MySqlConnectionStringBuilder(value);
                        connectionStringCache.Add(value, newSettings);
                    }
                }

                settings = newSettings;

                if (settings.Database != null && settings.Database.Length > 0)
                    this.database = settings.Database;

                if (driver != null)
                    driver.Settings = newSettings;
            }
        }

        #endregion

        #region Transactions

#if !MONO
        /// <summary>
        /// Enlists in the specified transaction. 
        /// </summary>
        /// <param name="transaction">
        /// A reference to an existing <see cref="System.Transactions.Transaction"/> in which to enlist.
        /// </param>
        public override void EnlistTransaction(System.Transactions.Transaction transaction)
        {
            // if the transaction given to us is null, then there is nothing to do.
            if (transaction == null)
                return;

            if (currentTransaction != null)
            {
                if (currentTransaction.BaseTransaction == transaction)
                    return;

                throw new MySqlException("Already enlisted");
            }

            MySqlPromotableTransaction t = new MySqlPromotableTransaction(this, transaction);
            transaction.EnlistPromotableSinglePhase(t);
            currentTransaction = t;
        }
#endif

        /// <include file='docs/MySqlConnection.xml' path='docs/BeginTransaction/*'/>
        public new MySqlTransaction BeginTransaction()
        {
            return BeginTransaction(IsolationLevel.RepeatableRead);
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/BeginTransaction1/*'/>
        public new MySqlTransaction BeginTransaction(IsolationLevel iso)
        {
            //TODO: check note in help
            if (State != ConnectionState.Open)
                throw new InvalidOperationException(Resources.ConnectionNotOpen);

            // First check to see if we are in a current transaction
            if ((driver.ServerStatus & ServerStatusFlags.InTransaction) != 0)
                throw new InvalidOperationException(Resources.NoNestedTransactions);

            MySqlTransaction t = new MySqlTransaction(this, iso);

            MySqlCommand cmd = new MySqlCommand("", this);

            cmd.CommandText = "SET SESSION TRANSACTION ISOLATION LEVEL ";
            switch (iso)
            {
                case IsolationLevel.ReadCommitted:
                    cmd.CommandText += "READ COMMITTED"; break;
                case IsolationLevel.ReadUncommitted:
                    cmd.CommandText += "READ UNCOMMITTED"; break;
                case IsolationLevel.RepeatableRead:
                    cmd.CommandText += "REPEATABLE READ"; break;
                case IsolationLevel.Serializable:
                    cmd.CommandText += "SERIALIZABLE"; break;
                case IsolationLevel.Chaos:
                    throw new NotSupportedException(Resources.ChaosNotSupported);
            }

            cmd.ExecuteNonQuery();

            cmd.CommandText = "BEGIN";
            cmd.ExecuteNonQuery();

            return t;
        }

        #endregion

        /// <include file='docs/MySqlConnection.xml' path='docs/ChangeDatabase/*'/>
        public override void ChangeDatabase(string database)
        {
            if (database == null || database.Trim().Length == 0)
                throw new ArgumentException(Resources.ParameterIsInvalid, "database");

            if (State != ConnectionState.Open)
                throw new InvalidOperationException(Resources.ConnectionNotOpen);

            driver.SetDatabase(database);
            this.database = database;
        }

        internal void SetState(ConnectionState newConnectionState, bool broadcast)
        {
            if (newConnectionState == this.connectionState)
                return;
            ConnectionState oldConnectionState = this.connectionState;
            connectionState = newConnectionState;
			if (broadcast)
				OnStateChange(new StateChangeEventArgs(oldConnectionState, this.connectionState));
        }

        /// <summary>
        /// Ping
        /// </summary>
        /// <returns></returns>
        public bool Ping()
        {
            bool result = driver.Ping();
            if (!result)
                SetState(ConnectionState.Closed, true);
            return result;
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/Open/*'/>
        public override void Open()
        {
            if (State == ConnectionState.Open)
                throw new InvalidOperationException(Resources.ConnectionAlreadyOpen);

            SetState(ConnectionState.Connecting, true);

            try
            {
                if (settings.Pooling)
                {
                    MySqlPool pool = MySqlPoolManager.GetPool(settings);
                    driver = pool.GetConnection();
                    procedureCache = pool.ProcedureCache;
                }
                else
                {
                    driver = Driver.Create(settings);
                    procedureCache = new ProcedureCache(settings.ProcedureCacheSize);
                }
            }
            catch (Exception)
            {
                SetState(ConnectionState.Closed, true);
                throw;
            }

            // if the user is using old syntax, let them know
            if (driver.Settings.UseOldSyntax)
                Logger.LogWarning("You are using old syntax that will be removed in future versions");

            SetState(ConnectionState.Open, false);
            driver.Configure(this);
            if (settings.Database != null && settings.Database != String.Empty)
                ChangeDatabase(settings.Database);

            // setup our schema provider
            if (driver.Version.isAtLeast(5, 0, 0))
                schemaProvider = new ISSchemaProvider(this);
            else
                schemaProvider = new SchemaProvider(this);
            perfMonitor = new PerformanceMonitor(this);

            // if we are opening up inside a current transaction, then autoenlist
            // TODO: control this with a connection string option
#if !MONO
            if (System.Transactions.Transaction.Current != null)
                EnlistTransaction(System.Transactions.Transaction.Current);
#endif

            hasBeenOpen = true;
			SetState(ConnectionState.Open, true);
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/CreateCommand/*'/>
        public new MySqlCommand CreateCommand()
        {
            // Return a new instance of a command object.
            MySqlCommand c = new MySqlCommand();
            c.Connection = this;
            return c;
        }

        #region ICloneable
        /// <summary>
        /// Creates a new MySqlConnection object with the exact same ConnectionString value
        /// </summary>
        /// <returns>A cloned MySqlConnection object</returns>
        object ICloneable.Clone()
        {
            MySqlConnection clone = new MySqlConnection();
            clone.ConnectionString = settings.GetConnectionString(true);
            return clone;
        }
        #endregion

        #region IDisposeable

        protected override void Dispose(bool disposing)
        {
            if (disposing && State == ConnectionState.Open)
                Close();
            base.Dispose(disposing);
        }

        #endregion

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            if (isolationLevel == IsolationLevel.Unspecified)
                return BeginTransaction();
            return BeginTransaction(isolationLevel);
        }

        protected override DbCommand CreateDbCommand()
        {
            return CreateCommand();
        }

        internal void Abort()
        {
            try
            {
                if (settings.Pooling)
                    MySqlPoolManager.ReleaseConnection(driver);
                else
                    driver.Close();
            }
            catch (Exception) { }
            SetState(ConnectionState.Closed, true);
        }

        /// <include file='docs/MySqlConnection.xml' path='docs/Close/*'/>
        public override void Close()
        {
            if (State == ConnectionState.Closed) return;

            if (dataReader != null)
                dataReader.Close();

            if (settings.Pooling)
            {
                // if we are in a transaction, roll it back
                if ((driver.ServerStatus & ServerStatusFlags.InTransaction) != 0)
                {
                    MySqlTransaction t = new MySqlTransaction(this, IsolationLevel.Unspecified);
                    t.Rollback();
                }

                MySqlPoolManager.ReleaseConnection(driver);
            }
            else
                driver.Close();

            SetState(ConnectionState.Closed, true);
        }

#if MONO2

        protected void OnStateChange (StateChangeEventArgs stateChangeArgs)
        {
            if (StateChange != null)
                StateChange(this, stateChangeArgs);
        }

#endif

        #region GetSchema Support

        /// <summary>
        /// Returns schema information for the data source of this <see cref="DbConnection"/>. 
        /// </summary>
        /// <returns>A <see cref="DataTable"/> that contains schema information. </returns>
        public override DataTable GetSchema()
        {
            return GetSchema(null);
        }

        /// <summary>
        /// Returns schema information for the data source of this 
        /// <see cref="DbConnection"/> using the specified string for the schema name. 
        /// </summary>
        /// <param name="collectionName">Specifies the name of the schema to return. </param>
        /// <returns>A <see cref="DataTable"/> that contains schema information. </returns>
        public override DataTable GetSchema(string collectionName)
        {
            if (collectionName == null)
                collectionName = SchemaProvider.MetaCollection;

            return GetSchema(collectionName, null);
        }

        /// <summary>
        /// Returns schema information for the data source of this <see cref="DbConnection"/>
        /// using the specified string for the schema name and the specified string array 
        /// for the restriction values. 
        /// </summary>
        /// <param name="collectionName">Specifies the name of the schema to return.</param>
        /// <param name="restrictionValues">Specifies a set of restriction values for the requested schema.</param>
        /// <returns>A <see cref="DataTable"/> that contains schema information.</returns>
        public override DataTable GetSchema(string collectionName, string[] restrictionValues)
        {
            /*            string msg = String.Format("collection = {0}", collectionName);
                        foreach (string s in restrictionValues)
                        {
                            msg += String.Format(" res={0}", s);
                        }
                        MessageBox.Show(msg);
              */
            if (collectionName == null)
                collectionName = SchemaProvider.MetaCollection;

            string[] restrictions = null;
            if (restrictionValues != null)
            {
                restrictions = new string[restrictionValues.Length];
                for (int x = 0; x < restrictionValues.Length; x++)
                {
                    string s = restrictionValues[x];
                    if (s != null)
                    {
                        if (s.StartsWith("`"))
                            s = s.Substring(1);
                        if (s.EndsWith("`"))
                            s = s.Substring(0, s.Length - 1);
                        restrictions[x] = s;
                    }
                }
            }

            DataTable dt = schemaProvider.GetSchema(collectionName, restrictions);
            return dt;
        }

        #endregion

    }

    /// <summary>
    /// Represents the method that will handle the <see cref="MySqlConnection.InfoMessage"/> event of a 
    /// <see cref="MySqlConnection"/>.
    /// </summary>
    public delegate void MySqlInfoMessageEventHandler(object sender, MySqlInfoMessageEventArgs args);

    /// <summary>
    /// Provides data for the InfoMessage event. This class cannot be inherited.
    /// </summary>
    public class MySqlInfoMessageEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public MySqlError[] errors;
    }
}
