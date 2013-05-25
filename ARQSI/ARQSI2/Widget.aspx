<%@ Page Title="iRadioDEI - Widget" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Widget.aspx.cs" Inherits="ARQSI2.Widget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel runat="server" ID="AuthenticatedMessagePanel">
        <br />
    </asp:Panel>
    <br />
    <iframe width="1325" height="710" src="http://phpdev.dei.isep.ipp.pt/~i100638/trabalho1.html"><p>Your browser does not support iframes.</p></iframe>

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