using System.Windows.Forms;
using System.Drawing;
using ShivasTower.Properties;

namespace ShivasTower
{
    partial class MainView
    {
         //summary
         //Required designer variable.
         //summary
        private System.ComponentModel.IContainer components = null;

         //summary
         //Clean up any resources being used.
         //summary
         //param name=disposingtrue if managed resources should be disposed; otherwise, false.param
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                ctrl.btnNorthEvent();
            }
            else if (keyData == Keys.Left)
            {
                ctrl.btnWestEvent();
            }
            else if (keyData == Keys.Right)
            {
                ctrl.btnEastEvent();
            }
            else if (keyData == Keys.Down)
            {
                ctrl.btnSouthEvent();
            }
            else if (keyData == (Keys.Control | Keys.A))
            {
                ctrl.miActionEvent();
            }
            else if (keyData == (Keys.Control | Keys.E))
            {
                ctrl.miExamineEvent();
            }
            else if (keyData == (Keys.Control | Keys.L))
            {
                ctrl.miNewGameEvent();
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                ctrl.miNewGameEvent();
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                ctrl.miSaveGameEvent();
            }
            else if (keyData == (Keys.Control | Keys.V))
            {
                ctrl.miVCEvent();
            }
            else if (keyData == (Keys.Control | Keys.X))
            {
                ctrl.miExitGameEvent();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Windows Form Designer generated code

         //summary
         //Required method for Designer support - do not modify
         //the contents of this method with the code editor.
         //summary
        private void InitializeComponent()
        {
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();

            this.miPerform = new System.Windows.Forms.ToolStripMenuItem();
            this.miExamine = new System.Windows.Forms.ToolStripMenuItem();
            this.miAction = new System.Windows.Forms.ToolStripMenuItem();
            this.miVC = new System.Windows.Forms.ToolStripMenuItem();

            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ms = new System.Windows.Forms.MenuStrip();

            for (int i = 0; i < 5; i++)
            {
                for (int q = 0; q < 5; q++)
                {
                    this.lblMap[i, q] = new System.Windows.Forms.Label();
                }
            }
            this.pnlMap = new System.Windows.Forms.TableLayoutPanel();

            for (int q = 0; q < 7; q++)
            {
                this.lblInvent[q] = new System.Windows.Forms.Label();
            }
            this.pnlInvent = new System.Windows.Forms.TableLayoutPanel();

            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();

            this.lblOutput = new System.Windows.Forms.Label();

            this.ms.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlMap.SuspendLayout();
            this.pnlInvent.SuspendLayout();
            this.SuspendLayout();

            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miPerform,
            this.miHelp});
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(284, 24);
            this.ms.TabIndex = 0;
            this.ms.Text = "Menu Strip";
            //
            // miFile
            //
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miLoad,
            this.miSave,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(77, 20);
            this.miFile.Text = "File";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Text = "New";
            this.miNew.Click += miNew_Click;
            // 
            // miLoad
            // 
            this.miLoad.Name = "miLoad";
            this.miLoad.Text = "Load";
            this.miLoad.Click += miLoad_Click;
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Text = "Save";
            this.miSave.Click += miSave_Click;
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Text = "Exit";
            this.miExit.Click += miExit_Click;
            //
            // miPerform
            //
            this.miPerform.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExamine,
            this.miAction,
            this.miVC});
            this.miPerform.Name = "miPerform";
            this.miPerform.Size = new System.Drawing.Size(77, 20);
            this.miPerform.Text = "Perform";
            // 
            // miExamine
            // 
            this.miExamine.Name = "miExamine";
            this.miExamine.Text = "Examine";
            this.miExamine.Click += miExamine_Click;
            // 
            // miAction
            // 
            this.miAction.Name = "miAction";
            this.miAction.Text = "Action";
            this.miAction.Click += miAction_Click;
            // 
            // miVC
            // 
            this.miVC.Name = "miVC";
            this.miVC.Text = "View Character";
            this.miVC.Click += miVC_Click;
            // 
            // miHelp
            // 
            this.miHelp.Name = "miHelp";
            this.miHelp.Text = "Help";
            this.miHelp.Click += miHelp_Click;
            // 
            // lblMap
            // 
            for (int i = 0; i < 5; i++)
            {
                for (int q = 0; q < 5; q++)
                {
                    this.lblMap[i,q].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.lblMap[i,q].Margin = new System.Windows.Forms.Padding(0);
                    this.lblMap[i,q].Name = "label" + i + q;
                    this.lblMap[i, q].Size = new Size(59,59);
                    this.lblMap[i,q].TabIndex = 15;
                }
            }
            // 
            // btnNorth
            //
            this.btnNorth.Image = Resources.north;
            this.btnNorth.Enabled = true;
            this.btnNorth.Location = new System.Drawing.Point(56, 8);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(56, 40);
            this.btnNorth.TabIndex = 0;
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += this.btnNorth_Click;
            // 
            // btnWest
            // 
            this.btnWest.Image = Resources.west;
            this.btnWest.Enabled = true;
            this.btnWest.Location = new System.Drawing.Point(16, 48);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(40, 48);
            this.btnWest.TabIndex = 1;
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += this.btnWest_Click;
            // 
            // btnEast
            // 
            this.btnEast.Image = Resources.east;
            this.btnEast.Enabled = true;
            this.btnEast.Location = new System.Drawing.Point(112, 48);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(40, 48);
            this.btnEast.TabIndex = 2;
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += this.btnEast_Click;
            // 
            // btnSouth
            // 
            this.btnSouth.Image = Resources.south;
            this.btnSouth.Enabled = true;
            this.btnSouth.Location = new System.Drawing.Point(56, 96);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(56, 40);
            this.btnSouth.TabIndex = 3;
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += this.btnSouth_Click;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSouth);
            this.pnlButtons.Controls.Add(this.btnEast);
            this.pnlButtons.Controls.Add(this.btnWest);
            this.pnlButtons.Controls.Add(this.btnNorth);
            this.pnlButtons.Controls.Add(this.lblOutput);
            this.pnlButtons.Location = new System.Drawing.Point(296, 30);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(174, 296);
            this.pnlButtons.TabIndex = 1;
            // 
            // lblOutput
            // 
            this.lblOutput.Location = new System.Drawing.Point(8, 144);
            this.lblOutput.Name = "lblOut";
            this.lblOutput.Size = new System.Drawing.Size(160, 144);
            this.lblOutput.TabIndex = 4;
            // 
            // pnlMap
            // 
            this.pnlMap.ColumnCount = 5;
            this.pnlMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    this.pnlMap.Controls.Add(this.lblMap[col, row], (col), (4 - row));
                }
            }
            this.pnlMap.Location = new System.Drawing.Point(0, 30);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.RowCount = 5;
            this.pnlMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMap.Size = new System.Drawing.Size(295, 295);
            this.pnlMap.TabIndex = 0;
            // 
            // pnlInvent
            // 
            this.pnlInvent.ColumnCount = 7;
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnlInvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            for (int q = 0; q < 7; q++)
            {
                this.pnlInvent.Controls.Add(this.lblInvent[q], q, 0);
            }
            this.pnlInvent.Location = new System.Drawing.Point(0, 326);
            this.pnlInvent.Name = "pnlInvent";
            this.pnlInvent.RowCount = 1;
            this.pnlInvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlInvent.Size = new System.Drawing.Size(472, 112);
            this.pnlInvent.TabIndex = 2;
            this.pnlInvent.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            // 
            // lblInvent
            // 
            for (int q = 0; q < 7; q++)
            {
                this.lblInvent[q].Name = "label" + q;
                this.lblInvent[q].Size = new System.Drawing.Size(61, 112);
                this.lblInvent[q].TabIndex = 0;
            }
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(470, 438);

            this.Controls.Add(this.ms);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlInvent);

            this.MainMenuStrip = this.ms;

            this.Name = "GameForm";
            this.Text = "Shiva no Tor";

            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();

            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();

            this.pnlMap.ResumeLayout(false);
            this.pnlMap.PerformLayout();

            this.pnlInvent.ResumeLayout(false);
            this.pnlInvent.PerformLayout();
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ToolStripMenuItem miFile;
        private ToolStripMenuItem miNew;
        private ToolStripMenuItem miLoad;
        private ToolStripMenuItem miSave;
        private ToolStripMenuItem miExit;
        private ToolStripMenuItem miPerform;
        private ToolStripMenuItem miAction;
        private ToolStripMenuItem miExamine;
        private ToolStripMenuItem miVC;
        private ToolStripMenuItem miHelp;
        private MenuStrip ms;

        private Label[,] lblMap = new Label[5, 5];
        private TableLayoutPanel pnlMap;
        
        private Label[] lblInvent = new Label[7];
        private TableLayoutPanel pnlInvent;

        private Button btnNorth;
        private Button btnEast;
        private Button btnWest;
        private Button btnSouth;
        private Panel pnlButtons;
        
        private Label lblOutput;
    }
}