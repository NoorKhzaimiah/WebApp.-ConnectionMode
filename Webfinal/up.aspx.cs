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
    public partial class up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tawjihi.mdf;Integrated Security=True";
            con1.Open();
            SqlCommand com = new SqlCommand("update student set name =@name where id =@id" , con1);
            com.Parameters.Add("id", DbType.String);
            com.Parameters.Add("name", DbType.String);
            com.Parameters["id"].Value = (TextBox2.Text);
            com.Parameters["name"].Value = (TextBox1.Text);


            try
            {
                if (com.ExecuteNonQuery() == 1)
                    Label1.Text = "successfull update";
                else
                    Label1.Text = "erreor";

            }
            catch (Exception ex1)
            {
                Label1.Text = ex1.Message;
            }
        }
    }
}