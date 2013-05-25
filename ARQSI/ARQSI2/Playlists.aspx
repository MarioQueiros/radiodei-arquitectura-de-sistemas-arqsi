<%@ Page Title="iRadioDEI - Playlists" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Playlists.aspx.cs" Inherits="ARQSI2.Playlists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <p>
        <asp:Label ID="Label7" runat="server" style="font-weight: 700; font-size: large; color: #FF0000" Text="There was an error while the page tried to show all the musics. Please try again later." Visible="False"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" style="font-size: xx-large; font-weight: 700; color: #FFFFFF;" Text="Playlists"></asp:Label>
    </p>
    
        <asp:Label ID="Label8" runat="server" style="font-weight: 700; color: #FF0000" Visible="False"></asp:Label>
    
        <asp:Label ID="Label9" runat="server" style="font-weight: 700; color: #FFFFFF;" Visible="False"></asp:Label>
    <br />
    
        &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Delete"/>
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
                        <%# Eval("Creation Date") %>
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
    
    <p>
        <asp:Label ID="Label6" runat="server" style="font-weight: 700; color: #FFFFFF;" Text="Musics" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView2" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("Name") %>
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