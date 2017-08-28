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

public partial class Prescription : System.Web.UI.Page
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
            rcbDiag.Filter = (RadComboBoxFilter)Convert.ToInt32("1");
            rcbFreq.Filter = (RadComboBoxFilter)Convert.ToInt32("1");
            rcbRoute.Filter = (RadComboBoxFilter)Convert.ToInt32("1");
        }
    }

    protected void RadComboBoxProduct_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        string sqlSelectCommand = "SELECT firstname, lastname,firstname+' '+lastname AS fullname, DateOfBirth, Sex,TransactionId," +
            "MemberType FROM dbo.VR_PatActivation WHERE (CONVERT(DATE,CreateDate))=(CONVERT(DATE,getdate()))" +
            "and Firstname like '%' + @text +'%' or lastname like '%' + @text +'%'";
        SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectCommand,
        ConfigurationManager.ConnectionStrings["CMS"].ConnectionString);
        adapter.SelectCommand.Parameters.AddWithValue("@text", e.Text);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        foreach (DataRow dataRow in dataTable.Rows)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Text = (string)dataRow["Fullname"];
            item.Value = (string)dataRow["Fullname"];

            string fullname = (string)dataRow["Fullname"];
            DateTime DateOfBirth = (DateTime)dataRow["DateOfBirth"];
            string Sex = (string)dataRow["Sex"];
            string Mem = (string)dataRow["MemberType"];

            item.Attributes.Add("Fullname", fullname.ToString());
            item.Attributes.Add("DateOfBirth", DateOfBirth.ToString("dd-MMM-yyyy"));
            item.Attributes.Add("Sex", Sex.ToString());
            item.Attributes.Add("MemberType", Mem.ToString());
            RadComboBox1.Items.Add(item);
            item.DataBind();
        }
    }
    protected void RadComboBoxProduct_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string sqlSelectCommand = "SELECT firstname, lastname,firstname+' '+lastname AS fullname, CONVERT(VARCHAR(9), DateOfBirth, 6) as DateOfBirth, Sex,TransactionId," +
            "MemberType,patientcode,address,age FROM dbo.VR_PatActivation WHERE (CONVERT(DATE,CreateDate))=(CONVERT(DATE,getdate()))" +
            "and Firstname +' '+lastname = + @text ";
        SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectCommand,
            ConfigurationManager.ConnectionStrings["CMS"].ConnectionString);
        adapter.SelectCommand.Parameters.AddWithValue("@text", RadComboBox1.Text.ToString());
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);

        if (dataTable.Rows.Count > 0)
        {
            lblFirstName.Text = dataTable.Rows[0]["FirstName"].ToString();
            lblLastName.Text = dataTable.Rows[0]["LastName"].ToString();
            lblDOB.Text = dataTable.Rows[0]["DateOfBirth"].ToString();
            lblAge.Text = dataTable.Rows[0]["Age"].ToString();
            lblCode.Text = dataTable.Rows[0]["patientcode"].ToString();
            lblGender.Text = dataTable.Rows[0]["Sex"].ToString();
            lblAddress.Text = dataTable.Rows[0]["address"].ToString();
            lblTID.Text = dataTable.Rows[0]["TransactionId"].ToString();
        }
        else
        {
            lblFirstName.Text = null;
            lblLastName.Text = null;
            lblDOB.Text = null;
            lblAge.Text = null;
            lblCode.Text = null;
            lblGender.Text = null;
            lblAddress.Text = null;
            lblTID.Text = null;
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
    //Paging server side for RadCombo Diagnosis - 70K rows data//
    private static string GetStatusMessage(int offset, int total)
    {
        if (total <= 0)
            return "No matches";

        return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
    }
    private static DataTable GetData(string text)
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from diaglist WHERE diag_name LIKE @text + '%'",
            ConfigurationManager.ConnectionStrings["EPrescription"].ConnectionString);
        adapter.SelectCommand.Parameters.AddWithValue("@text", text.Replace("%", "[%]"));

        DataTable data = new DataTable();
        adapter.Fill(data);

        return data;
    }
    protected void rcbDiag_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable data = GetData(e.Text);

        int itemOffset = e.NumberOfItems;
        int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Rows.Count);
        e.EndOfItems = endOffset == data.Rows.Count;

        for (int i = itemOffset; i < endOffset; i++)
        {
            rcbDiag.Items.Add(new RadComboBoxItem(data.Rows[i]["diag_name"].ToString(), data.Rows[i]["diag_name"].ToString()));
        }

        e.Message = GetStatusMessage(endOffset, data.Rows.Count);
    }
    protected void ResetGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[13]
            { new DataColumn("ID"), new DataColumn("DrugName"), new DataColumn("DrugID"), new DataColumn("Unit")
                , new DataColumn("RouteType"), new DataColumn("Dosage"),new DataColumn("DosageUnit"),new DataColumn("Frequency")
                , new DataColumn("Duration"), new DataColumn("DurationUnit"),new DataColumn("TotalUnit"),new DataColumn("Refill"),new DataColumn("Remark")});
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
        if (RadComboBox1.Text == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please choose patient first')", true);
            //Response.Write("<script>alert('Please choose patient first')</script>");
        }
        else
        { 
        DataTable dt = (DataTable)ViewState["Medications"];
        dt.Rows.Add(1, rcbSearchMed.Text.Trim(), lblDrugID.Text.Trim(),
        lblUnit.Text.Trim(), rcbRoute.Text.Trim(), tbxDosage.Text.Trim(), lblDosageUnit.Text.Trim(), rcbFreq.SelectedValue,
        tbxDuration.Text.Trim(), ddlDUnit.Text.Trim(), tbxTotalUnit.Text.ToString(), chkRefill.Checked, 
            tbxRemark.Text.Trim());
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
        bool refill = (row.FindControl("chkEditRefill") as CheckBox).Checked;
        string route = (row.Cells[5].Controls[0] as TextBox).Text;
        string dosage = (row.Cells[7].Controls[0] as TextBox).Text;
        string freq = (row.Cells[9].Controls[0] as TextBox).Text;
        string dur = (row.Cells[10].Controls[0] as TextBox).Text;
        string Dunit = (row.Cells[11].Controls[0] as TextBox).Text;
        string totalunit = (row.Cells[12].Controls[0] as TextBox).Text;
        string remark = (row.Cells[14].Controls[0] as TextBox).Text;

        
        DataTable dt = ViewState["Medications"] as DataTable;
        dt.Rows[row.RowIndex]["RouteType"] = route;
        dt.Rows[row.RowIndex]["Dosage"] = dosage;
        dt.Rows[row.RowIndex]["Frequency"] = freq;
        dt.Rows[row.RowIndex]["Duration"] = dur;
        dt.Rows[row.RowIndex]["DurationUnit"] = Dunit;
        dt.Rows[row.RowIndex]["TotalUnit"] = totalunit;
        dt.Rows[row.RowIndex]["Refill"] = refill;
        dt.Rows[row.RowIndex]["Remark"] = remark;
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
        chkRefill.Checked = false;
        tbxRemark.Text = string.Empty;
        tbxDuration.Text = string.Empty;
        tbxTotalUnit.Text = string.Empty;
        
    }
    protected void ClearForm()
    {
        RadComboBox1.Text = null;
        tbxWeight.Text = null;
        lblTID.Text = null;
        lblFirstName.Text = null;
        lblLastName.Text = null;
        lblDOB.Text = null;
        lblAge.Text = null;
        lblCode.Text = null;
        lblGender.Text = null;
        lblAddress.Text = null;
        rcbDiag.Text = null;
        tbxRemark.Text = null;
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
        //Get PrescriptionID from DB
        string sqlSelectCommand = "SELECT top 1 SUBSTRING(PrescriptionID,0,8) as DateID, SUBSTRING(PrescriptionID,11,4) as RunID from dbo.ePrescription WHERE " +
            "SUBSTRING(PrescriptionID,0,8)=SUBSTRING(REPLACE((CONVERT(NVARCHAR(9),getdate(),6)),' ','' ),0,8) order by SUBSTRING(PrescriptionID,11,4) DESC ";
        SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectCommand,
            ConfigurationManager.ConnectionStrings["EPrescription"].ConnectionString);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        string newPresID = "";
        if (dataTable.Rows.Count > 0)
        {
            string CharID = dataTable.Rows[0]["DateID"].ToString();
            int RunID = Convert.ToInt32(dataTable.Rows[0]["RunID"].ToString()) + 1;
            newPresID = CharID + "HCM" + RunID.ToString().PadLeft(4, '0');
        }
        else
        {
            string CharID = DateTime.Now.ToString("ddMMMyy");
            int RunID = 1;
            newPresID = CharID + "HCM" + RunID.ToString().PadLeft(4, '0');
        }
        string firstname = lblFirstName.Text;
        string lastname = lblLastName.Text;
        DateTime dob = DateTime.Parse(lblDOB.Text);
        string age = lblAge.Text;
        string patientcode = lblCode.Text;
        string weight = tbxWeight.Text;
        string gender = lblGender.Text;
        string address = lblAddress.Text;
        string tid = lblTID.Text;
        string diag = rcbDiag.Text;
        string remarkgen = txbRemarkPres.Text;
        DateTime deliverydate = DateTime.Now;
        DateTime createdate = DateTime.Now;
        var loggedInDoctor = HttpContext.Current.User.Identity.Name;

        int count1 = 0;
        var diagList = DataRepository.DiaglistProvider.GetPaged("DIAG_NAME = '" + diag + "'", "", 0, 1, out count1);
        Diaglist diagVN = new Diaglist();
        if (count1 == 1)
        {
            diagVN = diagList[0];
        }

        string sqlInsertMaster = "INSERT INTO dbo.ePrescription (PrescriptionID,TransactionID,PatientCode,FirstName,"+
                "LastName,DeliveryDate,CreateDate,Address,DateOfBirth,Age,Weight,Diagnosis, PrescribingDoctor,Sex,"+
                "DiagnosisVN,DiagCode,Remark,IsComplete) VALUES ('"
                + newPresID + "','" 
                + tid + "','" 
                + patientcode  + "','" 
                + firstname + "','" 
                + lastname + "','" 
                + deliverydate + "','" 
                + createdate + "','" 
                + address + "','" 
                + dob + "','" 
                + age + "',N'" 
                + weight + "','"     
                + diag + "','" 
                + loggedInDoctor + "','" 
                + gender + "',N'"
                + diagVN.DiagNameVn + "',N'"
                + diagVN.DiagCode + "',N'"
                + remarkgen + "',1)";
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

            sqlInsertDetail = "INSERT INTO ePrescriptionDetail( PrescriptionID,Sq,DrugId,DrugName,Unit," +
                    "Remark,Dosage,Frequency,Duration,RouteType,RouteTypeVN,DurationUnit,UnitVN,DosageUnit,"+
                    "DosageUnitVN,FrequencyVN,DurationUnitVN,Refill,TotalUnit)VALUES('"
                    + newPresID + "','"
                    + dtMed.Rows[i]["Sq"].ToString().Trim() + "','"
                    + dtMed.Rows[i]["Drug ID"].ToString().Trim() + "','"
                    + dtMed.Rows[i]["Drug Name"].ToString().Trim() + "',N'"
                    + dtMed.Rows[i]["Form"].ToString().Trim() + "',N'"
                    + dtMed.Rows[i]["Remark"].ToString().Trim() + "',N'"
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
                    + dtMed.Rows[i]["Refill"].ToString().Trim() + "',N'"
                    + dtMed.Rows[i]["Total"].ToString().Trim() + "')";
            using (SqlCommand cmd = new SqlCommand(sqlInsertDetail, ePresCon))
            {
                ePresCon.Open();
                cmd.ExecuteNonQuery();
                ePresCon.Close();
            }
            
        }
        
        string url = "Print.aspx?PrescriptionId=" + newPresID;
        string script = String.Format("window.open('{0}','YourWindowName','HEIGHT=600,WIDTH=820,resizable=no,scrollbars=yes,toolbar=yes,menubar=no,status=yes');", url);
        ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", script, true);
        ClearForm();
        //Response.Redirect("Prescription.aspx");
    }
         

    protected void resetForm_Click(object sender, EventArgs e)
    {
        
        ClearForm();
    }
}