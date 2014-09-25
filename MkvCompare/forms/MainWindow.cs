using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkvCompare
{
    public partial class MainWindow : Form
    {
        public WebView webView;

        public MainWindow()
        {
            InitializeComponent();

             var settings = new CefSharp.Settings
            {
                PackLoadingDisabled = true,
            };

             if (CEF.Initialize(settings))
             {
                 BrowserSettings browserSettings = new BrowserSettings();
                 browserSettings.FileAccessFromFileUrlsAllowed = true;
                 browserSettings.UniversalAccessFromFileUrlsAllowed = true;
                 browserSettings.TextAreaResizeDisabled = true;

                 this.webView = new WebView(Application.StartupPath + @"\res\www\index.html", browserSettings);

                 this.webView.Dock = DockStyle.Fill;
                 this.toolStripContainer.ContentPanel.Controls.Add(webView);
             }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reduce_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
