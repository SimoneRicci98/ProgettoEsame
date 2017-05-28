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
    double imponibile;
    double imponibile_iva;
    double totFatt;
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
        help.assegnaComando("SELECT CodFiscale,Indirizzo,RagioneSociale,TelAzienda,PartitaIVA FROM Clienti WHERE ID_Azienda = '" + Session["ID_Cliente"].ToString() + "'");
        rs = help.estraiDati();
        rs.Read();
        #region assegno valori alle label del cliente
        lblCodFiscCliFor.Text = rs["CodFiscale"].ToString();
        lblIndirizzoCliFor.Text = rs["Indirizzo"].ToString();
        lblPartIvaCliFor.Text = rs["PartitaIVA"].ToString();
        lblRagSocCliFor.Text = rs["RagioneSociale"].ToString();
        lblNumTelCliFor.Text = rs["TelAzienda"].ToString();
        #endregion
        help.disconnetti();

        help.connetti();
        help.assegnaComando("SELECT Numero,Oggetto,Data,TipoPagamento FROM Fattura WHERE Numero = '" + Session["Numero"].ToString() + "' AND COD_Cliente = '" + Session["ID_Cliente"].ToString() + "'");
        rs = help.estraiDati();
        rs.Read();
        lblNumFatt.Text = rs["Numero"].ToString();
        lblOggetto.Text = rs["Oggetto"].ToString();
        lblDataFatt.Text = rs["Data"].ToString();
        lblTipoPagamento.Text = rs["TipoPagamento"].ToString();
        help.disconnetti();
        

    }

    public string caricatabella_imponibili()
    {
        string tabella = "";
        help.connetti();
        help.assegnaComando("SELECT CodArticolo,Descrizione,Quantità,PrezzoUnitario,Sconto,Importo,Iva FROM Fattura WHERE Numero = '" + Session["Numero"].ToString()+ "'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            tabella += "<div class=\"col-md-12\">" +
            "<div class=\"col-md-1\" style=\"border: solid 1px black\">" + rs["CodArticolo"].ToString() + "</div>" +
            "<div class=\"col-md-5\" style=\"border: solid 1px black\">" + rs["Descrizione"].ToString() + "</div>" +
            "<div class=\"col-md-1\" style=\"border: solid 1px black\">" + rs["Quantità"].ToString() + "</div>" +
            "<div class=\"col-md-2\" style=\"border: solid 1px black\">" + rs["PrezzoUnitario"].ToString() + "</div>" +
            "<div class=\"col-md-1\" style=\"border: solid 1px black\">" + rs["Sconto"].ToString() + "</div>" +
            "<div class=\"col-md-1\" style=\"border: solid 1px black\">" + rs["Iva"].ToString() + "</div>" +
            "<div class=\"col-md-1\" style=\"border: solid 1px black\">" + rs["Importo"].ToString() + "</div>" +
            "</div>";
            imponibile += Convert.ToDouble(rs["Iva"].ToString());
            imponibile_iva += ((Convert.ToDouble(rs["PrezzoUnitario"].ToString()) * Convert.ToDouble(rs["Quantità"].ToString())) / 100) * Convert.ToDouble(rs["Importo"].ToString()); 
        }
        totFatt = (imponibile + imponibile_iva);
        help.disconnetti();
        lblImponibile.Text = imponibile.ToString();
        lblImpostaIva.Text = imponibile_iva.ToString();
        lblTotFatt.Text = totFatt.ToString();
        return tabella;
    }
}