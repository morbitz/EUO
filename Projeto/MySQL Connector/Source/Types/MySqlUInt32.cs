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
using MySql.Data.MySqlClient;
using System.Globalization;

namespace MySql.Data.Types
{
	internal struct MySqlUInt32 : IMySqlValue
	{
		private uint mValue;
		private bool isNull;
		private bool is24Bit;

		private MySqlUInt32(MySqlDbType type)
		{
			is24Bit = type == MySqlDbType.Int24 ? true : false;
			isNull = true;
			mValue = 0;
		}

		public MySqlUInt32(MySqlDbType type, bool isNull)
			: this(type)
		{
			this.isNull = isNull;
		}

		public MySqlUInt32(MySqlDbType type, uint val)
			: this(type)
		{
			this.isNull = false;
			mValue = val;
		}

		#region IMySqlValue Members

		public bool IsNull
		{
			get { return isNull; }
		}

		MySqlDbType IMySqlValue.MySqlDbType
		{
			get { return MySqlDbType.UInt32; }
		}

		DbType IMySqlValue.DbType
		{
			get { return DbType.UInt32; }
		}

		object IMySqlValue.Value
		{
			get { return mValue; }
		}

		public uint Value
		{
			get { return mValue; }
		}

		Type IMySqlValue.SystemType
		{
			get { return typeof(UInt32); }
		}

		string IMySqlValue.MySqlTypeName
		{
			get { return is24Bit ? "MEDIUMINT" : "INT"; }
		}

		void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object v, int length)
		{
			uint val = Convert.ToUInt32(v);
			if (binary)
				stream.Write(BitConverter.GetBytes(val));
			else
				stream.WriteStringNoNull(val.ToString());
		}

		IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal)
		{
			if (nullVal)
				return new MySqlUInt32((this as IMySqlValue).MySqlDbType, true);

			if (length == -1)
				return new MySqlUInt32((this as IMySqlValue).MySqlDbType,
					 (uint)stream.ReadInteger(4));
			else
				return new MySqlUInt32((this as IMySqlValue).MySqlDbType,
					 UInt32.Parse(stream.ReadString(length),
					 CultureInfo.InvariantCulture));
		}

		void IMySqlValue.SkipValue(MySqlStream stream)
		{
			stream.SkipBytes(4);
		}

		#endregion

		internal static void SetDSInfo(DataTable dsTable)
		{
			string[] types = new string[] { "MEDIUMINT", "INT" };
			MySqlDbType[] dbtype = new MySqlDbType[] { MySqlDbType.UInt24, 
                MySqlDbType.UInt32 };

			// we use name indexing because this method will only be called
			// when GetSchema is called for the DataSourceInformation 
			// collection and then it wil be cached.
			for (int x = 0; x < types.Length; x++)
			{
				DataRow row = dsTable.NewRow();
				row["TypeName"] = types[x];
				row["ProviderDbType"] = dbtype[x];
				row["ColumnSize"] = 0;
				row["CreateFormat"] = types[x] + " UNSIGNED";
				row["CreateParameters"] = null;
				row["DataType"] = "System.UInt32";
				row["IsAutoincrementable"] = true;
				row["IsBestMatch"] = true;
				row["IsCaseSensitive"] = false;
				row["IsFixedLength"] = true;
				row["IsFixedPrecisionScale"] = true;
				row["IsLong"] = false;
				row["IsNullable"] = true;
				row["IsSearchable"] = true;
				row["IsSearchableWithLike"] = false;
				row["IsUnsigned"] = true;
				row["MaximumScale"] = 0;
				row["MinimumScale"] = 0;
				row["IsConcurrencyType"] = DBNull.Value;
				row["IsLiteralsSupported"] = false;
				row["LiteralPrefix"] = null;
				row["LiteralSuffix"] = null;
				row["NativeDataType"] = null;
				dsTable.Rows.Add(row);
			}
		}
	}
}
