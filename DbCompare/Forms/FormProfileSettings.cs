using DbCompare.Objects;
using System;
using System.Windows.Forms;

namespace DbCompare.Forms
{
    public partial class FormProfileSettings : Form
    {
        private readonly Profile _profile;

        public FormProfileSettings(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            _profile = profile;

            InitializeComponent();
            InitializeProfile();
        }

        private void InitializeProfile()
        {
            foreach (var item in _profile.ExcludedSchemas)
            {
                lbxExcludedSchemas.Items.Add(item);
            }

            foreach (var item in _profile.ExcludedObjects)
            {
                lbxExcludedObjects.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _profile.ExcludedSchemas.Clear();
            foreach (var item in lbxExcludedSchemas.Items)
            {
                _profile.ExcludedSchemas.Add(item.ToString());
            }

            _profile.ExcludedObjects.Clear();
            foreach (var item in lbxExcludedObjects.Items)
            {
                _profile.ExcludedObjects.Add(item.ToString());
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            using (FormInput dialog = new FormInput())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(dialog.Value))
                        return;

                    ListBox control = (ListBox)contextMenuExcluded.Tag;
                    control.Items.Add(dialog.Value.Trim());
                }
            }
        }

        private void mniRemove_Click(object sender, EventArgs e)
        {
            ListBox control = (ListBox)contextMenuExcluded.Tag;
            if (control.SelectedIndex != -1)
                control.Items.RemoveAt(control.SelectedIndex);
        }

        private void mniClear_Click(object sender, EventArgs e)
        {
            ListBox control = (ListBox)contextMenuExcluded.Tag;
            control.Items.Clear();
        }

        private void lbxExcludedSchemas_MouseUp(object sender, MouseEventArgs e)
        {
            contextMenuExcluded.Tag = lbxExcludedSchemas;

            if (e.Button == MouseButtons.Right)
                contextMenuExcluded.Show(MousePosition);
        }

        private void lbxExcludedObjects_MouseUp(object sender, MouseEventArgs e)
        {
            contextMenuExcluded.Tag = lbxExcludedObjects;

            if (e.Button == MouseButtons.Right)
                contextMenuExcluded.Show(MousePosition);
        }
    }
}