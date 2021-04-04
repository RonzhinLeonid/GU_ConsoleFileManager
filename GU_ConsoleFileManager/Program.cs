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
            UI.PrintConsole();

            string path = @"E:\Проект обучение";

            var selectFolder = new SelectFolder(path);
            selectFolder.PrintInfo();
            selectFolder.PrintTree(0, 20);
            selectFolder.PrintTree(20, 40);
            selectFolder.PrintTree(40, 60);
            selectFolder.PrintTree(60, 80);
            selectFolder.PrintTree(80, 100);
            selectFolder.PrintFile(0, 10);
            selectFolder.PrintFile(10, 20);
            selectFolder.PrintFile(20, 30);
            selectFolder.PrintFile(30, 40);
            selectFolder.PrintFile(40, 50);

            //var t = new FolderTree(path);
            //var t = new FolderTree(@"E:");

            //var dirInfo = new DirectoryInfo(path);
            //var dirSize = DirSize(dirInfo);


            //t = new FolderTree(@"E:\Проект обучение\AutoCAD");
            selectFolder.PrintTree(0, 20);
            selectFolder.PrintTree(51, 70);
            Console.WriteLine();
            //var originalpos = Console.CursorTop;

            //var k = Console.ReadKey();
            //var i = 2;

            //while (k.KeyChar != 'q')
            //{
            //    if (k.Key == ConsoleKey.UpArrow)
            //    {
            //        Console.SetCursorPosition(0, Console.CursorTop - i);
            //        Console.ForegroundColor = ConsoleColor.Black;
            //        Console.BackgroundColor = ConsoleColor.White;
            //        Console.WriteLine("Option " + (Console.CursorTop + 1));
            //        Console.ResetColor();
            //        i++;

            //    }

            //    Console.SetCursorPosition(8, originalpos);
            //    k = Console.ReadKey();
            //}

            Console.ReadKey();
        }
        /// <summary>
        /// Получение размера папки
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        //public static long DirSize(DirectoryInfo d)
        //{
        //    long Size = 0;
        //    // Добавить размеры файлов.
        //    FileInfo[] fis = d.GetFiles();
        //    foreach (FileInfo fi in fis)
        //    {
        //        Size += fi.Length;
        //    }
        //    // Добавьте размеры подкаталогов.
        //    DirectoryInfo[] dis = d.GetDirectories();
        //    foreach (DirectoryInfo di in dis)
        //    {
        //        Size += DirSize(di);
        //    }
        //    return (Size);
        //}





        //static void GetRecursFiles(string start_path, int level, ref int lvl)
        //{
        //    lvl++;
        //    string[] folders = Directory.GetDirectories(start_path);
        //    foreach (string folder in folders)
        //    {
        //        DirectoryInfo info = new DirectoryInfo(folder);
        //        if ((info.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
        //        {
        //            Console.WriteLine("Папка: " + folder + "\n");
        //            if (lvl < level)
        //                GetRecursFiles(folder, level, ref lvl);
        //        }
        //    }
        //    lvl--;
        //    string[] files = Directory.GetFiles(start_path);
        //    foreach (string filename in files)
        //    {
        //        Console.WriteLine("Файл: " + filename + "\n");
        //    }
        //}
    }
}
