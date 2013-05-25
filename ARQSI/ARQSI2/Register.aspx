<%@ Page Title="iRadioDEI - Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="True" CodeBehind="Register.aspx.cs" Inherits="ARQSI2.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <br />
        <asp:Label ID="Label6" runat="server" style="font-weight: 700; font-size: xx-large; color: #FFFFFF;" Text="Register"></asp:Label>
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
                    <asp:TextBox ID="TxtPassword" runat="server"
                                 TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"><strong>Retype Password:</strong></td>
                <td>
                    <asp:TextBox ID="TxtRePassword" runat="server"
                                 TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6"><strong>Location:</strong></td>
                <td>
                    <asp:TextBox ID="TxtLocation" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Save" 
                             onclick="Button1_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Overline="False" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Registration completed." Visible="False" style="font-weight: 700; color: #FFFFFF"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="You should now login. Click on login hyperlink to login." Visible="False" style="font-weight: 700; color: #FFFFFF"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx" Visible="False" style="color: #FFFFFF">Login</asp:HyperLink>
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
