
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

public partial class UserRolesEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UserRolesEdit.aspx?{0}", UserRolesDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UserRolesEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "UserRoles.aspx");
		FormUtil.SetDefaultMode(FormView1, "RoleId");
	}
}


