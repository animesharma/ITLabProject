<%@ Page Title="" Language="C#" MasterPageFile="~/Initial.master" AutoEventWireup="true" CodeFile="OrderConfirm.aspx.cs" Inherits="OrderConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server">Your Order Details : </asp:Label>
    <br />
    <asp:GridView runat="server" ID="Items" AutoGenerateColumns="false" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="grid_id" runat="server"  Text='<%#Bind("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="grid_name" runat="server"  Text='<%#Bind("Name") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="grid_price" runat="server"  Text='<%#Bind("Price") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="grid_qty" runat="server" Text='<%#Bind("Quantty") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView> 
    <br />
    <asp:Label ID="totlb" runat="server"></asp:Label>
    <br />
    <asp:Label ID="moplb" runat="server" Text="Mode of Payment : "></asp:Label>
    <asp:DropDownList ID="mopddl" runat="server">
        <asp:ListItem Text="Cash on Delivery" Value="0" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Payment Coupons" Value="1" ></asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="dtlb" runat="server" Text="Delivery Time Slot : "></asp:Label>
    <asp:RadioButtonList ID="dtrbl" runat="server" align="center">
        <asp:ListItem Text="09:00 am" Value="0"></asp:ListItem>
        <asp:ListItem Text="12:00 noon" Value="1"></asp:ListItem>
        <asp:ListItem Text="03:00 pm" Value="2"></asp:ListItem>
        <asp:ListItem Text="06:00 pm" Value="3"></asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="chkbtn" runat="server" Text="Checkout!" OnClick="chkbtn_Click" />
    <br />
    <asp:Label ID="successlb" runat="server"></asp:Label>
    <br />
    </asp:Content>
