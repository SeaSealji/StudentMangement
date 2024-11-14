using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 学生管理系统
{
   
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string connectionString = "Server=localhost;Database=test2;User Id=root;Password=123456;";
    
        public Form1()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            LoadData();
            showView.FullRowSelect = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Sno, Sname, Ssex,Sage,Sdept FROM student";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    showView.Items.Clear(); // 清除现有的数据
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Sno"].ToString());
                        item.SubItems.Add(reader["Sname"].ToString());
                        item.SubItems.Add(reader["Ssex"].ToString());
                        item.SubItems.Add(reader["Sage"].ToString());
                        item.SubItems.Add(reader["Sdept"].ToString());
                        showView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (showView.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要编辑的学生");
                return;
            }

            ListViewItem item = showView.SelectedItems[0];
            string studentId = item.SubItems[0].Text;  // 假设学号是第一个子项

            // 创建并显示编辑表单
            EditStudentForm editForm = new EditStudentForm(studentId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // 更新 ListView 的显示
                
                item.SubItems[1].Text = editForm.txtSname2.Text;
                item.SubItems[2].Text = editForm.comboBox1.Text;
                item.SubItems[3].Text = editForm.txtSage2.Text.ToString();
                item.SubItems[4].Text = editForm.comboBox2.Text;

            }
        }
        private void UpdateListViewItem(Student student, ListViewItem item)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            addForm.Owner = this;
            addForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (showView.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除的学生");
                return;
            }

            var confirmResult = MessageBox.Show("确定要删除选中的学生吗？",
                                                "确认删除",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                ListViewItem item = showView.SelectedItems[0];
                string studentId = item.SubItems[0].Text;  // 假设学号是第一个子项

                // 删除 ListView 中的项
                showView.Items.Remove(item);

                // 更新数据库或其他数据源
                DeleteStudentFromDatabase(studentId);
            }
        }
        private void DeleteStudentFromDatabase(string studentId)
        {
            // 数据库删除逻辑
            string connectionString = "Server=localhost;Database=test2;User Id=root;Password=123456;";  // 数据库连接字符串
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Student WHERE Sno = @Sno";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Sno", studentId);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    // 可以根据 result 的值判断删除操作是否成功
                    if (result > 0)
                    {
                        MessageBox.Show("学生删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("学生删除失败！");
                    }
                }
            }
        }

        public void InsertStudentIntoDatabase(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO student (Sno, Sname, Ssex, Sage, Sdept) VALUES (@Sno, @Sname, @Ssex, @Sage, @Sdept)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Sno", student.Sno);
                    cmd.Parameters.AddWithValue("@Sname", student.Sname);
                    cmd.Parameters.AddWithValue("@Ssex", student.Ssex);
                    cmd.Parameters.AddWithValue("@Sage", student.Sage);
                    cmd.Parameters.AddWithValue("@Sdept", student.Sdept);
                    cmd.ExecuteNonQuery();
                    LoadData(); // 刷新 ListView 显示最新数据
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding student: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string sno = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(sno))
            {
                MessageBox.Show("请输入学号");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Sno, Sname, Ssex, Sage, Sdept FROM student WHERE Sno = @Sno";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Sno", sno);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                      foreach (ListViewItem item in showView.Items)
                        {
                           
                                // 选中并确保可见
                                item.Selected = false;
                                //showView.EnsureVisible(item.Index);
                            
                        }

                        // 遍历ListView寻找匹配的学号
                        foreach (ListViewItem item in showView.Items)
                        {
                            if (item.Text == sno) // 假设ListView的第一列是Sno
                            {
                                // 选中并确保可见
                                item.Selected = true;
                                showView.EnsureVisible(item.Index);
                                
                                break;
                            }
                        }

                   
                    }
                    else
                    {
                        MessageBox.Show("不存在该学生，请检查学号是否正确");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据库操作出错: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void showView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class Student
    {
        // 属性
        public string Sno { get; set; }     // 学号
        public string Sname { get; set; }   // 姓名
        public string Ssex { get; set; }    // 性别
        public int Sage { get; set; }       // 年龄
        public string Sdept { get; set; }   // 系别

        // 构造函数
        public Student() { }

        public Student(string sno, string sname, string ssex, int sage, string sdept)
        {
            Sno = sno;
            Sname = sname;
            Ssex = ssex;
            Sage = sage;
            Sdept = sdept;
        }

        // 可以根据需要添加其他方法，比如验证数据的方法等
    }
}
