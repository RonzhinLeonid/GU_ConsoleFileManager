using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    public class MoveFolderCommand : Command
    {
        public override string Name => "MoveFolder";

        public override void Handle()
        {
            startViewFolder = 0;
            startViewFiles = 0;
            string path = parametrs[0];
            var selectFolder = new SelectFolder(path);
            selectFolder.PrintInfo();
            selectFolder.PrintTree(startViewFolder, lengthViewFolder);
            selectFolder.PrintFile(startViewFiles, lengthViewFiles);
        }
    }
}
