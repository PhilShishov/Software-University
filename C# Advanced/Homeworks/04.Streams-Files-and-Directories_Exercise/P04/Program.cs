using System;
using System.IO;

namespace P04
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = "copyMe.png";
            string picCopyPath = "copyMe-copy.png";

            var reader = new FileStream(picPath, FileMode.Open);

            using (reader)
            {
                var buffer = new byte[4096];

                using (var writer = new FileStream(picCopyPath, FileMode.Create))
                {
                    while (true)
                    {
                        var totalByte = reader.Read(buffer, 0, buffer.Length);

                        if (totalByte == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, totalByte);
                    }
                }
            }

        }
    }
}
