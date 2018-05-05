using System.Windows.Forms;

namespace DbCompare.Forms
{
    public partial class FormCompare : Form
    {
        public FormCompare(string src, string tar)
        {
            InitializeComponent();

            tbxSource.Text = src;
            tbxTarget.Text = tar;
        }
    }
}