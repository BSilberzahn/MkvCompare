using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkvCompare
{
    class ControllerBase
    {
        String selectedPath1;
        String selectedPath2;
        static ArrayList movieList1 = new ArrayList();
        static ArrayList movieList2 = new ArrayList();
        public void main()
        {
            //this.selectedPath1 = selectedPath1;
            //this.selectedPath2 = selectedPath2;
            //this.selectedPath1Form1.Text = selectedPath1;
            //this.selectedPath2Form1.Text = selectedPath2;
            //this.label3.Text = selectedPath1 + " -> " + selectedPath2;
            //this.label4.Text = selectedPath2 + " -> " + selectedPath1;
            ListDirectory(new TreeView(), selectedPath1,1);
            ListDirectory(new TreeView(), selectedPath2,2);
            //foreach (var name in movieList1)
            //    this.listView1.Items.Add(new ListViewItem(name.ToString()));
            //foreach (var name in movieList2)
            //    this.listView2.Items.Add(new ListViewItem(name.ToString()));
           
        }

        private void ListDirectory(TreeView treeView, string path, int num)
        {
            ArrayList movieListTmp1 = new ArrayList();
            ArrayList movieListTmp2 = new ArrayList();
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo, num));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo, int num)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory, num));
            foreach (var file in directoryInfo.GetFiles()) { 
                directoryNode.Nodes.Add(new TreeNode(file.Name));
                if (Path.GetExtension(file.Name)==".mkv")
                {
                    if(num==1)
                    {
                         movieList1.Add(file.Name);
                        //Console.WriteLine(file.Name);
                    }else if (num == 2){
                        movieList2.Add(file.Name);
                        //Console.WriteLine(file.Name);
                    } 
                }   
        }
            return directoryNode;
        }
    }
}
