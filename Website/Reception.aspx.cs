#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ePrescription.Web.UI;
using ePrescription.Data;
#endregion

public partial class Reception : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FormUtil.RedirectAfterUpdate(gridReception, "Reception.aspx?page={0}");
        FormUtil.SetPageIndex(gridReception, "page");
        FormUtil.RedirectAfterUpdate(gridPatientActivation, "Reception.aspx?page={0}");
        FormUtil.SetPageIndex(gridPatientActivation, "page");
        }
    }

    protected void gridPatientActivation_Rowcommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            GridViewRow grvRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
            string transID = e.CommandArgument.ToString();
            string pCode = ((Label)grvRow.FindControl("lblPatientCode")).Text;
            string fName = ((Label)grvRow.FindControl("lblFirstName")).Text;
            string lName = ((Label)grvRow.FindControl("lblLastName")).Text;
            string sex = ((Label)grvRow.FindControl("lblSex")).Text;
            DateTime dob = DateTime.Parse(((Label)grvRow.FindControl("lblDOB")).Text);
            string nat = ((Label)grvRow.FindControl("lblNationality")).Text;
            bool pStart = true;
            DataRepository.ClinicalStatsProvider.AddRecept(pCode, transID, fName, lName, dob, sex, nat,pStart);
            gridPatientActivation.EditIndex = -1;
            Response.Redirect("Reception.aspx");
        }
        if (e.CommandName == "Void")
        {
            GridViewRow grvRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
            string transID = e.CommandArgument.ToString();
            string reason = ((DropDownList)grvRow.FindControl("ddlVoidReason")).Text;
            DataRepository.VrReceptionProvider.UpdatePatCMS(transID,reason);
            gridPatientActivation.EditIndex = -1;
            Response.Redirect("Reception.aspx");
        }
    }
    protected void gridReception_Rowcommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Revert")
        {
            GridViewRow row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
            var transID = e.CommandArgument.ToString();
            DataRepository.ClinicalStatsProvider.UpdateRecept(transID);
            Response.Redirect("Reception.aspx");
        }
    }
}