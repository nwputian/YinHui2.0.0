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
    public partial class Form5 : Form
    {
        public SqlConnection uid = new SqlConnection(@"");
        private string no;
        private int No;
        private string movie;

        public Form5()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

          
             int fangyingting= (int)comboBox2.SelectedItem;
        
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
          string a= monthCalendar1.SelectionStart.ToString("yyyyMMdd");
           string b=DateTime.Now.ToString("yyyyMMdd");
            if(string.Compare(a,b)<=0)
            {
                MessageBox.Show("请选择本日之后的日期");
            }

               
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 3; i++)
            {
                comboBox2.Items.Add(i + 1);
            }
            for (int i = 0; i < 4; i++)
            {
                comboBox3.Items.Add(i + 1);
            }
            for (int i = 0; i < 12; i++)
            {
                comboBox4.Items.Add(i + 1);
            }

            //删除button
            button5.Enabled = false;
            //查所有电影名称
            select();
            
          
        }

        public void  select ()
        {
            uid.ConnectionString = global.constr;
            string a = "select 电影名称 from 电影信息";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                comboBox6.Items.Clear();
                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        comboBox6.Items.Add(dr[i].ToString());
                    }

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
             int changci=(int)comboBox3.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {

           string time = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            DateTime dt = DateTime.Now;

            uid.ConnectionString = global.constr;

            string a = "insert into 排片信息 values('"+movie+"','" + comboBox2.Text + "','"+time+"','" + comboBox3.Text + "','90')";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                if (comboBox2.Text.Trim() == String.Empty || comboBox3.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("不能有空值！");
                }
                else
                {
                    uid.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("添加成功");

                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
                select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uid.ConnectionString = global.constr;
            try
            {
              if(textBox1.Text.Trim() == String.Empty|| textBox2.Text.Trim() == String.Empty|| textBox3.Text.Trim() == String.Empty|| textBox5.Text.Trim() == String.Empty|| textBox6.Text.Trim() == String.Empty|| textBox7.Text.Trim() == String.Empty|| textBox8.Text.Trim() == String.Empty|| comboBox1.SelectedItem == null || comboBox4.SelectedItem == null || comboBox5.SelectedItem == null || richTextBox1.Text==null)
                {
                    MessageBox.Show("基本属性不能为空，请再次输入");
                }
             else
                {   
                    //查询电影数目
                    uid.Open();
                    string f = "select count(*) from 电影信息 ";
                    SqlCommand cm = new SqlCommand(f, uid);
                    SqlDataReader dr = cm.ExecuteReader();
                    dr.Read();
                    no = dr[0].ToString();
                    uid.Close();
                    //插入数据

                    string dt;
                        dt=comboBox1.Text+"-"+comboBox4.Text+"-"+comboBox5.Text;
                    DateTime dt1;
                    dt1 = Convert.ToDateTime(dt);

                    uid.Open();
                    No = int.Parse(no) + 1;
                    string a = "insert into 电影信息 values('"+ No +"','"+ textBox1.Text +"','"+ textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+richTextBox1.Text+"','"+textBox8.Text+ "','"+dt1+"','" + textBox7.Text+"')";
                    SqlCommand cmd = new SqlCommand(a, uid);
                    if (cmd.ExecuteNonQuery()>0)
                    {
                        MessageBox.Show("添加成功");
                        movie = textBox1.Text;
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        richTextBox1.Clear();
                        panel1.Enabled = true;
                        panel2.Visible = false;
                        panel1.Visible = true;
                        panel3.Visible = false;
                    }
       
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
                select();
            }
          
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int x = (int)comboBox4.SelectedItem;
            int[] y = new int[13] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            comboBox5.Items.Clear();
            for (int i = 0; i < y[x]; i++)
            {
                comboBox5.Items.Add(i + 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
      
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            uid.ConnectionString = global.constr;
            int flag = 0;
            string a = "select 电影名称,地区,语言,时长,上映日期 from 电影信息 where 电影名称='"+comboBox6.Text+"'";
            SqlCommand cmd = new SqlCommand(a, uid);           
            try
            {
                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    flag = 1;
                    textBox10.Text = dr[0].ToString();
                    textBox11.Text = dr[1].ToString();
                    textBox14.Text = dr[2].ToString();
                    textBox13.Text = dr[3].ToString();
                    textBox12.Text = dr[4].ToString();
                }
                if(flag==0)
                {
                    MessageBox.Show("数据库中没有这个电影！请重新输入");
                }
                else
                {
                    button5.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }

            string b = "select 电影名称,放映厅,放映日期,场次,剩余票数 from 排片信息 where 电影名称='" + comboBox6.Text + "'";
            SqlCommand cmd1 = new SqlCommand(b, uid);
            try
            {
                uid.Open();
                SqlDataReader drr= cmd1.ExecuteReader();
                int coo = 0;
                while (drr.Read())
                {
   
                    listView1.Items.Add(drr[0].ToString());
                    listView1.Items[coo].SubItems.Add(drr[1].ToString());
                    listView1.Items[coo].SubItems.Add(drr[2].ToString());
                    listView1.Items[coo].SubItems.Add(drr[3].ToString());
                    listView1.Items[coo].SubItems.Add(drr[4].ToString());

                    coo++;
    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void button5_Click(object sender, EventArgs e)
        {
            uid.ConnectionString = global.constr;
            string a = "delete  from 电影信息 where 电影名称='"+comboBox6.Text+"'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                uid.Open();
                if(cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("删除成功！");                 
                    listView1.Items.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                }
               

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
                select();
            }
            button5.Enabled = false;


        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uid.ConnectionString = global.constr;
            string a = "select 电影名称 from 电影信息";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                comboBox7.Items.Clear();
                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        comboBox7.Items.Add(dr[i].ToString());
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string time = monthCalendar2.SelectionStart.ToString("yyyy-MM-dd");

            uid.ConnectionString = global.constr;

            string a = "insert into 排片信息 values('" +comboBox7.Text+ "','" + comboBox8.Text + "','" + time + "','" + comboBox9.Text + "','90')";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {

                if (comboBox7.SelectedItem == null || comboBox8.SelectedItem == null || comboBox9.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("不能有空值！");
                }
                else
                {
                    uid.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("添加成功");

                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();             
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }
      

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.ShowDialog();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
