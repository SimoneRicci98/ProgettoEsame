using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using Winnovative;
using System.Collections.Generic;

public partial class VisualizzaFattura : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    string ragsocCliente;
    double imponibile;
    double imponibile_iva;
    double totFatt;
    string azienda;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["NomeFile"] = "";
            azienda = Session["Azienda"].ToString();

            help.connetti();
            help.assegnaComando("SELECT CodFiscale,Email,Indirizzo,PartitaIVA,RagioneSociale,TelAzienda FROM Aziende WHERE ID_Azienda = '" + azienda + "'");
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
            ragsocCliente = rs["RagioneSociale"].ToString();
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
            ViewState["NomeFile"] = "Fattura n" + Session["Numero"].ToString() + " per " + ragsocCliente + ".pdf";
        }
    }

    public string caricatabella_imponibili()
    {
        List<int> qta = new List<int>();
        List<int> cod = new List<int>();
        List<int> iva = new List<int>();
        List<string> desc = new List<string>();
        List<int> prezzo = new List<int>();
        help.connetti();
        help.assegnaComando("SELECT COD_Prod,QtaProd,Iva FROM Vendita WHERE NumFatt="+Session["Numero"].ToString());
        rs = help.estraiDati();
        while(rs.Read())
        {
            qta.Add(int.Parse(rs["QtaProd"].ToString()));
            cod.Add(int.Parse(rs["COD_Prod"].ToString()));
            iva.Add(int.Parse(rs["Iva"].ToString()));
        }
        help.disconnetti();

        int i = 0;
        foreach(int app in cod)
        {
            help.connetti();
            help.assegnaComando("SELECT Descrizione,Prezzo FROM Prodotti WHERE COD_Azienda='" + Session["Azienda"] + "' AND ID_Prodotto = "+cod[i].ToString());
            rs = help.estraiDati();
            rs.Read();
            desc.Add(rs["Descrizione"].ToString());
            prezzo.Add(int.Parse(rs["Prezzo"].ToString()));
            help.disconnetti();
            i++;
        }
        

        string tabella = "";
        i = 0;
        foreach (int app in cod)
        {
            tabella += "<div class=\"col-xs-12\" style=\"border-left:solid 1px black;border-right:solid 1px black;border-bottom:solid 1px black\">" +
            "<div class=\"col-xs-2\">" + cod[i].ToString() + "</div>" +
            "<div class=\"col-xs-4\">" + desc[i].ToString() + "</div>" +
            "<div class=\"col-xs-1\">" + qta[i].ToString() + "</div>" +
            "<div class=\"col-xs-3\">" + prezzo[i].ToString() + "</div>" +
            "<div class=\"col-xs-1\">" + iva[i].ToString() + "</div>" +
            "<div class=\"col-xs-1\">" + prezzo[i]*qta[i] + "</div>" +
            "</div>";
            imponibile_iva += Convert.ToDouble(iva[i]);
            imponibile += Convert.ToDouble(prezzo[i] * qta[i]);
            i++;
        }
        totFatt = (imponibile + imponibile_iva);
        lblImponibile.Text = imponibile.ToString();
        lblImpostaIva.Text = imponibile_iva.ToString();
        lblTotFatt.Text = totFatt.ToString();
        return tabella;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    /*
    public void stampa()
    {
            
// Create a HTML to PDF converter object with default settings
        HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

        // The buffer to receive the generated PDF document
        byte[] outPdfBuffer = null;

        string url = Request.Url.AbsoluteUri;

        // Convert the HTML page given by an URL to a PDF document in a memory buffer
        outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);


        // Send the PDF as response to browser

        // Set response content type
        Response.AddHeader("Content-Type", "application/pdf");

        // Instruct the browser to open the PDF file as an attachment or inline
        Response.AddHeader("Content-Disposition", String.Format("{0}; filename=" + (string)ViewState["NomeFile"] + "; size={1}",
             "attachment", outPdfBuffer.Length.ToString()));

        // Write the PDF document buffer to HTTP response
        Response.BinaryWrite(outPdfBuffer);
        // End the HTTP response and stop the current page processing
        Response.End();
    }
    protected void btnStampa_Click(object sender, EventArgs e)
    {
        stampa();
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
    }*/
}