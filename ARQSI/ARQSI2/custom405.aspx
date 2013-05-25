<%@ Page Language="C#" Title="iRadioDEI - 405 Error" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="custom405.aspx.cs" Inherits="ARQSI2.custom405" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <p>
    <br />
    <asp:Label ID="Label8" runat="server" style="color: #FF0000; font-weight: 700; font-size: xx-large" Text="405 - HTTP verb used to access this page is not allowed."></asp:Label>
</p>
<p>
    <asp:Label ID="Label9" runat="server" style="font-weight: 700; color: #FFFFFF;" Text="The page you are looking for cannot be displayed because an invalid method (HTTP verb) was used to attempt access."></asp:Label>
</p>

    </asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="LoginContent">
    <strong style="font-size: medium; text-align: right">
        <asp:LoginView ID="LoginView1" runat="server">
            <LoggedInTemplate>
                Welcome,
        <asp:LoginName ID="LoginName1" runat="server" />
                <br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" ForeColor="White" LogoutText="Logout" LoginText="Login"/>
            </LoggedInTemplate>
            <AnonymousTemplate>
                Hello, please login to enter a playlist.<br />
                <br />
                <a href="~/Login.aspx" id="HeadLoginStatus" runat="server" style="color: #FFFFFF">Log In</a>
            </AnonymousTemplate>
        </asp:LoginView>
    </strong>
</asp:Content>