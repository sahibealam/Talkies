using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;
using System.Linq;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_Id"] != null)//Administrator
        {
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            //Response.Redirect("Index.aspx");
        }
        txtUserName.Focus();
        if (!IsPostBack)
        {

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim().Replace("'", "") == "")
        {
            MessageBox.Show("Please Provide Valid User Name..!!");
            txtUserName.Focus();
            return;
        }
        if (txtPassowrd.Text.Trim().Replace("'", "") == "")
        {
            MessageBox.Show("Please Provide Password!!");
            txtPassowrd.Focus();
            return;
        }
        DataSet ds = new DataSet();
        ds = new DataLayer().getLoginDetails(txtUserName.Text.Trim().Replace("'", ""), txtPassowrd.Text.Trim().Replace("'",""));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Session["Login_Id"] = ds.Tables[0].Rows[0]["Login_Id"].ToString().Trim();
            Session["Person_Id"] = ds.Tables[0].Rows[0]["Login_PersonId"].ToString();
            Session["Login_UserName"] = ds.Tables[0].Rows[0]["Login_UserName"].ToString();
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            MessageBox.Show("Invalid Login Credentials!!");
            return;
        }
    }
}
