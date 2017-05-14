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
    SqlDataReader rs1;
    protected void Page_Load(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT RagioneSociale,PartitaIva,CodFiscale,Indirizzo FROM Aziende WHERE ID_Azienda = "+Session["Azienda"].ToString());
        rs = help.estraiDati();
        rs.Read();
        lblAzienda.Text = rs["RagioneSociale"].ToString();
        lblCodFisc.Text = rs["CodFiscale"].ToString();
        lblIndirizzo.Text = rs["Indirizzo"].ToString();
        lblPartitaIva.Text = rs["PartitaIva"].ToString();
        help.disconnetti();
        tabella();
    }


    public void tabella()
    {
        string app = "";
        string app1 = "";
        int index = 0;
        int index1 = 0;
        string codCliFor = "";
        help.connetti();
        help.assegnaComando("SELECT NumDoc,ContoMastro,Descrizione,DareAvere,Protocollo FROM Giornale " +
            "WHERE COD_Azienda ='" + Session["Azienda"].ToString()+"'");
        rs = help.estraiDati();
        help.disconnetti();
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
        while (rs.Read())
        {
            index = rs["DareAvere"].ToString().IndexOf('_');
            app = rs["DareAvere"].ToString().Substring(0, index);
            if (app == "Dare")
            {
                index1 = rs["CodCliFor"].ToString().IndexOf('_');
                app1 = rs["CodCliFor"].ToString().Substring(0, index);
                if (app1=="Cliente")
                {
                    help.connetti();
                    help.assegnaComando("SELECT RagioneSociale FROM Clienti WHERE ID_Azienda ='"+app1.Substring(index1)+"'");
                    rs1 = help.estraiDati();
                    rs1.Read();
                    codCliFor = rs1["RagioneSociale"].ToString();
                    help.disconnetti();
                    dt.Rows.Add(rs["NumDoc"],codCliFor,"", rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index), "");
                }
                else
                {
                    help.connetti();
                    help.assegnaComando("SELECT RagioneSociale FROM Fornitori WHERE ID_Azienda ='" + app1.Substring(index1) + "'");
                    rs1 = help.estraiDati();
                    rs1.Read();
                    codCliFor = rs1["RagioneSociale"].ToString();
                    help.disconnetti();
                    dt.Rows.Add(rs["NumDoc"], "", codCliFor, rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index), "");
                }
                
            }
            else
            {
                index1 = rs["CodCliFor"].ToString().IndexOf('_');
                app1 = rs["CodCliFor"].ToString().Substring(0, index);
                if (app1 == "Cliente")
                {
                    help.connetti();
                    help.assegnaComando("SELECT RagioneSociale FROM Clienti WHERE ID_Azienda ='" + app1.Substring(index1) + "'");
                    rs1 = help.estraiDati();
                    rs1.Read();
                    codCliFor = rs1["RagioneSociale"].ToString();
                    help.disconnetti();
                    dt.Rows.Add(rs["NumDoc"], codCliFor, "", rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index), "");
                }
                else
                {
                    help.connetti();
                    help.assegnaComando("SELECT RagioneSociale FROM Fornitori WHERE ID_Azienda ='" + app1.Substring(index1) + "'");
                    rs1 = help.estraiDati();
                    rs1.Read();
                    codCliFor = rs1["RagioneSociale"].ToString();
                    help.disconnetti();
                    dt.Rows.Add(rs["NumDoc"], "", codCliFor, rs["ContoMastro"], rs["Protocollo"], rs["Descrizione"], rs["DareAvere"].ToString().Substring(index), "");
                }

            }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        

    }
}