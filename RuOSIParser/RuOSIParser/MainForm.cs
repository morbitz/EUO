using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RuOSIParser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void buttonImportar_Click(object sender, EventArgs e)
        {

            //WebClient wc = new WebClient();
            //FileInfo fi = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "packetguide.xml"));
            //if (fi.Exists) fi.Delete();
            //wc.Headers.Clear();
            //wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            //wc.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            //wc.Headers.Add("Accept-Language", "pt-BR,pt;q=0.8,en-US;q=0.6,en;q=0.4");
            //wc.Headers.Add("Cache-Control", "max-age=0");
            //wc.Headers.Add("User-Agent", "Mozilla/1.22 (compatible; MSIE 2.0; Windows 3.1)");

            //wc.OpenReadCompleted += (s, ev) =>
            //{
            //    byte[] imageBytes = new byte[9999999];
            //    ev.Result.Read(imageBytes, 0, imageBytes.Length);

            //    // Now you can use the returned stream to set the image source too
            //    BinaryWriter bw = new BinaryWriter(new StreamWriter(fi.FullName).BaseStream);
            //    bw.Write(imageBytes);
            //    bw.Close();

            //    fi = new FileInfo(Path.Combine(Application.StartupPath, "index.xml"));

            //    XDocument xDoc = XDocument.Load(fi.FullName);

            //    if (xDoc.Root != null)
            //    {
            //        var types = from x in xDoc.Root.Descendants() let attribute = x.Attribute("type") where attribute != null select attribute.Value;
            //        foreach (var v in types)
            //        {
            //            listBoxClasses.Items.Add(v);
            //        }
            //    }
            //};
            //wc.OpenReadAsync(new Uri(textBoxURL.Text));
            /*
            wc.DownloadFile(textBoxURL.Text, fi.FullName);
            */

            FileInfo fi = new FileInfo(Path.Combine(Application.StartupPath, "index.xml"));

            XmlDocument doc = new XmlDocument();

            doc.Load(fi.FullName);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Packets/Packet");
            List<String> classes = new List<string>(); 
            foreach (XmlNode node in nodes)
            {
                ClassGenerator cg = new ClassGenerator();
                cg.Namespace = "RuOSI";
                cg.Inheritance = "Packet";
                var selectSingleNode = node.SelectSingleNode("Name");
                if (selectSingleNode != null) cg.ClassName = selectSingleNode.InnerText.Replace(" ", "");
                var singleNode = node.SelectSingleNode("Description");
                if (singleNode != null) cg.Description = singleNode.InnerText;

                var xmlNodeList = node.SelectNodes("Data");
                if (xmlNodeList != null)
                    foreach (XmlNode prop in xmlNodeList)
                    {
                        if (prop.Attributes != null)
                            cg.PublicAttributes.Add(new Tuple<String, String>(prop.Attributes["type"].Value,prop.InnerText.Split(':')[0].Split('(')[0].Replace(" ","").Trim()));
                    }
                classes.Add(cg);
            }
        }
    }
}