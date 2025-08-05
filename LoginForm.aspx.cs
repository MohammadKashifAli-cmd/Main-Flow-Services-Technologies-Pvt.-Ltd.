using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace LoginApp
{
    public partial class LoginForm : System.Web.UI.Page
    {
        private readonly string cms = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(cms))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from LoginApp where username=@username and password=@password", con);
                cmd.Parameters.AddWithValue("@username", usernameField.Text);
                cmd.Parameters.AddWithValue("@password", passwordField.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    if(dr.HasRows)
                    {
                        Session["username"] = dr["username"].ToString();
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }
    }
}