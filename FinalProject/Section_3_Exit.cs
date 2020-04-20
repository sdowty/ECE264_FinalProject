using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    public class AdventureExit
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public List<int> Vocab { get; set; }

        public int Conditional { get { return Destination / 1000; } }
        public int ComputedDest { get { return Destination % 1000; } }

        public AdventureExit(int Source, int Dest)
        {
            this.Source = Source;
            Destination = Dest;
            Vocab = new List<int>();

        }
        public void AddVocab(int v)
        {
            Vocab.Add(v);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Dest:{0}\n", this.Destination);
            foreach (int i in this.Vocab)
                sb.AppendFormat("{0}, ", i);
            return sb.ToString();
        }
    }
}
