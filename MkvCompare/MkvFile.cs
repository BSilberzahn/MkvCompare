using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkvCompare
{
    class MkvFile
    {
        public String fullName;
        public String labelName;
        public String path;
        public Double size;

        public MkvFile(String fullName, String path)
        {
            this.fullName = fullName;
            this.labelName = Path.GetFileNameWithoutExtension(fullName);
            this.path = path;
            this.size = Math.Round((new FileInfo(path + "/" + fullName).Length) / 1024.00 / 1024.00 / 1024.00,2);
            //Console.WriteLine("\tSIZE "+size);
        }

    }
}
