using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class VisualizzaFattura : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT CodFiscale,Email,Indirizzo,PartitaIVA,RagioneSociale,TelAzienda FROM Aziende WHERE ID_Azienda = '" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        rs.Read();
        #region assengo valori alle label della mia azienda
        lblCodFisc.Text = rs["CodFiscale"].ToString();
        lblEmail.Text = rs["Email"].ToString();
        lblIndirizzoMio.Text = rs["Indirizzo"].ToString();
        lblPartIva.Text = rs["PartitaIVA"].ToString();
        lblRagSoc.Text = rs["RagioneSociale"].ToString();
        lblNumTel.Text = rs["TelAzienda"].ToString();
        #endregion
        help.disconnetti();

        help.connetti();
        help.assegnaComando("SELET CodFiscale,Indirizzo,RagioneSociale,TelAzienda FROM Clienti WHERE ID_Cliente = '" + Session["ID_Cliente"].ToString() + "'");
        rs = help.estraiDati();
        rs.Read();
        #region assengo valori alle label del cliente
        lblCodFiscCliFor.Text = rs["CodFiscale"].ToString();
        lblIndirizzoCliFor.Text = rs["Indirizzo"].ToString();
        lblPartIvaCliFor.Text = rs["PartitaIVA"].ToString();
        lblRagSocCliFor.Text = rs["RagioneSociale"].ToString();
        lblNumTelCliFor.Text = rs["TelAzienda"].ToString();
        #endregion
        help.disconnetti();

        help.connetti();
        help.assegnaComando("SELECT * FROM Fattura WHERE Numero = '" + Session["Numero"].ToString() + "' AND COD_Cliente = '" + Session["ID_Cliente"].ToString() + "'");
        rs = help.estraiDati();
        rs.Read();
        lblNumFatt.Text = rs["Numero"].ToString();
        lblOggetto.Text = rs["Oggetto"].ToString();
        lblDataFatt.Text = rs["Data"].ToString();
        lblTipoPagamento.Text = rs["TipoPagamento"].ToString();
        help.disconnetti();
        

    }

    public string caricatabella()
    {
        string tabella = "";

        help.connetti();
        help.assegnaComando("SELECT ");

        return tabella;
    }
}