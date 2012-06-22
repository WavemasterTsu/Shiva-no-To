using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ShivasTower.Model.Objects;

using ESpecial = ShivasTower.Model.Enums.ESpecial;

namespace ShivasTower.Model.Map
{
    [Serializable]
    class RoomItem : Room
    {
        protected override string DefaultMovementText
        {
            get
            {
                return "There is a weapon in this room.";
            }
        }

        protected override string NewDefaultMovementText
        {
            get
            {
                return "The room is now empty.";
            }
        }

        protected override string DefaultExamineText
        {
            get
            {
                return "Use the action button to take the weapon.";
            }
        }

        protected override string NewDefaultExamineText
        {
            get
            {
                return "No weapon in this room.";
            }
        }

        protected override string DefaultActionText
        {
            get
            {
                return "You add the weapon to your arsenal.";
            }
        }

        protected override string NewDefaultActionText
        {
            get
            {
                return "You have already taken the weapon in this room.";
            }
        }

        private Item objItem;
        public Item Item
        {
            get
            {
                return objItem;
            }
            set
            {
                objItem = value;
                blnHasItem = true;
            }
        }

        private bool blnHasItem;
        protected override bool UseNewText
        {
            get
            {
                return !blnHasItem;
            }
        }

        public override void PerformAction()
        {
            blnHasItem = false;
        }
    }
}