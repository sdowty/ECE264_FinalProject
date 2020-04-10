using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Program
    {
        static List<AdventureRoom> myRooms;

        static void Main(string[] args)
        {
            myRooms = new List<AdventureRoom>(140);
            getData(@"..\..\..\rooms.txt");

            myRooms[8].Print();
        }

        static void getData(string filename)
        {
            string tmp;
            using (StreamReader fs = new StreamReader(filename))
            {
                fs.ReadLine(); //section 1
                myRooms.Add(new AdventureRoom());
                //Console.WriteLine(fs.ReadLine());
                while (true)
                {
                    // get room descriptions

                    tmp = fs.ReadLine();
                    string[] q = tmp.Split('\t');
                    int roomNumber = int.Parse(q[0]);

                    if(roomNumber<0)
                    {
                        break;
                    }

                    if (myRooms.Count < roomNumber + 1)
                    {
                        myRooms.Add(new AdventureRoom());
                    }
                    if (myRooms[roomNumber].Description.Length == 0)
                        myRooms[roomNumber].Description = q[1];
                    else
                        myRooms[roomNumber].Description += " " + q[1];
                    // done with room descriptions
                }

                tmp = fs.ReadLine(); //start section 2
                while (true)
                {
                    tmp = fs.ReadLine();
                    string[] q = tmp.Split('\t');
                    int roomNumber = int.Parse(q[0]);

                    if (roomNumber < 0)
                        break;
                    myRooms[roomNumber].ShortDescription = q[1];
                }

                Console.WriteLine(fs.ReadLine());
            }
        }
    }
}