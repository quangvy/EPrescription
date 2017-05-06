using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool ValidateUser(string userName, string passWord)
    {
        // Check for invalid userName.
        // userName must not be null and must be between 1 and 15 characters.

        return new UserInfo().Login(userName, passWord);

    }

    protected void btnSignIn_OnClick(object sender, EventArgs e)
    {
        if (ValidateUser(txtName.Value, txtPassword.Value))
            FormsAuthentication.RedirectFromLoginPage(txtName.Value,
            true);
        else
            Response.Redirect("Default.aspx", true);

    }
}