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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace MySql.Data.Common
{
	/// <summary>
	/// Summary description for StreamCreator.
	/// </summary>
	internal class StreamCreator
	{
		string hostList;
		uint port;
		string pipeName;
		uint timeOut;

		public StreamCreator(string hosts, uint port, string pipeName)
		{
			hostList = hosts;
			if (hostList == null || hostList.Length == 0)
				hostList = "localhost";
			this.port = port;
			this.pipeName = pipeName;
		}

		public Stream GetStream(uint timeOut)
		{
			this.timeOut = timeOut;

			if (hostList.StartsWith("/"))
				return CreateSocketStream(null, 0, true);

			string[] dnsHosts = hostList.Split('&');

			System.Random random = new Random((int)DateTime.Now.Ticks);
			int index = random.Next(dnsHosts.Length);
			int pos = 0;
			bool usePipe = (pipeName != null && pipeName.Length != 0);
			Stream stream = null;

			while (pos < dnsHosts.Length)
			{
				if (usePipe)
					stream = CreateNamedPipeStream(dnsHosts[index]);
				else
				{
#if NET20
                    IPHostEntry ipHE = GetHostEntry(dnsHosts[index]);
#else
				    IPHostEntry ipHE = Dns.GetHostByName(dnsHosts[index]);
#endif

					foreach (IPAddress address in ipHE.AddressList)
					{
						// MySQL doesn't currently support IPv6 addresses
						if (address.AddressFamily == AddressFamily.InterNetworkV6)
							continue;

						stream = CreateSocketStream(address, port, false);
						if (stream != null)
							break;
					}
				}
				if (stream != null)
					break;
				index++;
				if (index == dnsHosts.Length)
					index = 0;
				pos++;
			}

			return stream;
		}

        private IPHostEntry GetHostEntry(string hostname)
        {
            IPAddress addr = null;
            IPHostEntry ipHE;
            if (IPAddress.TryParse(hostname, out addr))
            {
                ipHE = new IPHostEntry();
                ipHE.AddressList = new IPAddress[1];
                ipHE.AddressList[0] = addr;
            }
            else
                ipHE = Dns.GetHostEntry(hostname);
            return ipHE;
        }

		private Stream CreateNamedPipeStream(string hostname)
		{
			string pipePath;
			if (0 == String.Compare(hostname, "localhost", true))
				pipePath = @"\\.\pipe\" + pipeName;
			else
				pipePath = String.Format(@"\\{0}\pipe\{1}", hostname.ToString(), pipeName);
			return new NamedPipeStream(pipePath, FileAccess.ReadWrite);
		}

		private EndPoint CreateUnixEndPoint(string host)
		{
			// first we need to load the Mono.posix assembly
#if NET20
			Assembly a = Assembly.Load("Mono.Posix");
#else
			Assembly a = Assembly.LoadWithPartialName("Mono.Posix");
#endif

			// then we need to construct a UnixEndPoint object
			EndPoint ep = (EndPoint)a.CreateInstance("Mono.Posix.UnixEndPoint",
				false, BindingFlags.CreateInstance, null,
				new object[1] { host }, null, null);
			return ep;
		}

		private Stream CreateSocketStream(IPAddress ip, uint port, bool unix)
		{
			EndPoint endPoint;

			if (!Platform.IsWindows() && unix)
				endPoint = CreateUnixEndPoint(hostList);
			else
				endPoint = new IPEndPoint(ip, (int)port);

			Socket socket = unix ?
				new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.IP) :
				new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IAsyncResult ias = socket.BeginConnect(endPoint, null, null);
			if (!ias.AsyncWaitHandle.WaitOne((int)timeOut * 1000, false))
			{
				socket.Close();
				return null;
			}
			try
			{
				socket.EndConnect(ias);
			}
			catch (Exception)
			{
				socket.Close();
				return null;
			}
            NetworkStream stream = new NetworkStream(socket, true);
            GC.SuppressFinalize(socket);
            GC.SuppressFinalize(stream);
            return stream;
		}

	}
}
