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
            String WatchingHere = @"E:\School\Code Practice\C#\Exam Project\New CSV";
            var fileSystemWatcher = new FileSystemWatcher(WatchingHere)
            { 
                Filter = "*.csv", 
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Attributes,
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Changed += ActionOccurOnFileChange;
            fileSystemWatcher.Created += ActionOccurOnFileCreated;
            fileSystemWatcher.Deleted += ActionOccurOnFileDeled;
            fileSystemWatcher.Renamed += ActionOccurOnFileRenamed;

            Console.WriteLine("File System Watcher is now running." +
                "\nThe following path is being monitored: '" + WatchingHere + "'." +
                "\nAny changes made will appear below." +
                "\nIf you want to terminate," +
                "\npress any key and ENTER.");
            Console.ReadLine();
        }

        private static void ActionOccurOnFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("*** Hey! A new file was added.");
            Console.WriteLine(e.ChangeType + ".");
            Console.WriteLine(e.Name);
        }

        private static void ActionOccurOnFileChange(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("*** A file change has occured.");
            Console.WriteLine(e.ChangeType + ".");
            Console.WriteLine(e.Name);
        }

        private static void ActionOccurOnFileDeled(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("*** The following file has been deleted:");
            Console.WriteLine(e.ChangeType + ".");
            Console.WriteLine(e.Name);
        }

        private static void ActionOccurOnFileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("*** The following file has been renamed:");
            Console.WriteLine($"The old file name was: '{e.OldName}'.");
            Console.WriteLine($"The new file name is: '{e.Name}'.");
        }
    }
}
