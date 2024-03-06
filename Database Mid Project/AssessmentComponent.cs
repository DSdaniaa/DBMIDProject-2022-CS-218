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
    public partial class AssessmentComponent : Form
    {
        public AssessmentComponent()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AssessmentComponent_Load(object sender, EventArgs e)
        {
            view();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            var conn = Configuration.getInstance().getConnection();
            SqlCommand cmdd = new SqlCommand("Select * from Assessment", conn);
            SqlDataAdapter daa = new SqlDataAdapter(cmdd);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView2.DataSource = dtt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into AssessmentComponent values ( @Name, @RubricId, @TotalMarks,  @GETDATE(), @GETDATE(), @AssessmentId)", con);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(textBox5.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM AssessmentComponent WHERE Id = @Id", con);
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
                textBox5.Text = "";

            }
            else
            {
                MessageBox.Show("Enter The Id");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            view();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE AssessmentComponent SET Name= @Name, RubricId=@RubricId, TotalMarks=@TotalMarks,DateUpdated=GETDATE(), AssessmentId=@AssessmentId WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@RubricId", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(textBox5.Text));
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
                textBox5.Text = "";

            }
            else
            {
                MessageBox.Show("Enter The Id");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            view();
        }
        private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
