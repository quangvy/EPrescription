
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ePrescription.Data;
using ePrescription.Entities;
using ePrescription.Web.UI;
#endregion

public partial class ProfilePage : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
	    if (!IsPostBack)
	    {
	        var user = DataRepository.UsersProvider.GetByUserName(HttpContext.Current.User.Identity.Name);
	        if (String.IsNullOrEmpty(user.Avatar))
	        {
	            imgAvatar.ImageUrl = "~/images/avatar/default.png";
	        }
	        else
	        {
	            imgAvatar.ImageUrl = "~/images/avatar/" + user.Avatar;
	        }
            if (String.IsNullOrEmpty(user.Signature))
            {
                imgSignature.ImageUrl = "~/images/signature/default.jpg";
            }
            else
            {
                imgSignature.ImageUrl = "~/images/signature/" + user.Signature;
            }
	        txtDisplayName.Text = user.DisplayName;
	        txtEmail.Text = user.Email;
	        txtFullName.Text = user.FullName;
	        txtMobilePhone.Text = user.MobilePhone;
	    }
	}

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
	    var user = DataRepository.UsersProvider.GetByUserName(HttpContext.Current.User.Identity.Name);
        user.DisplayName = txtDisplayName.Text;
        user.Email = txtEmail.Text;
        user.FullName = txtFullName.Text;
        user.MobilePhone = txtMobilePhone.Text;
        if (!string.IsNullOrEmpty(txtPassword.Text))
            user.Password = txtPassword.Text;
        if (fulAvatar.HasFile)
        {
            string fileName = Path.GetFileName(fulAvatar.FileName);
            FileInfo fi = new FileInfo(fileName);
            string ext = fi.Extension;
            fulAvatar.SaveAs(Server.MapPath("~/images/avatar/") + user.UserName + "avatar"+ ext);
            user.Avatar = user.UserName + "avatar" + ext;
        }
        if (fulSignature.HasFile)
        {
            string fileName = Path.GetFileName(fulSignature.FileName);
            FileInfo fi = new FileInfo(fileName);
            string ext = fi.Extension; fulAvatar.SaveAs(Server.MapPath("~/images/signature/") + user.UserName + "signature" + ext);
            user.Signature = user.UserName + "signature" + ext;
        }
        DataRepository.UsersProvider.Update(user);
        Response.Redirect("Profile.aspx");
    }
}


