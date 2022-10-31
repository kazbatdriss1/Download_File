using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltoHttp;


namespace Download_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HttpDownloader httpDownloader;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            httpDownloader = new HttpDownloader(TextBox_url.Text,$"{Application.StartupPath}\\{Path.GetFileName(TextBox_url.Text)}");
            httpDownloader.DownloadCompleted += HttpDownloader_DownloadCompleted;
            httpDownloader.ProgressChanged += HttpDownloader_ProgressChanged;
            httpDownloader.Start();
        }

        private void HttpDownloader_ProgressChanged(object sender, AltoHttp.ProgressChangedEventArgs e)
        {
            ProgressBar.Value = (int)e.Progress;
            label_ProgressBar.Text = $"{e.Progress.ToString("0.00")}%";
            label_Speed.Text = string.Format("{0} MB/s",(e.SpeedInBytes/ 1024d / 1024d).ToString("0.00"));
            label_Downloded.Text = string.Format("{0} MB/s",(httpDownloader.TotalBytesReceived / 1024d / 1024d).ToString("0.00"));
            label_Status.Text = "downloading...";

        }

        private void HttpDownloader_DownloadCompleted(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                label_Status.Text = "Finish !";
                label_ProgressBar.Text = "100 %";
            });
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (httpDownloader != null)
            {
                httpDownloader.Pause();
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (httpDownloader != null)
            {
                httpDownloader.Resume();
            }
        }
    }
}
