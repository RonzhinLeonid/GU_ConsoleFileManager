using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    public class NextFoldersDirectory : Command
    {
        public override string Name => "NextFolders";

        public override void Handle()
        {
            string path = parametrs[0];
            var selectFolder = new SelectFolder(path);
            if (selectFolder.CountAllFolders > startViewFolder + lengthViewFolder)
            {
                startViewFolder += lengthViewFolder;
                selectFolder.PrintTree(startViewFolder, lengthViewFolder);
            }
        }
    }
}
