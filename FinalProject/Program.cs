using System;
using System.IO;

namespace FinalProject
{
    class Program
    {
        static List<AdventureRoom> myRooms;

        static void Main(string[] args)
        {
            myRooms = new List<AdventureRoom>(140);
            getData(@"..\..\..\rooms.txt");

            Console.WriteLine(myRooms[4].Description);
        }

        static void getData(string filename)
        {
            using (StreamReader fs = new StreamReader(filename))
            {
                fs.ReadLine(); //section 1
                //Console.WriteLine(fs.ReadLine());
                while (true)
                {
                    string tmp = fs.ReadLine();
                    string[] q = tmp.split('\t');
                    int roomNumber = int.parse(q[0]);

                    if(roomNumber<0)
                    {
                        break;
                    }

                    if (myRooms.Count < roomNumber)
                    {
                        myRooms.Add(new AdventureRoom());
                    }
                    myRooms[roomNumber].Description += q[1];
                    
                }
            }
        }
    }
}