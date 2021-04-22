using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    public class PrevFilesDirectory : Command
    {
        public override string Name => "PrevFiles";

        public override void Handle()
        {
            if (startViewFiles >= lengthViewFiles)
            {
                startViewFiles -= lengthViewFiles;
                string path = parametrs[0];
                var selectFolder = new SelectFolder(path);
                selectFolder.PrintFile(startViewFiles, lengthViewFiles);
            }
        }
    }
}
