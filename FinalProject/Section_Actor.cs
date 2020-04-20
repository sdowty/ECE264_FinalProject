using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class AdventureActor : AdventureContainer
    {
        private List<AdventureRoom> History;
        public AdventureRoom CurrentRoom
        {
            get { return History[0]; }
            set
            {
                History[2] = History[1];
                History[1] = History[0];
                History[0] = value;
            }
        }
        public AdventureRoom OldLocation { get { return History[1]; } }
        public AdventureRoom ReallyOldLocation { get { return History[2]; } }

        public AdventureActor()
        {
            History = new List<AdventureRoom>(3)
            {
                null,
                null,
                null,
            };
        }
    }
}
