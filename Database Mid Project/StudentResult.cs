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
    public partial class StudentResult : Form
    {
        public StudentResult()
        {
            InitializeComponent();
        }

        private void StudentResult_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            var conn = Configuration.getInstance().getConnection();
            SqlCommand cmdd = new SqlCommand("Select * from AssessmentComponent", conn);
            SqlDataAdapter daa = new SqlDataAdapter(cmdd);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView2.DataSource = dtt;
            var connn = Configuration.getInstance().getConnection();
            SqlCommand cmddd = new SqlCommand("Select * from RubricLevel", connn);
            SqlDataAdapter daaa = new SqlDataAdapter(cmddd);
            DataTable dttt = new DataTable();
            daaa.Fill(dttt);
            dataGridView2.DataSource = dttt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into StudentResult values ( @StudenId, @AssessmentComponentId, @RubricMeasurementId,  @GETDATE())", con);
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@RubricMeasurementId", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM StudentResult WHERE StudentId = @StudentId and AssessmentComponentId=@AssessmentComponentId", con);
                cmd.Parameters.AddWithValue("@StudentId", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(textBox3.Text));


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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE StudentResult SET RubricMeasurementId=@RubricMeasurementId, EvaluationDate=GETDATE() WHERE StudentId = @StudentId and AssessmentComponentId=@AssessmentComponentId", con);
                cmd.Parameters.AddWithValue("@StudentId", textBox2.Text);
                cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@RubricMeasurementId", int.Parse(textBox4.Text));
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
                textBox3.Text = "";
                textBox4.Text = "";

            }
            else
            {
                MessageBox.Show("Enter The Id's");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
