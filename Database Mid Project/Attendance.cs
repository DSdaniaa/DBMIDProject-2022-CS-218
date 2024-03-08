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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
            comboBox1.Items.Add("Present");
            comboBox1.Items.Add("Absent");
            comboBox1.Items.Add("Leave");
            comboBox1.Items.Add("Late");

        }


        private void Attendance_Load(object sender, EventArgs e)
        {
           
        }
        private void DisplayNextRecord()
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNextRole_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedItem != null && textBox1.Text != "")
            {
                int DateID;
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmmmd = new SqlCommand("Select  Id from ClassAttendance where AttendanceDate = GETDATE()", con);
                object resultt = cmmmd.ExecuteScalar();
                if (resultt == null)
                {
                    SqlCommand cmddd = new SqlCommand("Insert into ClassAttendance values (GETDATE() )", con);
                    cmddd.ExecuteNonQuery();
                    SqlCommand cmmd = new SqlCommand("Select  Id from ClassAttendance where AttendanceDate = GETDATE()", con);
                    object resulttt = cmmd.ExecuteScalar();
                    DateID = Convert.ToInt32(resulttt);
                }
                else
                {
                    DateID = Convert.ToInt32(resultt);

                }
                int combo;
                
                if (comboBox1.SelectedItem.ToString()== "Present")
                {
                    combo = 1;
                }
                else if (comboBox1.SelectedItem.ToString() == "Absent")
                {
                    combo = 2;
                }
                else if (comboBox1.SelectedItem.ToString() == "Leave")
                {
                    combo = 3;
                }
                else
                {
                    combo = 4;
                }
                int attributeValue;
                SqlCommand cmd = new SqlCommand("Select Id from Student where RegistrationNumber = @RegistrationNumber and Status=@Status ", con);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox1.Text);
                cmd.Parameters.AddWithValue("@Status",5);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    attributeValue = int.Parse(result.ToString());



                    //var con = Configuration.getInstance().getConnection();
                    SqlCommand cmdd = new SqlCommand("Insert into StudentAttendance values (@DateId,@attributeValue, @combo )", con);
                    cmdd.Parameters.AddWithValue("@DateId", DateID);
                    cmdd.Parameters.AddWithValue("@attributeValue", attributeValue);
                    cmdd.Parameters.AddWithValue("@combo", combo);
                    cmdd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                    
                }
                else
                {
                    MessageBox.Show("No Record Exists");
                }

            }
            else 
            {
                MessageBox.Show("Enter all the required data");
            }

            textBox1.Text = "";
            comboBox1.SelectedItem = null;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }
    }
}
