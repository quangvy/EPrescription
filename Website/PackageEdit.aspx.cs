
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ePrescription.Web.UI;
#endregion

public partial class PackageEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "PackageEdit.aspx?{0}", PackageDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "PackageEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Package.aspx");
		FormUtil.SetDefaultMode(FormView1, "PackageId");
	}
	protected void GridViewPackageDetail1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PackageDetailId={0}", GridViewPackageDetail1.SelectedDataKey.Values[0]);
		Response.Redirect("PackageDetailEdit.aspx?" + urlParams, true);		
	}	
}


