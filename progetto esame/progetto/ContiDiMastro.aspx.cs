using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ContiDiMastro : System.Web.UI.Page
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
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Col1"] = string.Empty;
        dr["Col2"] = string.Empty;
        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;


        grvPrimaNota.DataSource = dt;
        grvPrimaNota.DataBind();

        Button btnAdd = (Button)grvPrimaNota.FooterRow.Cells[2].FindControl("ButtonAdd");
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
                    TextBox Codice = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("txtCodice");
                    TextBox Nome = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtNome");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = Codice.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Nome.Text;
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
;
                    TextBox Codice = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtCodice");
                    TextBox Nome = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[3].FindControl("txtNome");


                    grvPrimaNota.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    Codice.Text = dt.Rows[i]["Col1"].ToString();
                    Nome.Text = dt.Rows[i]["Col2"].ToString();
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
                    TextBox Codice = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[1].FindControl("txtCodice");
                    TextBox Nome = (TextBox)grvPrimaNota.Rows[rowIndex].Cells[2].FindControl("txtNome");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Col1"] = Codice.Text;
                    dtCurrentTable.Rows[i - 1]["Col2"] = Nome.Text;
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
                    string Nome = row.ItemArray[2] as string;
                    string Cod_azienda = Session["Azienda"].ToString();

                    //mettere un id per il salvataggio, altrimenti è un casino
                    help.connetti();
                    help.assegnaComando("INSERT INTO ContiDiMastro VALUES(" + Codice + ",'" + Nome + "','" + Cod_azienda + "')");
                    help.eseguicomando();
                    help.disconnetti();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}