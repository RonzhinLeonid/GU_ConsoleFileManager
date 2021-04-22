using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    public class NextFilesDirectory : Command
    {
        public override string Name => "NextFiles";

        public override void Handle()
        {
            
            string path = parametrs[0];
            var selectFolder = new SelectFolder(path);
            if (selectFolder.CountFiles > startViewFiles + lengthViewFiles)
            {
                startViewFiles += lengthViewFiles;
                selectFolder.PrintFile(startViewFiles, lengthViewFiles);
            }
        }
    }
}
