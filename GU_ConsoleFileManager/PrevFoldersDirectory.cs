using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    public class PrevFoldersDirectory : Command
    {
        public override string Name => "PrevFolders";

        public override void Handle()
        {
            if (startViewFolder >= lengthViewFolder)
            {
                startViewFolder -= lengthViewFolder;
                string path = parametrs[0];
                var selectFolder = new SelectFolder(path);
                selectFolder.PrintTree(startViewFolder, lengthViewFolder);
            }
        }
    }
}
