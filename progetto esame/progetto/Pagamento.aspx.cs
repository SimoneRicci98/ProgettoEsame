using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pagamento : System.Web.UI.Page
{
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
            lblErrCod.Text = "Inserire una data valida";
            continua = false;
        }
        if (txtCVV.Text == string.Empty || txtCVV.Text.Length!=3)
        {
            lblErrCod.Text = "Inserire un CVV valido";
            continua = false;
        }
        if(continua)
        {
            Response.Redirect("Grazie.aspx");
        }
    }
}