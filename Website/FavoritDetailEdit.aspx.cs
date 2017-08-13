
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

public partial class FavoritDetailEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "FavoritDetailEdit.aspx?{0}", FavoritDetailDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "FavoritDetailEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "FavoritDetail.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


