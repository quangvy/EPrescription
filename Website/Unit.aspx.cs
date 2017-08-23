

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

public partial class UnitPage : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "Route.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
        FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Unit={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("RouteEdit.aspx?" + urlParams, true);
	}

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="UpdateUnit")
        {
            //Response.Write("<script>alert('"+e.CommandArgument+"');</script>");
            GridViewRow grvRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            var unit = e.CommandArgument.ToString();
            var unitVN =  ((TextBox)grvRow.FindControl("txtUnitVN")).Text;
            var DosageUnit = ((TextBox)grvRow.FindControl("txtDosageUnit")).Text;
            var DosageUnitVN = ((TextBox)grvRow.FindControl("txtDosageUnitVN")).Text;
            DataRepository.VrUnitTableProvider.Update(unit, unitVN, DosageUnit, DosageUnitVN);
            GridView1.EditIndex = -1;
            //Response.Write("<script>alert('"+ unitVN + "');</script>");
        }
    }
}


