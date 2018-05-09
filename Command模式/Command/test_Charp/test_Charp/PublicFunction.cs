using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace test_Charp
{
    public class PublicFunction
    {
        public static String server = ".//config//server.xml";
        public static String conString = null;
        public static String shareFolder = null;
        public PublicFunction()
        {

        }

        public static bool LoadConfig()
        {
             XmlDocument xml = new XmlDocument();
             String ip = null;
             String db = null;
             String user = null;
             String passwd = null;

             bool ret = false;
             try
             {
                 xml.Load(server);

                 XmlNode root = xml.SelectSingleNode("server");
                 ip = root["ip"].InnerText;
                 db = root["db"].InnerText;
                 user = root["user"].InnerText;
                 passwd = root["passwd"].InnerText;

                 conString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
				                       ip, db, user, passwd);

                 shareFolder = "\\\\"+ip + "\\yikatongPIC";
                 ret = true;

             } catch (Exception exp) {

             }
             return ret;
        }
    }
}
