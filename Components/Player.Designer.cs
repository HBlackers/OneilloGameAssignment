

namespace O_NeilloGame.Components
{
    partial class Player
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
            txtPlayerName = new TextBox();
            lblPlayerTokenNum = new Label();
            imgPlayerTokenColour = new PictureBox();
            lblPlayerTurn = new Label();
            ((System.ComponentModel.ISupportInitialize)imgPlayerTokenColour).BeginInit();
            SuspendLayout();
            // 
            // txtPlayerName
            // 
            txtPlayerName.BackColor = Color.White;
            txtPlayerName.ForeColor = Color.DarkOrange;
            txtPlayerName.Location = new Point(4, 5);
            txtPlayerName.Margin = new Padding(4, 5, 4, 5);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(260, 27);
            txtPlayerName.TabIndex = 0;
            txtPlayerName.TextChanged += txtPlayerName_TextChanged;
            // 
            // lblPlayerTokenNum
            // 
            lblPlayerTokenNum.AutoSize = true;
            lblPlayerTokenNum.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlayerTokenNum.ForeColor = Color.White;
            lblPlayerTokenNum.Location = new Point(4, 37);
            lblPlayerTokenNum.Margin = new Padding(4, 0, 4, 0);
            lblPlayerTokenNum.Name = "lblPlayerTokenNum";
            lblPlayerTokenNum.Size = new Size(36, 39);
            lblPlayerTokenNum.TabIndex = 1;
            lblPlayerTokenNum.Text = "0";
            // 
            // imgPlayerTokenColour
            // 
            imgPlayerTokenColour.BackColor = Color.Transparent;
            imgPlayerTokenColour.Location = new Point(57, 37);
            imgPlayerTokenColour.Margin = new Padding(4, 5, 4, 5);
            imgPlayerTokenColour.Name = "imgPlayerTokenColour";
            imgPlayerTokenColour.Size = new Size(80, 80);
            imgPlayerTokenColour.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPlayerTokenColour.TabIndex = 2;
            imgPlayerTokenColour.TabStop = false;
            // 
            // lblPlayerTurn
            // 
            lblPlayerTurn.AutoSize = true;
            lblPlayerTurn.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlayerTurn.ForeColor = Color.Chartreuse;
            lblPlayerTurn.Location = new Point(70, 133);
            lblPlayerTurn.Margin = new Padding(4, 0, 4, 0);
            lblPlayerTurn.Name = "lblPlayerTurn";
            lblPlayerTurn.Size = new Size(129, 29);
            lblPlayerTurn.TabIndex = 3;
            lblPlayerTurn.Text = "Your Turn";
            // 
            // Player
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblPlayerTurn);
            Controls.Add(imgPlayerTokenColour);
            Controls.Add(lblPlayerTokenNum);
            Controls.Add(txtPlayerName);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Player";
            Size = new Size(276, 170);
            ((System.ComponentModel.ISupportInitialize)imgPlayerTokenColour).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtPlayerName;
        private Label lblPlayerTokenNum;
        public PictureBox imgPlayerTokenColour;
        public Label lblPlayerTurn;
    }
}
