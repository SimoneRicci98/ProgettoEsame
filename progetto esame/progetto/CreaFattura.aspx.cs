using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmettiFattura : System.Web.UI.Page
{
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
        dt.Columns.Add(new DataColumn("Col5", typeof(string)));
        dt.Columns.Add(new DataColumn("Col6", typeof(string)));
        dt.Columns.Add(new DataColumn("Col7", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Col1"] = string.Empty;
        dr["Col2"] = string.Empty;
        dr["Col3"] = string.Empty;
        dr["Col4"] = string.Empty;
        dr["Col5"] = string.Empty;
        dr["Col6"] = string.Empty;
        dr["Col7"] = string.Empty;
        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;


        grvPrimaNota.DataSource = dt;
        grvPrimaNota.DataBind();

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
                    TextBox CodiceArticolo = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("txtCodArt");
                    TextBox Descrizione = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtDesc");
                    TextBox Quantità = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtQta");
                    TextBox PrezzoUnitario = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("txtPrezzo");
                    TextBox Sconto = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[5].FindControl("txtSconto");
                    TextBox Importo = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[6].FindControl("txtImporto");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[7].FindControl("drpIva");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = CodiceArticolo.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Descrizione.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Quantità.Text;
                    dtCurrentTable.Rows[i - 1]["Col4"] = PrezzoUnitario.Text;
                    dtCurrentTable.Rows[i - 1]["Col5"] = Sconto.Text;
                    dtCurrentTable.Rows[i - 1]["Col6"] = Importo.Text;
                    dtCurrentTable.Rows[i - 1]["Col7"] = Iva.SelectedValue;

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
                    TextBox CodiceArticolo = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("txtCodArt");
                    TextBox Descrizione = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtDesc");
                    TextBox Quantità = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtQta");
                    TextBox PrezzoUnitario = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("txtPrezzo");
                    TextBox Sconto = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[5].FindControl("txtSconto");
                    TextBox Importo = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[6].FindControl("txtImporto");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[7].FindControl("drpIva");


                    grvPrimaNota.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    CodiceArticolo.Text = dt.Rows[i]["Col1"].ToString();
                    Descrizione.Text = dt.Rows[i]["Col2"].ToString();
                    Quantità.Text = dt.Rows[i]["Col3"].ToString();
                    PrezzoUnitario.Text = dt.Rows[i]["Col4"].ToString();
                    Sconto.Text = dt.Rows[i]["Col5"].ToString();
                    Importo.Text = dt.Rows[i]["Col6"].ToString();
                    Iva.SelectedValue = dt.Rows[i]["Col7"].ToString();
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
                    TextBox CodiceArticolo = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("txtCodArt");
                    TextBox Descrizione = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtDesc");
                    TextBox Quantità = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtQta");
                    TextBox PrezzoUnitario = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[4].FindControl("txtPrezzo");
                    TextBox Sconto = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[5].FindControl("txtSconto");
                    TextBox Importo = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[6].FindControl("txtImporto");
                    DropDownList Iva = (DropDownList)grvPrimaNota.Rows[rowIndex].Cells[7].FindControl("drpIva");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = CodiceArticolo.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Descrizione.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = Quantità.Text;
                    dtCurrentTable.Rows[i - 1]["Col4"] = PrezzoUnitario.Text;
                    dtCurrentTable.Rows[i - 1]["Col5"] = Sconto.Text;
                    dtCurrentTable.Rows[i - 1]["Col6"] = Importo.Text;
                    dtCurrentTable.Rows[i - 1]["Col7"] = Iva.SelectedValue;

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
                    string CodiceArticolo = row.ItemArray[1] as string;
                    string Descrizione = row.ItemArray[2] as string;
                    string Quantità = row.ItemArray[3] as string;
                    string PrezzoUnitario = row.ItemArray[4] as string;
                    string Sconto = row.ItemArray[5] as string;
                    string Importo = row.ItemArray[6] as string;
                    string Iva = row.ItemArray[7] as string;
                    /*if (Dare != null)
                    {
                        help.connetti();
                        help.assegnaComando("INSERT INTO Giornale(COD_Azienda,ContoMastro,DareAvere,Imponibile,COD_Cliente/Fornitore) VALUES('" + Session["Azienda"].ToString() + "','" + ContoMastro + "','" + Dare + "','" + Iva + "','" + codCliFor + "')");
                        help.eseguicomando();
                        help.disconnetti();
                    }
                    else
                    {
                        help.connetti();
                        help.assegnaComando("INSERT INTO Giornale(COD_Azienda,ContoMastro,DareAvere,Imponibile,COD_Cliente/Fornitore) VALUES('" + Session["Azienda"].ToString() + "','" + ContoMastro + "','" + Avere + "','" + Iva + "','" + codCliFor + "')");
                        help.eseguicomando();
                        help.disconnetti();
                    }*/


                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}