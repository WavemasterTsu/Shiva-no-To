using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using ShivasTower.Model;
using ShivasTower.Model.Map;
using ShivasTower.Model.Objects;

using ESpecial = ShivasTower.Model.Enums.ESpecial;

namespace ShivasTower.Load.Xml
{
    class XmlParser
    {
        private string strPath;
        private XmlTextReader objTextReader;

        public ReadState ReaderState
        {
            get
            {
                return objTextReader.ReadState;
            }
        }

        public XmlParser(string strPath)
        {
            this.strPath = strPath;
        }

        public List<Floor> ParseTowerXML()
        {
            if (objTextReader.ReadToFollowing(ElementTags.NumberOfFloors))
            {
                int intNumOfFloors = objTextReader.ReadElementContentAsInt();

                if (intNumOfFloors > 0)
                {
                    return new List<Floor>(intNumOfFloors);
                }
                else
                {
                    throw new Exception("The tower must have at least one floor.");
                }
            }
            else
            {
                XMLTagNotFoundException(ElementTags.NumberOfFloors);
                return null;
            }
        }

        public Floor ParseNextFloorXML()
        {
            return ParseFloorXML(null);
        }

        public Floor ParseFloorXML(int? intCurrentFloorID)
        {
            int intCurrentFloorIDFromXML;
            bool blnCurrentFloorFound = false;

            if (intCurrentFloorID == null)
            {
                if (objTextReader.ReadToFollowing(ElementTags.Floor))
                {
                    intCurrentFloorID = Int16.Parse(objTextReader.GetAttribute(AttributeTags.FloorNumber));
                    blnCurrentFloorFound = true;
                }
                else
                {
                    XMLTagNotFoundException(ElementTags.Floor);
                }
            }
            else
            {
                while (objTextReader.ReadToFollowing(ElementTags.Floor))
                {
                    intCurrentFloorIDFromXML = Int16.Parse(objTextReader.GetAttribute(AttributeTags.FloorNumber));

                    if (intCurrentFloorID == intCurrentFloorIDFromXML)
                    {
                        blnCurrentFloorFound = true;
                    }
                } 
            }

            if (blnCurrentFloorFound)
            {                
                objTextReader.ReadToFollowing(ElementTags.NumberOfRooms);
                int intNumOfRooms = objTextReader.ReadElementContentAsInt();

                Room[] objMap = new Room[intNumOfRooms];

                int intInitCoordX = -1;
                int intInitCoordY = -1;

                if (objTextReader.ReadToFollowing(ElementTags.InitialLocation))
                {
                    intInitCoordX = Int16.Parse(objTextReader.GetAttribute(AttributeTags.xCoordinate));
                    intInitCoordY = Int16.Parse(objTextReader.GetAttribute(AttributeTags.yCoordinate));
                }
                else
                {
                    XMLTagNotFoundException(ElementTags.InitialLocation);
                }

                Location objInitLocation = new Location(intInitCoordX, intInitCoordY);

                for (int i = 0; i < intNumOfRooms; i++)
                {
                    objTextReader.ReadToFollowing(ElementTags.Room);
                    objMap[i] = ParseRoomXML();
                }

                return new Floor(intCurrentFloorID.Value, objMap, objInitLocation);
            }
            else
            {
                throw new Exception(string.Format("{0} - could not be found.", 
                    intCurrentFloorID != null ? "Floor " + intCurrentFloorID.ToString() : "Next floor"));
            }
        }

        private Room ParseRoomXML()
        {
            bool blnRoomComplete = false;

            int intLocationXCoord = Int16.Parse(objTextReader.GetAttribute(AttributeTags.xCoordinate));
            int intLocationYCoord = Int16.Parse(objTextReader.GetAttribute(AttributeTags.yCoordinate));

            bool blnPassable = true;

            string strMovementText = null;
            string strExamineText = null;
            string strActionText = null;

            string strNewMovementText = null;
            string strNewExamineText = null;
            string strNewActionText = null;

            ESpecial eSpecial = ESpecial.None;
            object objSpecial = null;

            if (objTextReader.IsEmptyElement)
            {
                blnRoomComplete = true;
            }

            while (!blnRoomComplete && objTextReader.Read())
            {
                if (objTextReader.IsStartElement())
                {
                    switch (objTextReader.LocalName)
                    {
                        case ElementTags.Room:
                            {
                                break;
                            }
                        case ElementTags.Passable:
                            {
                                blnPassable = objTextReader.ReadElementContentAsBoolean();
                                break;
                            }
                        case ElementTags.MovementText:
                            {
                                strMovementText = objTextReader.ReadElementContentAsString();
                                break;
                            }
                        case ElementTags.ExamineText:
                            {
                                strExamineText = objTextReader.ReadElementContentAsString();
                                break;
                            }
                        case ElementTags.ActionText:
                            {
                                strActionText = objTextReader.ReadElementContentAsString();
                                break;
                            }
                        case ElementTags.NewMovementText:
                            {
                                strNewMovementText = objTextReader.ReadElementContentAsString();
                                break;
                            }
                        case ElementTags.NewExamineText:
                            {
                                strNewExamineText = objTextReader.ReadElementContentAsString();
                                break;
                            }
                        case ElementTags.NewActionText:
                            {
                                strNewActionText = objTextReader.ReadElementContentAsString();
                                break;
                            }
                        case ElementTags.Special:
                            {
                                string strSpecial = objTextReader.GetAttribute(AttributeTags.Type);
                                eSpecial = GetEnumByString<ESpecial>(strSpecial);

                                switch (eSpecial)
                                {
                                    case ESpecial.Lever:
                                        {
                                            int intLeverCoordX = Int16.Parse(objTextReader.GetAttribute(AttributeTags.xCoordinate));
                                            int intLeverCoordY = Int16.Parse(objTextReader.GetAttribute(AttributeTags.yCoordinate));
                                            Location objTarget = new Location(intLeverCoordX, intLeverCoordY);

                                            objSpecial = new Lever(objTarget);
                                            break;
                                        }
                                    case ESpecial.Item:
                                        {
                                            objTextReader.ReadToFollowing(ElementTags.ItemIndex);
                                            int intItemIndex = objTextReader.ReadElementContentAsInt();

                                            objTextReader.ReadToFollowing(ElementTags.ItemName);
                                            string strItemName = objTextReader.ReadElementContentAsString();

                                            objTextReader.ReadToFollowing(ElementTags.ItemDescription);
                                            string strItemDesc = objTextReader.ReadElementContentAsString();

                                            objSpecial = new Item(intItemIndex, strItemName, strItemDesc);
                                            break;
                                        }
                                    case ESpecial.Fight:
                                        {
                                            objTextReader.ReadToFollowing(ElementTags.Outcome);
                                            string strOutcome = objTextReader.ReadElementContentAsString();

                                            objTextReader.ReadToFollowing(ElementTags.OutcomeSuccess);
                                            string strOutcomeSuccess = objTextReader.ReadElementContentAsString();

                                            objTextReader.ReadToFollowing(ElementTags.OutcomeFail);
                                            string strOutcomeFail = objTextReader.ReadElementContentAsString();

                                            objSpecial = new Fight(strOutcome, strOutcomeSuccess, strOutcomeFail);
                                            break;
                                        }
                                }
                            }
                            break;
                    }
                }
                else
                {
                    if (objTextReader.LocalName == ElementTags.Room)
                    {
                        blnRoomComplete = true;
                    }
                }
            }

            Location objLocation = null;
            if (intLocationXCoord > -1 && intLocationYCoord > -1)
            {
                objLocation  = new Location(intLocationXCoord, intLocationYCoord);
            }
            else
            {
                throw new Exception("Room location x and y coordinates must be positive.");
            }

            switch(eSpecial)
            {
                case ESpecial.None:
                case ESpecial.Stairwell:
                {
                    return new Room
                    {
                        Location = objLocation,
                        Passable = blnPassable,
                        MovementText = strMovementText,
                        NewMovementText = strNewMovementText,
                        ExamineText = strExamineText,
                        NewExamineText = strNewExamineText,
                        ActionText = strActionText,
                        NewActionText = strNewActionText,
                        Special = eSpecial
                    };
                }
                case ESpecial.Lever:
                {
                    return new RoomLever
                    {
                        Location = objLocation,
                        Passable = blnPassable,
                        MovementText = strMovementText,
                        NewMovementText = strNewMovementText,
                        ExamineText = strExamineText,
                        NewExamineText = strNewExamineText,
                        ActionText = strActionText,
                        NewActionText = strNewActionText,
                        Lever = objSpecial as Lever,
                        Special = eSpecial
                    };
                }
                case ESpecial.Item:
                {
                    return new RoomItem
                    {
                        Location = objLocation,
                        Passable = blnPassable,
                        MovementText = strMovementText,
                        NewMovementText = strNewMovementText,
                        ExamineText = strExamineText,
                        NewExamineText = strNewExamineText,
                        ActionText = strActionText,
                        NewActionText = strNewActionText,
                        Item = objSpecial as Item,
                        Special = eSpecial
                    };
                }
                case ESpecial.Fight:
                {
                    return new RoomFight
                    {
                        Location = objLocation,
                        Passable = blnPassable,
                        MovementText = strMovementText,
                        NewMovementText = strNewMovementText,
                        ExamineText = strExamineText,
                        NewExamineText = strNewExamineText,
                        ActionText = strActionText,
                        NewActionText = strNewActionText,
                        Fight = objSpecial as Fight,
                        Special = eSpecial
                    };
                }
                default:
                    return null;
            }
        }

        public void Open()
        {
            objTextReader = new XmlTextReader(strPath);
            objTextReader.MoveToContent();
        }

        public void Close()
        {
            //closes the xml text reader
            objTextReader.Close();
        }

        public void Reset()
        {
            if (objTextReader != null && objTextReader.ReadState < ReadState.Error)
            {
                Close();
            }
            
            Open();
        }

        private void XMLTagNotFoundException(string strTag)
        {
            throw new Exception(string.Format("XML tag {0} not found", strTag));
        }

        public T GetEnumByString<T>(string strEnum)
            where T : struct
        {
            if(typeof(T).BaseType == typeof(Enum))
            {
                T result;

                if(Enum.TryParse<T>(strEnum, out result))
                {
                    return result;
                }
                else
                {
                    throw new Exception(string.Format("Unable to parse {0} from type of {1}.", strEnum, typeof(T)));
                }
            }
            else
            {
                throw new Exception(string.Format("Type {0} is not an enumeration.", typeof(T)));
            }
        }
    }
}