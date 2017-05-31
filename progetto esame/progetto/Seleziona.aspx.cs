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
    protected void Page_Load(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT Versione FROM Utenti WHERE ID_Utente = " + Session["Utente"].ToString());
        rs = help.estraiDati();
        rs.Read();
        if (Convert.ToInt16(rs["Versione"].ToString()) == 0)
        {
            btnAssistenza.Enabled = false;
            lblVers.Visible = false;
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
        help.assegnaComando("SELECT COUNT(COD_Azienda) FROM Clienti WHERE COD_Azienda = " + Session["Azienda"].ToString());
        rs = help.estraiDati();
        string numClienti = rs[0].ToString();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("SELECT COUNT(COD_Azienda) FROM Fornitori WHERE COD_Azienda = " + Session["Azienda"].ToString());
        rs = help.estraiDati();
        string numFornitori = rs[0].ToString();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("CREATE VIEW vista1 as(SELECT DISTINCT COUNT(ID_Fattura) as conta FROM Fattura WHERE COD_Azienda ="+Session["Azienda"].ToString()+")");
        help.eseguicomando();
        help.disconnetti();
        help.connetti();
        help.assegnaComando("SELECT DISTINCT COUNT(Conta) FROM vista1");
        rs = help.estraiDati();
        string numFatture = rs[0].ToString();
        help.disconnetti();
        #endregion
        lblLimitazioni.Text = "Hai "+numClienti+" clienti, "+numFornitori+" fornitori e hai creato "+numFatture+" fatture finora.";
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
}