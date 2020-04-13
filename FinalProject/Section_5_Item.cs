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
        }
        public int Index { get; set; }
        public string ShortDescription { get; set; }
        public List<string> StateDescriptions { get; set; }
        public int State { get; set; }


    }
}
