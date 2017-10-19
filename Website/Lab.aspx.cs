using ePrescription.Data;
using ePrescription.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Lab : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblTid.Text = Request.QueryString["Parameter"].ToString();
            rcbSearchLab.Filter = (RadComboBoxFilter)Convert.ToInt32("1");
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8]
                { new DataColumn("ID"), new DataColumn("TID"), new DataColumn("ReqID"), new DataColumn("Code")
                , new DataColumn("Description"), new DataColumn("ReqDoctor"),new DataColumn("ReqDate"),new DataColumn("ReqStatus")});
            ViewState["Request"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void btnGenPatient_Click(object sender, EventArgs e)
    {
        string tid = lblTid.Text.ToString();
        DataSet PatList = DataRepository.ClinicalStatsProvider.GetByTID(tid);
        DataTable dt = PatList.Tables[0];
        lblFirstName.Text = dt.Rows[0]["FirstName"].ToString();
        lblLastName.Text = dt.Rows[0]["LastName"].ToString();
        lblDOB.Text = dt.Rows[0]["dob"].ToString();
        lblCode.Text = dt.Rows[0]["PatientCode"].ToString();
        lblGender.Text = dt.Rows[0]["sex"].ToString();
        lblNat.Text = dt.Rows[0]["nationality"].ToString();
    }
    protected void rcbSearchLab_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        int count = 0;
        var proCode = DataRepository.VrMedProProvider.GetPaged("Description = '" + rcbSearchLab.Text.Trim() + "'", "", 0, 1, out count);
        VrMedPro code = new VrMedPro();
        if (count == 1)
        {
            code = proCode[0];
        }
        //DataSet ds = DataRepository.VrMedProProvider.GetByDescription(rcbSearchLab.Text);
        tbxProCode.Text = code.ProCode;
        decimal price = code.PubPrice;
        var Prices = string.Format("{0:#,##0}", price);
        tbxPrice.Text = Prices.ToString();
    }
    protected void BindGrid()
    {
        var dt = (DataTable)ViewState["Request"];

        foreach (DataRow dr in dt.Rows)
        {
            dr["ID"] = dt.Rows.IndexOf(dr) + 1;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnClearRowClick(object sender, EventArgs e)
    {
        Clear();
    }
    protected void Clear()
    {
        rcbSearchLab.Text = string.Empty;
        tbxPrice.Text = string.Empty;
        tbxProCode.Text = string.Empty;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (lblCode.Text == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please click [Generate Patient] first')", true);
        }
        if (rcbSearchLab.Text == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please choose Lab before Add')", true);
        }
        else
        {
            DataTable dt = (DataTable)ViewState["Request"];
            //Get LabID from DB
            string sqlSelectCommand = "SELECT top 1 SUBSTRING(ReqID,4,7) as RunID from dbo.DoctorRequest " +
                " order by SUBSTRING(ReqID,4,7) DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectCommand,
            ConfigurationManager.ConnectionStrings["EPrescription"].ConnectionString);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string newLabID = "";
            if (dataTable.Rows.Count == 0)
            {
                int RunID = 1;
                newLabID = "Lab" + RunID.ToString().PadLeft(7, '0');
            }
            if (dataTable.Rows.Count > 0)
            {
                int RunID = Convert.ToInt32(dataTable.Rows[0]["RunID"].ToString()) + 1;
                newLabID = "Lab" + RunID.ToString().PadLeft(7, '0');
            }
            var loggedInDoctor = HttpContext.Current.User.Identity.Name;
            var today = DateTime.Now;
            dt.Rows.Add(1, lblTid.Text.Trim(), newLabID,
            tbxProCode.Text.Trim(), rcbSearchLab.Text.Trim(), loggedInDoctor, today, "requested");
            ViewState["Request"] = dt;
            this.BindGrid();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["Request"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["Request"] = dt;
        BindGrid();
    }

    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            string TID = ((Label)row.FindControl("lblTID")).Text; 
            string newLabID = ((Label)row.FindControl("lblReqID")).Text; 
            var code = ((Label)row.FindControl("lblCode")).Text; 
            var description = ((Label)row.FindControl("lblDescription")).Text; 
            var reqDr = ((Label)row.FindControl("lblReqDoctor")).Text; 
            var reqStatus = ((Label)row.FindControl("lblStatus")).Text; 
            DateTime date = DateTime.Now;
            DateTime coldate = DateTime.Parse(tbxColDate.Text.Trim());
            TimeSpan coltime = TimeSpan.Parse(tbxColTime.Text.Trim());
            //TimeSpan coltime =  TimeSpan.ParseExact(tbxColTime.Text.Trim(), @"hh\:mm\:ss", CultureInfo.InvariantCulture);
            DataRepository.Provider.ExecuteScalar("_DoctorRequest_Insert",TID, newLabID, code, description, reqDr, date, coldate,coltime, reqStatus);
        }
        string TIDadd = lblTid.Text.ToString();
        DataRepository.ClinicalStatsProvider.UpdateLabDrReq(TIDadd);
        ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alert", "alert('Request for Lab is ordered');window.location ='DoctorDashBoard.aspx';", true);
    }
}