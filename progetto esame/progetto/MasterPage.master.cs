using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Utente"] == null)
        {
            lblLogin.Visible = true;
            lblBenv.Visible = false;
            btnLogout.Visible = false;
        }
        else
        {
            lblLogin.Visible = false;
            lblBenv.Visible = true;
            btnLogout.Visible = true;
        }
        
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("Default.aspx");
    }
    public string icona()
    {
        if (Session["Utente"] != null)
            return "";
        else
            return "<span class=\"glyphicon glyphicon-log-in\"></span>";

    }
}
