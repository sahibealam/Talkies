using Obout.Ajax.UI.HTMLEditor;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterCategory : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.MasterPageFile = SetMasterPage.ReturnPage();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Person_Id"] == null || Session["Login_Id"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        if (!IsPostBack)
        {
            get_tbl_Category();
        }
    }

    private void get_tbl_Category()
    {
        DataSet ds = new DataSet();
        ds = (new DataLayer()).get_tbl_Category();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdPost.DataSource = ds.Tables[0];
            grdPost.DataBind();
        }
        else
        {
            grdPost.DataSource = null;
            grdPost.DataBind();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Msg = "";
        if (txtCategory.Text.Trim() == string.Empty)
        {
            Msg = "Give Category";
            txtCategory.Focus();
            return;
        }
        tbl_Category obj_tbl_Category = new tbl_Category();
        if (hf_Category_Id.Value == "0" || hf_Category_Id.Value == "")
        {
            obj_tbl_Category.Category_Id = 0;
        }
        else
        {
            obj_tbl_Category.Category_Id = Convert.ToInt32(hf_Category_Id.Value);
        }
        obj_tbl_Category.Category_AddedBy = Convert.ToInt32(Session["Person_Id"].ToString());
        obj_tbl_Category.Category_Name = txtCategory.Text.Trim();
        obj_tbl_Category.Category_Status = 1;

        if (obj_tbl_Category == null)
        {
            MessageBox.Show(Msg);
            return;
        }
        if (new DataLayer().Insert_tbl_Category(obj_tbl_Category, obj_tbl_Category.Category_Id, ref Msg))
        {
            MessageBox.Show("Category Created Successfully ! ");
            reset();
            get_tbl_Category();
            return;
        }
        else
        {
            if (Msg == "A")
            {
                MessageBox.Show("This Category Already Exist. Give another! ");
            }
            else
            {
                MessageBox.Show("Error ! ");
            }
            return;
        }
    }

    private void reset()
    {
        txtCategory.Text = "";
        hf_Category_Id.Value = "0";
        get_tbl_Category();
        divCreateNew.Visible = false;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int Category_Id = Convert.ToInt32(((sender as ImageButton).Parent.Parent as GridViewRow).Cells[0].Text.Trim());
        hf_Category_Id.Value = Category_Id.ToString();
        DataSet ds = new DataSet();
        ds = (new DataLayer()).Edit_tbl_Category(Category_Id);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCategory.Text = ds.Tables[0].Rows[0]["Category_Name"].ToString();
        }
        divCreateNew.Visible = true;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int Category_Id = Convert.ToInt32(hf_Category_Id.Value);
        int Person_Id = Convert.ToInt32(Session["Person_Id"].ToString());
        if (new DataLayer().Delete_Category(Category_Id, Person_Id))
        {
            MessageBox.Show("Deleted Successfully!!");
            reset();
            return;
        }
        else
        {
            MessageBox.Show("Error In Deletion!!");
            reset();
            return;
        }
    }

    protected void grdPost_PreRender(object sender, EventArgs e)
    {
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
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        btnDelete.Visible = false;
        txtCategory.Text = "";
        hf_Category_Id.Value = "0";
        divCreateNew.Visible = true;
    }
}
