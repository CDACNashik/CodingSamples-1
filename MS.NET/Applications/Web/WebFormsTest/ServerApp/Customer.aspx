<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="ServerApp.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ServerApp</title>
</head>
<body>
    <h1>Welcome Customer</h1>
    <form id="form1" runat="server">
        <asp:Login ID="CustomerLogin" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" DestinationPageUrl="~/Protected/Order.aspx" DisplayRememberMe="False" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="CustomerLogin_Authenticate" TitleText="" UserNameLabelText="Customer ID:" >
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
        </asp:Login>
    </form>
</body>
</html>
