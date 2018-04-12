<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            类型：<asp:TextBox ID="txtType" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp; PlanOrder&nbsp;&nbsp;PlanUpdate&nbsp; AlloyElement&nbsp;&nbsp; AllNCData<br />
            <br />
            上传的xml：<asp:FileUpload ID="uploadXML" runat="server" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Button ID="Button1" runat="server" Text="提交" Width="55px" />
            <br />

        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
