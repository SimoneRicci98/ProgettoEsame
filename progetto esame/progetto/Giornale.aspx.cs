using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Giornale : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT RagioneSociale,PartitaIva,CodFiscale,Indirizzo FROM Aziende WHERE ID_Azienda = "+Session["Azienda"].ToString());
        rs = help.estraiDati();
        lblAzienda.Text = rs["RagioneSociale"].ToString();
        lblCodFisc.Text = rs["CodFiscale"].ToString();
        lblIndirizzo.Text = rs["Indirizzo"].ToString();
        lblPartitaIva.Text = rs["PartitaIva"].ToString();
        help.disconnetti();

        help.connetti();
        help.assegnaComando("");
    }


    public void tabella()
    {
        string app = "";
        int index = 0; ;
        help.connetti();
        help.assegnaComando("SELECT NumDoc,ContoMastro,Descrizione,DareAvere,Protocollo FROM Giornale " +
            "WHERE COD_Azienda ='" + Session["Azienda"].ToString()+"'");
        rs = help.estraiDati();
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[6]
           {new DataColumn("NumDoc"),
            new DataColumn("ContoMastro"),
            new DataColumn("Proto"),
            new DataColumn("Desc"),
            new DataColumn("Dare"),
            new DataColumn("Avere")});
        while (rs.Read())
        {
            index = rs["DareAvere"].ToString().IndexOf('_');
            app = rs["DareAvere"].ToString().Substring(0, index);
            if (app == "Dare")
            {
                dt.Rows.Add(rs["NumDoc"], rs["ContoMastro"], rs["Protocollo"],rs["Descrizione"],rs["DareAvere"],"");
            }
            else
            {
                dt.Rows.Add(rs["NumDoc"], rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], "", rs["DareAvere"]);
            }
            
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        help.disconnetti();

    }
}