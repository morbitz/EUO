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
using System.Globalization;
using System.Text;
using MySql.Data.Common;
using MySql.Data.Types;

namespace MySql.Data.MySqlClient
{
	internal enum ColumnFlags : int
	{
		NOT_NULL = 1,
		PRIMARY_KEY = 2,
		UNIQUE_KEY = 4,
		MULTIPLE_KEY = 8,
		BLOB = 16,
		UNSIGNED = 32,
		ZERO_FILL = 64,
		BINARY = 128,
		ENUM = 256,
		AUTO_INCREMENT = 512,
		TIMESTAMP = 1024,
		SET = 2048,
		NUMBER = 32768
	};

	/// <summary>
	/// Summary description for Field.
	/// </summary>
	internal class MySqlField
	{
		#region Fields

		// public fields
		public string CatalogName;
		public int ColumnLength;
		public string ColumnName;
		public string OriginalColumnName;
		public string TableName;
		public string RealTableName;
		public string DatabaseName;
		public Encoding Encoding;
		public int maxLength;

		// protected fields
		protected ColumnFlags colFlags;
		protected int charSetIndex;
		protected byte precision;
		protected byte scale;
		protected MySqlDbType mySqlDbType;
		protected DBVersion connVersion;
        protected MySqlConnection connection;
        protected bool binaryOk;

		#endregion

		public MySqlField(MySqlConnection connection)
		{
            this.connection = connection;
            connVersion = connection.driver.Version;
			maxLength = 1;
            binaryOk = true;
		}

		#region Properties

		public int CharacterSetIndex
		{
			get { return charSetIndex; }
			set { charSetIndex = value; }
		}

		public MySqlDbType Type
		{
			get { return mySqlDbType; }
		}

		public byte Precision
		{
			get { return precision; }
			set { precision = value; }
		}

		public byte Scale
		{
			get { return scale; }
			set { scale = value; }
		}

		public int MaxLength
		{
			get { return maxLength; }
			set { maxLength = value; }
		}

		public ColumnFlags Flags
		{
			get { return colFlags; }
		}

		public bool IsAutoIncrement
		{
			get { return (colFlags & ColumnFlags.AUTO_INCREMENT) > 0; }
		}

		public bool IsNumeric
		{
			get { return (colFlags & ColumnFlags.NUMBER) > 0; }
		}

		public bool AllowsNull
		{
			get { return (colFlags & ColumnFlags.NOT_NULL) == 0; }
		}

		public bool IsUnique
		{
			get { return (colFlags & ColumnFlags.UNIQUE_KEY) > 0; }
		}

		public bool IsPrimaryKey
		{
			get { return (colFlags & ColumnFlags.PRIMARY_KEY) > 0; }
		}

		public bool IsBlob
		{
			get
			{
				return (mySqlDbType >= MySqlDbType.TinyBlob &&
				mySqlDbType <= MySqlDbType.Blob) ||
				(mySqlDbType >= MySqlDbType.TinyText &&
				mySqlDbType <= MySqlDbType.Text) ||
				(colFlags & ColumnFlags.BLOB) > 0;
			}
		}

		public bool IsBinary
		{
			get 
            { 
                if (connVersion.isAtLeast(4,1,0))
                    return binaryOk && (CharacterSetIndex == 63);
                return binaryOk && ((colFlags & ColumnFlags.BINARY) > 0); 
            }
		}

		public bool IsUnsigned
		{
			get { return (colFlags & ColumnFlags.UNSIGNED) > 0; }
		}

		public bool IsTextField
		{
			get
			{
				return Type == MySqlDbType.VarString || Type == MySqlDbType.VarChar ||
					 (IsBlob && !IsBinary);
			}
		}

		#endregion

		public void SetTypeAndFlags(MySqlDbType type, ColumnFlags flags)
		{
			colFlags = flags;
			mySqlDbType = type;

            // if our type is an unsigned number, then we need
            // to bump it up into our unsigned types
            // we're trusting that the server is not going to set the UNSIGNED
            // flag unless we are a number
            if (IsUnsigned)
            {
                switch (type)
                {
                    case MySqlDbType.Byte:
                        mySqlDbType = MySqlDbType.UByte; break;
                    case MySqlDbType.Int16:
                        mySqlDbType = MySqlDbType.UInt16; break;
                    case MySqlDbType.Int24:
                        mySqlDbType = MySqlDbType.UInt24; break;
                    case MySqlDbType.Int32:
                        mySqlDbType = MySqlDbType.UInt32; break;
                    case MySqlDbType.Int64:
                        mySqlDbType = MySqlDbType.UInt64; break;
                }
            }

            if (IsBlob && !IsBinary)
            {
                if (type == MySqlDbType.TinyBlob)
                    mySqlDbType = MySqlDbType.TinyText;
                else if (type == MySqlDbType.MediumBlob)
                    mySqlDbType = MySqlDbType.MediumText;
                else if (type == MySqlDbType.Blob)
                    mySqlDbType = MySqlDbType.Text;
                else if (type == MySqlDbType.LongBlob)
                    mySqlDbType = MySqlDbType.LongText;
            }
		}

		public IMySqlValue GetValueObject()
		{
			return GetIMySqlValue(Type);
		}

		public static IMySqlValue GetIMySqlValue(MySqlDbType type)
		{
			switch (type)
			{
				case MySqlDbType.Byte:
					return new MySqlByte();
				case MySqlDbType.UByte: 
                    return new MySqlUByte();
				case MySqlDbType.Int16: 
                    return new MySqlInt16();
				case MySqlDbType.UInt16: 
                    return new MySqlUInt16();
				case MySqlDbType.Int24:
				case MySqlDbType.Int32:
				case MySqlDbType.Year: 
                    return new MySqlInt32(type, true);
				case MySqlDbType.UInt24:
				case MySqlDbType.UInt32: 
                    return new MySqlUInt32(type, true);
				case MySqlDbType.Bit: 
                    return new MySqlBit();
				case MySqlDbType.Int64:
					return new MySqlInt64();
				case MySqlDbType.UInt64: 
                    return new MySqlUInt64();
				case MySqlDbType.Time: 
                    return new MySqlTimeSpan();
				case MySqlDbType.Date:
				case MySqlDbType.Datetime:
				case MySqlDbType.Newdate:
				case MySqlDbType.Timestamp: 
                    return new MySqlDateTime(type, true);
				case MySqlDbType.Decimal:
				case MySqlDbType.NewDecimal:
					return new MySqlDecimal();
				case MySqlDbType.Float: 
                    return new MySqlSingle();
				case MySqlDbType.Double: 
                    return new MySqlDouble();
				case MySqlDbType.Set:
				case MySqlDbType.Enum:
				case MySqlDbType.String:
                case MySqlDbType.VarString:
				case MySqlDbType.VarChar:
                case MySqlDbType.Text:
                case MySqlDbType.TinyText:
                case MySqlDbType.MediumText:
                case MySqlDbType.LongText:
                case (MySqlDbType)Field_Type.NULL:
                    return new MySqlString(type, true);
				case MySqlDbType.Blob:
				case MySqlDbType.MediumBlob:
				case MySqlDbType.LongBlob:
                case MySqlDbType.TinyBlob:
                case MySqlDbType.Binary:
                case MySqlDbType.VarBinary:
                    return new MySqlBinary(type, true);
                default:
                    throw new MySqlException("Unknown data type");
			}
		}
	}

}
