<%@ Page Title="iRadioDEI - 412 Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="custom412.aspx.cs" Inherits="ARQSI2.custom412" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <p>
    <br />
    <asp:Label ID="Label8" runat="server" style="color: #FF0000; font-weight: 700; font-size: xx-large" Text="412 - Precondition set by the client failed when evaluated on the Web server."></asp:Label>
</p>
<p>
    <asp:Label ID="Label9" runat="server" style="font-weight: 700; color: #FFFFFF;" Text="The request was not completed due to preconditions that are set in the request header. Preconditions prevent the requested method from being applied to a resource other than the one intended. An example of a precondition is testing for expired content in the page cache of the client."></asp:Label>
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