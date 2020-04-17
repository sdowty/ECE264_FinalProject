using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FinalProject
{
    public class AdventureRoom :AdventureContainer

    {
        private string _Description;

        public AdventureRoom(string d) :base()
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\n\n", Description);

            foreach (AdventureItem i in this.MyItems)
            {
                sb.AppendFormat("{0}\n", i);
            }

            return sb.ToString();
        }

        public void Print()
        {
            Console.WriteLine("Short: {0}", ShortDescription);
            Console.WriteLine("Long: {0}", Description);
            Console.WriteLine("Exits:");
            foreach(AdventureExit e in this.Exits)
            {
                Console.WriteLine(e);
            }
            foreach (AdventureItem e in this.MyItems)
            {
                Console.WriteLine(e);
            }
        }


    }
}