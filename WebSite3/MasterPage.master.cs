using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public static string user;
    public static bool IsloggedIn = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Session["user"] as string))
        {
            user = Session["user"] as string;
            IsloggedIn = true;
        }

    }

    protected void handleLogout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
       // IsloggedIn=false;

    }
}
