using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Prodotti : System.Web.UI.Page
{
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


        grvProdotti.DataSource = dt;
        grvProdotti.DataBind();

        Button btnAdd = (Button)grvProdotti.FooterRow.Cells[2].FindControl("ButtonAdd");
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
                    TextBox Codice = (TextBox)grvProdotti.Rows[rowIndex].Cells[1].FindControl("txtCodice");
                    TextBox Descrizione = (TextBox)grvProdotti.Rows[rowIndex].Cells[2].FindControl("txtNome");
                    TextBox Prezzo = (TextBox)grvProdotti.Rows[rowIndex].Cells[3].FindControl("txtPrezzo");
                    TextBox Qta = (TextBox)grvProdotti.Rows[rowIndex].Cells[4].FindControl("txtQta");


                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = Codice.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Descrizione.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Prezzo.Text;
                    dtCurrentTable.Rows[i - 1]["Col4"] = Qta.Text;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                grvProdotti.DataSource = dtCurrentTable;
                grvProdotti.DataBind();
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
                    ;
                    TextBox Codice = (TextBox)grvProdotti.Rows[rowIndex].Cells[1].FindControl("txtCodice");
                    TextBox Descrizione = (TextBox)grvProdotti.Rows[rowIndex].Cells[2].FindControl("txtDesc");
                    TextBox Prezzo = (TextBox)grvProdotti.Rows[rowIndex].Cells[3].FindControl("txtPrezzo");
                    TextBox Qta = (TextBox)grvProdotti.Rows[rowIndex].Cells[4].FindControl("txtQta");


                    grvProdotti.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    Codice.Text = dt.Rows[i]["Col1"].ToString();
                    Descrizione.Text = dt.Rows[i]["Col2"].ToString();
                    Prezzo.Text = dt.Rows[i]["Col3"].ToString();
                    Qta.Text = dt.Rows[i]["Col4"].ToString();
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
                grvProdotti.DataSource = dt;
                grvProdotti.DataBind();

                for (int i = 0; i < grvProdotti.Rows.Count - 1; i++)
                {
                    grvProdotti.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
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
                    TextBox Codice = (TextBox)grvProdotti.Rows[rowIndex].Cells[1].FindControl("txtCodice");
                    TextBox Descrizione = (TextBox)grvProdotti.Rows[rowIndex].Cells[2].FindControl("txtDesc");
                    TextBox Prezzo = (TextBox)grvProdotti.Rows[rowIndex].Cells[3].FindControl("txtPrezzo");
                    TextBox Qta = (TextBox)grvProdotti.Rows[rowIndex].Cells[4].FindControl("txtQta");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = Codice.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Prezzo.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Prezzo.Text;
                    dtCurrentTable.Rows[i - 1]["Col4"] = Qta.Text;
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
            dbHelper help = new dbHelper();
            SetRowData();
            DataTable table = ViewState["CurrentTable"] as DataTable;

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    string Codice = row.ItemArray[1] as string;
                    string Descrizione = row.ItemArray[2] as string;
                    string Prezzo = row.ItemArray[3] as string;
                    string Qta = row.ItemArray[4] as string;
                    string Cod_azienda = Session["Azienda"].ToString();

                    help.connetti();
                    help.assegnaComando("INSERT INTO Prodotti(ID_Prodotto,Descrizione,Prezzo,Qta,COD_Azienda) VALUES('" + Codice + "','" + Descrizione + "',"+Prezzo +","+Qta+",'"+ Cod_azienda + "')");
                    help.eseguicomando();
                    help.disconnetti();
                }
                MessageBox.Show("Prodotti aggiunti correttamente");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}