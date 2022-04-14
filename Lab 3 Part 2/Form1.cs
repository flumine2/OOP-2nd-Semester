using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_Part_2
{

    public partial class Form1 : Form
    {
        Action action;
        private bool opacityChanged = false;
        private bool BackgroundChanged = false;
        private bool checkBox1Bool = false;
        private bool checkBox2Bool = false;
        private bool checkBox3Bool = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Transparency_Click(object sender, EventArgs e)
        {
            ChangeOpacity();
        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            ChangeBackgroundColor();
        }

        private void HelloWorld_Click(object sender, EventArgs e)
        {
            ShowHW();
        }

        private void SuperButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я супермегакнопка,\nі цього мене не позбавиш!");
        }

        private void SuperButton_MouseCaptureChanged(object sender, EventArgs e)
        {
            action();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1Bool)
            {
                action -= ChangeOpacity;
                checkBox1Bool = false;
            }
            else
            {
                action += ChangeOpacity;
                checkBox1Bool = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2Bool)
            {
                action -= ChangeBackgroundColor;
                checkBox2Bool = false;
            }
            else
            {
                action += ChangeBackgroundColor;
                checkBox2Bool = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3Bool)
            {
                action -= ShowHW;
                checkBox3Bool = false;
            }
            else
            {
                action += ShowHW;
                checkBox3Bool = true;
            }
        }

        private void ChangeOpacity()
        {
            if (opacityChanged)
            {
                Opacity = 1;
                opacityChanged = false;
            }
            else
            {
                Opacity = 0.5;
                opacityChanged = true;
            }
        }

        private void ChangeBackgroundColor()
        {
            if (BackgroundChanged)
            {
                BackColor = Color.White;
                BackgroundChanged = false;
            }
            else
            {
                BackColor = Color.Black;
                BackgroundChanged = true;
            }
        }

        private void ShowHW()
        {
            MessageBox.Show("Hello World");
        }
    }
}
