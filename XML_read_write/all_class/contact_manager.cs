using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace XML_read_write.all_class
{
    internal static class contact_manager
    {
        public static void get_list_file(ComboBox cb)
        {
            cb.Items.Clear();
            string[] file_list = Directory.GetFiles(@"store\");
            foreach (string file in file_list)
            {
                cb.Items.Add(Path.GetFileName(file));
            }
        }
        public static int create_file(string file_path)
        {
            if(!File.Exists(file_path))
            {
                XmlDocument newXmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = newXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement rootElement = newXmlDoc.CreateElement("xml_doc");
                newXmlDoc.AppendChild(xmlDeclaration);
                newXmlDoc.AppendChild(rootElement);
                newXmlDoc.Save(file_path);

                return 1;
            }

            return 0;
        }

        public static void load_xml(DataGrid dg, string file_path)
        {
            List<contact_item> contact_Items = new List<contact_item>();
            XDocument xDocument = XDocument.Load(file_path);
  
            foreach (XElement childElement in xDocument.Descendants("xml_doc"))
            {
                try
                {
                    contact_item item = new contact_item();
                    item.Id = childElement.Element("id").Value;
                    item.F_name = childElement.Element("first_name").Value;
                    item.L_name = childElement.Element("last_name").Value;
                    item.Gender = childElement.Element("gender").Value;
                    item.Phone = childElement.Element("phone").Value;
                    
                    contact_Items.Add(item);                 
                }
                catch { }
            }
  
            dg.ItemsSource = contact_Items;
        }

        public static void add_xml(contact_item contact, string file_path)
        {
            XDocument doc = XDocument.Load(file_path);
            doc.Root.Add(
                new XElement(
                    "xml_doc",
                    new XElement("id", contact.Id),
                    new XElement("first_name", contact.F_name),
                    new XElement("last_name", contact.L_name),
                    new XElement("gender", contact.Gender),
                    new XElement("phone", contact.Phone)
                    )
                );
            doc.Save(file_path);
        }
    }
}
