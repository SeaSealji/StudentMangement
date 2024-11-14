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


namespace 学生管理系统
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadSdeptValues();

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSno.Text) ||
        string.IsNullOrWhiteSpace(txtSname.Text) ||
        string.IsNullOrWhiteSpace(comboBox1.Text) ||
        string.IsNullOrWhiteSpace(txtSage.Text) ||
        string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // 构造学生对象，这一步是可选的，取决于您是否使用对象来处理数据
            Student newStudent = new Student()
            {
                Sno = txtSno.Text,
                Sname = txtSname.Text,
                Ssex = comboBox1.Text,
                Sage = int.Parse(txtSage.Text), // 注意处理可能的格式错误
                Sdept = comboBox2.Text
            };

            // 调用主窗体的方法来添加数据到数据库
            ((Form1)this.Owner).InsertStudentIntoDatabase(newStudent);
            this.Close();
        }
    }
}
