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
    class Figure
    {
        public virtual void Draw(PaintEventArgs e) { }
        public virtual void setx1(int value) { }
        public virtual void sety1(int value) { }
        public virtual void setwidth(int value) { }
        public virtual void setheight(int value) { }

        public virtual int getx1() { return 0; }
        public virtual int gety1() { return 0; }
        public virtual int getwidth() { return 0; }
        public virtual int getheight() { return 0; }
    }
}
