using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class CreateAlbum : System.Web.UI.Page
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
            AllClasses.Create_Directory_Session1();
            AllClasses.Create_Directory_Session2();
            fill_Category();
            fill_Studio();
            get_Genere();
            get_Starring("S", lbStarring);
            get_Starring("D", lbDirector);
            get_Starring("A", lbSupportingActor);


            if (Request.QueryString.Count > 0)
            {
                load_Album_Details();
            }
        }
    }
    private void load_Album_Details()
    {
        int Album_Id = Convert.ToInt32(Request.QueryString[0].ToString());

        DataSet ds = new DataSet();
        ds = (new DataLayer()).Edit_Album(Album_Id);
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hf_AlbumId.Value = ds.Tables[0].Rows[0]["Album_Id"].ToString();

                txtAlbumName.Text = ds.Tables[0].Rows[0]["Album_Name"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["Album_Description"].ToString();
                Rating1.CurrentRating = Convert.ToInt32(ds.Tables[0].Rows[0]["Album_Rating"].ToString());
                ddlMountingRating.SelectedValue = ds.Tables[0].Rows[0]["Album_Mounting_Rating"].ToString();
                ddlStudio.SelectedValue = ds.Tables[0].Rows[0]["Album_Studio_Id"].ToString();
                ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["Album_Category"].ToString();
            }

            if (ds.Tables.Count > 1 && ds.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    for (int j = 0; j < lbStarring.Items.Count; j++)
                    {
                        if (ds.Tables[2].Rows[i]["AlbumStaff_Starring_id"].ToString() == lbStarring.Items[j].Value)
                        {
                            lbStarring.Items[j].Selected = true;
                            break;
                        }
                    }
                }
            }
            if (ds.Tables.Count > 2 && ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    for (int j = 0; j < lbSupportingActor.Items.Count; j++)
                    {
                        if (ds.Tables[1].Rows[i]["AlbumStaff_Starring_id"].ToString() == lbSupportingActor.Items[j].Value)
                        {
                            lbSupportingActor.Items[j].Selected = true;
                            break;
                        }
                    }
                }
            }
            if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    for (int j = 0; j < lbDirector.Items.Count; j++)
                    {
                        if (ds.Tables[3].Rows[i]["AlbumStaff_Starring_id"].ToString() == lbDirector.Items[j].Value)
                        {
                            lbDirector.Items[j].Selected = true;
                            break;
                        }
                    }
                }
            }
            if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                {
                    for (int j = 0; j < lbGenere.Items.Count; j++)
                    {
                        if (ds.Tables[4].Rows[i]["AlbumGenere_Genere_id"].ToString() == lbGenere.Items[j].Value)
                        {
                            lbGenere.Items[j].Selected = true;
                            break;
                        }
                    }
                }
            }

        }
    }
    private void get_Genere()
    {
        DataSet ds = new DataSet();
        ds = new DataLayer().get_Genere();
        if (AllClasses.CheckDataSet(ds))
        {
            lbGenere.DataTextField = "Genere_Name";
            lbGenere.DataValueField = "Genere_Id";
            lbGenere.DataSource = ds.Tables[0];
            lbGenere.DataBind();
        }
        else
        {
            lbGenere.Items.Clear();
        }
    }
    private void get_Starring(string staring_type, ListBox ld)
    {
        DataSet ds = new DataSet();
        ds = new DataLayer().get_Starring(staring_type);
        if (AllClasses.CheckDataSet(ds))
        {
            ld.DataTextField = "Starring_name";
            ld.DataValueField = "Starring_id";
            ld.DataSource = ds.Tables[0];
            ld.DataBind();
        }
        else
        {
            ld.Items.Clear();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAlbumName.Text.Trim() == "")
        {
            txtAlbumName.Focus();
            return;
        }
        if (txtDescription.Text.Trim() == "")
        {
            txtDescription.Focus();
            return;
        }
        if (ddlMountingRating.Text.Trim() == "")
        {
            ddlMountingRating.Focus();
        }
        if (ddlStudio.SelectedValue == "0")
        {
            ddlStudio.Focus();
            return;
        }
        if (ddlCategory.SelectedValue == "0")
        {
            ddlCategory.Focus();
            return;
        }

        tbl_Album_Save objAlbumSave = new tbl_Album_Save();

        try
        {
            objAlbumSave.Album_Id = Convert.ToInt32(hf_AlbumId.Value);
        }
        catch
        {
            objAlbumSave.Album_Id = 0;
        }
        List<tbl_Upload_Banner> obj_tbl_Upload_BannerLi = new List<tbl_Upload_Banner>();
        Dictionary<string, byte[]> file_Upload_Array_Banner = new Dictionary<string, byte[]>();
        if (Session["FileUpload1"] != null)
        {
            file_Upload_Array_Banner = (Dictionary<string, byte[]>)Session["FileUpload1"];
            foreach (KeyValuePair<string, byte[]> item in file_Upload_Array_Banner)
            {
                if (item.Value != null)
                {
                    tbl_Upload_Banner obj_tbl_Upload_Banner = new tbl_Upload_Banner();
                    obj_tbl_Upload_Banner.AlbumUpload_Status = 1;
                    obj_tbl_Upload_Banner.AlbumUpload_Type = "B";
                    obj_tbl_Upload_Banner.AlbumUpload_File_Bytes = item.Value;
                    obj_tbl_Upload_Banner.AlbumUpload_Path = item.Key;
                    obj_tbl_Upload_BannerLi.Add(obj_tbl_Upload_Banner);
                }
            }
        }
        else
        {
            file_Upload_Array_Banner = null;
        }

        Dictionary<string, byte[]> file_Upload_Array_Video = new Dictionary<string, byte[]>();
        if (Session["FileUpload2"] != null)
        {
            file_Upload_Array_Video = (Dictionary<string, byte[]>)Session["FileUpload2"];
            foreach (KeyValuePair<string, byte[]> item in file_Upload_Array_Video)
            {
                if (item.Value != null)
                {
                    tbl_Upload_Banner obj_tbl_Upload_Banner = new tbl_Upload_Banner();
                    obj_tbl_Upload_Banner.AlbumUpload_Status = 1;
                    obj_tbl_Upload_Banner.AlbumUpload_Type = "V";
                    obj_tbl_Upload_Banner.AlbumUpload_File_Bytes = item.Value;
                    obj_tbl_Upload_Banner.AlbumUpload_Path = item.Key;
                    obj_tbl_Upload_BannerLi.Add(obj_tbl_Upload_Banner);
                }
            }
        }
        else
        {
            file_Upload_Array_Video = null;
        }
        if (file_Upload_Array_Banner == null || file_Upload_Array_Banner.Count == 0)
        {
            MessageBox.Show("Please Upload Album Banner.");
            return;
        }
        if (file_Upload_Array_Video == null || file_Upload_Array_Video.Count == 0)
        {
            MessageBox.Show("Please Upload Trailer Video.");
            return;
        }
        objAlbumSave.Album_Name = txtAlbumName.Text.Trim();
        objAlbumSave.Album_Description = txtDescription.Text.Trim();
        objAlbumSave.Album_Rating = Rating1.CurrentRating;
        objAlbumSave.Album_Mounting_Rating = ddlMountingRating.Text.Trim();
        objAlbumSave.Album_Studio_Id = Convert.ToInt32(ddlStudio.SelectedValue);
        objAlbumSave.Album_Category = Convert.ToInt32(ddlCategory.SelectedValue);
        objAlbumSave.Album_AddedBy = Convert.ToInt32(Session["Person_Id"].ToString());
        objAlbumSave.Album_Status = 1;
        List<tbl_Album_Staff> obj_tbl_Album_Staff_Li = new List<tbl_Album_Staff>();
        for (int i = 0; i < lbStarring.Items.Count; i++)
        {
            if (lbStarring.Items[i].Selected)
            {
                tbl_Album_Staff obj_tbl_Album_Staff = new tbl_Album_Staff();
                obj_tbl_Album_Staff.AlbumStaff_AddedBy = Convert.ToInt32(Session["Person_Id"].ToString());
                obj_tbl_Album_Staff.AlbumStaff_Starring_id = Convert.ToInt32(lbStarring.Items[i].Value);
                obj_tbl_Album_Staff.AlbumStaff_Status = 1;
                obj_tbl_Album_Staff_Li.Add(obj_tbl_Album_Staff);
            }
        }
        for (int i = 0; i < lbDirector.Items.Count; i++)
        {
            if (lbDirector.Items[i].Selected)
            {
                tbl_Album_Staff obj_tbl_Album_Staff = new tbl_Album_Staff();
                obj_tbl_Album_Staff.AlbumStaff_AddedBy = Convert.ToInt32(Session["Person_Id"].ToString());
                obj_tbl_Album_Staff.AlbumStaff_Starring_id = Convert.ToInt32(lbDirector.Items[i].Value);
                obj_tbl_Album_Staff.AlbumStaff_Status = 1;
                obj_tbl_Album_Staff_Li.Add(obj_tbl_Album_Staff);
            }
        }
        for (int i = 0; i < lbSupportingActor.Items.Count; i++)
        {
            if (lbSupportingActor.Items[i].Selected)
            {
                tbl_Album_Staff obj_tbl_Album_Staff = new tbl_Album_Staff();
                obj_tbl_Album_Staff.AlbumStaff_AddedBy = Convert.ToInt32(Session["Person_Id"].ToString());
                obj_tbl_Album_Staff.AlbumStaff_Starring_id = Convert.ToInt32(lbSupportingActor.Items[i].Value);
                obj_tbl_Album_Staff.AlbumStaff_Status = 1;
                obj_tbl_Album_Staff_Li.Add(obj_tbl_Album_Staff);
            }
        }
        List<tbl_Album_Genere> obj_tbl_Album_Genere_Li = new List<tbl_Album_Genere>();
        for (int i = 0; i < lbGenere.Items.Count; i++)
        {
            if (lbGenere.Items[i].Selected)
            {
                tbl_Album_Genere obj_tbl_Album_Genere = new tbl_Album_Genere();
                obj_tbl_Album_Genere.AlbumGenere_AddedBy = Convert.ToInt32(Session["Person_Id"].ToString());
                obj_tbl_Album_Genere.AlbumGenere_Genere_id = Convert.ToInt32(lbGenere.Items[i].Value);
                obj_tbl_Album_Genere.AlbumGenere_Status = 1;
                obj_tbl_Album_Genere_Li.Add(obj_tbl_Album_Genere);
            }
        }

        if (new DataLayer().Insert_Album(objAlbumSave, obj_tbl_Album_Staff_Li, obj_tbl_Album_Genere_Li, obj_tbl_Upload_BannerLi))
        {
            MessageBox.Show("Created Successfully");
            reset();
        }
        else
        {
            MessageBox.Show("Error");
        }
    }

    private void reset()
    {
        hf_AlbumId.Value = "0";
        txtAlbumName.Text = "";
        txtDescription.Text = "";
        Rating1.CurrentRating = 0;

        for (int i = 0; i < lbDirector.Items.Count; i++)
        {
            lbDirector.Items[i].Selected = false;
        }
        for (int i = 0; i < lbGenere.Items.Count; i++)
        {
            lbGenere.Items[i].Selected = false;
        }
        for (int i = 0; i < lbStarring.Items.Count; i++)
        {
            lbStarring.Items[i].Selected = false;
        }
        for (int i = 0; i < lbSupportingActor.Items.Count; i++)
        {
            lbSupportingActor.Items[i].Selected = false;
        }
        ddlCategory.SelectedValue = "0";
        ddlMountingRating.SelectedValue = "0";
        ddlStudio.SelectedValue = "0";
        ddlCategory.SelectedValue = "0";
        Session["FileUpload1"] = null;
        Session["FileUpload2"] = null;

    }

    protected void btnAddStarring_Click(object sender, ImageClickEventArgs e)
    {
        mpCreateStar.Show();
    }

    protected void btnSaveStar_Click(object sender, EventArgs e)
    {
        tbl_Starring objStarring = new tbl_Starring();
        if (txtStarName.Text.Trim() == "")
        {
            MessageBox.Show("Please Provide Name!!");
            txtStarName.Focus();
            mpCreateStar.Show();
            return;
        }
        objStarring.Starring_Name = txtStarName.Text.Trim();
        objStarring.Starring_Type = ddlStarType.SelectedValue;
        if (new DataLayer().Starring_savebtn(objStarring))
        {
            MessageBox.Show("Created Successfully");
            get_Starring("S", lbStarring);
            get_Starring("D", lbDirector);
            get_Starring("A", lbSupportingActor);
            txtStarName.Text = "";
        }
        else
        {
            MessageBox.Show("Error");
            mpCreateStar.Show();
        }

    }

    protected void btnCreateGenere_Click(object sender, EventArgs e)
    {
        tbl_Genere objGenere = new tbl_Genere();
        if (txtGenere.Text.Trim() == "")
        {
            MessageBox.Show("Please Provide Name!!");
            txtGenere.Focus();
            mpGenere.Show();
            return;
        }

        objGenere.Genere_Name = txtGenere.Text.Trim();
        if (new DataLayer().Genere_savebtn(objGenere))
        {
            MessageBox.Show("Created Successfully");
            txtGenere.Text = "";
            get_Genere();
        }
        else
        {
            MessageBox.Show("Error");
            mpGenere.Show();
        }
    }

    protected void btnAddGenere_Click(object sender, ImageClickEventArgs e)
    {
        mpGenere.Show();
    }

    protected void btnCreateStudio_Click(object sender, EventArgs e)
    {
        tbl_Studio objStudio = new tbl_Studio();

        if (txtStudio.Text.Trim() == "")
        {
            MessageBox.Show("Please Provide Name!!");
            txtStudio.Focus();
            mpStudio.Show();
            return;
        }

        objStudio.Studio_Name = txtStudio.Text.Trim();
        if (new DataLayer().Studio_savebtn(objStudio))
        {
            MessageBox.Show("Created Successfully");
            txtStudio.Text = "";
            fill_Studio();
        }
        else
        {
            MessageBox.Show("Error");
            mpStudio.Show();
        }
    }


    private void fill_Category()
    {
        DataSet ds = new DataSet();
        ds = new DataLayer().get_Category();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            AllClasses.FillDropDown(ds.Tables[0], ddlCategory, "Category_Name", "Category_Id");
        }

        else
        {



        }
    }
    private void fill_Studio()
    {
        DataSet ds = new DataSet();
        ds = new DataLayer().get_Studio();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            AllClasses.FillDropDown(ds.Tables[0], ddlStudio, "Studio_Name", "Studio_Id");
        }

        else
        {



        }
    }

    protected void btnAddStudio_Click(object sender, ImageClickEventArgs e)
    {
        mpStudio.Show();
    }
}