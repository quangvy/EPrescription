using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VitalSign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        lblTest.Text= Request.QueryString["Parameter"].ToString();
    }
}