using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuOSIParser
{
    public class ClassGenerator
    {
        private const String ident = "    ";
        private const String lb = "\n";
        private Int32 _placeholder = 0;
        public Int32 Level { get; set; }
        public String Description { get; set; }
        public String ClassName { get; set; }
        public String Namespace { get; set; }
        public String Inheritance { get; set; }
        public List<Tuple<String,String>> PublicAttributes {get;set;}
        public List<Tuple<String, String>> PrivateAttributes {get;set;}
        public static implicit operator String(ClassGenerator cg)
        {
            return cg.Class;
        }

        public override string ToString()
        {
            return Class;
        }
        private String id
        {
            get
            {
                String ret = "";
                for (int i = 0; i < Level; i++)
                {
                    ret += ident;
                }
                return ret;
            }
        }

        public String Class
        {
            get
            {
                Level = 0;
                _placeholder = 0;
                String classe = "";
                if (!String.IsNullOrEmpty(Namespace))
                {
                    classe += id + "namespace " + Namespace + lb + "{" + lb; //namespace
                    Level++;
                }
                classe += id + "public classe " + ClassName +
                         (String.IsNullOrEmpty(Inheritance) ? "" : " : " + Inheritance) +
                         (String.IsNullOrEmpty(Description) ? " // " + Description : "") + lb;
                classe += id + "{" + lb; //classe
                Level++;
                foreach (Tuple<String, String> att in PrivateAttributes)
                {
                    classe += id + GetType(att.Item1) + " m_" + GetName(att.Item2) + ";" + lb;
                }

                foreach (Tuple<String, String> att in PublicAttributes)
                {
                    classe += id + GetType(att.Item1) + " " + GetName(att.Item2) + lb;
                }

                classe += id + "public " + ClassName + "{}" + lb; //Construtor

                Level--;
                classe += id + "}" + lb; //classe
                if (!String.IsNullOrEmpty(Namespace))
                {
                    Level--;
                    classe += id + "}" + lb; //namespace
                }
                return classe;
            }
        }

        private String GetName(String xml)
        {
            if (xml.StartsWith("0") || xml.StartsWith("1") || xml.StartsWith("2") || xml.StartsWith("3") || xml.StartsWith("4") || xml.StartsWith("5") || xml.StartsWith("6") || xml.StartsWith("7") || xml.StartsWith("8") || xml.StartsWith("9"))
            {
                return "Placeholder" + _placeholder++ + " = " + xml;
            }
            else
            {
                return xml + "{ get; set; }";
            }
        }
        private String GetType(String xml)
        {
            String type = "";
            switch (xml.ToLower())
            {
                case "word":
                    type = "Int16";
                    break;
                case "dword":
                    type = "Int32";
                    break;
                case "qword":
                    type = "Int64";
                    break;
                case "char":
                    type = "byte";
                    break;
                case "uchar":
                    type = "char";
                    break;
                case "sbyte":
                    type = "sbyte";
                    break;
                default:
                    type = xml;
                    break;
            }
            return type;
        }
        public ClassGenerator()
        {
            PublicAttributes = new List<Tuple<String,String>>();
            PrivateAttributes = new List<Tuple<String,String>>();
            Level = 0;
        }
    }
}
