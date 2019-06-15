using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
   

    public class global
    {
        public static  string movie_name;
        public static  int[][] key;
        public static int f;
        public static string userID;
        public static string constr = "Server =LAPTOP-LZ\\SQLEXPRESS;database=电影购票管理系统;integrated security = true";
    }
    static class Program
    {
        


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
        Application.Run(new Form1());
          
            
        }
    }
}
