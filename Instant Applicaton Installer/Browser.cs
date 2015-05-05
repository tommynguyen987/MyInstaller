using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstantApplicationInstaller
{
    public partial class frmBrowser : Form
    {
        bool isNewWindow = false;
        public frmBrowser()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            Uri uri = new Uri(frmApplication.strUrl);
            //webBrowser1.Url = uri;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string[] arrExtensions = { "zip", "rar", "exe", "msi" };
            if (arrExtensions.Contains(e.Url.Segments[e.Url.Segments.Length - 1].Split('.')[e.Url.Segments[e.Url.Segments.Length - 1].Split('.').Length - 1]))
            {
                string filepath = null;
                saveFileDialog1.FileName = e.Url.Segments[e.Url.Segments.Length - 1];
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = saveFileDialog1.FileName;
                    System.Net.WebClient client = new System.Net.WebClient();
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(e.Url, filepath);
                }
            }
            else
            {
                if (isNewWindow)
                {
                    //webBrowser1.Navigate(e.Url);
                }
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                frmApplication.SourceFolder = saveFileDialog1.FileName;
                frmApplication.DesFolder = frmApplication.GetDataFolder() + Handler.GetLastItem(Handler.RemoveExtension(saveFileDialog1.FileName), '\\');
                frmApplication frmApp = new frmApplication();
                frmApp.AddApplications(frmApplication.SourceFolder, frmApplication.DesFolder);
                if (Progress.isCompleted)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error when downloading file." + System.Environment.NewLine + e.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            isNewWindow = true;
            //webBrowser1.Url = new Uri(webBrowser1.StatusText);
        }

        private void tabControl_VisibleChanged(object sender, EventArgs e)
        {

        }  
    }
}
