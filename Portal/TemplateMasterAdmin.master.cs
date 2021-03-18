using System;
using System.Web.UI.WebControls;

public partial class TemplateMasterAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Person_Id"] == null || Session["Login_Id"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        if (!IsPostBack)
        {
            string lastLogin = "";
            //string lastLogin = new DataLayer().get_tbl_LoginHistory_Last_Login(Session["Person_Id"].ToString());
            lblUserHeader.Text = Session["Login_UserName"].ToString() + "     " + lastLogin;
            lblUser.Text = Session["Login_UserName"].ToString();
        }
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        //new DataLayer().Update_tbl_LoginHistory(Session["LoginHistory_Id"].ToString());
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Index.aspx");
    }

    protected void lnkChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
}
