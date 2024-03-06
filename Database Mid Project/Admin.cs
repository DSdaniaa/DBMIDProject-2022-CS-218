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
    }
}
