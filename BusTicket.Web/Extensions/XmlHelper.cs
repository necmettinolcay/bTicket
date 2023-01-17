using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace BusTicket.Web.Extensions
{
    public static class XmlHelper
    {
        public static XmlElement StrToXmlElement(string str)
        {
            XmlDocument xd = new XmlDocument();
            
            try
            {
                xd.LoadXml(str);
            }
            catch
            {
                throw;
            }

            return xd.DocumentElement;
        }

        public static DataSet XmlNodeToDataset(XmlNode xmlNode)
        {
            DataSet ds = new DataSet();
            XmlNodeReader nr = new XmlNodeReader(xmlNode);

            try
            {
                ds.ReadXml(nr);
            }
            catch
            {
                throw;
            }

            return ds;
        }

        public static XmlElement UserPasswordXmlElement()
        {
            return XmlHelper.StrToXmlElement("<Kullanici><Adi>" + "user" + "</Adi><Sifre>" + "password" + "</Sifre></Kullanici>");
        }
    }
}
