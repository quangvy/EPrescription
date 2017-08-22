

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
#endregion

public partial class EPrescriptionPage : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "EPrescription.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
		FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PrescriptionId={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("EPrescriptionEdit.aspx?" + urlParams, true);
	}
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Reprint")
        {
            
            GridViewRow grvRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            var presID = e.CommandArgument.ToString();
            string url = "Print.aspx?PrescriptionId=" + presID;
            string script = String.Format("window.open('{0}','YourWindowName','HEIGHT=600,WIDTH=820,fullscreen=yes,resizable=no,scrollbars=yes,toolbar=yes,menubar=no,status=yes');", url);
            ClientScript.RegisterStartupScript(this.GetType(), "OPEN_WINDOW", script, true);
        }
    }

}


