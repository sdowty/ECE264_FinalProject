using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Program
    {
        static List<AdventureRoom> myRooms;
        static List<AdventureVocab> myVocab;

        static void Main(string[] args)
        {
            myRooms = new List<AdventureRoom>(140);
            myVocab = new List<AdventureVocab>();
            getData(@"..\..\..\rooms.txt");

            //testSection4();
        }

        static void testSection4()
        {
            string input;
            int number;
            bool found;

            while(true)
            {
                input = Console.ReadLine();
                found = false;
                if(int.TryParse(input, out number))
                {
                    if (number == 0)
                        return;
                    //find num in list
                    foreach(AdventureVocab v in myVocab)
                    {
                        if(v.Index == number)
                        {
                            Console.WriteLine(v);
                            found = true;
                            break;
                        }
                    }
                    if(!found)
                        Console.WriteLine("Not found.");
                }
                else
                {
                    //find word in list
                    foreach (AdventureVocab v in myVocab)
                    {
                        if (string.Compare(v.Word, 0, input.ToUpper(), 0, 5) == 0)
                        {
                            Console.WriteLine(v);
                            found = true;
                            break;
                        }
                    }
                    if(!found)
                        Console.WriteLine("Not found.");
                }
            }
        }

        static void GetSection1(StreamReader fs)
        {
            string tmp;
            fs.ReadLine(); //section 1
            myRooms.Add(new AdventureRoom());
            //Console.WriteLine(fs.ReadLine());
            while (true)
            {
                // get room descriptions

                tmp = fs.ReadLine();
                string[] q = tmp.Split('\t');
                int roomNumber = int.Parse(q[0]);

                if (roomNumber < 0)
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
        }

        static void GetSection2(StreamReader fs)
        {
            string tmp;
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
        }

        static void GetSection3(StreamReader fs)
        {
            string tmp;
            fs.ReadLine();
            while (true)
            {
                tmp = fs.ReadLine();
                string[] q = tmp.Split('\t');
                int roomNumber = int.Parse(q[0]);

                if (roomNumber < 0)
                    break;
                // skip it
            }
        }

        static void GetSection4(StreamReader fs)
        {
            string tmp; //section4
            fs.ReadLine();
            while (true)
            {
                tmp = fs.ReadLine();
                string[] q = tmp.Split('\t');
                int vocabNumber = int.Parse(q[0]);
                int M = vocabNumber / 1000;
                int index = M % 1000;
                if (vocabNumber < 0)
                    return;

                myVocab.Add(new AdventureVocab(vocabNumber, q[1]));
            }
        }

        static void GetSection5(StreamReader fs)
        {
            AdventureItem item;
            string tmp;
            int itemNumber;

            fs.ReadLine(); // section 5

            tmp = fs.ReadLine();
            string[] q = tmp.Split('\t');
            itemNumber = int.Parse(q[0]);

            while (itemNumber > 0)
            {
                
                item = new AdventureItem();
                itemNumber = int.Parse(q[0]);
                item.Index = itemNumber;
                item.ShortDescription = q[1];

                // getting state description
                tmp = fs.ReadLine();
                q = tmp.Split('\t');
                int descNumber = int.Parse(q[0]);
                int t = descNumber % 100;

                while (t == 0)  //description
                {
                    t = itemNumber / 100;
                    if (item.StateDescriptions.Count <= t)
                    {
                        item.StateDescriptions.Add(q[1]);
                    }
                    else
                    {
                        item.StateDescriptions[t] += " " + q[1];
                    }

                    tmp = fs.ReadLine();
                    q = tmp.Split('\t');
                    int descNumber = int.Parse(q[0]);
                    int t = descNumber % 100;
                }

                itemNumber = descNumber;
                // q and itemNumber must contain next data
            }
        }

        static void getData(string filename)
        {
            string tmp;
            using (StreamReader fs = new StreamReader(filename))
            {
                GetSection1(fs);
                GetSection2(fs);
                GetSection3(fs);
                GetSection4(fs);
                GetSection5(fs);

                Console.WriteLine(fs.ReadLine());
            }
        }
    }
}