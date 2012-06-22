//Title: Shiva no To
//Authors: Eric Hill and Charles Guyer

//This class holds all the static data that will be used throughout the game. Data such as lblMap levels,
//flavor text, and position on the lblMap will all be held here. This allows the program to be easily saved.
//Upon saving only this class needs to be serialized because it tells the rest of the program what is
//happening and what happened last. In the future, I will be implementing a way to save level designs
//outside of the immediate program. This will save on time taken to save and load, as well as make creating
//new levels and altering old levels much easier.

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

using ShivasTower.Model;
using ShivasTower.Model.Map;
using ShivasTower.Model.Objects;

using EDirection = ShivasTower.Model.Enums.EDirection;
using ESpecial = ShivasTower.Model.Enums.ESpecial;

namespace ShivasTower.Control
{
    [Serializable]
    class GetData
    {
        public Character Character
        {
            get;
            set;
        }

        public List<Floor> Tower
        {
            get;
            set;
        }

        public int NumOfFloors
        {
            get
            {
                return Tower.Capacity;
            }
        }

        public Location CurrentLocation
        {
            get
            {
                return CurrentFloor.CurrentRoom.Location;
            }
        }

        public Location TemporaryLocation
        {
            get
            {
                return CurrentFloor.TemporaryRoom.Location;
            }
        }

        private Floor objCurrentFloor;
        public Floor CurrentFloor
        {
            get
            {
                return objCurrentFloor;
            }
            set
            {
                Tower.Add(value);
                objCurrentFloor = value;
            }
        }

        public Room CurrentRoom
        {
            get
            {
                return CurrentFloor.CurrentRoom;
            }
        }

        //determines if the Room being moved to is a legitimate choice
        public bool CanMove(EDirection eDirection)
        {
            Location objTemporaryLocation = CurrentLocation.DeepClone<Location>(CurrentLocation);

            switch (eDirection)
            {
                case EDirection.North:
                    {
                        objTemporaryLocation.y++;            //North
                        break;
                    }
                case EDirection.East:
                    {
                        objTemporaryLocation.x++;            //East
                        break;
                    }
                case EDirection.West:
                    {
                        objTemporaryLocation.x--;            //West
                        break;
                    }
                case EDirection.South:
                    {
                        objTemporaryLocation.y--;            //South
                        break;
                    }
            }

            CurrentFloor.SetTemporaryRoom(objTemporaryLocation);

            if (CurrentFloor.TemporaryRoom != null && CurrentFloor.TemporaryRoom.Passable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveCharacter()
        {
            CurrentFloor.CommitCharacterMove();
        }

        public bool IsLevelOver()
        {
            if (CurrentFloor.CurrentRoom.Special == ESpecial.Stairwell)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsGameOver()
        {
            return CurrentFloor.ID == NumOfFloors;
        }

        public string ViewCharacter()
        {
            //Here we show a simple output of the user's choices. This is
            //a good way to show the user their beginning stats; since we
            //will not be showing them interactively. Due to the nature of
            //a console application.
            return
            "Name:   " + Character.Name + "\n" +
            "Age:    " + Character.Age + "\n" +
            "Gender: " + Character.Gender + "\n" +
            "\n" +
            "Strength:  " + Character.Strength + "\n" +
            "Dexterity: " + Character.Dexterity + "\n" +
            "Wisdom:    " + Character.Wisdom + "\n" +
            "Luck:      " + Character.Luck + "\n" +
            "Endurance: " + Character.Endurance;
        }

        public void CreateCharacter()
        {
            Character = new Character();
        }

        public void CreateCharacter(string name, int age, bool gender)
        {
            Character = new Character(name, age, gender);
        }

        public Room GetRoomByLocation(int x, int y)
        {
            return CurrentFloor.GetRoomByLocation(new Location(x, y));
        }

        public ESpecial GetSpecialByLocation(int x, int y)
        {
            Room objRoom = CurrentFloor.GetRoomByLocation(new Location(x, y));

            if (objRoom != null)
            {
                return objRoom.Special;
            }

            else
            {
                return ESpecial.None;
            }
        }
    }
}