<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        //RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs       
    }

    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Login", "Login", "~/Index.aspx");
    }
    protected void Application_PreSendRequestHeaders()
    {
        Response.Headers.Remove("X-Frame-Options");
        Response.AddHeader("X-Frame-Options", "AllowAll");
    }
    void Session_Start(object sender, EventArgs e)
    {
        Session.Timeout = 120;
        Session.Add("Login_Id", null);
        Session.Add("Login_UserName", null);
        Session.Add("Person_Id", null);
        Session.Add("ServerDate", null);
        Session.Add("LoginHistory_Id", null);
    }

    void Session_End(object sender, EventArgs e)
    {
        Session["Login_Id"] = null;
        Session["Login_UserName"] = null;
        Session["Person_Id"] = null;
        Session["ServerDate"] = null;
        Session["LoginHistory_Id"] = null;
    }

</script>

