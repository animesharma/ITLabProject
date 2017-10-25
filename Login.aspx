<%@ Page Title="" Language="C#" MasterPageFile="~/Initial.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" ID="emaillb">E-mail ID : </asp:Label>
    <asp:TextBox runat="server" ID="emailtb" placeholder="abc@example.com" TextMode="Email"></asp:TextBox>
    <asp:RequiredFieldValidator id="rfv2" runat="server"
        ControlToValidate="emailtb"
        ErrorMessage="E-mail is a required field."
        ForeColor="Red">
    </asp:RequiredFieldValidator>
    <br />
    <asp:Label runat="server" ID="passlb">Password : </asp:Label>
    <asp:TextBox runat="server" ID="passtb" placeholder="Atleast 6 characters" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator id="rfv3" runat="server"
        ControlToValidate="passtb"
        ErrorMessage="Password is a required field."
        ForeColor="Red">
    </asp:RequiredFieldValidator>
    <br />
    <asp:Button runat="server" ID="logbtn" OnClick="Login_Click" Text="Login!" />
    <asp:Label runat="server" ID="successlb"></asp:Label>
</asp:Content>

