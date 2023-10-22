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
            btnGame = new ToolStripButton();
            btnSettings = new ToolStripButton();
            btnHelp = new ToolStripButton();
            flp_GameInfo = new FlowLayoutPanel();
            tlpGameBoard = new TableLayoutPanel();
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
            Menu.Text = "toolStrip1";
            // 
            // btnGame
            // 
            btnGame.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnGame.Image = (Image)resources.GetObject("btnGame.Image");
            btnGame.ImageTransparentColor = Color.Magenta;
            btnGame.Name = "btnGame";
            btnGame.Size = new Size(52, 24);
            btnGame.Text = "Game";
            // 
            // btnSettings
            // 
            btnSettings.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.ImageTransparentColor = Color.Magenta;
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(66, 24);
            btnSettings.Text = "Settings";
            // 
            // btnHelp
            // 
            btnHelp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnHelp.Image = (Image)resources.GetObject("btnHelp.Image");
            btnHelp.ImageTransparentColor = Color.Magenta;
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(45, 24);
            btnHelp.Text = "Help";
            // 
            // flp_GameInfo
            // 
            flp_GameInfo.BackColor = Color.Chocolate;
            flp_GameInfo.Location = new Point(191, 712);
            flp_GameInfo.Margin = new Padding(4, 5, 4, 5);
            flp_GameInfo.Name = "flp_GameInfo";
            flp_GameInfo.Size = new Size(600, 200);
            flp_GameInfo.TabIndex = 2;
            // 
            // tlpGameBoard
            // 
            tlpGameBoard.BackColor = Color.Black;
            tlpGameBoard.ColumnCount = 2;
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.RowStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpGameBoard.Location = new Point(42, 54);
            tlpGameBoard.Name = "tlpGameBoard";
            tlpGameBoard.RowCount = 2;
            tlpGameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpGameBoard.Size = new Size(900, 600);
            tlpGameBoard.TabIndex = 3;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 953);
            Controls.Add(tlpGameBoard);
            Controls.Add(flp_GameInfo);
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

        private ToolStrip Menu;
        private ToolStripButton btnGame;
        private ToolStripButton btnSettings;
        private ToolStripButton btnHelp;
        private FlowLayoutPanel flp_GameInfo;
        private TableLayoutPanel tlpGameBoard;
    }
}

