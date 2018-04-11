namespace MesCall
{
    using System;
    using System.Data;
    using System.IO;
    using System.Web.UI;
    using System.Xml;

    public class MESDataIF : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsCallback)
            {
                try
                {
                    XmlDocument document = new XmlDocument();
                    XmlElement newChild = document.CreateElement("return");
                    document.AppendChild(newChild);
                    XmlAttribute node = document.CreateAttribute("code");
                    XmlAttribute attribute2 = document.CreateAttribute("message");
                    newChild.Attributes.Append(node);
                    newChild.Attributes.Append(attribute2);
                    bool flag = true;
                    DataSet set = new DataSet();
                    try
                    {
                        set.ReadXml(base.Request.InputStream);
                    }
                    catch (Exception exception)
                    {
                        node.Value = "-1";
                        attribute2.Value = exception.Message;
                        flag = false;
                    }
                    string name = base.Request.Params["type"];
                    if ((set.Tables.Count < 1) || !set.Tables.Contains(name))
                    {
                        node.Value = "-1";
                        attribute2.Value = string.Format("Table {0} not exist in the received data!", name);
                        flag = false;
                    }
                    if (flag)
                    {
                        int num = new MESAgent().SendToMES(name, set.Tables[name]);
                        if (num != 0)
                        {
                            node.Value = num.ToString();
                            attribute2.Value = "Call MES server failed!";
                            flag = false;
                        }
                        else
                        {
                            node.Value = "1";
                            attribute2.Value = "Success";
                            flag = true;
                        }
                    }
                    string fileName = "";
                    if (flag)
                    {
                        DateTime now = DateTime.Now;
                        string path = base.Server.MapPath("DataReceived");
                        Directory.CreateDirectory(path);
                        fileName = Path.Combine(path, string.Format("{0}_{1}.xml", name, now.ToString("yyyyMMddHHmmssfff")));
                        set.WriteXml(fileName);
                    }
                    StringWriter writer = new StringWriter();
                    document.Save(writer);
                    writer.ToString();
                    base.Response.ContentType = "text/xml";
                    document.Save(base.Response.OutputStream);
                }
                catch (Exception exception2)
                {
                    base.Response.Write(exception2.Message);
                }
            }
        }
    }
}

