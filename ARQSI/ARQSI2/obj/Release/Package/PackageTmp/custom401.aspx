<%@ Page Title="iRadioDEI - 401 Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="custom401.aspx.cs" Inherits="ARQSI2.custom401" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <p>
    <br />
    <asp:Label ID="Label8" runat="server" style="color: #FF0000; font-weight: 700; font-size: xx-large" Text="401 - Unauthorized: Access is denied due to invalid credentials."></asp:Label>
</p>
<p>
    <asp:Label ID="Label9" runat="server" style="font-weight: 700; color: #FFFFFF;" Text="You do not have permission to view this directory or page using the credentials that you supplied."></asp:Label>
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