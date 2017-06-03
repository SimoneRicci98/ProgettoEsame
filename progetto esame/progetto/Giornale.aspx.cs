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
    int TotDare = 0;
    int TotAvere = 0;
    List<string> numDocumenti = new List<string>();
    int n = 0;
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
        int i = 0;
        string app = "";
        string app1 = "";
        int index = 0;
        int index1 = 0;
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[10]
           {new DataColumn("NumDoc"),
            new DataColumn("DataF"),
            new DataColumn("DataR"),
            new DataColumn("Cliente"),
            new DataColumn("Fornitore"),
            new DataColumn("ContoMastro"),
            new DataColumn("Proto"),
            new DataColumn("Desc"),
            new DataColumn("Dare"),
            new DataColumn("Avere")});
        help.connetti();
        help.assegnaComando("SELECT COUNT(NumDoc) AS Conta FROM Giornale WHERE COD_Azienda ='" + Session["Azienda"].ToString() + "' GROUP BY NumDoc");
        rs = help.estraiDati();
        while (rs.Read())
        {
            numDocumenti.Add(rs["Conta"].ToString());
        }
        help.disconnetti();
        help.connetti();
        help.assegnaComando("SELECT NumDoc,ContoMastro,Descrizione,DareAvere,Protocollo,Cod_CliFor,DataFattura,DataRegistrazione FROM Giornale " +
            "WHERE COD_Azienda ='" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        while (i != numDocumenti.Count)
        {
            rs.Read();
            index = rs["DareAvere"].ToString().IndexOf('_');
            app = rs["DareAvere"].ToString().Substring(0, index);
            if (app == "Dare")
            {
                index1 = rs["Cod_CliFor"].ToString().IndexOf('_');
                app1 = rs["Cod_CliFor"].ToString().Substring(0, index1);
                if (app1 == "Cliente")
                {
                    dt.Rows.Add(rs["NumDoc"], rs["DataFattura"], rs["DataRegistrazione"], rs["Cod_CliFor"].ToString().Substring(index1 + 1), "", rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index + 1), "");
                }
                else
                {
                    dt.Rows.Add(rs["NumDoc"], rs["DataFattura"], rs["DataRegistrazione"], "", rs["Cod_CliFor"].ToString().Substring(index1 + 1), rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index + 1), "");
                }
                TotDare += Convert.ToInt16(rs["DareAvere"].ToString().Substring(index + 1));
                n++;
            }
            else
            {
                index1 = rs["Cod_CliFor"].ToString().IndexOf('_');
                app1 = rs["Cod_CliFor"].ToString().Substring(0, index1);
                if (app1 == "Cliente")
                {
                    dt.Rows.Add(rs["NumDoc"], rs["DataFattura"], rs["DataRegistrazione"], rs["Cod_CliFor"].ToString().Substring(index1 + 1), "", rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], "", rs["DareAvere"].ToString().Substring(index + 1));
                }
                else
                {
                    dt.Rows.Add(rs["NumDoc"], rs["DataFattura"], rs["DataRegistrazione"], "", rs["Cod_CliFor"].ToString().Substring(index1 + 1), rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], "", rs["DareAvere"].ToString().Substring(index + 1));
                }
                TotAvere += Convert.ToInt16(rs["DareAvere"].ToString().Substring(index + 1));
                n++;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (numDocumenti[i] != null)
            {
                if (n == Convert.ToInt16(numDocumenti[i]))
                {
                    dt.Rows.Add("------------------------------", "------------------------------", "------------------------------", "------------------------------", "------------------------------", "------------------------------", "------------------------------", "--------------------", "------------------------------", "------------------------------");
                    i++;
                    n = 0;
                }
            }
        }
        if (TotAvere != TotDare)
        {
            lblErr.Text = "Dare e avere non corrispondono!";
        }
        lblTotAvere.Text = "Totale avere: " + TotAvere;
        lblTotDare.Text = "Totale dare: " + TotDare;
        help.disconnetti();
    }
}