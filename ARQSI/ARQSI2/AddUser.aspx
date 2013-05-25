<%@ Page Title="iRadioDEI - Add Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="ARQSI2.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <asp:Label ID="Label15" runat="server" style="font-weight: 700; color: #FF0000; font-size: large" Visible="False"></asp:Label>
    <asp:Panel ID="NormalPanel" runat="server" Visible="False">
        <asp:Label ID="Label5" runat="server" Style="font-size: large; font-weight: 700; color: #FF0000;" Text="You do not have sufficient permissions to access this page."></asp:Label>
    </asp:Panel>
    <asp:Panel ID="AdminPanel" runat="server" Visible="False">
        <div>
            <br />
            <asp:Label ID="Label8" runat="server" Style="font-size: xx-large; font-weight: 700; color: #FFFFFF;" Text="Add User"></asp:Label>
            <br />
            <br />
            <table class="style1">
                <tr>
                    <td class="auto-style6"><strong>Username:</strong></td>
                    <td>
                        <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><strong>Email:</strong></td>
                    <td>
                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><strong>Password:</strong></td>
                    <td>
                        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><strong>Retype Password:</strong></td>
                    <td>
                        <asp:TextBox ID="TxtRePassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><strong>Location:</strong></td>
                    <td>
                        <asp:TextBox ID="TxtLocation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><strong>Type:</strong></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="128px">
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Save"
            OnClick="Button1_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Overline="False" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Visible="False" style="font-weight: 700; color: #FFFFFF"></asp:Label>
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="AddMusics.aspx" CssClass="auto-style6" style="font-weight: 700">Add Musics</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="EditMusic.aspx" CssClass="auto-style6" style="font-weight: 700">Edit Music</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="WinnerPlaylist.aspx" CssClass="auto-style6" style="font-weight: 700">Winner Playlist</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="Admin.aspx" CssClass="auto-style6" style="font-weight: 700">Admin Page</asp:HyperLink>
        <br />
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