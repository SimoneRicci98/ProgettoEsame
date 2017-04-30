using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Amministrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper("ContabilitàDB.accdb");
    OleDbDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        lstDomande.Items.Clear();
        if(Session["Admin"]!=null)
        {
            int cont = 0;
            help.connetti();
            help.assegnaComando("SELECT Utente,Domanda FROM DomandeRisposte ORDER BY Data DESC");
            rs = help.estraiDati();
            while (rs.Read() || cont == 10)
            {
                cont++;
                lstDomande.Items.Add("Domanda da: " + rs["Utente"].ToString());
                lstDomande.Items.Add(rs["Domanda"].ToString());
            }
            help.disconnetti();
        }
        else
        {
            MessageBox.Show("NON HAI I PERMESSI NECESSARI PER QUESTA PAGINA");
            Response.AppendHeader("Refresh", "2;url=Default.aspx");
        }

    }

    protected void lstDomande_SelectedITemChanged(object sender, EventArgs e)
    {

    }

    protected void btnRisp_Click(object sender, EventArgs e)
    {

    }

    protected void btnSeleziona_Click(object sender, EventArgs e)
    {
        try
        {
            string utente;
            string domanda = lstDomande.SelectedIndex.ToString();
            help.connetti();
            help.assegnaComando("SELECT Utente FROM Domande-Risposte WHERE Domanda ='"+domanda+"'");
            rs = help.estraiDati();
            rs.Read();
            utente = rs["Utente"].ToString();
            help.disconnetti();
            lblRisp.Text = "Rispondi a: " +utente;
            lblDomandaDa.Text = "Alla domanda: " + domanda;
        }
        catch
        {
            lblbErr.Text = "Assicurati di aver selezionato una domanda";
        }
    }
}