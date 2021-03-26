using System;
using System.IO;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public class Program
    {
        static void Main()
        {
            string filesPath = @"E:\newphot"; 

            DirectoryInfo directoryInfo = new DirectoryInfo(filesPath);
            FileInfo[] files = directoryInfo.GetFiles();

            Task.Factory.StartNew(() => RenamePictures(files)).Wait();
            Task.Factory.StartNew(() => ResizePictures(filesPath)).Wait();
    
            Console.WriteLine("Operations were completed!");
            Console.WriteLine("Check path: " + filesPath);

            Console.ReadKey();
        }

        static void RenamePictures(FileInfo[] files)
        {
            Console.WriteLine("---Rename---");

            string newFilesName;
            Console.WriteLine("Input name for all files");
            newFilesName = Console.ReadLine();

            PhotoManager.RenameImages(files, newFilesName);
        }

        static void ResizePictures(string filePath)
        {
            Console.WriteLine("---Resize---");

            Console.WriteLine("Please input new image width");
            int width = GetNumber();

            Console.WriteLine("Please input new image heigth");
            int heigth = GetNumber();

            PhotoManager.ResizeImages(filePath, width, heigth);
        }

        static int GetNumber()
        {
            do
            {
                Console.Write("Value: ");
                int value;
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
            } while (true);
        }
    }
}
