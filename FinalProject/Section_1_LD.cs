using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    public class AdventureRoom
    {
        private string _Description;

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


    }
}