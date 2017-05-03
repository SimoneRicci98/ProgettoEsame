using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


public partial class Reg : System.Web.UI.Page
{
    dbHelper help = new dbHelper("ContabilitàDB.accdb");
    OleDbDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string email;
        string password;
        email = TxtEmail.Text;
        password = TxtPass.Text;
        try
        {
            if(email == "Admin")
            {
                help.connetti();
                help.assegnaComando("SELECT ID_Admin FROM Admin WHERE Nome='" + email + "' AND Password='" + password + "'");
                rs = help.estraiDati();
                rs.Read();
                Session["Admin"] = rs["ID_Admin"].ToString();
                help.disconnetti();
                Response.Redirect("Amministrazione.aspx");
            }
            else
            {
                help.connetti();
                help.assegnaComando("SELECT ID_Utente FROM Utenti WHERE Email='" + email + "' AND Password='" + password + "'");
                rs = help.estraiDati();
                rs.Read();
                Session["Utente"] = rs["ID_Utente"].ToString();
                help.disconnetti();
                Response.Redirect("Seleziona.aspx");
            }
        }
        catch
        {
            help.disconnetti();
            lblErr.Text = "Nome utente o password errati!";
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["Utente"] = null;
        Response.Redirect("Default.aspx");
    }

    
}