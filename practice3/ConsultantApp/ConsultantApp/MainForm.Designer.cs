using System.ComponentModel;

namespace ConsultantApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStartConsultation = new System.Windows.Forms.Button();
            this.buttonAuthors = new System.Windows.Forms.Button();
            this.buttonAboutProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartConsultation
            // 
            this.buttonStartConsultation.Location = new System.Drawing.Point(107, 155);
            this.buttonStartConsultation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStartConsultation.Name = "buttonStartConsultation";
            this.buttonStartConsultation.Size = new System.Drawing.Size(256, 78);
            this.buttonStartConsultation.TabIndex = 0;
            this.buttonStartConsultation.Text = "Начать";
            this.buttonStartConsultation.UseVisualStyleBackColor = true;
            this.buttonStartConsultation.Click += new System.EventHandler(this.StartConsultation);
            // 
            // buttonAuthors
            // 
            this.buttonAuthors.Location = new System.Drawing.Point(107, 238);
            this.buttonAuthors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAuthors.Name = "buttonAuthors";
            this.buttonAuthors.Size = new System.Drawing.Size(256, 69);
            this.buttonAuthors.TabIndex = 1;
            this.buttonAuthors.Text = "Авторы";
            this.buttonAuthors.UseVisualStyleBackColor = true;
            this.buttonAuthors.Click += new System.EventHandler(this.ShowAuthors);
            // 
            // buttonAboutProgram
            // 
            this.buttonAboutProgram.Location = new System.Drawing.Point(107, 313);
            this.buttonAboutProgram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAboutProgram.Name = "buttonAboutProgram";
            this.buttonAboutProgram.Size = new System.Drawing.Size(256, 68);
            this.buttonAboutProgram.TabIndex = 2;
            this.buttonAboutProgram.Text = "О программе";
            this.buttonAboutProgram.UseVisualStyleBackColor = true;
            this.buttonAboutProgram.Click += new System.EventHandler(this.ShowAboutProgram);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(457, 447);
            this.Controls.Add(this.buttonAboutProgram);
            this.Controls.Add(this.buttonAuthors);
            this.Controls.Add(this.buttonStartConsultation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonAboutProgram;
        private System.Windows.Forms.Button buttonAuthors;
        private System.Windows.Forms.Button buttonStartConsultation;

        #endregion
    }
}
