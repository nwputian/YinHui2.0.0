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
    public partial class Form3 : Form
    {

        public SqlConnection uid = new SqlConnection();
        public Form3()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int f = 0;
            uid.ConnectionString = global.constr;
            string a = "select userID,password from 用户 where usertype='用户'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {   

                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    if(dr[0].ToString()==textBox2.Text||dr[1].ToString()==textBox3.Text)
                    {
                        f = 1;
                    }
                }
                dr.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }
           
            if (f == 0)
            {
                uid.ConnectionString = global.constr;
                string b = "insert into 用户 values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','用户','"+textBox4.Text+"')";
                SqlCommand cmd1= new SqlCommand(b, uid);
                try
                {
                    uid.Open();
                    if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||string.IsNullOrWhiteSpace(textBox3.Text)|| string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show("不能为空值！");
                    }
                    else
                    {
                       
                        if (cmd1.ExecuteNonQuery() >= 0)
                        {
                            MessageBox.Show("注册成功！");
                            this.Visible = false;

                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    uid.Close();
                }
            }
            else
            {
                MessageBox.Show("账号或密码已存在，请重新输入！");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
