<%@ Page Title="iRadioDEI - Password Recover" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="PasswordRecover.aspx.cs" Inherits="ARQSI2.PasswordRecover" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br />
    <asp:Label ID="Label6" runat="server" style="font-weight: 700; font-size: xx-large; color: #FFFFFF;" Text="Recover Password"></asp:Label>
    <br />
    <br />
    <table>
        <tr>
            <td class="auto-style6"><strong>Email:</strong></td>
            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Label ID="Label7" runat="server" style="font-weight: 700; font-size: medium; color: #FF0000" Visible="False"></asp:Label>
    <asp:Label ID="Label8" runat="server" Text="An email was sent to your email address." Visible="False" style="font-weight: 700; color: #FFFFFF"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Recover" />
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