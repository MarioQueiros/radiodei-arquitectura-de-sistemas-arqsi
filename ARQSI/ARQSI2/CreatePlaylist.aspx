<%@ Page Title="iRadioDEI - Create Playlits" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePlaylist.aspx.cs" Inherits="ARQSI2.CreatePlaylist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <br />
    <asp:Label ID="Label9" runat="server" style="font-weight: 700; color: #FFFFFF; font-size: xx-large" Text="Create a Playlist"></asp:Label>
    <br />



    <br />



    <asp:GridView ID="gdvMusicas" runat="server" OnPageIndexChanging="gdvMusicas_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvMusicas_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" style="text-align: center">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="Select"/>



            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <%# Eval("ID") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <%# Eval("Name") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Creation Date">
                <ItemTemplate>
                    <%# Eval("Launch Year") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView>



    <br />



    <asp:Label ID="Label5" runat="server" style="font-weight: 700; color: #FF0000" Visible="False"></asp:Label>



    <br />



    <asp:Label ID="Label8" runat="server" Text="Label" Visible="False" style="font-weight: 700; color: #FFFFFF"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Playlist Name:" style="color: #FFFFFF; font-weight: 700"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />



    <br />
    <asp:ListBox ID="ListBox1" runat="server" style="min-width:200px" Rows="12"></asp:ListBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Remove Selected" Width="110px" Enabled="False" />
    &nbsp;<asp:Button ID="Button2" runat="server" Enabled="False" OnClick="Button2_Click" Text="Save" style="height: 26px" />
    <br />
    <asp:Label ID="Label6" runat="server" style="font-weight: 700; color: #FFFFFF"></asp:Label>
    <br />
    


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