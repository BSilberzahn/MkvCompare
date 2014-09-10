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


namespace MkvCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            String appdir = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));

            // Commenter et décommenter une ligne ci-dessous en fonction du poste (temporaire le temps de trouver une solution).
            //this.webBrowser1.Url = new Uri("file:///" + @"C:\Users\Benjamin\Documents\Visual Studio 2013\Projects\MkvCompare\MkvCompare\index.html");
            this.webBrowser1.Url = new Uri("file:///" + @"C:\Users\Erwan\Documents\Boulot\C#\MkvCompare\MkvCompare\index.html");


        }

       

    }
}
