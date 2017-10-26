<%@ Page Title="" Language="C#" MasterPageFile="~/Initial.master" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="query" Text="Enter Query!" runat="server" OnClick="query_Click" />
    <asp:Panel ID="queryp" runat="server" Visible="false">
        <asp:TextBox ID="querytb" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="execute" runat="server" OnClick="execute_Click" Text="Execute Query!" />
        <br />
        <asp:Label ID="quelb" runat="server"></asp:Label>
    </asp:Panel>
    
    <asp:Button ID="addmgr" Text="Add Manager!" runat="server" OnClick="addmgr_Click" />
    <asp:Panel ID="addmgrp" runat="server" Visible="false">
        <asp:RadioButtonList runat="server" ID="addmgrrbl">

        </asp:RadioButtonList>
        <asp:Button ID="addm" runat="server" OnClick="addm_Click" Text="Add Manager!" />
    </asp:Panel>

</asp:Content>

