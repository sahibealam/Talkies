using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
public partial class Createaccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        save_account obj_save_account = new save_account();
        try
        {
            obj_save_account.save_id = Convert.ToInt32(hf_save_id.Value);
        }
        catch
        {
            obj_save_account.save_id = 0;
        }

        if (txtPersonName.Text.Trim() == "")
        {
            MessageBox.Show("Please Provide Name!!");
            txtPersonName.Focus();

            return;

        }
        if (txtUserName.Text.Trim() == "")
        {
            MessageBox.Show("Please Provide User Name!!");
            txtUserName.Focus();

            return;

        }

        if (txtMobile.Text.Trim() == "")
        {
            MessageBox.Show("Please Provide Mobile Number!!");
            txtMobile.Focus();

            return;

        }
        if (txtEmail.Text.Trim() == "")
        {

            MessageBox.Show("Please Provide Email!!");
            txtEmail.Focus();

        }
        if (txtPassword.Text.Trim() == "")
        {

            MessageBox.Show("Please  Provide Password!!");
            txtPassword.Focus();

        }
        if (txtConfirmPassword.Text.Trim() == "")
        {
            MessageBox.Show("Please  Confirm Password!!");
            txtConfirmPassword.Focus();
        }
        if (ddlGender.SelectedValue == "0")
        {
            MessageBox.Show("Please select Gender!!");
            ddlGender.Focus();
        }
        if (txtAge.Text.Trim() == "")
        {

            MessageBox.Show("Please Fill Age!!");
            txtAge.Focus();
        }

        obj_save_account.save_name = txtPersonName.Text.Trim();
        obj_save_account.save_Username = txtUserName.Text.Trim();
        obj_save_account.save_mobile = txtMobile.Text.Trim();
        obj_save_account.save_email = txtEmail.Text.Trim();
        obj_save_account.save_password = txtPassword.Text.Trim(); 
        obj_save_account.save_confirmpassword = txtConfirmPassword.Text.Trim();
        obj_save_account.save_gender = ddlGender.Text.Trim();
        obj_save_account.save_age = txtAge.Text.Trim();
        DataSet sa = new DataLayer().Account_check(obj_save_account);
        if (hf_save_id == null)
        {
            if (sa != null && sa.Tables.Count > 0 && sa.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Email already Exist OR Mobile alredy Exist!!");

            }
            else if (new DataLayer().Account_savebtn(obj_save_account))
            {
                MessageBox.Show("Account Created Successfully!!");

            }
        }
        else
        {
            int save_id = 0;
            DataSet ds = new DataSet();
            ds = (new DataLayer()).Edit(Convert.ToInt32(save_id));
            if ((new DataLayer()).Update_save_account(obj_save_account))
            {
                MessageBox.Show("Account Updated Successfully!!");
                return;
            }
            else
            {
                MessageBox.Show("Error In Account Updation!!");
                return;
            }
        }
    }
        
       
    

       

   

      




   protected void grdPost_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdPost_PreRender1(object sender, EventArgs e)
    {
        if (txtPersonName.Text.Trim() == "")
        {


            DataSet ds = new DataSet();
            ds = new DataLayer().Insert_Grid2(txtPersonName.Text.Trim());
            if (AllClasses.CheckDataSet(ds))
            {
                grdPost.DataSource = ds;
                grdPost.DataBind();
            }
            else
            {
                grdPost.DataSource = null;
                grdPost.DataBind();
            }
            GridView gv = (GridView)sender;
            if (gv.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gv.UseAccessibleHeader = true;
            }
            if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
            {
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }



    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int save_id = 0;
       ImageButton btnDelete = sender as ImageButton;
        GridViewRow gr = btnDelete.Parent.Parent as GridViewRow;

        save_id = Convert.ToInt32(gr.Cells[0].Text.Trim());
        if (new DataLayer().Delete_save(save_id))
        {
            MessageBox.Show("Deleted Successfully!!");
            
            return;
        }
        else
        {
            MessageBox.Show("Error In Deletion!!");
            return;
        }
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lnkUpdate = sender as ImageButton;
        hf_save_id.Value = (lnkUpdate.Parent.Parent as GridViewRow).Cells[0].Text.Trim();
        DataSet ds = new DataSet();
        ds = (new DataLayer()).Edit(Convert.ToInt32(hf_save_id.Value));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) 
        {

            try
            {
               ddlGender.SelectedValue = ds.Tables[0].Rows[0]["save_gender"].ToString();
            }
            catch
            {
                ddlGender.SelectedValue = "0";
            }
            txtPersonName.Text = ds.Tables[0].Rows[0]["save_name"].ToString();
          txtUserName.Text = ds.Tables[0].Rows[0]["save_Username"].ToString();
          txtMobile.Text = ds.Tables[0].Rows[0]["save_mobile"].ToString();
          txtEmail.Text = ds.Tables[0].Rows[0]["save_email"].ToString();
          //txtPassword.Text = ds.Tables[0].Rows[0]["save_password"].ToString();
          //txtConfirmPassword.Text = ds.Tables[0].Rows[0]["save_confirmpassword"].ToString();
         // ddlGender.Text = ds.Tables[0].Rows[0]["save_gender"].ToString();
          txtAge.Text = ds.Tables[0].Rows[0]["save_age"].ToString();
        }
        else
        {
            MessageBox.Show("Please update your details!!");
            return;
        }

        // Response.Redirect("Createaccount.aspx");
    }

  
}