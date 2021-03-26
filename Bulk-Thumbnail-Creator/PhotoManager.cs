using System.Drawing;
using System.IO;

namespace Bulk_Thumbnail_Creator
{
    public class PhotoManager
    {
        public static void RenameImages(FileInfo[] files,  string newFilesName)
        {
            int fileNumber = 1;

            foreach (var item in files)
            {
                item.MoveTo(Path.Combine(item.Directory.FullName, $"{newFilesName}{fileNumber}.jpg"));
                fileNumber++;
            }
        }

        public static void ResizeImages(string filePath, int width, int heigth)
        {
            int fileIndex = 1;
            string[] files = Directory.GetFiles(filePath);

            foreach (var item in files)
            {
                Bitmap bmp = new Bitmap(item);
                Image image = new Bitmap(bmp, width, heigth);
                image.Save($"{filePath}/{fileIndex}.jpg");
                fileIndex++;
            }
        }
    }
}