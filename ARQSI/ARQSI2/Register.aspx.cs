using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HyperLink1.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;

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
                int er = Active_Record.Users.Register(username, password, email, location);
                if (er == -99)
                {
                    lblError.Text = "An error occurred while registering the user. Please try again later.";
                    lblError.Visible = true;
                }
                else
                {
                    if (er == 1)
                    {
                        try
                        {
                            MailMessage mail = new MailMessage();
                            mail.To.Add(email);
                            mail.From = new MailAddress("iradio@dei.pt", "iRadioDei");
                            mail.Subject = "iRadioDEI register information";
                            mail.Body = "You registred in iRadioDEI.\n\nYour registration information are:\n\n   Username: " + username + "\n   Password: " + password + "\n\n\nThank you for your register.\nWe are waiting for your visit!\n\niRadioDEI";
                            SmtpClient mSmtpClient = new SmtpClient();
                            mSmtpClient.Send(mail);
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }

                        HyperLink1.Visible = true;
                        Label1.Visible = true;
                        Label2.Visible = true;
                        TxtUserName.Text = "";
                        TxtPassword.Text = "";
                        TxtRePassword.Text = "";
                        TxtEmail.Text = "";
                        TxtLocation.Text = "";
                        lblError.Text = "";
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