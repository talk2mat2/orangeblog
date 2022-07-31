using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class account_Default : System.Web.UI.Page
{

    public static bool Pass_Email_Error = false;
    public static string error_message = "";
    public static bool success = false;
    public static string success_message = "";
    string email = "";
    string password = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        success = false;
        success_message = "";
        error_message = "";
        Pass_Email_Error = false;
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
      

        if(!(Email.Text.Length>0) || !(Password.Text.Length > 0) || !(Name.Text.Length > 0))
        {
            error_message = "provide email ,password and full name";
            Pass_Email_Error = true;

        }
        else
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["blogdb"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                 con.Open();
                string query = @"select * from account where email="+"\'"+Email.Text+"\';";
                SqlDataReader Users= new SqlCommand(query, con).ExecuteReader();
                if (Users.HasRows)
                {
                    //users already exist in database
                    Pass_Email_Error = true;
                    error_message = "A already user  exist with this email " + Email.Text;
                    return;
                }


            }
            catch(Exception er)
            {
                Pass_Email_Error = true;
                error_message = "registeration failed" + er;
            }

            try
            {
                //get connection to database
                var connectionString = ConfigurationManager.ConnectionStrings["blogdb"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();
                string query = @"insert into account (name,email,password) values(" + "\'" + Name.Text + "\',\'" + Email.Text + "\',\'" + Password.Text + "\');";
                SqlCommand register = new SqlCommand(query, conn);
                register.ExecuteNonQuery();
                success = true;
                success_message = "registered successfully";
                conn.Close();
            }
            catch (Exception error)
            {
                Pass_Email_Error = true;
                error_message = "registeration failed" + error;
            }


        }
    }
}