using ePrescription.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DoctorDashBoard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void gridDoctor_Rowcommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "LAB")
        {
            GridViewRow row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
            var transID = e.CommandArgument.ToString();
            lbltest.Text = transID;
            Response.Redirect("Lab.aspx?Parameter="+transID);
        }
    }
    //HttpResponse.Redirect("SecondForm.aspx?Parameter=" + tbxTID.Text );

    
}