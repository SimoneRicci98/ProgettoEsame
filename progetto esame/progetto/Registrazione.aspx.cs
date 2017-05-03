﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Registrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper("ContabilitàDB.accdb");
    OleDbDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime oggi = DateTime.Today;
            int app = 0;
            string nome = txtNome.Text;
            string cognome = txtCognome.Text;
            string email = txtEmail.Text;
            string psw = txtPass.Text;
            help.connetti();
            help.assegnaComando("SELECT MAX (ID_Utente) AS massimo FROM Utenti");
            rs = help.estraiDati();
            rs.Read();
            app = int.Parse(rs["massimo"].ToString()) + 1;
            help.disconnetti();

            help.connetti();
            help.assegnaComando("INSERT INTO Utenti VALUES(" + app + ",'" + nome + "','" + cognome + "','" + email + "','" + psw + "','" + Session["Versione"].ToString() + "',#" + oggi + "#)");
            help.eseguicomando();
            help.disconnetti();
            Session["Utente"] = app.ToString();
            Session["Azienda"] = "mia";
            Response.Redirect("AggiungiAnagrafica.aspx");
        }
        catch
        {
            Response.Write("Qualcosa non va");
        }
    }
}