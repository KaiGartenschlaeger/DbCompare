using System;
using System.Data.Common;
using System.Windows.Forms;

namespace DbCompare.Forms
{
    public partial class FormExecuteSQL : Form
    {
        #region Fields

        private DbConnection m_connection;

        #endregion

        #region Constructor

        public FormExecuteSQL(DbConnection connection)
        {
            InitializeComponent();

            m_connection = connection;
        }

        #endregion

        #region Control Events

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = m_connection.CreateCommand();
                command.CommandText = tbxSQL.Text;

                command.ExecuteNonQuery();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Properties

        public string SQL
        {
            get
            {
                return tbxSQL.Text;
            }

            set
            {
                tbxSQL.Text = value;
                tbxSQL.Select(0, 0);
            }
        }

        #endregion
    }
}