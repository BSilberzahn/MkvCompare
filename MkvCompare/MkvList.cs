using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkvCompare
{
    class MkvList
    {
        public List<MkvFile> movieList;

        public MkvList pathToMkvList(string path)
        {
            ListDirectory(new TreeView(), path);
            return this;
        }

        private List<MkvFile> ListDirectory(TreeView treeView, string path)
        {
            movieList = new List<MkvFile>();
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            return movieList;
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                directoryNode.Nodes.Add(new TreeNode(file.Name));
                if (Path.GetExtension(file.Name) == ".mkv")
                {
                    movieList.Add(new MkvFile(file.Name, directoryInfo.FullName));
                }
            }
            return directoryNode;
        }

    }
}
