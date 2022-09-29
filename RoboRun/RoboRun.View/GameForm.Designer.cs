namespace RoboRun.View
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuFileNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._menuFileLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this._menuFileSaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this._menuFileExitGame = new System.Windows.Forms.ToolStripMenuItem();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this._menuGameSmall = new System.Windows.Forms.ToolStripMenuItem();
            this._menuGameMedium = new System.Windows.Forms.ToolStripMenuItem();
            this._menuGameBig = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._toolLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolLabelGameTime = new System.Windows.Forms.ToolStripStatusLabel();
            this._menuStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFile,
            this._menuSettings});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(11, 5, 0, 5);
            this._menuStrip.Size = new System.Drawing.Size(460, 34);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _menuFile
            // 
            this._menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFileNewGame,
            this.toolStripMenuItem1,
            this._menuFileLoadGame,
            this._menuFileSaveGame,
            this.toolStripMenuItem2,
            this._menuFileExitGame});
            this._menuFile.Name = "_menuFile";
            this._menuFile.Size = new System.Drawing.Size(46, 24);
            this._menuFile.Text = "File";
            // 
            // _menuFileNewGame
            // 
            this._menuFileNewGame.Name = "_menuFileNewGame";
            this._menuFileNewGame.Size = new System.Drawing.Size(200, 26);
            this._menuFileNewGame.Text = "Új játék";
            this._menuFileNewGame.Click += new System.EventHandler(this.MenuFileNewGame_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
            // 
            // _menuFileLoadGame
            // 
            this._menuFileLoadGame.Name = "_menuFileLoadGame";
            this._menuFileLoadGame.Size = new System.Drawing.Size(200, 26);
            this._menuFileLoadGame.Text = "Játék betöltése...";
            this._menuFileLoadGame.Click += new System.EventHandler(this.MenuFileLoadGame_Click);
            // 
            // _menuFileSaveGame
            // 
            this._menuFileSaveGame.Name = "_menuFileSaveGame";
            this._menuFileSaveGame.Size = new System.Drawing.Size(200, 26);
            this._menuFileSaveGame.Text = "Játék mentése...";
            this._menuFileSaveGame.Click += new System.EventHandler(this.MenuFileSaveGame_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(197, 6);
            // 
            // _menuFileExitGame
            // 
            this._menuFileExitGame.Name = "_menuFileExitGame";
            this._menuFileExitGame.Size = new System.Drawing.Size(200, 26);
            this._menuFileExitGame.Text = "Kilépés";
            this._menuFileExitGame.Click += new System.EventHandler(this.MenuFileExitGame_Click);
            // 
            // _menuSettings
            // 
            this._menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuGameSmall,
            this._menuGameMedium,
            this._menuGameBig});
            this._menuSettings.Name = "_menuSettings";
            this._menuSettings.Size = new System.Drawing.Size(95, 24);
            this._menuSettings.Text = "Beállítások";
            // 
            // _menuGameSmall
            // 
            this._menuGameSmall.Name = "_menuGameSmall";
            this._menuGameSmall.Size = new System.Drawing.Size(184, 26);
            this._menuGameSmall.Text = "(7 x 7)";
            this._menuGameSmall.Click += new System.EventHandler(this.MenuGameSmall_Click);
            // 
            // _menuGameMedium
            // 
            this._menuGameMedium.Name = "_menuGameMedium";
            this._menuGameMedium.Size = new System.Drawing.Size(184, 26);
            this._menuGameMedium.Text = "(11 x 11)";
            this._menuGameMedium.Click += new System.EventHandler(this.MenuGameMedium_Click);
            // 
            // _menuGameBig
            // 
            this._menuGameBig.Name = "_menuGameBig";
            this._menuGameBig.Size = new System.Drawing.Size(184, 26);
            this._menuGameBig.Text = "(15 x 15)";
            this._menuGameBig.Click += new System.EventHandler(this.MenuGameBig_Click);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "RoboRun tábla (*.rrt)|*.rrt";
            this._openFileDialog.Title = "RoboRun játék betöltése";
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.Filter = "RoboRun tábla (*.rrt)|*.rrt";
            this._saveFileDialog.Title = "RoboRun játék mentése";
            // 
            // _statusStrip
            // 
            this._statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolLabel1,
            this._toolLabelGameTime});
            this._statusStrip.Location = new System.Drawing.Point(0, 490);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
            this._statusStrip.Size = new System.Drawing.Size(460, 30);
            this._statusStrip.TabIndex = 1;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _toolLabel1
            // 
            this._toolLabel1.Name = "_toolLabel1";
            this._toolLabel1.Size = new System.Drawing.Size(84, 24);
            this._toolLabel1.Text = "Lépésszám:";
            // 
            // _toolLabelGameTime
            // 
            this._toolLabelGameTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._toolLabelGameTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this._toolLabelGameTime.Name = "_toolLabelGameTime";
            this._toolLabelGameTime.Size = new System.Drawing.Size(59, 24);
            this._toolLabelGameTime.Text = "0:00:00";
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(460, 520);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "RoboRun játék";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _menuFile;
        private System.Windows.Forms.ToolStripMenuItem _menuFileNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _menuFileLoadGame;
        private System.Windows.Forms.ToolStripMenuItem _menuFileSaveGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem _menuFileExitGame;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _menuSettings;
        private System.Windows.Forms.ToolStripMenuItem _menuGameSmall;
        private System.Windows.Forms.ToolStripMenuItem _menuGameMedium;
        private System.Windows.Forms.ToolStripMenuItem _menuGameBig;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabel1;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabelGameTime;
    }
}