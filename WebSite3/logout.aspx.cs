using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public class Main : MasterPage
{


}
public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Main.IsloggedIn = false;
        Session.Clear();
        Session.Abandon();
        Response.Redirect("/account/login.aspx");

    }
}