using System.Web;
using System.Web.UI;

public class SetMasterPage : Page
{
    public static string ReturnPage()
    {
        string _page = string.Empty;
        _page = "TemplateMasterAdmin.master";
        return _page;
    }
}
