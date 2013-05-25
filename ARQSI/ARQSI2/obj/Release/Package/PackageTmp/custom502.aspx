<%@ Page Title="iRadioDEI - 502 Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="custom502.aspx.cs" Inherits="ARQSI2.custom502" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <p>
    <br />
    <asp:Label ID="Label8" runat="server" style="color: #FF0000; font-weight: 700; font-size: xx-large" Text="502 - Web server received an invalid response while acting as a gateway or proxy server."></asp:Label>
</p>
<p>
    <asp:Label ID="Label9" runat="server" style="font-weight: 700; color: #FFFFFF;" Text="There is a problem with the page you are looking for, and it cannot be displayed. When the Web server (while acting as a gateway or proxy) contacted the upstream content server, it received an invalid response from the content server."></asp:Label>
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