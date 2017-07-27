
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

public partial class EPrescriptionEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "EPrescriptionEdit.aspx?{0}", EPrescriptionDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "EPrescriptionEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "EPrescription.aspx");
		FormUtil.SetDefaultMode(FormView1, "PrescriptionId");
	}
	protected void GridViewEPrescriptionDetail1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PrescriptionDetailId={0}", GridViewEPrescriptionDetail1.SelectedDataKey.Values[0]);
		Response.Redirect("EPrescriptionDetailEdit.aspx?" + urlParams, true);		
	}	
}


