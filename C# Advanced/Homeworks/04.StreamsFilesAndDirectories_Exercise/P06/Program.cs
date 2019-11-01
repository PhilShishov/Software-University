using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace P06
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipFile = @"..\..\..\myNewzip.zip";
            var file = "copyMe.png";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
