using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ShivasTower.Model.Map;

namespace ShivasTower.Model.Objects
{
    class Lever
    {
        public Location TargetLocation
        {
            get;
            private set;
        }

        private Room objTarget;
        public Room Target
        {
            get
            {
                return objTarget;
            }
            set
            {
                objTarget = value;
                objTarget.NumOfLocks++;
            }
        }

        public bool IsActive
        {
            get;
            private set;
        }

        public Lever(Location objLocation)
        {
            TargetLocation = objLocation;
            IsActive = false;
        }

        public void FlipLever()
        {
            IsActive = !IsActive;

            Target.NumOfLocks += IsActive ? -1 : 1;
        }
    }
}
