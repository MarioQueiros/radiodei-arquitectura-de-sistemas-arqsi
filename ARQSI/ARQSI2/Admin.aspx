<%@ Page Title="iRadioDEI - Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ARQSI2.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <asp:Label ID="Label15" runat="server" style="font-weight: 700; color: #FF0000; font-size: large" Visible="False"></asp:Label>


    <br />
    <asp:Panel ID="NormalPanel" runat="server" Visible="False">
        <asp:Label ID="Label5" runat="server" Style="font-size: large; font-weight: 700; color: #FF0000;" Text="You do not have sufficient permissions to access this page."></asp:Label>
    </asp:Panel>
    <asp:Panel ID="ManagerPanel" runat="server" Visible="False">
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="AddMusics.aspx" CssClass="auto-style6" style="font-weight: 700">Add Musics</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="EditMusic.aspx" CssClass="auto-style6" style="font-weight: 700">Edit Music</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="WinnerPlaylist.aspx" CssClass="auto-style6" style="font-weight: 700">Winner Playlist</asp:HyperLink>
        <br />
    </asp:Panel>
    <asp:Panel ID="AdminPanel" runat="server" Visible="False">
        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="AddUser.aspx" CssClass="auto-style6" style="font-weight: 700">Add User</asp:HyperLink>
    </asp:Panel>
    


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