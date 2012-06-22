using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShivasTower.Model.Objects
{
    class Item
    {
        private int myIndex = -1;
        private string myName = "";
        private string myDesc = "";

        public Item(int index, string name, string desc)
        {
            myIndex = index;
            myName = name;
            myDesc = desc;
        }

        public int index
        {
            get
            {
                return myIndex;
            }
        }

        public string name
        {
            get
            {
                return myName;
            }
        }

        public string description
        {
            get
            {
                return myDesc;
            }
        }
    }
}