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
    public partial class Progress : Form
    {
        public static bool isCancelled = false;
        public static bool isCompleted = false;
        public Progress()
        {
            InitializeComponent();
            btnOK.Enabled = false;
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            // Start the BackgroundWorker.
            backgroundWorker1.RunWorkerAsync();
            lblInfo.Text = "Adding application in progress. It may take several minutes to complete. Please wait!";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            // Your background task goes here
            for (int i = 0; i <= 100; i++)
            {
                // Report progress to 'UI' thread
                backgroundWorker1.ReportProgress(i, i);
                // Simulate long task
                System.Threading.Thread.Sleep(100);
            }
            if (!e.Cancel)
            {
                Handler.CopyFiles(frmApplication.SourceFolder, frmApplication.DesFolder);
            }
            else
            {
                Handler.DeleteFiles(frmApplication.DesFolder);
            }        
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.            
            progressBar1.Value = e.ProgressPercentage;            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                lblInfo.Text = "Operation is cancelled!";
                isCancelled = true;
                Handler.DeleteFiles(frmApplication.DesFolder);
            }

            // Check to see if an error occurred in the background process.
            else if (e.Error != null)
            {
                lblInfo.Text = "Error while performing operation!";
                isCancelled = true;
                Handler.DeleteFiles(frmApplication.DesFolder);
            }
            else
            {
                // Everything completed normally.                
                lblInfo.Text = "The application is added successfully!";
                isCompleted = true;
            }
            progressBar1.Value = 0;
            progressBar1.Hide();         
            this.Text = "Completed";
            btnOK.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
