using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEbml.Core;

namespace MkvCompare
{
    class Controller
    {
        private static List<MkvFile> movieList;

        public static List<MkvFile> pathToMkvList(string path)
        {
            return ListDirectory(new TreeView(), path);
        }

        private static List<MkvFile> ListDirectory(TreeView treeView, string path)
        {
            movieList = new List<MkvFile>();
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
        {// GESTION DES ERREURS A FAIRE 
            string[] files = Directory.GetFiles(mkvFile.path, mkvFile.fullName);
            foreach (string file in files)
            {
                string otherFile = Path.Combine(otherPath, mkvFile.fullName);
                File.Copy(file, otherFile);
            }
        }

        private static void getHiddenFiles(String path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static void MatroskaTagsDescriptor(EbmlReader ebmlReader, MatroskaElementDescriptorProvider medp, string tab)
        {
            //Console.WriteLine("\t " + (ebmlReader.ElementSize));
            
            while (ebmlReader.ReadNext())
            {
                var descriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                if (descriptor == null) continue;
                if (descriptor.Name == "Cluster") continue;
                if (descriptor.Name == "Cues") continue;
                Console.WriteLine(tab + descriptor.Name + " " + ebmlReader.ElementPosition);
                if (descriptor.Type == ElementType.MasterElement)
                {
                    ebmlReader.EnterContainer();
                    MatroskaTagsDescriptor(ebmlReader, medp, tab + "\t");
                }
            }
            ebmlReader.LeaveContainer();
        }


        // Hierarchie des tags du conteneur MKV
        public static void MatroskaTagsIndentator(string mkvFilePath)
        {
            MatroskaElementDescriptorProvider medp = new MatroskaElementDescriptorProvider();

            using (var fs = new FileStream(mkvFilePath, FileMode.Open, FileAccess.Read))
            using (EbmlReader ebmlReader = new EbmlReader(fs))
            {
                var segmentFound = ebmlReader.LocateElement(MatroskaElementDescriptorProvider.Segment);
                if (segmentFound)
                {
                    ebmlReader.EnterContainer();
                    MatroskaTagsDescriptor(ebmlReader, medp, "");
                }
            }
        }

        

     
    }
}
