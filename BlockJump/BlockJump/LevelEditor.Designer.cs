namespace BlockJump
{
    partial class LevelEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.LevelDrawer = new System.Windows.Forms.PictureBox();
            this.OpenSaveButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.NewLevelButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.LevelDrawer)).BeginInit();
            this.SuspendLayout();
            // 
            // LevelDrawer
            // 
            this.LevelDrawer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LevelDrawer.Location = new System.Drawing.Point(100, 0);
            this.LevelDrawer.Name = "LevelDrawer";
            this.LevelDrawer.Size = new System.Drawing.Size(800, 75);
            this.LevelDrawer.TabIndex = 0;
            this.LevelDrawer.TabStop = false;
            this.LevelDrawer.SizeChanged += new System.EventHandler(this.LevelDrawer_SizeChanged);
            // 
            // OpenSaveButton
            // 
            this.OpenSaveButton.Location = new System.Drawing.Point(12, 0);
            this.OpenSaveButton.Name = "OpenSaveButton";
            this.OpenSaveButton.Size = new System.Drawing.Size(75, 23);
            this.OpenSaveButton.TabIndex = 1;
            this.OpenSaveButton.UseVisualStyleBackColor = true;
            this.OpenSaveButton.Click += new System.EventHandler(this.OpenSaveButton_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(0, 80);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(900, 493);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // NewLevelButton
            // 
            this.NewLevelButton.Location = new System.Drawing.Point(12, 30);
            this.NewLevelButton.Name = "NewLevelButton";
            this.NewLevelButton.Size = new System.Drawing.Size(75, 23);
            this.NewLevelButton.TabIndex = 3;
            this.NewLevelButton.UseVisualStyleBackColor = true;
            this.NewLevelButton.Click += new System.EventHandler(this.NewLevelButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "MW LEVEL FILES|*.lev";
            this.openFileDialog.Title = "Open A Level";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 558);
            this.Controls.Add(this.NewLevelButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.OpenSaveButton);
            this.Controls.Add(this.LevelDrawer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            ((System.ComponentModel.ISupportInitialize)(this.LevelDrawer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LevelDrawer;
        private System.Windows.Forms.Button OpenSaveButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button NewLevelButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}