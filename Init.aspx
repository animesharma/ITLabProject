﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Init.aspx.cs" Inherits="Init" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:label id = "Label1" runat ="server">Welcome To FlopKart Groceries!</asp:label>
            <br />
            <asp:Button runat="server" ID="Register" Text="Register" OnClick="Register_Click" />
            <asp:Button runat="server" ID="Login" Text="Login" OnClick="Login_Click" />
            <br />
        </div>
    </form>
</body>
</html>
