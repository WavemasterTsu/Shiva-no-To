//Title: Shiva
//Authors: Eric Hill

//The user will select a name, an age, and a gender.
//After entering all the information, the game will begin.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShivasTower.Model.Objects
{
    [Serializable]
    class Character
    {
        //Character Information
        private string strName = null;
        private int intAge = -1;
        private bool blnGender = true;                   //true == male; false == female;

        //Character Stats
        private int intStrength = 5;
        private int intDexterity = 5;
        private int intWisdom = 5;
        private int intLuck = 5;
        private int intEndurance = 5;

        [NonSerialized]
        Image imgIcon = null;

        private string strImagePath;

        public Character()
        {
            strName = "Eric";
            intAge = 21;
            blnGender = true;
        }

        public Character(string strName, int intAge, bool blnGender)
        {
            this.strName = strName;
            this.intAge = intAge;
            this.blnGender = blnGender;
        }

        public string Name
        {
            get
            {
                return strName;
            }
        }

        public int Age
        {
            get
            {
                return intAge;
            }
            set
            {
                if (intAge != value)
                {
                    intAge = value;
                }
            }
        }

        public string Gender
        {
            get
            {
                if (blnGender == true)
                {
                    return "Male";
                }
                else if (blnGender == false)
                {
                    return "Female";
                }
                else
                {
                    return "Other";
                }
            }
        }

        public int Strength
        {
            get
            {
                return intStrength;
            }
        }

        public int Dexterity
        {
            get
            {
                return intDexterity;
            }
        }

        public int Wisdom
        {
            get
            {
                return intWisdom;
            }
        }

        public int Luck
        {
            get
            {
                return intLuck;
            }
        }

        public int Endurance
        {
            get
            {
                return intEndurance;
            }
        }

        public string ImagePath
        {
            set
            {
                strImagePath = value;
                imgIcon = Bitmap.FromFile(strImagePath);
            }
        }

        public Image Icon
        {
            get
            {
                if (imgIcon == null)
                {
                    imgIcon = Bitmap.FromFile(strImagePath);
                }

                return imgIcon;
            }
        }

        public void UpdateStats(int strength, int dexterity, int wisdom, int luck, int endurance)
        {
            intStrength += strength;
            intDexterity += dexterity;
            intWisdom += wisdom;
            intLuck += luck;
            intEndurance += endurance;
        }
    }
}