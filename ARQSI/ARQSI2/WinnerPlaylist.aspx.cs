using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class WinnerPlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                string type = Active_Record.Users.getUserTypeByUsername(User.Identity.Name);
                if (type == null)
                {
                    Label15.Text = "An error occurred while loading the page. Try again later.";
                    Label15.Visible = true;
                }
                else
                {
                    Label15.Visible = false;
                    if (type == "Normal")
                    {
                        NormalPanel.Visible = true;
                    }
                    else if (type == "Manager")
                    {
                        ManagerPanel.Visible = true;

                    }
                    else if (type == "Admin")
                    {
                        ManagerPanel.Visible = true;
                    }
                    else
                    {
                        NormalPanel.Visible = true;
                    }
                }
            }
            else
            {
                NormalPanel.Visible = true;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            var monday = today.AddDays(-(int)today.DayOfWeek).AddDays(1);
            var sunday = today.AddDays(-(int)today.DayOfWeek).AddDays(7);

            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                DataTable dt = Active_Record.Playlist.getTopPlaylist();
                if (dt == null)
                {
                    Label19.Text = "An error occurred while loading the page. Try again later.";
                    Label19.Visible = true;
                }
                else
                {
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    GridView3.Columns[0].Visible = false;
                    Label19.Text = "";
                }
            }
            else
            {
                Label19.Text = "Votes are still open!";
                Label19.Visible = true;
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = Active_Record.Playlist.getTopPlaylist();

            DataRow dr = dt.Rows[GridView3.SelectedIndex];
            int index = (int)dr["ID"];
            DataTable dt1 = Active_Record.Playlist.LoadMusicByIdPlaylist(index);
            if (dt1 == null)
            {
                /*Label19.Text="";
                Label19.Visible = true;*/
            }
            else
            {
                GridView4.DataSource = dt1;
                GridView4.DataBind();
            }
        }
    }
}