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
    public partial class ComponentReport : Form
    {
        private System.Drawing.Size originalFormSize;
        private Rectangle Original1;
        private Rectangle Original2;
        private Rectangle Original3;
        public ComponentReport()
        {
            InitializeComponent();
        }
        private void resize(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Size.Width * xRatio);
            int newHeight = (int)(r.Size.Height * yRatio);
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }
        private void ComponentReport_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            Original1 = new Rectangle(dataGridView1.Location.X, dataGridView1.Location.Y, dataGridView1.Width, dataGridView1.Height);
            Original3 = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            Original2 = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);


            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select s.RegistrationNumber, CONCAT(s.FirstName,' ', s.LastName ) As Name,c.Name As CLOs, ac.Name As Components,ac.TotalMarks, ((CONVERT(FLOAT,(Select MeasurementLevel from RubricLevel where Id=sr.RubricMeasurementId))/ CONVERT(FLOAT,(Select Max(MeasurementLevel) from RubricLevel where RubricId=r.Id)))*(CONVERT(FLOAT,(Select TotalMarks from AssessmentComponent where sr.AssessmentComponentId=Id)))) AS ObtainedMarks FROM StudentResult sr INNER JOIN RubricLevel rl ON sr.RubricMeasurementId = rl.Id INNER JOIN Rubric r ON rl.RubricId = r.Id INNER JOIN Clo c ON r.CloId = c.Id INNER JOIN Student s ON sr.StudentId = s.Id INNER JOIN AssessmentComponent ac ON sr.AssessmentComponentId = ac.Id; ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form moreForm = new Student();
            this.Hide();
            moreForm.Show();
        }

        private void ComponentReport_Resize(object sender, EventArgs e)
        {
            resize(Original1, dataGridView1);
            resize(Original2, button2);
            resize(Original3, label1);
        }
    }
}
