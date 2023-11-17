namespace O_neilloGame.Components
{
    partial class ctrRestoreGame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbSavedGames = new ComboBox();
            lblSaveGamesHeader = new Label();
            lblLoadGameTitle = new Label();
            btnLoadGame = new Button();
            SuspendLayout();
            // 
            // cmbSavedGames
            // 
            cmbSavedGames.FormattingEnabled = true;
            cmbSavedGames.Location = new Point(139, 157);
            cmbSavedGames.Name = "cmbSavedGames";
            cmbSavedGames.Size = new Size(220, 28);
            cmbSavedGames.TabIndex = 11;
            // 
            // lblSaveGamesHeader
            // 
            lblSaveGamesHeader.AutoSize = true;
            lblSaveGamesHeader.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblSaveGamesHeader.ForeColor = Color.Chocolate;
            lblSaveGamesHeader.Location = new Point(169, 104);
            lblSaveGamesHeader.Name = "lblSaveGamesHeader";
            lblSaveGamesHeader.Size = new Size(160, 32);
            lblSaveGamesHeader.TabIndex = 10;
            lblSaveGamesHeader.Text = "Saved Games";
            // 
            // lblLoadGameTitle
            // 
            lblLoadGameTitle.AutoSize = true;
            lblLoadGameTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoadGameTitle.ForeColor = Color.Chocolate;
            lblLoadGameTitle.Location = new Point(167, 16);
            lblLoadGameTitle.Name = "lblLoadGameTitle";
            lblLoadGameTitle.Size = new Size(174, 41);
            lblLoadGameTitle.TabIndex = 9;
            lblLoadGameTitle.Text = "Load Game";
            // 
            // btnLoadGame
            // 
            btnLoadGame.BackColor = Color.Chocolate;
            btnLoadGame.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadGame.ForeColor = Color.White;
            btnLoadGame.Location = new Point(167, 222);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(174, 77);
            btnLoadGame.TabIndex = 8;
            btnLoadGame.Text = "Load";
            btnLoadGame.UseVisualStyleBackColor = false;
            btnLoadGame.Click += LoadGame_Click;
            // 
            // ctrRestoreGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbSavedGames);
            Controls.Add(lblSaveGamesHeader);
            Controls.Add(lblLoadGameTitle);
            Controls.Add(btnLoadGame);
            Name = "ctrRestoreGame";
            Size = new Size(500, 350);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSavedGames;
        private Label lblSaveGamesHeader;
        private Label lblLoadGameTitle;
        private Button btnLoadGame;
    }
}
