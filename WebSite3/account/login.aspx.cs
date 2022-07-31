using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class account_Default : System.Web.UI.Page
{
    public static bool Pass_Email_Error = false;
    public static string error_message = "";
    string email = "";
    string password = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Pass_Email_Error = false;
        error_message = "";

    }


    protected void Button1_Click(object sender, EventArgs e)

    {

        if (!(Email.Text.Length > 0) || !(Password.Text.Length > 0))
        {
            Pass_Email_Error = true;
            error_message = "provide a valid email and password ";

        }
        else
        {
            try
            {
                //EXTABLISH CONNECTION WITH DB
                string connectionString = ConfigurationManager.ConnectionStrings["blogdb"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                //check mif user exist
                string query = @"select email,password,name,id from account where email=" + "\'" + Email.Text + "\';";
                SqlDataReader exist = new SqlCommand(query, conn).ExecuteReader();
                if (exist.Read() && exist.HasRows)
                {
                    email = exist.GetString(0);
                    password = exist.GetString(1);
                    string name = exist.GetString(2);
                    int id = exist.GetInt32(3);
                    if (email == Email.Text && password == Password.Text)
                    {
                        Session["user"] = name;
                        Session["userid"] = id;
                        Response.Redirect("/");
                    }
                    else
                    {
                        Pass_Email_Error = true;
                        error_message = "invalid email or password";

                    }
                }
            }
            catch (Exception error)
            {
                Pass_Email_Error = true;
                error_message = "error occured = " + error;

            }
        }
    }
}