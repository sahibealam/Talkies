using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TemplateMasterAdmin : System.Web.UI.MasterPage
{
    public string EnableCreditNote = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("Dashboard.aspx");
    }
}
