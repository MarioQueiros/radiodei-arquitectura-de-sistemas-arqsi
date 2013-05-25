using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class AddUser : System.Web.UI.Page
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
                        NormalPanel.Visible = true;
                    }
                    else if (type == "Admin")
                    {
                        AdminPanel.Visible = true;
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            Label13.Text = "";
            string username = TxtUserName.Text;
            string password = TxtPassword.Text;
            string repassword = TxtRePassword.Text;
            string email = TxtEmail.Text;
            string location = TxtLocation.Text;

            lblError.Text = "";

            bool[] flags = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                flags[i] = true;
            }

            if (username.Trim() == "")
            {
                flags[0] = false;
                lblError.Text += "Invalid Username. \n ";
            }
            else
            {
                flags[0] = true;
            }
            if (password.Trim() == "" && repassword.Trim() == "")
            {
                flags[1] = false;
                lblError.Text += "Invalid Password.";
                if (flags[1] != false)
                {
                    if (password != repassword)
                    {
                        flags[2] = false;
                        lblError.Text += "Passwords are diferent.";
                    }
                    else
                    {
                        flags[0] = true;
                    }
                }
            }
            else
            {
                flags[0] = true;
            }
            if (email.Trim() == "")
            {
                flags[3] = false;
                lblError.Text += "Invalid Email.";
            }
            else
            {
                if (Regex.IsMatch(email.Trim(), @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"))
                {
                    flags[0] = true;
                }
                else
                {
                    flags[0] = false;
                    lblError.Text += "Invalid Email.";
                }
            }

            if (flags[0] != false && flags[1] != false && flags[2] != false && flags[3] != false)
            {
                int er = Active_Record.Users.Register(username, password, email, location, DropDownList1.SelectedValue);
                if (er == -99)
                {
                    Label15.Text = "An error occurred while loading the page. Try again later.";
                    Label15.Visible = true;
                }
                else
                {
                    if (er == 1)
                    {
                        TxtUserName.Text = "";
                        TxtPassword.Text = "";
                        TxtRePassword.Text = "";
                        TxtEmail.Text = "";
                        TxtLocation.Text = "";
                        lblError.Text = "";
                        Label13.Visible = true;
                        Label13.Text = "User created successfully.";
                    }
                    else if (er == -1)
                    {
                        lblError.Text = "Register error. Try again later!";
                    }
                    else if (er == -2)
                    {
                        lblError.Text = "Username already exists!";
                    }
                    else if (er == -3)
                    {
                        lblError.Text = "Email already exists!";
                    }
                }
            }
        }
    }
}