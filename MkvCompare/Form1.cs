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
using System.Collections;
using System.Reflection;
using Microsoft.Win32;


namespace MkvCompare
{
    public partial class Form1 : Form
    {

        private string uri = "file:///" + Directory.GetCurrentDirectory().ToString() + @"\..\..\index.html";

        public Form1()
        {
            InitializeComponent();
           
            // Commenter et décommenter une ligne ci-dessous en fonction du poste (temporaire le temps de trouver une solution).
            this.webBrowser1.Url = new Uri(uri);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document;
            HtmlElement head = doc.GetElementsByTagName("head")[0];
            
            if (head != null)
            {
                HtmlElement s = doc.CreateElement("script");
                s.SetAttribute("text", System.IO.File.ReadAllText(@"..\..\js\jquery-1-11-1.js"));
                head.AppendChild(s);
                s = doc.CreateElement("script");
                s.SetAttribute("text", System.IO.File.ReadAllText(@"..\..\js\mkv.js"));
                head.AppendChild(s);
            }
        }



       

    }
}
