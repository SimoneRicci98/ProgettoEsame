using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class VisualizzaDati : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    HttpCookie myCookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        myCookie = Request.Cookies["PopUp"];
        if (Session["Operazione"].ToString()=="1")
        {
            Session["Fornitore"] = false;
            Session["Cliente"] = true;
            tabella();
        }
        else
        {
            Session["Fornitore"] = true;
            Session["Cliente"] = false;
            tabella();
        }
    }
    public void tabella()
    {
        help.connetti();
        help.assegnaComando("SELECT RagioneSociale,Indirizzo,Email,TelAzienda FROM Aziende WHERE Tipo ="+ Session["Operazione"].ToString()+" AND CliFor = '" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4]
           {new DataColumn("Nome"),
            new DataColumn("Ind"),
            new DataColumn("Tel"),
            new DataColumn("Email")});
        while (rs.Read())
        {
            dt.Rows.Add(rs["RagioneSociale"], rs["Indirizzo"], rs["TelAzienda"], rs["Email"]);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        help.disconnetti();
    }

    protected void btnAgg_Click(object sender, EventArgs e)
    {
        if (myCookie == null)
        {
            myCookie = new HttpCookie("PopUp");
            DateTime now = DateTime.Now;
            myCookie.Value = "";
            myCookie.Expires = now.AddYears(10);
            Response.Cookies.Add(myCookie);
            MessageBox.Show("Nel caso non si aprisse alcuna finestra è possibile che il vostro broswer blocchi i pop-up, è possibile attivare i pop-up per questa pagina nella casella dell'url, a destra, opure in basso al centro");
        }
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'AggiungiAnagrafica.aspx', null, 'height=1000,width=920,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }
}