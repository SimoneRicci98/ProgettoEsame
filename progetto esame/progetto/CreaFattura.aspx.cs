using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class EmettiFattura : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
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

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Col1"] = string.Empty;
        dr["Col2"] = string.Empty;
        dr["Col3"] = string.Empty;
        dr["Col4"] = string.Empty;
        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;


        grvPrimaNota.DataSource = dt;
        grvPrimaNota.DataBind();
        help.connetti();
        help.assegnaComando("SELECT Descrizione FROM Prodotti WHERE COD_Azienda='" + Session["Azienda"].ToString() + "'");
        rs = help.estraiDati();
        DropDownList Prodotto = (DropDownList)grvPrimaNota.Rows[0].Cells[1].FindControl("drpProd");
        while (rs.Read())
        {
            Prodotto.Items.Add(rs["Descrizione"].ToString());
        }
        help.disconnetti();

        Button btnAdd = (Button)grvPrimaNota.FooterRow.Cells[4].FindControl("ButtonAdd");
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
                    DropDownList Prodotto = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("drpProd");
                    TextBox Quantità = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtQta");
                    TextBox Sconto = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtSconto");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("drpIva");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = Prodotto.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Quantità.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Sconto.Text;
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
                    DropDownList Prodotto = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("drpProd");
                    TextBox Quantità = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtQta");
                    TextBox Sconto = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtSconto");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("drpIva");

                    help.connetti();
                    help.assegnaComando("SELECT Descrizione FROM Prodotti WHERE COD_Azienda='" + Session["Azienda"].ToString()+"'");
                    rs = help.estraiDati();
                    while (rs.Read())
                    {
                        Prodotto.Items.Add(rs["Descrizione"].ToString());
                    }
                    help.disconnetti();

                    grvPrimaNota.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    Prodotto.SelectedValue = dt.Rows[i]["Col1"].ToString();
                    Quantità.Text = dt.Rows[i]["Col2"].ToString();
                    Sconto.Text = dt.Rows[i]["Col3"].ToString();
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
                    DropDownList Prodotto = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("drpProd");
                    TextBox Quantità = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtQta");
                    TextBox Sconto = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtSconto");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("drpIva");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = Prodotto.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Quantità.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Sconto.Text;
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
            SetRowData();
            DataTable table = ViewState["CurrentTable"] as DataTable;

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    string NomeCliente = DropDownList1.SelectedItem.Text;
                    bool trovato=false;
                    Session["Numero"] = txtNumero.Text;

                    help.connetti();
                    help.assegnaComando("CREATE VIEW vista AS (SELECT RagioneSociale,ID_Azienda FROM Clienti WHERE COD_Azienda ='" + Session["Azienda"].ToString()+"')");
                    help.eseguicomando();
                    help.disconnetti();
                    help.connetti();
                    help.assegnaComando("SELECT ID_Azienda FROM vista WHERE RagioneSociale='"+NomeCliente+"'");
                    rs = help.estraiDati();
                    rs.Read();
                    string app = rs["ID_Azienda"].ToString();
                    help.disconnetti();
                    help.connetti();
                    help.assegnaComando("DROP VIEW vista");
                    help.eseguicomando();
                    help.disconnetti();


                    help.connetti();
                    help.assegnaComando("SELECT Numero FROM Fattura WHERE COD_Cliente='" + app + "' AND COD_Azienda='" + Session["Azienda"].ToString() + "'");
                    rs = help.estraiDati();
                    while (rs.Read())
                    {
                        if (rs["Numero"].ToString() == txtNumero.Text)
                        {
                            lblErrNum.Text = "Numero fattura già esistente per questo cliente";
                            trovato = true;
                        }
                    }
                    txtNumero.Focus();
                    help.disconnetti();

                    if(!trovato)
                    {
                        string oggetto = txtOggetto.Text;
                        string data = txtData.Text;
                        string tipoPagamento = txtPagamento.Text;

                        string Descrizione = row.ItemArray[1] as string;
                        string Quantità = row.ItemArray[2] as string;
                        string Sconto = row.ItemArray[3] as string;
                        string Iva = row.ItemArray[4] as string;
   
                        help.connetti();
                        help.assegnaComando("SELECT ID_Azienda FROM Clienti WHERE RagioneSociale = '" + NomeCliente + "'");
                        rs = help.estraiDati();
                        rs.Read();
                        Session["ID_Cliente"] = rs["ID_Azienda"].ToString();
                        help.disconnetti();

                        help.connetti();
                        help.assegnaComando("SELECT Qta FROM Prodotti WHERE COD_Azienda='" + Session["Azienda"].ToString() + "' AND Descrizione = '" + Descrizione + "'");
                        rs=help.estraiDati();
                        rs.Read();
                        if(int.Parse(rs["Qta"].ToString())!=0)
                        {
                            help.disconnetti();
                        #region creazione fattura
                        help.connetti();
                        help.assegnaComando("SELECT ID_Prodotto,Prezzo FROM Prodotti WHERE COD_Azienda='" + Session["Azienda"].ToString()+"' AND Descrizione = '"+Descrizione+"'");
                        rs = help.estraiDati();
                        rs.Read();
                        string CodiceArticolo = rs["ID_Prodotto"].ToString();
                        string PrezzoUnitario = rs["Prezzo"].ToString();
                        int Importo = int.Parse(PrezzoUnitario) * int.Parse(Quantità);
                        help.disconnetti();

                        help.connetti();
                        help.assegnaComando("INSERT INTO Fattura(Numero,CodArticolo,Descrizione,Quantità,PrezzoUnitario,Sconto,Importo,Iva,Oggetto,TipoPagamento,Data,COD_Cliente,COD_Azienda) " +
                            "VALUES('" + Session["Numero"].ToString() +
                            "','" + CodiceArticolo +
                            "','" + Descrizione +
                            "','" + Quantità +
                            "','" + PrezzoUnitario +
                            "','" + Sconto +
                            "','" + Importo +
                            "','" + Iva +
                            "','" + oggetto +
                            "','" + tipoPagamento +
                            "','" + data +
                            "','" + Session["ID_Cliente"].ToString() +
                            "','" + Session["Azienda"].ToString() + "')");
                        help.eseguicomando();
                        help.disconnetti();
                        btnVisual.Enabled = true;
                        #endregion
                        }
                        else
                        {
                            help.disconnetti();
                            MessageBox.Show("Impossibile emettere la fattura, uno o più prodotti sono terminati");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void HiddenField1_ValueChanged(object sender, EventArgs e)
    {

    }

    protected void btnVisual_Click(object sender, EventArgs e)
    {
            if (Session["Numero"] != null)
                Response.Redirect("VisualizzaFattura.aspx");
            else
                MessageBox.Show("Salvare prima la fattura!");
        

    }

    protected void txtData_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtNumero_TextChanged(object sender, EventArgs e)
    {
    }

    protected void txtOggetto_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnVisual0_Click(object sender, EventArgs e)
    {
        Session["Numero"] = txtVisualNum.Text;
        Response.Redirect("VisualizzaFattura.aspx");
    }
}