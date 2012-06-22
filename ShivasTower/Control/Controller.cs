using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

using ShivasTower.Load.Xml;
using ShivasTower.Model.Map;
using ShivasTower.Model.Objects;

using EDirection = ShivasTower.Model.Enums.EDirection;
using ESpecial = ShivasTower.Model.Enums.ESpecial;

namespace ShivasTower.Control
{
    class Controller
    {
        /// <summary>
        /// general constants
        /// </summary>
        const string strSaveFile = "Shiva.stf";
        const string strDataFile = "Data.xml";

        /// <summary>
        /// general instance variables
        /// </summary>
        private GetData objGetData = null;
        private XmlParser objXmlParser = null;
        private SoapFormatter objSerializer = null;

        /// <summary>
        /// State names and statechart state variables
        /// </summary>
        private enum UniversalStates
        {
            Exit,
            Help,
            PlayGame,
            PrepareGame,
            NULL
        }

        private enum PrepareGameStates
        {
            Interactive,
            NewGame,
            CreateChar,
            LoadGame,
            NULL
        }

        private enum PlayGameStates
        {
            SetupTower,
            SetupFloor,
            Interactive,
            Move,
            SaveGame,
            Examine,
            Action,
            ViewChar,
            GameOver,
            NULL
        }

        private UniversalStates UniversalState = UniversalStates.NULL;
        private PrepareGameStates PrepareGameState = PrepareGameStates.NULL;
        private PlayGameStates PlayGameState = PlayGameStates.NULL;

        /// <summary>
        /// GUI elements we want to control
        /// </summary>
        ToolStripMenuItem miSave;
        ToolStripMenuItem miPerform;

        Button btnNorth;
        Button btnEast; 
        Button btnWest;
        Button btnSouth;
        Panel pnlButtons;

        Label lblOutput;
        Label[,] lblMap;
        Label[] lblInvent;

        public Controller(ToolStripMenuItem miSave, ToolStripMenuItem miPerform, Label[,] lblMap, Panel pnlButtons, 
            Button btnNorth, Button btnEast, Button btnWest, Button btnSouth, Label lblOutput, Label[] lblInvent)
        {
            this.miSave = miSave;
            this.miPerform = miPerform;
            
            this.btnNorth = btnNorth;
            this.btnEast = btnEast;
            this.btnWest = btnWest;
            this.btnSouth = btnSouth;
            this.pnlButtons = pnlButtons;
            
            this.lblOutput = lblOutput;
            this.lblMap = lblMap;
            this.lblInvent = lblInvent;

            objXmlParser = new XmlParser(strDataFile);
            objSerializer = new SoapFormatter();

            GoPrepareGameState();
        }

        ///////////////////////////// S T A T E S ////////////////////////

        /// <summary>
        /// Each state method has the pattern:
        /// PROLOGUE:
        ///     stateVar = state (repeat as necessary)
        ///     call inner statechart entry (as warranted)
        /// A c t i o n s (as warranted)
        /// EPILOGUE:
        ///     non-event transition call (as warranted)
        /// </summary>

        private void GoPrepareGameState()
        {
            UniversalState = UniversalStates.PrepareGame;

            miSave.Enabled = false;
            miPerform.Enabled = false;
            pnlButtons.Enabled = false;

            GoInitialState();
        }

        private void GoInitialState()
        {
            PrepareGameState = PrepareGameStates.Interactive;
        }

        private void GoNewState()
        {
            PrepareGameState = PrepareGameStates.NewGame;

            objGetData = new GetData();

            GoCreateCharState();

            GoPlayGameState();
        }

        private void GoLoadState()
        {
            PrepareGameState = PrepareGameStates.LoadGame;

            bool blnSuccess = true;
            try
            {
                using (Stream objFileStream = File.OpenRead(strSaveFile))
                {
                    objGetData = (GetData)(objSerializer.Deserialize(objFileStream));
                }
            }
            catch (Exception e)
            {
                blnSuccess = false;
                lblOutput.Text = string.Format("Failed loading file {0}", strSaveFile);                
            }

            if (blnSuccess)
            {
                lblOutput.Text = lblOutput.Text + "Game loaded.";
                GoPlayGameState();
            }
            else
            {
                GoInitialState();
            }
        }

        private void GoCreateCharState()
        {
            PrepareGameState = PrepareGameStates.CreateChar;

            //Character objCharacter = 

            objGetData.CreateCharacter("Eric", 22, true);
        }

        private void GoPlayGameState()
        {
            UniversalState = UniversalStates.PlayGame;

            miSave.Enabled = true;
            miPerform.Enabled = true;
            pnlButtons.Enabled = true;

            DataFileExistsTransition();
        }

        private void GoSetupTowerState()
        {
            PlayGameState = PlayGameStates.SetupTower;

            objXmlParser.Reset();
            objGetData.Tower = objXmlParser.ParseTowerXML();            

            GoSetupFloorState();
        }

        private void GoSetupFloorState()
        {
            PlayGameState = PlayGameStates.SetupFloor;

            //loads the current floor's information
            objGetData.CurrentFloor = objXmlParser.ParseNextFloorXML();

            GoFillMapState();

            lblOutput.Text = objGetData.CurrentRoom.MovementText;

            GoPlayState();
        }

        private void GoFillMapState()
        {
            Room objInitialRoom = objGetData.CurrentRoom;

            for (int col = 0; col < 5; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    lblMap[col, row].Image = null;

                    Room objRoom = objGetData.GetRoomByLocation(col, row);

                    if (objRoom != null && (objRoom.Location == objInitialRoom.Location))
                    {
                        lblMap[col, row].Image = AppResources.sonic;
                    }

                    if (objRoom == null)
                    {
                        lblMap[col, row].BackColor = Color.Black;                           //color inaccessible rooms black
                    }
                    else
                    {
                        Color objColor = Color.Black;

                        switch (objRoom.Special)
                        {
                            case ESpecial.Lever:
                                objColor = Color.LightSalmon;         //color rooms with levers red
                                break;
                            case ESpecial.Fight:
                                objColor = Color.LightSteelBlue;
                                break;
                            case ESpecial.Item:
                                objColor = Color.LightGreen;
                                break;
                            case ESpecial.Stairwell:
                                objColor = Color.LightSkyBlue;        //color stairwells blue
                                break;
                            case ESpecial.None:
                                objColor = Color.White;               //everything else is white
                                break;
                        }

                        lblMap[col, row].BackColor = objColor;
                    }
                }
            }
        }

        private void GoPlayState()
        {
            PlayGameState = PlayGameStates.Interactive;
        }

        private void GoMoveState(EDirection eDirection)
        {
            PlayGameState = PlayGameStates.Move;

            if (objGetData.CanMove(eDirection))
            {
                lblMap[objGetData.CurrentLocation.x, objGetData.CurrentLocation.y].Image = null;

                objGetData.MoveCharacter();
                lblOutput.Text = objGetData.CurrentRoom.MovementText;

                //prints the image on the new Room
                lblMap[objGetData.CurrentLocation.x, objGetData.CurrentLocation.y].Image = AppResources.sonic;

                LevelOverTransition();
            }
            else
            {
                PlayGameState = PlayGameStates.Interactive;
            }
        }

        private void GoExamineState()
        {
            PlayGameState = PlayGameStates.Examine;

            lblOutput.Text = objGetData.CurrentRoom.ExamineText;

            GoPlayState();
        }

        private void GoActionState()
        {
            PlayGameState = PlayGameStates.Action;

            objGetData.CurrentRoom.PerformAction();
            lblOutput.Text = objGetData.CurrentRoom.ActionText;

            GoPlayState();
        }

        private void GoVCState()
        {
            lblOutput.Text = objGetData.ViewCharacter();
        }
        
        private void GoSaveState()
        {
            PlayGameState = PlayGameStates.SaveGame;

            using (Stream objSaveFile = File.Create(strSaveFile))
            {
                objSerializer.Serialize(objSaveFile, objGetData);
            }

            GoPlayState();
        }
        
        private void GoGameOverState()
        {
            PlayGameState = PlayGameStates.GameOver;

            lblOutput.Text = "Game Complete";

            PlayAgainTransition();
        }
        
        private void GoHelpState()
        {
            UniversalState = UniversalStates.Help;

            lblOutput.Text = "Help!";

            GoPlayState();
        }

        private void GoExitState()
        {
            UniversalState = UniversalStates.Exit;

            //Close XML Reader
            objXmlParser.Close();

            Environment.Exit(0);
        }

        /////////////////////// E V E N T S //////////////////////
        /// <summary>
        /// public event transition methods
        /// 
        /// Each event determines the state context and if valid calls
        /// the appropriate state method(s)
        /// 
        /// Illegal state/event combos are ignored
        /// </summary>

        public void miNewGameEvent()
        {
            GoNewState();
        }

        public void miLoadGameEvent()
        {
            GoLoadState();
        }

        public void miSaveGameEvent()
        {
            if (UniversalState == UniversalStates.PlayGame)
            {
                GoSaveState();
            }
        }

        public void miExitGameEvent()
        {
            GoExitState();
        }

        public void miExamineEvent()
        {
            if (UniversalState == UniversalStates.PlayGame && PlayGameState == PlayGameStates.Interactive)
            {
                GoExamineState();
            }
        }

        public void miActionEvent()
        {
            if (UniversalState == UniversalStates.PlayGame && PlayGameState == PlayGameStates.Interactive)
            {
                GoActionState();
            }
        }

        public void miVCEvent()
        {
            if (UniversalState == UniversalStates.PlayGame && PlayGameState == PlayGameStates.Interactive)
            {
                GoVCState();
            }
        }

        public void miHelpEvent()
        {
            GoHelpState();
        }

        public void btnNorthEvent()
        {
            if (UniversalState == UniversalStates.PlayGame && PlayGameState == PlayGameStates.Interactive)
            {
                GoMoveState(EDirection.North);
            }
        }

        public void btnEastEvent()
        {
            if (UniversalState == UniversalStates.PlayGame && PlayGameState == PlayGameStates.Interactive)
            {
                GoMoveState(EDirection.East);
            }
        }

        public void btnWestEvent()
        {
            if (UniversalState == UniversalStates.PlayGame && PlayGameState == PlayGameStates.Interactive)
            {
                GoMoveState(EDirection.West);
            }
        }

        public void btnSouthEvent()
        {
            if (UniversalState == UniversalStates.PlayGame && PlayGameState == PlayGameStates.Interactive)
            {
                GoMoveState(EDirection.South);
            }
        }      

        /////////////////// NON - EVENT TRANSITIONS ////////////////////////
        /// <summary>
        /// These methods enable transitions that are not associated
        /// with events.  They are called after the actions of the state
        /// are completed.
        /// 
        /// Guards should include valid current state check and other
        /// context checks.
        /// </summary>
        private void SaveFileExistsTransition()
        {
            if (File.Exists(strSaveFile))
            {
                GoLoadState();
            }
            else
            {
                lblOutput.Text = lblOutput.Text + "Save file: " + strSaveFile + " not found.";
            }
        }

        private void DataFileExistsTransition()
        {
            if (File.Exists(strDataFile))
            {
                GoSetupTowerState();
            }
            else
            {
                lblOutput.Text = "Data file: " + strDataFile + " not found.";
            }
        }

        //private void RoomHasSpecialTransition()
        //{
        //    string special = GetData.findSpecial();
        //    switch (special)
        //    {
        //        case "lever": GetData.activateLever();
        //                     break;
        //        case "item": //GetData.getItem();
        //                     break;
        //        default: break;
        //    }
        //}

        private void LevelOverTransition()
        {
            if (objGetData.IsLevelOver())
            {
                GameOverTransition();
            }
            else
            {
                GoPlayState();
            }
        }

        private void GameOverTransition()
        {
            if (objGetData.IsGameOver())
            {
                GoGameOverState();
            }
            else
            {
                GoSetupFloorState();
            }
        }

        private void PlayAgainTransition()
        {
            GoPrepareGameState();
        }
    }
}