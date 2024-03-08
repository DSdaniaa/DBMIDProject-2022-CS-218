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
            view();
            var conn = Configuration.getInstance().getConnection();
            SqlCommand cmdd = new SqlCommand("Select Name from AssessmentComponent", conn);
            SqlDataAdapter daa = new SqlDataAdapter(cmdd);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView2.DataSource = dtt;
            var connn = Configuration.getInstance().getConnection();
            SqlCommand cmddd = new SqlCommand("Select * from RubricLevel", connn);
            SqlDataAdapter daaa = new SqlDataAdapter(cmddd);
            DataTable dttt = new DataTable();
            daaa.Fill(dttt);
            dataGridView3.DataSource = dttt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {

                var con = Configuration.getInstance().getConnection();

                int StuId, ComId, RubricId;
                SqlCommand cmd = new SqlCommand("Select Id from Student where RegistrationNumber = @RegistrationNumber and Status=@Status ", con);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox2.Text);
                cmd.Parameters.AddWithValue("@Status", 5);
                object result = cmd.ExecuteScalar();
                SqlCommand cmdd = new SqlCommand("Select Id from AssessmentComponent where Name= @Name", con);
                cmdd.Parameters.AddWithValue("@Name", textBox3.Text);
                object resultt = cmdd.ExecuteScalar();
                SqlCommand cmmd = new SqlCommand("Select Id from RubricLevel where MeasurementLevel= @MeasurementLevel", con);
                cmmd.Parameters.AddWithValue("@MeasurementLevel", textBox4.Text);
                object resulttt = cmmd.ExecuteScalar();
                if (result != null && resultt != null && resulttt != null)
                {
                    StuId = int.Parse(result.ToString());
                    ComId = int.Parse(resultt.ToString());
                    RubricId = int.Parse(resulttt.ToString());
                    SqlCommand cm = new SqlCommand("Insert into StudentResult values ( @StudentId, @AssessmentComponentId, @RubricMeasurementId,  GETDATE())", con);
                    cm.Parameters.AddWithValue("@StudentId", StuId);
                    cm.Parameters.AddWithValue("@AssessmentComponentId", ComId);
                    cm.Parameters.AddWithValue("@RubricMeasurementId", RubricId);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                }
                else
                {
                    MessageBox.Show("No Record Exists");
                }
            }
            else
            {
                MessageBox.Show("Enter The Required Information");
            }

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            view();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                int StuId, ComId;
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select Id from Student where RegistrationNumber = @RegistrationNumber and Status=@Status ", con);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox2.Text);
                cmd.Parameters.AddWithValue("@Status", 5);
                object result = cmd.ExecuteScalar();
                SqlCommand cmdd = new SqlCommand("Select Id from AssessmentComponent where Name= @Name", con);
                cmdd.Parameters.AddWithValue("@Name", textBox3.Text);
                object resultt = cmdd.ExecuteScalar();
               
                if (result != null && resultt != null )
                {
                    StuId = int.Parse(result.ToString());
                    ComId = int.Parse(resultt.ToString());


                    SqlCommand ccmd = new SqlCommand("DELETE FROM StudentResult WHERE StudentId = @StudentId and AssessmentComponentId=@AssessmentComponentId", con);
                    ccmd.Parameters.AddWithValue("@StudentId", StuId);
                    ccmd.Parameters.AddWithValue("@AssessmentComponentId", ComId);
                    int rowsAffected = ccmd.ExecuteNonQuery();

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
                    MessageBox.Show("No Record Exists");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
               
            }
            else
            {
                MessageBox.Show("Enter The Required Information");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }

            view();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                int StuId, ComId,RubricId;
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select Id from Student where RegistrationNumber = @RegistrationNumber and Status=@Status ", con);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox2.Text);
                cmd.Parameters.AddWithValue("@Status", 5);
                object result = cmd.ExecuteScalar();
                SqlCommand cmdd = new SqlCommand("Select Id from AssessmentComponent where Name= @Name", con);
                cmdd.Parameters.AddWithValue("@Name", textBox3.Text);
                object resultt = cmdd.ExecuteScalar();
                SqlCommand cmmd = new SqlCommand("Select Id from RubricLevel where MeasurementLevel= @MeasurementLevel", con);
                cmmd.Parameters.AddWithValue("@MeasurementLevel", textBox4.Text);
                object resulttt = cmmd.ExecuteScalar();
                if (result != null && resultt != null && resulttt != null)
                {
                    StuId = int.Parse(result.ToString());
                    ComId = int.Parse(resultt.ToString());
                    RubricId = int.Parse(resulttt.ToString());

                    SqlCommand ccmd = new SqlCommand("UPDATE StudentResult SET RubricMeasurementId=@RubricMeasurementId, EvaluationDate=GETDATE() WHERE StudentId = @StudentId and AssessmentComponentId=@AssessmentComponentId", con);
                    ccmd.Parameters.AddWithValue("@StudentId", StuId);
                    ccmd.Parameters.AddWithValue("@AssessmentComponentId", ComId);
                    ccmd.Parameters.AddWithValue("@RubricMeasurementId", RubricId);
                    int rowsAffected = ccmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update record. Make sure the ID exists.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("No Record Exists");
                   
                }

            }
            else
            {
                MessageBox.Show("Enter The Required Information");
                
            }
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            view();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from StudentResult", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }
    }
}
