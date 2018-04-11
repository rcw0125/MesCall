namespace MesCall
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Xml;

    public class _Default : Page
    {
        protected HtmlForm form1;
        protected TextBox txtType;
        protected FileUpload uploadXML;

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Send();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.IsPostBack)
            {
                this.Send();
            }
        }

        protected void Send()
        {
            string str = base.Request.Url.ToString();
            string fileName = Path.GetFileName(base.Request.FilePath);
            int index = str.IndexOf(fileName);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(str.Substring(0, index) + string.Format("MESDataIF.aspx?type={0}", this.txtType.Text));
            if (request != null)
            {
                HttpWebResponse response;
                int num2;
                request.Method = "POST";
                request.ContentType = "text/xml; charset=utf-8";
                request.ContentLength = this.uploadXML.FileContent.Length;
                try
                {
                    Stream requestStream = request.GetRequestStream();
                    byte[] buffer = new byte[this.uploadXML.FileContent.Length];
                    this.uploadXML.FileContent.Read(buffer, 0, (int) this.uploadXML.FileContent.Length);
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                }
                catch (Exception exception)
                {
                    base.Response.Write(exception.Message);
                    base.Response.End();
                    return;
                }
                try
                {
                    response = (HttpWebResponse) request.GetResponse();
                }
                catch (WebException exception2)
                {
                    base.Response.Write(exception2.Message);
                    base.Response.End();
                    return;
                }
                catch (Exception exception3)
                {
                    base.Response.Write(exception3.Message);
                    base.Response.End();
                    return;
                }
                Stream responseStream = response.GetResponseStream();
                byte[] buffer2 = new byte[0x100];
                StringBuilder builder = new StringBuilder();
                do
                {
                    num2 = responseStream.Read(buffer2, 0, 0x100);
                    string str4 = Encoding.UTF8.GetString(buffer2);
                    builder.Append(str4);
                }
                while (num2 > 0);
                XmlDocument document = new XmlDocument();
                string xml = builder.ToString();
                document.LoadXml(xml);
                XmlElement element = document.SelectSingleNode("return") as XmlElement;
                string str6 = element.Attributes["code"].Value;
                string s = element.Attributes["message"].Value;
                if (!str6.Equals("1"))
                {
                    base.Response.Write("失败:");
                    base.Response.Write(s);
                    base.Response.End();
                }
                else
                {
                    base.Response.Write("成功");
                }
            }
        }
    }
}

