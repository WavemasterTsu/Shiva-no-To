using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ShivasTower.Model.Objects;

using ESpecial = ShivasTower.Model.Enums.ESpecial;

namespace ShivasTower.Model.Map
{
    class Floor
    {
        private Room[] Map;

        public int ID
        {
            get;
            private set;
        }

        public Room CurrentRoom
        {
            get;
            private set;
        }

        public Room TemporaryRoom
        {
            get;
            private set;
        }

        //Constructor
        public Floor(int intFloorID, Room[] objMap, Location objInitLocation)
        {
            ID = intFloorID;
            Map = objMap;
            SetCurrentRoom(objInitLocation);

            LinkRooms();
        }

        public void SetCurrentRoom(Location objNewLocation)
        {
            CurrentRoom = GetRoomByLocation(objNewLocation);
        }

        public void SetTemporaryRoom(Location objNewLocation)
        {
            TemporaryRoom = GetRoomByLocation(objNewLocation);
        }

        public void CommitCharacterMove()
        {
            CurrentRoom = TemporaryRoom;
        }

        public void ChangeRoomPassableStatusByLocation(bool blnPassable, Location objLocation)
        {
            GetRoomByLocation(objLocation).Passable = blnPassable;
        }

        public Room GetRoomByLocation(Location objLocation)
        {
            return Map.FirstOrDefault(room => room.Location.CompareTo(objLocation) == 0);
        }

        public void LinkRooms()
        {
            foreach (Room objRoom in Map)
            {
                switch (objRoom.Special)
                {
                    case ESpecial.Lever:
                        {
                            Lever objLever = ((RoomLever)objRoom).Lever;
                            objLever.Target = GetRoomByLocation(objLever.TargetLocation);
                            break;
                        }
                }
            }
        }
    }
}