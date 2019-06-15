using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Seat
    {
        public Seat(int i,int j, string seatNum, Color color)
        {
            this.i = i;
            this.j = j;
            this.SeatNum = seatNum;
            this.Color = color;
        }
        private Color color;
        public Color Color {
            get { return color; }
            set { color = value; }
        }
        private string seatNum;
        public int i;
        public int j;

        public string SeatNum {
            get { return seatNum; }
            set { seatNum = value; }

        }
    }
}
