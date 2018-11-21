using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace UOPackets
{
    public class Packet
    {
        private Int16 m_PacketSize;
        public Byte[] Data { get; set; }
        public Byte Id { get; set; }
        public Int16 PacketSize
        {
            get { return m_PacketSize; }
            set { m_PacketSize = value; }
        }

        public Packet()
        {
			Data = new Byte[4096];
        }
        public Packet(byte id)
        {
            Id = id;
			Data = new Byte[4096];
            //m_Data = new byte[packetSizes[id]];
        }
        public virtual void Build()
        {

        }
        protected void Insert(String s)
        {
            InsertString(s);
        }
        protected void Insert(String s, Int32 size)
        {
            InsertString(s, size);
        }
        protected void Insert(Char c)
        {
            InsertChar(c);
        }
        protected void Insert(Char [] c)
        {
            InsertChar(c);
        }
        protected void Insert(SByte b)
        {
            InsertSByte(b);
        }
        protected void Insert(SByte [] b)
        {
            InsertSByte(b);
        }
        protected void Insert(Byte b)
        {
            InsertByte(b);
        }
        protected void Insert(Byte[] b)
        {
            InsertByte(b);
        }
        protected void Insert(Int16 word)
        {
            InsertWord(word);
        }
        protected void Insert(Int16 [] word)
        {
            InsertWord(word);
        }
        protected void Insert(Int32 dword)
        {
            InsertDWord(dword);
        }
        protected void Insert(Int32 [] dword)
        {
            InsertDWord(dword);
        }
        protected void Insert(Int64 qword)
        {
            InsertQWord(qword);
        }
        protected void Insert(Int64 [] qword)
        {
            InsertQWord(qword);
        }
		protected void Insert(UInt16 word)
		{
			InsertUWord(word);
		}
		protected void Insert(UInt16[] word)
		{
			InsertUWord(word);
		}
		protected void Insert(UInt32 dword)
		{
			InsertUDWord(dword);
		}
		protected void Insert(UInt32[] dword)
		{
			InsertUDWord(dword);
		}
		protected void Insert(UInt64 qword)
		{
			InsertUQWord(qword);
		}
		protected void Insert(UInt64[] qword)
		{
			InsertUQWord(qword);
		}
        protected void InsertString(String s)
        {
            byte[] st = Encoding.UTF8.GetBytes(s);

            for (int i = 0; i < st.Length; i++)
            {
                Data[m_PacketSize + i] = st[i];
            }

            m_PacketSize += (short)st.Length;
        }
        protected void InsertString(String s, Int32 size)
        {
            byte[] st = Encoding.UTF8.GetBytes(s);

            for (int i = 0; i < st.Length; i++)
            {
                Data[m_PacketSize + i] = st[i];
            }

            m_PacketSize += (short)size;
        }
        protected void InsertChar(Char c)
        {
            Data[m_PacketSize] = Convert.ToByte(c);
            m_PacketSize++;
        }
        protected void InsertChar(Char [] cs)
        {
            foreach (Char c in cs)
            {
                Data[m_PacketSize] = Convert.ToByte(c);
                m_PacketSize++;
            }
        }
        protected void InsertSByte(SByte b)
        {
            Data[m_PacketSize] = (Byte)b;
            m_PacketSize++;
        }
        protected void InsertSByte(SByte[] bs)
        {
            foreach (SByte b in bs)
            {
                InsertSByte(b);
            }
        }
        protected void InsertByte(Byte b)
        {
            Data[m_PacketSize] = b;
            m_PacketSize++;
        }
        protected void InsertByte(Byte[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                Data[m_PacketSize + i] = b[i];
            }

            m_PacketSize += (short)b.Length;
        }
        protected void InsertByte(List<Byte> b)
        {
            for (int i = 0; i < b.Count; i++)
            {
                Data[m_PacketSize + i] = b[i];
            }

            m_PacketSize += (short)b.Count;
        }
        protected void InsertInt16(Int16 word)
        {
            Data[m_PacketSize] = BitConverter.GetBytes(word)[1];
            Data[m_PacketSize + 1] = BitConverter.GetBytes(word)[0];
            m_PacketSize += 2;
        }
        protected void InsertInt16(Int16 []words)
        {
            foreach (Int16 word in words)
            {
                InsertInt16(word);
            }
        }
        protected void InsertInt32(Int32 dword)
        {
            Data[m_PacketSize] = BitConverter.GetBytes(dword)[3];
            Data[m_PacketSize + 1] = BitConverter.GetBytes(dword)[2];
            Data[m_PacketSize + 2] = BitConverter.GetBytes(dword)[1];
            Data[m_PacketSize + 3] = BitConverter.GetBytes(dword)[0];
            m_PacketSize += 4;
        }
        protected void InsertInt32(Int32 [] dwords)
        {
            foreach (Int32 dword in dwords)
            {
                InsertInt32(dword);
            }
        }
        protected void InsertInt64(Int64 qword)
        {
            Data[m_PacketSize] = BitConverter.GetBytes(qword)[7];
            Data[m_PacketSize + 1] = BitConverter.GetBytes(qword)[6];
            Data[m_PacketSize + 2] = BitConverter.GetBytes(qword)[5];
            Data[m_PacketSize + 3] = BitConverter.GetBytes(qword)[4];
            Data[m_PacketSize + 4] = BitConverter.GetBytes(qword)[3];
            Data[m_PacketSize + 5] = BitConverter.GetBytes(qword)[2];
            Data[m_PacketSize + 6] = BitConverter.GetBytes(qword)[1];
            Data[m_PacketSize + 7] = BitConverter.GetBytes(qword)[0];
            m_PacketSize += 8;
        }
        protected void InsertInt64(Int64 [] qwords)
        {
            foreach (Int64 qword in qwords)
            {
                InsertInt64(qword);
            }
        }
        protected void InsertWord(Int16 word)
        {
            InsertInt16(word);
        }
        protected void InsertWord(Int16 [] words)
        {
            InsertInt16(words);
        }
        protected void InsertDWord(Int32 dword)
        {
            InsertInt32(dword);
        }
        protected void InsertDWord(Int32 [] dwords)
        {
            InsertInt32(dwords);
        }
        protected void InsertQWord(Int64 qword)
        {
            InsertInt64(qword);
        }
        protected void InsertQWord(Int64 [] qwords)
        {
            InsertInt64(qwords);
        }
		protected void InsertUInt16(UInt16 word)
		{
			Data[m_PacketSize] = BitConverter.GetBytes(word)[1];
			Data[m_PacketSize + 1] = BitConverter.GetBytes(word)[0];
			m_PacketSize += 2;
		}
		protected void InsertUInt16(UInt16[] words)
		{
			foreach (Int16 word in words)
			{
				InsertInt16(word);
			}
		}
		protected void InsertUInt32(UInt32 dword)
		{
			Data[m_PacketSize] = BitConverter.GetBytes(dword)[3];
			Data[m_PacketSize + 1] = BitConverter.GetBytes(dword)[2];
			Data[m_PacketSize + 2] = BitConverter.GetBytes(dword)[1];
			Data[m_PacketSize + 3] = BitConverter.GetBytes(dword)[0];
			m_PacketSize += 4;
		}
		protected void InsertUInt32(UInt32[] dwords)
		{
			foreach (Int32 dword in dwords)
			{
				InsertInt32(dword);
			}
		}
		protected void InsertUInt64(UInt64 qword)
		{
			Data[m_PacketSize] = BitConverter.GetBytes(qword)[7];
			Data[m_PacketSize + 1] = BitConverter.GetBytes(qword)[6];
			Data[m_PacketSize + 2] = BitConverter.GetBytes(qword)[5];
			Data[m_PacketSize + 3] = BitConverter.GetBytes(qword)[4];
			Data[m_PacketSize + 4] = BitConverter.GetBytes(qword)[3];
			Data[m_PacketSize + 5] = BitConverter.GetBytes(qword)[2];
			Data[m_PacketSize + 6] = BitConverter.GetBytes(qword)[1];
			Data[m_PacketSize + 7] = BitConverter.GetBytes(qword)[0];
			m_PacketSize += 8;
		}
		protected void InsertUInt64(UInt64[] qwords)
		{
			foreach (Int64 qword in qwords)
			{
				InsertInt64(qword);
			}
		}
		protected void InsertUWord(UInt16 word)
		{
			InsertUInt16(word);
		}
		protected void InsertUWord(UInt16[] words)
		{
			InsertUInt16(words);
		}
		protected void InsertUDWord(UInt32 dword)
		{
			InsertUInt32(dword);
		}
		protected void InsertUDWord(UInt32[] dwords)
		{
			InsertUInt32(dwords);
		}
		protected void InsertUQWord(UInt64 qword)
		{
			InsertUInt64(qword);
		}
		protected void InsertUQWord(UInt64[] qwords)
		{
			InsertUInt64(qwords);
		}
		protected void SetBuffer(ref TcpClient t)
		{
			t.SendBufferSize = PacketSize;
			t.Client.SendBufferSize = PacketSize;
			t.SendTimeout = 10;
			t.Client.SendTimeout = 10;
			t.Client.NoDelay = true;
			t.NoDelay = true;
			t.Client.Blocking = false;
		}

    	public void Compress()
        {
			int size = 0;
			byte[] Aux = new byte[m_PacketSize];
			for (int i = 0; i < m_PacketSize; i++)
			{
				Aux[i] = Data[i];
			}
			Data = Compression.Compress(Aux, 0, m_PacketSize, ref size);

			Aux = new byte[size];
			for (int i = 0; i < size; i++)
			{
				Aux[i] = Data[i];
			}
			Data = Aux;

            PacketSize = (short)size;
        }
        public void FixSize()
        {
            Data[1] = BitConverter.GetBytes(PacketSize)[1];
            Data[2] = BitConverter.GetBytes(PacketSize)[0];
        }

		public void Send(TcpClient t)
		{
			//SetBuffer(ref t);
			//t.Client.SendBufferSize = m_PacketSize;
			t.Client.Send(Data, 0, PacketSize, SocketFlags.None);
			//t.Client.Send(Data);
		}
		public void Send(NetworkStream ns)
		{
			while (ns.DataAvailable && ns.ReadByte() != -1)
			{
			}
			ns.Flush();

			ns.Write(Data, 0, PacketSize);
		}


    }
}
