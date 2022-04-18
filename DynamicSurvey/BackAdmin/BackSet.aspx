<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackSet.aspx.cs" Inherits="DynamicSurvey.BackAdmin.BackSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblCaptionName" runat="server" Text="問卷名稱"></asp:Label><asp:TextBox ID="txtSetCaption" runat="server"></asp:TextBox><br>
        <asp:Label ID="lblContent" runat="server" Text="描述內容"></asp:Label><asp:TextBox ID="txtSetContent" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblStartTime" runat="server" Text="開始時間"></asp:Label><asp:TextBox ID="txtSetStartTime" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblEndTime" runat="server" Text="結束時間"></asp:Label><asp:TextBox ID="txtSetEndTime" runat="server"></asp:TextBox><br />
        <asp:CheckBox ID="ckbIsEnable" runat="server" Text="已啟用" /><asp:Button ID="btnSend" runat="server" Text="送出"  BackColor="#00CC00" OnClick="btnSend_Click" /><asp:Button ID="btnCancel" runat="server" Text="取消" />



    </form>
</body>
</html>
