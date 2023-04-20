<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        //Application["activeUsers"] = 0;
        //Application["users"] = 0;
        Application["SignedInVisitors"] = 0;
        Application["GuestVisitors"] = 0;
        Application["AdminVisitors"] = 0;
        Application["currentVisitors"] = 0;
        Application["currentGuestVisitors"] = 0;
        Application["currentSignedInVisitors"] = 0;
        Application["currentAdminVisitors"] = 0;
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session["type"] = 0;
        Session.Timeout = 20;
        //Application["users"] = (int)Application["users"] + 1;
        Session["admin"] = false;
        Session["login"] = false;
        Session["Admin2"] = false;
        Session["username2"] = "guest";
        Application.Lock();
        Application["currentVisitors"] = (int)Application["currentVisitors"] + 1;
        Session ["count"] = 0;
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

       // Application.Lock();
       // Application["activeUsers"] = (int)Application["activeUsers"] - 1;
      //  Application.UnLock();
       // Session.Abandon();
       // Session.Clear();
        Application.Lock();
        Application["currentVisitors"] = (int)Application["currentVisitors"] - 1;
        if ((int)Application["currentGuestVisitors"] >=1 )
            Application["currentGuestVisitors"] = (int)Application["currentGuestVisitors"] - 1;
        if ((int)Application["currentSignedInVisitors"] >=1)
            Application["currentSignedInVisitors"] = (int)Application["currentSignedInVisitors"] - 1;
        if ((int)Application["currentAdminVisitors"] >=1)
            Application["currentAdminVisitors"] = (int)Application["currentAdminVisitors"] - 1;
        Application.UnLock();
        Session.Abandon();
        Session.Clear();
    }

</script>
