using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace MakeSquare
{
    class FileParallel
    {
        public static String ReadFile()
        {
            string text = System.IO.File.ReadAllText(File.nameFile);
            Console.WriteLine("File :- " + text);
            return text;
        }
        
        public static async Task<string> readFile()
        {
            string filePath = File.nameFile;




            string text = await ReadTextAsync(filePath);

            Debug.WriteLine(text);
            // Console.WriteLine(text);



            return text;
        }

        private static async Task<string> ReadTextAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.UTF8.GetString(buffer, 0, numRead);
                    sb.Append(text);

                }

                return sb.ToString();


            }
        }
        


    }

    
}
