using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FinalProject
{
    public class AdventureRoom
    {
        private string _Description;

        public AdventureRoom(string d)
        {
            Description = d;
            Exits = new List<AdventureExit>();
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

        public List<AdventureExit> Exits { get; set; }

        public void Print()
        {
            Console.WriteLine("Short: {0}", ShortDescription);
            Console.WriteLine("Long: {0}", Description);
            Console.WriteLine("Exits:");
            foreach(AdventureExit e in this.Exits)
            {
                Console.WriteLine(e);
            }
        }

    }
}