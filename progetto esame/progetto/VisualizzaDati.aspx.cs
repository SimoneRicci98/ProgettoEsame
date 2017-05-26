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
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Operazione"].ToString()=="Cli")
        {
            string app="Clienti";
            tabella(app);
        }
        else
        {
            string app = "Fornitori";
            tabella(app);
        }
    }
    public void tabella(string app)
    {
        help.connetti();
        help.assegnaComando("SELECT RagioneSociale,Indirizzo,Email,TelAzienda FROM "+app+" WHERE COD_Azienda = '" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4]
           {new DataColumn("Nome"),
            new DataColumn("Ind"),
            new DataColumn("Tel"),
            new DataColumn("Email")});
        while (rs.Read())
        {
            dt.Rows.Add(rs["RagioneSociale"], rs["Indirizzo"], rs["Email"], rs["TelAzienda"]);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        help.disconnetti();
    }
}