using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        Point LocationXY;
        Point LocationX1Y1;
        String filePath= "C:\\Users\\SamSepi0l\\Downloads\\slice1.png";

        List<Rectangle> rectangles = new List<Rectangle>();
        List<String> filePaths = new List<String>();

        bool IsMouseDown = false;
        bool IsMouseUp = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //IsMouseDown = true;
            //IsMouseUp = false;

            //LocationXY = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (IsMouseDown == true)
            //{
            //    LocationX1Y1 = e.Location;

            //    Refresh();
            //}
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (IsMouseDown == true)
            //{
            //    LocationX1Y1 = e.Location;

            //    IsMouseDown = false;

            //    IsMouseUp = true;

            //    rectangles.Add(GetRect());
            //}
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //if (rect != null)
            //{
            //    e.Graphics.DrawRectangle(Pens.Red, GetRect());

            //}

            //if (rectangles.Count > 0)
            //{
            //    foreach (Rectangle r in rectangles)
            //    {
            //        e.Graphics.DrawRectangle(Pens.Red, r);
            //    }
            //}

        }

        private Rectangle GetRect()
        {
            rect = new Rectangle();

            rect.X = Math.Min(LocationXY.X, LocationX1Y1.X);
            rect.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);

            rect.Width = Math.Abs(LocationXY.X - LocationX1Y1.X);

            rect.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);

            return rect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imagelocalization = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagelocalization = dialog.FileName;
                pictureBox1.ImageLocation = imagelocalization;

            }
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            IsMouseUp = false;

            LocationXY = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;

                Refresh();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string roomType = comboBox1.SelectedItem.ToString();
            if (roomType == "Room") filePath= "C:\\Users\\SamSepi0l\\Downloads\\slice1.png";
            if (roomType == "Kitchen") filePath= "C:\\Users\\SamSepi0l\\Downloads\\slice3.png";
            if (roomType == "Toilet") filePath= "C:\\Users\\SamSepi0l\\Downloads\\slice2.png";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;

                IsMouseDown = false;

                IsMouseUp = true;

                rectangles.Add(GetRect());
                filePaths.Add(filePath);
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                Rectangle rect = GetRect();
                e.Graphics.DrawRectangle(Pens.Red, rect);
                e.Graphics.DrawImage(Bitmap.FromFile(filePath), rect);
            }

            if (rectangles.Count > 0)
            {
                int i = 0;
                foreach (Rectangle r in rectangles)
                {
                    
                    e.Graphics.DrawRectangle(Pens.Red, r);
                    e.Graphics.DrawImage(Bitmap.FromFile(filePaths[i]), r);
                    i=i+1; 
                }
            }
        }


    }
}
