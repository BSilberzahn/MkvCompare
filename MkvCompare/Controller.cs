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

        public static string GetMatroskaMovieDuration(string mkvFilePath)
        {
            MatroskaElementDescriptorProvider medp = new MatroskaElementDescriptorProvider();
            using (var fs = new FileStream(mkvFilePath, FileMode.Open, FileAccess.Read))
            using (EbmlReader ebmlReader = new EbmlReader(fs))
            {
                var segmentFound = ebmlReader.LocateElement(MatroskaElementDescriptorProvider.Segment);
                if (segmentFound)
                {
                    ebmlReader.EnterContainer();
                    while (ebmlReader.ReadNext())
                    {
                        var descriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                        if (descriptor == null) continue;
                        if (descriptor.Name == "Tracks")
                        {
                            Console.WriteLine("\t dans " + descriptor.Name);
                            ebmlReader.EnterContainer();
                            while (ebmlReader.ReadNext())
                            {
                                var trackDescriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                                if (trackDescriptor == null) continue;
                                if (trackDescriptor.Name == "TrackEntry")
                                {
                                    Console.WriteLine("\t dans " + trackDescriptor.Name);
                                    ebmlReader.EnterContainer();
                                    while (ebmlReader.ReadNext())
                                    {
                                        var trackEntryDescriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                                        if (trackEntryDescriptor == null) continue;
                                        if (trackEntryDescriptor.Name == "Video")
                                        {
                                            Console.WriteLine("\t dans " + trackEntryDescriptor.Name);
                                            ebmlReader.EnterContainer();
                                            while (ebmlReader.ReadNext())
                                            {
                                                var videoDescriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                                                if (videoDescriptor == null) continue;
                                                if (videoDescriptor.Name == "PixelWidth")
                                                {
                                                    Console.WriteLine("\t dans " + videoDescriptor.Name);
                                                    Console.WriteLine("\t value " + ebmlReader.ReadUInt());
                                                }
                                                else if (videoDescriptor.Name == "PixelHeight")
                                                {
                                                    Console.WriteLine("\t value " + ebmlReader.ReadUInt());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static List<string> GetMatroskaSubtitleLanguages(string mkvFilePath)
        {
            MatroskaElementDescriptorProvider medp = new MatroskaElementDescriptorProvider();
            List<string> lstLanguages = new List<string>();

            using (var fs = new FileStream(mkvFilePath, FileMode.Open, FileAccess.Read))
            using (EbmlReader ebmlReader = new EbmlReader(fs))
            {
                var segmentFound = ebmlReader.LocateElement(MatroskaElementDescriptorProvider.Segment);
                if (segmentFound)
                {
                    ebmlReader.EnterContainer();
                    while (ebmlReader.ReadNext())
                    {
                        var descriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                        if (descriptor == null) continue;
                        if (descriptor.Name == "Tracks")
                        {
                            ebmlReader.EnterContainer();
                            while (ebmlReader.ReadNext())
                            {
                                var trackDescriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                                if (trackDescriptor == null) continue;
                                if (trackDescriptor.Name == "TrackEntry")
                                {
                                    ebmlReader.EnterContainer();
                                    long trackType = 0;
                                    string trackLanguage = null;
                                    while (ebmlReader.ReadNext())
                                    {
                                        var trackEntryDescriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                                        if (trackEntryDescriptor == null) continue;
                                        if (trackEntryDescriptor.Name == "TrackType")
                                        {
                                            trackType = ebmlReader.ReadInt();
                                        }
                                        else if (trackEntryDescriptor.Name == "Language")
                                        {
                                            trackLanguage = ebmlReader.ReadUtf();
                                        }
                                    }
                                    if (trackType == 0x11) //subtitle
                                    {
                                        lstLanguages.Add(trackLanguage);
                                    }
                                    ebmlReader.LeaveContainer();
                                }
                            }
                            ebmlReader.LeaveContainer();
                            break;
                        }
                    }
                }
            }
            return lstLanguages;
        }
    }
}
