using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ShivasTower.Model.Objects;

namespace ShivasTower.Model.Map
{
    class RoomLever : Room
    {
        protected override string DefaultMovementText
        {
            get
            {
                return "Use the action command to pull the lever.";
            }
        }

        protected override string DefaultExamineText
        {
            get
            {
                return "The lever is in the off position.";
            }
        }

        protected override string NewDefaultExamineText
        {
            get
            {
                return "The lever is in the on position.";
            }
        }

        protected override string DefaultActionText
        {
            get
            {
                return "You pull on the lever.";
            }
        }

        public Lever Lever;

        protected override bool UseNewText
        {
            get
            {
                return Lever.IsActive;
            }
        }

        public override void PerformAction()
        {
            Lever.FlipLever();
        }
    }
}