using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEbml.Core;

namespace MkvCompare
{
    class MkvFile
    {
        public String fullName;     // with the .mkv extension
        public String labelName;    // without the .mkv extension
        public String path;
        public Double size;
        public long width ;
        public long height;
        public List<string> listLanguageSubtitle;
        public List<string> listLanguageAudio;


        public MkvFile(String fullName, String path)
        {
            this.fullName = fullName;
            this.labelName = Path.GetFileNameWithoutExtension(fullName);
            this.path = path;
            this.size = Math.Round((new FileInfo(path + "/" + fullName).Length) / 1024.00 / 1024.00 / 1024.00,2);
            listLanguageSubtitle = new List<string>();
            listLanguageAudio = new List<string>();
            GetMatroskaTags();
        }

        private void GetMatroskaTags()
        {
            MatroskaElementDescriptorProvider medp = new MatroskaElementDescriptorProvider();

            using (var fs = new FileStream(path + "/" + fullName, FileMode.Open, FileAccess.Read))
            using (EbmlReader ebmlReader = new EbmlReader(fs))
            {
                Console.WriteLine("--------------" + labelName + "----------------");
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
                                        if (trackEntryDescriptor.Name == "Video")
                                        {
                                            ebmlReader.EnterContainer();
                                            while (ebmlReader.ReadNext())
                                            {
                                                var videoDescriptor = medp.GetElementDescriptor(ebmlReader.ElementId);
                                                
                                                if (videoDescriptor == null) continue;
                                                if (videoDescriptor.Name == "PixelWidth")
                                                {
                                                    width = ebmlReader.ReadInt();
                                                }
                                                else if (videoDescriptor.Name == "PixelHeight")
                                                {
                                                    height = ebmlReader.ReadInt();
                                                }
                                            }
                                            ebmlReader.LeaveContainer();
                                        }
                                        else if (trackEntryDescriptor.Name == "TrackType")
                                        {
                                            trackType = ebmlReader.ReadInt();
                                        }
                                        else if (trackEntryDescriptor.Name == "Language")
                                        {
                                            trackLanguage = ebmlReader.ReadUtf();

                                            if (trackType == 0x11) //subtitle
                                            {
                                                listLanguageSubtitle.Add(trackLanguage);
                                                //Console.WriteLine("subtitle : ->" + trackLanguage + "<-");
                                            }
                                            else if (trackType == 2) //audio
                                            {
                                                listLanguageAudio.Add(trackLanguage);
                                                //Console.WriteLine("audio : ->" + trackLanguage + "<-");
                                            }
                                        }

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
        }
        public void display()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("FullName : " + fullName);
            Console.WriteLine("LabelName : " + labelName);
            Console.WriteLine("Path : " + path);
            Console.WriteLine("Size : " + size);
            Console.WriteLine("Width : " + width);
            Console.WriteLine("Height : " + height);
            Console.WriteLine("Subtitles : " + listLanguageSubtitle.Count);
            foreach (string sub in listLanguageSubtitle)
            {
                Console.WriteLine("\t - " + sub);
            }
            Console.WriteLine("Audio : " + listLanguageAudio.Count);
            foreach (string aud in listLanguageAudio)
            {
                Console.WriteLine("\t - " + aud);
            }
        }
    }
}
