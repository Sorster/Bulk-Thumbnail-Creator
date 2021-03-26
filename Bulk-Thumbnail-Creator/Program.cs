using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public class Program
    {
        static void Main()
        {
            string filePath = @"E:\newphot"; 

            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            FileInfo[] files = directoryInfo.GetFiles();

            Task.Factory.StartNew(() => PhotoManager.RenameImages(files)).Wait();
            Task.Factory.StartNew(() => PhotoManager.ResizeImages(filePath)).Wait();
    
            Console.WriteLine("Operations were completed!");
            Console.WriteLine("Check path: " + filePath);

            Console.ReadKey();
        }
    }
}
