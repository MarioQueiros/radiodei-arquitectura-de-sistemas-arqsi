<%@ Page Title="iRadioDEI - Add Musics" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMusics.aspx.cs" Inherits="ARQSI2.AddMusics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <asp:Label ID="Label15" runat="server" style="font-weight: 700; color: #FF0000; font-size: large" Visible="False"></asp:Label>
    <asp:Panel ID="NormalPanel" runat="server" Visible="False">
        <asp:Label ID="Label5" runat="server" Style="font-size: large; font-weight: 700; color: #FF0000;" Text="You do not have sufficient permissions to access this page."></asp:Label>
    </asp:Panel>
    <asp:Panel ID="ManagerPanel" runat="server" Visible="False" Height="271px" style="font-weight: 700">
        <br />
        <asp:Label ID="Label9" runat="server" Style="font-size: xx-large; font-weight: 700; color: #FFFFFF;" Text="Add Musics"></asp:Label>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Music Name:" style="font-weight: 700; color: #FFFFFF"></asp:Label></td>
                <td>&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Year:" style="font-weight: 700; color: #FFFFFF"></asp:Label></td>
                <td>&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save" />
        <br />
        <asp:Label ID="Label11" runat="server" Style="color: #FF0000; font-weight: 700" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label14" runat="server" Visible="False" style="font-weight: 700; color: #FFFFFF"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="AddMusics.aspx" CssClass="auto-style6" style="font-weight: 700">Add Musics</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="EditMusic.aspx" CssClass="auto-style6" style="font-weight: 700">Edit Music</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="WinnerPlaylist.aspx" CssClass="auto-style6">Winner Playlist</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="Admin.aspx" style="color: #FFFFFF">Admin Page</asp:HyperLink>
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