using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    public abstract class Command
    {

        protected List<string> parametrs;
        protected int startViewFolder;
        protected int startViewFiles;
        protected int lengthViewFolder;
        protected int lengthViewFiles;

        public List<string> Parametrs { set { parametrs = value; } }
        public int StartViewFolder 
        {
            get
            {
                return startViewFolder;
            }
            set
            { 
                startViewFolder = value;
            }
        }
        public int StartViewFiles 
        {
            get
            {
                return startViewFiles;
            }
            set
            {
                startViewFiles = value;
            }
        } 
        public int LengthViewFolder
        {
            get
            {
                return lengthViewFolder;
            }
            set
            {
                lengthViewFolder = value;
            }
        }
        public int LengthViewFiles
        {
            get
            {
                return lengthViewFiles;
            }
            set
            {
                lengthViewFiles = value;
            }
        }

        public abstract string Name { get; }

        public virtual bool CanHandle(string cmd)
        {
            return cmd == Name;
        }

        public abstract void Handle();
    }
}
