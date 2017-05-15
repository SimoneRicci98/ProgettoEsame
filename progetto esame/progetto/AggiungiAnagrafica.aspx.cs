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
            if((bool)Session["Cliente"])
            {
                lblAz.Text = " del cliente";
                Session["Operazione"] = "cli";
                btnChiudi.Visible = true;
            }
            else
            if ((bool)Session["Fornitore"])
            {
                lblAz.Text = " del fornitore";
                Session["Operazione"] = "for";
                btnChiudi.Visible = true;
            }
            else
            if (Session["Azienda"] is int)
            {
                lblAz.Text = " della tua azienda";
                Session["Operazione"] = "mia";
                btnChiudi.Visible = false;
            }
            else if(Session["Azienda"]!=null)
            {
                lblAz.Text = " della tua azienda";
                Session["Operazione"] = "mia";
                btnChiudi.Visible = false;
            }
        }
        catch
        {

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
        string Fax;
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
                Fax = txtFax.Text;
                Tel = txtTel.Text;
                Email = txtEmail.Text;
        #endregion
 
            try
            {
                switch (Session["Operazione"].ToString())
                {
                    case "mia":
                        #region inserimento dati propria azienda
                        help.connetti();
                        help.assegnaComando("INSERT INTO Aziende(COD_Proprietario,RagioneSociale,Numero,Indirizzo,PartitaIVA,CodFiscale,NomeCog,Provincia,Cap,Regione,Nazione,TelAzienda,Email) " +
                            "VALUES('" + Session["Utente"].ToString() + "','" + RagioneSociale + "','" + NumCell + "','" + Indirizzo + "','" + PIva + "','" + CodFisc + "','" + NomeCognome + "','" + Provincia + "','" + Cap + "','" + Regione + "','" + Nazione + "','" + Tel + "','" + Email + "')");
                        help.eseguicomando();
                        help.disconnetti();
                        Response.Redirect("Seleziona.aspx");
                        #endregion
                        break;
                    case "cli":
                        #region insetimento dati nella tabella clienti
                        help.connetti();
                        help.assegnaComando("INSERT INTO Clienti(COD_Azienda,RagioneSociale,Numero,Indirizzo,PartitaIVA,CodFiscale,NomeCog,Provincia,Cap,Regione,Nazione,TelAzienda,Email) " +
                            "VALUES('" + Session["Azienda"].ToString() + "','" + RagioneSociale + "','" + NumCell + "','" + Indirizzo + "','" + PIva + "','" + CodFisc + "','" + NomeCognome + "','" + Provincia + "','" + Cap + "','" + Regione + "','" + Nazione + "','" + Tel + "','" + Email + "')");
                        help.eseguicomando();
                        help.disconnetti();
                        #endregion
                    break;
                    case "for":
                        #region inserimento dati nella tabella fornitori
                        help.connetti();
                        help.assegnaComando("INSERT INTO Fornitori(COD_Azienda,RagioneSociale,Numero,Indirizzo,PartitaIVA,CodFiscale,NomeCog,Provincia,Cap,Regione,Nazione,TelAzienda,Email) " +
                            "VALUES('" + Session["Azienda"].ToString() + "','" + RagioneSociale + "','" + NumCell + "','" + Indirizzo + "','" + PIva + "','" + CodFisc + "','" + NomeCognome + "','" + Provincia + "','" + Cap + "','" + Regione + "','" + Nazione + "','" + Tel + "','" + Email + "')");
                        help.eseguicomando();
                        help.disconnetti();
                    #endregion
                    break;
                    default:
                        break;

                }
            }
            catch
            {
                Response.Write("Errore");
            }
    }

    protected void btnChiudi_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }
}