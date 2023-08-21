using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace Ind
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jshya\OneDrive\Documents\MyEmployeeDB.mdf;Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sex = string.Empty;
            if (RadioButton1.Checked)
            {
                sex = "Male";
            }
            else if (RadioButton2.Checked)
            {
                sex = "Female";
            }
            else if (RadioButton3.Checked)
            {
                sex = "Others";
            }
            string maritalstatus = string.Empty;
            if (RadioButton4.Checked)
            {
                maritalstatus = "Single";
            }
            else if (RadioButton5.Checked)
            {
                maritalstatus = "Married";
            }

            if (EmpNameTb.Text == "" || EmpIDTb.Text == "" || DepartmentCb.SelectedIndex == -1 || SalaryTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into EmpTB1(EmpId,EmpName,Department,Sex,MaritalStatus,Salary,Address)values(@EID,@EN,@DP,@SX,@MS,@SL,@AD)", Con);
                    cmd.Parameters.AddWithValue("@EID", EmpIDTb.Text);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", DepartmentCb.ToString());
                    cmd.Parameters.AddWithValue("@SX", sex);
                    cmd.Parameters.AddWithValue("@MS", maritalstatus);
                    cmd.Parameters.AddWithValue("@SL", SalaryTB.Text);
                    cmd.Parameters.AddWithValue("@AD", AddressTA.InnerText);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details Updated");
                    Con.Close();
                    ShowEmployee();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }

        }

        private void ShowEmployee()
        {
            throw new NotImplementedException();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            /*SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PassoneConnectionString"].ConnectionString);
            Con.Open();
            SqlCommand com = new SqlCommand("(SELECT EmpId,EmpName,Department,Sex,MaritalStatus,Address,Salary FROM EmpTB1)", Con);
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader = com.ExecuteReader();
            dt.Load(sqlDataReader);
            sqlDataReader.Close();
            GridView dataGridView1 = new GridView();
            dataGridView1.DataSource = dt;
            Con.Close();*/

            Response.Redirect("WebForm1.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from EmpTB1 where EmpId=@EID", Con);
                    cmd.Parameters.AddWithValue("@EID", EmpIDTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee details deleted");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

