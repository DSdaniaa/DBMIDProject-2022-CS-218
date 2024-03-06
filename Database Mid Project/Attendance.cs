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
        }
        private DataTable dataTable;
        private int currentIndex = 0;

        private void Attendance_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student where status=5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            da.Fill(dataTable);

            // Start displaying records
            DisplayNextRecord();
        }
        private void DisplayNextRecord()
        {
            if (currentIndex < dataTable.Rows.Count)
            {
                DataRow row = dataTable.Rows[currentIndex];
                // Add the record from the DataRow to the CheckListBox
                //checkListBox1.Items.Clear(); // Clear existing items
                checkListBox1.Items.Add(row["RegistrationNumber"].ToString());
                //checkListBox1.Items.Add(row["Column2"].ToString());
                // You can add more columns similarly

                // Move to the next record
                currentIndex++;

                // You can use a timer or any other mechanism to control the timing between each record
                // For example, if using a timer, start the timer here to display the next record after a certain interval
            }
            else
            {
                // All records have been displayed
                MessageBox.Show("All records displayed.");
            }
        }
    }
}
