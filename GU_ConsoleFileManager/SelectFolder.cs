using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    class SelectFolder
    {
        static int countFiles;
        static int countHiddenFiles = 0;
        static int countSubFolders;
        static int countHiddenFolders = 0;
        long size;
        FolderTree folderTree;
        public SelectFolder(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                return;
            }
            size = GetDirSize(dirInfo);
            GetCountFiles(dirInfo);
            GetCountSubFolders(dirInfo);
            folderTree = new FolderTree(path);
        }
        /// <summary>
        /// Вывод информации о содержимом выбранной папки
        /// </summary>
        public void PrintInfo()
        {
            int cursorPosX = 102;
            int cursorPosY = 1;
            Console.CursorLeft = cursorPosX;
            Console.CursorTop = cursorPosY;
            Console.WriteLine("Информация о директории:");
            Console.CursorLeft = cursorPosX;
            Console.WriteLine($"Кол-во файлов:             {countFiles}");
            Console.CursorLeft = cursorPosX;
            Console.WriteLine($"Кол-во скрытых файлов:     {countHiddenFiles}");
            Console.CursorLeft = cursorPosX;
            Console.WriteLine($"Кол-во подпапок:           {countSubFolders}");
            Console.CursorLeft = cursorPosX;            
            Console.WriteLine($"Кол-во скрытых подпапок:   {countHiddenFolders}");
            Console.CursorLeft = cursorPosX;
            Console.WriteLine($"Общий размер содержимого:  {size}");
        }
        /// <summary>
        /// Вывод в консоль структуры папок
        /// </summary>
        /// <param name="startPos">Начальная позиция вывода</param>
        /// <param name="endPos"></param>
        public void PrintTree(int startPos, int endPos)
        {
            int cursorPosX = 1;
            int cursorPosY = 1;
            var root = folderTree.GetRoot();
            if (root == null)
            {
                return;
            }
            string lastNode = "";
            if (root.Edges.Count != 0)
            {
                lastNode = root.Edges[root.Edges.Count - 1].Path;
            }

            int countString = endPos - startPos;
            int numberString = 0;
            var stack = new Stack<Node>();
            var lvlRoot = root.Level;
            var lvlPrev = 0;
            int lvlNode;
            bool lastNodeBool = false;

            Console.CursorLeft = cursorPosX;
            Console.CursorTop = cursorPosY;
            Console.WriteLine($"Path: {root.Path}");

            for (int i = root.Edges.Count - 1; i >= 0; i--)
            {
                stack.Push(root.Edges[i]);
            }
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (lastNode == node.Path && !lastNodeBool)
                    lastNodeBool = true;
                lvlNode = node.Level - lvlRoot;
                int nextLvl;
                if (stack.Count != 0) nextLvl = stack.Peek().Level - lvlRoot;
                else nextLvl = 0;
                if (numberString >= startPos && numberString < endPos)
                {
                    Console.CursorLeft = cursorPosX;
                    var str = Getprefix(lvlPrev, lvlNode, nextLvl, lastNodeBool) + Path.GetFileName(node.Path);
                    if (str.Length > 100)
                    {
                        str = str.Substring(0, 97) + "...";
                    }
                    Console.WriteLine($"{str,-100}");
                    countString--;
                }
                numberString++;

                for (int i = node.Edges.Count - 1; i >= 0; i--)
                {
                    stack.Push(node.Edges[i]);
                }
                if (numberString >= endPos) break;
            }
            if (countString > 0)
                for (int i = 0; i < countString; i++)
                {
                    Console.CursorLeft = cursorPosX;
                    var str = "";
                    Console.WriteLine($"{str,-100}");
                }
        }
        /// <summary>
        /// Вывод в консоль списка файлов заданной директории
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        public void PrintFile(int startPos, int endPos)
        {
            int cursorPosX = 1;
            int cursorPosY = 23;
            int numberString = 0;
            int countString = endPos - startPos;
            var root = folderTree.GetRoot();
            if (root == null)
            {
                return;
            }
            Console.CursorLeft = cursorPosX;
            Console.CursorTop = cursorPosY;
            foreach (var item in root.Files)
            {
                if (numberString >= startPos && numberString < endPos)
                {
                    Console.CursorLeft = cursorPosX;
                    var temp = new FileInfo(item);
                    var isHiiden = (temp.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                    Console.WriteLine($"{Path.GetFileNameWithoutExtension(item),-35} {Path.GetExtension(item),-10} {temp.Length,10} {temp.LastWriteTime,20} {temp.IsReadOnly,7} {isHiiden,7}");
                    countString--;
                }
                numberString++;
                if (numberString >= endPos) break;
            }
            if (countString > 0)
                for (int i = 0; i < countString; i++)
                {
                    Console.CursorLeft = cursorPosX;
                    var str = "";
                    Console.WriteLine($"{str,-100}");
                }

        }

        /// <summary>
        /// Получение размера папки
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        static long GetDirSize(DirectoryInfo dirInfo)
        {
            long Size = 0;
            // Добавить размеры файлов.
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo fi in files)
            {
                Size += fi.Length;
            }
            // Добавьте размеры подкаталогов.
            DirectoryInfo[] folders = dirInfo.GetDirectories();
            foreach (DirectoryInfo di in folders)
            {
                Size += GetDirSize(di);
            }
            return Size;
        }
        /// <summary>
        /// Получение количества файлов в папке
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        static void GetCountFiles(DirectoryInfo dirInfo)
        {
            countFiles = dirInfo.GetFiles().Length;
            string[] files = Directory.GetFiles(dirInfo.FullName + "\\");
            foreach (string file in files)
            {
                DirectoryInfo info = new DirectoryInfo(file);
                if ((info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    countHiddenFiles++;
                }
            }

        }
        /// <summary>
        /// Получение количества папок в папке
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        static void GetCountSubFolders(DirectoryInfo dirInfo)
        {
            countSubFolders = dirInfo.GetDirectories().Length;
            string[] folders = Directory.GetDirectories(dirInfo.FullName + "\\");
            foreach (string folder in folders)
            {
                DirectoryInfo info = new DirectoryInfo(folder);
                if ((info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    countHiddenFolders++;
                }
            }

        }
        
        /// <summary>
        /// Получение префикса для стоки
        /// </summary>
        /// <param name="lvlPrev"></param>
        /// <param name="lvl"></param>
        /// <param name="nextLvl"></param>
        /// <param name="lastNode"></param>
        /// <returns></returns>
        static string Getprefix(int lvlPrev, int lvl, int nextLvl, bool lastNode)
        {
            string sepaseparator = "";
            if (lvl - lvlPrev == 0) return "│";
            if (lastNode)
            {
                if (lvl - lvlPrev == 1) return "└";
                for (int i = 2; i < lvl - lvlPrev; i++)
                {
                    sepaseparator += "│";
                }
                sepaseparator = " " + sepaseparator;
            }
            else
            {
                if (lvl - lvlPrev == 1) return "├";
                for (int i = 1; i < lvl - lvlPrev; i++)
                {
                    sepaseparator += "│";
                }
            }
            if (nextLvl <= lvl) return sepaseparator + "└";
            else return sepaseparator + "├";
        }
    }
}
