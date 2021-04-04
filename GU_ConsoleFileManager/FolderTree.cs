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
            var dirInfo = new DirectoryInfo(startFolder);
            if (!dirInfo.Exists)
            {
                return;
            }
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

        public Node GetRoot()
        {
            if (_root != null)
                return _root;
            else return null;
        }
        
    }
}
