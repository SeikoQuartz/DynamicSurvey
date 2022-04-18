<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontList.aspx.cs" Inherits="DynamicSurvey.Front.FrontList" %>

<%@ Register Src="~/ShareControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>前台列表頁</h1>
    <form id="form1" runat="server">
        <div>

            <asp:PlaceHolder ID="SearchingBlock" runat="server">
                <p>
                    <asp:Label ID="lblCaption" runat="server" Text="問卷標題" Width="150px"></asp:Label>
                    <asp:TextBox ID="txtCaption" runat="server" Width="200px"></asp:TextBox>
                </p>
                <asp:Label ID="lblSEDate" runat="server" Text="開始/結束日" Width="150px"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" Width="100px"></asp:TextBox>
                <asp:TextBox ID="txtEndDate" runat="server" Width="100px"></asp:TextBox>
                <asp:Button ID="btnSearachSurvey" runat="server" Text="搜尋" />
            </asp:PlaceHolder>

            <asp:GridView ID="GridSurveyList" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>

                    <asp:BoundField DataField="SurveyNumber" HeaderText="SurveyNumber" SortExpression="SurveyNumber" />

                    <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                    <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                    <asp:BoundField DataField="Caption" HeaderText="Caption" SortExpression="Caption" />
                    <asp:CheckBoxField DataField="IsEnable" HeaderText="IsEnable" SortExpression="IsEnable" />
                    <asp:TemplateField HeaderText="觀看統計">
                        <ItemTemplate>
                            <%--  <%# Eval("BookID") %>: 資料繫結運算式  --%>
                            <a href="FrontSum.aspx?ID=<%# Eval("QuestionID") %>">前往</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SurveyConnectionString %>" SelectCommand="SELECT * FROM [FirstTry]"></asp:SqlDataSource>
            <uc1:ucPager runat="server" ID="ucPager" PageSize="10" />
        </div>

    </form>
</body>
</html>
