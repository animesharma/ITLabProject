<%@ Page Title="" Language="C#" MasterPageFile="~/Initial.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" ID="namelb">Name : </asp:Label>
    <asp:TextBox runat="server" ID="nametb" placeholder="Your Full Name"></asp:TextBox>
    <asp:RequiredFieldValidator id="rfv1" runat="server"
        ControlToValidate="nametb"
        ErrorMessage="Name is a required field."
        ForeColor="Red">
    </asp:RequiredFieldValidator>
    <br />
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
    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "passtb" ID="rev1" ValidationExpression = "^[\s\S]{6,}$" runat="server" ErrorMessage="Minimum 6 characters required." ForeColor="DarkRed"></asp:RegularExpressionValidator>
    <br />
    <asp:Label runat="server" ID="contlb">Contact Number : </asp:Label>
    <asp:TextBox runat="server" ID="conttb" TextMode="Phone"></asp:TextBox>
    <asp:RequiredFieldValidator id="rfv4" runat="server"
        ControlToValidate="conttb"
        ErrorMessage="Contact is a required field."
        ForeColor="Red">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "conttb" ID="rev2" ValidationExpression = "^[\s\S]{10,10}$" runat="server" ErrorMessage="10 digits required." ForeColor="DarkRed"></asp:RegularExpressionValidator>

    <br />
    <asp:Label runat="server" ID="addlb">Address : </asp:Label>
    <asp:TextBox runat="server" ID="addtb"></asp:TextBox>
    <asp:RequiredFieldValidator id="rfv5" runat="server"
        ControlToValidate="addtb"
        ErrorMessage="Address is a required field."
        ForeColor="Red">
    </asp:RequiredFieldValidator>
    <br />
    <asp:Button runat="server" ID="regbtn" OnClick="Register_Click" Text="Register!" />
    <br />
    <asp:Label runat="server" ID="successlb"></asp:Label>
</asp:Content>

