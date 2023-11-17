namespace O_neilloGame.Components
{
    partial class ctrAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrAbout));
            lblAboutGameTitle = new Label();
            lblAbout = new Label();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblAboutGameTitle
            // 
            lblAboutGameTitle.AutoSize = true;
            lblAboutGameTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblAboutGameTitle.ForeColor = Color.Chocolate;
            lblAboutGameTitle.Location = new Point(136, 13);
            lblAboutGameTitle.Name = "lblAboutGameTitle";
            lblAboutGameTitle.Size = new Size(223, 41);
            lblAboutGameTitle.TabIndex = 4;
            lblAboutGameTitle.Text = "O'Neillo Game";
            // 
            // lblAbout
            // 
            lblAbout.AutoSize = true;
            lblAbout.BackColor = Color.Chocolate;
            lblAbout.BorderStyle = BorderStyle.FixedSingle;
            lblAbout.ForeColor = SystemColors.ButtonHighlight;
            lblAbout.Location = new Point(8, 71);
            lblAbout.Name = "lblAbout";
            lblAbout.Size = new Size(489, 182);
            lblAbout.TabIndex = 5;
            lblAbout.Text = resources.GetString("lblAbout.Text");
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.Chocolate;
            btnOk.ForeColor = SystemColors.ButtonHighlight;
            btnOk.Location = new Point(136, 275);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(223, 72);
            btnOk.TabIndex = 6;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += Ok_Click;
            // 
            // ctrAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOk);
            Controls.Add(lblAbout);
            Controls.Add(lblAboutGameTitle);
            Name = "ctrAbout";
            Size = new Size(500, 350);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAboutGameTitle;
        private Label lblAbout;
        private Button btnOk;
    }
}
