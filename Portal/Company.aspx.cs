using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;


public partial class Company : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fill_Company();

    }
    private void fill_Company()
    {
        DataSet ds = new DataSet();
        ds = new DataLayer().get_Company();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
          
            ddlCompany.DataTextField = "tbl_Company_Name";
            ddlCompany.DataValueField = "tbl_Company_Name";
            ddlCompany.DataSource = ds.Tables[0];
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        tbl_Company obj_C = new tbl_Company();
        obj_C.tbl_Company_Name= lblCompany.Text.Trim(); 
        obj_C.Ato_sell = lblAto_sell.Text.Trim(); 
        obj_C.Ato_By = lblAto_By.Text.Trim(); 
        obj_C.Totl_sell = lblTotl_sell.Text.Trim(); 
        obj_C.Totl_Qty = lblTotl_Qty.Text.Trim(); 
        obj_C.tbl_Final_Qty = txtFinalQuantity.Text.Trim(); 
        obj_C.tbl_Self_result = txtSelfResult.Text.Trim(); 
        obj_C.tbl_NSE_result = txtNSE.Text.Trim(); 
        obj_C.Date = txtDate.Text.Trim(); 

        if(new DataLayer().seve_Ammount(obj_C))
        {
            MessageBox.Show("Save SuccessFully   ");
        }
        else
        {
            MessageBox.Show("Error in Saving");
        }

    }
}