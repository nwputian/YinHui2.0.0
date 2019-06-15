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
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        private void selectbutton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            //查询电影
            SqlConnection uid = new SqlConnection();
            uid.ConnectionString = global.constr;
            string a = "select * from 电影信息 where 电影名称 like '%" + select.Text + "%'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                this.listView1.Items.Clear();
                uid.Open();
                SqlDataReader b = cmd.ExecuteReader();
                if (!b.Read())
                {
                   MessageBox.Show("无此影片");
                 }
                else
                { 
                    do
                    {
                        button1.Enabled = true;
                        ListViewItem first = new ListViewItem(b[1].ToString());
                        global.movie_name = b[1].ToString();
                        for (int i = 2; i < b.FieldCount; i++)
                        {
                            if (i == 7)
                            {
                                richTextBox1.Text = (b[7].ToString());
                            }
                            else
                            {
                                first.SubItems.Add(b[i].ToString());
                            }

                        }   
                        this.listView1.Items.Add(first);
                      
                    }
                    while (b.Read());
                    
                    b.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { uid.Close(); }
            //查询结果
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("电影名称", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("地区", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("类别", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("语言", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("主演", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("导演", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("时长", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("上映日期", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("票价", 60, HorizontalAlignment.Left);
            DateTime dt = DateTime.Now;
            button1.Enabled = false;
            SqlConnection uid = new SqlConnection();
            uid.ConnectionString = global.constr;
            string a = "select * from 电影信息  ";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                this.listView1.Items.Clear();
                uid.Open();
                SqlDataReader b = cmd.ExecuteReader();
                while (b.Read())

                {
                    
                    ListViewItem first = new ListViewItem(b[1].ToString());
                    global.movie_name = b[1].ToString();
                    DateTime dt1 = Convert.ToDateTime(b[9].ToString());
                    if (DateTime.Compare(dt, dt1) >= 0)
                    {
                        for (int i = 2; i < b.FieldCount; i++)
                        {
                            if (i == 7)
                            {
                                richTextBox1.Text = (b[7].ToString());
                            }
                            else
                            {
                                first.SubItems.Add(b[i].ToString());
                            }

                        }                
                        this.listView1.Items.Add(first);
            
                    }
                }
                        b.Close();                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { uid.Close(); }

        }

        public void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void select_TextChanged_1(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            SqlConnection uid = new SqlConnection();
            uid.ConnectionString = global.constr;
            string a = "select 电影名称 from 电影信息 where 电影名称 like '%"+select.Text+"%'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                listBox1.Items.Clear();
                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        listBox1.Items.Add(dr[i].ToString());
                    }

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void select_Leave(object sender, EventArgs e)
        {
            if (!listBox1.Focused) listBox1.Visible = false;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            select.Text = listBox1.Text;
        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            listBox1.Visible = false;
        }

        private void listBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            name f3 = new name();
            f3.ShowDialog();
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
