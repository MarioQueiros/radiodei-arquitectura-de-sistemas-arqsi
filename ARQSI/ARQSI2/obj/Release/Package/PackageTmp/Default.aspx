<%@ Page Title="iRadioDEI - Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ARQSI2._Default" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" ID="AuthenticatedMessagePanel">
        <br />
    </asp:Panel>
    <asp:Label ID="Label5" runat="server" Text="Vote in one of the playlist" style="color: #FFFFFF; font-weight: 700;"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnRowCommand="GridView1_RowCommand1" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
             <asp:BoundField DataField="Votes" HeaderText="Votes" />
            <asp:TemplateField HeaderText="Views Musics" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="view" runat="server" CommandName="View Musics" Text="Action"></asp:LinkButton>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Vote" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="vote" runat="server" CommandName="Vote" Text="Click"></asp:LinkButton>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
    <asp:Label ID="Label6" runat="server" ForeColor="Red" Visible="False" style="font-weight: 700"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" PageSize="12" Style="margin-top: 12px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Name">
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
