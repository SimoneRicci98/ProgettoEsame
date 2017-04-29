using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
public partial class _Default : System.Web.UI.Page
{
    dbHelper help = new dbHelper("ContabilitàDB.accdb");
    OleDbDataReader rs;

    protected void Page_Load(object sender, EventArgs e)
    {
        int cont = 0;
        help.connetti();
        help.assegnaComando("SELECT Utente,Domanda FROM DomandeRisposte");
        rs = help.estraiDati();
        while(rs.Read() || cont==10)
        {
            cont++;
            lstDomande.Items.Add("Domanda da: " + rs["Utente"].ToString());
            lstDomande.Items.Add(rs["Domanda"].ToString());
        }
        help.disconnetti();
        if(Session["dom"]==null)
        {
            Session["dom"] = "";
            txtUtente.Text = "Utente anonimo";
            txtDomanda.Text = "Cosa voglio sapere?";
        }

    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string utente = txtUtente.Text;
        string domanda = txtDomanda.Text;
        if(domanda!="" && utente!="")
        {
            help.connetti();
            help.assegnaComando("INSERT INTO DomandeRisposte(Utente,Domanda,Risposta) VALUES('"+utente+"','"+domanda+"','blank')");
            help.eseguicomando();
            help.disconnetti();
            txtDomanda.Text = "";
            lblErr1.Text = "";
            lstDomande.Items.Clear();
            Response.Redirect("Default.aspx");
        }
        else
        {
            if(domanda == "")
            {
                lblErr1.Text = "Fai la domanda!";
            }
            if(utente == "")
            {
                lblErr2.Text = "Inserisci un nome!";
            }
            
        }

    }

    protected void txtUtente_TextChanged(object sender, EventArgs e)
    {

    }
}