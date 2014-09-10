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
    class Controller
    {
        private static ArrayList movieList = new ArrayList();

        public static ArrayList pathToMkvList(string path)
        {
            return ListDirectory(new TreeView(), path);
        }

        private static ArrayList ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            return movieList;
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                directoryNode.Nodes.Add(new TreeNode(file.Name));
                if (Path.GetExtension(file.Name) == ".mkv")
                {
                    movieList.Add(file.Name);
                    //Console.WriteLine(file.Name);
                }
            }
            return directoryNode;
        }
    }
}
