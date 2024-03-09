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
    public partial class Rubric : Form
    {
      
        public Rubric()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Rubric_Load(object sender, EventArgs e)
        {
            view();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == ""|| textBox3.Text == "" || textBox4.Text == "") 
            {
                MessageBox.Show("Enter Required Records");
            }
            else
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Rubric values (@Id,@Details, @CloId)", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@CloId", int.Parse(textBox3.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                
            }
            view();
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Rubric SET Details= @Details, CloId=@CloId WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@CloId", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox4.Text));
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update record. Make sure the ID exists.");
                }
                textBox4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Enter The Id");
            }
            view();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Rubric WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox4.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to delete record. Make sure the ID exists.");
                }
                textBox4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Enter The Id");
            }
            view();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }
        private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }

        private void Rubric_Resize(object sender, EventArgs e)
        {

        }
    }
}
