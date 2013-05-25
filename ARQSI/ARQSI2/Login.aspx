<%@ Page Title="iRadioDEI - Login" Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ARQSI2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <div>
        <h1 style="font-weight: normal; color: #FFFFFF">
            <strong>Login</strong></h1>
    <p>
        <span class="auto-style6"><strong>Username:
        </strong></span>
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox></p>
    <p>
        <span class="auto-style6"><strong>Password:</strong></span>
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></p>
    <p>
        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" style="font-weight: 700; color: #FFFFFF" /> </p>
        <p>
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="PasswordRecover.aspx" style="color: #FFFFFF; font-weight: 700">Password Recover</asp:HyperLink>
        </p>
    <p>
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /> </p>
        <p>
            <asp:Label ID="Label1" runat="server" style="color: #FFFFFF; font-weight: 700"></asp:Label>
        </p>
        <asp:Label ID="Label5" runat="server" style="font-weight: 700; color: #FF0000" Text="There was a problem with login system. Please come back later." Visible="False"></asp:Label>
    <p>
        <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid. Please try again."
            Visible="False" style="font-weight: 700"></asp:Label> </p>    
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="LoginContent">
</asp:Content>
