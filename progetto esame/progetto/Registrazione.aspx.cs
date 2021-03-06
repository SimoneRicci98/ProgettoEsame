﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Registrazione : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            bool presente = false;
            int app = 0;
            string nome = txtNome.Text;
            string cognome = txtCognome.Text;
            string email = txtEmail.Text;
            string psw = txtPass.Text;
            if (nome.Trim() != string.Empty || cognome.Trim() != string.Empty || email.Trim() != string.Empty || psw.Trim() != string.Empty)
            {
                help.connetti();
                help.assegnaComando("SELECT Email FROM Utenti");
                rs = help.estraiDati();
                while (rs.Read() && presente == false)
                {
                    if (rs["Email"].ToString() == email)
                    {
                        lblErr.Text = "Email già presente";
                        presente = true;
                    }
                }
                help.disconnetti();
                if (!presente)
                {
                    help.connetti();
                    help.assegnaComando("SELECT MAX (ID_Utente) AS massimo FROM Utenti");
                    rs = help.estraiDati();
                    rs.Read();
                    app = int.Parse(rs["massimo"].ToString()) + 1;
                    help.disconnetti();

                    help.connetti();
                    help.assegnaComando("INSERT INTO Utenti VALUES(" + app + ",'" + nome + "','" + cognome + "','" + email + "','" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(psw, "md5") + "','" + Session["Versione"].ToString() + "')");
                    help.eseguicomando();
                    help.disconnetti();
                    Session["Utente"] = app.ToString();
                    Session["Azienda"] = true;

                    Response.Redirect("AggiungiAnagrafica.aspx");
                }
            }
            else
            {
                lblErr.Text = "Compila tutti i campi";
            }
        }
        catch
        {
            Response.Write("Qualcosa non va");
        }
    }

}
