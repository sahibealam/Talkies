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

public partial class AlbumSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            fill_Category();
            fill_Studio();
            get_Genere();
            get_Starring("S", lbStarring);
            get_Starring("D", lbDirector);
            get_Starring("A", lbSupportingActor);
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string Star = "";
        string Director = "";
        string Genere = "";
        string Suppporting = "";
        int Category_Id = 0;
        for (int i = 0; i < lbStarring.Items.Count; i++)
        {
            if (lbStarring.Items[i].Selected)
            {
                Star += lbStarring.Items[i].Value + ", ";
            }
        }
        if (Star.Trim() != "")
        {
            Star = Star.Trim().Substring(0, Star.Trim().Length - 1);
        }
        for (int i = 0; i < lbDirector.Items.Count; i++)
        {
            if (lbDirector.Items[i].Selected)
            {
                Director += lbDirector.Items[i].Value + ", ";
            }
        }
        if (Director.Trim() != "")
        {
            Director = Director.Trim().Substring(0, Director.Trim().Length - 1);
        }
        for (int i = 0; i < lbSupportingActor.Items.Count; i++)
        {
            if (lbSupportingActor.Items[i].Selected)
            {
                Suppporting += lbSupportingActor.Items[i].Value + ", ";
            }
        }
        if (Suppporting.Trim() != "")
        {
            Suppporting = Suppporting.Trim().Substring(0, Suppporting.Trim().Length - 1);
        }
        for (int i = 0; i < lbGenere.Items.Count; i++)
        {
            if (lbGenere.Items[i].Selected)
            {
                Genere += lbGenere.Items[i].Value + ", ";
            }
        }
        if (Genere.Trim() != "")
        {
            Genere = Genere.Trim().Substring(0, Genere.Trim().Length - 1);
        }

        int Studio_Id = 0;
        try
        {
            Studio_Id = Convert.ToInt32(ddlStudio.SelectedValue);
        }
        catch
        {
            Studio_Id = 0;
        }
        Category_Id = Convert.ToInt32(ddlCategory.SelectedValue);
        DataSet ds = new DataSet();
        ds = new DataLayer().Insert_Grid(txtAlbumName.Text.Trim(), Category_Id, Studio_Id, Genere, Star, Suppporting, Director);
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
    }
    protected void btnSearch_Click()
    {
        string Star = "";
        string Director = "";
        string Genere = "";
        string Suppporting = "";
        int Category_Id = 0;
        for (int i = 0; i < lbStarring.Items.Count; i++)
        {
            if (lbStarring.Items[i].Selected)
            {
                Star += lbStarring.Items[i].Value + ", ";
            }
        }
        if (Star.Trim() != "")
        {
            Star = Star.Trim().Substring(0, Star.Trim().Length - 1);
        }
        for (int i = 0; i < lbDirector.Items.Count; i++)
        {
            if (lbDirector.Items[i].Selected)
            {
                Director += lbDirector.Items[i].Value + ", ";
            }
        }
        if (Director.Trim() != "")
        {
            Director = Director.Trim().Substring(0, Director.Trim().Length - 1);
        }
        for (int i = 0; i < lbSupportingActor.Items.Count; i++)
        {
            if (lbSupportingActor.Items[i].Selected)
            {
                Suppporting += lbSupportingActor.Items[i].Value + ", ";
            }
        }
        if (Suppporting.Trim() != "")
        {
            Suppporting = Suppporting.Trim().Substring(0, Suppporting.Trim().Length - 1);
        }
        for (int i = 0; i < lbGenere.Items.Count; i++)
        {
            if (lbGenere.Items[i].Selected)
            {
                Genere += lbGenere.Items[i].Value + ", ";
            }
        }
        if (Genere.Trim() != "")
        {
            Genere = Genere.Trim().Substring(0, Genere.Trim().Length - 1);
        }

        Category_Id = Convert.ToInt32(ddlCategory.SelectedValue);
        DataSet ds = new DataSet();
        ds = new DataLayer().Insert_Grid(txtAlbumName.Text.Trim(), Category_Id, Convert.ToInt32(ddlStudio.SelectedValue), Genere, Star, Suppporting, Director);
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
    }

    protected void grdPost_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Rating = e.Row.Cells[1].Text.Trim();
            AjaxControlToolkit.Rating Rating1 = e.Row.FindControl("Rating1") as AjaxControlToolkit.Rating;
            Rating1.ReadOnly = true;
            Rating1.CurrentRating = Convert.ToInt32(Rating);

            BulletedList List_Director_id = (e.Row.FindControl("List_Director_id") as BulletedList);
            BulletedList List_Star_id = (e.Row.FindControl("List_Star_id") as BulletedList);
            BulletedList List_Supporting_id = (e.Row.FindControl("List_Suppoprting_id") as BulletedList);
            BulletedList List_Genere_id = (e.Row.FindControl("List_Genere_id") as BulletedList);
            generate_bullets(e.Row.Cells[2].Text.Trim(), List_Director_id);
            generate_bullets(e.Row.Cells[3].Text.Trim(), List_Star_id);
            generate_bullets(e.Row.Cells[4].Text.Trim(), List_Supporting_id);
            generate_bullets(e.Row.Cells[5].Text.Trim(), List_Genere_id);


            int Album_Id = Convert.ToInt32(e.Row.Cells[0].Text.ToString());

            //HtmlGenericControl albumPreview = e.Row.FindControl("albumPreview") as HtmlGenericControl;
            HiddenField hf_albumPreview = e.Row.FindControl("hf_albumPreview") as HiddenField;


            string _inner = "";
            DataSet ds = new DataLayer().get_Banner(Album_Id);
            if (AllClasses.CheckDataSet(ds))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    _inner += "<a href = '" + ds.Tables[0].Rows[i]["AlbumUpload_Path"].ToString() + "' rel = 'lyteshow[vacation]' title = 'Preview-" + (i + 1) + "'>Preview-" + (i + 1) + "</a>";
                }
                hf_albumPreview.Value = _inner;
            }
        }
    }

    private static void generate_bullets(string _data, BulletedList List_Director_id)
    {
        string[] List_Director = _data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        List_Director_id.DataSource = List_Director;
        List_Director_id.DataBind();
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int Album_Id = 0;
        ImageButton btnReview = sender as ImageButton;
        GridViewRow gr = btnReview.Parent.Parent as GridViewRow;

        Album_Id = Convert.ToInt32(gr.Cells[0].Text.Trim());
        if (new DataLayer().Delete_Album(Album_Id))
        {
            MessageBox.Show("Deleted Successfully!!");
            btnSearch_Click();
            return;
        }
        else
        {
            MessageBox.Show("Error In Deletion!!");
            return;
        }
    }

    protected void btnReview_Click(object sender, ImageClickEventArgs e)
    {
        int Album_Id = 0;
        ImageButton btnReview = sender as ImageButton;
        GridViewRow gr = btnReview.Parent.Parent as GridViewRow;

        Album_Id = Convert.ToInt32(gr.Cells[0].Text.Trim());
        Response.Redirect("Default.aspx?Album_Id=" + Album_Id);
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int Album_Id = 0;
        ImageButton btnReview = sender as ImageButton;
        GridViewRow gr = btnReview.Parent.Parent as GridViewRow;

        Album_Id = Convert.ToInt32(gr.Cells[0].Text.Trim());


        Response.Redirect("CreateAlbum.aspx?Album_Id=" + Album_Id.ToString());
    }
}

