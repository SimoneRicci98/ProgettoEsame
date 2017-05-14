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
        help.assegnaComando("SELECT RagioneSociale,PartitaIva,CodFiscale,Indirizzo FROM Aziende WHERE ID_Azienda = " + Session["Azienda"].ToString());
        rs = help.estraiDati();
        rs.Read();
        lblAzienda.Text = rs["RagioneSociale"].ToString();
        lblCodFisc.Text = rs["CodFiscale"].ToString();
        lblIndirizzo.Text = rs["Indirizzo"].ToString();
        lblPartitaIva.Text = rs["PartitaIva"].ToString();
        help.disconnetti();
        try
        {
            tabella();
        }
        catch
        {
            MessageBox.Show("C'è stato un errore");
        }
    }


    public void tabella()
    {
        string app = "";
        string app1 = "";
        int index = 0;
        int index1 = 0;
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[8]
           {new DataColumn("NumDoc"),
            new DataColumn("Cliente"),
            new DataColumn("Fornitore"),
            new DataColumn("ContoMastro"),
            new DataColumn("Proto"),
            new DataColumn("Desc"),
            new DataColumn("Dare"),
            new DataColumn("Avere")});
        help.connetti();
        help.assegnaComando("SELECT NumDoc,ContoMastro,Descrizione,DareAvere,Protocollo,Cod_CliFor FROM Giornale " +
            "WHERE COD_Azienda ='" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            index = rs["DareAvere"].ToString().IndexOf('_');
            app = rs["DareAvere"].ToString().Substring(0, index);
            if (app == "Dare")
            {
                index1 = rs["Cod_CliFor"].ToString().IndexOf('_');
                app1 = rs["Cod_CliFor"].ToString().Substring(0, index1);
                if (app1 == "Cliente")
                {
                    dt.Rows.Add(rs["NumDoc"], rs["Cod_CliFor"].ToString().Substring(index1+1), "", rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index+1), "");
                }
                else
                {
                    dt.Rows.Add(rs["NumDoc"], "", rs["Cod_CliFor"].ToString().Substring(index1+1), rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index+1), "");
                }

            }
            else
            {
                index1 = rs["Cod_CliFor"].ToString().IndexOf('_');
                app1 = rs["Cod_CliFor"].ToString().Substring(0, index1);
                if (app1 == "Cliente")
                {
                    dt.Rows.Add(rs["NumDoc"], rs["Cod_CliFor"].ToString().Substring(index1+1), "", rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], "", rs["DareAvere"].ToString().Substring(index+1));
                }
                else
                {
                    dt.Rows.Add(rs["NumDoc"], "", rs["Cod_CliFor"].ToString().Substring(index1+1), rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], "", rs["DareAvere"].ToString().Substring(index+1));
                }

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();   
        }
        help.disconnetti();
    }
}