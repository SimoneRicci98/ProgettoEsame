using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class PrimaNota : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    HttpCookie myCookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        #region carico clienti
        help.connetti();
        help.assegnaComando("SELECT RagioneSociale FROM Clienti WHERE COD_Azienda = '"+Session["Azienda"].ToString()+"'");
        rs = help.estraiDati();
        while(rs.Read())
        {
            DropDownList1.Items.Add(rs["RagioneSociale"].ToString());
        }
        help.disconnetti();
        #endregion
        #region carico fornitori
        help.connetti();
        help.assegnaComando("SELECT RagioneSociale FROM Fornitori WHERE COD_Azienda = '" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        while (rs.Read())
        {
            DropDownList2.Items.Add(rs["RagioneSociale"].ToString());
        }
        help.disconnetti();
#endregion
        myCookie = Request.Cookies["PopUp"];
        if (!IsPostBack)
        {
            FirstGridViewRow();
        }
    }
    private void FirstGridViewRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Col1", typeof(string)));
        dt.Columns.Add(new DataColumn("Col2", typeof(string)));
        dt.Columns.Add(new DataColumn("Col3", typeof(string)));
        dt.Columns.Add(new DataColumn("Col4", typeof(string)));
        dt.Columns.Add(new DataColumn("Col5", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Col1"] = string.Empty;
        dr["Col2"] = string.Empty;
        dr["Col3"] = string.Empty;
        dr["Col4"] = string.Empty;
        dr["Col5"] = string.Empty;
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        grvPrimaNota.DataSource = dt;
        grvPrimaNota.DataBind();
        help.connetti();
        help.assegnaComando("Select Conto from ContiDiMastro WHERE COD_Azienda=0 OR COD_Azienda="+Session["Azienda"].ToString());
        rs = help.estraiDati();
        DropDownList ContoMastro = (DropDownList)grvPrimaNota.Rows[0].Cells[1].FindControl("drpConto");
        while(rs.Read())
        {
            ContoMastro.Items.Add(rs["Conto"].ToString());
        }
        help.disconnetti();
        Button btnAdd = (Button)grvPrimaNota.FooterRow.Cells[5].FindControl("ButtonAdd");
        Page.Form.DefaultFocus = btnAdd.ClientID;
    }
    private void AddNewRow()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    DropDownList ContoMastro = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("drpConto");
                    TextBox Avere = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtAvere");
                    TextBox Dare = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtDare");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("drpIva");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    help.connetti();
                    help.assegnaComando("Select Conto from ContiDiMastro WHERE COD_Azienda=0 OR COD_Azienda=" + Session["Azienda"].ToString());
                    rs = help.estraiDati();
                    while (rs.Read())
                    {
                        ContoMastro.Items.Add(rs["Conto"].ToString());
                    }
                    help.disconnetti();

                    dtCurrentTable.Rows[i - 1]["Col1"] = ContoMastro.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Avere.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Dare.Text;
                    dtCurrentTable.Rows[i - 1]["Col4"] = Iva.SelectedValue;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                grvPrimaNota.DataSource = dtCurrentTable;
                grvPrimaNota.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList ContoMastro = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("drpConto");
                    TextBox Avere = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtAvere");
                    TextBox Dare = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtDare");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("drpIva");

                    help.connetti();
                    help.assegnaComando("Select Conto from ContiDiMastro WHERE COD_Azienda=0 OR COD_Azienda=" + Session["Azienda"].ToString());
                    rs = help.estraiDati();
                    while (rs.Read())
                    {
                        ContoMastro.Items.Add(rs["Conto"].ToString());
                    }
                    help.disconnetti();

                    grvPrimaNota.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    ContoMastro.Text = dt.Rows[i]["Col1"].ToString();
                    Avere.Text = dt.Rows[i]["Col2"].ToString();
                    Dare.Text = dt.Rows[i]["Col3"].ToString();
                    Iva.SelectedValue = dt.Rows[i]["Col4"].ToString();
                    rowIndex++;
                }
            }
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRow();
    }
    protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;
                grvPrimaNota.DataSource = dt;
                grvPrimaNota.DataBind();

                for (int i = 0; i < grvPrimaNota.Rows.Count - 1; i++)
                {
                    grvPrimaNota.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
                SetPreviousData();
            }
        }
    }

    private void SetRowData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            { 
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    DropDownList ContoMastro = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("drpConto");
                    TextBox Avere = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtAvere");
                    TextBox Dare = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtDare");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("drpIva");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = ContoMastro.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Avere.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Dare.Text;
                    dtCurrentTable.Rows[i - 1]["Col4"] = Iva.SelectedValue;
                    rowIndex++;
                }
                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            #region assegno variabili
            string codCliFor="";
            string descrizione = txtDesc.Text;
            string protocollo = txtProt.Text;
            string NumDoc = txtNumDoc.Text;
            string totDoc = txtTot.Text;
            string dataOperazione = txtDataOperazione.Text;
            string dataFattura = txtDataFattura.Text;
            #endregion
            #region controllo radiobutton
            if(radioCliente.Checked)
            {
                help.connetti();
                help.assegnaComando("SELECT ID_Azienda FROM Clienti WHERE COD_Azienda = '"+Session["Azienda"].ToString()+
                    "' AND RagioneSociale = '"+DropDownList1.SelectedItem.Text+"'");
                rs = help.estraiDati();
                rs.Read();
                codCliFor = "Cliente_" + rs["ID_Azienda"].ToString();
                help.disconnetti();
            }
            if (radioFornitore.Checked)
            {
                help.connetti();
                help.assegnaComando("SELECT ID_Azienda FROM Fornitori WHERE COD_Azienda = '" + Session["Azienda"].ToString() +
                    "' AND RagioneSociale = '" + DropDownList2.SelectedItem.Text + "'");
                rs = help.estraiDati();
                rs.Read();
                codCliFor = "Fornitore_" + rs["ID_Azienda"].ToString();
                help.disconnetti();
            }
            #endregion
            if(!radioFornitore.Checked && !radioCliente.Checked)
            {
                MessageBox.Show("Selezionare cliente o fornitore");
            }
            else
            {
                DateTime oggi = DateTime.Today;
                if(DateTime.Parse(txtDataFattura.Text)<=oggi && DateTime.Parse(txtDataOperazione.Text) <= oggi)
                {
                    lblErr1.Visible = false;
                    lblErr2.Visible = false;
                    SetRowData();
                    DataTable table = ViewState["CurrentTable"] as DataTable;
                    if (table != null)
                    {
                        foreach (DataRow row in table.Rows)
                        {

                            help.connetti();
                            help.assegnaComando("SELECT MAX (ID_Scrittura) AS massimo FROM Giornale");
                            rs = help.estraiDati();
                            rs.Read();
                            int app = int.Parse(rs["massimo"].ToString()) + 1;
                            help.disconnetti();
                            string ContoMastro = row.ItemArray[1] as string;
                            string Avere = row.ItemArray[2] as string;
                            string Dare = row.ItemArray[3] as string;
                            string Iva = row.ItemArray[4] as string;
                            if (Dare != string.Empty)
                            {
                                help.connetti();
                                help.assegnaComando("INSERT INTO Giornale" +
                                    " VALUES('" + app +
                                    "','" + Session["Azienda"].ToString() +
                                    "','" + ContoMastro +
                                    "','Dare_" + Dare +
                                    "','" + totDoc +
                                    "','" + codCliFor +
                                    "','" + descrizione +
                                    "','" + Iva +
                                    "','" + NumDoc +
                                    "','" + protocollo +
                                    "','" + dataOperazione +
                                    "','" + dataFattura + "')");
                                help.eseguicomando();
                                help.disconnetti();
                            }
                            else
                            {
                                help.connetti();
                                help.assegnaComando("INSERT INTO Giornale" +
                                    " VALUES('" + app +
                                    "','" + Session["Azienda"].ToString() +
                                    "','" + ContoMastro +
                                    "','Avere_" + Avere +
                                    "','" + totDoc +
                                    "','" + codCliFor +
                                    "','" + descrizione +
                                    "','" + Iva +
                                    "','" + NumDoc +
                                    "','" + protocollo +
                                    "','" + dataOperazione +
                                    "','" + dataFattura + "')");
                                help.eseguicomando();
                                help.disconnetti();
                            }
                        }
                    }
                    pulisciPagina();
                }
                else
                {
                    if(DateTime.Parse(txtDataFattura.Text) > oggi)
                    {
                        lblErr1.Visible = true;
                    }
                    if(DateTime.Parse(txtDataOperazione.Text) > oggi)
                    {
                        lblErr2.Visible = true;
                    }
                }

            }            
        }
        catch(FormatException)
        {
            MessageBox.Show("Inserire le date in modo corretto");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void pulisciPagina()
    {
        txtDesc.Text = string.Empty;
        txtNumDoc.Text = string.Empty;
        txtProt.Text = string.Empty;
        txtTot.Text = string.Empty;
        txtDataOperazione.Text = string.Empty;
        txtDataFattura.Text = string.Empty;
        radioCliente.Checked = false;
        radioEmessa.Checked = false;
        radioFornitore.Checked = false;
        radioRicevuta.Checked = false;
        FirstGridViewRow();
    }

    protected void btnAggCli_Click(object sender, EventArgs e)
    {
        if (myCookie == null)
        {
            myCookie = new HttpCookie("PopUp");
            DateTime now = DateTime.Now;
            myCookie.Value = "";
            myCookie.Expires = now.AddYears(10);
            Response.Cookies.Add(myCookie);
            MessageBox.Show("Nel caso non si aprisse alcuna finestra è possibile che il vostro broswer blocchi i pop-up, è possibile attivare i pop-up per questa pagina nella casella dell'url, a destra");
        }
        Session["Fornitore"] = false;
        Session["Cliente"] = true;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('AggiungiAnagrafica.aspx','_blank')", true);
    }

    protected void btnAggFor_Click(object sender, EventArgs e)
    {
        if (myCookie == null)
        {
            myCookie = new HttpCookie("PopUp");
            DateTime now = DateTime.Now;
            myCookie.Value = "";
            myCookie.Expires = now.AddYears(10); 
            Response.Cookies.Add(myCookie);
            MessageBox.Show("Nel caso non si aprisse alcuna finestra è possibile che il vostro broswer blocchi i pop-up, è possibile attivare i pop-up per questa pagina nella casella dell'url, a destra");
        }
        Session["Fornitore"] = true;
        Session["Cliente"] = false;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('AggiungiAnagrafica.aspx','_blank')", true);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Giornale.aspx");
    }
}