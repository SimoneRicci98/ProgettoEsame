using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Fatturazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper("ContabilitàDB.accdb");
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT ID_Azienda FROM Aziende WHERE COD_Proprietario ='" + Session["Utente"].ToString()+"'");
        rs = help.estraiDati();
        rs.Read();
        Session["Azienda"] = rs["ID_Azienda"].ToString();
        help.disconnetti();
    }
}