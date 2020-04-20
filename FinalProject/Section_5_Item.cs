using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FinalProject
{
    public class AdventureItem
    {
        public AdventureItem()
        {
            StateDescriptions = new List<string>();
            ShortDescription = "";
            State = 0;
        }

        public int Index { get; set; }
        public string ShortDescription { get; set; }
        public List<string> StateDescriptions { get; set; }
        public int State { get; set; }
        public bool Immovable;

        public string DebugString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Index:{0}\n", Index));
            sb.Append(string.Format("SD:{0}\n", ShortDescription));
            sb.Append(string.Format("State:{0}\n", State));
            foreach(string s in StateDescriptions)
            {
                sb.Append(string.Format("{0}\n", s));
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return StateDescriptions[State];
        }
        }
}
