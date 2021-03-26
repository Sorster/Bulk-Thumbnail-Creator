using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public class PhotoManager
    {
        public static void RenameImages(FileInfo[] files)
        {
            Console.WriteLine("---Rename---");

            string newFilesName;
            Console.WriteLine("Input name for all files");
            newFilesName = Console.ReadLine();

            int fileNumber = 1;
            try
            {
                foreach (var item in files)
                {
                    item.Rename($"{newFilesName}{fileNumber}.jpg");
                    fileNumber++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an exception!");
            }
        }

        public static void ResizeImages(string filePath)
        {
            Console.WriteLine("---Resize---");

            Console.WriteLine("Please input new image width");
            int width = GetNumber();

            Console.WriteLine("Please input new image heigth");
            int heigth = GetNumber();

            int fileIndex = 1;

            string[] files = Directory.GetFiles(filePath);
            try
            { 
                foreach (var item in files)
                {
                    Bitmap bmp = new Bitmap(item);
                    Image image = new Bitmap(bmp, width, heigth);
                    image.Save($"{filePath}/{fileIndex}.jpg");
                    fileIndex++;
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        public static int GetNumber()
        {
            do
            {
                Console.Write("Value: ");
                int value;
                if(int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
            } while (true);
        }
    }
}