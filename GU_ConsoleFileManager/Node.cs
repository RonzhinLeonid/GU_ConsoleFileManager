using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GU_ConsoleFileManager
{
    class Node
    {
        public int Level { get; set; }
        public string Path { get; set; }
        public string[] Files { get; set; }
        public List<Node> Edges { get; set; }
        public Node()
        {

        }
        public Node(string path)
        {
            Level = GetLevelPath(path);
            Path = path;
            Files = Directory.GetFiles(path + "\\");
            Edges = new List<Node>();
        }
        static int GetLevelPath(string path)
        {
            var temp = path.Split('\\');
            return temp.Length;
        }
    }
}
