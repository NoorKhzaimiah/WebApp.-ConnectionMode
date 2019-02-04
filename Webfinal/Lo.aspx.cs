using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Webfinal
{
    public partial class Lo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = " " ;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tawjihi.mdf;Integrated Security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con1;
                com.CommandText = "select * from student where id=@id and password=@password";
                com.Parameters.Add("id", DbType.String);
                com.Parameters.Add("password", DbType.String);
                com.Parameters["id"].Value = TextBox1.Text;
                com.Parameters["password"].Value = TextBox2.Text;

                 

                con1.Open();
                SqlDataReader rd1 = com.ExecuteReader();
                if (rd1.Read())
                {
                    Session["id"] = rd1["id"];
                    Response.Redirect("p2.aspx");
                }
                else
                    Label1.Text = "invalid id/password";
                rd1.Close();
                con1.Close();
            }
            catch (Exception ex1)
            {
                Label1.Text = ex1.Message;
            }

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}