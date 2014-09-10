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
        private static ArrayList movieList;

        public static ArrayList pathToMkvList(string path)
        {
            return ListDirectory(new TreeView(), path);
        }

        private static ArrayList ListDirectory(TreeView treeView, string path)
        {
            movieList = new ArrayList();
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
                    movieList.Add(new MkvFile(file.Name, directoryInfo.FullName));
                }
            }
            return directoryNode;
        }

        public static double getFreeSizeDisk(string path)
        {
            string driveLetter = Path.GetPathRoot(path);
            double freespace = 0;
            foreach (System.IO.DriveInfo label in System.IO.DriveInfo.GetDrives())
            {
                if (label.Name.Contains(driveLetter))
                {
                    freespace = label.TotalFreeSpace / 1024.00 / 1024.00 / 1024.00;
                    freespace = Math.Round(freespace, 2);
                }
            }
            return freespace;
        }
        public static void copy(MkvFile mkvFile, String otherPath)
        {
            string[] files = Directory.GetFiles(mkvFile.path, mkvFile.fullName);
            foreach (string file in files)
            {
                string otherFile = Path.Combine(otherPath, mkvFile.fullName);
                File.Copy(file, otherFile);
            }
        }
    }
}
