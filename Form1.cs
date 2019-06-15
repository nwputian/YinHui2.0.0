using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {    //连接数据库
        public SqlConnection uid = new SqlConnection();
        

        public Form1()
        {
            InitializeComponent();
        }
            
        private void button1_Click(object sender, EventArgs e)
        {   //检测是否有效
            uid.ConnectionString = global.constr;
        string a="select * from 用户  where userID='"+textBox1.Text+"' and password='"+textBox2.Text+"'and usertype='用户'";
            SqlCommand cmd = new SqlCommand(a, uid);

            try {
                uid.Open();
                object b = cmd.ExecuteScalar();
                if (b == null)
                {
                    MessageBox.Show("密码或账号输入错误，请检查");
                    
                }
                else
                {
                    global.userID = textBox1.Text;
                    this.Visible = false;
                    Form2 frm = new Form2();
                    frm.ShowDialog();
                   
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { uid.Close();
            }
        }

        internal void showdialog()
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void administraors_Click_1(object sender, EventArgs e)
        {
            uid.ConnectionString = global.constr;
            string a = "select * from 用户  where userID='" + textBox1.Text + "' and password='" + textBox2.Text + "'and usertype='管理员'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                uid.Open();
                object b = cmd.ExecuteScalar();
                if (b == null)
                {
                    MessageBox.Show("密码或账号输入错误，请检查");
                }
                else
                {
                    this.Visible = false;
                    Form5 frm = new Form5();
                    frm.ShowDialog();
                    
                }
                
               // Form5 frm = new Form5();
                //frm.ShowDialog();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }
        }
       
        private void register_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
