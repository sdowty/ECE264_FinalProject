using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FinalProject
{
    public class AdventureVocab
    {
        public AdventureVocab(): this(0,"")
        { }

        public AdventureVocab(int idx, string vocab)
        {
            Index = idx;
            Word = vocab;
        }

        public int Index { get; set; }
        public string Word { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Index, Word);
        }
    }
}