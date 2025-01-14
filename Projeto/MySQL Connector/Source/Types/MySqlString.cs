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
using System.IO;
using MySql.Data.MySqlClient;

namespace MySql.Data.Types
{
	internal struct MySqlString : IMySqlValue
	{
		private string mValue;
		private bool isNull;
		private MySqlDbType type;

		public MySqlString(MySqlDbType type, bool isNull)
		{
			this.type = type;
			this.isNull = isNull;
			mValue = String.Empty;
		}

		public MySqlString(MySqlDbType type, string val)
		{
			this.type = type;
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
			get { return type; }
		}

		DbType IMySqlValue.DbType
		{
			get { return DbType.String; }
		}

		object IMySqlValue.Value
		{
			get { return mValue; }
		}

		public string Value
		{
			get { return mValue; }
		}

		Type IMySqlValue.SystemType
		{
			get { return typeof(string); }
		}

		string IMySqlValue.MySqlTypeName
		{
			get { return type == MySqlDbType.Set ? "SET" : type == MySqlDbType.Enum ? "ENUM" : "VARCHAR"; }
		}

		private string EscapeString(string s)
		{
			s = s.Replace("\\", "\\\\");
			s = s.Replace("\'", "\\\'");
			s = s.Replace("\"", "\\\"");
			s = s.Replace("`", "\\`");
			s = s.Replace("�", "\\�");
			s = s.Replace("�", "\\�");
			s = s.Replace("�", "\\�");
			return s;
		}

		void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object val, int length)
		{
			string v = val.ToString();
            if (length > 0)
            {
                length = Math.Min(length, v.Length);
                v = v.Substring(0, length);
            }

			if (binary)
				stream.WriteLenString(v);
			else
				stream.WriteStringNoNull("'" + EscapeString(v) + "'");
		}

		IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal)
		{
			if (nullVal)
				return new MySqlString(type, true);

			string s = String.Empty;
			if (length == -1)
				s = stream.ReadLenString();
			else
				s = stream.ReadString(length);
			MySqlString str = new MySqlString(type, s);
			return str;
		}

		void IMySqlValue.SkipValue(MySqlStream stream)
		{
			long len = stream.ReadFieldLength();
			stream.SkipBytes((int)len);
		}

		#endregion

		internal static void SetDSInfo(DataTable dsTable)
		{
			string[] types = new string[] { "CHAR", "VARCHAR", "SET", "ENUM" };
			MySqlDbType[] dbtype = new MySqlDbType[] { MySqlDbType.String, 
                MySqlDbType.VarChar, MySqlDbType.Set, MySqlDbType.Enum };

			// we use name indexing because this method will only be called
			// when GetSchema is called for the DataSourceInformation 
			// collection and then it wil be cached.
			for (int x = 0; x < types.Length; x++)
			{
				DataRow row = dsTable.NewRow();
				row["TypeName"] = types[x];
				row["ProviderDbType"] = dbtype[x];
				row["ColumnSize"] = 0;
                row["CreateFormat"] = x < 2 ? types[x] + "({0})" : types[x];
				row["CreateParameters"] = x < 2 ? "size" : null;
				row["DataType"] = "System.String";
				row["IsAutoincrementable"] = false;
				row["IsBestMatch"] = true;
				row["IsCaseSensitive"] = false;
				row["IsFixedLength"] = false;
				row["IsFixedPrecisionScale"] = true;
				row["IsLong"] = false;
				row["IsNullable"] = true;
				row["IsSearchable"] = true;
				row["IsSearchableWithLike"] = true;
				row["IsUnsigned"] = false;
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
