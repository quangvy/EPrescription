using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Favorite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rcbDiag.Filter = (RadComboBoxFilter)Convert.ToInt32("1");
    }
}