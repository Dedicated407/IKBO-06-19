using System.Windows.Forms;

namespace ConsultantApp
{
    public partial class ConsultantForm : Form
    {
        public ConsultantForm(Control mainForm)
        {
            InitializeComponent();
            Closing += (_, _) => mainForm.Show();
        }
    }
}
