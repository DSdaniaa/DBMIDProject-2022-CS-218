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
    public partial class Form1 : Form
    {
        private System.Drawing.Size originalFormSize;
        private Rectangle Original1;
        private Rectangle Original2;
        private Rectangle Original3;
        private Rectangle Original4;
        private Rectangle Original5;
        private Rectangle Original6;
        private Rectangle Original7;
        private Rectangle Original8;
        private Rectangle Original9;
        private Rectangle Original10;
        private Rectangle Original11;
        private Rectangle Original12;
        private Rectangle Original13;
        private Rectangle Original14;
        private Rectangle Original15;
        private Rectangle Original16;


        public Form1()
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
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@FirstName, @LastName, @Contact, @Email, @RegistrationNumber, @Status)", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox6.Text);
            cmd.Parameters.AddWithValue("@Status", 5);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            view();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName= @FirstName, LastName= @LastName, Contact= @Contact, Email= @Email, Status=@Status WHERE RegistrationNumber=@RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox6.Text);
            cmd.Parameters.AddWithValue("@Status", 5);
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update record. Make sure the Registration Number exists.");
            }

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            view();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET Status = @Status WHERE RegistrationNumber = @RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@Status", 6); 
            cmd.Parameters.AddWithValue("@RegistrationNumber", textBox6.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Attribute updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update attribute. Make sure the Registration Number exists.");
            }
            view();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void view()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select FirstName, LastName, Contact, Email, RegistrationNumber from Student where Status = 5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            Original1 = new Rectangle(dataGridView1.Location.X, dataGridView1.Location.Y, dataGridView1.Width, dataGridView1.Height);
            Original2 = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            Original3 = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            Original4 = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            Original5 = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            Original6 = new Rectangle(label5.Location.X, label5.Location.Y, label5.Width, label5.Height);
            Original7 = new Rectangle(label6.Location.X, label6.Location.Y, label6.Width, label6.Height);
            Original8 = new Rectangle(textBox2.Location.X, textBox2.Location.Y, textBox2.Width, textBox2.Height);
            Original9 = new Rectangle(textBox3.Location.X, textBox3.Location.Y, textBox3.Width, textBox3.Height);
            Original10 = new Rectangle(textBox4.Location.X, textBox4.Location.Y, textBox4.Width, textBox4.Height);
            Original11 = new Rectangle(textBox5.Location.X, textBox5.Location.Y, textBox5.Width, textBox5.Height);
            Original12= new Rectangle(textBox6.Location.X, textBox6.Location.Y, textBox6.Width, textBox6.Height);
            Original13= new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            Original14= new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            Original15= new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);
            Original16 = new Rectangle(button4.Location.X, button4.Location.Y, button4.Width, button4.Height);

            view();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form moreForm = new Admin();
            this.Hide();
            moreForm.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resize(Original1, dataGridView1);
            resize(Original2, label1);
            resize(Original3, label2);
            resize(Original4, label3);
            resize(Original5, label4);
            resize(Original6, label5);
            resize(Original7, label6);
            resize(Original8, textBox2);
            resize(Original9, textBox3);
            resize(Original10, textBox4);
            resize(Original11, textBox5);
            resize(Original12, textBox6);
            resize(Original13, button1);
            resize(Original14, button2);
            resize(Original15, button3);
            resize(Original16, button4);
            
        }
    }
}
