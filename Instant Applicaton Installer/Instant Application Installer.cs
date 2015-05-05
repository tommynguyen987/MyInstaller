using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace InstantApplicationInstaller
{
    public partial class frmApplication : Form
    {
        DataBase db = new DataBase();
        bool isClickBrowsed = false;
        public static string SourceFolder, DesFolder, strUrl;
        int sortColumn = 0;
        static string RootFolder = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName;
        
        public static string GetDataFolder()
        {
            return System.IO.Directory.GetParent(RootFolder).FullName + "\\Resources\\Data\\";
        }
        
        public frmApplication()
        {
            InitializeComponent();           
            btnInstallBasic.Enabled = btnInstallAdvanced.Enabled = btnSelectAllFolder.Enabled = btnCopy.Enabled = false;
            chkSelectSubFolders.Enabled = false;
            lstAddedApps.Columns.Add("Application Name", 180);
            lstAddedApps.Columns.Add("Application Path", 300);
            lstAddedApps.Columns.Add("Application Type", 100);            
        }

        private void frmApplication_Load(object sender, EventArgs e)
        {
            LoadApplications(1);
        }

        private void LoadApplications(int type)
        {
            System.Data.DataTable dt = new DataTable();            
            switch (type)
            {
                case 2:
                    SetCheckState(chkListAdvancedApps, btnInstallAdvanced, false);
                    dt = Handler.LoadData(type, txtAdvancedSearch.Text.Trim());
                    ((ListBox)chkListAdvancedApps).DataSource = dt;
                    ((ListBox)chkListAdvancedApps).DisplayMember = "AppName";
                    ((ListBox)chkListAdvancedApps).ValueMember = "ID";                    
                    if (dt.Rows.Count > 0)
                    {
                        btnSelectAllAdvanced.Enabled = true;                        
                    }
                    else
                    {
                        btnSelectAllAdvanced.Enabled = false;
                    }                    
                    break;
                case 3:
                    lstAddedApps.Items.Clear();
                    rdBasicApp.Checked = true;
                    btnRemove.Enabled = false;
                    dt = Handler.LoadData(type, (txtAppName.Text.Trim() == "" ? "" : txtAppName.Text.Trim()));                    
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ListViewItem item = new ListViewItem();
                            item.SubItems[0].Text = row["AppName"].ToString();
                            item.SubItems.Add(row["AppPath"].ToString());
                            item.SubItems.Add(row["AppType"].ToString());
                            item.Tag = row["ID"].ToString();
                            lstAddedApps.Items.Add(item);
                        }
                        lstAddedApps.Sorting = SortOrder.Ascending;
                        lstAddedApps.Sort();
                        lstAddedApps.ListViewItemSorter = new ListViewItemComparer(sortColumn,
                                                                  lstAddedApps.Sorting);
                    }                    
                    break;
                default:
                    SetCheckState(chkListBasicApps, btnInstallBasic, false);
                    dt = Handler.LoadData(type, txtBasicSearch.Text.Trim());
                    ((ListBox)chkListBasicApps).DataSource = dt;
                    ((ListBox)chkListBasicApps).DisplayMember = "AppName";
                    ((ListBox)chkListBasicApps).ValueMember = "ID";                    
                    if (dt.Rows.Count > 0)
                    {
                        btnSelectAllBasic.Enabled = true;                        
                    }
                    else
                    {
                        btnSelectAllBasic.Enabled = false;                        
                    }                    
                    break;
            }            
        }

        private void LoadAddedApplicationsByType(int type, string appName)
        {
            lstAddedApps.Items.Clear();
            btnRemove.Enabled = false;
            System.Data.DataTable dt = Handler.LoadData(type, appName);
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = row["AppName"].ToString();            
                item.SubItems.Add(row["AppPath"].ToString());
                item.SubItems.Add(row["AppType"].ToString());
                item.Tag = row["ID"].ToString();
                lstAddedApps.Items.Add(item);
            }
            lstAddedApps.Sorting = SortOrder.Ascending;
            lstAddedApps.Sort();
            lstAddedApps.ListViewItemSorter = new ListViewItemComparer(sortColumn,
                                                              lstAddedApps.Sorting); 
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabAdvancedApp":
                    txtAdvancedSearch.Text = "";
                    LoadApplications(2);
                    break;
                case "tabAddedApp":                    
                    txtFolder.Text = "";
                    txtFile.Text = "";
                    txtAppName.Text = "";
                    LoadApplications(3);
                    break;
                case "tabGoogleSearch":
                    txtGoogleSearch.Text = "";
                    lstSearchResults.Items.Clear();
                    break;
                case "tabCopier":
                    txtSourceFolder.Text = "";
                    txtDestFolder.Text = "";

                    break;
                default:
                    txtBasicSearch.Text = "";
                    LoadApplications(1);
                    break;
            }
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fldBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFolder.Text = fldBrowser.SelectedPath;
                txtFile.Text = "";
                txtAppName.Text = "";
                btnAdd.Enabled = true;
                btnAdd.Text = "Add";
                isClickBrowsed = true;
                SourceFolder = txtFolder.Text;
            }
            else
            {
                btnAdd.Enabled = false;
                isClickBrowsed = false;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFile.Text = fileBrowser.FileName;
                txtFolder.Text = "";
                txtAppName.Text = "";
                btnAdd.Enabled = true;
                btnAdd.Text = "Add";
                isClickBrowsed = true;
                SourceFolder = txtFile.Text;
            }
            else
            {
                btnAdd.Enabled = false;
                isClickBrowsed = false;
            }
        }

        public void AddApplications(string strSourceFolder, string strDesFolder)
        {           
            ApplicationInfo appInfo = new ApplicationInfo();
            appInfo.ID = "App" + Handler.GetRandomInteger();
            appInfo.AppName = txtAppName.Text.Trim() == string.Empty ? Handler.GetLastItem(Handler.RemoveExtension(strSourceFolder), '\\') : txtAppName.Text.Trim();
            appInfo.AppPath = strDesFolder;
            foreach (Control c in grbAppType.Controls)
            {
                RadioButton rd = (RadioButton)c;
                if (rd.Checked)
                {
                    string strName = rd.Text;
                    if (strName == "Basic")
                    {
                        appInfo.AppType = AppTypes.Basic;
                    }
                    else
                    {
                        appInfo.AppType = AppTypes.Advanced;
                    }
                }                
            }
            if (btnAdd.Text == "Add")
            {
                Progress prg = new Progress();
                prg.ShowDialog();

                if (Progress.isCompleted || Progress.isCancelled)
                {
                    if (Progress.isCancelled)
                    {                                                
                        Handler.DeleteFiles(appInfo.AppPath);
                    }
                    else
                    {
                        Handler.AddItem(appInfo);
                    }                             
                }
            }
            else
            {
                appInfo.ID = GetSelectedID();
                Handler.UpdateItem(appInfo);                
            }
            txtAppName.Text = "";
            txtAppName.Enabled = false;
            LoadApplications(3);            
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text != "")
            {                
                
                DesFolder = GetDataFolder()  + Handler.GetLastItem(txtFolder.Text, '\\');
                AddApplications(txtFolder.Text, DesFolder);
                txtFolder.Text = "";
            }

            if (txtFile.Text != "")
            {                
                DesFolder = GetDataFolder() + Handler.GetLastItem(Handler.RemoveExtension(txtFile.Text), '\\');
                AddApplications(txtFile.Text, DesFolder);
                txtFile.Text = "";                
            }            
            isClickBrowsed = false;
            btnAdd.Enabled = false;
        }

        private string GetSelectedID()
        {
            string id = "";
            foreach (ListViewItem item in lstAddedApps.Items)
            {
                if (item.Selected)
                {
                    id = item.Tag.ToString();
                    break;
                }
            }
            return id;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete the item(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (lstAddedApps.SelectedItems.Count >= 2)
                {
                    foreach (ListViewItem item in lstAddedApps.SelectedItems)
                    {
                        string id = item.Tag.ToString();
                        System.Data.DataTable dt = Handler.LoadDataByID(id);
                        Handler.DeleteFiles(dt.Rows[0]["AppPath"].ToString());
                        Handler.RemoveItem(id);                            
                    }                    
                }
                else if (lstAddedApps.SelectedItems.Count == 1)
                {
                    foreach (ListViewItem item in lstAddedApps.SelectedItems)
                    {
                        if (item.Selected)
                        {
                            string id = item.Tag.ToString();
                            System.Data.DataTable dt = Handler.LoadDataByID(id);
                            Handler.DeleteFiles(dt.Rows[0]["AppPath"].ToString());
                            Handler.RemoveItem(id);                            
                            break;
                        }
                    }
                }                          
            }
            btnRemove.Enabled = false;
            txtFolder.Text = "";            
            txtAppName.Text = "";
            LoadApplications(3);
        }
        
        private void rdBasicApp_CheckedChanged(object sender, EventArgs e)
        {
            //LoadAddedApplicationsByType(1);
            //type = 1;

            if (!string.IsNullOrEmpty(txtFolder.Text.Trim()) && CheckChange() && !isClickBrowsed)
            {
                btnAdd.Enabled = true;
                btnAdd.Text = "Update";
            }
            else
            {
                if (isClickBrowsed)
                {
                    btnAdd.Enabled = true;                
                }
                else
                {
                    btnAdd.Enabled = false;                
                }                
                btnAdd.Text = "Add";
            }
        }

        private void rdAdvanceApp_CheckedChanged(object sender, EventArgs e)
        {
            //LoadAddedApplicationsByType(2);
            //type = 2;

            if (txtFolder.Text.Trim() != "" && CheckChange() && !isClickBrowsed)
            {
                btnAdd.Enabled = true;
                btnAdd.Text = "Update";
            }
            else
            {
                if (isClickBrowsed)
                {
                    btnAdd.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                }
                btnAdd.Text = "Add";
            }
        }

        private void lstAddedApps_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lstAddedApps.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lstAddedApps.Sorting == SortOrder.Ascending)
                    lstAddedApps.Sorting = SortOrder.Descending;
                else
                    lstAddedApps.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lstAddedApps.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lstAddedApps.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              lstAddedApps.Sorting); 
        }
       
        private void lstAddedApps_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstAddedApps.Items)
                {
                    if (item == e.Item && e.IsSelected)
                    {
                        btnRemove.Enabled = true;
                        btnAdd.Enabled = false;
                        string id = item.Tag.ToString();
                        System.Data.DataTable dt = Handler.LoadDataByID(id);
                        txtFolder.Text = dt.Rows[0]["AppPath"].ToString();
                        txtAppName.Text = dt.Rows[0]["AppName"].ToString();
                        txtAppName.Enabled = true;
                        foreach (Control c in grbAppType.Controls)
                        {
                            RadioButton rd = (RadioButton)c;
                            string strName = rd.Text;
                            if (strName == dt.Rows[0]["AppType"].ToString())
                            {
                                rd.Checked = true;
                            }
                        }
                        item.BackColor = SystemColors.Highlight;                        
                    }
                    else
                    {
                        item.BackColor = lstAddedApps.BackColor;
                    }
                }
            }
            catch (Exception)
            {
            }            
        }
        
        private void lstAddedApps_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstAddedApps.Items)
                {                    
                    if (item == e.Item)
                    {
                        item.BackColor = SystemColors.ActiveBorder;
                    }
                    else
                    {
                        item.BackColor = lstAddedApps.BackColor;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void lstAddedApps_Leave(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstAddedApps.Items)
            {
                if (item.Selected)
                {
                    btnRemove.Enabled = true;
                }
                else
                {
                    //btnRemove.Enabled = false;
                }
            }
        }

        private bool CheckChange()
        {
            bool isChanged = false;
            foreach (ListViewItem item in lstAddedApps.Items)
            {
                if (item.Selected)
                {
                    string id = item.Tag.ToString();
                    System.Data.DataTable dt = Handler.LoadDataByID(id);
                    string AppType = dt.Rows[0]["AppType"].ToString();
                    string AppPath = dt.Rows[0]["AppPath"].ToString();
                    foreach (Control c in grbAppType.Controls)
                    {
                        RadioButton rd = (RadioButton)c;
                        string strName = rd.Text;
                        if (strName != AppType && rd.Checked && txtAppName.Text.Trim() != "")
                        {
                            isChanged = true;
                        }
                    }
                }
            }
            return isChanged;
        }
        
        private void SetEnabledInstall(CheckedListBox chkListBox, Button btnInstall)
        {
            bool isChecked = false;
            for (int i = 0; i < chkListBox.Items.Count; i++)
            {
                if (chkListBox.GetItemChecked(i))
                    isChecked = true;
            }

            if (!isChecked)
            {
                btnInstall.Enabled = false;                
                btnUnselectAll.Enabled = false;
                btnUnselectAllAdvanced.Enabled = false;
                btnUnselectAllFolder.Enabled = false;
                if (txtSourceFolder.Text != "" && txtDestFolder.Text != "")
                {
                    btnCopy.Enabled = true;
                }
                else
                {
                    btnCopy.Enabled = false;
                }
            }
            else
            {
                btnInstall.Enabled = true;
                btnUnselectAll.Enabled = true;
                btnUnselectAllAdvanced.Enabled = true;                
                btnUnselectAllFolder.Enabled = true;
                if (txtSourceFolder.Text != "" && txtDestFolder.Text != "")
                {
                    btnCopy.Enabled = true;
                }
                else
                {
                    btnCopy.Enabled = false;
                }
            }           
        }
        
        private void SetCheckState(CheckedListBox chkListBox, Button btnInstall, bool isChecked)
        {
            for (int i = 0; i < chkListBox.Items.Count; i++)
            {
                chkListBox.SetItemChecked(i, isChecked);
            }
            SetEnabledInstall(chkListBox, btnInstall);
        }

        private void chkListBasicApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnabledInstall(chkListBasicApps, btnInstallBasic);
        }
        
        private void btnSelectAllBasic_Click(object sender, EventArgs e)
        {
            SetCheckState(chkListBasicApps, btnInstallBasic , true);
        }

        private void btnUnselectAllBasic_Click(object sender, EventArgs e)
        {
            SetCheckState(chkListBasicApps, btnInstallBasic , false);
        }

        private void btnSelectAllAdvanced_Click(object sender, EventArgs e)
        {
            SetCheckState(chkListAdvancedApps, btnInstallAdvanced, true);
        }

        private void btnUnselectAllAdvanced_Click(object sender, EventArgs e)
        {
            SetCheckState(chkListAdvancedApps, btnInstallAdvanced, false);
        }                

        private void chkListAdvancedApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnabledInstall(chkListAdvancedApps, btnInstallAdvanced);
        }
                
        private void txtBasicSearch_KeyUp(object sender, KeyEventArgs e)
        {
            LoadApplications(1);
        }

        private void txtAdvancedSearch_KeyUp(object sender, KeyEventArgs e)
        {
            LoadApplications(2);
        }

        private void txtAppName_KeyUp(object sender, KeyEventArgs e)
        {
            if (GetSelectedID() == "" && string.IsNullOrEmpty(txtFolder.Text) && string.IsNullOrEmpty(txtFile.Text))
            {
                LoadApplications(3);   
            }
            else
            {
                if (!string.IsNullOrEmpty(txtAppName.Text.Trim()) && (!string.IsNullOrEmpty(txtFolder.Text) || !string.IsNullOrEmpty(txtFile.Text)))
                {
                    if (!string.IsNullOrEmpty(GetSelectedID()) && !isClickBrowsed)
                    {
                        btnAdd.Text = "Update";
                    }
                    btnAdd.Enabled = true;
                    //btnRemove.Enabled = false;                
                }
                else
                {
                    btnAdd.Enabled = false;
                }
            }
        }         

        private string GetAppPath(string id)
        {
            string appPath = "";
            try
            {
                appPath = Handler.LoadDataByID(id).Rows[0]["AppPath"].ToString();
            }
            catch (Exception)
            {
            }            
            return appPath;
        }

        private string FindInstallFile(string AppFolder)
        {            
            string sFileName = null;
            try
            {
                var ext = new List<string> { ".exe", ".msi", ".rar", ".zip" };
                var sFiles = System.IO.Directory.GetFiles(AppFolder,"*.*", System.IO.SearchOption.TopDirectoryOnly).Where(s => ext.Any(e => s.EndsWith(e))).ToList();
                if (sFiles.Count == 1)
                {
                    sFileName = sFiles[0];
                }
                else 
                { 
                    foreach (string sFile in sFiles)
                    {
                        string tmp = sFile.Replace(AppFolder + "\\", string.Empty);
                        tmp = tmp.ToLower();
                        if (Handler.GetLastItem(AppFolder,'\\').ToLower().StartsWith(tmp) || tmp.Contains("x86") || tmp.Contains("setup"))
                        {
                            sFileName = AppFolder + "\\" + tmp;   
                        }
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return sFileName;
        }

        private void InstallApplications(CheckedListBox chkListBox)
        {
            try
            {
                System.Collections.Generic.Dictionary<string,string> arrInstalledApps = new System.Collections.Generic.Dictionary<string,string>();                        
                for (int i = 0; i < chkListBox.CheckedItems.Count; i++)
                {
                    DataRowView XDRV = (DataRowView)chkListBox.CheckedItems[i];
                    DataRow XDR = XDRV.Row;
                    string appName = XDR[chkListBox.DisplayMember].ToString();
                    string id = XDR[chkListBox.ValueMember].ToString();
                    string appPath = GetAppPath(id);
                    string installFileUrl = FindInstallFile(appPath);
                    // Start installing programs
                    System.Diagnostics.Process.Start(installFileUrl);
                    System.Threading.Thread.Sleep(30000);
                    MessageBox.Show("Is " + appName + " set up successfully?", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Question);                    
                }                                                                                  
	        }        
            catch {}                
        }

        private void btnInstallBasic_Click(object sender, EventArgs e)
        {
            InstallApplications(chkListBasicApps);
            SetCheckState(chkListBasicApps, btnInstallBasic, false);
        }

        private void btnInstallAdvanced_Click(object sender, EventArgs e)
        {
            InstallApplications(chkListAdvancedApps);
            SetCheckState(chkListAdvancedApps, btnInstallAdvanced, false);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFolder.Text = "";
            txtFile.Text = "";
            txtAppName.Text = "";
            btnAdd.Text = "Add";
            btnAdd.Enabled = false;
            LoadApplications(3);
        }
                
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void ExecuteSearch()
        {
            try
            {
                if (btnSearch.Text == "Search")
                {
                    if (txtGoogleSearch.Text.Trim() != "")
                    {
                        lstSearchResults.Items.Clear();
                        Google.API.Search.GwebSearchClient gs = new Google.API.Search.GwebSearchClient("");
                        List<Google.API.Search.IWebResult> results = gs.Search(txtGoogleSearch.Text.Trim(), 20).ToList();
                        if (results.Count > 0)
                        {
                            foreach (var item in results)
                            {
                                ListViewItem lstItem = new ListViewItem();
                                lstItem.SubItems[0].Text = item.Title;                                
                                lstItem.Tag = item.Url;                                
                                lstSearchResults.Items.Add(lstItem);
                            }
                        }
                    }
                }
                else
                {
                    foreach (ListViewItem item in lstSearchResults.SelectedItems)
                    {
                        strUrl = item.Tag.ToString();
                        frmBrowser br = new frmBrowser();
                        br.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while performing searching operation!" + System.Environment.NewLine + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGoogleSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Text = "Search";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGoogleSearch.Text = "";
            btnSearch.Text = "Search";
            lstSearchResults.Items.Clear();
        }

        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.Text = "Go to Browser";
        }

        private void lstSearchResults_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstSearchResults.Items)
                {
                    if (item == e.Item)
                    {
                        item.BackColor = SystemColors.ActiveBorder;
                    }
                    else
                    {
                        item.BackColor = lstAddedApps.BackColor;
                    }
                }
            }
            catch {}
        }

        private void txtGoogleSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteSearch();
            }
        }   

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            if (fldBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSourceFolder.Text = SourceFolder = fldBrowser.SelectedPath;
                chkSelectSubFolders.Enabled = true;
            }
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            if (fldBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDestFolder.Text = DesFolder = fldBrowser.SelectedPath;
                if (txtSourceFolder.Text != "")
                {
                    btnCopy.Enabled = true;
                }
            }
        }

        private void ListSourceFolder(string strPath)
        {
            try
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strPath);
                string[] arrDir = new string[dirInfo.GetDirectories().Length];
                int i = 0;
                foreach (var item in dirInfo.GetDirectories())
                {
                    arrDir[i++] = item.Name;
                }
                chkListSourceFolder.Items.AddRange(arrDir);
                if (arrDir.Length > 0)
                {
                    btnSelectAllFolder.Enabled = true;
                }
                else
                {
                    btnSelectAllFolder.Enabled = false;
                    if (dirInfo.GetFiles().Length > 0)
                    {
                        btnCopy.Enabled = true;
                    }
                    else
                    {
                        btnCopy.Enabled = false;
                    }
                }

                if (txtDestFolder.Text != "")
                {
                    btnCopy.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSelectAllFolder_Click(object sender, EventArgs e)
        {
            SetCheckState(chkListSourceFolder, btnCopy, true);
        }

        private void btnUnselectAllFolder_Click(object sender, EventArgs e)
        {
            SetCheckState(chkListSourceFolder, btnCopy, false);
        }

        private void chkListSourceFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnabledInstall(chkListSourceFolder, btnCopy);
        }

        private void chkSelectSubFolders_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectSubFolders.Checked)
            {
                ListSourceFolder(txtSourceFolder.Text);
            }
            else
            {
                chkListSourceFolder.Items.Clear();
                btnSelectAllFolder.Enabled = false;
            }
        }                                          

        private void btnCopy_Click(object sender, EventArgs e)
        {            
            String[] subFolders = new String[chkListSourceFolder.Items.Count - chkListSourceFolder.CheckedItems.Count]; ;
            if (chkSelectSubFolders.Checked)
            {
                CopyFiles.CopyFiles.isSubIgnore = true;
                int index = 0;
                for (int i = 0; i < chkListSourceFolder.Items.Count; i++)
                {
                    if (!chkListSourceFolder.GetItemChecked(i))
                    {
                        subFolders[index] = txtSourceFolder.Text + "\\" + chkListSourceFolder.GetItemText(chkListSourceFolder.Items[i]);
                        index++;
                    }
                }
            }
            
            CopyFiles.CopyFiles Temp = new CopyFiles.CopyFiles(txtSourceFolder.Text, txtDestFolder.Text);
            //Create the default Copy Files Dialog window from our Copy Files assembly
            //and sync it with our main/current thread
            CopyFiles.Copying TempDiag = new CopyFiles.Copying();
            TempDiag.SynchronizationObject = this;
            //Copy the files anysncrinsuly
            Temp.CopyAsync(TempDiag, subFolders);
                        
            txtSourceFolder.Text = "";
            txtDestFolder.Text = "";
            chkListSourceFolder.Items.Clear();
            chkSelectSubFolders.Enabled = false;
            chkSelectSubFolders.Checked = false;
            btnSelectAllFolder.Enabled = false;
            btnUnselectAllFolder.Enabled = false;
            btnCopy.Enabled = false;
        }                      
    }

    // Implements the manual sorting of items by column.
    class ListViewItemComparer : System.Collections.IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y) 
        {
            int returnVal= -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                    ((ListViewItem)y).SubItems[col].Text);
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }    
}