using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Active_Record;

namespace MusicPreferences
{
    public partial class _Default : Page
    {
        string flag;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btGetData_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            bindGridView1();
            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        protected void btGetPLaylist_by_location_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            bindGridView2();
            GridView2.DataSource = null;
            GridView2.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            flag = (string)ViewState["flag"];
            GridView1.PageIndex = e.NewPageIndex;
            if (flag == "true")
            {
                bindGridView1();
            }
            else
            {
                bindGridView2();
            }
        }

        public void bindGridView1()
        {
            try
            {
                Playlist pl = new Playlist();
                DataSet ds = pl.LoadAllMP();
                bool check = IsEmpty(ds);
                if (!check)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Label1.Text = "";
                    ViewStat["flag"] = "true";
                }
                else
                {
                    Label1.Text = "No data found!";
                }
            }
            catch (Exception e)
            {
                Label1.Text = "The Server is down! Try again later!";
            }
        }

        public void bindGridView2()
        {
            try
            {
                if (txbLocation.Text == "")
                {
                    Label1.Text = "Enter a location!";
                }
                else
                {
                    Playlist pl = new Playlist();
                    DataSet ds = pl.LoadByLocationMP(txbLocation.Text);
                    bool check = IsEmpty(ds);
                    if (!check)
                    {
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                        Label1.Text = "";
                        ViewState["flag"] = "false";
                    }
                    else
                    {
                        Label1.Text = "No data found!";
                    }
                }
            }
            catch (Exception e)
            {
                Label1.Text = "The Server is down! Try again later!";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Playlist pl = new Playlist();
            DataSet ds;

            if (Page.IsPostBack)
            {
                // Retrieve and display the property value.
                flag = (string)ViewState["flag"];
            }

            if (flag == "true")
            {
                ds = pl.LoadAllMP();
            }
            else
            {
                ds = pl.LoadByLocationMP(txbLocation.Text);
            }

            int currentPage = GridView1.PageIndex;
            int pos = currentPage * 10;

            DataRow dr = ds.Tables[0].Rows[GridView1.SelectedIndex + pos];
            int index = (int)dr["id_playlist"];

            Music mus = new Music();
            DataSet ds2 = mus.LoadById_playlist(index);
            GridView2.DataSource = ds2;
            GridView2.DataBind();
        }

        bool IsEmpty(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
                if (table.Rows.Count != 0) return false;
            return true;
        }
    }
}