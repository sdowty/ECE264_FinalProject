using System;
using System.IO;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            getData(@"..\..\..\rooms.txt");
        }

        static void getData(string filename)
        {
            using (StreamReader fs = new StreamReader(filename))
            {
                Console.WriteLine(fs.ReadLine());
            }
        }
    }
}
