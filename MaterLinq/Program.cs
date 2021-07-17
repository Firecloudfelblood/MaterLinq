using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaterLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var location = Path.Combine(Directory.GetCurrentDirectory(), "StudentStats");
            DisplayLargestFilesWithOutLinq(location);
            
            DisplayLargestFilesWithLinq(location);
        }

        private static void DisplayLargestFilesWithLinq(string path)
        {
            Console.WriteLine("\n Yes LINQ");
            var files = new DirectoryInfo(path).GetFiles()
                .Where(file => file.LastWriteTime > new DateTime(2020, 12, 01))
                    .OrderBy(file => file.Length) 
                    .Take(5);
            print(files);
        }

        private static void DisplayLargestFilesWithOutLinq(string path)
        {
            Console.WriteLine("\n No LINQ");
            var dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles();
            Array.Sort(files, (x, y) =>
                {
                    if (x.Length == y.Length)
                        return 0;
                    if (x.Length > y.Length)
                        return 1;
                    return -1;
                }
            );
            print(files);
        }

        private static void print(IEnumerable<FileInfo> files)
        {
            Console.WriteLine("\n");
            foreach (var file in files)
            {
                Console.WriteLine($"{file.Name} weights {file.Length}");
            }
        }
    }
}