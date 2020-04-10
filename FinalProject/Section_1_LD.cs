using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FinalProject
{
    public class AdventureRoom
    {
        private string _Description;
        private string _ShortDescription;

        public AdventureRoom(string d)
        {
            Description = d;
        }

        public AdventureRoom() : this("")
        { }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string ShortDescription
        {
            get;
            set;
        }

        public int GetDescription(StreamReader sr)
        {
            string tmp = sr.ReadLine();
            string[] q = tmp.Split('\t');
            int roomNumber = int.Parse(q[0]);

            if(roomNumber < 0)
                return roomNumber;

            if (Description.Length == 0)
                Description = q[1];
            else
                Description += " " + q[1];

            return roomNumber;
        }

        public void Print()
        {
            Console.WriteLine("Short: {0}", ShortDescription);
            Console.WriteLine("Long: {0}", Description);
        }

    }
}