using System;
using System.Windows.Forms;
using ConsultantApp.Properties;

namespace ConsultantApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void StartConsultation(object sender, EventArgs e)
        {
            ConsultantForm form = new (this);

            Hide();
            form.Show();
        }

        private void ShowAuthors(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Authors, Resources.AuthorsCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
