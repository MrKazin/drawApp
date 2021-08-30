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
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        private bool AllowMoveForPaint = false;

        string TypeOfFigure;                                                                     
        private void button1_Click(object sender, EventArgs e)///////////////line
        {
            TypeOfFigure = "Line";
        }         
        private void button2_Click(object sender, EventArgs e)///////////////rectangle
        {
            TypeOfFigure = "Rectangle";
        }   
        private void button3_Click(object sender, EventArgs e)///////////////ellipse
        {
            TypeOfFigure = "Ellipse";
        }      

        Dictionary<String, Figure> MapOfFigures = new Dictionary<string, Figure>();
        Figure FigureToChange;
        string NameOfFigureToChange;
        bool FigureToChangeIsNotEmpty = false;
        /////////////////////////values and flags for line
        int lx1,ly1,lx2,ly2; 
        public bool CreateLineFlag = false;             
        public bool ShowLineFlag = false;
        ////////////////////////values and flags for rectangle
        int rx1,ry1,rwidth,rheight;                               
        public bool CreateRectangleFlag = false;        
        public bool ShowRectangleFlag = false;
        ////////////////////////values and flags for ellipse
        int ex1,ey1,ewidth,eheight;                                 
        public bool CreateEllipseFlag = false;          
        public bool ShowEllipseFlag = false;            

        ////////////////////////Customize for figures
        private int WidthOfPen = 1;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private Color PenColor = Color.Black;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            WidthOfPen = comboBox1.SelectedIndex;
        }                        
        private void button4_Click(object sender, EventArgs e)
        {                                                              
            colorDialog1.ShowDialog();
            PenColor = colorDialog1.Color;                                
        }                                                              

     
        private void panel1_Paint(object sender, PaintEventArgs e)////////////////////////////////////paint figure
        {
            
            switch (TypeOfFigure)
            {
                case "Line":
                    if (CreateLineFlag.Equals(true))
                    {
                        if (ShowLineFlag.Equals(true))
                        {
                            Line figure = new Line(lx1, ly1, lx2, ly2, WidthOfPen, PenColor);
                            figure.Draw(e);
                        }
                        foreach (var figure in MapOfFigures)
                        {
                            Figure value = figure.Value;
                            value.Draw(e);
                        }
                    }
                    break;
                case "Rectangle":
                    if (CreateRectangleFlag.Equals(true))
                    {
                        if (ShowRectangleFlag.Equals(true))
                        {
                            Rectangle rectangle = new Rectangle(rx1, ry1, rwidth, rheight, WidthOfPen, PenColor);
                            rectangle.Draw(e);
                        }
                        foreach (var figure in MapOfFigures)
                        {
                            Figure value = figure.Value;
                            value.Draw(e);
                        }
                    }
                    break;
                case "Ellipse":
                    if (CreateEllipseFlag.Equals(true))
                    {
                        if (ShowEllipseFlag.Equals(true))
                        {
                            Ellipse ellipse = new Ellipse(ex1, ey1, ewidth, eheight, WidthOfPen, PenColor);
                            ellipse.Draw(e);
                        }
                        foreach (var figure in MapOfFigures)
                        {
                            Figure value = figure.Value;
                            value.Draw(e);
                        }
                    }
                    break;
            }
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)////////////////////////////////////mouse down
        {
            
            if (checkBox1.Checked.Equals(false) && checkBox2.Checked.Equals(false))
            {
                switch (TypeOfFigure)
                {
                    case "Line":
                        CreateLineFlag = true;
                        ShowLineFlag = true;
                        lx1 = e.Location.X;
                        ly1 = e.Location.Y;
                        break;
                    case "Rectangle":
                        CreateRectangleFlag = true;
                        ShowRectangleFlag = true;
                        rx1 = e.Location.X;
                        ry1 = e.Location.Y;
                        break;
                    case "Ellipse":
                        CreateEllipseFlag = true;
                        ShowEllipseFlag = true;
                        ex1 = e.Location.X;
                        ey1 = e.Location.Y;
                        break;
                }
            }
            AllowMoveForPaint = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)////////////////////////////////////mouse move
        {
            if (FigureToChangeIsNotEmpty.Equals(true) && checkBox2.Checked.Equals(false) && checkBox1.Checked && NameOfFigureToChange.StartsWith("Line"))//////// moving line
            {
                if(e.X > FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() + 10); FigureToChange.setx1(FigureToChange.getx1() + 10); }
                else if(e.X < FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() - 10); FigureToChange.setx1(FigureToChange.getx1() - 10); }
                else if(e.Y > FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() + 30); FigureToChange.sety1(FigureToChange.gety1() + 30); }
                else if (e.Y < FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() - 30); FigureToChange.sety1(FigureToChange.gety1() - 30); }
            }
            if (FigureToChangeIsNotEmpty.Equals(true) && checkBox1.Checked.Equals(false) && checkBox2.Checked && NameOfFigureToChange.StartsWith("Line"))//////// stretching line
            {
                if (e.X > FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() + 10); }
                else if (e.X < FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() - 10); }
                else if (e.Y > FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() + 30); }
                else if (e.Y < FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() - 30); }
            }
            

            if (FigureToChangeIsNotEmpty.Equals(true) && checkBox2.Checked.Equals(false) && checkBox1.Checked && NameOfFigureToChange.StartsWith("Rectangle"))//////// moving rectangle
            {
                if (e.X > FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setx1(FigureToChange.getx1() + 10); }
                else if (e.X < FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setx1(FigureToChange.getx1() - 10); }
                else if (e.Y > FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.sety1(FigureToChange.gety1() + 40); }
                else if (e.Y < FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.sety1(FigureToChange.gety1() - 40); }
            }
            if (FigureToChangeIsNotEmpty.Equals(true) && checkBox1.Checked.Equals(false) && checkBox2.Checked && NameOfFigureToChange.StartsWith("Rectangle"))//////// stretching rectangle
            {
                if (e.X > FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() + 10); }
                else if (e.X < FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() - 10); }
                else if (e.X > FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() + 20); }
                else if (e.X < FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() - 40); }
            }


            if (FigureToChangeIsNotEmpty.Equals(true) && checkBox2.Checked.Equals(false) && checkBox1.Checked && NameOfFigureToChange.StartsWith("Ellipse"))  //////// moving ellipse
            {
                if (e.X > FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setx1(FigureToChange.getx1() + 10); }
                else if (e.X < FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setx1(FigureToChange.getx1() - 10); }
                else if (e.Y > FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.sety1(FigureToChange.gety1() + 40); }
                else if (e.Y < FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.sety1(FigureToChange.gety1() - 40); }
            }
            if (FigureToChangeIsNotEmpty.Equals(true) && checkBox1.Checked.Equals(false) && checkBox2.Checked && NameOfFigureToChange.StartsWith("Ellipse"))  //////// stretching ellipse
            {
                if (e.X > FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() + 10); }
                else if (e.X < FigureToChange.getx1() + FigureToChange.getwidth()) { FigureToChange.setwidth(FigureToChange.getwidth() - 10); }
                else if (e.X > FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() + 20); }
                else if (e.X < FigureToChange.gety1() + FigureToChange.getheight()) { FigureToChange.setheight(FigureToChange.getheight() - 60); }
            }


            if (AllowMoveForPaint)///////////////move for creating figure
            {
                switch (TypeOfFigure)
                {
                    case "Line":
                        if (CreateLineFlag.Equals(true))
                        {
                            lx2 = e.Location.X;
                            ly2 = e.Location.Y;
                            Invalidate();
                        }
                        CreateLineFlag = true;
                        panel1.Refresh();
                        break;
                    case "Rectangle":
                        if (CreateRectangleFlag.Equals(true))
                        {
                            rwidth = e.Location.X - rx1;
                            rheight = e.Location.Y - ry1;
                            Invalidate();
                        }
                        CreateRectangleFlag = true;
                        panel1.Refresh();
                        break;
                    case "Ellipse":
                        if (CreateEllipseFlag.Equals(true))
                        {
                            ewidth = e.Location.X - ex1;
                            eheight = e.Location.Y - ey1;
                            Invalidate();
                        }
                        CreateEllipseFlag = true;
                        panel1.Refresh();
                        break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)///////searching for chosen figure in MapOfFigures
        {
            NameOfFigureToChange = comboBox2.Text;
            foreach (var current in MapOfFigures)
            { if (current.Key.Equals(NameOfFigureToChange)) { FigureToChange = current.Value; } }
            FigureToChangeIsNotEmpty = true;
        }

        int LineCounter = 1, RectangleCounter = 1, EllipseCounter = 1;

        private void panel1_MouseUp(object sender, MouseEventArgs e)////////////////////////////////////mouse up
        {
            if (FigureToChangeIsNotEmpty.Equals(true))
            {
                FigureToChangeIsNotEmpty = false;
            }
            else if (AllowMoveForPaint)
            {
                switch (TypeOfFigure)
                {
                    case "Line":
                        CreateLineFlag = false;
                        ShowLineFlag = false;

                        Line line_element = new Line(lx1, ly1, lx2, ly2, WidthOfPen, PenColor);
                        string line_element_string = "Line " + LineCounter.ToString();

                        MapOfFigures.Add(line_element_string, line_element);
                        comboBox2.Items.Add(line_element_string);
 
                        LineCounter++;
                        break;
                    case "Rectangle":
                        CreateRectangleFlag = false;
                        ShowRectangleFlag = false;

                        Rectangle rectangle_element = new Rectangle(rx1, ry1, rwidth, rheight, WidthOfPen, PenColor);
                        string rectangle_element_string = "Rectangle" + RectangleCounter.ToString();

                        MapOfFigures.Add(rectangle_element_string, rectangle_element);
                        comboBox2.Items.Add(rectangle_element_string);

                        RectangleCounter++;
                        break;
                    case "Ellipse":
                        CreateEllipseFlag = false;
                        ShowEllipseFlag = false;

                        Ellipse ellipse_element = new Ellipse(ex1, ey1, ewidth, eheight, WidthOfPen, PenColor);
                        string ellipse_element_string = "Ellipse" + EllipseCounter.ToString();

                        MapOfFigures.Add(ellipse_element_string, ellipse_element);    
                        comboBox2.Items.Add(ellipse_element_string);
                        EllipseCounter++;
                        break;
                }
            }
            AllowMoveForPaint = false;
        }
    }
}