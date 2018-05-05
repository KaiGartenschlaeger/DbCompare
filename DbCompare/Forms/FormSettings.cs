using System;
using System.Windows.Forms;

namespace DbCompare.Forms
{
    public partial class FormSettings : Form
    {
        #region Constructor

        public FormSettings()
        {
            InitializeComponent();
        }

        #endregion

        #region Control events

        private void btnChooseMergeApplication_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose merge application path";
                dialog.Filter = "Application|*.exe;*.com|All files|*.*";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    tbxMergeToolPath.Text = dialog.FileName;

                    if (string.IsNullOrEmpty(tbxMergeToolArguments.Text))
                    {
                        tbxMergeToolArguments.Text = "{source} {destination}";
                    }
                }
            }
        }

        #endregion

        #region Properties

        public string MergeToolPath
        {
            get { return tbxMergeToolPath.Text; }
            set { tbxMergeToolPath.Text = value; }
        }

        public string MergeToolArguments
        {
            get { return tbxMergeToolArguments.Text; }
            set { tbxMergeToolArguments.Text = value; }
        }

        #endregion
    }
}