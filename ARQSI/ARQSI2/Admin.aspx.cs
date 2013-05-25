using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ARQSI2
{
    public partial class Admin : System.Web.UI.Page
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
                        AdminPanel.Visible = true;
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
    }
}