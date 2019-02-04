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
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Text = "";
            try
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tawjihi.mdf;Integrated Security=True";


                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;
                cmd1.CommandText = "select name as student_name, grade, city from student where id=@id";
                cmd1.Parameters.Add("id", DbType.String);
               cmd1.Parameters["id"].Value = (DropDownList1.SelectedValue);
                con1.Open();

                SqlDataReader rd1 = cmd1.ExecuteReader();
                ListItem item = new ListItem("name     grade");
                ListBox1.Items.Add(item);
                while (rd1.Read())
                {
                    string name = rd1["student_name"].ToString();
                    double grade = Convert.ToDouble(rd1["grade"]);
                    //  item = new ListItem(name + "   " + grade);
                    ListBox1.Items.Add(name + "     " + grade);
                }
                rd1.Close();
                con1.Close();
            }
            catch (Exception ex1)
            {
                Label1.Text = ex1.Message;
            }
        }
 
    }
}