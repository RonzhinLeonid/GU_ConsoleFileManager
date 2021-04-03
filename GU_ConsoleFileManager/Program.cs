using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenegerUILibrary;

namespace GU_ConsoleFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
            //Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
            
            UI.PrintConsole();
            var t = new FolderTree(@"E:");
            t.PrintTree();

            Console.ReadKey();
        }
        static void GetRecursFiles(string start_path, int level, ref int lvl)
        {
            lvl++;
            string[] folders = Directory.GetDirectories(start_path);
            foreach (string folder in folders)
            {
                DirectoryInfo info = new DirectoryInfo(folder);
                if ((info.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    Console.WriteLine("Папка: " + folder + "\n");
                    if (lvl < level)
                        GetRecursFiles(folder, level, ref lvl);
                }
            }
            lvl--;
            string[] files = Directory.GetFiles(start_path);
            foreach (string filename in files)
            {
                Console.WriteLine("Файл: " + filename + "\n");
            }
        }
    }
}
