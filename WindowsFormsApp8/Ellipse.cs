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
    class Ellipse : Figure
    {
        public int x1;
        public int y1;
        public int width;
        public int height;
        public int WidthOfPen;
        public Color ColorOfPen;

        public Ellipse(int x1, int y1, int width, int height, int WidthOfPen, Color ColorOfPen)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.width = width;
            this.height = height;
            this.WidthOfPen = WidthOfPen;
            this.ColorOfPen = ColorOfPen;
        }

        override
        public void Draw(PaintEventArgs e)
        {
            Pen Pen = new Pen(ColorOfPen, WidthOfPen);
            e.Graphics.DrawEllipse(Pen, x1, y1, width, height);
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
            width = value;
        }
        override
        public void setheight(int value)
        {
            height = value;
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
            return width;
        }
        override
         public int getheight()
        {
            return height;
        }
    }
}