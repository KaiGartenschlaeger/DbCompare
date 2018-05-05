using System;
using System.Windows.Forms;

namespace DbCompare.Forms
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
}