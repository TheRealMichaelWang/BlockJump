namespace BlockJump
{
    partial class StartPage
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
            this.components = new System.ComponentModel.Container();
            this.startImage = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.startImage)).BeginInit();
            this.SuspendLayout();
            // 
            // startImage
            // 
            this.startImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startImage.Location = new System.Drawing.Point(0, 0);
            this.startImage.Name = "startImage";
            this.startImage.Size = new System.Drawing.Size(534, 398);
            this.startImage.TabIndex = 0;
            this.startImage.TabStop = false;
            this.startImage.Click += new System.EventHandler(this.StartImage_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 398);
            this.Controls.Add(this.startImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartPage";
            this.ShowIcon = false;
            this.Text = "BLOCK JUMP";
            ((System.ComponentModel.ISupportInitialize)(this.startImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox startImage;
        private System.Windows.Forms.Timer timer;
    }
}