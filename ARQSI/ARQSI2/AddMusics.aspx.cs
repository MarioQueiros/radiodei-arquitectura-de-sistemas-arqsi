using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class AddMusics : System.Web.UI.Page
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label14.Text = "";
            if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "")
            {

                try
                {
                    if (TextBox2.Text.Length != 4)
                    {
                        Label11.Text = "Insert a valid year (yyyy)";
                    }
                    else
                    {
                        int year = Convert.ToInt32(TextBox2.Text);
                        string name = TextBox1.Text;

                        int q = Active_Record.Music.InsertMusic(name, year);
                        if (q == -1)
                        {
                            Label11.Text = "Error while insert music information in database. Try again later.";
                        }
                        else if (q == -99)
                        {
                            Label15.Text = "An error occurred while loading the page. Try again later.";
                            Label15.Visible = true;
                        }
                        else
                        {

                            Label11.Text = "";
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            Label14.Visible = true;
                            Label14.Text = "Music inserted successfully.";
                        }
                    }

                }
                catch
                {
                    Label11.Text = "Insert a valid year (yyyy)";
                }
            }
            else
            {
                Label11.Visible = true;
                Label11.Text = "Insert information about the music.";
            }
        }

       
    }
}