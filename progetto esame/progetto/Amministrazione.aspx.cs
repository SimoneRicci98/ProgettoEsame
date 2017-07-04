using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Amministrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ViewState["Domanda"] = "";
        }
        
        drpDomande.Items.Clear();
        if(Session["Admin"]!=null)
        {
            help.connetti();
            help.assegnaComando("SELECT Domanda FROM DomandeRisposte WHERE Risposta = 'blank' ORDER BY Data DESC");
            rs = help.estraiDati();
            while (rs.Read())
            {
                drpDomande.Items.Add(rs["Domanda"].ToString());
            }
            help.disconnetti();
        }
        else
        {
            MessageBox.Show("NON HAI I PERMESSI NECESSARI PER QUESTA PAGINA");
            Response.AppendHeader("Refresh", "1;url=Default.aspx");
        }

    }

    protected void lstDomande_SelectedITemChanged(object sender, EventArgs e)
    {

    }

    protected void btnRisp_Click(object sender, EventArgs e)
    {
        try
        {
            help.connetti();
            help.assegnaComando("UPDATE DomandeRisposte SET Risposta = '"+TextBox1.Text+"' WHERE Risposta = 'blank' AND Domanda='"+ViewState["Domanda"].ToString()+"'");
            help.eseguicomando();
            help.disconnetti();
            lblSuccess.Text = "Operazione completata";
        }
        catch
        {
            MessageBox.Show("Errore nell'inserimento della risposta");
        }
    }

    protected void btnSeleziona_Click(object sender, EventArgs e)
    {
        try
        {
            string utente;
            ViewState["Domanda"] = drpDomande.SelectedValue;
            help.connetti();
            help.assegnaComando("SELECT Utente FROM DomandeRisposte WHERE Domanda ='" + ViewState["Domanda"].ToString() + "'");
            rs = help.estraiDati();
            rs.Read();
            utente = rs["Utente"].ToString();
            help.disconnetti();
            lblRisp.Text = "Rispondi a: " +utente;
            lblDomandaDa.Text = "Alla domanda: " + ViewState["Domanda"].ToString();
        }
        catch
        {
            lblbErr.Text = "Assicurati di aver selezionato una domanda";
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            help.connetti();
            help.assegnaComando(txtQuery.Text);
            string app = txtQuery.Text.Substring(0, txtQuery.Text.IndexOf(" "));
            switch (app.ToUpper())
            {
                case "SELECT":
                    rs = help.estraiDati();
                    grdQuery.DataSource = rs;
                    grdQuery.DataBind();
                    break;
                default:
                    help.eseguicomando();
                    break;
            }
            help.disconnetti();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
}