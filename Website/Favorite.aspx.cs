using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Telerik.Web.UI;
using System.Web.Services;
using ePrescription.Data;
using ePrescription.Entities;
public partial class Favorite : System.Web.UI.Page
{
    SqlConnection ePresCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EPrescription"].ConnectionString);
    private const int ItemsPerRequest = 15;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //ViewState["autogen"] = 1;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13]
                { new DataColumn("ID"), new DataColumn("DrugName"), new DataColumn("DrugID"), new DataColumn("Unit")
                , new DataColumn("RouteType"), new DataColumn("Dosage"),new DataColumn("DosageUnit"),new DataColumn("Frequency")
                , new DataColumn("Duration"), new DataColumn("DurationUnit"),new DataColumn("TotalUnit"),new DataColumn("Refill"),new DataColumn("Remark")});
            ViewState["Medications"] = dt;
            rcbFreq.Filter = (RadComboBoxFilter)Convert.ToInt32("1");
            rcbRoute.Filter = (RadComboBoxFilter)Convert.ToInt32("1");
            rptFavorite.DataSource = DataRepository.FavoritMasterProvider.GetAll();
            rptFavorite.DataBind();


        }
    }
    

    protected void rcbSearchMed_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        string sqlSelectCommand = "SELECT [DrugId],[DrugName],[GenericName],GenericName+' ('+DrugName+')' As GenName,[Quantity] FROM [Vr_DrugForPrescription] WHERE genericname Like'%' + @text +'%' or drugname Like'%' + @text +'%' ORDER BY DrugName";
        SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectCommand,
        ConfigurationManager.ConnectionStrings["UFPharma"].ConnectionString);
        adapter.SelectCommand.Parameters.AddWithValue("@text", e.Text);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Text = (string)dataRow["GenName"];
            item.Value = (string)dataRow["DrugName"];
            string DrugID = (string)dataRow["DrugID"];
            string DrugName = (string)dataRow["DrugName"];
            string GenericName = (string)dataRow["GenericName"];
            int Quantity = (int)dataRow["Quantity"];
            item.Attributes.Add("DrugID", DrugID.ToString());
            item.Attributes.Add("DrugName", DrugName.ToString());
            item.Attributes.Add("Genericname", GenericName.ToString());
            item.Attributes.Add("Quantity", Quantity.ToString());
            rcbSearchMed.Items.Add(item);
            item.DataBind();
        }
    }
    protected void rcbSearchMed_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string sqlSelectCommand = "SELECT [DrugID],[GenericName],[Unit],[IsControlDrug], DosageUnit FROM [Vr_DrugForPrescription] WHERE Genericname+' ('+DrugName+')'=@text ";
        SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectCommand,
            ConfigurationManager.ConnectionStrings["UFPharma"].ConnectionString);
        adapter.SelectCommand.Parameters.AddWithValue("@text", rcbSearchMed.Text.ToString());
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        if (dataTable.Rows.Count > 0)
        {
            lblDrugID.Text = dataTable.Rows[0]["DrugID"].ToString();
            lblUnit.Text = dataTable.Rows[0]["Unit"].ToString();
            lblDosageUnit.Text = dataTable.Rows[0]["DosageUnit"].ToString();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void ResetGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[11]
            { new DataColumn("ID"), new DataColumn("DrugName"), new DataColumn("DrugID"), new DataColumn("Unit")
                , new DataColumn("RouteType"), new DataColumn("Dosage"),new DataColumn("DosageUnit"),new DataColumn("Frequency")
                , new DataColumn("Duration"), new DataColumn("DurationUnit"),new DataColumn("TotalUnit")});
        ViewState["Medications"] = dt;
        dt = null;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void BindGrid()
    {
        var dt = (DataTable)ViewState["Medications"];

        foreach (DataRow dr in dt.Rows)
        {
            dr["ID"] = dt.Rows.IndexOf(dr) + 1;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void Add(object sender, EventArgs e)
    {
        if (tbxFavName.Text == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please name the favourite first')", true);
            //Response.Write("<script>alert('Please choose patient first')</script>");
        }
        else
        {
            DataTable dt = (DataTable)ViewState["Medications"];
            dt.Rows.Add(1, rcbSearchMed.Text.Trim(), lblDrugID.Text.Trim(),
            lblUnit.Text.Trim(), rcbRoute.Text.Trim(), tbxDosage.Text.Trim(), lblDosageUnit.Text.Trim(), rcbFreq.SelectedValue,
            tbxDuration.Text.Trim(), ddlDUnit.Text.Trim(), tbxTotalUnit.Text.ToString());
            ViewState["Customers"] = dt;
            this.BindGrid();
            Clear();
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    protected void OnUpdate(object sender, EventArgs e)
    {
        GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        string route = (row.Cells[5].Controls[0] as TextBox).Text;
        string dosage = (row.Cells[7].Controls[0] as TextBox).Text;
        string freq = (row.Cells[9].Controls[0] as TextBox).Text;
        string dur = (row.Cells[10].Controls[0] as TextBox).Text;
        string Dunit = (row.Cells[11].Controls[0] as TextBox).Text;
        string totalunit = (row.Cells[12].Controls[0] as TextBox).Text;

        DataTable dt = ViewState["Medications"] as DataTable;
        dt.Rows[row.RowIndex]["RouteType"] = route;
        dt.Rows[row.RowIndex]["Dosage"] = dosage;
        dt.Rows[row.RowIndex]["Frequency"] = freq;
        dt.Rows[row.RowIndex]["Duration"] = dur;
        dt.Rows[row.RowIndex]["DurationUnit"] = Dunit;
        dt.Rows[row.RowIndex]["TotalUnit"] = totalunit;
       
        ViewState["Medications"] = dt;
        GridView1.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnCancel(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
        }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["Medications"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["Medications"] = dt;
        BindGrid();
    }

    protected void btnClearRowClick(object sender, EventArgs e)
    {
        Clear();
    }
    protected void Clear()
    {
        rcbSearchMed.Text = string.Empty;
        lblDrugID.Text = string.Empty;
        lblUnit.Text = string.Empty;
        rcbRoute.Text = null;
        tbxDosage.Text = string.Empty;
        lblDosageUnit.Text = null;
        rcbFreq.Text = string.Empty;
        tbxDuration.Text = string.Empty;
        tbxTotalUnit.Text = string.Empty;

    }
    protected void ClearForm()
    {
        
        Clear();
        DataTable dt = (DataTable)GridView1.DataSource;
        ViewState["Medications"] = dt;
        if (dt != null) dt.Clear();
        ResetGrid();
    }
    // End Medication add//
    //Save Prescription to DB//
    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        //Create datatable to get data from Gridview
        DataTable dtMed = new DataTable("ePrescriptionDetail");
        foreach (TableCell cell in GridView1.HeaderRow.Cells)
        {
            dtMed.Columns.Add(cell.Text);
        }
        //Loop through the GridView and copy rows.
        foreach (GridViewRow row in GridView1.Rows)
        {
            dtMed.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dtMed.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            dtMed.Rows[row.RowIndex][13] = ((Label)row.Cells[13].Controls[1]).Text;
        }
        //Get FavouriteID from DB
        string sqlSelectCommand = "SELECT top 1 SUBSTRING(FavouriteID,0,3) as FavID, SUBSTRING(FavouriteID,4,7) as RunID from dbo.FavoritMaster order by SUBSTRING(FavouriteID,4,7) DESC ";
        SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectCommand,
            ConfigurationManager.ConnectionStrings["EPrescription"].ConnectionString);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        string newPresID = "";
        if (dataTable.Rows.Count > 0)
        {
            int RunID = Convert.ToInt32(dataTable.Rows[0]["RunID"].ToString()) + 1;
            newPresID = "Fav" + RunID.ToString().PadLeft(7, '0');
        }
        else
        {
            int RunID = 1;
            newPresID = "Fav" + RunID.ToString().PadLeft(7, '0');
        }
        string favName = tbxFavName.Text;
        var loggedInDoctor = HttpContext.Current.User.Identity.Name;
        
        string sqlInsertMaster = "INSERT INTO dbo.FavoritMaster (FavouriteID, DiceaseName, CreateBy) VALUES ('"
                + newPresID + "',N'"
                + tbxFavName.Text.Trim() + "','"
                + loggedInDoctor + "')" ;
        using (SqlCommand command = new SqlCommand(sqlInsertMaster, ePresCon))
        {
            ePresCon.Open();
            command.ExecuteNonQuery();
            ePresCon.Close();
        }

        string sqlInsertDetail = "";
        for (int i = 0; i < dtMed.Rows.Count; i++)
        {
            int count = 0;
            var unitList = DataRepository.VrUnitTableProvider.GetPaged("Unit = N'" + dtMed.Rows[i]["Form"].ToString().Trim() + "'", "", 0, 1, out count);
            //var unitoutList = DataRepository.VrUnitTableProvider.GetPaged("Unit = 'No Value'", "", 0, 1, out count);
            VrUnitTable unitItem = new VrUnitTable();
            if (count == 1)
            {
                unitItem = unitList[0];
            }

            var freList = DataRepository.FrequencyProvider.GetPaged("abbre = N'" + dtMed.Rows[i]["Freq"].ToString().Trim() + "'", "", 0, 1, out count);
            Frequency frequencyItem = new Frequency();
            if (count == 1)
            {
                frequencyItem = freList[0];
            }
            var routeVNList = DataRepository.RouteProvider.GetPaged("Route = N'" + dtMed.Rows[i]["Route"].ToString().Trim() + "'", "", 0, 1, out count);
            Route routeVNItem = new Route();
            if (count == 1)
            {
                routeVNItem = routeVNList[0];
            }
            string hardCode = dtMed.Rows[i]["D_Unit"].ToString().Trim();
            switch (hardCode)
            {
                case "Day(s)": hardCode = "Ngày"; break;
                case "Week(s)": hardCode = "Tuần"; break;
                case "Hour(s)": hardCode = "Giờ"; break;
            }

            sqlInsertDetail = "INSERT INTO FavoritDetail( FavouriteID,DrugId,DrugName,Unit," +
                    "Dosage,Frequency,Duration,RouteType,RouteTypeVN,DurationUnit,UnitVN,DosageUnit," +
                    "DosageUnitVN,FrequencyVN,DurationUnitVN,TotalUnit)VALUES('"
                    + newPresID + "','"
                    + dtMed.Rows[i]["Drug ID"].ToString().Trim() + "',N'"
                    + dtMed.Rows[i]["Drug Name"].ToString().Trim() + "',N'"
                    + dtMed.Rows[i]["Form"].ToString().Trim() + "',N'"
                    + dtMed.Rows[i]["Dosage"].ToString().Trim() + "',N'"
                    + frequencyItem.Meaning + "',N'"
                    + dtMed.Rows[i]["Dur."].ToString().Trim() + "',N'"
                    + dtMed.Rows[i]["Route"].ToString().Trim() + "',N'"
                    + routeVNItem.RouteVn + "',N'"
                    + dtMed.Rows[i]["D_Unit"].ToString().Trim() + "',N'"
                    + unitItem.UnitVn + "',N'"
                    + unitItem.DosageUnit + "',N'"
                    + unitItem.DosageUnitVn + "',N'"
                    + frequencyItem.VnMeaning + "','"
                    + hardCode + "','"
                    + dtMed.Rows[i]["Total"].ToString().Trim() + "')";
            using (SqlCommand cmd = new SqlCommand(sqlInsertDetail, ePresCon))
            {
                ePresCon.Open();
                cmd.ExecuteNonQuery();
                ePresCon.Close();
            }

        }

        ClearForm();
        Response.Redirect("Favorite.aspx");
    }


    protected void resetForm_Click(object sender, EventArgs e)
    {

        ClearForm();
    }


    protected void rptFavorite_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView grvDetails = (GridView)e.Item.FindControl("grvDetails");
            //string id = rptFav
            FavoritMaster itemFavoritMaster = (FavoritMaster)e.Item.DataItem;
            grvDetails.DataSource = DataRepository.FavoritDetailProvider.GetByFavouriteId(itemFavoritMaster.FavouriteId);
            grvDetails.DataBind();
        }
    }

    protected void rptFavorite_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string favoriteId = (string)e.CommandArgument;
            var byFavouriteId = DataRepository.FavoritDetailProvider.GetByFavouriteId(favoriteId);
            DataTable dt = (DataTable)ViewState["Medications"];
            foreach (FavoritDetail detail in byFavouriteId)
            {
                DataRepository.FavoritMasterProvider.Del(favoriteId);
            }
            Response.Redirect("Favorite.aspx");
            BindGrid();
        }
    }
    
}