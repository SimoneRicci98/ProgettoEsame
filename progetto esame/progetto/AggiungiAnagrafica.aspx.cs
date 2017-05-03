using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class AggiungiAnagrafica : System.Web.UI.Page
{
    dbHelper help = new dbHelper("ContabilitàDB.accdb");

    protected void Page_Load(object sender, EventArgs e)
    { 
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        #region variabili
        string RagioneSociale;
        string NomeCognome;
        string PIva;
        string CodFisc;
        string Indirizzo;
        string Provincia;
        string Cap;
        string Regione;
        string Nazione;
        string NumCell;
        string Fax;
        string Tel;
        string Email;
        #endregion
        if (Session["Versione"] != null)
        {
            if ((int)Session["Versione"] == 0)
            {
                #region assegno valori alle variabili
                RagioneSociale = txtRagSoc.Text;
                NomeCognome = txtNomCog.Text;
                PIva = txtPIva.Text;
                CodFisc = txtCodF.Text;
                Indirizzo = txtIndirizzo.Text;
                Provincia = txtProv.Text;
                Cap = txtCap.Text;
                Regione = txtReg.Text;
                Nazione = txtNaz.Text;
                NumCell = txtNUmCell.Text;
                Fax = txtFax.Text;
                Tel = txtTel.Text;
                Email = txtEmail.Text;
                #endregion

            }
        }
    }
}