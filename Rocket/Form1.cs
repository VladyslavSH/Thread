using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(Fly, pictureBox1);
            ThreadPool.QueueUserWorkItem(Fly, pictureBox2);
            ThreadPool.QueueUserWorkItem(Fly, pictureBox3);
            ThreadPool.QueueUserWorkItem(Fly, pictureBox4);
            ThreadPool.QueueUserWorkItem(Fly, pictureBox5);
        }

        private void Fly(object state)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            int i = 0; ;
            PictureBox pictureBox = state as PictureBox;
            while (true)
            {
                if (pictureBox.Location.Y < Bounds.Y - 90)
                {
                    break;
                }
                    pictureBox.Invoke(new Action(() =>
                    {
                        i = pictureBox.Location.Y - 7;
                        Random rand = new Random();
                        pictureBox.Location = new Point(pictureBox.Location.X, rand.Next(i, pictureBox.Location.Y));
                    }));
                Thread.Sleep(50);
            }
            
        }
    }
}
