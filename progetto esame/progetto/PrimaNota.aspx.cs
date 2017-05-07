using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrimaNota : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int rowIndex = 0;
        if (!IsPostBack)
        {
            SetInitialRow();
        }

        DropDownList IVA = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("comboIVA");
        string[] iva = { "4", "10", "22" };
        IVA.Items.Add(iva[0]);
        IVA.Items.Add(iva[1]);
        IVA.Items.Add(iva[2]);

    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("Numero", typeof(string)));
        dt.Columns.Add(new DataColumn("Tipo", typeof(string)));
        dt.Columns.Add(new DataColumn("IVA", typeof(string)));
        dt.Columns.Add(new DataColumn("Imponibile", typeof(string)));
        dt.Columns.Add(new DataColumn("Importo iva", typeof(string)));
        dt.Columns.Add(new DataColumn("Conto di mastro", typeof(string)));
        dr = dt.NewRow();
        dr["Numero"] = 1;
        dr["Tipo"] = string.Empty;
        dr["IVA"] = string.Empty;
        dr["Imponibile"] = string.Empty;
        dr["Importo IVA"] = string.Empty;
        dr["Conto di mastro"] = string.Empty;
        dt.Rows.Add(dr);
        dr = dt.NewRow();

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }

    private void AddNewRowToGrid()
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
                    //estraggo i dati
                    DropDownList Tipo = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("comboTipo");
                    DropDownList IVA = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("comboIVA");
                    TextBox Imponibile = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox3");
                    Label lblImportoIva = (Label)Gridview1.Rows[rowIndex].Cells[3].FindControl("lblImpoIva");
                    DropDownList ContoMastro = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("comboConto");
                    Imponibile.Text = "0";
                    string[] iva = { "4", "10", "22" };
                    IVA.Items.Add(iva[0]);
                    IVA.Items.Add(iva[1]);
                    IVA.Items.Add(iva[2]);
                    int importoiva= int.Parse(Imponibile.Text) * int.Parse(Imponibile.Text) / 100 * int.Parse(IVA.SelectedItem.ToString());
                    lblImportoIva.Text = importoiva.ToString();

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["Numero"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Tipo"] = Tipo.Text;
                    dtCurrentTable.Rows[i - 1]["IVA"] = IVA.Text;
                    dtCurrentTable.Rows[i - 1]["Imponibile"] = Imponibile.Text;
                    dtCurrentTable.Rows[i - 1]["Importo Iva"] = lblImportoIva.Text;
                    dtCurrentTable.Rows[i - 1]["Conto di mastro"] = ContoMastro.Text;

                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                Gridview1.DataSource = dtCurrentTable;
                Gridview1.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
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
                    DropDownList Tipo = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("comboTipo");
                    DropDownList IVA = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("comboIVA");
                    TextBox Imponibile = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox3");
                    Label lblImportoIva = (Label)Gridview1.Rows[rowIndex].Cells[3].FindControl("lblImpoIva");
                    DropDownList ContoMastro = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("comboTipo");


                    Tipo.Text = dt.Rows[i]["Tipo"].ToString();
                    IVA.Text = dt.Rows[i]["IVA"].ToString();
                    Imponibile.Text = dt.Rows[i]["Imponibile"].ToString();
                    lblImportoIva.Text = dt.Rows[i]["Importo iva"].ToString();
                    ContoMastro.Text = dt.Rows[i]["Conto di mastro"].ToString();

                    rowIndex++;
                }
            }
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Gridview1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}