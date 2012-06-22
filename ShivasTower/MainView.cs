using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ShivasTower.Control;

namespace ShivasTower
{
    public partial class MainView : Form
    {
        Controller ctrl = null;

        public MainView()
        {
            InitializeComponent();

            ctrl = new Controller(miSave, miPerform, lblMap, pnlButtons, btnNorth,
                btnEast, btnWest, btnSouth, lblOutput, lblInvent);
        }

        #region Menu Events

        public void miNew_Click(object sender, EventArgs e)
        {
            ctrl.miNewGameEvent();
        }

        public void miLoad_Click(object sender, EventArgs e)
        {
            ctrl.miLoadGameEvent();
        }

        public void miSave_Click(object sender, EventArgs e)
        {
            ctrl.miSaveGameEvent();
        }

        public void miExit_Click(object sender, EventArgs e)
        {
            ctrl.miExitGameEvent();
        }

        public void miAction_Click(object sender, EventArgs e)
        {
            ctrl.miActionEvent();
        }

        public void miExamine_Click(object sender, EventArgs e)
        {
            ctrl.miExamineEvent();
        }

        public void miVC_Click(object sender, EventArgs e)
        {
            ctrl.miVCEvent();
        }

        public void miHelp_Click(object sender, EventArgs e)
        {
            ctrl.miHelpEvent();
        }

        #endregion Menu Events

        #region Events

        private void btnNorth_Click(object Sender, EventArgs e)
        {
            ctrl.btnNorthEvent(); 
        }

        private void btnEast_Click(object Sender, EventArgs e)
        {
            ctrl.btnEastEvent(); 
        }

        private void btnWest_Click(object Sender, EventArgs e)
        {
            ctrl.btnWestEvent(); 
        }

        private void btnSouth_Click(object Sender, EventArgs e)
        {
            ctrl.btnSouthEvent();
        }

        #endregion Events
    }
}