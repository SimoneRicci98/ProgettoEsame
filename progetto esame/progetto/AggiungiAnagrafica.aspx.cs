using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AggiungiAnagrafica : System.Web.UI.Page
{
    dbHelper help = new dbHelper();

    protected void Page_Load(object sender, EventArgs e)
    { 
        try
        {
            if (Session["Azienda"] != null)
            {
                lblAz.Text = " della tua azienda";
                Session["Operazione"] = "0";
                btnChiudi.Visible = false;
            }
            if (Session["Cliente"] != null && Session["Fornitore"] != null)
            {
                if ((bool)Session["Cliente"])
                {
                    lblAz.Text = " del cliente";
                    Session["Operazione"] = "1";
                    btnChiudi.Visible = true;
                }
                else
                if ((bool)Session["Fornitore"])
                {
                    lblAz.Text = " del fornitore";
                    Session["Operazione"] = "2";
                    btnChiudi.Visible = true;
                }
            }

        }
        catch
        {
            MessageBox.Show("C'è stato un errore");
        }

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
        string Tel;
        string Email;
        #endregion
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
                Tel = txtTel.Text;
                Email = txtEmail.Text;
                bool err1 = false;
                bool err2 = false;
        #endregion
            switch (CodFisc.Length)
            {
                case 11:
                    break;
                case 16:
                    break;
                default: err1 = true;
                    lblErr1.Text = "Codice fiscale inserito in modo errato";
                    break;
            }
            if (PIva.Length!=11)
            {
                err2 = true;
                lblErr0.Text = "Partita iva inserita in modo errato";
            }
        if(!err1 && !err2)
        {
            try
            {
                string operazione = Session["Operazione"].ToString();
                switch (operazione)
                {
                    case "0":
                        #region inserimento dati propria azienda 
                        help.connetti();
                        help.assegnaComando("INSERT INTO Aziende(COD_Proprietario,RagioneSociale,Numero,Indirizzo,PartitaIVA,CodFiscale,NomeCog,Provincia,Cap,Regione,Nazione,TelAzienda,Email,Tipo,CLiFor) " +
                            "VALUES('" + Session["Utente"].ToString() + "','" + RagioneSociale + "','" + NumCell + "','" + Indirizzo + "','" + PIva + "','" + CodFisc + "','" + NomeCognome + "','" + Provincia + "','" + Cap + "','" + Regione + "','" + Nazione + "','" + Tel + "','" + Email + "',"+operazione+",0)");
                        help.eseguicomando();
                        help.disconnetti();
                        Response.Redirect("Seleziona.aspx");
                        #endregion
                        break;
                    case "1":
                        #region insetimento dati clienti
                        help.connetti();
                        help.assegnaComando("INSERT INTO Aziende(COD_Proprietario,RagioneSociale,Numero,Indirizzo,PartitaIVA,CodFiscale,NomeCog,Provincia,Cap,Regione,Nazione,TelAzienda,Email,Tipo,CliFor) " +
                            "VALUES('" + 0 + "','" + RagioneSociale + "','" + NumCell + "','" + Indirizzo + "','" + PIva + "','" + CodFisc + "','" + NomeCognome + "','" + Provincia + "','" + Cap + "','" + Regione + "','" + Nazione + "','" + Tel + "','" + Email + "',"+operazione+","+Session["Azienda"].ToString()+")");
                        help.eseguicomando();
                        help.disconnetti();
                        #endregion
                    break;
                    case "2":
                        #region inserimento dati fornitori
                        help.connetti();
                        help.assegnaComando("INSERT INTO Aziende(COD_Proprietario,RagioneSociale,Numero,Indirizzo,PartitaIVA,CodFiscale,NomeCog,Provincia,Cap,Regione,Nazione,TelAzienda,Email,Tipo,Clifor) " +
                            "VALUES('" + 0 + "','" + RagioneSociale + "','" + NumCell + "','" + Indirizzo + "','" + PIva + "','" + CodFisc + "','" + NomeCognome + "','" + Provincia + "','" + Cap + "','" + Regione + "','" + Nazione + "','" + Tel + "','" + Email + "'," + operazione + "," + Session["Azienda"].ToString() + ")");
                        help.eseguicomando();
                        help.disconnetti();
                    #endregion
                    break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
 

    }

    protected void btnChiudi_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }
}