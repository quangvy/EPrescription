using ePrescription.Data;
using ePrescription.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LabCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptLabReceive.DataSource = DataRepository.VrLabReceiveProvider.GetAll();
            rptLabReceive.DataBind();
            rptLabProcess.DataSource = DataRepository.VrLabwipProvider.GetAll();
            rptLabProcess.DataBind();
            rptDone.DataSource = DataRepository.VrLabResultProvider.GetAll();
            rptDone.DataBind();
        }
    }
    protected void rptLabReceive_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView grvDetails = (GridView)e.Item.FindControl("grvDetails");
            VrLabReceive itemFavoritMaster = (VrLabReceive)e.Item.DataItem;
            DataSet ds = DataRepository.Provider.ExecuteDataSet("_Vr_LabReceive");
            grvDetails.DataSource = ds;
            grvDetails.DataBind();
        }
    }

    protected void rptLabReceive_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Confirm")
        {
            string TID = (string)e.CommandArgument;
            TextBox esample = e.Item.FindControl("tbxSample") as TextBox;
            string sample = esample.Text;
            DataRepository.DoctorRequestProvider.LabProcess (sample, TID);
            Response.Redirect("LabCenter.aspx");
        }
    }
    protected void rptLabProcess_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView grvDetails = (GridView)e.Item.FindControl("grvDetails");
            VrLabwip itemFavoritMaster = (VrLabwip)e.Item.DataItem;
            VList<VrLabwip> ds = DataRepository.VrLabwipProvider.GetAll();
            grvDetails.DataSource = ds;
            grvDetails.DataBind();
        }
    }

    protected void rptLabProcess_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Confirm")
        {
            string TID = (string)e.CommandArgument;
            DataRepository.DoctorRequestProvider.LabDone(TID);
            Response.Redirect("LabCenter.aspx");
        }
        if (e.CommandName == "Print")
        {
            string ReqID = (string)e.CommandArgument;
            string url = "LabPrint.aspx?ReqID=" + ReqID;
            string script = String.Format("window.open('{0}','YourWindowName','HEIGHT=600,WIDTH=820,resizable=no,scrollbars=yes,toolbar=yes,menubar=no,status=yes');", url);
            ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", script, true);
           
        }
    }
    protected void rptDone_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView grvDetails = (GridView)e.Item.FindControl("grvDetails");
            VrLabResult itemFavoritMaster = (VrLabResult)e.Item.DataItem;
            VList<VrLabResult> ds = DataRepository.VrLabResultProvider.GetAll();
            grvDetails.DataSource = ds;
            grvDetails.DataBind();
        }
    }

    protected void rptDone_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {

        //if (e.CommandName == "Confirm")
        //{
        //    string TID = (string)e.CommandArgument;
        //    DataRepository.DoctorRequestProvider.LabDone(TID);
        //    Response.Redirect("LabCenter.aspx");
        //}
        if (e.CommandName == "Print")
        {
            string ReqID = (string)e.CommandArgument;
            string url = "LabPrint.aspx?ReqID=" + ReqID;
            string script = String.Format("window.open('{0}','YourWindowName','HEIGHT=600,WIDTH=820,resizable=no,scrollbars=yes,toolbar=yes,menubar=no,status=yes');", url);
            ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", script, true);

        }
    }
}