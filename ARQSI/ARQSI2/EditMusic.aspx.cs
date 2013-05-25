using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class EditMusic : System.Web.UI.Page
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
                        if (!IsPostBack)
                            Manager();
                    }
                    else if (type == "Admin")
                    {
                        ManagerPanel.Visible = true;

                        if (!IsPostBack)
                            Manager();
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

        public void Manager()
        {
            DataTable dt = Active_Record.Music.LoadMusics();
            if (dt == null)
            {
                Label15.Text = "An error occurred while loading the page. Try again later.";
                Label15.Visible = true;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Columns[0].Visible = false;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label17.Visible = false;
            GridView1.EditIndex = e.NewEditIndex;
            BindGridData();
        }

        private void BindGridData()
        {
            DataTable dt = Active_Record.Music.LoadMusics();
            if (dt == null)
            {
                Label15.Text = "An error occurred while loading the page. Try again later.";
                Label15.Visible = true;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Columns[0].Visible = false;
            }
        }

        protected void GridView1_RowCancelling(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridData();
            Label16.Visible = false;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string s = GridView1.DataKeys[e.RowIndex].Value.ToString();
            TextBox name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            TextBox year = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLaunchYear");

            if (name.Text.Trim() == "" || year.Text.Trim() == "")
            {
                Label16.Text = "Insert data on the textbox.";
                Label16.Visible = true;
            }
            else
            {
                Label16.Visible = false;
                int q = Active_Record.Music.UpdateMusicInfo(Convert.ToInt32(s), name.Text, year.Text);
                if (q == -1)
                {
                    Label6.Text = "Error while updating music information. Try again later.";
                    Label6.Visible = true;
                }
                else if (q == -99)
                {
                    Label15.Text = "An error occurred while loading the page. Try again later.";
                    Label15.Visible = true;
                }
                else
                {
                    GridView1.EditIndex = -1;

                    BindGridData();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string s = GridView1.DataKeys[e.RowIndex].Value.ToString();

            int q = Active_Record.Music.DeleteMusic(Convert.ToInt32(s));
            if(q==-99)
            {
                Label15.Text = "An error occurred while loading the page. Try again later.";
                Label15.Visible = true;
            }
            else if (q == -1)
            {
                Label6.Text = "Error while deleting music. Try again later.";
                Label6.Visible = true;
            }
            else
            {
                Label17.Text = "Music successfully deleted.";
                Label17.Visible = true;
                BindGridData();
            }
        }

    }
}