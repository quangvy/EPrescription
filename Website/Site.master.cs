using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePrescription.Data;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
	        var user = DataRepository.UsersProvider.GetByUserName(HttpContext.Current.User.Identity.Name);
            if (string.IsNullOrEmpty(user.Avatar))
                imgAvatar.ImageUrl = "~/images/avatar/default.png";
            else
            {
                imgAvatar.ImageUrl = "~/images/avatar/" + user.Avatar;
            }
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
    }
}
