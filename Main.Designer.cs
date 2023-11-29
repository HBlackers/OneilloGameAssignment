namespace O_NeilloGame
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Menu = new ToolStrip();
            btnGame = new ToolStripDropDownButton();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            restoreGameToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            btnSettings = new ToolStripDropDownButton();
            informationPanelToolStripMenuItem = new ToolStripMenuItem();
            speakToolStripMenuItem = new ToolStripMenuItem();
            btnHelp = new ToolStripDropDownButton();
            helpToolStripMenuItem = new ToolStripMenuItem();
            flpGameInfo = new FlowLayoutPanel();
            Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.BackColor = Color.Chocolate;
            Menu.ImageScalingSize = new Size(20, 20);
            Menu.Items.AddRange(new ToolStripItem[] { btnGame, btnSettings, btnHelp });
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(982, 27);
            Menu.TabIndex = 0;
            Menu.Text = "tsMenu";
            // 
            // btnGame
            // 
            btnGame.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnGame.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, saveGameToolStripMenuItem, restoreGameToolStripMenuItem, exitToolStripMenuItem });
            btnGame.Image = (Image)resources.GetObject("btnGame.Image");
            btnGame.ImageTransparentColor = Color.Magenta;
            btnGame.Name = "btnGame";
            btnGame.Size = new Size(62, 24);
            btnGame.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(185, 26);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += NewGame_Click;
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(185, 26);
            saveGameToolStripMenuItem.Text = "Save Game";
            saveGameToolStripMenuItem.Click += SaveGame_Click;
            // 
            // restoreGameToolStripMenuItem
            // 
            restoreGameToolStripMenuItem.Name = "restoreGameToolStripMenuItem";
            restoreGameToolStripMenuItem.Size = new Size(185, 26);
            restoreGameToolStripMenuItem.Text = "Restore Game";
            restoreGameToolStripMenuItem.Click += RestoreGame_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(185, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitGame_Click;
            // 
            // btnSettings
            // 
            btnSettings.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSettings.DropDownItems.AddRange(new ToolStripItem[] { informationPanelToolStripMenuItem, speakToolStripMenuItem });
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.ImageTransparentColor = Color.Magenta;
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(76, 24);
            btnSettings.Text = "Settings";
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Checked = true;
            informationPanelToolStripMenuItem.CheckState = CheckState.Checked;
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(209, 26);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            informationPanelToolStripMenuItem.Click += Information_Click;
            // 
            // speakToolStripMenuItem
            // 
            speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            speakToolStripMenuItem.Size = new Size(209, 26);
            speakToolStripMenuItem.Text = "Speak";
            speakToolStripMenuItem.Click += Speak_Click;
            // 
            // btnHelp
            // 
            btnHelp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnHelp.DropDownItems.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            btnHelp.Image = (Image)resources.GetObject("btnHelp.Image");
            btnHelp.ImageTransparentColor = Color.Magenta;
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(55, 24);
            btnHelp.Text = "Help";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(133, 26);
            helpToolStripMenuItem.Text = "About";
            helpToolStripMenuItem.Click += About_Click;
            // 
            // flpGameInfo
            // 
            flpGameInfo.BackColor = Color.Chocolate;
            flpGameInfo.Location = new Point(188, 779);
            flpGameInfo.Margin = new Padding(4, 5, 4, 5);
            flpGameInfo.Name = "flpGameInfo";
            flpGameInfo.Size = new Size(600, 169);
            flpGameInfo.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 953);
            Controls.Add(flpGameInfo);
            Controls.Add(Menu);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Main";
            Text = "O'Neillo Game";
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ToolStrip Menu;
        private FlowLayoutPanel flpGameInfo;
        public ToolStripDropDownButton btnSettings;
        public ToolStripMenuItem informationPanelToolStripMenuItem;
        public ToolStripMenuItem speakToolStripMenuItem;
        private ToolStripDropDownButton btnGame;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private ToolStripMenuItem restoreGameToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripDropDownButton btnHelp;
        private ToolStripMenuItem helpToolStripMenuItem;
    }
}

