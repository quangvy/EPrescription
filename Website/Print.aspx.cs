using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!this.IsPostBack) { 
        ReportViewer1.LocalReport.EnableExternalImages = true;
        //string imagePath = new Uri(Server.MapPath("~/images/Usersignature.jpg")).AbsoluteUri;
        //ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
        //ReportViewer1.LocalReport.SetParameters(parameter);
        //ReportViewer1.LocalReport.Refresh();

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        
    }
}