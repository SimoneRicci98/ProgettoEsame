using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;

    protected void Page_Load(object sender, EventArgs e)
    {
        int cont = 0;
        help.connetti();
        help.assegnaComando("SELECT Utente,Domanda FROM DomandeRisposte ORDER BY Data DESC");
        rs = help.estraiDati();
        while(rs.Read() || cont==10)
        {
            cont++;
            lstDomande.Items.Add("Domanda da: " + rs["Utente"].ToString());
            lstDomande.Items.Add(rs["Domanda"].ToString());
        }
        help.disconnetti();
        cont = 0;
        help.connetti();
        help.assegnaComando("SELECT Utente,Domanda,Risposta FROM DomandeRisposte ORDER BY Data DESC");
        rs = help.estraiDati();
        while (rs.Read() || cont == 10)
        {
            if(rs["Risposta"].ToString() != "blank")
            {
                cont++;
                lstRisposte.Items.Add("Rispondo a: " + rs["Utente"].ToString());
                lstRisposte.Items.Add("Che ha chiesto: " + rs["Domanda"].ToString());
                lstRisposte.Items.Add(rs["Risposta"].ToString());
            }
            
        }
        help.disconnetti();
        if (Session["dom"]==null)
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
        DateTime oggi = DateTime.Today;
        string utente = txtUtente.Text;
        string domanda = txtDomanda.Text;
        if(domanda!="" && utente!="")
        {
            help.connetti();
            help.assegnaComando("INSERT INTO DomandeRisposte(Utente,Domanda,Risposta,Data) VALUES('"+utente+"','"+domanda+"','blank','"+oggi+"')");
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

    protected void btnProva_Click(object sender, EventArgs e)
    {
        Session["Versione"] = 0;
        Response.Redirect("Registrazione.aspx");
    }

    protected void btnCompleta_Click(object sender, EventArgs e)
    {
        Session["Versione"] = 1;
        Response.Redirect("Pagamento.aspx");
    }
}