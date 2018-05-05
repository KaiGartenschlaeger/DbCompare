using DbCompare.Objects;
using SimpleConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DbCompare.Forms
{
    public partial class FormMain : Form
    {
        #region Fields

        private const string PROFILES_FILENAME = "Profiles.xml";
        private const string SETTINGS_FILENAME = "Settings.xml";

        private string _settingsPath;
        private string _settingsFilePath;
        private string _profilesFilePath;

        private Settings _settings;

        private List<Profile> _profiles;
        private Profile _curentProfile;

        private SqlConnection _srcConnection = null;
        private SqlConnection _tarConnection = null;

        #endregion

        #region Constructor

        public FormMain()
        {
            InitializeComponent();
            slState.Text = string.Empty;
        }

        #endregion

        #region Form events

        private void FormMain_Load(object sender, EventArgs e)
        {
            _settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DbCompare");
            if (!Directory.Exists(_settingsPath))
            {
                Directory.CreateDirectory(_settingsPath);
            }

            _settingsFilePath = Path.Combine(_settingsPath, SETTINGS_FILENAME);
            _profilesFilePath = Path.Combine(_settingsPath, PROFILES_FILENAME);

            LoadSettings();
            LoadProfiles();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            SaveProfile();
        }

        #endregion

        #region Control Events

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (FormSettings dialog = new FormSettings())
            {
                dialog.MergeToolPath = _settings.MergeToolPath ?? string.Empty;
                dialog.MergeToolArguments = _settings.MergeToolArguments ?? string.Empty;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    _settings.MergeToolPath = dialog.MergeToolPath;
                    _settings.MergeToolArguments = dialog.MergeToolArguments;
                }
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (!ValidProfile())
            {
                MessageBox.Show("Missing informations, please fill out all connection values.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            if (!bwCompare.IsBusy)
            {
                bwCompare.RunWorkerAsync();
            }
        }

        private void btnProfiles_Click(object sender, EventArgs e)
        {
            menuProfiles.Show(MousePosition);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (_curentProfile == null)
                return;

            using (FormProfileSettings profileSettings = new FormProfileSettings(_curentProfile))
            {
                profileSettings.ShowDialog(this);
            }
        }

        private void menuProfiles_Opening(object sender, CancelEventArgs e)
        {
        }

        private void mniLoad_Click(object sender, EventArgs e)
        {
        }

        private void mniSave_Click(object sender, EventArgs e)
        {
            if (ValidProfile())
            {
                Profile profile = new Profile();

                profile.SourceHost = tbxSourceHost.Text;
                profile.SourceUsername = tbxSourceUsername.Text;
                profile.SourcePassword = tbxSourcePassword.Text;
                profile.SourceIntegratedMode = chbSrcIntegratedSecurity.Checked;
                profile.SourceDatabase = tbxSrcDatabase.Text;

                profile.TargetHost = tbxTargetHost.Text;
                profile.TargetUsername = tbxTargetUsername.Text;
                profile.TargetPassword = tbxTargetPassword.Text;
                profile.TargetIntegratedMode = chbTargetIntegratedSecurity.Checked;
                profile.TargetDatabase = tbxTarDatabase.Text;

                AddProfile(profile);
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            Profile profile = ((ToolStripMenuItem)sender).Tag as Profile;
            if (profile != null)
            {
                tbxSourceHost.Text = profile.SourceHost;
                tbxSourceUsername.Text = profile.SourceUsername;
                tbxSourcePassword.Text = profile.SourcePassword;
                chbSrcIntegratedSecurity.Checked = profile.SourceIntegratedMode;
                tbxSrcDatabase.Text = profile.SourceDatabase;

                tbxTargetHost.Text = profile.TargetHost;
                tbxTargetUsername.Text = profile.TargetUsername;
                tbxTargetPassword.Text = profile.TargetPassword;
                chbTargetIntegratedSecurity.Checked = profile.TargetIntegratedMode;
                tbxTarDatabase.Text = profile.TargetDatabase;

                _curentProfile = profile;
            }
        }

        private void lvwRoutineChanges_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvwRoutineChanges.SelectedIndices.Count > 0)
            {
                RoutineChange change = (RoutineChange)lvwRoutineChanges.SelectedItems[0].Tag;

                miCreateRoutine.Visible = (change.ChangeType == RoutineChangeType.Added);
                miDeleteRoutine.Visible = (change.ChangeType == RoutineChangeType.Deleted);

                mniCompareRoutines.Visible = (change.ChangeType == RoutineChangeType.DefinitionChanged);
                miUpdateRoutineSourceToTarget.Visible = (change.ChangeType == RoutineChangeType.DefinitionChanged);
                miUpdateRoutineTargetToSource.Visible = (change.ChangeType == RoutineChangeType.DefinitionChanged);

                menuRoutines.Show(MousePosition);
            }
        }
        private void miCreateRoutine_Click(object sender, EventArgs e)
        {
            RoutineChange change = (RoutineChange)lvwRoutineChanges.SelectedItems[0].Tag;

            using (FormExecuteSQL dialog = new FormExecuteSQL(_tarConnection))
            {
                dialog.SQL = change.Source.Defination;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Successfull executed", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void UpdateRoutine(SqlConnection connection, RoutineInfo routine)
        {
            // replace create with update
            string sql = routine.Defination;
            switch (routine.Type)
            {
                case "PROCEDURE":
                    sql = sql.Replace(
                        "CREATE PROCEDURE [" + routine.Schema + "].[" + routine.Name + "]",
                        "ALTER PROCEDURE [" + routine.Schema + "].[" + routine.Name + "]");
                    break;

                case "FUNCTION":
                    sql = sql.Replace(
                        "CREATE FUNCTION [" + routine.Schema + "].[" + routine.Name + "]",
                        "ALTER FUNCTION [" + routine.Schema + "].[" + routine.Name + "]");
                    break;
            }

            using (FormExecuteSQL dialog = new FormExecuteSQL(connection))
            {
                dialog.SQL = sql;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Successfull executed", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void miUpdateRoutineSourceToTarget_Click(object sender, EventArgs e)
        {
            UpdateRoutine(_tarConnection,
                ((RoutineChange)lvwRoutineChanges.SelectedItems[0].Tag).Source);
        }
        private void miUpdateRoutineTargetToSource_Click(object sender, EventArgs e)
        {
            UpdateRoutine(_srcConnection,
                ((RoutineChange)lvwRoutineChanges.SelectedItems[0].Tag).Target);
        }
        private void miDeleteRoutine_Click(object sender, EventArgs e)
        {
            RoutineChange change = (RoutineChange)lvwRoutineChanges.SelectedItems[0].Tag;
            using (FormExecuteSQL dialog = new FormExecuteSQL(_tarConnection))
            {
                switch (change.Source.Type)
                {
                    case "PROCEDURE":
                        dialog.SQL = string.Format("DROP PROCEDURE [{0}].[{1}];",
                            change.Source.Schema, change.Source.Name);
                        break;
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Successfull executed", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void mniCompareRoutines_Click(object sender, EventArgs e)
        {
            RoutineChange change = (RoutineChange)lvwRoutineChanges.SelectedItems[0].Tag;

            if (string.IsNullOrEmpty(_settings.MergeToolPath))
            {
                using (FormCompare dialog = new FormCompare(
                    change.Source.Defination, change.Target.Defination))
                {
                    dialog.ShowDialog(this);
                }
            }
            else
            {
                try
                {
                    string path1 = Path.GetTempFileName();
                    File.WriteAllText(path1, change.Source.Defination);

                    string path2 = Path.GetTempFileName();
                    File.WriteAllText(path2, change.Target.Defination);

                    string args = _settings.MergeToolArguments
                        .Replace("{source}", "\"" + path1 + "\"")
                        .Replace("{destination}", "\"" + path2 + "\"");

                    Process.Start(_settings.MergeToolPath, args);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to compare\n\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lvwColumns_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvwColumns.SelectedIndices.Count > 0)
            {
                menuColumns.Show(MousePosition);
            }
        }
        private void miColumnsUpdate_Click(object sender, EventArgs e)
        {
            if (lvwColumns.SelectedIndices.Count > 0)
            {
                ColumnChange change = lvwColumns.SelectedItems[0].Tag as ColumnChange;
                if (change != null)
                {
                    switch (change.ChangeType)
                    {
                        case ColumnChangeType.Added:
                        case ColumnChangeType.DataTypeChanged:
                        case ColumnChangeType.MaxLengthChanged:
                        case ColumnChangeType.NullableChanged:
                            StringBuilder sql = new StringBuilder();

                            sql.AppendFormat("ALTER TABLE [{0}].[{1}]",
                                change.SourceColumn.Schema,
                                change.SourceColumn.Table);

                            if (change.ChangeType == ColumnChangeType.Added)
                            {
                                sql.AppendFormat(" ADD [{0}]",
                                    change.SourceColumn.Name);
                            }
                            else
                            {
                                sql.AppendFormat(" ALTER COLUMN [{0}]",
                                    change.SourceColumn.Name);
                            }

                            sql.AppendFormat(" [{0}]",
                                change.SourceColumn.DataType);

                            if (change.SourceColumn.MaximumLength > 0)
                            {
                                sql.AppendFormat("({0})",
                                    change.SourceColumn.MaximumLength);
                            }

                            if (change.SourceColumn.IsNullable)
                            {
                                sql.AppendFormat(" NULL");
                            }
                            else
                            {
                                sql.AppendFormat(" NOT NULL");
                            }

                            using (FormExecuteSQL dialog = new FormExecuteSQL(_tarConnection))
                            {
                                dialog.SQL = sql.ToString();

                                if (dialog.ShowDialog(this) == DialogResult.OK)
                                {
                                    MessageBox.Show("Successfull executed", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            break;

                        case ColumnChangeType.Removed:
                            StringBuilder removeSQL = new StringBuilder();

                            removeSQL.AppendFormat("ALTER TABLE [{0}].[{1}] DROP COLUMN [{2}]",
                                change.SourceColumn.Schema,
                                change.SourceColumn.Table,
                                change.SourceColumn.Name);

                            using (FormExecuteSQL dialog = new FormExecuteSQL(_tarConnection))
                            {
                                dialog.SQL = removeSQL.ToString();

                                if (dialog.ShowDialog(this) == DialogResult.OK)
                                {
                                    MessageBox.Show("Successfull executed", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            break;

                        case ColumnChangeType.DefaultValueChanged:
                            StringBuilder defaultSQL = new StringBuilder();

                            defaultSQL.AppendFormat("ALTER TABLE [{0}].[{1}] ADD CONSTRAINT [DF_{1}_{2}] DEFAULT {3} FOR [{2}]",
                                change.SourceColumn.Schema,
                                change.SourceColumn.Table,
                                change.SourceColumn.Name,
                                change.SourceColumn.Default);

                            using (FormExecuteSQL dialog = new FormExecuteSQL(_tarConnection))
                            {
                                dialog.SQL = defaultSQL.ToString();

                                if (dialog.ShowDialog(this) == DialogResult.OK)
                                {
                                    MessageBox.Show("Successfull executed", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            break;

                        default:
                            MessageBox.Show("Not implemented now", "Not implemented",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            break;
                    }
                }
            }
        }

        private void UpdateView(ViewInfo view, SqlConnection connection)
        {
            using (FormExecuteSQL dialog = new FormExecuteSQL(connection))
            {
                dialog.SQL = view.Definition;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Successfull executed", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void lvwViewsChanges_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvwViewsChanges.SelectedItems.Count > 0)
            {
                menuViews.Show(MousePosition);
            }
        }
        private void menuViews_Opening(object sender, CancelEventArgs e)
        {
            if (lvwViewsChanges.SelectedItems.Count > 0)
            {
                ViewChange change = (ViewChange)lvwViewsChanges.SelectedItems[0].Tag;

                mniCreateView.Visible = change.ChangeType == ViewChangeType.Added;
                mniDeleteView.Visible = change.ChangeType == ViewChangeType.Deleted;
                mniCompareViews.Visible = change.ChangeType == ViewChangeType.Changed;
                mniCompareViewsGap.Visible = change.ChangeType == ViewChangeType.Changed;
                mniUpdateSourceView.Visible = change.ChangeType == ViewChangeType.Changed;
                mniUpdateTargetView.Visible = change.ChangeType == ViewChangeType.Changed;
            }
        }
        private void mniCompareViews_Click(object sender, EventArgs e)
        {
            ViewChange change = (ViewChange)lvwViewsChanges.SelectedItems[0].Tag;

            if (string.IsNullOrEmpty(_settings.MergeToolPath))
            {
                using (FormCompare dialog = new FormCompare(
                    change.Source.Definition, change.Target.Definition))
                {
                    dialog.ShowDialog(this);
                }
            }
            else
            {
                try
                {
                    string path1 = Path.GetTempFileName();
                    File.WriteAllText(path1, change.Source.Definition);

                    string path2 = Path.GetTempFileName();
                    File.WriteAllText(path2, change.Target.Definition);

                    string args = _settings.MergeToolArguments
                        .Replace("{source}", "\"" + path1 + "\"")
                        .Replace("{destination}", "\"" + path2 + "\"");

                    Process.Start(_settings.MergeToolPath, args);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to compare\n\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void mniCreateView_Click(object sender, EventArgs e)
        {
            ViewChange change = (ViewChange)lvwViewsChanges.SelectedItems[0].Tag;

            using (FormExecuteSQL dialog = new FormExecuteSQL(_tarConnection))
            {
                dialog.SQL = change.Source.Definition;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Successfull executed", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void mniUpdateTargetView_Click(object sender, EventArgs e)
        {
            UpdateView(((ViewChange)lvwViewsChanges.SelectedItems[0].Tag).Source, _tarConnection);
        }
        private void mniUpdateSourceView_Click(object sender, EventArgs e)
        {
            UpdateView(((ViewChange)lvwViewsChanges.SelectedItems[0].Tag).Target, _srcConnection);
        }
        private void mniDeleteView_Click(object sender, EventArgs e)
        {
            ViewChange change = (ViewChange)lvwViewsChanges.SelectedItems[0].Tag;
            using (FormExecuteSQL dialog = new FormExecuteSQL(_tarConnection))
            {
                dialog.SQL = $"DROP VIEW [{change.Source.Schema}].[{change.Source.Name}]";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Successfull executed", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region BackgroundWorker Compare

        private void bwCompare_DoWork(object sender, DoWorkEventArgs e)
        {
            //
            // clear gui
            //
            bwCompare.ReportProgress((int)CompareState.ClearGUI);

            //
            // open connections
            //
            bwCompare.ReportProgress((int)CompareState.Connecting);

            _srcConnection = OpenConnection(tbxSourceHost.Text, tbxSourceUsername.Text, tbxSourcePassword.Text, tbxSrcDatabase.Text, chbSrcIntegratedSecurity.Checked);
            if (_srcConnection != null)
            {
                _tarConnection = OpenConnection(tbxTargetHost.Text, tbxTargetUsername.Text, tbxTargetPassword.Text, tbxTarDatabase.Text, chbTargetIntegratedSecurity.Checked);
            }

            //
            // start compare
            //
            bwCompare.ReportProgress((int)CompareState.Compare);

            if (_srcConnection != null && _tarConnection != null)
            {
                //
                // tables
                //
                var sourceTables = GetTableInfos(_srcConnection);
                var targetTables = GetTableInfos(_tarConnection);

                foreach (var table in sourceTables)
                {
                    // added table
                    if (!targetTables.ContainsKey(table.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.AddedTable, table.Value);
                    }
                }

                foreach (var table in targetTables)
                {
                    // removed table
                    if (!sourceTables.ContainsKey(table.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.RemovedTable, table.Value);
                    }
                }

                // refresh gui
                bwCompare.ReportProgress((int)CompareState.RefreshGUITables);

                // 
                // views
                //
                var sourceViews = GetViewInfos(_srcConnection);
                var targetViews = GetViewInfos(_tarConnection);

                foreach (var view in sourceViews)
                {
                    if (!targetViews.ContainsKey(view.Key))
                    {
                        // added view
                        bwCompare.ReportProgress((int)CompareState.ViewAdded,
                            new ViewChange(view.Value, null, ViewChangeType.Added));
                    }
                    else
                    {
                        // changed view
                        if (view.Value.Definition.Trim() != targetViews[view.Key].Definition.Trim())
                        {
                            bwCompare.ReportProgress((int)CompareState.ViewChanged,
                                new ViewChange(view.Value, targetViews[view.Key], ViewChangeType.Changed));
                        }
                    }
                }

                // removed view
                foreach (var routine in targetViews)
                {
                    if (!sourceViews.ContainsKey(routine.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.ViewRemoved,
                            new ViewChange(routine.Value, null, ViewChangeType.Deleted));
                    }
                }

                bwCompare.ReportProgress((int)CompareState.RefreshGUIViews);

                //
                // columns
                //
                var sourceColumns = GetColumnInfos(_srcConnection);
                var targetColumns = GetColumnInfos(_tarConnection);

                foreach (var sourceColumn in sourceColumns)
                {
                    if (!targetColumns.ContainsKey(sourceColumn.Key))
                    {
                        // new column
                        if (targetTables.ContainsKey(sourceColumn.Value.Schema + "." + sourceColumn.Value.Table))
                        {
                            bwCompare.ReportProgress((int)CompareState.AddedColumn,
                                new ColumnCompare(sourceColumn.Value, null));
                        }
                    }
                    else
                    {
                        bwCompare.ReportProgress((int)CompareState.CompareColumn,
                            new ColumnCompare(sourceColumn.Value, targetColumns[sourceColumn.Key]));
                    }
                }

                foreach (var targetColumn in targetColumns)
                {
                    if (!sourceColumns.ContainsKey(targetColumn.Key))
                    {
                        // removed column
                        if (sourceTables.ContainsKey(targetColumn.Value.Schema + "." + targetColumn.Value.Table))
                        {
                            bwCompare.ReportProgress((int)CompareState.RemovedColumn,
                                new ColumnCompare(targetColumn.Value, null));
                        }

                    }
                }

                // refresh gui
                bwCompare.ReportProgress((int)CompareState.RefreshGUIColumns);

                //
                // indizees
                //
                Dictionary<string, IndexInformation> srcIndizees = GetIndizees(_srcConnection);
                Dictionary<string, IndexInformation> tarIndizees = GetIndizees(_tarConnection);

                foreach (var index in srcIndizees)
                {
                    if (!tarIndizees.ContainsKey(index.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.IndexAdded, index.Value);
                    }
                }

                foreach (var index in tarIndizees)
                {
                    if (!srcIndizees.ContainsKey(index.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.IndexRemoved, index.Value);
                    }
                }

                // refresh gui
                bwCompare.ReportProgress((int)CompareState.RefreshGUIIndizees);

                //
                // foreign keys
                //
                Dictionary<string, ForeignKeyInformation> srcForeignKeys = GetForeignKeys(_srcConnection);
                Dictionary<string, ForeignKeyInformation> tarForeignKeys = GetForeignKeys(_tarConnection);

                foreach (var key in srcForeignKeys)
                {
                    if (!tarForeignKeys.ContainsKey(key.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.ForeignKeyAdded, key.Value);
                    }
                }

                foreach (var key in tarForeignKeys)
                {
                    if (!srcForeignKeys.ContainsKey(key.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.ForeignKeyRemoved, key.Value);
                    }
                }

                bwCompare.ReportProgress((int)CompareState.RefreshGUIForeignKeys);

                //
                // stored procedures
                //
                Dictionary<string, RoutineInfo> srcRoutines = GetRoutines(_srcConnection);
                Dictionary<string, RoutineInfo> tarRoutines = GetRoutines(_tarConnection);

                // added routine
                foreach (var routine in srcRoutines)
                {
                    if (!tarRoutines.ContainsKey(routine.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.RoutineAdded,
                            new RoutineChange(routine.Value, null, RoutineChangeType.Added));
                    }
                    else
                    {
                        // changed routine
                        if (routine.Value.Defination.Trim() != tarRoutines[routine.Key].Defination.Trim())
                        {
                            bwCompare.ReportProgress((int)CompareState.RoutineChanged,
                                new RoutineChange(routine.Value, tarRoutines[routine.Key], RoutineChangeType.DefinitionChanged));
                        }
                    }
                }

                // removed routine
                foreach (var routine in tarRoutines)
                {
                    if (!srcRoutines.ContainsKey(routine.Key))
                    {
                        bwCompare.ReportProgress((int)CompareState.RoutineRemoved,
                            new RoutineChange(routine.Value, null, RoutineChangeType.Deleted));
                    }
                }

                // refresh gui
                bwCompare.ReportProgress((int)CompareState.RefreshGUIRoutines);
            }
        }
        private void bwCompare_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CompareState state = (CompareState)e.ProgressPercentage;
            switch (state)
            {
                case CompareState.ClearGUI:
                    slState.Text = "Preparing GUI..";

                    tabTables.Text = "Refreshing..";
                    tabViews.Text = "Refreshing..";
                    tabColumns.Text = "Refreshing..";
                    tabIndexes.Text = "Refreshing..";
                    tabForeignKeys.Text = "Refreshing..";
                    tabRoutines.Text = "Refreshing..";

                    lvwTableChanges.Items.Clear();
                    lvwViewsChanges.Items.Clear();
                    lvwColumns.Items.Clear();
                    lvwIndizees.Items.Clear();
                    lvwForeignKeys.Items.Clear();
                    lvwRoutineChanges.Items.Clear();

                    grpSourceDb.Enabled = false;
                    grpTargetDb.Enabled = false;
                    btnProfiles.Enabled = false;
                    btnCompare.Enabled = false;

                    break;

                case CompareState.Connecting:
                    slState.Text = "Connecting..";
                    break;

                case CompareState.Compare:
                    slState.Text = "Compare Databases..";
                    break;

                case CompareState.AddedTable:
                    TableInfo addedTable = (TableInfo)e.UserState;
                    AddTableChange(addedTable, "Added");
                    break;

                case CompareState.RemovedTable:
                    TableInfo removedTable = (TableInfo)e.UserState;
                    AddTableChange(removedTable, "Removed");
                    break;

                case CompareState.ViewAdded:
                case CompareState.ViewRemoved:
                case CompareState.ViewChanged:
                    AddViewChange((ViewChange)e.UserState);
                    break;

                case CompareState.RefreshGUITables:
                    if (lvwTableChanges.Items.Count > 0)
                    {
                        tabTables.Text = "Tables (" + lvwTableChanges.Items.Count.ToString("n0") + ")";
                    }
                    else
                    {
                        tabTables.Text = "Tables";
                    }
                    break;

                case CompareState.RefreshGUIViews:
                    if (lvwViewsChanges.Items.Count > 0)
                    {
                        tabViews.Text = "Views (" + lvwViewsChanges.Items.Count.ToString("n0") + ")";
                    }
                    else
                    {
                        tabViews.Text = "Views";
                    }
                    break;

                case CompareState.ForeignKeyAdded:
                    ForeignKeyInformation addedFK = (ForeignKeyInformation)e.UserState;
                    AddForeignKeyChange(addedFK.Key_Schema, addedFK.Table_Name, addedFK.Key_Name, "Added");
                    break;

                case CompareState.ForeignKeyRemoved:
                    ForeignKeyInformation removedFK = (ForeignKeyInformation)e.UserState;
                    AddForeignKeyChange(removedFK.Key_Schema, removedFK.Table_Name, removedFK.Key_Name, "Removed");
                    break;

                case CompareState.IndexAdded:
                    IndexInformation addedIndex = (IndexInformation)e.UserState;
                    AddIndexChange(addedIndex.Schema, addedIndex.Table, addedIndex.Column, addedIndex.Index, "Added");
                    break;

                case CompareState.IndexChanged:
                    break;

                case CompareState.IndexRemoved:
                    IndexInformation removedIndex = (IndexInformation)e.UserState;
                    AddIndexChange(removedIndex.Schema, removedIndex.Table, removedIndex.Column, removedIndex.Index, "Removed");
                    break;

                case CompareState.RefreshGUIIndizees:
                    if (lvwIndizees.Items.Count > 0)
                    {
                        tabIndexes.Text = "Indexes (" + lvwIndizees.Items.Count.ToString("n0") + ")";
                    }
                    else
                    {
                        tabIndexes.Text = "Indexes";
                    }
                    break;

                case CompareState.AddedColumn:
                    ColumnCompare addedColumn = (ColumnCompare)e.UserState;
                    AddColumnChange(addedColumn.SourceColumn.Schema, addedColumn.SourceColumn.Table, addedColumn.SourceColumn.Name, "Added",
                        new ColumnChange(ColumnChangeType.Added, addedColumn.SourceColumn, addedColumn.TargetColumn));
                    break;

                case CompareState.RemovedColumn:
                    ColumnCompare removedColumn = (ColumnCompare)e.UserState;
                    AddColumnChange(removedColumn.SourceColumn.Schema, removedColumn.SourceColumn.Table, removedColumn.SourceColumn.Name, "Removed",
                        new ColumnChange(ColumnChangeType.Removed, removedColumn.SourceColumn, removedColumn.TargetColumn));
                    break;

                case CompareState.CompareColumn:
                    ColumnCompare columnCompare = (ColumnCompare)e.UserState;
                    CompareColumns(columnCompare.SourceColumn, columnCompare.TargetColumn);
                    break;

                case CompareState.RefreshGUIColumns:
                    if (lvwColumns.Items.Count > 0)
                    {
                        tabColumns.Text = "Columns (" + lvwColumns.Items.Count.ToString("n0") + ")";
                    }
                    else
                    {
                        tabColumns.Text = "Columns";
                    }
                    break;

                case CompareState.RoutineAdded:
                case CompareState.RoutineRemoved:
                case CompareState.RoutineChanged:
                    AddRoutineChange((RoutineChange)e.UserState);
                    break;

                case CompareState.RefreshGUIRoutines:
                    if (lvwRoutineChanges.Items.Count > 0)
                    {
                        tabRoutines.Text = "Routines (" + lvwRoutineChanges.Items.Count.ToString("n0") + ")";
                    }
                    else
                    {
                        tabRoutines.Text = "Routines";
                    }
                    break;

                case CompareState.RefreshGUIForeignKeys:
                    if (lvwForeignKeys.Items.Count > 0)
                    {
                        tabForeignKeys.Text = "Keys (" + lvwForeignKeys.Items.Count.ToString("n0") + ")";
                    }
                    else
                    {
                        tabForeignKeys.Text = "Keys";
                    }
                    break;
            }
        }
        private void bwCompare_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grpSourceDb.Enabled = true;
            grpTargetDb.Enabled = true;

            btnProfiles.Enabled = true;
            btnCompare.Enabled = true;

            slState.Text = "Done";
        }

        #endregion

        #region Helper

        private bool ValidProfile()
        {
            if (string.IsNullOrEmpty(tbxSourceHost.Text) || string.IsNullOrEmpty(tbxTargetHost.Text)
                || string.IsNullOrEmpty(tbxSourceUsername.Text) || string.IsNullOrEmpty(tbxTargetUsername.Text)
                || string.IsNullOrEmpty(tbxSourcePassword.Text) || string.IsNullOrEmpty(tbxTargetPassword.Text)
                || string.IsNullOrEmpty(tbxSrcDatabase.Text) || string.IsNullOrEmpty(tbxTarDatabase.Text))
            {
                return false;
            }

            return true;
        }

        private void LoadSettings()
        {
            try
            {
                ConfigGroup settings = ConfigGroup.Load(_settingsFilePath, ConfigFormat.Xml);
                if (settings == null)
                {
                    settings = new ConfigGroup("DbCompare");
                }

                _settings = new Settings();

                ConfigGroup groupMerge = settings.SetGroup("Merge");
                _settings.MergeToolPath = groupMerge.ReadString("MergeToolPath", string.Empty);
                _settings.MergeToolArguments = groupMerge.ReadString("MergeToolArguments", string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open settings\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            try
            {
                ConfigGroup settings = new ConfigGroup("DbCompare");

                ConfigGroup groupMerge = settings.SetGroup("Merge");
                groupMerge.Write("MergeToolPath", _settings.MergeToolPath ?? string.Empty);
                groupMerge.Write("MergeToolArguments", _settings.MergeToolArguments ?? string.Empty);

                settings.Save(_settingsFilePath, ConfigFormat.Xml);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save settings\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProfiles()
        {
            _profiles = new List<Profile>();

            try
            {
                if (File.Exists(_profilesFilePath))
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(_profilesFilePath);

                    XmlNode nodeProfiles = xml["Profiles"];
                    if (nodeProfiles != null)
                    {
                        foreach (XmlNode nodeProfile in nodeProfiles.ChildNodes)
                        {
                            if (nodeProfile.Name != "Profile")
                                return;

                            XmlNode nodeSourceDatabase = nodeProfile["SourceDatabase"];
                            XmlNode nodeTargetDatabase = nodeProfile["TargetDatabase"];

                            if (nodeSourceDatabase != null && nodeTargetDatabase != null)
                            {
                                Profile profile = new Profile();

                                profile.SourceHost = nodeSourceDatabase["Host"].InnerText;
                                profile.SourceUsername = nodeSourceDatabase["Username"].InnerText;
                                profile.SourcePassword = nodeSourceDatabase["Password"].InnerText;
                                profile.SourceIntegratedMode = Convert.ToBoolean(nodeSourceDatabase["IntegratedMode"].InnerText);
                                profile.SourceDatabase = nodeSourceDatabase["Database"].InnerText;

                                profile.TargetHost = nodeTargetDatabase["Host"].InnerText;
                                profile.TargetUsername = nodeTargetDatabase["Username"].InnerText;
                                profile.TargetPassword = nodeTargetDatabase["Password"].InnerText;
                                profile.TargetIntegratedMode = Convert.ToBoolean(nodeTargetDatabase["IntegratedMode"].InnerText);
                                profile.TargetDatabase = nodeTargetDatabase["Database"].InnerText;

                                XmlNode nodeExcludedSchemas = nodeProfile["ExcludedSchemas"];
                                if (nodeExcludedSchemas != null)
                                {
                                    foreach (XmlNode node in nodeExcludedSchemas.SelectNodes("Item"))
                                    {
                                        profile.ExcludedSchemas.Add(node.InnerText);
                                    }
                                }

                                XmlNode nodeExcludedObjects = nodeProfile["ExcludedObjects"];
                                if (nodeExcludedSchemas != null)
                                {
                                    foreach (XmlNode node in nodeExcludedObjects.SelectNodes("Item"))
                                    {
                                        profile.ExcludedObjects.Add(node.InnerText);
                                    }
                                }

                                AddProfile(profile);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void SaveProfile()
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create(_profilesFilePath,
                    new XmlWriterSettings()
                    {
                        Indent = true,
                        Encoding = Encoding.UTF8
                    }))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Profiles");

                    foreach (Profile profile in _profiles)
                    {
                        writer.WriteStartElement("Profile");

                        writer.WriteStartElement("SourceDatabase");
                        writer.WriteElementString("Host", profile.SourceHost);
                        writer.WriteElementString("Username", profile.SourceUsername);
                        writer.WriteElementString("Password", profile.SourcePassword);
                        writer.WriteElementString("IntegratedMode", profile.SourceIntegratedMode.ToString());
                        writer.WriteElementString("Database", profile.SourceDatabase);
                        writer.WriteEndElement();

                        writer.WriteStartElement("TargetDatabase");
                        writer.WriteElementString("Host", profile.TargetHost);
                        writer.WriteElementString("Username", profile.TargetUsername);
                        writer.WriteElementString("Password", profile.TargetPassword);
                        writer.WriteElementString("IntegratedMode", profile.TargetIntegratedMode.ToString());
                        writer.WriteElementString("Database", profile.TargetDatabase);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ExcludedSchemas");
                        foreach (var item in profile.ExcludedSchemas)
                        {
                            writer.WriteElementString("Item", item);
                        }
                        writer.WriteEndElement();

                        writer.WriteStartElement("ExcludedObjects");
                        foreach (var item in profile.ExcludedObjects)
                        {
                            writer.WriteElementString("Item", item);
                        }
                        writer.WriteEndElement();

                        writer.WriteEndElement(); // profile
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception)
            {
            }
        }

        private void AddProfile(Profile profile)
        {
            _profiles.Add(profile);

            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = profile.TargetHost;
            menuItem.Tag = profile;
            menuItem.Click += new EventHandler(menuItem_Click);
            menuProfiles.Items.Add(menuItem);
        }

        private void AddTableChange(TableInfo ti, string action)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = ti;
            lvi.Text = ti.Schema;
            lvi.SubItems.Add(ti.Name);
            lvi.SubItems.Add(action);
            lvwTableChanges.Items.Add(lvi);
        }

        private void AddViewChange(ViewChange change)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = change;
            lvi.Text = change.Source.Schema;
            lvi.SubItems.Add(change.Source.Name);
            lvi.SubItems.Add(change.ChangeType.ToString());

            lvwViewsChanges.Items.Add(lvi);
        }

        private void AddColumnChange(string schema, string table, string column, string action, ColumnChange change)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = change;
            lvi.Text = schema;
            lvi.SubItems.Add(table);
            lvi.SubItems.Add(column);
            lvi.SubItems.Add(action);

            lvwColumns.Items.Add(lvi);
        }

        private void AddForeignKeyChange(string schema, string table, string key, string action)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = schema;
            lvi.SubItems.Add(table);
            lvi.SubItems.Add(key);
            lvi.SubItems.Add(action);

            lvwForeignKeys.Items.Add(lvi);
        }

        private void AddIndexChange(string schema, string table, string column, string index, string action)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = schema;
            lvi.SubItems.Add(table);
            lvi.SubItems.Add(column);
            lvi.SubItems.Add(index);
            lvi.SubItems.Add(action);

            lvwIndizees.Items.Add(lvi);
        }

        private void AddRoutineChange(RoutineChange change)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = change;

            lvi.Text = change.Source.Schema;
            lvi.SubItems.Add(change.Source.Body);
            lvi.SubItems.Add(change.Source.Name);
            lvi.SubItems.Add(change.Source.Type);
            lvi.SubItems.Add(change.ChangeType.ToString());

            lvwRoutineChanges.Items.Add(lvi);
        }

        private void CompareColumns(ColumnInfo column1, ColumnInfo column2)
        {
            if (column1.MaximumLength != column2.MaximumLength)
            {
                // length changed
                AddColumnChange(column1.Schema, column1.Table, column1.Name, "Maximum length changed from " + column2.MaximumLength + " to " + column1.MaximumLength,
                    new ColumnChange(ColumnChangeType.MaxLengthChanged, column1, column2));
            }

            if (column1.IsNullable != column2.IsNullable)
            {
                // nullable changed
                AddColumnChange(column1.Schema, column1.Table, column1.Name, "Nullable changed to " + (column1.IsNullable ? "not nullable" : "nullable"),
                    new ColumnChange(ColumnChangeType.NullableChanged, column1, column2));
            }

            if (column1.DataType != column2.DataType)
            {
                // datatype changed
                AddColumnChange(column1.Schema, column1.Table, column1.Name, "Datatype changed from " + column2.DataType + " to " + column1.DataType,
                    new ColumnChange(ColumnChangeType.DataTypeChanged, column1, column2));
            }

            if (column1.Position != column2.Position)
            {
                // position changed
                AddColumnChange(column1.Schema, column1.Table, column1.Name, "Position changed from " + column2.Position + " to " + column1.Position,
                    new ColumnChange(ColumnChangeType.PositionChanged, column1, column2));
            }

            if (column1.Default != column2.Default)
            {
                // default value changed
                AddColumnChange(column1.Schema, column1.Table, column1.Name, "Default value changed to '" + (column1.Default == null ? "NULL" : column1.Default + "'"),
                    new ColumnChange(ColumnChangeType.DefaultValueChanged, column1, column2));
            }
        }

        #endregion

        #region Helper

        private bool IsSchemaExcluded(string schema)
        {
            if (_curentProfile == null)
                return false;

            foreach (var excludedSchema in _curentProfile.ExcludedSchemas)
            {
                if (schema.IndexOf(excludedSchema, StringComparison.OrdinalIgnoreCase) != -1)
                    return true;
            }

            return false;
        }

        private bool IsObjectExcluded(string name)
        {
            if (_curentProfile == null)
                return false;

            foreach (var excludedName in _curentProfile.ExcludedObjects)
            {
                if (name.IndexOf(excludedName, StringComparison.OrdinalIgnoreCase) != -1)
                    return true;
            }

            return false;
        }

        #endregion

        #region Database Methods

        private SqlConnection OpenConnection(string hostname, string username, string password, string database, bool integratedSecurity)
        {
            SqlConnection result;
            try
            {
                result = new SqlConnection();

                SqlConnectionStringBuilder srcConnectionString = new SqlConnectionStringBuilder();
                srcConnectionString.DataSource = hostname;
                srcConnectionString.UserID = username;
                srcConnectionString.Password = password;
                srcConnectionString.InitialCatalog = database;
                srcConnectionString.IntegratedSecurity = integratedSecurity;

                result.ConnectionString = srcConnectionString.ToString();

                result.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed:\n" + ex.Message);
                result = null;
            }

            return result;
        }

        private Dictionary<string, TableInfo> GetTableInfos(SqlConnection con)
        {
            Dictionary<string, TableInfo> result = new Dictionary<string, TableInfo>();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT TABLE_SCHEMA,TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_SCHEMA,TABLE_NAME", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TableInfo table = new TableInfo();
                        table.Schema = dr.GetString(0);
                        table.Name = dr.GetString(1);

                        if (!IsSchemaExcluded(table.Schema) && !IsObjectExcluded(table.Name))
                        {
                            result.Add(table.Schema + "." + table.Name, table);
                        }
                    }
                }
            }
            catch (Exception)
            { }

            return result;
        }

        private Dictionary<string, ViewInfo> GetViewInfos(SqlConnection con)
        {
            Dictionary<string, ViewInfo> result = new Dictionary<string, ViewInfo>();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT TABLE_SCHEMA, TABLE_NAME, VIEW_DEFINITION FROM INFORMATION_SCHEMA.VIEWS ORDER BY TABLE_SCHEMA,TABLE_NAME", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ViewInfo view = new ViewInfo();
                        view.Schema = dr.GetString(0);
                        view.Name = dr.GetString(1);
                        view.Definition = dr.GetString(2);

                        if (!IsSchemaExcluded(view.Schema) && !IsObjectExcluded(view.Name))
                        {
                            result.Add(view.Schema + "." + view.Name, view);
                        }
                    }
                }
            }
            catch (Exception)
            { }

            return result;
        }

        private Dictionary<string, ColumnInfo> GetColumnInfos(SqlConnection con)
        {
            Dictionary<string, ColumnInfo> result = new Dictionary<string, ColumnInfo>();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE,ISNULL(CHARACTER_MAXIMUM_LENGTH,0) AS [CHARACTER_MAXIMUM_LENGTH],IS_NULLABLE,ORDINAL_POSITION,ISNULL(COLUMN_DEFAULT,'') AS [COLUMN_DEFAULT] FROM INFORMATION_SCHEMA.COLUMNS ORDER BY TABLE_SCHEMA,TABLE_NAME", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ColumnInfo column = new ColumnInfo();
                        column.Schema = dr.GetString(0);
                        column.Table = dr.GetString(1);
                        column.Name = dr.GetString(2);
                        column.DataType = dr.GetString(3);
                        column.MaximumLength = dr.GetInt32(4);
                        column.IsNullable = dr.GetString(5).Equals("YES");
                        column.Position = dr.GetInt32(6);
                        column.Default = dr.GetString(7);

                        if (!IsSchemaExcluded(column.Schema) && !IsObjectExcluded(column.Name))
                        {
                            string columnName = column.Schema + "." + column.Table + "." + column.Name;
                            if (!result.ContainsKey(columnName))
                            {
                                result.Add(columnName, column);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        private Dictionary<string, RoutineInfo> GetRoutines(SqlConnection con)
        {
            Dictionary<string, RoutineInfo> result = new Dictionary<string, RoutineInfo>();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT ROUTINE_SCHEMA,ROUTINE_NAME,ROUTINE_TYPE,ROUTINE_DEFINITION,ROUTINE_BODY FROM INFORMATION_SCHEMA.ROUTINES ORDER BY ROUTINE_SCHEMA, ROUTINE_NAME", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RoutineInfo routine = new RoutineInfo();
                        routine.Schema = dr.GetString(0);
                        routine.Name = dr.GetString(1);
                        routine.Type = dr.GetString(2);
                        routine.Defination = dr.GetString(3);
                        routine.Body = dr.GetString(4);

                        if (!IsSchemaExcluded(routine.Schema) && !IsObjectExcluded(routine.Name))
                        {
                            string path = routine.Schema + "." + routine.Name;
                            if (!result.ContainsKey(path))
                            {
                                result.Add(path, routine);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        private Dictionary<string, TableConstraintInfo> GetTableConstraints(SqlConnection con)
        {
            Dictionary<string, TableConstraintInfo> result = new Dictionary<string, TableConstraintInfo>();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT CONSTRAINT_SCHEMA, CONSTRAINT_NAME, CONSTRAINT_TYPE, TABLE_SCHEMA, TABLE_NAME, IS_DEFERRABLE, INITIALLY_DEFERRED FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS  ORDER BY CONSTRAINT_SCHEMA, CONSTRAINT_NAME", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TableConstraintInfo info = new TableConstraintInfo();
                        info.ConstraintSchema = dr.GetString(0);
                        info.ConstraintName = dr.GetString(1);
                        info.ConstraintType = dr.GetString(2);
                        info.TableSchema = dr.GetString(3);
                        info.TableName = dr.GetString(4);
                        info.IsDeferrable = dr.GetString(5).Equals("YES", StringComparison.OrdinalIgnoreCase);
                        info.InitiallyDeferred = dr.GetString(6).Equals("YES", StringComparison.OrdinalIgnoreCase);

                        if (!IsSchemaExcluded(info.ConstraintSchema) && !IsObjectExcluded(info.ConstraintName))
                        {
                            string name = info.ConstraintSchema + "." + info.ConstraintName;
                            if (!result.ContainsKey(name))
                            {
                                result.Add(name, info);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        private Dictionary<string, ForeignKeyInformation> GetForeignKeys(SqlConnection con)
        {
            Dictionary<string, ForeignKeyInformation> result = new Dictionary<string, ForeignKeyInformation>();

            try
            {
                using (SqlCommand cmd = new SqlCommand("select c.TABLE_SCHEMA as tab_schema, c.TABLE_NAME as tab_name, c.CONSTRAINT_SCHEMA as fk_schema, c.CONSTRAINT_NAME as fk_name from INFORMATION_SCHEMA.TABLE_CONSTRAINTS c where CONSTRAINT_TYPE = 'FOREIGN KEY'"))
                {
                    cmd.Connection = con;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ForeignKeyInformation info = new ForeignKeyInformation();
                            info.Table_Schema = dr.GetString(0);
                            info.Table_Name = dr.GetString(1);
                            info.Key_Schema = dr.GetString(2);
                            info.Key_Name = dr.GetString(3);

                            if (!IsSchemaExcluded(info.Key_Schema) && !IsObjectExcluded(info.Table_Name))
                            {
                                string name = info.Table_Schema + "." + info.Table_Name + "." + info.Key_Name;
                                if (!result.ContainsKey(name))
                                {
                                    result.Add(name, info);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        private Dictionary<string, IndexInformation> GetIndizees(SqlConnection con)
        {
            Dictionary<string, IndexInformation> result = new Dictionary<string, IndexInformation>();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT s.name AS [Schema], t.name AS [Table], c.name AS [Column], i.name AS [Index], i.type AS [Type], i.is_unique AS [IsUnique], i.is_primary_key AS [IsPrimary] FROM sys.tables t, sys.indexes i, sys.index_columns ic, sys.columns c, sys.schemas s WHERE 1=1 AND t.object_id = i.object_id AND t.object_id = ic.object_id AND t.object_id = c.object_id AND i.index_id = ic.index_id AND ic.column_id = c.column_id AND t.schema_id = s.schema_id ORDER BY t.schema_id, t.name, c.name", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IndexInformation info = new IndexInformation();
                        info.Schema = dr.GetString(0);
                        info.Table = dr.GetString(1);
                        info.Column = dr.GetString(2);
                        info.Index = dr.GetString(3);
                        info.Type = dr.GetByte(4);
                        info.IsUnique = dr.GetBoolean(5);
                        info.IsPrimary = dr.GetBoolean(6);

                        if (!IsSchemaExcluded(info.Schema) && !IsObjectExcluded(info.Index))
                        {
                            string name = info.Schema + "." + info.Table + "." + info.Index;
                            if (!result.ContainsKey(name))
                            {
                                result.Add(name, info);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        #endregion
    }
}