namespace O_neilloGame.Components
{
    partial class ctrSaveGame
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
            lblGameNameHeader = new Label();
            txtGameNameInput = new TextBox();
            btnSaveGame = new Button();
            lblSaveGameTitle = new Label();
            lblSaveGamesHeader = new Label();
            cmbSavedGames = new ComboBox();
            SuspendLayout();
            // 
            // lblGameNameHeader
            // 
            lblGameNameHeader.AutoSize = true;
            lblGameNameHeader.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblGameNameHeader.ForeColor = Color.Chocolate;
            lblGameNameHeader.Location = new Point(150, 153);
            lblGameNameHeader.Name = "lblGameNameHeader";
            lblGameNameHeader.Size = new Size(192, 32);
            lblGameNameHeader.TabIndex = 0;
            lblGameNameHeader.Text = "Set Game Name";
            // 
            // txtGameNameInput
            // 
            txtGameNameInput.Location = new Point(104, 188);
            txtGameNameInput.Name = "txtGameNameInput";
            txtGameNameInput.Size = new Size(271, 27);
            txtGameNameInput.TabIndex = 1;
            // 
            // btnSaveGame
            // 
            btnSaveGame.BackColor = Color.Chocolate;
            btnSaveGame.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveGame.ForeColor = Color.White;
            btnSaveGame.Location = new Point(162, 239);
            btnSaveGame.Name = "btnSaveGame";
            btnSaveGame.Size = new Size(160, 65);
            btnSaveGame.TabIndex = 2;
            btnSaveGame.Text = "Save";
            btnSaveGame.UseVisualStyleBackColor = false;
            btnSaveGame.Click += btnSaveGame_Click;
            // 
            // lblSaveGameTitle
            // 
            lblSaveGameTitle.AutoSize = true;
            lblSaveGameTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblSaveGameTitle.ForeColor = Color.Chocolate;
            lblSaveGameTitle.Location = new Point(162, 11);
            lblSaveGameTitle.Name = "lblSaveGameTitle";
            lblSaveGameTitle.Size = new Size(171, 41);
            lblSaveGameTitle.TabIndex = 3;
            lblSaveGameTitle.Text = "Save Game";
            // 
            // lblSaveGamesHeader
            // 
            lblSaveGamesHeader.AutoSize = true;
            lblSaveGamesHeader.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblSaveGamesHeader.ForeColor = Color.Chocolate;
            lblSaveGamesHeader.Location = new Point(162, 69);
            lblSaveGamesHeader.Name = "lblSaveGamesHeader";
            lblSaveGamesHeader.Size = new Size(160, 32);
            lblSaveGamesHeader.TabIndex = 4;
            lblSaveGamesHeader.Text = "Saved Games";
            // 
            // cmbSavedGames
            // 
            cmbSavedGames.FormattingEnabled = true;
            cmbSavedGames.Location = new Point(104, 104);
            cmbSavedGames.Name = "cmbSavedGames";
            cmbSavedGames.Size = new Size(271, 28);
            cmbSavedGames.TabIndex = 5;
            // 
            // ctrSaveGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbSavedGames);
            Controls.Add(lblSaveGamesHeader);
            Controls.Add(lblSaveGameTitle);
            Controls.Add(btnSaveGame);
            Controls.Add(txtGameNameInput);
            Controls.Add(lblGameNameHeader);
            Name = "ctrSaveGame";
            Size = new Size(500, 350);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGameNameHeader;
        private TextBox txtGameNameInput;
        private Button btnSaveGame;
        private Label lblSaveGameTitle;
        private Label lblSaveGamesHeader;
        private ComboBox cmbSavedGames;
    }
}
