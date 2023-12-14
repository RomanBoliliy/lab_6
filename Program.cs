using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace lab_6
{

    internal class Program
    {
        
        static void Main(string[] args)
        {
            FileMonitor sm = new FileMonitor();
            sm.FindChange();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

     
        class FileMonitor {


            const string PATH = @"C:\Users\Роман\Desktop\lab_6\lab_6";

            FileSystemWatcher watcher = new FileSystemWatcher(PATH);

            public delegate void FileMonitorDelegate(string path);
            string res;
            public void FindChange() { 

                watcher.Changed += OnFileModified;
                watcher.Created += OnFileCreated;
                watcher.Deleted += OnFileDeleted;
                watcher.Renamed += OnFileRenamed;

                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
            }

            private static void OnFileModified(object sender, FileSystemEventArgs e)
            {
                if (e.ChangeType != WatcherChangeTypes.Changed)
                {
                    return;
                }
                Console.WriteLine($"Changed: {e.FullPath}");
            }
            private static void OnFileCreated(object sender, FileSystemEventArgs e) =>
                Console.WriteLine($"Created:{e.Name} \nPath: {e.FullPath}");



            private static void OnFileDeleted(object sender, FileSystemEventArgs e) =>
                Console.WriteLine($"Deleted: {e.Name} \nPath: {e.FullPath}" );

            private static void OnFileRenamed(object sender, RenamedEventArgs e) =>
                Console.WriteLine($"Renamed: {e.OldName} \nNew name:{e.Name} \nPath: {e.FullPath}");
        }

    }
}
