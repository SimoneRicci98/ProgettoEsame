using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Fatturazione : System.Web.UI.Page
{
     dbHelper help = new dbHelper();
     SqlDataReader rs;
    string limitazioni;
    int v;
    protected void Page_Load(object sender, EventArgs e)
    {    
        int numFornitori;
        int numClienti;
        int numFatture;
        help.connetti();
        help.assegnaComando("SELECT Versione FROM Utenti WHERE ID_Utente = " + Session["Utente"].ToString());
        rs = help.estraiDati();
        rs.Read();
        v = Convert.ToInt16(rs["Versione"].ToString());
        if (v == 0)
        {
            Session["Versione"] = 0;
            btnAssistenza.Enabled = false;
        }
        help.disconnetti();

        help.connetti();
        help.assegnaComando("SELECT ID_Azienda FROM Aziende WHERE COD_Proprietario ='" + Session["Utente"].ToString()+"'");
        rs = help.estraiDati();
        rs.Read();
        Session["Azienda"] = rs["ID_Azienda"].ToString();
        help.disconnetti();
        #region conto clienti, fornitori e fatture create
        help.connetti();
        help.assegnaComando("SELECT COUNT(COD_Azienda) FROM Clienti WHERE COD_Azienda = '" + Session["Azienda"].ToString()+"'");
        rs = help.estraiDati();
        rs.Read();
        numClienti = 5- Convert.ToInt16(rs[0].ToString());
        help.disconnetti();
        help.connetti();
        help.assegnaComando("SELECT COUNT(COD_Azienda) FROM Fornitori WHERE COD_Azienda = '" + Session["Azienda"].ToString()+"'");
        rs = help.estraiDati();
        rs.Read();
        numFornitori = 3-Convert.ToInt16(rs[0].ToString());
        help.disconnetti();
        help.connetti();
        help.assegnaComando("CREATE VIEW vista1 as(SELECT COUNT(DISTINCT Numero) as conta FROM Fattura WHERE COD_Azienda ='"+Session["Azienda"].ToString()+"')");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("SELECT conta FROM vista1");
        rs = help.estraiDati();
        rs.Read();
        if (rs["conta"].ToString() == "0")
        {
            numFatture = 10;
            help.disconnetti();
        }
        else
        {
            help.disconnetti();
            help.connetti();
            help.assegnaComando("SELECT DISTINCT COUNT(Conta) FROM vista1");
            rs = help.estraiDati();
            rs.Read();
            numFatture =10-Convert.ToInt16(rs[0].ToString());
            help.disconnetti();
        }
        help.connetti();
        help.assegnaComando("DROP VIEW Vista1");
        help.eseguicomando();
        help.disconnetti();
        #endregion
        if (numClienti == 0 && numFornitori == 0 && numFatture == 0)
        {
            limitazioni = "<asp:Button ID = \"btnPrimaNota\" runat = \"server\" CssClass = \"btn btn-link\" Text = \"Hai raggiunto i limiti della versione di prova, acquista la versione completa per continuare a usare il sito\" Width = \"100%\" OnClick = \"btnAcquista_Click\" />";
        }
        else
        {
            limitazioni = "Hai ancora a disposizione " + numClienti + " clienti, " + numFornitori + " fornitori e " + numFatture + " fatture disponibili nella versione di prova.";
        }

    }

    protected void btnFatt_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreaFattura.aspx");
    }

    protected void btnPrimaNota_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrimaNota.aspx");
    }

    protected void btnGiornale_Click(object sender, EventArgs e)
    {
        Response.Redirect("Giornale.aspx");
    }

    protected void btnContiMastro_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContiDiMastro.aspx");
    }

    protected void btnAreaPers_Click(object sender, EventArgs e)
    {
        Response.Redirect("AreaPersonale.aspx");
    }

    protected void btnAssistenza_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assistenza.aspx");
    }

    protected void btnCli_Click(object sender, EventArgs e)
    {
        Session["Operazione"] = "Cli";
        Response.Redirect("VisualizzaDati.aspx");
    }

    protected void btnFor_Click(object sender, EventArgs e)
    {
        Session["Operazione"] = "For";
        Response.Redirect("VisualizzaDati.aspx");
    }
    protected void btnAcquista_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pagamento.aspx");
    }

    public string htmlStr()
    { string html;
        if (v == 0)
        {
           html  = "<div class=\"col-xs-4\">" +
                  "<div class=\"col-xs-12\" style=\"border:solid 1px blue; align-items:center\">" +
                  limitazioni +
                  "</div>" +
                  "</div>";
        }
        else
        {
            html = "";
        }

        return html;
    }

    protected void btnProd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Prodotti.aspx");
    }
}