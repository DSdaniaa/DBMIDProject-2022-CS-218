
namespace Database_Mid_Project
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkStudent = new System.Windows.Forms.CheckBox();
            this.checkAdmin = new System.Windows.Forms.CheckBox();
            this.btnNextRole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Algerian", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Role";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkStudent
            // 
            this.checkStudent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkStudent.AutoSize = true;
            this.checkStudent.BackColor = System.Drawing.Color.Transparent;
            this.checkStudent.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkStudent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkStudent.Location = new System.Drawing.Point(311, 204);
            this.checkStudent.Name = "checkStudent";
            this.checkStudent.Size = new System.Drawing.Size(156, 48);
            this.checkStudent.TabIndex = 5;
            this.checkStudent.Text = "Student";
            this.checkStudent.UseVisualStyleBackColor = false;
            this.checkStudent.CheckedChanged += new System.EventHandler(this.checkCustomer_CheckedChanged);
            // 
            // checkAdmin
            // 
            this.checkAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.checkAdmin.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAdmin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkAdmin.Location = new System.Drawing.Point(321, 126);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(142, 48);
            this.checkAdmin.TabIndex = 4;
            this.checkAdmin.Text = "Admin";
            this.checkAdmin.UseVisualStyleBackColor = false;
            this.checkAdmin.CheckedChanged += new System.EventHandler(this.checkAdmin_CheckedChanged);
            // 
            // btnNextRole
            // 
            this.btnNextRole.BackColor = System.Drawing.Color.Transparent;
            this.btnNextRole.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextRole.Location = new System.Drawing.Point(629, 298);
            this.btnNextRole.Name = "btnNextRole";
            this.btnNextRole.Size = new System.Drawing.Size(98, 41);
            this.btnNextRole.TabIndex = 7;
            this.btnNextRole.Text = "Next";
            this.btnNextRole.UseVisualStyleBackColor = false;
            this.btnNextRole.Click += new System.EventHandler(this.btnNextRole_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkStudent);
            this.Controls.Add(this.checkAdmin);
            this.Controls.Add(this.btnNextRole);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkStudent;
        private System.Windows.Forms.CheckBox checkAdmin;
        private System.Windows.Forms.Button btnNextRole;
    }
}