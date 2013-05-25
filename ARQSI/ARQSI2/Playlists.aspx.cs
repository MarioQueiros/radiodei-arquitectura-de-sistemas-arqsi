using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class Playlists : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                DataTable dt = Active_Record.Playlist.LoadPlaylistByUsername(User.Identity.Name);
                if (dt == null)
                {
                    Label7.Visible = true;
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    GridView1.Columns[2].Visible = false;
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label8.Visible = false;
            Label9.Visible = false; 
            DataSet ds = Active_Record.Playlist.LoadPlaylistByUsername(User.Identity.Name, 1);
            if (ds == null)
            {
                Label7.Visible = true;
            }
            else
            {
                DataRow dr = ds.Tables[0].Rows[GridView1.SelectedIndex];
                int index = (int)dr["id_playlist"];

                DataTable dt1 = Active_Record.Playlist.LoadMusicByIdPlaylist(index);
                if (dt1 == null)
                {
                    Label7.Visible = true;
                }
                else
                {
                    GridView2.DataSource = dt1;
                    GridView2.DataBind();

                    if (GridView2.Rows.Count == 0)
                    {
                        Label6.Visible = false;
                    }
                    else
                    {
                        Label6.Visible = true;
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = Active_Record.Playlist.LoadPlaylistByUsername(User.Identity.Name, 1);
            if (ds == null)
            {
                Label7.Visible = true;
            }
            else
            {
                DataRow dr = ds.Tables[0].Rows[e.RowIndex];
                int index = (int)dr["id_playlist"];
                int q = Active_Record.Playlist.DeletePlaylist(index);

                if (q == -99)
                {
                    Label7.Visible = true;
                }
                else if (q == -1)
                {
                    Label8.Text = "There was an error when tried to delete selected playlist. Try again later";
                    Label8.Visible = true;
                }
                else
                {
                    Label9.Text = "Playlist successfully deleted.";
                    Label9.Visible = true;

                    DataTable dt = Active_Record.Playlist.LoadPlaylistByUsername(User.Identity.Name);
                    if (dt == null)
                    {
                        Label7.Visible = true;
                    }
                    else
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        GridView1.Columns[2].Visible = false;
                    }

                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    Label6.Visible = false;
                }
            }
        }
    }
}