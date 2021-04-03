using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    class FolderTree
    {
        private Node _root;
        public FolderTree()
        {

        }
        public FolderTree(string startFolder)
        {
            FillFolderTree(startFolder);
        }
        /// <summary>
        /// Заполнение дерева
        /// </summary>
        /// <param name="startFolder"></param>
        public void FillFolderTree(string startFolder)
        {
            _root = new Node(startFolder);
            string[] folders = Directory.GetDirectories(startFolder + "\\");
            foreach (string folder in folders)
            {
                DirectoryInfo info = new DirectoryInfo(folder);
                if ((info.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    _root.Edges.Add(new Node(folder));
                }
            }
            ///этот кусок выделитьв рекурсия для возможности задания уровней
            foreach (var item in _root.Edges)
            {
                folders = Directory.GetDirectories(item.Path);
                foreach (string folder in folders)
                {
                    DirectoryInfo info = new DirectoryInfo(folder);
                    if ((info.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        item.Edges.Add(new Node(folder));
                    }
                }
            }
        }

        public void PrintTree()
        {
            if (_root == null)
            {
                Console.WriteLine("Папка пуста");
                return;
            }
            var stack = new Stack<Node>();
            var lastNode = _root.Edges[_root.Edges.Count - 1].Path;
            var lvlRoot = _root.Level;
            var lvlPrev = 0;
            int lvlNode;
            bool lastNodeBool = false;
            Console.WriteLine(_root.Path);
            //stack.Push(_root);
            for (int i = _root.Edges.Count - 1; i >= 0; i--)
            {
                stack.Push(_root.Edges[i]);
            }
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (lastNode == node.Path && !lastNodeBool)
                    lastNodeBool = true;
                lvlNode = node.Level - lvlRoot;
                //GetLevelPath(lvl - lvlRoot, newLvl - lvlRoot)
                var nextLvl = 0;
                if (stack.Count != 0) nextLvl = stack.Peek().Level;
                else nextLvl = 0;
                Console.WriteLine(GetLevelPath(lvlPrev, lvlNode, nextLvl, lastNodeBool) + Path.GetFileName(node.Path));
                for (int i = node.Edges.Count -1; i >= 0 ; i--)
                {
                    stack.Push(node.Edges[i]);
                }
                //lvlPrev = lvlNode;
                //foreach (var item in node.Edges)
                //{

                //        //Console.WriteLine(Path.GetDirectoryName(node.Path));
                //}
            }
        }
        
        static string GetLevelPath(int lvlPrev, int lvl, int nextLvl, bool lastNode)
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
