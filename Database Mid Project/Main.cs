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
    public partial class Main : Form
    {
        private System.Drawing.Size originalFormSize;
        private Rectangle Original1;
        private Rectangle Original2;
        private Rectangle Original3;
        private Rectangle Original4;

        public Main()
        {
            InitializeComponent();
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
        private void Main_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            Original1 = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            Original2 = new Rectangle(btnNextRole.Location.X, btnNextRole.Location.Y, btnNextRole.Width, btnNextRole.Height);
            Original3 = new Rectangle(checkAdmin.Location.X, checkAdmin.Location.Y, checkAdmin.Width, checkAdmin.Height);
            Original4 = new Rectangle(checkStudent.Location.X, checkStudent.Location.Y, checkStudent.Width, checkStudent.Height);

        }

        private void checkCustomer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNextRole_Click(object sender, EventArgs e)
        {
            if (checkAdmin.Checked == true && checkStudent.Checked == false)
            {
                Form moreForm = new Admin();
                this.Hide();
                moreForm.Show();
            }
            else if (checkStudent.Checked == true && checkAdmin.Checked == false)
            {
               Form moreForm = new Student();
                this.Hide();
               moreForm.Show();
            }
            else if (checkStudent.Checked == true && checkAdmin.Checked == true)
            {
                MessageBox.Show("SELECT ONE");
                
            }
            checkAdmin.Checked = false;
            checkStudent.Checked = false;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            resize(Original1, label1);
            resize(Original2, btnNextRole);
            resize(Original3, checkAdmin);
            resize(Original4, checkStudent);
        }
    }
}
