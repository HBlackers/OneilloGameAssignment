﻿
namespace O_neilloGame.Components
{
    partial class ctrToken
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
            imgTile = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imgTile).BeginInit();
            SuspendLayout();
            // 
            // imgTile
            // 
            imgTile.BackColor = Color.DarkGreen;
            imgTile.BorderStyle = BorderStyle.FixedSingle;
            imgTile.Enabled = false;
            imgTile.Location = new Point(3, 3);
            imgTile.Name = "imgTile";
            imgTile.Size = new Size(116, 96);
            imgTile.SizeMode = PictureBoxSizeMode.CenterImage;
            imgTile.TabIndex = 0;
            imgTile.TabStop = false;
            imgTile.Click += TileClicked;
            // 
            // ctrToken
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(imgTile);
            Name = "ctrToken";
            Size = new Size(122, 102);
            Click += TileClicked;
            ((System.ComponentModel.ISupportInitialize)imgTile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox imgTile;
    }
}
