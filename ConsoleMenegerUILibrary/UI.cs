using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenegerUILibrary
{
    public static class UI
    {
        //"┬";
        //"┴";
        //"┤";
        //"├";
        //"┼";
        //"┌";
        //"┐";
        //"└";
        //"┘";
        //"│";
        //"─";
        public static void PrintConsole()
        {
            Console.Title = "Файловый менеджер";
            //Console.WindowHeight = 40;
            //Console.WindowWidth = 150; 
            Console.SetWindowSize(150, 40);
            Console.SetBufferSize(150, 40);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────┬──────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    ├──────────────────────────────────────────────┤");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("├────────────────────────────────────────────────────────────────────────────────────────────────────┤                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("│                                                                                                    │                                              │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────┴──────────────────────────────────────────────┘");

        }
    }
}
