namespace MesCall
{
    using AppSvrIF;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Web.Configuration;

    public class MESAgent
    {
        private Session m_Session = new Session();

        public MESAgent()
        {
            string str = ConfigurationManager.AppSettings["MESServer"];
            string str2 = ConfigurationManager.AppSettings["Account"];
            string str3 = ConfigurationManager.AppSettings["Password"];
            this.m_Session.ConnectionStr = str;
            this.m_Session.User = str2;
            this.m_Session.Password = str3;
        }

        public int SendToMES(string type, DataTable tb)
        {
            MESIFDataConfigSection webApplicationSection = WebConfigurationManager.GetWebApplicationSection("MESIFDataConfigSection") as MESIFDataConfigSection;
            if (webApplicationSection == null)
            {
                return -1;
            }
            MESIFDataConfigElement element = webApplicationSection.MESIFDatas[type];
            if (element == null)
            {
                return -2;
            }
            string str = element.Target.Trim();
            string target = element.Method.Trim();
            if (((str == null) || (target == null)) || ((str.Length < 1) || (target.Length < 1)))
            {
                return -3;
            }
            int num = this.m_Session.Open();
            if (num != 0)
            {
                return num;
            }
            Command cmd = null;
            num = this.m_Session.CreateCommand(5, str, target, ref cmd);
            if (num != 0)
            {
                return num;
            }
            if (cmd.ParameterCount != 1)
            {
                return -3;
            }
            DataSet set = new DataSet("L3DataSet");
            DataTable table = tb.Clone();
            table.Merge(tb);
            table.TableName = "L3DataTable";
            set.Tables.Add(table);
            cmd.set_Parameters(0, set);
            num = this.m_Session.Execute(cmd);
            if (num != 0)
            {
                return num;
            }
            if (!Convert.ToBoolean(cmd.Return))
            {
                return (int) cmd.ErrorCode;
            }
            this.m_Session.Close();
            return 0;
        }
    }
}

