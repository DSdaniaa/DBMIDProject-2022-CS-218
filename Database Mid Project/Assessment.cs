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
    public partial class Assessment : Form
    {
        public Assessment()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Assessment values ( @Title, GETDATE(), @TotalMarks, @TotalWeightage)", con);
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            view();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Assessment WHERE Id = @Id", con);
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
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            view();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Assessment SET Title= @Title, TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
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
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            view();
        }

        private void Assessment_Load(object sender, EventArgs e)
        {
            view();
        }
        private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
