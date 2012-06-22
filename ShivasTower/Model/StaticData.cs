using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShivasTower.Model
{
    public class Enums
    {
        public enum ESpecial
        {
            None,
            Stairwell,
            Lever,
            Item,
            Fight
        }

        public enum EXMLReaderState
        {
            Open,
            Close,
            ParseFloor
        }

        public enum EDirection
        {
            North,
            East,
            West,
            South
        }
    }

    public class Statics
    {
        public static Enums.ESpecial GetSpecialFromString(string strSpecial)
        {
            switch (strSpecial)
            {
                case "none":
                    return Enums.ESpecial.None;
                case "stairwell":
                    return Enums.ESpecial.Stairwell;
                case "lever":
                    return Enums.ESpecial.Lever;
                case "item":
                    return Enums.ESpecial.Item;
                case "fight":
                    return Enums.ESpecial.Fight;
                default:
                    return Enums.ESpecial.None;
            }
        }
    }

    public class Consts
    {
        public const string IntroText =
@"    ______   __        _                                    _________        
  .' ____ \ [  |      (_)                                  |  _   _  |
  | (___ \_| | |--.   __  _   __  ,--.     _ .--.   .--.   |_/ | | \_|.--.   
   _.____`.  | .-. | [  |[ \ [  ]`'_\ :   [ `.-. |/ .'`\ \     | |  / .'`\ \ 
  | \____) | | | | |  | | \ \/ / // | |,   | | | || \__. |    _| |_ | \__. | 
   \______.'[___]|__][___] \__/  \'-;__/  [___||__]'.__.'    |_____| '.__.'  

Welcome to this fantastic tower. Beware of false walls, deadly traps, and
ferocious monsters. When you reach the top of the tower, maybe you will
finally have reached godlihood. Go forth my boy Shiva and realize your great
destiny.";

        public const int InitialFloor = 1;
        public static int NumOfFloors { get; set; }

        public static List<string> AcceptedImageExts = new List<string>
        {
            "bmp",
            "jpg",
            "png",
            "gif"
        };
    }
}