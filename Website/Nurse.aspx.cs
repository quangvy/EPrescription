using ePrescription.Data;
using ePrescription.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Nurse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5]
            {new DataColumn("TID"), new DataColumn("Code"), new DataColumn("Description"), new DataColumn("ReqDoctor"), new DataColumn("Billable")});
        ViewState["Update"] = dt;
    }
    protected void btnSaveVS_OnClick(object sender, EventArgs e)
    {
        if (tbxTemp.Text == string.Empty || tbxPulse.Text == string.Empty || tbxPress.Text == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please input Vital Sign first')", true);
        }

        else
        {
            string TID = lblTranID.Text.ToString().Trim();
            int count1 = 0;
            var TIDList = DataRepository.VitalSignProvider.GetPaged("TID = '" + TID + "'", "", 0, 1, out count1);
            string pcode = lblpatcode.Text.ToString();
            string temp = tbxTemp.Text.ToString();
            string pulse = tbxPulse.Text.ToString();
            string res = tbxRes.Text.ToString();
            string bpress = tbxPress.Text.ToString();
            string satO2 = tbxSat.Text.ToString();
            string gcs = tbxGCS.Text.ToString();
            string height = tbxHeight.Text.ToString();
            string weight = tbxWeight.Text.ToString();
            DateTime date = DateTime.Now;
            var loggedInDoctor = HttpContext.Current.User.Identity.Name;
            var updateUser = HttpContext.Current.User.Identity.Name;
            if (count1 == 0)
            {
                //string dbTID = TIDList[0].Tid;
                DataRepository.VitalSignProvider.Insert(TID, pcode, temp, pulse, res, bpress, satO2, gcs, height, weight, date, loggedInDoctor);
            }
            else
            {
                DataRepository.VitalSignProvider.Update(TID, temp, pulse, res, bpress, satO2, gcs, height, weight, date, updateUser);
            }
            DataRepository.ClinicalStatsProvider.UpdVitalSign(TID);
            foreach (GridViewRow row in gridUpdate.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    string proCode = ((Label)row.Cells[1].Controls[1]).Text;
                    CheckBox bill = (row.Cells[0].FindControl("cb_Billable") as CheckBox) ;
                    string b = bill.Checked.ToString();
                    Boolean billable;
                    Boolean.TryParse(b, out billable);
                    DataRepository.DoctorRequestProvider.UpdNurse(proCode, billable, TID);
                }
            }
        }
        Response.Redirect("nurse.aspx");
    }
    protected void gridWaitingPat_process(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Process")
        {
            //fill Patient info -- start//
            GridViewRow grvRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
            string transID = e.CommandArgument.ToString();
            string pCode = ((Label)grvRow.FindControl("lblPatientCode")).Text;
            string fName = ((Label)grvRow.FindControl("lblFirstName")).Text;
            string lName = ((Label)grvRow.FindControl("lblLastName")).Text;
            string sex = ((Label)grvRow.FindControl("lblSex")).Text;
            DateTime dob = DateTime.Parse(((Label)grvRow.FindControl("lblDOB")).Text);
            string nat = ((Label)grvRow.FindControl("lblNationality")).Text;
            lblTranID.Text = transID.ToString();
            lblpatcode.Text = pCode.ToString();
            lblFname.Text = fName.ToString();
            lblLname.Text = lName.ToString();
            lblDOB.Text = dob.ToString("dd-MMM-yyyy");
            lblNat.Text = nat.ToString();
            lblSex.Text = sex.ToString();
            //fill Patient info -- end//
            DataSet dt = DataRepository.DoctorRequestProvider.GetByTID(transID);
            gridUpdate.DataSource = dt;
            gridUpdate.DataBind();
        }

    }
}