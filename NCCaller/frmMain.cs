using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Web;
using System.Net;
using System.Configuration;
using System.Reflection;
using System.Threading;

namespace NCCaller
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private AliveNotifier m_AliveMoniter = null;

        public static DataTable InStoredt = new DataTable();
        public static DataTable Irondt = new DataTable();
        public static DataTable Qualitydt = new DataTable();
        public static DataTable Allreturndt = new DataTable();

        private NCDataConfig m_Cfg = null;

        private void ConnectMES()
        {
            if (L3Session.Opened)
            {
                pbMESStatus.Image = MainResources.button_green.ToBitmap();
            }
            else
            {
                L3Session.ConnectionStr = Properties.Settings.Default.MESServer;
                L3Session.User = Properties.Settings.Default.Account;
                L3Session.Password = Properties.Settings.Default.Password;
                pbMESStatus.Image = MainResources.button_yellow.ToBitmap();
                if (L3Session.Open() != 0)
                {   // Cannot connect to AppServer
                    pbMESStatus.Image = MainResources.button_red.ToBitmap();
                }
                else
                {   // Connected to AppServer
                    pbMESStatus.Image = MainResources.button_green.ToBitmap();
                }
            }
            try
            {
                AppSvrIF.Command cmdNull = new AppSvrIF.Command();
                cmdNull.Type = (int)AppSvrIF.CommandType.Empty;
                L3Session.Execute(cmdNull);
            }
            catch { }            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ConnectMES();
            m_AliveMoniter = new AliveNotifier(L3Session);
            m_AliveMoniter.L3Session = L3Session;
            m_AliveMoniter.Start();

            m_Cfg = new NCDataConfig("NCData.config");
            string strDataDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
            string strDataFail = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataFailed");
            Directory.CreateDirectory(strDataDir);
            Directory.CreateDirectory(strDataFail);

            ConnectMES();
            txtMESServer.Text = L3Session.ConnectionStr;
            txtNCServer.Text = Properties.Settings.Default.NCServer;

            pbNCStatus.Image = MainResources.button_blue.ToBitmap();

            NCDataItemConfig[] datas = m_Cfg.GetDatas();
            foreach (NCDataItemConfig data in datas)
            {
                string subtgt = data.Subscribe;
                string[] items = subtgt.Split('.');
                L3Session.Subscribe(items[0], items[1], AppSvrIF.SubscribeType.Change);
                lstTypes.Items.Add(data);
            }
        }

        private void Adapter_OnObjectPropChanged(string strObj, string strProp, object newVal, object oldVal)
        {
            //取出入库时需要上传的炉次号并反写标志
            AppSvrIF.Command cmdInstore = null;
            AppSvrIF.Command cmdInstoreComfirm = null;
            int iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "GetInStore", ref cmdInstore);
            if (iRet != 0)
                return;
            iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "ConfirmInStore", ref cmdInstoreComfirm);
            if (iRet != 0)
                return;
            L3Session.Execute(cmdInstore);
            DataSet dsInstore = cmdInstore.Return as DataSet;
            if (dsInstore != null)
            {
                if (dsInstore.Tables.Count > 0)
                {
                    DataTable tbData2 = dsInstore.Tables[0];
                    if (tbData2.Rows.Count > 0)
                    {
                        foreach (DataRow tbrow in tbData2.Rows)
                        {
                            tbrow["NC_Confirm_Flag"] = "1";
                        }
                        InStoredt.Merge(tbData2);
                        cmdInstoreComfirm.set_Parameters(0, dsInstore);
                        L3Session.Execute(cmdInstoreComfirm);
                    }
                }
            }

            //取出铁水需要上传的炉次号并反写标志
            AppSvrIF.Command cmdIron = null;
            AppSvrIF.Command cmdIronComfirm = null;
            iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "GetIron", ref cmdIron);
            if (iRet != 0)
                return;
            iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "ConfirmIron", ref cmdIronComfirm);
            if (iRet != 0)
                return;
            L3Session.Execute(cmdIron);
            DataSet dsIron = cmdIron.Return as DataSet;
            if (dsIron != null)
            {
                if (dsIron.Tables.Count > 0)
                {
                    DataTable tbData = dsIron.Tables[0];
                    if (tbData.Rows.Count > 0)
                    {
                        Irondt.Merge(tbData);
                        cmdIronComfirm.set_Parameters(0, dsIron);
                        L3Session.Execute(cmdIronComfirm);
                    }
                }
            }

            //取出库内改判炉号并反写标志
            AppSvrIF.Command cmdQuality = null;
            AppSvrIF.Command cmdQualityComfirm = null;
            iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "GetInStoreQuality", ref cmdQuality);
            if (iRet != 0)
                return;
            iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "ConfirmInStoreQuality", ref cmdQualityComfirm);
            if (iRet != 0)
                return;
            L3Session.Execute(cmdQuality);
            DataSet dsQuality = cmdQuality.Return as DataSet;
            if (dsQuality != null)
            {
                if (dsQuality.Tables.Count > 0)
                {
                    DataTable tbData1 = dsQuality.Tables[0];
                    if (tbData1.Rows.Count > 0)
                    {
                        foreach (DataRow tbrow in tbData1.Rows)
                        {
                            tbrow["NC_Confirm_Flag"] = "1";
                        }
                        Qualitydt.Merge(tbData1);
                        cmdQualityComfirm.set_Parameters(0, dsQuality);
                        L3Session.Execute(cmdQualityComfirm);
                    }
                }
            }

            //取出全回炉时需要上传的炉次号并反写标志
            AppSvrIF.Command cmdAll = null;
            AppSvrIF.Command cmdAllComfirm = null;
            iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "GetAllReturn", ref cmdAll);
            if (iRet != 0)
                return;
            iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "ConfirmAllReturn", ref cmdAllComfirm);
            if (iRet != 0)
                return;
            L3Session.Execute(cmdAll);
            DataSet dsAll = cmdAll.Return as DataSet;
            if (dsAll != null)
            {
                if (dsAll.Tables.Count > 0)
                {
                    DataTable tbData3 = dsAll.Tables[0];
                    if (tbData3.Rows.Count > 0)
                    {
                        foreach (DataRow tbrow in tbData3.Rows)
                        {
                            tbrow["NC_Confirm_Flag"] = "1";
                        }
                        Allreturndt.Merge(tbData3);
                        cmdAllComfirm.set_Parameters(0, dsAll);
                        L3Session.Execute(cmdAllComfirm);
                    }
                }
            }
        }

        private string TranslateDataToNC(NCDataItemConfig item, DataTable data)
        {
            System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
            trans.Load(item.XSLT);
            string strTmpDir = Path.GetTempPath();
            string strLogDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
            string strDataFile = Path.Combine(strTmpDir, "MES_Data.xml");
            string strXmlFile = Path.Combine(strLogDir, string.Format("{0}_{1}.xml", item.Type, DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            data.WriteXml(strDataFile);
            trans.Transform(strDataFile, strXmlFile);
            return strXmlFile;
        }

        //private string TranslateDataSetToNC(NCDataItemConfig item, DataSet data)
        //{
        //    System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
        //    trans.Load(item.XSLT);
        //    string strTmpDir = Path.GetTempPath();
        //    string strLogDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
        //    string strDataFile = Path.Combine(strTmpDir, "MES_Data.xml");
        //    string strXmlFile = Path.Combine(strLogDir, string.Format("{0}_{1}.xml", item.Type, DateTime.Now.ToString("yyyyMMddHHmmssfff")));
        //    data.WriteXml(strDataFile);
        //    trans.Transform(strDataFile, strXmlFile);
        //    return strXmlFile;
        //}



        /// <summary>
        ///    返回转换后的xml路径   xsl 可方便的将一种格式的xml，转换成另一种格式的xml
        /// </summary>
        /// <param name="strxslt"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private string TranslateDataSetToNC(string strxslt, DataSet data)
        {
            System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
            trans.Load(strxslt);
            string strTmpDir = Path.GetTempPath();
            //string strLogDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
            string strLogDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);           
            string strXmlFile = Path.Combine(strLogDir, string.Format("{0}.xml", "MES_Data"));

            //DataSet data 转换成xml 文件路径
            string strDataFile = Path.Combine(strTmpDir, "MES_Data.xml");
            data.WriteXml(strDataFile);

            trans.Transform(strDataFile, strXmlFile);
            return strXmlFile;
        }

        private string XmlGetElement(XmlDocument doc, string value)
        {
            XmlNode root = doc.DocumentElement.FirstChild;
            IEnumerator ienum = root.GetEnumerator();
            XmlElement book = null;
            while (ienum.MoveNext())
            {
                book = (XmlElement)ienum.Current;
                if (book.Name.Equals(value))
                {
                    // MessageBox.Show(book.InnerText);
                    //string strRet = book.InnerText.ToString();
                    //writelog(strRet);   
                    break;
                }

            }

            return (book != null) ? book.InnerText : null;
        }

        private bool TransferXML(string strXML, string strHeatID, string strType, string strXslt)
        {
            try
            {
                System.IO.FileStream file = new System.IO.FileStream(strXML, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                file.Seek(0, System.IO.SeekOrigin.Begin);
                int iLen = (int)file.Length;
                byte[] data = new byte[iLen];
                file.Read(data, 0, iLen);
                file.Close();

                string strURI = Properties.Settings.Default.NCServer;
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURI);
                if (request == null)
                {
                    dsLog.Clear();
                    DataRow row = dsLog.Tables[0].NewRow();
                    row["HeatID"] = strHeatID;
                    row["BillType"] = strXslt;
                    row["Other1"] = strType;
                    row["Flag"] = "1";
                    row["Remark"] = "访问NC服务器失败";
                    dsLog.Tables[0].Rows.Add(row);
                    WtritReturnLogFromNC(dsLog);
                    return false;
                }
                request.Method = "POST";
                request.ContentType = "text/xml; charset=gb2312";
                request.ContentLength = iLen;
                request.Timeout = 500000; // 500秒 

                try
                {
                    System.IO.Stream postDataStream = request.GetRequestStream();
                    postDataStream.Write(data, 0, iLen);
                    postDataStream.Close();
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    //string strRet = e.Message.ToString();
                    //writelog(strRet);

                    dsLog.Clear();
                    DataRow row = dsLog.Tables[0].NewRow();
                    row["HeatID"] = strHeatID;
                    row["BillType"] = strXslt;
                    row["Other1"] = strType;
                    row["Flag"] = "1";
                    row["Remark"] = e.Message.ToString();
                    dsLog.Tables[0].Rows.Add(row);
                    WtritReturnLogFromNC(dsLog);

                    return false;
                }

                //Get answer
                System.Net.HttpWebResponse resp;
                try
                {
                    resp = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException err)
                {
                    //MessageBox.Show(err.Status + " - " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //string strRet = err.Message.ToString();
                    //writelog(strRet);                    

                    resp = (HttpWebResponse)err.Response;
                    if (resp == null)
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = err.Message.ToString();
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);

                        return false;
                    }
                }
                catch (Exception err)
                {
                    //MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //string strRet = err.Message.ToString();
                    //writelog(strRet);
                    dsLog.Clear();
                    DataRow row = dsLog.Tables[0].NewRow();
                    row["HeatID"] = strHeatID;
                    row["BillType"] = strXslt;
                    row["Other1"] = strType;
                    row["Flag"] = "1";
                    row["Remark"] = err.Message.ToString();
                    dsLog.Tables[0].Rows.Add(row);
                    WtritReturnLogFromNC(dsLog);

                    return false;
                }


                Stream rcvStream = resp.GetResponseStream();
                byte[] respBytes = new byte[256];
                int byteCount;

                StringBuilder builder = new StringBuilder();
                do
                {
                    byteCount = rcvStream.Read(respBytes, 0, 256);
                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                    string inputString = encoding.GetString(respBytes);
                    builder.Append(inputString);

                } while (byteCount > 0);

                XmlDocument doc = new XmlDocument();
                string xmlRet = builder.ToString();
                int iPos = xmlRet.IndexOf(@"</ufinterface>");
                xmlRet = xmlRet.Substring(0, iPos + ((string)@"</ufinterface>").Length);
                doc.LoadXml(xmlRet);

                string tok = XmlGetElement(doc, "resultcode");
                string resultCont = XmlGetElement(doc, "resultdescription");
                resultCont = resultCont.Replace("\r\n", "");
                resultCont = resultCont.Replace("\t", "");
                resp.Close();
                rcvStream.Close();

                //返回正确写日志，否则丢弃
                if (!tok.Equals("1"))
                {
                    //MessageBox.Show(string.Format("调用NC接口错误！{0}\r{1}", tok, resultCont));
                    //string strRet = "调用NC接口错误:" + resultCont;
                    //writelog(strRet);
                    dsLog.Clear();
                    DataRow row = dsLog.Tables[0].NewRow();
                    row["HeatID"] = strHeatID;
                    row["BillType"] = strXslt;
                    row["Other1"] = strType;
                    row["Flag"] = "1";
                    row["Remark"] = resultCont;
                    dsLog.Tables[0].Rows.Add(row);
                    WtritReturnLogFromNC(dsLog);
                    return false;
                }
                else
                {
                    dsLog.Clear();
                    DataRow row = dsLog.Tables[0].NewRow();
                    row["HeatID"] = strHeatID;
                    row["BillType"] = strXslt;
                    row["Other1"] = strType;
                    row["Flag"] = "0";
                    dsLog.Tables[0].Rows.Add(row);
                    WtritReturnLogFromNC(dsLog);
                    return true;
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(this, e.ToString(), "Error");
                //string strRet = e.ToString();
                //writelog(strRet);

                dsLog.Clear();
                DataRow row = dsLog.Tables[0].NewRow();
                row["HeatID"] = strHeatID;
                row["BillType"] = strXslt;
                row["Other1"] = strType;
                row["Flag"] = "1";
                row["Remark"] = e.ToString();
                dsLog.Tables[0].Rows.Add(row);
                WtritReturnLogFromNC(dsLog);

                return false;
            }
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            timerCheck.Stop();
            ConnectMES();
            RefreshLogs();
            //向NC发送数据
            MesStoreDataSendToNC();
            MesIronDataSendToNC();
            MesQualityDataSendToNC();
            MesAllReturnSendToNC();
            timerCheck.Start();
        }

        private void RefreshLogs()
        {
            lstSent.Items.Clear();
            lstFailed.Items.Clear();
            if (lstTypes.SelectedItem == null)
                return;

            NCDataItemConfig item = lstTypes.SelectedItem as NCDataItemConfig;
            if (item == null)
                return;

            string type = item.Type;
            string strDataDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
            string strDataFail = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataFailed");

            // List Sent data
            string[] fileSent = Directory.GetFiles(strDataDir, string.Format("{0}*.xml", type));
            foreach (string strfile in fileSent)
            {
                lstSent.Items.Add(strfile);
            }
            // List failed data
            string[] fileFailed = Directory.GetFiles(strDataFail, string.Format("{0}*.xml", type));
            foreach (string strfile in fileFailed)
            {
                lstFailed.Items.Add(strfile);
            }
        }

        private void LogFile_DoubleClicked(object sender, EventArgs e)
        {
            ListBox lst = sender as ListBox;
            if (lst.SelectedItem == null)
                return;

            string strDir = "";
            if (lst == lstSent)
            {
                strDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
            }
            else if (lst == lstFailed)
            {
                strDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataFailed");
            }
            string strFile = lst.SelectedItem.ToString();
            string strPath = Path.Combine(strDir, strFile);

            System.Diagnostics.Process.Start(strPath);
        }

        private void bbtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WtritReturnLogFromNC(DataSet dt)
        {
            AppSvrIF.Command cmdLog = null;
            int iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "WriteLogFromNC", ref cmdLog);
            if (iRet != 0)
                return;
            cmdLog.set_Parameters(0, dt);
            L3Session.Execute(cmdLog);
        }

        private void MesStoreDataSendToNC()
        {
            string strXslt = "";
            string Method = "";
            DataTable dt = new DataTable();
            dt = InStoredt.Copy();
            InStoredt.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strHeatID = dt.Rows[i]["HeatID"].ToString();
                    string strType = "1";
                    //订单
                    strXslt = @"MillPlanToNC.xslt";
                    AppSvrIF.Command cmdPlanOrder = null;
                    int iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "SendPlanInfor", ref cmdPlanOrder);
                    if (iRet != 0)
                        continue;
                    cmdPlanOrder.set_Parameters(0, strHeatID);
                    L3Session.Execute(cmdPlanOrder);

                    DataSet dsPlanOrder = cmdPlanOrder.Return as DataSet;
                    if (dsPlanOrder != null && dsPlanOrder.Tables.Count > 0 && dsPlanOrder.Tables[0].Rows.Count > 0)
                    {

                        string strXML = TranslateDataSetToNC(strXslt, dsPlanOrder);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }
                    //投料
                    strXslt = @"BOFAddMaterialsInforToNC.xslt";
                    Method = "SendAddMaterialsInfor";
                    DataSet dsM = new DataSet();
                    dsM = MesDs(strHeatID, Method);
                    if (dsM != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsM);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }

                    //完工
                    strXslt = @"BloomInfor.xslt";
                    Method = "SendBloomInfor";
                    DataSet dsB = new DataSet();
                    dsB = MesDs(strHeatID, Method);
                    if (dsB != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsB);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }

                    //质检
                    strXslt = @"QualityJudgeInfor.xslt";
                    Method = "SendQualityJudgeInfor";
                    DataSet dsQ = new DataSet();
                    dsQ = QualityDs(strHeatID, Method, "0");
                    if (dsQ != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsQ);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }

                    //入库
                    strXslt = @"BloomInStoreInfor.xslt";
                    Method = "SendBloomInStoreInfor";
                    DataSet dsI = new DataSet();
                    dsI = MesDs(strHeatID, Method);
                    if (dsI != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsI);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }
                }
            }
        }

        private void MesQualityDataSendToNC()
        {
            string strXslt = "";
            string Method = "";
            DataTable dt = new DataTable();
            dt = Qualitydt.Copy();
            Qualitydt.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strHeatID = dt.Rows[i]["HeatID"].ToString();
                    string strType = "1";

                    //入库改判质检
                    strXslt = @"InStoreQualityInfor.xslt";
                    Method = "SendQualityJudgeInfor";
                    DataSet dsQ = new DataSet();
                    dsQ = QualityDs(strHeatID, Method, "1");
                    if (dsQ != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsQ);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }
                }
            }
        }

        private void MesIronDataSendToNC()
        {
            string strXslt = "";
            string Method = "";
            DataTable dt = new DataTable();
            dt = Irondt.Copy();
            Irondt.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strHeatID = dt.Rows[i]["HeatID"].ToString();
                    string strType = "2";
                    //完工
                    strXslt = @"IronBloomInfor.xslt";
                    Method = "SendIronBloomInfor";
                    DataSet dsB = new DataSet();
                    dsB = MesDs(strHeatID, Method);
                    if (dsB != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsB);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }

                    //质检
                    strXslt = @"IronQualityJudgeInfor.xslt";
                    Method = "SendIronQualityJudgeInfor";
                    DataSet dsQ = new DataSet();
                    dsQ = MesDs(strHeatID, Method);
                    if (dsQ != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsQ);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }

                    //入库
                    strXslt = @"IronBloomInStoreInfor.xslt";
                    Method = "SendIronBloomInStoreInfor";
                    DataSet dsI = new DataSet();
                    dsI = MesDs(strHeatID, Method);
                    if (dsI != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsI);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }
                }
            }
        }

        private void MesAllReturnSendToNC()
        {
            string strXslt = "";
            string Method = "";
            DataTable dt = new DataTable();
            dt = Allreturndt.Copy();
            Allreturndt.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strHeatID = dt.Rows[i]["HeatID"].ToString();
                    string strType = "1";
                    //订单
                    strXslt = @"MillPlanToNC.xslt";
                    AppSvrIF.Command cmdPlanOrder = null;
                    int iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", "SendPlanInfor", ref cmdPlanOrder);
                    if (iRet != 0)
                        continue;
                    cmdPlanOrder.set_Parameters(0, strHeatID);
                    L3Session.Execute(cmdPlanOrder);

                    DataSet dsPlanOrder = cmdPlanOrder.Return as DataSet;
                    if (dsPlanOrder != null && dsPlanOrder.Tables.Count > 0 && dsPlanOrder.Tables[0].Rows.Count > 0)
                    {

                        string strXML = TranslateDataSetToNC(strXslt, dsPlanOrder);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }
                    //投料
                    strXslt = @"BOFAddMaterialsInforToNC.xslt";
                    Method = "SendAddMaterialsInfor";
                    DataSet dsM = new DataSet();
                    dsM = MesDs(strHeatID, Method);
                    if (dsM != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsM);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }

                    //完工
                    strXslt = @"BloomInfor.xslt";
                    Method = "SendBloomInfor";
                    DataSet dsB = new DataSet();
                    dsB = MesDs(strHeatID, Method);
                    if (dsB != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsB);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }

                    //入库
                    strXslt = @"BloomInStoreInfor.xslt";
                    Method = "SendBloomInStoreInfor";
                    DataSet dsI = new DataSet();
                    dsI = MesDs(strHeatID, Method);
                    if (dsI != null)
                    {
                        string strXML = TranslateDataSetToNC(strXslt, dsI);
                        TransferXML(strXML, strHeatID, strType, strXslt);
                    }
                    else
                    {
                        dsLog.Clear();
                        DataRow row = dsLog.Tables[0].NewRow();
                        row["HeatID"] = strHeatID;
                        row["BillType"] = strXslt;
                        row["Other1"] = strType;
                        row["Flag"] = "1";
                        row["Remark"] = "在MES中没有查询出相应的数据";
                        dsLog.Tables[0].Rows.Add(row);
                        WtritReturnLogFromNC(dsLog);
                    }
                }
            }
        }

        private DataSet MesDs(string strHeatID, string strMethod)
        {
            AppSvrIF.Command cmdMaterial = null;
            int iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", strMethod, ref cmdMaterial);
            if (iRet != 0)
                return null;
            cmdMaterial.set_Parameters(0, strHeatID);
            L3Session.Execute(cmdMaterial);
            if (strMethod == "SendIronQualityJudgeInfor")
            {
                //主表
                DataSet dsMain = cmdMaterial.Return as DataSet;
                if (dsMain == null)
                    return null;
                if (dsMain.Tables.Count < 1)
                    return null;
                //从表1
                DataSet dsReturn1 = cmdMaterial.get_Parameters(1) as DataSet;
                if (dsReturn1 == null)
                    return null;
                if (dsReturn1.Tables.Count < 1)
                    return null;
                //从表2
                DataSet dsReturn2 = cmdMaterial.get_Parameters(2) as DataSet;
                if (dsReturn2 == null)
                    return null;
                if (dsReturn2.Tables.Count < 1)
                    return null;
                DataSet dsM = new DataSet();
                //组织主表记录集
                DataTable tbM = new DataTable();
                tbM = dsMain.Tables[0].Clone();
                tbM = dsMain.Tables[0].Copy();
                tbM.TableName = "M";
                dsM.Tables.Add(tbM);
                //组织从表1记录集
                DataTable tbS = new DataTable();
                tbS = dsReturn1.Tables[0].Clone();
                tbS = dsReturn1.Tables[0].Copy();
                tbS.TableName = "s1";
                dsM.Tables.Add(tbS);
                //组织从表2记录集
                DataTable tbS1 = new DataTable();
                tbS1 = dsReturn2.Tables[0].Clone();
                tbS1 = dsReturn2.Tables[0].Copy();
                tbS1.TableName = "s2";
                dsM.Tables.Add(tbS1);

                return dsM;
            }
            else
            {
                //主表
                DataSet dsMain = cmdMaterial.get_Parameters(1) as DataSet;
                if (dsMain == null)
                    return null;
                if (dsMain.Tables.Count < 1)
                    return null;
                //从表
                DataSet dsReturn = cmdMaterial.Return as DataSet;
                if (dsReturn == null)
                    return null;
                if (dsReturn.Tables.Count < 1)
                    return null;
                DataSet dsM = new DataSet();
                //组织主表记录集
                DataTable tbM = new DataTable();
                tbM = dsMain.Tables[0].Clone();
                tbM = dsMain.Tables[0].Copy();
                tbM.TableName = "M";
                dsM.Tables.Add(tbM);
                //组织从表记录集
                DataTable tbS = new DataTable();
                tbS = dsReturn.Tables[0].Clone();
                tbS = dsReturn.Tables[0].Copy();
                tbS.TableName = "s1";
                dsM.Tables.Add(tbS);

                return dsM;
            }
        }

        /// <summary>
        /// 组织主从表   L3Command的返回值是主表 第二个第三个引用参数为从表 写L3Command方法是关键
        /// </summary>
        /// <param name="strHeatID"></param>
        /// <param name="strMethod"></param>
        /// <param name="strQualityType"></param>
        /// <returns></returns>
        private DataSet QualityDs(string strHeatID, string strMethod, string strQualityType)
        {
            AppSvrIF.Command cmdMaterial = null;
            int iRet = L3Session.CreateCommand((int)AppSvrIF.CommandType.Call, @"XGMESLogic\BaseDataMag\CBaseData_Mag\BaseData_Mag", strMethod, ref cmdMaterial);
            if (iRet != 0)
                return null;
            cmdMaterial.set_Parameters(0, strHeatID);
            cmdMaterial.set_Parameters(3, strQualityType);
            L3Session.Execute(cmdMaterial);

            //主表
            DataSet dsMain = cmdMaterial.Return as DataSet;
            if (dsMain == null)
                return null;
            if (dsMain.Tables.Count < 1)
                return null;
            //从表1
            DataSet dsReturn1 = cmdMaterial.get_Parameters(1) as DataSet;
            if (dsReturn1 == null)
                return null;
            if (dsReturn1.Tables.Count < 1)
                return null;
            //从表2
            DataSet dsReturn2 = cmdMaterial.get_Parameters(2) as DataSet;
            if (dsReturn2 == null)
                return null;
            if (dsReturn2.Tables.Count < 1)
                return null;
            DataSet dsM = new DataSet();
            //组织主表记录集
            DataTable tbM = new DataTable();
            tbM = dsMain.Tables[0].Clone();
            tbM = dsMain.Tables[0].Copy();
            tbM.TableName = "M";
            dsM.Tables.Add(tbM);
            //组织从表1记录集
            DataTable tbS = new DataTable();
            tbS = dsReturn1.Tables[0].Clone();
            tbS = dsReturn1.Tables[0].Copy();
            tbS.TableName = "s1";
            dsM.Tables.Add(tbS);
            //组织从表2记录集
            DataTable tbS1 = new DataTable();
            tbS1 = dsReturn2.Tables[0].Clone();
            tbS1 = dsReturn2.Tables[0].Copy();
            tbS1.TableName = "s2";
            dsM.Tables.Add(tbS1);

            return dsM;
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_AliveMoniter.Stop();
        }
    }
}