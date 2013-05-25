<%@ Page Title="Music Preferences" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MusicPreferences._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Music Preferences</title>
    <style type="text/css">
        html, body {
            height: 100%;
            width: 100%;
            padding: 0;
            margin-left: 40px;
            margin-right: auto;
            margin-top: 5px;
        }

        .title {
            text-shadow: #000000 0 1px 0;
            font-size: 50px;
            margin: 0 0 0px 0;
            font-weight: bold;
            margin-left: 9em;
            color: #900000;
        }

        #full-screen-background-image {
            z-index: -999;
            min-height: 100%;
            min-width: 1024px;
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0;
            left: 0;
        }

        .form-title {
            text-shadow: #000000 0 1px 0;
            color: #900000;
            font-size: 22px;
            font: bolder;
        }

        .form-title2 {
            text-shadow: #000000 0 1px 0;
            color: #900000;
            font-size: 22px;
            font: bolder;
        }

        .style1 {
            width: 100%;
        }

        .style2 {
            width: 99px;
        }

        .style3 {
            width: 152px;
        }

        .auto-style1 {
            width: 333px;
        }
    </style>
</head>
<body>
    <img src="images.jpg" id="full-screen-background-image" />
    <h1 class="title">Music Preferences</h1>
    <br/>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btGetPLaylist" runat="server" BackColor="#990000" BorderColor="Maroon" BorderStyle="Solid" ForeColor="#FFFFCC" Text="Get Playlists" ToolTip="Get All Playlists" OnClick="btGetData_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbLocation" class="form-title2" runat="server" Text="Location"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbLocation" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btGetPLaylist_by_location" runat="server" Text="Get Playlists By Location" BackColor="#990000" BorderColor="Maroon" BorderStyle="Solid" ForeColor="#FFFFCC" ToolTip="Get Playlist By Location" OnClick="btGetPLaylist_by_location_Click" />
            <br />
            <br />
            <asp:Label class="form-title" ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1"
                runat="server"
                CellPadding="4"
                AllowPaging="True"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                AutoGenerateColumns="False"
                Width="500px" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="View Musics" />
                    <asp:BoundField DataField="name" HeaderText="Name">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="location" HeaderText="Location">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <br />
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="List of Musics">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="#FFCC66" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
