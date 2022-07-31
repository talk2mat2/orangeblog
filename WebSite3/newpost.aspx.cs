using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class newpost : System.Web.UI.Page
{

    public static bool PostError;
    public static string error_message;
    protected void Page_Load(object sender, EventArgs e)
    {
        PostError = false;
     error_message = "";
}

    protected void Button1_Click(object sender, EventArgs e)
    {
        string textBody = descriptionTextBox.Text.ToString();
        string Posttitle = PostTitle.Text;


        if(string.IsNullOrEmpty(Posttitle) || string.IsNullOrEmpty(textBody))
            {
            return;

        }
        else
        {
            try
            {
                //getdb connection

                string connectionString = ConfigurationManager.ConnectionStrings["blogdb"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                var id = Session["userid"].ToString();
                int userid = Convert.ToInt32(id);
                DateTime now = DateTime.Now;
                string query = @"insert into posts (title,body,postedby, created_at) values ('" + Posttitle + "\',\'" + textBody + "\',\'" + userid + "\','" + now + "\')";
                SqlCommand register = new SqlCommand(query, conn);
                register.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/");
            }
            catch(Exception err)
            {
                PostError = true;
                error_message = "error ocured" + err;
            }
        }


    }
}