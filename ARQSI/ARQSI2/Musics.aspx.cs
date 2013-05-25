using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class Musics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                DataTable dt = Active_Record.Music.LoadMusics();
                if (dt == null)
                {
                    Label5.Visible = true;
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    GridView1.Columns[0].Visible = false;
                }
            }
        }

        private void BindGridData()
        {
            DataTable dt = Active_Record.Music.LoadMusics();
            if (dt == null)
            {
                Label5.Visible = true;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                GridView1.Columns[0].Visible = false;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridData();
        }
    }
}