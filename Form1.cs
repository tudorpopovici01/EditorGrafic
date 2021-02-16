using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafic
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Bitmap pic1;
        string mode;
        int xclick1, yclick1;
        int x1, y1;
        public Form1()
        {
            mode = "Linie";
            InitializeComponent();
            pic = new Bitmap(1000, 1000);
            pic1 = new Bitmap(1000, 1000);
            x1 = y1 = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            button4.BackColor = b.BackColor;
        }

        private void salveazăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName!="")
            pic.Save(saveFileDialog1.FileName);
        }

        private void deschideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mode = "Linie";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            mode = "Pătrat";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mode = "Oval";
            
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button4.BackColor, trackBar1.Value);
            Graphics g;
            g = Graphics.FromImage(pic);
            if (mode == "Pătrat")
            {
                
                g.DrawRectangle(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
             xclick1 = e.X;
             yclick1 = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button4.BackColor,trackBar1.Value);
              
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            Graphics g;
            g = Graphics.FromImage(pic);
            
            Graphics g1;
            g1 = Graphics.FromImage(pic1);
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(p, x1, y1, e.X, e.Y);



                if (mode == "Linie")
                {
                    g.DrawLine(p, x1, y1, e.X, e.Y);
                }
                if (mode == "Pătrat")
                {
                    g1.Clear(Color.White);
                    g1.DrawRectangle(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
                }
                if (mode == "Oval")
                {
                    g1.Clear(Color.White);
                    g1.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
                }
                g.DrawImage(pic1, 0, 0);

                pictureBox1.Image = pic;
            }
                x1 = e.X;
                y1 = e.Y;
                                 
              
              
        }
    }
}
