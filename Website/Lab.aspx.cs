using ePrescription.Data;
using ePrescription.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Lab : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txbTid.Text = Request.QueryString["Parameter"].ToString();
    }
    
    protected void lblTid_DataBinding(object sender, EventArgs e)
    {
        string tid = txbTid.Text.ToString();
        var PatList = DataRepository.ClinicalStatsProvider.GetByTID(tid);
        Label1.Text = PatList.ToString();
            }
}