using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Text;
            
            int auth = Active_Record.Users.ValidateUser(username, password);
            if (auth == -99)
            {
                Label5.Visible = true;
            }
            else
            {
                if (auth == 1)
                {
                    // Create the cookie that contains the forms authentication ticket
                    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(username, RememberMe.Checked);

                    // Get the FormsAuthenticationTicket out of the encrypted cookie
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    // Create a new FormsAuthenticationTicket that includes our custom User Data
                    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, "");

                    // Update the authCookie's Value to use the encrypted version of newTicket
                    authCookie.Value = FormsAuthentication.Encrypt(newTicket);

                    // Manually add the authCookie to the Cookies collection
                    Response.Cookies.Add(authCookie);

                    // Determine redirect URL and send user there
                    string redirUrl = FormsAuthentication.GetRedirectUrl(UserName.Text, RememberMe.Checked);

                    Session["username"] = username;

                    Response.Redirect(redirUrl);


                }

                InvalidCredentialsMessage.Visible = true;
            }
        }
    }
}