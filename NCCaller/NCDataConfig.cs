using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

namespace NCCaller
{
    class NCDataItemConfig
    {
        private XmlElement m_Elem = null;

        public NCDataItemConfig(XmlElement elem)
        {
            m_Elem = elem;
        }

        public override string ToString()
        {
            return Type;
        }

        public string Type
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["type"].Value;
            }
        }

        public string Subscribe
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["subscribe"].Value;
            }
        }

        public string Source
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["source"].Value;
            }
        }

        public string GetMethod
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["getmethod"].Value;
            }
        }

        public string ConfirmMethod
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["confirmmethod"].Value;
            }
        }

        public string KeyField
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["keyfield"].Value;
            }
        }

        public string StatusField
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["statusfield"].Value;
            }
        }

        public string Target
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["target"].Value;
            }
        }

        public string XSLT
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["xslt"].Value;
            }
        }

        public string XmlType
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["xmltype"].Value;
            }
        }

        public string RelationField
        {
            get
            {
                if (m_Elem == null)
                    return "";
                else
                    return m_Elem.Attributes["relationfiled"].Value;
            }
        }
    }

    class NCDataConfig : XmlDocument
    {
        public NCDataConfig()
        {
        }

        public NCDataConfig(string strFile)
        {
            Open(strFile);
        }

        public void Open(string strFile)
        {
            if (Path.GetPathRoot(strFile) == "")
            {   // Relative path
                string strCurPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                strFile = Path.Combine(strCurPath, strFile);
            }
            Load(strFile);
        }

        public NCDataItemConfig[] GetDatas()
        {
            XmlNodeList nodes = SelectNodes("NCDataConfig/data");
            if (nodes == null || nodes.Count < 1)
                return null;
            NCDataItemConfig[] datas = new NCDataItemConfig[nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                NCDataItemConfig data = new NCDataItemConfig(nodes[i] as XmlElement);
                datas[i] = data;
            }
            return datas;
        }

        internal NCDataItemConfig[] FindDataBySubTgt(string subTgt)
        {
            XmlNodeList nodes = SelectNodes(string.Format("NCDataConfig/data[@subscribe='{0}']", subTgt));
            if (nodes == null || nodes.Count < 1)                             
                return null;
            NCDataItemConfig[] datas = new NCDataItemConfig[nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                NCDataItemConfig data = new NCDataItemConfig(nodes[i] as XmlElement);
                datas[i] = data;
            }
            return datas;
        }        
    }
}
