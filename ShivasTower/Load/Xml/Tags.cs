using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShivasTower.Load.Xml
{
    class AttributeTags
    {
        public const string FloorNumber = "number";
        public const string xCoordinate = "x_coord";
        public const string yCoordinate = "y_coord";
        public const string Type = "type";
    }

    class ElementTags
    {
        public const string NumberOfFloors = "num_of_floors";
        public const string NumberOfRooms = "num_of_rooms";
        public const string InitialLocation = "init_location";
        public const string Floor = "floor";
        public const string Room = "room";
        public const string Passable = "passable";
        public const string MovementText = "movement_text";
        public const string ExamineText = "examine_text";
        public const string ActionText = "action_text";
        public const string NewMovementText = "new_movement_text";
        public const string NewExamineText = "new_examine_text";
        public const string NewActionText = "new_action_text";
        public const string Special = "special";
        public const string ItemIndex = "index";
        public const string ItemName = "name";
        public const string ItemDescription = "description";
        public const string Outcome = "outcome";
        public const string OutcomeSuccess = "outcome_success";
        public const string OutcomeFail = "outcome_fail";
    }
}
