using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AreaPersonale : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT * FROM Aziende WHERE ID_Azienda = '"+Session["Azienda"].ToString()+"'");
        rs = help.estraiDati();
        rs.Read();
        string idUtente = rs["COD_Proprietario"].ToString();
        #region assengo valori alle label
            lblCap.Text = rs["Cap"].ToString();
            lblCodFisc.Text = rs["CodFiscale"].ToString();
            lblEmail.Text = rs["Email"].ToString();
            lblIndirizzo.Text = rs["Indirizzo"].ToString();
            lblNazione.Text = rs["Nazione"].ToString();
            lblNomCog.Text = rs["NomeCog"].ToString();
            lblNumCell.Text = rs["Numero"].ToString();
            lblPartitaIva.Text = rs["PartitaIVA"].ToString();
            lblProvincia.Text = rs["Provincia"].ToString();
            lblRagSoc.Text = rs["RagioneSociale"].ToString();
            lblRegione.Text = rs["Regione"].ToString();
            lblTelefono.Text = rs["TelAzienda"].ToString();
        #endregion
        help.disconnetti();

        help.connetti();
        help.assegnaComando("SELECT Password FROM Utenti WHERE ID_Utente ="+idUtente);
        rs = help.estraiDati();
        rs.Read();
        txtPassword.Text = rs["Password"].ToString();
        help.disconnetti();
    }

    protected void btnChiudi_Click(object sender, EventArgs e)
    {
        if (txtPassword.TextMode == TextBoxMode.Password)
            txtPassword.TextMode = TextBoxMode.SingleLine;
        else
            txtPassword.TextMode = TextBoxMode.Password;
    }
}