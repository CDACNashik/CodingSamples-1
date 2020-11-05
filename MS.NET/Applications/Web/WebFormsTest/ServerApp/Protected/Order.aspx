<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ServerApp.Protected.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ServerApp</title>
</head>
<body>
    <h1>Welcome Customer <asp:Label ID="CustomerIdLabel" runat="server" /> </h1>
    <form id="form1" runat="server">
        <p>
            <b>Product No</b><br />
            <asp:DropDownList ID="ProductNoDropDownList" runat="server" DataSourceID="ProductDataSource" DataTextField="ProductNo" DataValueField="ProductNo">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ProductDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="ServerApp.Models.ShopDataSetTableAdapters.ProductTableAdapter"></asp:ObjectDataSource>
        </p>
        <p>
            <b>Quantity</b><br />
            <asp:TextBox ID="QuantityTextBox" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="QuantityTextBox" ErrorMessage="*" runat="server" />
            <asp:RegularExpressionValidator ControlToValidate="QuantityTextBox" ValidationExpression="[1-9][0-9]*" ErrorMessage="#" runat="server" />
        </p>
        <p>
            <asp:Button ID="OrderButton" Text="Order" OnClick="OrderButton_Click" runat="server" />
        </p>
        <p>
            <asp:Label ID="OrderResultLabel" runat="server" />
        </p>
    </form>
    <p>
        <asp:HyperLink Text="Your Invoice" NavigateUrl="Invoice.aspx" runat="server" />
    </p>
</body>
</html>
