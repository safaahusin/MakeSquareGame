using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSquare
{
    class File
    {
        /* input => vaild 4 shape
         * input1 => no sol
         * input2 => vaild 5 shape
         * input3 => invaild input
         * 
         */
        public static String nameFile; 

        public static String ReadFile()
        {
            nameFile= @StartForm.fileName + ".txt";
            string text = System.IO.File.ReadAllText(nameFile);
            Console.WriteLine("File :- " + text );
            return text;
        }
    }
}
