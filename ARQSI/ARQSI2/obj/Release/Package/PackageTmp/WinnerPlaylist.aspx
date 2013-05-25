<%@ Page Title="iRadioDEI - Winner Playlist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WinnerPlaylist.aspx.cs" Inherits="ARQSI2.WinnerPlaylist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <asp:Label ID="Label15" runat="server" style="font-weight: 700; color: #FF0000; font-size: large" Visible="False"></asp:Label>
    <asp:Panel ID="NormalPanel" runat="server" Visible="False">
        <asp:Label ID="Label5" runat="server" Style="font-size: large; font-weight: 700; color: #FF0000;" Text="You do not have sufficient permissions to access this page."></asp:Label>
    </asp:Panel>
    <asp:Panel ID="ManagerPanel" runat="server" Visible="False">
        <asp:Label ID="Label20" runat="server" style="font-weight: 700; font-size: x-large; color: #FFFFFF;" Text="Playlist Winner"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Get the winner playlist" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label19" runat="server" ForeColor="Red" Text="Label" Visible="False" style="font-weight: 700"></asp:Label>
        <br />
        &nbsp;<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <%# Eval("ID") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblId0" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName1" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nº of votes">
                    <ItemTemplate>
                        <%# Eval("Votes") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtN_votes" runat="server" Text='<%# Eval("Votes") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:buttonfield buttontype="Button" commandname="Select" headertext="Action" text="View Musics" />
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
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Musics">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName2" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
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
        <br />
        <br />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="AddMusics.aspx" style="font-weight: 700; color: #FFFFFF">Add Musics</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="EditMusic.aspx" style="font-weight: 700; color: #FFFFFF">Edit Music</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="WinnerPlaylist.aspx" style="font-weight: 700; color: #FFFFFF">Winner Playlist</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="Admin.aspx" style="color: #FFFFFF; font-weight: 700">Admin Page</asp:HyperLink>
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