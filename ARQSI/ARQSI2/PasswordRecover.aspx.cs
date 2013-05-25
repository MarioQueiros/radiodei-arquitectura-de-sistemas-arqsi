using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class PasswordRecover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Visible = false;
            if(IsPostBack)
                Label8.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Trim() == "")
            {
                Label7.Visible = true;
                Label7.Text = "Insert an email in the textbox.";
            }
            else
            {
                if (!Regex.IsMatch(TextBox2.Text.Trim(), @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"))
                {
                    Label7.Visible = true;
                    Label7.Text = "Insert an email in the textbox.";
                }
                else
                {
                    string password = Active_Record.Users.GetPasswordByEmail(TextBox2.Text);
                    if (password == null)
                    {
                        Label7.Text = "There was an error while trying to recover password. Try again later.";
                        Label7.Visible = true;
                    }
                    else if (password == "")
                    {
                        Label7.Text = "The email inserted was not found on your database. Please check the email inserted.";
                        Label7.Visible = true;
                    }
                    else
                    {
                        string username = Active_Record.Users.GetUsernameByEmail(TextBox2.Text);
                        if (username == null)
                        {
                            Label7.Text = "There was an error while trying to recover password. Try again later.";
                            Label7.Visible = true;
                        }
                        else if (username == "")
                        {
                            Label7.Text = "The email inserted was not found on your database. Please check the email inserted.";
                            Label7.Visible = true;
                        }
                        else
                        {
                            string email = Active_Record.Users.GetEmailByUsername(username);
                            if (email == null)
                            {
                                Label7.Text = "There was an error while trying to recover password. Try again later.";
                                Label7.Visible = true;
                            }
                            else if (email == "")
                            {
                                Label7.Text = "The email inserted was not found on your database. Please check the email inserted.";
                                Label7.Visible = true;
                            }
                            else
                            {
                                try
                                {
                                    MailMessage mail = new MailMessage();
                                    mail.To.Add(email);
                                    mail.From = new MailAddress("iradio@dei.pt", "iRadioDei");
                                    mail.Subject = "iRadioDEI - Password recover";
                                    mail.Body = "You (or someone) asked to recover the password used in iRadioDEI.\n\nHere are the information about your account:\n\n   Username: " + username + "\n   Password: " + password + "\n\n\nIf you don't request to recover your password forget this email.\n\nThank you.\niRadioDEI";
                                    SmtpClient mSmtpClient = new SmtpClient();
                                    mSmtpClient.Send(mail);

                                    TextBox2.Text = "";
                                    Label8.Visible = true;
                                }
                                catch (Exception ex)
                                {
                                    ex.ToString();
                                    Label7.Text = "There was an error while trying to recover password. Try again later.";
                                    Label7.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}