
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

public partial class FavoritMasterEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "FavoritMasterEdit.aspx?{0}", FavoritMasterDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "FavoritMasterEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "FavoritMaster.aspx");
		FormUtil.SetDefaultMode(FormView1, "FavouriteId");
	}
	protected void GridViewFavoritDetail1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewFavoritDetail1.SelectedDataKey.Values[0]);
		Response.Redirect("FavoritDetailEdit.aspx?" + urlParams, true);		
	}	
}


