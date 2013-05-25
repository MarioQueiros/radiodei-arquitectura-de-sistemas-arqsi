<%@ Page Title="iRadioDEI - Edit Musics"Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditMusic.aspx.cs" Inherits="ARQSI2.EditMusic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <asp:Label ID="Label15" runat="server" style="font-weight: 700; color: #FF0000; font-size: large" Visible="False"></asp:Label>
    <asp:Panel ID="NormalPanel" runat="server" Visible="False">
        <asp:Label ID="Label5" runat="server" Style="font-size: large; font-weight: 700; color: #FF0000;" Text="You do not have sufficient permissions to access this page."></asp:Label>
    </asp:Panel>
    <asp:Panel ID="ManagerPanel" runat="server" Visible="False">
        <br />
        <asp:Label ID="Label7" runat="server" Style="font-size: xx-large; font-weight: 700; color: #FFFFFF;" Text="Edit Musics"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label16" runat="server" Visible="False" style="font-weight: 700; color: #FF0000"></asp:Label>
        <asp:Label ID="Label17" runat="server" style="font-weight: 700; color: #FFFFFF;" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label6" runat="server" style="color: #FF0000; font-weight: 700" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelling" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" style="text-align: center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <%# Eval("ID") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Creation Date">
                    <ItemTemplate>
                        <%# Eval("Launch Year") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLaunchYear" runat="server" Text='<%# Eval("Launch Year") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                        <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Delete"/>
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
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="AddMusics.aspx" style="color: #FFFFFF; font-weight: 700">Add Musics</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="EditMusic.aspx" style="color: #FFFFFF; font-weight: 700">Edit Music</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="WinnerPlaylist.aspx" style="color: #FFFFFF; font-weight: 700">Winner Playlist</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="Admin.aspx" style="font-weight: 700; color: #FFFFFF">Admin Page</asp:HyperLink>
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