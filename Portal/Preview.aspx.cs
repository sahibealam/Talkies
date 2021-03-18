using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            int Album_Id = Convert.ToInt32(Request.QueryString[0].ToString());
            string _inner = "";
            DataSet ds = new DataLayer().get_Banner(Album_Id);
            if (AllClasses.CheckDataSet(ds))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    _inner += "<a href = '" + ds.Tables[0].Rows[i]["AlbumUpload_Path"].ToString() + "' rel = 'lyteshow[vacation]' title = 'Preview-" + (i + 1) + "'>Preview-" + (i + 1) + "</a>";
                }
                albumPreview.InnerHtml = _inner;
            }

        }
    }
}