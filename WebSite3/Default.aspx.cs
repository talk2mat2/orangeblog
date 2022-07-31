using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RepeterData();
        }
    }

    public void RepeterData()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["blogdb"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        cmd = new SqlCommand("select posts.id,posts.title,posts.body,posts.postedby,posts.created_at,account.name from posts INNER JOIN account on account.id=posts.postedby", con);
        DataSet ds = new DataSet();
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        RepterDetails.DataSource = ds;
        RepterDetails.DataBind();
    }
}