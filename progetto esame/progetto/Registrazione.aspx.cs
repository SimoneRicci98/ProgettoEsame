using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Registrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper("ContabilitàDB.accdb");
    OleDbDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime oggi = DateTime.Today;
            int app = 0;
            string email = txtEmailReg.Text;
            string psw = txtPswReg.Text;
            help.connetti();
            help.assegnaComando("SELECT MAX (ID_Utente) AS massimo FROM Utenti");
            rs = help.estraiDati();
            rs.Read();
            app = int.Parse(rs["massimo"].ToString()) + 1;
            help.disconnetti();

            help.connetti();
            help.assegnaComando("INSERT INTO Utenti VALUES('" + app + "','" + email + "','" + psw + "','"+Session["Versione"].ToString()+",#"+oggi+"#)");
            help.eseguicomando();
            help.disconnetti();
            Session["Utente"] = app.ToString();
            Response.Redirect("AggiungiAnagrafica.aspx");
        }
        catch
        {

        }
    }
}