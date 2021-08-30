using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    class Line : Figure
    {
        public int x1,y1,x2,y2;

        public int thickness_line;
        public Color color_line;
        public Line(int x1, int y1, int x2, int y2, int thickness_line, Color color_line)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.thickness_line = thickness_line;
            this.color_line = color_line;
        }

        override
        public void Draw(PaintEventArgs e)
        {
            Pen Pen = new Pen(color_line, thickness_line);
            e.Graphics.DrawLine(Pen, x1, y1, x2, y2);
        }
        
        override
        public void setx1(int value)
        {
            x1 = value;
        }
        override
        public void sety1(int value)
        {
            y1 = value;
        }
        override
        public void setwidth(int value)
        {
            x2 = value;
        }
        override
        public void setheight(int value)
        {
            y2 = value;
        }


        override
        public int getx1()
        {
            return x1;
        }
        override
        public int gety1()
        {
            return y1;
        }
        override
        public int getwidth()
        {
            return x2;
        }
        override
        public int getheight()
        {
            return y2;
        }
    }
}