using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Pagamento : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnContinua_Click(object sender, EventArgs e)
    {
        bool continua = true;
        if(txtCodice.Text==string.Empty|| txtCodice.Text.Length!=16)
        {
            lblErrCod.Text = "Inserire un codice valido";
            continua = false;
        }
        if (txtGiorno.Text == string.Empty || txtMese.Text == string.Empty)
        {
            lblErrData.Text = "Inserire una data valida";
            continua = false;
        }
        if (txtCVV.Text == string.Empty || txtCVV.Text.Length!=3)
        {
            lblErrCVV.Text = "Inserire un CVV valido";
            continua = false;
        }
        if(continua)
        {
            if (Session["Versione"]!=null && (int)Session["Versione"] != 0)
            {
                help.connetti();
                help.assegnaComando("UPDATE Utenti SET Versione = 1 WHERE ID_Utente = " + Session["Utente"].ToString());
                help.eseguicomando();
                help.disconnetti();
            }
            Response.Redirect("Grazie.aspx");
        }
    }
}