﻿using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.IO;
using NReco.PdfGenerator;
public partial class VisualizzaFattura : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    string ragsocCliente;
    double imponibile;
    double imponibile_iva;
    double totFatt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["NomeFile"] = "";
        }
        //Session["Azienda"] = 4;
        //Session["ID_Cliente"] = 1;
        //Session["Numero"] = 5;
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
        ragsocCliente = rs["RagioneSociale"].ToString();
        lblRagSoc.Text = ragsocCliente;
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
            tabella += "<div class=\"col-xs-12\">" +
            "<div class=\"col-xs-1\" style=\"border: solid 1px black\">" + rs["CodArticolo"].ToString() + "</div>" +
            "<div class=\"col-xs-5\" style=\"border: solid 1px black\">" + rs["Descrizione"].ToString() + "</div>" +
            "<div class=\"col-xs-1\" style=\"border: solid 1px black\">" + rs["Quantità"].ToString() + "</div>" +
            "<div class=\"col-xs-2\" style=\"border: solid 1px black\">" + rs["PrezzoUnitario"].ToString() + "</div>" +
            "<div class=\"col-xs-1\" style=\"border: solid 1px black\">" + rs["Sconto"].ToString() + "</div>" +
            "<div class=\"col-xs-1\" style=\"border: solid 1px black\">" + rs["Iva"].ToString() + "</div>" +
            "<div class=\"col-xs-1\" style=\"border: solid 1px black\">" + rs["Importo"].ToString() + "</div>" +
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

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void btnStampa_Click(object sender, EventArgs e)
    {
        /*Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName((string)ViewState["NomeFile"]));
        Response.WriteFile((string)ViewState["NomeFile"]);
        Response.End();*/
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {/*
        var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
        ViewState["NomeFile"] = "Fattura n" + Session["Numero"] + " per il cliente " + ragsocCliente + ".pdf";
        htmlToPdf.TempFilesPath = Server.MapPath("~/App_Data/" + Session["Azienda"].ToString() + "/");
        btnSalva.Visible = false;
        btnStampa.Visible = false;
        htmlToPdf.GeneratePdfFromFile(Request.Url.AbsoluteUri, null, (string)ViewState["NomeFile"]);
        btnSalva.Visible = true;
        btnStampa.Visible = true;
        Response.Redirect(Request.Url.AbsoluteUri);*/
    }
}