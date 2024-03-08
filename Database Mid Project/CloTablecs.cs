using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Mid_Project
{
    public partial class CloTablecs : Form
    {
        public CloTablecs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Clo values ( @Name, GETDATE(), GETDATE())", con);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            //cmd.Parameters.AddWithValue("@DateCreated", int.Parse(textBox1.Text));
           // cmd.Parameters.AddWithValue("@DateUpdated", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            textBox2.Text = "";
            view();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Clo WHERE Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully!");
            }
            else
            {
                MessageBox.Show("Failed to delete record. Make sure the ID exists.");
            }

            textBox2.Text = "";
            view();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Clo SET Name= @UpdatedName, DateUpdated=GETDATE() WHERE Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@UpdatedName", textBox1.Text);
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update record. Make sure the ID exists.");
            }

            textBox2.Text = "";
            textBox1.Text = "";
            view();

        }

        private void CloTablecs_Load(object sender, EventArgs e)
        {
            view();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }
    }
}
