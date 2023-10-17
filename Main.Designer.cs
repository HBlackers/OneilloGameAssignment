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
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnGame = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.pnl_Game = new System.Windows.Forms.Panel();
            this.flp_GameInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Chocolate;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGame,
            this.btnSettings,
            this.btnHelp});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(844, 25);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "toolStrip1";
            // 
            // btnGame
            // 
            this.btnGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGame.Image = ((System.Drawing.Image)(resources.GetObject("btnGame.Image")));
            this.btnGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(42, 22);
            this.btnGame.Text = "Game";
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(53, 22);
            this.btnSettings.Text = "Settings";
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(36, 22);
            this.btnHelp.Text = "Help";
            // 
            // pnl_Game
            // 
            this.pnl_Game.BackColor = System.Drawing.Color.White;
            this.pnl_Game.Location = new System.Drawing.Point(12, 47);
            this.pnl_Game.Name = "pnl_Game";
            this.pnl_Game.Size = new System.Drawing.Size(776, 248);
            this.pnl_Game.TabIndex = 1;
            // 
            // flp_GameInfo
            // 
            this.flp_GameInfo.BackColor = System.Drawing.Color.Chocolate;
            this.flp_GameInfo.Location = new System.Drawing.Point(12, 526);
            this.flp_GameInfo.Name = "flp_GameInfo";
            this.flp_GameInfo.Size = new System.Drawing.Size(446, 130);
            this.flp_GameInfo.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(844, 821);
            this.Controls.Add(this.flp_GameInfo);
            this.Controls.Add(this.pnl_Game);
            this.Controls.Add(this.Menu);
            this.Name = "Main";
            this.Text = "O\'Neillo Game";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton btnGame;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.Panel pnl_Game;
        private System.Windows.Forms.FlowLayoutPanel flp_GameInfo;
    }
}

