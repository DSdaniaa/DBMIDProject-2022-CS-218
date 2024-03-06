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
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

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
               // Form moreForm = new Student("customer");
                this.Hide();
               // moreForm.Show();
            }
            else if (checkStudent.Checked == true && checkAdmin.Checked == true)
            {
                MessageBox.Show("SELECT ONE");
                
            }
            checkAdmin.Checked = false;
            checkStudent.Checked = false;
        }
    }
}
