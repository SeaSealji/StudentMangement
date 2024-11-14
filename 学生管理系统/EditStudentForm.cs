using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 学生管理系统
{
    public partial class EditStudentForm : Form
    {
        public EditStudentForm(string studentId)
        {
           
            InitializeComponent();
            LoadStudentData(studentId);
            LoadSdeptValues();
        }
        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadStudentData(string studentId)
        {
            string connectionString = "Server=localhost;Database=test2;User Id=root;Password=123456;";
            string query = "SELECT Sno, Sname, Ssex, Sage, Sdept FROM Student WHERE Sno = @Sno";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Sno", studentId);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtSname2.Text = reader["SName"].ToString();
                        txtSno1.Text = reader["Sno"].ToString();
                        txtSage2.Text = reader["Sage"].ToString();
                       // txtSsex2.Text = reader["Ssex"].ToString();
                        comboBox1.Text= reader["Ssex"].ToString();
                        //txtSdept2.Text = reader["Sdept"].ToString();
                        comboBox2.Text= reader["Sdept"].ToString();
                        
                    }
                }

            }
           

        }
        private void LoadSdeptValues()
        {
            string connectionString = "Server=localhost;Database=test2;User Id=root;Password=123456;";
            string query = "SELECT DISTINCT Sdept FROM Student";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string sdept = reader["Sdept"].ToString();
                        comboBox2.Items.Add(sdept);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=test2;User Id=root;Password=123456;";
            string updateQuery = "UPDATE Student SET SName = @SName, Ssex = @Ssex, SAge = @SAge, Sdept = @Sdept WHERE Sno = @Sno";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Sname", txtSname2.Text);
                // 为其他字段添加参数
                cmd.Parameters.AddWithValue("@Sdept", comboBox2.Text);  // 确保有 studentId 字段
                cmd.Parameters.AddWithValue("@Ssex", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Sage",txtSage2.Text.ToString());
                cmd.Parameters.AddWithValue("@Sno", txtSno1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}
