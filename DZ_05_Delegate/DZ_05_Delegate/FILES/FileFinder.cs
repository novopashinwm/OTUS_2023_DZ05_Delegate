using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_05_Delegate.FILES
{
    public class FileFinder
    {
        private string path = string.Empty;
        public event EventHandler<FileArgs>? FileFound;

        public FileFinder(string path) 
        {
            this.path = path;
        }

        public void IsFileExists(CancellationToken cancellationToken) 
        {
            if (string.IsNullOrEmpty(path) || cancellationToken.IsCancellationRequested)
                return;
            var filesAndDirs = new List<string>(Directory.GetFiles(path));
            filesAndDirs.AddRange(Directory.GetDirectories(path));
            foreach (var item in filesAndDirs)
            {
                if (IsDir(item))
                {
                    Console.WriteLine($"This is dir {item}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"This is file {item}");
                    OnFileFound(this, new FileArgs { Name = Path.GetFileName(item) });
                }
                Thread.Sleep(3000);

                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Canceling to finding files!!!");

                    return;
                }

            }

        }

        public bool IsDir(string path)
        {
            return ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory);
        }

        public void OnFileFound(object sender, FileArgs args)
        {
            FileFound?.Invoke(this, args);
        }
    }
}
