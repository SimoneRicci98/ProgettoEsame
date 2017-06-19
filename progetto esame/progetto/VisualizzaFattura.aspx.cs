using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using Winnovative;


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
        help.connetti();
        help.assegnaComando("CREATE VIEW Vista AS("+
            "SELECT ");


        string tabella = "";
        help.connetti();
        help.assegnaComando("SELECT CodArticolo,Descrizione,Quantità,PrezzoUnitario,Sconto,Importo,Iva FROM Fattura WHERE Numero = '" + Session["Numero"].ToString()+ "' AND COD_Azienda="+azienda);
        rs = help.estraiDati();
        while (rs.Read())
        {
            tabella += "<div class=\"col-xs-12\" style=\"border-left:solid 1px black;border-right:solid 1px black;border-bottom:solid 1px black\">" +
            "<div class=\"col-xs-2\">" + rs["CodArticolo"].ToString() + "</div>" +
            "<div class=\"col-xs-4\">" + rs["Descrizione"].ToString() + "</div>" +
            "<div class=\"col-xs-1\">" + rs["Quantità"].ToString() + "</div>" +
            "<div class=\"col-xs-2\">" + rs["PrezzoUnitario"].ToString() + "</div>" +
            "<div class=\"col-xs-1\">" + rs["Sconto"].ToString() + "</div>" +
            "<div class=\"col-xs-1\">" + rs["Iva"].ToString() + "</div>" +
            "<div class=\"col-xs-1\">" + rs["Importo"].ToString() + "</div>" +
            "</div>";
            imponibile_iva += Convert.ToDouble(rs["Iva"].ToString());
            imponibile += Convert.ToDouble(rs["Importo"].ToString());
        }
        totFatt = (imponibile + imponibile_iva);
        help.disconnetti();
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