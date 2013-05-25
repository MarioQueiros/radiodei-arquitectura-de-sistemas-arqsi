using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ARQSI2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            // Log out the current user
            FormsAuthentication.SignOut();

            Session.Abandon();

            // Redirect back to the homepage
            Response.Redirect("~/Default.aspx");
        }

        protected void LoginStatus2_LoggedOut(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }
}
}