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
    public partial class name : Form
    {
        public SqlConnection uid = new SqlConnection(@"");
        Form2 f2 = new Form2();
        int[][] u=new int[11][];
        int[][] v = new int[11][];

        string movie_name;
        private int f;

        public name()
        {
            InitializeComponent();
        }
        //座位设计
        private void InitSeats(int seatRow, int seatLine, TabPage tb)
        {
            Label label;
            Seat seat;
            global.key = new int[10][];
            for (int i = 1; i <= seatRow; i++)
            {
                for (int j = 1; j <= seatLine; j++)
                {   
                    
                    label = new Label();
                    label.BackColor = Color.Yellow;
                    label.AutoSize = false;
                    label.Location = new Point(1, 1);
                    label.Name = "lbl" + (j).ToString() + "_" + (i).ToString();
                    label.Size = new Size(40, 23);
                    label.Text = (j).ToString() + "-" + (i).ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Location = new Point(30 + (i * 64), 30 + (j * 30));
                    label.Click += new EventHandler(Seat_Click);
                    label.Enabled = false;
                    tb.Controls.Add(label);
                    seat = new Seat(i, j, (j).ToString() + "-" + (i).ToString(), Color.Yellow);
                }
            }
        }
            
    
         
        private void Seat_Click(object sender, EventArgs e)
        {
            

            string seatNum = ((Label)sender).Text.ToString();
            
            if (((Label)sender).BackColor==Color.Red)
            {
                ((Label)sender).BackColor = Color.Yellow;
                 f--;
            }
            else
            {
                ((Label)sender).BackColor = Color.Red;
                 f++;

            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            movie_name = global.movie_name;       
            f = global.f;
            f = 0;
            textBox5.Text = (movie_name);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            InitSeats(9, 10, tabPage1);
            textBox1.Text = "\r\n\r\n  过\r\n\r\n\r\n\r\n\r\n  道";
            uid.ConnectionString = global.constr;
            string a = "select 上映日期,票价 from 电影信息  where 电影信息.电影名称='"+movie_name+ "'";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                    textBox2.Text=dr[0].ToString();
                   textBox4.Text = dr[1].ToString();
                dr.Close();
            }
            
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }
            DateTime dt = DateTime.Now;
            uid.ConnectionString = global.constr;
            string b = "select 放映厅,场次 from 排片信息 where 电影名称='"+movie_name+"' and 放映日期='"+dt+"'";
            SqlCommand cmd1 = new SqlCommand(b, uid);
            try
            {
                uid.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();

               while (dr1.Read())
                {   
                    comboBox2.Items.Add(dr1[0].ToString());
                    comboBox1.Items.Add(dr1[1].ToString());
                } 
                dr1.Close();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            int ff = 0;
            int fff = 0;
            string str = "否";
            Random ro = new Random();
            int[] iResult = new int[100];
            int iUp = 999999;
            int iDown = 100000;
            for (int i = 1; i <= f; i++)
            {
                iResult[i] = ro.Next(iDown, iUp);

            }
            uid.ConnectionString = global.constr;
            string a = "update 排片信息 set 剩余票数=剩余票数-" + f.ToString() + " where 电影名称='" + movie_name + "' and 放映厅='" + comboBox2.Text + "' and 场次='" + comboBox1.Text + "'";
            SqlCommand cmd1 = new SqlCommand(a, uid);
            try
            {
                uid.Open();
                if (f == 0)
                {
                    MessageBox.Show("还没买票！");
                }
                else
                {
                    cmd1.ExecuteNonQuery();

                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }


            for (int i = 0; i < 11; i++)
            {
                v[i] = new int[11];
            }
            for (int i = 0; i < tabPage1.Controls.Count; i++)
            {
                if (tabPage1.Controls[i].BackColor == Color.Red)
                {
                    string b = tabPage1.Controls[i].Text.Substring(0, 1);
                    string c = tabPage1.Controls[i].Text.Substring(2, 1);
                    tabPage1.Controls[i].Enabled = false;
                    int bb = int.Parse(b);
                    int cc = int.Parse(c);
                    v[bb][cc] = 1;
                }

            }
            if (f != 0)
            {
                this.Visible = true;
                Form f8 = new Form8();
                f8.ShowDialog();
                
                DateTime dt = DateTime.Today;
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (u[i][j] != v[i][j])
                        {
                            ff++;
                            string b = "insert into 购票座位号 values('" + textBox5.Text + "','" + comboBox2.Text + "', '" + comboBox1.Text + "', '" + dt + "', '" + (i).ToString() + "', '" + (j).ToString() + "','" + (iResult[ff]).ToString() + "') ";
                            SqlCommand cmd = new SqlCommand(b, uid);
                            try
                            {
                                uid.Open();
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    flag = 1;
                                    MessageBox.Show("  第" + (ff).ToString() + " 张票\r\n  取票密码：" + (iResult[ff]).ToString() + "\r\n   放 映 厅 ：" + comboBox2.Text + "\r\n  场       次：" + comboBox1.Text);
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                            finally
                            {
                                uid.Close();
                            }

                        }
                    }
                }



                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (u[i][j] != v[i][j])
                        {
                            fff++;
                            string c = "insert into 订单 values('" + iResult[fff].ToString() + "','" + global.userID + "','"+str+"') ";
                            SqlCommand cmd2 = new SqlCommand(c, uid);
                            try
                            {
                                uid.Open();
                                if (cmd2.ExecuteNonQuery() > 0)
                                {                              
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                            finally
                            {
                                uid.Close();
                            }

                        }
                    }
                }
                button1.Enabled = false;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label5_Click(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox1.Enabled = false;
            textBox1.AcceptsTab = true;
            textBox1.BackColor = Color.Yellow;
            textBox1.Font = new Font(textBox1.Font.FontFamily, 20, textBox1.Font.Style);
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tabPage1.Controls.Count; i++)
            {
                tabPage1.Controls[i].Enabled = true;
            }

           
            SqlConnection uid = new SqlConnection();
            uid.ConnectionString = global.constr;
            for (int i=0;i<11;i++)
            {
                u[i] = new int[11];

            }
            DateTime dt = DateTime.Now;
            string a = "select 座位号行,座位号列 from 购票座位号 where 电影名称='"+movie_name+"'and 放映厅='" + comboBox2.Text + "' and 场次='" + comboBox1.Text + "' and 放映日期='"+dt+"' ";
            SqlCommand cmd = new SqlCommand(a, uid);
            try
            {
                uid.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    for (int h = 0; h <11; h++)
                    {
                        for (int l = 0; l < 11; l++)
                        {
                            if (dr[0].ToString() == (h).ToString() && dr[1].ToString() == (l).ToString())
                            {
                                u[h][l] = 1;
                            }
                           
                        }
                    }                   
                    for (int i = 0; i < tabPage1.Controls.Count; i++)
                    {

                        if (tabPage1.Controls[i].Text == dr[0].ToString() + "-" + dr[1].ToString())
                        {
                            tabPage1.Controls[i].BackColor = Color.Red;
                            tabPage1.Controls[i].Enabled = false;
                        }
                    }    
                }
                switch(comboBox1.Text)
                {
                    case  "1": textBox3.Text = "8:00";break;
                    case  "2": textBox3.Text = "11;00";break;
                    case  "3": textBox3.Text = "15;00";break;
                    case  "4": textBox3.Text = "19;00";break;
                }




                dr.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                uid.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form f2 = new Form2();
            f2.Visible = true;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            f2.Visible = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
