using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    public class AdventureContainer
    {
        public List<AdventureItem> MyItems { get; set; }

        public AdventureContainer()
        {
            MyItems = new List<AdventureItem>();
        }

        public void AddItem(AdventureItem i)
        {
            MyItems.Add(i);
        }

        public bool RemoveItem (int id)
        {
            foreach (AdventureItem x in MyItems)
            {
                if (x.Index == id) { return MyItems.Remove(x); }
            }
            return false;
        }

        bool HasItem (int id)
        {
            foreach (AdventureItem x in MyItems)
            {
                if (x.Index == id) { return true; }
            }
            return false;
        }
    }
}
