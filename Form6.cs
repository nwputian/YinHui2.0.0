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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection uid = new SqlConnection();
            uid.ConnectionString = global.constr;
            string a = "delete from 购票座位号  where 取票密码='"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                uid.Open();
                if(cmd.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("退票成功");
     
                }
                else
                {
                    MessageBox.Show("取票密码输入错误！请重新输入");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }
            

            string b = "select 电影名称,放映厅,场次,放映日期,座位号行,座位号列,订单.取票密码 from 订单,购票座位号 where 订单.userID='" + global.userID + "' and 订单.取票密码=购票座位号.取票密码";
            SqlCommand cmd1 = new SqlCommand(b, uid);
            try
            {
                this.listView1.Items.Clear();
                uid.Open();
                SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                   
                    ListViewItem first = new ListViewItem(dr[0].ToString());
                    first.SubItems.Add(dr[1].ToString());
                    first.SubItems.Add(dr[2].ToString());
                    first.SubItems.Add(dr[3].ToString());
                    first.SubItems.Add(dr[4].ToString() + "-" + dr[5].ToString());
                    first.SubItems.Add(dr[6].ToString());

                    this.listView1.Items.Add(first);
                }

                dr.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { uid.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void Form6_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("电影名称", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("放映厅", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("场次", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("放映日期",120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("座位号", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("取票密码", 120, HorizontalAlignment.Left);
            SqlConnection uid = new SqlConnection();
            uid.ConnectionString = global.constr;
            string a = "select 电影名称,放映厅,场次,放映日期,座位号行,座位号列,订单.取票密码 from 订单,购票座位号 where 订单.userID='" + global.userID + "' and 订单.取票密码=购票座位号.取票密码";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {             
                this.listView1.Items.Clear();
                uid.Open();
                SqlDataReader b = cmd.ExecuteReader();
                while (b.Read())
                {
                    ListViewItem first = new ListViewItem(b[0].ToString());
                    first.SubItems.Add(b[1].ToString());
                    first.SubItems.Add(b[2].ToString());
                    first.SubItems.Add(b[3].ToString());
                    first.SubItems.Add(b[4].ToString() + "-" + b[5].ToString());
                    first.SubItems.Add(b[6].ToString());

                    this.listView1.Items.Add(first);
                }

                b.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { uid.Close(); }
        }
    }
    
}
