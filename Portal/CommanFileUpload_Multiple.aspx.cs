using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommanFileUpload_Multiple : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void AjaxFileUploadMultiple_UploadCompleteAll(object sender, AjaxControlToolkit.AjaxFileUploadCompleteAllEventArgs e)
    {
        Dictionary<string, byte[]> file_Upload_Array = new Dictionary<string, byte[]>();
        //string strUploadPath = "~/K_Log/" + Request.UrlReferrer.Query.Split(new char[]{'='})[1].ToString() + "/";
        string strUploadPath = "~/K_Log/" + Session["Folder_Name1"].ToString() + "/";

        string[] _files = Directory.GetFiles(Server.MapPath(strUploadPath));
        if (_files != null && _files.Length > 0)
        {
            for (int i = 0; i < _files.Length; i++)
            {
                FileInfo fl = new FileInfo(_files[i]);
                file_Upload_Array.Add(fl.Name, File.ReadAllBytes(fl.FullName));
            }
        }        
        Session["FileUpload1"] = file_Upload_Array;
        AllClasses.Create_Directory_Session1();
    }

    protected void AjaxFileUploadMultiple_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        string filename = System.IO.Path.GetFileName(e.FileName);
        //string strUploadPath = "~/K_Log/" + Request.UrlReferrer.Query.Split(new char[]{'='})[1].ToString() + "/";
        string strUploadPath = "~/K_Log/" + Session["Folder_Name1"].ToString() + "/";
        AjaxFileUploadMultiple.SaveAs(Server.MapPath(strUploadPath) + filename);
    }
}