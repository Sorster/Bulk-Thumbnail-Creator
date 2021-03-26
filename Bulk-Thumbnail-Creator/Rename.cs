using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Thumbnail_Creator
{
    public static class RenameClass
    {
        public static void Rename(this FileInfo fileInfo, string name)
        {
            fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, name));
        }
    }
}
