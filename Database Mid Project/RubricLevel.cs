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
    public partial class RubricLevel : Form
    {
        public RubricLevel()
        {
            InitializeComponent();
        }

        private void RubricLevel_Load(object sender, EventArgs e)
        {
            view();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into RubricLevel values ( @RubricId, @Details, @MeasurementLevel)", con);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Details", textBox3.Text);
            cmd.Parameters.AddWithValue("@MeasurmentLevel", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            view();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE RubricLevel SET RubricId=@RubricId, Details= @Details, MeasurementLevel=@MeasurementLevel WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@RubricId", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Details", textBox3.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", int.Parse(textBox4.Text));
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update record. Make sure the ID exists.");
                }

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Enter The Id");
            }
            view();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM RubricLevel WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to delete record. Make sure the ID exists.");
                }

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Enter The Id");
            }
            view();
        }
         private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from RubricLevel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
