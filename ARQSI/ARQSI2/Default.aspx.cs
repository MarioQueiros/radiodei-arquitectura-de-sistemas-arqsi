using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ARQSI2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                CustomIdentity ident = User.Identity as CustomIdentity;

                AuthenticatedMessagePanel.Visible = true;
            }
            else
            {
                AuthenticatedMessagePanel.Visible = false;
            }
            bindGridView();
        }


        protected void bindGridView()
        {
            var today = DateTime.Today;
            var monday = today.AddDays(-(int)today.DayOfWeek).AddDays(1);
            var sunday = today.AddDays(-(int)today.DayOfWeek).AddDays(7);

            if (today >= monday && today < sunday)
            {
                DataTable dt = Active_Record.Playlist.getPlaystsForVotes(DateTime.Today);
                if (dt == null)
                {
                    Label5.Text = "An error occurred while loading the page. Try again later!";
                    Label5.Visible = true;
                }
                else if (dt.Rows.Count == 0)
                {
                    Label5.Text = "There isn't any playlist submited!";
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Columns[0].Visible = false;
                }
            }
            else
            {
                Label5.Text = "Votes are currently closed!";
                Label5.Visible = true;
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView();
        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View Musics")
            {
                DataTable dt = Active_Record.Playlist.getPlaystsForVotes(DateTime.Today);

                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = gvr.RowIndex;

                int currentPage = GridView1.PageIndex;
                int pos = currentPage * 15;

                DataRow dr = dt.Rows[rowIndex + pos];
                int index = (int)dr["ID"];

                DataTable dt1 = Active_Record.Playlist.LoadMusicByIdPlaylist(index);
                GridView2.DataSource = dt1;
                GridView2.DataBind();
            }
            else if (e.CommandName == "Vote")
            {
                DataTable dt = Active_Record.Playlist.getPlaystsForVotes(DateTime.Today);
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = gvr.RowIndex;
                int currentPage = GridView1.PageIndex;
                int pos = currentPage * 15;
                DataRow dr = dt.Rows[rowIndex + pos];
                int index = (int)dr["ID"];

                int index2 = Active_Record.Playlist.verifyPlaylist(index);
                if (index2 != 0)
                {
                    int q = Active_Record.Playlist.updateVote(index2, index);
                    if (q == -99)
                    {
                        Label6.Text = "An error occurred while inserting the vote. Try again later.";
                        Label6.Visible = true;
                    }
                }
                bindGridView();
            }
        }
    }
}