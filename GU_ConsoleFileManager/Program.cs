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
        static string path = @"E:\Проект обучение";
        static int startViewFolder = 0;
        static int startViewFiles = 0;
        static int lengthViewFolder = 20;
        static int lengthViewFiles = 10;

        static void Main(string[] args)
        {
            UI.PrintConsole();

            List<Command> commands = new List<Command>();
            commands.Add(new MoveFolderCommand());
            commands.Add(new NextFoldersDirectory());
            commands.Add(new NextFilesDirectory());
            commands.Add(new PrevFoldersDirectory());
            commands.Add(new PrevFilesDirectory());

            while (true)
            {
                string cmd = GetCommand();
                List<string> parametrs = new List<string>();
                string comand = ParseCommand(cmd, ref parametrs);

                foreach (var item in commands)
                {
                    if (item.CanHandle(comand))
                    {
                        item.Parametrs = parametrs;
                        item.StartViewFolder = startViewFolder;
                        item.StartViewFiles = startViewFiles;
                        item.LengthViewFolder = lengthViewFolder;
                        item.LengthViewFiles = lengthViewFiles;
                        item.Handle();
                        startViewFolder = item.StartViewFolder;
                        startViewFiles = item.StartViewFiles;
                        lengthViewFolder = item.LengthViewFolder;
                        lengthViewFiles = item.LengthViewFiles;
                        break;
                    }
                }
            }
            //string path = @"E:\Проект обучение";

            //var selectFolder = new SelectFolder(path);
            //selectFolder.PrintInfo();
            //selectFolder.PrintTree(0, 20);
            //selectFolder.PrintTree(20, 40);
            //selectFolder.PrintTree(40, 60);
            //selectFolder.PrintTree(60, 80);
            //selectFolder.PrintTree(80, 100);
            //selectFolder.PrintFile(0, 10);
            //selectFolder.PrintFile(10, 20);
            //selectFolder.PrintFile(20, 30);
            //selectFolder.PrintFile(30, 40);
            //selectFolder.PrintFile(40, 50);

            //var t = new FolderTree(path);
            //var t = new FolderTree(@"E:");

            //var dirInfo = new DirectoryInfo(path);
            //var dirSize = DirSize(dirInfo);


            //t = new FolderTree(@"E:\Проект обучение\AutoCAD");
            //selectFolder.PrintTree(0, 20);
            //selectFolder.PrintTree(51, 70);
            //Console.WriteLine();
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
        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parametrs"></param>
        /// <returns></returns>
        private static string ParseCommand(string cmd, ref List<string> parametrs)
        {
            var temp = cmd.Split(' ');
            for (int i = 1; i < temp.Length; i++)
            {
                parametrs.Add(temp[i]);
            }
            return temp[0];
        }

        /// <summary>
        /// Получить команду из консоли
        /// </summary>
        /// <returns></returns>
        private static string GetCommand()
        {
            Console.SetCursorPosition(0, 34);
            var cmd = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new String(' ', Console.BufferWidth));
            return cmd;
        }
    }
}
