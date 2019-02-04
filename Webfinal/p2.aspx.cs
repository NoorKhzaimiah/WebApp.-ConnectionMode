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
    public partial class p2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tawjihi.mdf;Integrated Security=True";
            SqlCommand com = new SqlCommand();
            com.Connection = con1;
            com.CommandText = "insert into student values (@id,@password,@name,@grade,@city)";
            com.Parameters.AddWithValue("@id", (TextBox1.Text));
            com.Parameters.AddWithValue("@password", (TextBox2.Text));
            com.Parameters.AddWithValue("@name", (TextBox3.Text));
            com.Parameters.AddWithValue("@grade", Int32.Parse(TextBox4.Text));  
            com.Parameters.AddWithValue("city", (TextBox5.Text));





            con1.Open();
            try
            {
                if (com.ExecuteNonQuery() == 1)
                    Label1.Text = "Success";
                else
                    Label1.Text = "err";
            }
            catch(Exception exx)
            {
                Label1.Text = exx.Message;
            }
            con1.Close();
        }
    }
}