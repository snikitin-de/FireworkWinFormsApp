namespace FireworkWinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            renderPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)renderPictureBox).BeginInit();
            SuspendLayout();
            // 
            // renderPictureBox
            // 
            renderPictureBox.Dock = DockStyle.Fill;
            renderPictureBox.Location = new Point(0, 0);
            renderPictureBox.Name = "renderPictureBox";
            renderPictureBox.Size = new Size(1487, 823);
            renderPictureBox.TabIndex = 0;
            renderPictureBox.TabStop = false;
            renderPictureBox.Paint += renderPictureBox_Paint;
            renderPictureBox.MouseDown += renderPictureBox_MouseDown;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1487, 823);
            Controls.Add(renderPictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(500, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Салют";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)renderPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox renderPictureBox;
    }
}