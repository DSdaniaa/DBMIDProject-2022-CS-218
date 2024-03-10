using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Mid_Project
{
    public partial class Admin : Form
    {
        private System.Drawing.Size originalFormSize;
        private Rectangle Original1;
        private Rectangle Original2;
        private Rectangle Original3;
        private Rectangle Original4;
        private Rectangle Original5;
        private Rectangle Original6;
        private Rectangle Original7;
        private Rectangle Original8;
        private Rectangle Original9;
        private Rectangle Original10;
        private Rectangle Original11;


        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Form1();
            this.Hide();
            moreForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form moreForm = new CloTablecs();
            this.Hide();
            moreForm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form moreForm = new Assessment();
            this.Hide();
            moreForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form moreForm = new Rubric();
            this.Hide();
            moreForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form moreForm = new RubricLevel();
            this.Hide();
            moreForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form moreForm = new StudentResult();
            this.Hide();
            moreForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form moreForm = new Attendance();
            this.Hide();
            moreForm.Show();
        }
        private void resize(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Size.Width * xRatio);
            int newHeight = (int)(r.Size.Height * yRatio);
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Form moreForm = new Main();
            this.Hide();
            moreForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form moreForm = new AssessmentComponent();
            this.Hide();
            moreForm.Show();
        }

        private void Admin_Resize(object sender, EventArgs e)
        {
            resize(Original1, label1);
            resize(Original2, button1);
            resize(Original3, button2);
            resize(Original4, button3);
            resize(Original5, button4);
            resize(Original6, button5);
            resize(Original7, button6);
            resize(Original8, button7);
            resize(Original9, button8);
            resize(Original10, button9);
            resize(Original11, button10);

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            Original1 = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            Original2 = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            Original3 = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            Original4 = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);
            Original5 = new Rectangle(button4.Location.X, button4.Location.Y, button4.Width, button4.Height);
            Original6 = new Rectangle(button5.Location.X, button5.Location.Y, button5.Width, button5.Height);
            Original7 = new Rectangle(button6.Location.X, button6.Location.Y, button6.Width, button6.Height);
            Original8 = new Rectangle(button7.Location.X, button7.Location.Y, button7.Width, button7.Height);
            Original9 = new Rectangle(button8.Location.X, button8.Location.Y, button8.Width, button8.Height);
            Original10 = new Rectangle(button9.Location.X, button9.Location.Y, button9.Width, button9.Height);
            Original11 = new Rectangle(button10.Location.X, button10.Location.Y, button10.Width, button10.Height);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form moreForm = new Student();
            this.Hide();
            moreForm.Show();
        }
    }
}
