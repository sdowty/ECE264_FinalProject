using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Program
    {
        static Dictionary<int, AdventureRoom> myRooms;
        static List<AdventureVocab> myVocab;
        static Dictionary<int, AdventureItem> myItems;
        static Dictionary<int, string> myMessages;
        static AdventureActor player;

        static void Main(string[] args)
        {
            myRooms = new Dictionary<int, AdventureRoom>(140);
            myVocab = new List<AdventureVocab>();  //keys are not unique
            myItems = new Dictionary<int, AdventureItem>();
            myMessages = new Dictionary<int, string>();
            player = new AdventureActor();
            getData(@"..\..\..\rooms.txt");

            //myRooms[100].Print();
            Console.WriteLine(myMessages[1]);
            Console.WriteLine('\n');
            Console.WriteLine(myMessages[65]);
            string poss = Console.ReadLine();
            if (poss.ToUpper() == "YES" || poss.ToUpper() == "Y")
                Console.WriteLine(myMessages[142]);

            player.CurrentRoom = myRooms[1];
            string command;
            while (true)
            {
                if (player.CurrentRoom.Flags.HasFlag(RoomFlags.light) 
                    || ((player.HasItem(2) || player.CurrentRoom.HasItem(2)) 
                    && myItems[2].State == 1))
                {
                    Console.WriteLine(player.CurrentRoom);
                }
                
                Console.Write(">");
                command = Console.ReadLine();
                string[] cmdlist = command.Split(' ');

                int myToken = Tokenize(cmdlist[0]);
                int myToken2 = 0;
                if (cmdlist.Length == 2)
                    myToken2 = Tokenize(cmdlist[1]);

                if (myToken == -1) 
                {
                    Console.WriteLine("I DON'T KNOW THAT WORD.");
                    continue;
                }
                else if (myToken > 2000 && myToken < 3000)  // verbs
                {
                    if (myToken2 == -1) // word that isnt in vocab
                    {
                        Console.WriteLine("CAN'T FIND {0}\n", cmdlist[1].ToUpper());
                    }
                    if (myToken == 2001 && myToken2 > 1000 && myToken2 < 2000)  // get stuff
                    {
                        int itemNumber = myToken2 % 1000;
                        AdventureItem item = myItems[itemNumber];
                        
                        if (player.CurrentRoom.HasItem(8))  // getting the bird
                        {
                            if (!player.HasItem(4)) // cage
                            {
                                Console.WriteLine(myMessages[18]);
                            }
                            else if (player.HasItem(5) || player.HasItem(6)) // need to drop rod
                            {
                                Console.WriteLine(myMessages[19]);
                            }
                            else
                            {
                                player.CurrentRoom.RemoveItem(itemNumber);  // get bird
                                player.AddItem(item);
                                Console.WriteLine("GOT {0}\n", cmdlist[1].ToUpper());
                            }
                        }
                        else if (player.CurrentRoom.HasItem(itemNumber))
                        {
                            player.CurrentRoom.RemoveItem(itemNumber);
                            player.AddItem(item);
                            Console.WriteLine("GOT {0}\n", cmdlist[1].ToUpper());
                        }
                        else
                        {
                            Console.WriteLine("CAN'T FIND {0}\n", cmdlist[1].ToUpper());
                        }
                    }
                    else if (myToken == 2002 && myToken2 > 1000 && myToken2 < 2000)     // drop items
                    {
                        int itemNumber = myToken2 % 1000;
                        AdventureItem item = myItems[itemNumber];

                        if (player.HasItem(itemNumber))
                        {
                            player.RemoveItem(itemNumber);
                            player.CurrentRoom.AddItem(item);
                            Console.WriteLine("DROPPED {0}\n", cmdlist[1].ToUpper());
                        }
                        else
                        {
                            Console.WriteLine("CAN'T FIND {0}\n", cmdlist[1].ToUpper());
                        }
                    }
                    else if (myToken == 2003)   // say or talk
                    {
                        for (int i = 1; i < +cmdlist.Length; i++)
                        {
                            Console.Write("{0} ", cmdlist[i].ToUpper());
                        }
                        Console.WriteLine("\n");
                    }
                    else if (myToken == 2004) //unlock
                    {
                        if (player.HasItem(1) && myItems[3].State == 0 && player.CurrentRoom.HasItem(3))
                        {
                            Console.WriteLine(myMessages[36]);
                            myItems[3].State++;
                        }
                        else if (!player.HasItem(1))
                        {
                            Console.WriteLine(myMessages[31]);
                        }
                        else if (myToken2 != 1055 || myToken2 != 1003)
                        {
                            Console.WriteLine(myMessages[33]);
                        }
                    }
                    else if (myToken == 2006)   // close or lock
                    {
                        if (player.HasItem(1) && myItems[3].State == 1 && player.CurrentRoom.HasItem(3))
                        {
                            Console.WriteLine(myMessages[35]);
                            myItems[3].State--;
                        }
                        else if (myToken2 != 1055 || myToken2 != 1003)
                        {
                            Console.WriteLine(myMessages[33]);
                        }

                    }
                    else if (myToken == 2007)   //light
                    {
                        if (myToken2 == 1002)   // the lamp
                        {
                            if (player.HasItem(2) || player.CurrentRoom.HasItem(2))
                            {
                                myItems[2].State = 1;
                                Console.WriteLine(myMessages[39]);
                            }
                        }
                    }
                    else if (myToken == 2008)   // extinguish
                    {
                        if (myToken2 == 1002)   // the lamp
                        {
                            if (player.HasItem(2) || player.CurrentRoom.HasItem(2))
                            {
                                myItems[2].State = 0;
                                Console.WriteLine(myMessages[40]);
                                if (!player.CurrentRoom.Flags.HasFlag(RoomFlags.light))
                                {
                                    Console.WriteLine(myMessages[16]);
                                }
                            }
                        }
                    }
                    else if (myToken == 2009)     // wave or shake
                    {
                        if (myToken2 == 1005 || myToken2 == 1006)       // can only wave rod in specific room
                        {
                            if (player.HasItem(5) || player.CurrentRoom.HasItem(5))
                            {
                                Console.WriteLine(myMessages[12]);
                            }
                        }
                    }
                    /*else if (myToken == 2011)   //walk
                    {
                        
                    }*/
                    else if (myToken == 2014)  //Eat
                    {
                        if (myToken2 == 1019) 
                        {
                            if (player.HasItem(19))
                            {
                                Console.WriteLine(myMessages[72]);
                                player.RemoveItem(19);
                            }
                            else if (!player.HasItem(19))
                            {
                                Console.WriteLine("YOU HAVE NOTHING TO EAT!!");
                            }
                        }
                        else if (myToken2 != 1019)
                        {
                            Console.WriteLine(myMessages[25]);
                        }
                    }
                    else if( myToken == 2015) //Drink
                    {
                        if (myToken2 == 1020 || myToken2 == 1021)   //bottle or water
                        {
                            if (player.HasItem(20) && myItems[20].State == 0)
                            {
                                Console.WriteLine(myMessages[74]);
                                myItems[20].State++;
                            }
                            else if (player.HasItem(20) && myItems[20].State == 1)
                            {
                                Console.WriteLine("THERE IS NOTHING IN THE BOTTLE TO DRINK!!!");
                            }
                            else if (player.CurrentRoom.Flags.HasFlag(RoomFlags.liquid))
                            {
                                Console.WriteLine(myMessages[73]);
                            }
                            else
                            {
                                Console.WriteLine(myMessages[110]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("ARE YOU SURE YOU WANT TO DRINK {0}", cmdlist[1].ToUpper());
                            string drink = Console.ReadLine();
                            if (drink.ToUpper() == "YES" || drink.ToUpper() == "Y")
                            {
                                Console.WriteLine(myMessages[81]);
                                drink = Console.ReadLine();
                                if (drink.ToUpper() == "YES" || drink.ToUpper() == "Y")
                                {
                                    Console.WriteLine(myMessages[82]);
                                }
                            }
                        }
                    }
                    else if (myToken == 2018) //quit
                    {
                        Console.WriteLine(myMessages[143]);
                        string ending = Console.ReadLine();

                        if (ending.ToUpper() == "YES" || ending.ToUpper() == "Y")
                        {
                            Console.WriteLine("\nADVENTURING IS OBVIOUSLY NOT FOR YOU!\n");
                            break;
                        }
                        else if (ending.ToUpper() == "NO" || ending.ToUpper() == "N")
                        {
                            Console.WriteLine("\n");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(myMessages[12]);
                            Console.WriteLine("\n");
                        }
                    }
                    else if (myToken == 2020)    // inventory
                    {
                        foreach (AdventureItem i in player.MyItems)
                        {
                            Console.WriteLine(i.ShortDescription);
                        }
                        Console.WriteLine('\n');
                    }
                    else if (myToken == 2022)   // fill
                    {
                        if (myToken2 == 1020 || myToken2 == 1021)   //bottle or water
                        {
                            if (player.HasItem(20) && myItems[20].State == 1 && player.CurrentRoom.Flags.HasFlag(RoomFlags.liquid))
                            {
                                Console.WriteLine(myMessages[107]);
                                myItems[20].State = 0;
                            }
                            else if (player.HasItem(20) && myItems[20].State == 1 && player.CurrentRoom.Flags.HasFlag(RoomFlags.OilWater))
                            {
                                Console.WriteLine(myMessages[108]);
                                myItems[20].State = 0;
                            }
                            else if (player.HasItem(20) && myItems[20].State == 0)
                            {
                                Console.WriteLine(myMessages[105]);
                            }
                            else
                            {
                                Console.WriteLine(myMessages[109]);
                            }
                        }
                    }
                }
                else if (myToken < 1000)
                {
                    foreach (AdventureExit e in player.CurrentRoom.Exits)
                    {
                        if (e.Vocab.Contains(myToken))
                        {
                            if (e.Conditional == 0 || e.Conditional == 100)
                                player.CurrentRoom = myRooms[e.Destination];
                            else if (e.Conditional >= 300)
                            {
                                int itemNumber = e.Conditional % 100;
                                int forbiddenState = (e.Conditional / 100) - 3;
                                if (myItems[itemNumber].State != forbiddenState)
                                    player.CurrentRoom = myRooms[e.ComputedDest];
                            }
                            else
                                throw new NotImplementedException("cant handle conditional movements");

                            break;
                        }
                    }
                }
            }
        }

        static public int Tokenize(string s)
        {
            foreach (AdventureVocab v in myVocab)
            {
                if (string.Compare(v.Word, 0, s.ToUpper(), 0, 5) == 0)
                {
                    return v.Index;
                }
            }
            return -1;
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
            //myRooms.Add(new AdventureRoom());
            //Console.WriteLine(fs.ReadLine());
            while (true)
            {
                // get room descriptions

                tmp = fs.ReadLine();
                string[] q = tmp.Split('\t');
                int roomNumber = int.Parse(q[0]);

                if (roomNumber < 0)
                    break;
                if (!myRooms.ContainsKey(roomNumber))
                    myRooms[roomNumber] = new AdventureRoom();

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
                tmp = fs.ReadLine();    // one exit
                string[] q = tmp.Split('\t');
                int roomNumber = int.Parse(q[0]);
                if (roomNumber < 0)
                    break;
                int destination = int.Parse(q[1]);
                AdventureExit x = new AdventureExit(roomNumber,destination);
                myRooms[x.Source].Exits.Add(x);
                for (int i=2; i < q.Length; i++)
                {
                    x.AddVocab(int.Parse(q[i]));
                }
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
            AdventureItem item = null;
            string tmp;
            int itemNumber;

            fs.ReadLine(); // section 5

            tmp = fs.ReadLine();
            string[] q = tmp.Split('\t');
            itemNumber = int.Parse(q[0]);

            while (itemNumber > 0)
            {
                if (item != null)
                    myItems[item.Index] = item;

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
                    t = descNumber / 100;
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
                    descNumber = int.Parse(q[0]);
                    t = descNumber % 100;
                }

                itemNumber = descNumber;
                // q and itemNumber must contain next data
            }
        }
        static void GetSection6(StreamReader fs)
        {
            string tmp;
            fs.ReadLine();
            while (true)
            {
                tmp = fs.ReadLine();    // one exit
                string[] q = tmp.Split('\t');
                int roomNumber = int.Parse(q[0]);
                if (roomNumber < 0)
                    break;

                if (myMessages.ContainsKey(roomNumber))
                    myMessages[roomNumber] += " " + q[1];
                else
                    myMessages[roomNumber] = q[1];
            }
        }
        static void GetSection7(StreamReader fs)
        {
            string tmp;     // section 7
            fs.ReadLine();
            while (true)
            {
                tmp = fs.ReadLine();    // one exit

                string[] q = tmp.Split('\t');
                int itemNumber = int.Parse(q[0]);
                if (itemNumber < 0)
                    break;

                if (!myItems.ContainsKey(itemNumber))
                {
                    continue;
                }

                if (q.Length == 2)
                {
                    int room = int.Parse(q[1]);

                    if (room != 0)
                        myRooms[room].AddItem(myItems[itemNumber]);
                }

                else if (q.Length == 3)
                {
                    int room1 = int.Parse(q[1]);
                    int room2 = int.Parse(q[2]);
                    myItems[itemNumber].Immovable = true;

                    if (room1 != 0)
                        myRooms[room1].AddItem(myItems[itemNumber]);

                    if (room2 != -1 && room2 != 0) 
                    {
                        myRooms[room2].AddItem(myItems[itemNumber]);
                    }
                   
                }
                

            }
        }
        static void GetSection9(StreamReader fs)

        {
            fs.ReadLine(); //Section 9
            string tmp;

            tmp = fs.ReadLine(); //one item

            string[] q = tmp.Split('\t');
            int bitNumber = int.Parse(q[0]);

            while (bitNumber >= 0)
            {
                for (int i = 1; i < q.Length; i++)
                {
                    int t = int.Parse(q[i]);
                    myRooms[t].Flags |= (RoomFlags)(1 << bitNumber);
                }
                tmp = fs.ReadLine();
                q = tmp.Split('\t');
                bitNumber = int.Parse(q[0]);
            }
        }
        static void SkipSection(StreamReader fs)
        {
            fs.ReadLine();
            string tmp;
            while(true)
            {
                tmp = fs.ReadLine();

                string[] q = tmp.Split('\t');
                int itemNumber = int.Parse(q[0]);
                if (itemNumber < 0)
                    break;
                //skip
            }
        }

        static void getData(string filename)
        {
            using (StreamReader fs = new StreamReader(filename))
            {
                GetSection1(fs);
                GetSection2(fs);
                GetSection3(fs);
                GetSection4(fs);
                GetSection5(fs);
                GetSection6(fs);
                GetSection7(fs);
                SkipSection(fs);
                GetSection9(fs);

                Console.WriteLine(fs.ReadLine());
            }
        }
    }
}