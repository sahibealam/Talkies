using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        tbl_Review obj_User_review = new tbl_Review();
       
        if (CheckBox2.Text.Trim() == "")
        {
            CheckBox2.Focus();
            return;
        }
        if (ddlUserName.SelectedValue == "0")
        {
            ddlUserName.Focus();
            return;
        }
        if (txtComment.Text.Trim() == "")
        {
            txtComment.Focus();
            return;
        }
        obj_User_review.tbl_Review_Rating = Rating1.CurrentRating;
       // obj_User_review. =Convert.ToInt32(ddlUserName.SelectedValue);
        obj_User_review.tbl_Review_faviourate = CheckBox2.Text.Trim();
        obj_User_review.tbl_Review_Comment = txtComment.Text.Trim();
        if (new DataLayer().Insert_Review(obj_User_review ))
        {
            MessageBox.Show("Review Submitted!!");
        }
        else
        {
            MessageBox.Show("Error!!");
        }

    }
}