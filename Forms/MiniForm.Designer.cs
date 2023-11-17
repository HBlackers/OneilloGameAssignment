namespace O_neilloGame.Forms
{
    partial class MiniForm
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
            flpContent = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpContent
            // 
            flpContent.Location = new Point(12, 12);
            flpContent.Name = "flpContent";
            flpContent.Size = new Size(510, 375);
            flpContent.TabIndex = 0;
            // 
            // MiniForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 403);
            Controls.Add(flpContent);
            Name = "MiniForm";
            Text = "MiniForm";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpContent;
    }
}