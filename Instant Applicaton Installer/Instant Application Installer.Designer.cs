namespace InstantApplicationInstaller
{
    partial class frmApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApplication));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBasicApp = new System.Windows.Forms.TabPage();
            this.txtBasicSearch = new System.Windows.Forms.TextBox();
            this.btnSelectAllBasic = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnInstallBasic = new System.Windows.Forms.Button();
            this.chkListBasicApps = new System.Windows.Forms.CheckedListBox();
            this.tabAdvancedApp = new System.Windows.Forms.TabPage();
            this.txtAdvancedSearch = new System.Windows.Forms.TextBox();
            this.btnSelectAllAdvanced = new System.Windows.Forms.Button();
            this.btnUnselectAllAdvanced = new System.Windows.Forms.Button();
            this.btnInstallAdvanced = new System.Windows.Forms.Button();
            this.chkListAdvancedApps = new System.Windows.Forms.CheckedListBox();
            this.tabAddedApp = new System.Windows.Forms.TabPage();
            this.grbAppType = new System.Windows.Forms.GroupBox();
            this.rdBasicApp = new System.Windows.Forms.RadioButton();
            this.rdAdvanceApp = new System.Windows.Forms.RadioButton();
            this.lstAddedApps = new System.Windows.Forms.ListView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.tabGoogleSearch = new System.Windows.Forms.TabPage();
            this.lstSearchResults = new System.Windows.Forms.ListView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtGoogleSearch = new System.Windows.Forms.TextBox();
            this.tabCopier = new System.Windows.Forms.TabPage();
            this.chkSelectSubFolders = new System.Windows.Forms.CheckBox();
            this.btnSelectAllFolder = new System.Windows.Forms.Button();
            this.btnUnselectAllFolder = new System.Windows.Forms.Button();
            this.chkListSourceFolder = new System.Windows.Forms.CheckedListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fldBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabBasicApp.SuspendLayout();
            this.tabAdvancedApp.SuspendLayout();
            this.tabAddedApp.SuspendLayout();
            this.grbAppType.SuspendLayout();
            this.tabGoogleSearch.SuspendLayout();
            this.tabCopier.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBasicApp);
            this.tabControl1.Controls.Add(this.tabAdvancedApp);
            this.tabControl1.Controls.Add(this.tabAddedApp);
            this.tabControl1.Controls.Add(this.tabGoogleSearch);
            this.tabControl1.Controls.Add(this.tabCopier);
            this.tabControl1.Location = new System.Drawing.Point(-2, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 623);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabBasicApp
            // 
            this.tabBasicApp.Controls.Add(this.txtBasicSearch);
            this.tabBasicApp.Controls.Add(this.btnSelectAllBasic);
            this.tabBasicApp.Controls.Add(this.btnUnselectAll);
            this.tabBasicApp.Controls.Add(this.btnInstallBasic);
            this.tabBasicApp.Controls.Add(this.chkListBasicApps);
            this.tabBasicApp.Location = new System.Drawing.Point(4, 24);
            this.tabBasicApp.Name = "tabBasicApp";
            this.tabBasicApp.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasicApp.Size = new System.Drawing.Size(776, 595);
            this.tabBasicApp.TabIndex = 0;
            this.tabBasicApp.Text = "Basic Applications";
            this.tabBasicApp.UseVisualStyleBackColor = true;
            // 
            // txtBasicSearch
            // 
            this.txtBasicSearch.Location = new System.Drawing.Point(14, 16);
            this.txtBasicSearch.Name = "txtBasicSearch";
            this.txtBasicSearch.Size = new System.Drawing.Size(632, 21);
            this.txtBasicSearch.TabIndex = 5;
            this.txtBasicSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBasicSearch_KeyUp);
            // 
            // btnSelectAllBasic
            // 
            this.btnSelectAllBasic.Location = new System.Drawing.Point(663, 15);
            this.btnSelectAllBasic.Name = "btnSelectAllBasic";
            this.btnSelectAllBasic.Size = new System.Drawing.Size(93, 23);
            this.btnSelectAllBasic.TabIndex = 2;
            this.btnSelectAllBasic.Text = "Select all";
            this.btnSelectAllBasic.UseVisualStyleBackColor = true;
            this.btnSelectAllBasic.Click += new System.EventHandler(this.btnSelectAllBasic_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Location = new System.Drawing.Point(663, 49);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(93, 23);
            this.btnUnselectAll.TabIndex = 3;
            this.btnUnselectAll.Text = "Unselect all";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAllBasic_Click);
            // 
            // btnInstallBasic
            // 
            this.btnInstallBasic.Location = new System.Drawing.Point(663, 83);
            this.btnInstallBasic.Name = "btnInstallBasic";
            this.btnInstallBasic.Size = new System.Drawing.Size(93, 23);
            this.btnInstallBasic.TabIndex = 4;
            this.btnInstallBasic.Text = "Install";
            this.btnInstallBasic.UseVisualStyleBackColor = true;
            this.btnInstallBasic.Click += new System.EventHandler(this.btnInstallBasic_Click);
            // 
            // chkListBasicApps
            // 
            this.chkListBasicApps.FormattingEnabled = true;
            this.chkListBasicApps.HorizontalScrollbar = true;
            this.chkListBasicApps.Location = new System.Drawing.Point(14, 50);
            this.chkListBasicApps.Name = "chkListBasicApps";
            this.chkListBasicApps.Size = new System.Drawing.Size(632, 516);
            this.chkListBasicApps.Sorted = true;
            this.chkListBasicApps.TabIndex = 1;
            this.chkListBasicApps.TabStop = false;
            this.chkListBasicApps.UseCompatibleTextRendering = true;
            this.chkListBasicApps.SelectedIndexChanged += new System.EventHandler(this.chkListBasicApps_SelectedIndexChanged);
            // 
            // tabAdvancedApp
            // 
            this.tabAdvancedApp.Controls.Add(this.txtAdvancedSearch);
            this.tabAdvancedApp.Controls.Add(this.btnSelectAllAdvanced);
            this.tabAdvancedApp.Controls.Add(this.btnUnselectAllAdvanced);
            this.tabAdvancedApp.Controls.Add(this.btnInstallAdvanced);
            this.tabAdvancedApp.Controls.Add(this.chkListAdvancedApps);
            this.tabAdvancedApp.Location = new System.Drawing.Point(4, 24);
            this.tabAdvancedApp.Name = "tabAdvancedApp";
            this.tabAdvancedApp.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvancedApp.Size = new System.Drawing.Size(776, 595);
            this.tabAdvancedApp.TabIndex = 1;
            this.tabAdvancedApp.Text = "Advance Application";
            this.tabAdvancedApp.UseVisualStyleBackColor = true;
            // 
            // txtAdvancedSearch
            // 
            this.txtAdvancedSearch.Location = new System.Drawing.Point(14, 16);
            this.txtAdvancedSearch.Name = "txtAdvancedSearch";
            this.txtAdvancedSearch.Size = new System.Drawing.Size(632, 21);
            this.txtAdvancedSearch.TabIndex = 6;
            this.txtAdvancedSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAdvancedSearch_KeyUp);
            // 
            // btnSelectAllAdvanced
            // 
            this.btnSelectAllAdvanced.Location = new System.Drawing.Point(663, 15);
            this.btnSelectAllAdvanced.Name = "btnSelectAllAdvanced";
            this.btnSelectAllAdvanced.Size = new System.Drawing.Size(93, 23);
            this.btnSelectAllAdvanced.TabIndex = 2;
            this.btnSelectAllAdvanced.Text = "Select all";
            this.btnSelectAllAdvanced.UseVisualStyleBackColor = true;
            this.btnSelectAllAdvanced.Click += new System.EventHandler(this.btnSelectAllAdvanced_Click);
            // 
            // btnUnselectAllAdvanced
            // 
            this.btnUnselectAllAdvanced.Location = new System.Drawing.Point(663, 49);
            this.btnUnselectAllAdvanced.Name = "btnUnselectAllAdvanced";
            this.btnUnselectAllAdvanced.Size = new System.Drawing.Size(93, 23);
            this.btnUnselectAllAdvanced.TabIndex = 3;
            this.btnUnselectAllAdvanced.Text = "Unselect all";
            this.btnUnselectAllAdvanced.UseVisualStyleBackColor = true;
            this.btnUnselectAllAdvanced.Click += new System.EventHandler(this.btnUnselectAllAdvanced_Click);
            // 
            // btnInstallAdvanced
            // 
            this.btnInstallAdvanced.Location = new System.Drawing.Point(663, 83);
            this.btnInstallAdvanced.Name = "btnInstallAdvanced";
            this.btnInstallAdvanced.Size = new System.Drawing.Size(93, 23);
            this.btnInstallAdvanced.TabIndex = 4;
            this.btnInstallAdvanced.Text = "Install";
            this.btnInstallAdvanced.UseVisualStyleBackColor = true;
            this.btnInstallAdvanced.Click += new System.EventHandler(this.btnInstallAdvanced_Click);
            // 
            // chkListAdvancedApps
            // 
            this.chkListAdvancedApps.FormattingEnabled = true;
            this.chkListAdvancedApps.HorizontalScrollbar = true;
            this.chkListAdvancedApps.Location = new System.Drawing.Point(14, 50);
            this.chkListAdvancedApps.Name = "chkListAdvancedApps";
            this.chkListAdvancedApps.Size = new System.Drawing.Size(632, 516);
            this.chkListAdvancedApps.Sorted = true;
            this.chkListAdvancedApps.TabIndex = 1;
            this.chkListAdvancedApps.UseCompatibleTextRendering = true;
            this.chkListAdvancedApps.SelectedIndexChanged += new System.EventHandler(this.chkListAdvancedApps_SelectedIndexChanged);
            // 
            // tabAddedApp
            // 
            this.tabAddedApp.Controls.Add(this.grbAppType);
            this.tabAddedApp.Controls.Add(this.lstAddedApps);
            this.tabAddedApp.Controls.Add(this.btnRemove);
            this.tabAddedApp.Controls.Add(this.btnReset);
            this.tabAddedApp.Controls.Add(this.btnAdd);
            this.tabAddedApp.Controls.Add(this.btnBrowseFile);
            this.tabAddedApp.Controls.Add(this.btnBrowse);
            this.tabAddedApp.Controls.Add(this.txtAppName);
            this.tabAddedApp.Controls.Add(this.txtFile);
            this.tabAddedApp.Controls.Add(this.label3);
            this.tabAddedApp.Controls.Add(this.label2);
            this.tabAddedApp.Controls.Add(this.label1);
            this.tabAddedApp.Controls.Add(this.txtFolder);
            this.tabAddedApp.Controls.Add(this.lblFolder);
            this.tabAddedApp.Location = new System.Drawing.Point(4, 24);
            this.tabAddedApp.Name = "tabAddedApp";
            this.tabAddedApp.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddedApp.Size = new System.Drawing.Size(776, 595);
            this.tabAddedApp.TabIndex = 2;
            this.tabAddedApp.Text = "Add Applications";
            this.tabAddedApp.UseVisualStyleBackColor = true;
            // 
            // grbAppType
            // 
            this.grbAppType.Controls.Add(this.rdBasicApp);
            this.grbAppType.Controls.Add(this.rdAdvanceApp);
            this.grbAppType.Location = new System.Drawing.Point(642, 126);
            this.grbAppType.Name = "grbAppType";
            this.grbAppType.Size = new System.Drawing.Size(114, 83);
            this.grbAppType.TabIndex = 4;
            this.grbAppType.TabStop = false;
            this.grbAppType.Text = "Application Type";
            // 
            // rdBasicApp
            // 
            this.rdBasicApp.AutoSize = true;
            this.rdBasicApp.Checked = true;
            this.rdBasicApp.Location = new System.Drawing.Point(10, 25);
            this.rdBasicApp.Name = "rdBasicApp";
            this.rdBasicApp.Size = new System.Drawing.Size(56, 19);
            this.rdBasicApp.TabIndex = 5;
            this.rdBasicApp.TabStop = true;
            this.rdBasicApp.Text = "Basic";
            this.rdBasicApp.UseVisualStyleBackColor = true;
            this.rdBasicApp.CheckedChanged += new System.EventHandler(this.rdBasicApp_CheckedChanged);
            // 
            // rdAdvanceApp
            // 
            this.rdAdvanceApp.AutoSize = true;
            this.rdAdvanceApp.Location = new System.Drawing.Point(10, 49);
            this.rdAdvanceApp.Name = "rdAdvanceApp";
            this.rdAdvanceApp.Size = new System.Drawing.Size(78, 19);
            this.rdAdvanceApp.TabIndex = 6;
            this.rdAdvanceApp.Text = "Advanced";
            this.rdAdvanceApp.UseVisualStyleBackColor = true;
            this.rdAdvanceApp.CheckedChanged += new System.EventHandler(this.rdAdvanceApp_CheckedChanged);
            // 
            // lstAddedApps
            // 
            this.lstAddedApps.FullRowSelect = true;
            this.lstAddedApps.GridLines = true;
            this.lstAddedApps.Location = new System.Drawing.Point(15, 129);
            this.lstAddedApps.Name = "lstAddedApps";
            this.lstAddedApps.ShowGroups = false;
            this.lstAddedApps.Size = new System.Drawing.Size(610, 437);
            this.lstAddedApps.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstAddedApps.TabIndex = 8;
            this.lstAddedApps.UseCompatibleStateImageBehavior = false;
            this.lstAddedApps.View = System.Windows.Forms.View.Details;
            this.lstAddedApps.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstAddedApps_ColumnClick);
            this.lstAddedApps.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lstAddedApps_ItemMouseHover);
            this.lstAddedApps.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstAddedApps_ItemSelectionChanged);
            this.lstAddedApps.Leave += new System.EventHandler(this.lstAddedApps_Leave);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(642, 224);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(114, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(544, 92);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(81, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(642, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFile.Location = new System.Drawing.Point(643, 55);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(113, 23);
            this.btnBrowseFile.TabIndex = 2;
            this.btnBrowseFile.Text = "Browse...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(643, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(113, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(95, 93);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(443, 21);
            this.txtAppName.TabIndex = 1;
            this.txtAppName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAppName_KeyUp);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(95, 56);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(530, 21);
            this.txtFile.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Display name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Or";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select file";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(95, 18);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(530, 21);
            this.txtFolder.TabIndex = 1;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolder.Location = new System.Drawing.Point(11, 20);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(75, 15);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "Select folder";
            // 
            // tabGoogleSearch
            // 
            this.tabGoogleSearch.Controls.Add(this.lstSearchResults);
            this.tabGoogleSearch.Controls.Add(this.btnClear);
            this.tabGoogleSearch.Controls.Add(this.btnSearch);
            this.tabGoogleSearch.Controls.Add(this.txtGoogleSearch);
            this.tabGoogleSearch.Location = new System.Drawing.Point(4, 24);
            this.tabGoogleSearch.Name = "tabGoogleSearch";
            this.tabGoogleSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoogleSearch.Size = new System.Drawing.Size(776, 595);
            this.tabGoogleSearch.TabIndex = 3;
            this.tabGoogleSearch.Text = "Google Search";
            this.tabGoogleSearch.UseVisualStyleBackColor = true;
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.FullRowSelect = true;
            this.lstSearchResults.GridLines = true;
            this.lstSearchResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSearchResults.Location = new System.Drawing.Point(14, 50);
            this.lstSearchResults.MultiSelect = false;
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.ShowGroups = false;
            this.lstSearchResults.Size = new System.Drawing.Size(632, 516);
            this.lstSearchResults.TabIndex = 9;
            this.lstSearchResults.UseCompatibleStateImageBehavior = false;
            this.lstSearchResults.View = System.Windows.Forms.View.List;
            this.lstSearchResults.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lstSearchResults_ItemMouseHover);
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(663, 50);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Reset";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(663, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtGoogleSearch
            // 
            this.txtGoogleSearch.Location = new System.Drawing.Point(14, 16);
            this.txtGoogleSearch.Name = "txtGoogleSearch";
            this.txtGoogleSearch.Size = new System.Drawing.Size(632, 21);
            this.txtGoogleSearch.TabIndex = 7;
            this.txtGoogleSearch.TextChanged += new System.EventHandler(this.txtGoogleSearch_TextChanged);
            this.txtGoogleSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtGoogleSearch_KeyUp);
            // 
            // tabCopier
            // 
            this.tabCopier.Controls.Add(this.chkSelectSubFolders);
            this.tabCopier.Controls.Add(this.btnSelectAllFolder);
            this.tabCopier.Controls.Add(this.btnUnselectAllFolder);
            this.tabCopier.Controls.Add(this.chkListSourceFolder);
            this.tabCopier.Controls.Add(this.btnCopy);
            this.tabCopier.Controls.Add(this.btnBrowseDest);
            this.tabCopier.Controls.Add(this.btnBrowseSource);
            this.tabCopier.Controls.Add(this.txtDestFolder);
            this.tabCopier.Controls.Add(this.label5);
            this.tabCopier.Controls.Add(this.txtSourceFolder);
            this.tabCopier.Controls.Add(this.label4);
            this.tabCopier.Location = new System.Drawing.Point(4, 24);
            this.tabCopier.Name = "tabCopier";
            this.tabCopier.Padding = new System.Windows.Forms.Padding(3);
            this.tabCopier.Size = new System.Drawing.Size(776, 595);
            this.tabCopier.TabIndex = 4;
            this.tabCopier.Text = "Copier";
            this.tabCopier.UseVisualStyleBackColor = true;
            // 
            // chkSelectSubFolders
            // 
            this.chkSelectSubFolders.AutoSize = true;
            this.chkSelectSubFolders.Location = new System.Drawing.Point(15, 91);
            this.chkSelectSubFolders.Name = "chkSelectSubFolders";
            this.chkSelectSubFolders.Size = new System.Drawing.Size(269, 19);
            this.chkSelectSubFolders.TabIndex = 9;
            this.chkSelectSubFolders.Text = "Select sub folders from source folder to copy";
            this.chkSelectSubFolders.UseVisualStyleBackColor = true;
            this.chkSelectSubFolders.CheckedChanged += new System.EventHandler(this.chkSelectSubFolders_CheckedChanged);
            // 
            // btnSelectAllFolder
            // 
            this.btnSelectAllFolder.Location = new System.Drawing.Point(662, 94);
            this.btnSelectAllFolder.Name = "btnSelectAllFolder";
            this.btnSelectAllFolder.Size = new System.Drawing.Size(97, 23);
            this.btnSelectAllFolder.TabIndex = 7;
            this.btnSelectAllFolder.Text = "Select all";
            this.btnSelectAllFolder.UseVisualStyleBackColor = true;
            this.btnSelectAllFolder.Click += new System.EventHandler(this.btnSelectAllFolder_Click);
            // 
            // btnUnselectAllFolder
            // 
            this.btnUnselectAllFolder.Location = new System.Drawing.Point(662, 132);
            this.btnUnselectAllFolder.Name = "btnUnselectAllFolder";
            this.btnUnselectAllFolder.Size = new System.Drawing.Size(97, 23);
            this.btnUnselectAllFolder.TabIndex = 8;
            this.btnUnselectAllFolder.Text = "Unselect all";
            this.btnUnselectAllFolder.UseVisualStyleBackColor = true;
            this.btnUnselectAllFolder.Click += new System.EventHandler(this.btnUnselectAllFolder_Click);
            // 
            // chkListSourceFolder
            // 
            this.chkListSourceFolder.FormattingEnabled = true;
            this.chkListSourceFolder.HorizontalScrollbar = true;
            this.chkListSourceFolder.Location = new System.Drawing.Point(14, 120);
            this.chkListSourceFolder.Name = "chkListSourceFolder";
            this.chkListSourceFolder.Size = new System.Drawing.Size(630, 452);
            this.chkListSourceFolder.Sorted = true;
            this.chkListSourceFolder.TabIndex = 6;
            this.chkListSourceFolder.UseCompatibleTextRendering = true;
            this.chkListSourceFolder.SelectedIndexChanged += new System.EventHandler(this.chkListSourceFolder_SelectedIndexChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(662, 169);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(97, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDest.Location = new System.Drawing.Point(662, 55);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(97, 23);
            this.btnBrowseDest.TabIndex = 5;
            this.btnBrowseDest.Text = "Browse...";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSource.Location = new System.Drawing.Point(662, 17);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(97, 23);
            this.btnBrowseSource.TabIndex = 5;
            this.btnBrowseSource.Text = "Browse...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Location = new System.Drawing.Point(123, 56);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.ReadOnly = true;
            this.txtDestFolder.Size = new System.Drawing.Size(521, 21);
            this.txtDestFolder.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Destination folder";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(123, 18);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(521, 21);
            this.txtSourceFolder.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Source folder";
            // 
            // fldBrowser
            // 
            this.fldBrowser.Description = "Browse folders in windows explorer";
            this.fldBrowser.ShowNewFolderButton = false;
            // 
            // fileBrowser
            // 
            this.fileBrowser.DefaultExt = "*.exe";
            // 
            // frmApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 618);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instant Application Installer";
            this.Load += new System.EventHandler(this.frmApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBasicApp.ResumeLayout(false);
            this.tabBasicApp.PerformLayout();
            this.tabAdvancedApp.ResumeLayout(false);
            this.tabAdvancedApp.PerformLayout();
            this.tabAddedApp.ResumeLayout(false);
            this.tabAddedApp.PerformLayout();
            this.grbAppType.ResumeLayout(false);
            this.grbAppType.PerformLayout();
            this.tabGoogleSearch.ResumeLayout(false);
            this.tabGoogleSearch.PerformLayout();
            this.tabCopier.ResumeLayout(false);
            this.tabCopier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBasicApp;
        private System.Windows.Forms.TabPage tabAdvancedApp;
        private System.Windows.Forms.TabPage tabAddedApp;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.ListView lstAddedApps;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.FolderBrowserDialog fldBrowser;
        private System.Windows.Forms.RadioButton rdAdvanceApp;
        private System.Windows.Forms.GroupBox grbAppType;
        private System.Windows.Forms.RadioButton rdBasicApp;
        private System.Windows.Forms.Button btnInstallBasic;
        private System.Windows.Forms.CheckedListBox chkListBasicApps;
        private System.Windows.Forms.Button btnSelectAllBasic;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnSelectAllAdvanced;
        private System.Windows.Forms.Button btnUnselectAllAdvanced;
        private System.Windows.Forms.Button btnInstallAdvanced;
        private System.Windows.Forms.CheckedListBox chkListAdvancedApps;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBasicSearch;
        private System.Windows.Forms.TextBox txtAdvancedSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabPage tabGoogleSearch;
        private System.Windows.Forms.TextBox txtGoogleSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView lstSearchResults;
        private System.Windows.Forms.TabPage tabCopier;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtDestFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkListSourceFolder;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSelectAllFolder;
        private System.Windows.Forms.Button btnUnselectAllFolder;
        private System.Windows.Forms.CheckBox chkSelectSubFolders;
    }
}

