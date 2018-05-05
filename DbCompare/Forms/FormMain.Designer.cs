namespace DbCompare.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.grpSourceDb = new System.Windows.Forms.GroupBox();
            this.tbxSrcDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbSrcIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxSourceHost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSourcePassword = new System.Windows.Forms.TextBox();
            this.tbxSourceUsername = new System.Windows.Forms.TextBox();
            this.grpTargetDb = new System.Windows.Forms.GroupBox();
            this.tbxTarDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbTargetIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxTargetHost = new System.Windows.Forms.TextBox();
            this.tbxTargetUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxTargetPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.lvwTableChanges = new System.Windows.Forms.ListView();
            this.clmnSchema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabViews = new System.Windows.Forms.TabPage();
            this.lvwViewsChanges = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabColumns = new System.Windows.Forms.TabPage();
            this.lvwColumns = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabIndexes = new System.Windows.Forms.TabPage();
            this.lvwIndizees = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabForeignKeys = new System.Windows.Forms.TabPage();
            this.lvwForeignKeys = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabRoutines = new System.Windows.Forms.TabPage();
            this.lvwRoutineChanges = new System.Windows.Forms.ListView();
            this.clmnRoutineSchema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnRoutineBody = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnRoutineName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnRoutineType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnRoutineAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProfiles = new System.Windows.Forms.Button();
            this.menuProfiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRoutines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniCompareRoutines = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miCreateRoutine = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdateRoutineSourceToTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdateRoutineTargetToSource = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteRoutine = new System.Windows.Forms.ToolStripMenuItem();
            this.bwCompare = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slState = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miColumnsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.Button();
            this.menuViews = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniCompareViews = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCompareViewsGap = new System.Windows.Forms.ToolStripSeparator();
            this.mniCreateView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdateTargetView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdateSourceView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDeleteView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProfile = new System.Windows.Forms.Button();
            this.grpSourceDb.SuspendLayout();
            this.grpTargetDb.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.tabViews.SuspendLayout();
            this.tabColumns.SuspendLayout();
            this.tabIndexes.SuspendLayout();
            this.tabForeignKeys.SuspendLayout();
            this.tabRoutines.SuspendLayout();
            this.menuProfiles.SuspendLayout();
            this.menuRoutines.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuColumns.SuspendLayout();
            this.menuViews.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSourceDb
            // 
            this.grpSourceDb.Controls.Add(this.tbxSrcDatabase);
            this.grpSourceDb.Controls.Add(this.label1);
            this.grpSourceDb.Controls.Add(this.chbSrcIntegratedSecurity);
            this.grpSourceDb.Controls.Add(this.label6);
            this.grpSourceDb.Controls.Add(this.tbxSourceHost);
            this.grpSourceDb.Controls.Add(this.label5);
            this.grpSourceDb.Controls.Add(this.label4);
            this.grpSourceDb.Controls.Add(this.tbxSourcePassword);
            this.grpSourceDb.Controls.Add(this.tbxSourceUsername);
            this.grpSourceDb.Location = new System.Drawing.Point(12, 12);
            this.grpSourceDb.Name = "grpSourceDb";
            this.grpSourceDb.Size = new System.Drawing.Size(285, 175);
            this.grpSourceDb.TabIndex = 0;
            this.grpSourceDb.TabStop = false;
            this.grpSourceDb.Text = "Source Database";
            // 
            // tbxSrcDatabase
            // 
            this.tbxSrcDatabase.Location = new System.Drawing.Point(14, 144);
            this.tbxSrcDatabase.Name = "tbxSrcDatabase";
            this.tbxSrcDatabase.Size = new System.Drawing.Size(250, 20);
            this.tbxSrcDatabase.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Database";
            // 
            // chbSrcIntegratedSecurity
            // 
            this.chbSrcIntegratedSecurity.AutoSize = true;
            this.chbSrcIntegratedSecurity.Location = new System.Drawing.Point(14, 105);
            this.chbSrcIntegratedSecurity.Name = "chbSrcIntegratedSecurity";
            this.chbSrcIntegratedSecurity.Size = new System.Drawing.Size(115, 17);
            this.chbSrcIntegratedSecurity.TabIndex = 5;
            this.chbSrcIntegratedSecurity.Text = "Integrated Security";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Passwort";
            // 
            // tbxSourceHost
            // 
            this.tbxSourceHost.Location = new System.Drawing.Point(14, 36);
            this.tbxSourceHost.Name = "tbxSourceHost";
            this.tbxSourceHost.Size = new System.Drawing.Size(250, 20);
            this.tbxSourceHost.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Benutzername";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Host";
            // 
            // tbxSourcePassword
            // 
            this.tbxSourcePassword.Location = new System.Drawing.Point(144, 79);
            this.tbxSourcePassword.Name = "tbxSourcePassword";
            this.tbxSourcePassword.Size = new System.Drawing.Size(120, 20);
            this.tbxSourcePassword.TabIndex = 3;
            this.tbxSourcePassword.UseSystemPasswordChar = true;
            // 
            // tbxSourceUsername
            // 
            this.tbxSourceUsername.Location = new System.Drawing.Point(14, 79);
            this.tbxSourceUsername.Name = "tbxSourceUsername";
            this.tbxSourceUsername.Size = new System.Drawing.Size(120, 20);
            this.tbxSourceUsername.TabIndex = 3;
            // 
            // grpTargetDb
            // 
            this.grpTargetDb.Controls.Add(this.tbxTarDatabase);
            this.grpTargetDb.Controls.Add(this.label2);
            this.grpTargetDb.Controls.Add(this.chbTargetIntegratedSecurity);
            this.grpTargetDb.Controls.Add(this.label9);
            this.grpTargetDb.Controls.Add(this.tbxTargetHost);
            this.grpTargetDb.Controls.Add(this.tbxTargetUsername);
            this.grpTargetDb.Controls.Add(this.label8);
            this.grpTargetDb.Controls.Add(this.tbxTargetPassword);
            this.grpTargetDb.Controls.Add(this.label7);
            this.grpTargetDb.Location = new System.Drawing.Point(308, 12);
            this.grpTargetDb.Name = "grpTargetDb";
            this.grpTargetDb.Size = new System.Drawing.Size(285, 175);
            this.grpTargetDb.TabIndex = 0;
            this.grpTargetDb.TabStop = false;
            this.grpTargetDb.Text = "Target Database";
            // 
            // tbxTarDatabase
            // 
            this.tbxTarDatabase.Location = new System.Drawing.Point(13, 144);
            this.tbxTarDatabase.Name = "tbxTarDatabase";
            this.tbxTarDatabase.Size = new System.Drawing.Size(250, 20);
            this.tbxTarDatabase.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Database";
            // 
            // chbTargetIntegratedSecurity
            // 
            this.chbTargetIntegratedSecurity.AutoSize = true;
            this.chbTargetIntegratedSecurity.Location = new System.Drawing.Point(13, 105);
            this.chbTargetIntegratedSecurity.Name = "chbTargetIntegratedSecurity";
            this.chbTargetIntegratedSecurity.Size = new System.Drawing.Size(115, 17);
            this.chbTargetIntegratedSecurity.TabIndex = 5;
            this.chbTargetIntegratedSecurity.Text = "Integrated Security";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Passwort";
            // 
            // tbxTargetHost
            // 
            this.tbxTargetHost.Location = new System.Drawing.Point(13, 36);
            this.tbxTargetHost.Name = "tbxTargetHost";
            this.tbxTargetHost.Size = new System.Drawing.Size(250, 20);
            this.tbxTargetHost.TabIndex = 2;
            // 
            // tbxTargetUsername
            // 
            this.tbxTargetUsername.Location = new System.Drawing.Point(13, 79);
            this.tbxTargetUsername.Name = "tbxTargetUsername";
            this.tbxTargetUsername.Size = new System.Drawing.Size(121, 20);
            this.tbxTargetUsername.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Benutzername";
            // 
            // tbxTargetPassword
            // 
            this.tbxTargetPassword.Location = new System.Drawing.Point(144, 79);
            this.tbxTargetPassword.Name = "tbxTargetPassword";
            this.tbxTargetPassword.Size = new System.Drawing.Size(120, 20);
            this.tbxTargetPassword.TabIndex = 3;
            this.tbxTargetPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Host";
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Location = new System.Drawing.Point(606, 159);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(166, 28);
            this.btnCompare.TabIndex = 1;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabTables);
            this.tabControl1.Controls.Add(this.tabViews);
            this.tabControl1.Controls.Add(this.tabColumns);
            this.tabControl1.Controls.Add(this.tabIndexes);
            this.tabControl1.Controls.Add(this.tabForeignKeys);
            this.tabControl1.Controls.Add(this.tabRoutines);
            this.tabControl1.Location = new System.Drawing.Point(12, 198);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 327);
            this.tabControl1.TabIndex = 2;
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.lvwTableChanges);
            this.tabTables.Location = new System.Drawing.Point(4, 22);
            this.tabTables.Name = "tabTables";
            this.tabTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabTables.Size = new System.Drawing.Size(752, 301);
            this.tabTables.TabIndex = 0;
            this.tabTables.Text = "Tables";
            this.tabTables.UseVisualStyleBackColor = true;
            // 
            // lvwTableChanges
            // 
            this.lvwTableChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnSchema,
            this.clmnTable,
            this.clmnAction});
            this.lvwTableChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTableChanges.FullRowSelect = true;
            this.lvwTableChanges.GridLines = true;
            this.lvwTableChanges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwTableChanges.HideSelection = false;
            this.lvwTableChanges.Location = new System.Drawing.Point(3, 3);
            this.lvwTableChanges.Name = "lvwTableChanges";
            this.lvwTableChanges.Size = new System.Drawing.Size(746, 295);
            this.lvwTableChanges.TabIndex = 0;
            this.lvwTableChanges.UseCompatibleStateImageBehavior = false;
            this.lvwTableChanges.View = System.Windows.Forms.View.Details;
            // 
            // clmnSchema
            // 
            this.clmnSchema.Text = "Schema";
            this.clmnSchema.Width = 118;
            // 
            // clmnTable
            // 
            this.clmnTable.Text = "Table";
            this.clmnTable.Width = 361;
            // 
            // clmnAction
            // 
            this.clmnAction.Text = "Action";
            this.clmnAction.Width = 218;
            // 
            // tabViews
            // 
            this.tabViews.Controls.Add(this.lvwViewsChanges);
            this.tabViews.Location = new System.Drawing.Point(4, 22);
            this.tabViews.Name = "tabViews";
            this.tabViews.Padding = new System.Windows.Forms.Padding(3);
            this.tabViews.Size = new System.Drawing.Size(752, 305);
            this.tabViews.TabIndex = 5;
            this.tabViews.Text = "Views";
            this.tabViews.UseVisualStyleBackColor = true;
            // 
            // lvwViewsChanges
            // 
            this.lvwViewsChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader15,
            this.columnHeader16});
            this.lvwViewsChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwViewsChanges.FullRowSelect = true;
            this.lvwViewsChanges.GridLines = true;
            this.lvwViewsChanges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwViewsChanges.HideSelection = false;
            this.lvwViewsChanges.Location = new System.Drawing.Point(3, 3);
            this.lvwViewsChanges.Name = "lvwViewsChanges";
            this.lvwViewsChanges.Size = new System.Drawing.Size(746, 299);
            this.lvwViewsChanges.TabIndex = 1;
            this.lvwViewsChanges.UseCompatibleStateImageBehavior = false;
            this.lvwViewsChanges.View = System.Windows.Forms.View.Details;
            this.lvwViewsChanges.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwViewsChanges_MouseUp);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Schema";
            this.columnHeader12.Width = 118;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Table";
            this.columnHeader15.Width = 361;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Action";
            this.columnHeader16.Width = 218;
            // 
            // tabColumns
            // 
            this.tabColumns.Controls.Add(this.lvwColumns);
            this.tabColumns.Location = new System.Drawing.Point(4, 22);
            this.tabColumns.Name = "tabColumns";
            this.tabColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tabColumns.Size = new System.Drawing.Size(752, 305);
            this.tabColumns.TabIndex = 3;
            this.tabColumns.Text = "Columns";
            this.tabColumns.UseVisualStyleBackColor = true;
            // 
            // lvwColumns
            // 
            this.lvwColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvwColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwColumns.FullRowSelect = true;
            this.lvwColumns.GridLines = true;
            this.lvwColumns.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwColumns.HideSelection = false;
            this.lvwColumns.Location = new System.Drawing.Point(3, 3);
            this.lvwColumns.Name = "lvwColumns";
            this.lvwColumns.Size = new System.Drawing.Size(746, 299);
            this.lvwColumns.TabIndex = 1;
            this.lvwColumns.UseCompatibleStateImageBehavior = false;
            this.lvwColumns.View = System.Windows.Forms.View.Details;
            this.lvwColumns.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwColumns_MouseUp);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Schema";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Table";
            this.columnHeader7.Width = 250;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Column";
            this.columnHeader8.Width = 180;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Action";
            this.columnHeader9.Width = 180;
            // 
            // tabIndexes
            // 
            this.tabIndexes.Controls.Add(this.lvwIndizees);
            this.tabIndexes.Location = new System.Drawing.Point(4, 22);
            this.tabIndexes.Name = "tabIndexes";
            this.tabIndexes.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndexes.Size = new System.Drawing.Size(752, 305);
            this.tabIndexes.TabIndex = 2;
            this.tabIndexes.Text = "Indexes";
            this.tabIndexes.UseVisualStyleBackColor = true;
            // 
            // lvwIndizees
            // 
            this.lvwIndizees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4});
            this.lvwIndizees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwIndizees.FullRowSelect = true;
            this.lvwIndizees.GridLines = true;
            this.lvwIndizees.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwIndizees.HideSelection = false;
            this.lvwIndizees.Location = new System.Drawing.Point(3, 3);
            this.lvwIndizees.Name = "lvwIndizees";
            this.lvwIndizees.Size = new System.Drawing.Size(746, 299);
            this.lvwIndizees.TabIndex = 1;
            this.lvwIndizees.UseCompatibleStateImageBehavior = false;
            this.lvwIndizees.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Schema";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Table";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Column";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Index";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Action";
            this.columnHeader4.Width = 150;
            // 
            // tabForeignKeys
            // 
            this.tabForeignKeys.Controls.Add(this.lvwForeignKeys);
            this.tabForeignKeys.Location = new System.Drawing.Point(4, 22);
            this.tabForeignKeys.Name = "tabForeignKeys";
            this.tabForeignKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabForeignKeys.Size = new System.Drawing.Size(752, 305);
            this.tabForeignKeys.TabIndex = 4;
            this.tabForeignKeys.Text = "Foreign keys";
            this.tabForeignKeys.UseVisualStyleBackColor = true;
            // 
            // lvwForeignKeys
            // 
            this.lvwForeignKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader14});
            this.lvwForeignKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwForeignKeys.FullRowSelect = true;
            this.lvwForeignKeys.GridLines = true;
            this.lvwForeignKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwForeignKeys.HideSelection = false;
            this.lvwForeignKeys.Location = new System.Drawing.Point(3, 3);
            this.lvwForeignKeys.Name = "lvwForeignKeys";
            this.lvwForeignKeys.Size = new System.Drawing.Size(746, 299);
            this.lvwForeignKeys.TabIndex = 2;
            this.lvwForeignKeys.UseCompatibleStateImageBehavior = false;
            this.lvwForeignKeys.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Schema";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Table";
            this.columnHeader11.Width = 180;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Index";
            this.columnHeader13.Width = 280;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Action";
            this.columnHeader14.Width = 150;
            // 
            // tabRoutines
            // 
            this.tabRoutines.Controls.Add(this.lvwRoutineChanges);
            this.tabRoutines.Location = new System.Drawing.Point(4, 22);
            this.tabRoutines.Name = "tabRoutines";
            this.tabRoutines.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoutines.Size = new System.Drawing.Size(752, 305);
            this.tabRoutines.TabIndex = 1;
            this.tabRoutines.Text = "Routines";
            this.tabRoutines.UseVisualStyleBackColor = true;
            // 
            // lvwRoutineChanges
            // 
            this.lvwRoutineChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnRoutineSchema,
            this.clmnRoutineBody,
            this.clmnRoutineName,
            this.clmnRoutineType,
            this.clmnRoutineAction});
            this.lvwRoutineChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwRoutineChanges.FullRowSelect = true;
            this.lvwRoutineChanges.GridLines = true;
            this.lvwRoutineChanges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwRoutineChanges.HideSelection = false;
            this.lvwRoutineChanges.Location = new System.Drawing.Point(3, 3);
            this.lvwRoutineChanges.Name = "lvwRoutineChanges";
            this.lvwRoutineChanges.Size = new System.Drawing.Size(746, 299);
            this.lvwRoutineChanges.TabIndex = 1;
            this.lvwRoutineChanges.UseCompatibleStateImageBehavior = false;
            this.lvwRoutineChanges.View = System.Windows.Forms.View.Details;
            this.lvwRoutineChanges.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwRoutineChanges_MouseUp);
            // 
            // clmnRoutineSchema
            // 
            this.clmnRoutineSchema.Text = "Schema";
            this.clmnRoutineSchema.Width = 80;
            // 
            // clmnRoutineBody
            // 
            this.clmnRoutineBody.Text = "Body";
            this.clmnRoutineBody.Width = 120;
            // 
            // clmnRoutineName
            // 
            this.clmnRoutineName.Text = "Name";
            this.clmnRoutineName.Width = 200;
            // 
            // clmnRoutineType
            // 
            this.clmnRoutineType.Text = "Type";
            this.clmnRoutineType.Width = 120;
            // 
            // clmnRoutineAction
            // 
            this.clmnRoutineAction.Text = "Action";
            this.clmnRoutineAction.Width = 180;
            // 
            // btnProfiles
            // 
            this.btnProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfiles.Location = new System.Drawing.Point(606, 89);
            this.btnProfiles.Name = "btnProfiles";
            this.btnProfiles.Size = new System.Drawing.Size(166, 28);
            this.btnProfiles.TabIndex = 1;
            this.btnProfiles.Text = "Profiles";
            this.btnProfiles.UseVisualStyleBackColor = true;
            this.btnProfiles.Click += new System.EventHandler(this.btnProfiles_Click);
            // 
            // menuProfiles
            // 
            this.menuProfiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSave,
            this.toolStripMenuItem2});
            this.menuProfiles.Name = "menuProfiles";
            this.menuProfiles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuProfiles.Size = new System.Drawing.Size(99, 32);
            this.menuProfiles.Opening += new System.ComponentModel.CancelEventHandler(this.menuProfiles_Opening);
            // 
            // mniSave
            // 
            this.mniSave.Name = "mniSave";
            this.mniSave.Size = new System.Drawing.Size(98, 22);
            this.mniSave.Text = "&Save";
            this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(95, 6);
            // 
            // menuRoutines
            // 
            this.menuRoutines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCompareRoutines,
            this.toolStripMenuItem1,
            this.miCreateRoutine,
            this.miUpdateRoutineSourceToTarget,
            this.miUpdateRoutineTargetToSource,
            this.miDeleteRoutine});
            this.menuRoutines.Name = "menuRoutines";
            this.menuRoutines.Size = new System.Drawing.Size(212, 120);
            // 
            // mniCompareRoutines
            // 
            this.mniCompareRoutines.Name = "mniCompareRoutines";
            this.mniCompareRoutines.Size = new System.Drawing.Size(211, 22);
            this.mniCompareRoutines.Text = "Com&pare";
            this.mniCompareRoutines.Click += new System.EventHandler(this.mniCompareRoutines_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // miCreateRoutine
            // 
            this.miCreateRoutine.Name = "miCreateRoutine";
            this.miCreateRoutine.Size = new System.Drawing.Size(211, 22);
            this.miCreateRoutine.Text = "&Create";
            this.miCreateRoutine.Click += new System.EventHandler(this.miCreateRoutine_Click);
            // 
            // miUpdateRoutineSourceToTarget
            // 
            this.miUpdateRoutineSourceToTarget.Name = "miUpdateRoutineSourceToTarget";
            this.miUpdateRoutineSourceToTarget.Size = new System.Drawing.Size(211, 22);
            this.miUpdateRoutineSourceToTarget.Text = "Update - Source -> Target";
            this.miUpdateRoutineSourceToTarget.Click += new System.EventHandler(this.miUpdateRoutineSourceToTarget_Click);
            // 
            // miUpdateRoutineTargetToSource
            // 
            this.miUpdateRoutineTargetToSource.Name = "miUpdateRoutineTargetToSource";
            this.miUpdateRoutineTargetToSource.Size = new System.Drawing.Size(211, 22);
            this.miUpdateRoutineTargetToSource.Text = "Update - Target -> Source";
            this.miUpdateRoutineTargetToSource.Click += new System.EventHandler(this.miUpdateRoutineTargetToSource_Click);
            // 
            // miDeleteRoutine
            // 
            this.miDeleteRoutine.Name = "miDeleteRoutine";
            this.miDeleteRoutine.Size = new System.Drawing.Size(211, 22);
            this.miDeleteRoutine.Text = "&Delete";
            this.miDeleteRoutine.Click += new System.EventHandler(this.miDeleteRoutine_Click);
            // 
            // bwCompare
            // 
            this.bwCompare.WorkerReportsProgress = true;
            this.bwCompare.WorkerSupportsCancellation = true;
            this.bwCompare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCompare_DoWork);
            this.bwCompare.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCompare_ProgressChanged);
            this.bwCompare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCompare_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slState
            // 
            this.slState.Name = "slState";
            this.slState.Size = new System.Drawing.Size(41, 17);
            this.slState.Text = "[State]";
            // 
            // menuColumns
            // 
            this.menuColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miColumnsUpdate});
            this.menuColumns.Name = "menuColumns";
            this.menuColumns.Size = new System.Drawing.Size(113, 26);
            // 
            // miColumnsUpdate
            // 
            this.miColumnsUpdate.Name = "miColumnsUpdate";
            this.miColumnsUpdate.Size = new System.Drawing.Size(112, 22);
            this.miColumnsUpdate.Text = "Update";
            this.miColumnsUpdate.Click += new System.EventHandler(this.miColumnsUpdate_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(606, 50);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(166, 28);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // menuViews
            // 
            this.menuViews.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCompareViews,
            this.mniCompareViewsGap,
            this.mniCreateView,
            this.mniUpdateTargetView,
            this.mniUpdateSourceView,
            this.mniDeleteView});
            this.menuViews.Name = "menuViews";
            this.menuViews.Size = new System.Drawing.Size(212, 120);
            this.menuViews.Opening += new System.ComponentModel.CancelEventHandler(this.menuViews_Opening);
            // 
            // mniCompareViews
            // 
            this.mniCompareViews.Name = "mniCompareViews";
            this.mniCompareViews.Size = new System.Drawing.Size(211, 22);
            this.mniCompareViews.Text = "Compare";
            this.mniCompareViews.Click += new System.EventHandler(this.mniCompareViews_Click);
            // 
            // mniCompareViewsGap
            // 
            this.mniCompareViewsGap.Name = "mniCompareViewsGap";
            this.mniCompareViewsGap.Size = new System.Drawing.Size(208, 6);
            // 
            // mniCreateView
            // 
            this.mniCreateView.Name = "mniCreateView";
            this.mniCreateView.Size = new System.Drawing.Size(211, 22);
            this.mniCreateView.Text = "&Create";
            this.mniCreateView.Click += new System.EventHandler(this.mniCreateView_Click);
            // 
            // mniUpdateTargetView
            // 
            this.mniUpdateTargetView.Name = "mniUpdateTargetView";
            this.mniUpdateTargetView.Size = new System.Drawing.Size(211, 22);
            this.mniUpdateTargetView.Text = "Update - Source -> Target";
            this.mniUpdateTargetView.Click += new System.EventHandler(this.mniUpdateTargetView_Click);
            // 
            // mniUpdateSourceView
            // 
            this.mniUpdateSourceView.Name = "mniUpdateSourceView";
            this.mniUpdateSourceView.Size = new System.Drawing.Size(211, 22);
            this.mniUpdateSourceView.Text = "Update - Target -> Source";
            this.mniUpdateSourceView.Click += new System.EventHandler(this.mniUpdateSourceView_Click);
            // 
            // mniDeleteView
            // 
            this.mniDeleteView.Name = "mniDeleteView";
            this.mniDeleteView.Size = new System.Drawing.Size(211, 22);
            this.mniDeleteView.Text = "&Delete";
            this.mniDeleteView.Click += new System.EventHandler(this.mniDeleteView_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfile.Location = new System.Drawing.Point(606, 120);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(166, 28);
            this.btnProfile.TabIndex = 6;
            this.btnProfile.Text = "Profile settings";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnProfiles);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.grpSourceDb);
            this.Controls.Add(this.grpTargetDb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL-Server Database-Compare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.grpSourceDb.ResumeLayout(false);
            this.grpSourceDb.PerformLayout();
            this.grpTargetDb.ResumeLayout(false);
            this.grpTargetDb.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabTables.ResumeLayout(false);
            this.tabViews.ResumeLayout(false);
            this.tabColumns.ResumeLayout(false);
            this.tabIndexes.ResumeLayout(false);
            this.tabForeignKeys.ResumeLayout(false);
            this.tabRoutines.ResumeLayout(false);
            this.menuProfiles.ResumeLayout(false);
            this.menuRoutines.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuColumns.ResumeLayout(false);
            this.menuViews.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSourceDb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxSourceHost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxSourcePassword;
        private System.Windows.Forms.TextBox tbxSourceUsername;
        private System.Windows.Forms.GroupBox grpTargetDb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxTargetHost;
        private System.Windows.Forms.TextBox tbxTargetUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxTargetPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTables;
        private System.Windows.Forms.TabPage tabRoutines;
        private System.Windows.Forms.ListView lvwTableChanges;
        private System.Windows.Forms.ColumnHeader clmnTable;
        private System.Windows.Forms.ColumnHeader clmnAction;
        private System.Windows.Forms.CheckBox chbSrcIntegratedSecurity;
        private System.Windows.Forms.CheckBox chbTargetIntegratedSecurity;
        private System.Windows.Forms.TextBox tbxSrcDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTarDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader clmnSchema;
        private System.Windows.Forms.ListView lvwRoutineChanges;
        private System.Windows.Forms.ColumnHeader clmnRoutineSchema;
        private System.Windows.Forms.ColumnHeader clmnRoutineBody;
        private System.Windows.Forms.ColumnHeader clmnRoutineName;
        private System.Windows.Forms.ColumnHeader clmnRoutineAction;
        private System.Windows.Forms.ColumnHeader clmnRoutineType;
        private System.Windows.Forms.Button btnProfiles;
        private System.Windows.Forms.ContextMenuStrip menuProfiles;
        private System.Windows.Forms.ToolStripMenuItem mniSave;
        private System.Windows.Forms.ContextMenuStrip menuRoutines;
        private System.Windows.Forms.ToolStripMenuItem miCreateRoutine;
        private System.Windows.Forms.ToolStripMenuItem miUpdateRoutineSourceToTarget;
        private System.Windows.Forms.ToolStripMenuItem miDeleteRoutine;
        private System.ComponentModel.BackgroundWorker bwCompare;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slState;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.TabPage tabIndexes;
        private System.Windows.Forms.ListView lvwIndizees;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabColumns;
        private System.Windows.Forms.ListView lvwColumns;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ContextMenuStrip menuColumns;
        private System.Windows.Forms.ToolStripMenuItem miColumnsUpdate;
        private System.Windows.Forms.ToolStripMenuItem miUpdateRoutineTargetToSource;
        private System.Windows.Forms.TabPage tabForeignKeys;
        private System.Windows.Forms.ListView lvwForeignKeys;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ToolStripMenuItem mniCompareRoutines;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TabPage tabViews;
        private System.Windows.Forms.ListView lvwViewsChanges;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ContextMenuStrip menuViews;
        private System.Windows.Forms.ToolStripMenuItem mniCompareViews;
        private System.Windows.Forms.ToolStripSeparator mniCompareViewsGap;
        private System.Windows.Forms.ToolStripMenuItem mniCreateView;
        private System.Windows.Forms.ToolStripMenuItem mniUpdateTargetView;
        private System.Windows.Forms.ToolStripMenuItem mniUpdateSourceView;
        private System.Windows.Forms.ToolStripMenuItem mniDeleteView;
        private System.Windows.Forms.Button btnProfile;
    }
}

