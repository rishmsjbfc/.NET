using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //@"C:\Users\rishavraj7\Desktop\.Net\FileHandling\FileHandling\bin\Debug"
            //File.Create("secondFile.txt");
            //Console.Read();
            //File.Delete("secondFile.txt");
            //File.WriteAllText("secondFile.txt","Overdose of pure awesomeness");//creates and writes
            //string content = Console.ReadLine();
            //File.AppendAllText("secondFile.txt", content);
            //File.Copy("secondFile.txt", "firstFile.txt");
            //Directory.CreateDirectory("subDir2");
            //Directory.Delete(@"C:\Users\rishavraj7\Desktop\Desktop\.Net\ConsoleApp1\ConsoleApp1\bin\\Debug\subDir2");
            File.Move("secondFile.txt", @"C:\Users\rishavraj7\Desktop\Desktop\.Net\ConsoleApp1\ConsoleApp1\bin\Debug\subDir1\firstFile.txt");


            Console.Read();

        }
    }
}
