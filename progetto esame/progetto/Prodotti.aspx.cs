using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Prodotti : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        tabella();

    }
    public void tabella()
    {
        help.connetti();
        help.assegnaComando("SELECT ID_Prodotto,Descrizione,Prezzo,Qta " +
            "FROM Prodotti "
            + "WHERE COD_Azienda = '" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4]
           {new DataColumn("Cod"),
            new DataColumn("Desc"),
            new DataColumn("Prez"),
            new DataColumn("Qta")});
        while (rs.Read())
        {
            dt.Rows.Add(rs["ID_Prodotto"], rs["Descrizione"], rs["Prezzo"]+" €", rs["Qta"]);
        }
        grdVisual.DataSource = dt;
        grdVisual.DataBind();
        help.disconnetti();

    }

    protected void btnGestisci_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestisciProdotti.aspx");
    }
}