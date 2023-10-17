namespace O_NeilloGame.Components
{
    partial class ctrGameInfo
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
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.lblPlayerTokenNum = new System.Windows.Forms.Label();
            this.imgPlayerTokenColour = new System.Windows.Forms.PictureBox();
            this.lblPlayerTurn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayerTokenColour)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(5, 22);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(196, 20);
            this.txtPlayerName.TabIndex = 0;
            // 
            // lblPlayerTokenNum
            // 
            this.lblPlayerTokenNum.AutoSize = true;
            this.lblPlayerTokenNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblPlayerTokenNum.Location = new System.Drawing.Point(15, 63);
            this.lblPlayerTokenNum.Name = "lblPlayerTokenNum";
            this.lblPlayerTokenNum.Size = new System.Drawing.Size(29, 31);
            this.lblPlayerTokenNum.TabIndex = 1;
            this.lblPlayerTokenNum.Text = "0";
            // 
            // imgPlayerTokenColour
            // 
            this.imgPlayerTokenColour.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgPlayerTokenColour.Location = new System.Drawing.Point(60, 45);
            this.imgPlayerTokenColour.Name = "imgPlayerTokenColour";
            this.imgPlayerTokenColour.Size = new System.Drawing.Size(141, 49);
            this.imgPlayerTokenColour.TabIndex = 2;
            this.imgPlayerTokenColour.TabStop = false;
            // 
            // lblPlayerTurn
            // 
            this.lblPlayerTurn.AutoSize = true;
            this.lblPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblPlayerTurn.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblPlayerTurn.Location = new System.Drawing.Point(56, 106);
            this.lblPlayerTurn.Name = "lblPlayerTurn";
            this.lblPlayerTurn.Size = new System.Drawing.Size(104, 24);
            this.lblPlayerTurn.TabIndex = 3;
            this.lblPlayerTurn.Text = "Your Turn";
            // 
            // ctrGameInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPlayerTurn);
            this.Controls.Add(this.imgPlayerTokenColour);
            this.Controls.Add(this.lblPlayerTokenNum);
            this.Controls.Add(this.txtPlayerName);
            this.Name = "ctrGameInfo";
            this.Size = new System.Drawing.Size(237, 136);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayerTokenColour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label lblPlayerTokenNum;
        private System.Windows.Forms.PictureBox imgPlayerTokenColour;
        private System.Windows.Forms.Label lblPlayerTurn;
    }
}
