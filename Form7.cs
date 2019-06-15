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
    public partial class Form7 : Form
    {
        public SqlConnection uid = new SqlConnection(@"");
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string str = "否";
            uid.ConnectionString = global.constr;

            string a = "select 是否验票 from 订单 where 取票密码='" + textBox1.Text+ "'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    flag = 1;

                    if(dr[0].ToString().CompareTo(str)==0)
                    {

                        MessageBox.Show("验票成功！");
                    }
                    else
                    {
                        MessageBox.Show("验票成功！");
                    }

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {   
                uid.Close();
            }

            if(flag==1)
            {
                uid.ConnectionString = global.constr;

                string b = "update 订单 set  是否验票='是' where 取票密码='" + textBox1.Text + "'";
                SqlCommand cmd1 = new SqlCommand(b, uid);
                try
                {
                    uid.Open();
                    cmd1.ExecuteNonQuery();
 
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    uid.Close();
                }
            }
            else
            {

                MessageBox.Show("非有效取票密码！");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
