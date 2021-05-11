using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcher_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystemWatcher = new FileSystemWatcher(@"E:\School\Code Practice\C#\Exam Project\New CSV")
            {
                Filter = "*.csv",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Attributes,
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Changed += OnActionOccurOnFolderPath;
            fileSystemWatcher.Created += OnActionOccurOnFolderPath;
            fileSystemWatcher.Deleted += OnActionOccurOnFolderPath;
            fileSystemWatcher.Renamed += OnActionOccurOnFolderPath;

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void OnActionOccurOnFolderPath(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("*** A file change has occured ***");
            Console.WriteLine(e.ChangeType);
            Console.WriteLine(e.Name);
        }

        private static void OnFileRenameOccur(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("*** Attention. The file was renamed ***");
            Console.WriteLine($"*** The old file name was: {e.OldName}");
            Console.WriteLine($"*** The new file name is: {e.Name}");
        }
    }
}
