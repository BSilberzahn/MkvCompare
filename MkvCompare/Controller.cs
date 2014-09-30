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
        public static MkvList PathToMkvList(string path)
        {
            return new MkvList().pathToMkvList(path);
        }

        public static void DeleteMkvFileInCommon(MkvList list, MkvList list2)
        {
            //return list.deleteMkvFileInCommon(list2.movieList);
            List<MkvFile> copyList = new List<MkvFile>();
            List<MkvFile> copyList2 = new List<MkvFile>();
            foreach (MkvFile mkv in list.movieList)
            {
                foreach (MkvFile mkv2 in list2.movieList)
                {
                    if (mkv.fullName.Equals(mkv2.fullName))
                    {
                        copyList.Add(mkv);
                        copyList2.Add(mkv2);
                    }
                }
            }
            foreach (MkvFile mkv in copyList)
            {
                list.movieList.Remove(mkv);
            }
            foreach (MkvFile mkv2 in copyList2)
            {
                list2.movieList.Remove(mkv2);
            }
        }

        public static double GetFreeSizeDisk(string path)
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
        public static void Copy(MkvFile mkvFile, String otherPath)
        {// GESTION DES ERREURS A FAIRE 
            string[] files = Directory.GetFiles(mkvFile.path, mkvFile.fullName);
            foreach (string file in files)
            {
                string otherFile = Path.Combine(otherPath, mkvFile.fullName);
                File.Copy(file, otherFile);
            }
        }

        private static void GetHiddenFiles(String path)
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
