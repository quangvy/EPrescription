using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePrescription.Data;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool ValidateUser(string userName, string passWord)
    {
        // Check for invalid userName.
        // userName must not be null and must be between 1 and 15 characters.

        return Login(userName, passWord);

    }

    private bool Login(string userName,string password)
    {
        int count = 0;
        DataRepository.UsersProvider.GetPaged("UserName = '"+ userName +"' AND Password = '"+ password + "'", "", 0, 1, out count);
        return count == 1;
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