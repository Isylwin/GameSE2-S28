namespace WinFormsGame
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbGame = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.ilEntities = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGame
            // 
            this.pbGame.BackColor = System.Drawing.Color.Purple;
            this.pbGame.Location = new System.Drawing.Point(124, 184);
            this.pbGame.Name = "pbGame";
            this.pbGame.Size = new System.Drawing.Size(1234, 781);
            this.pbGame.TabIndex = 0;
            this.pbGame.TabStop = false;
            this.pbGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGame_Paint);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 33;
            this.GameTimer.Tick += new System.EventHandler(this.Update);
            // 
            // ilEntities
            // 
            this.ilEntities.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilEntities.ImageStream")));
            this.ilEntities.TransparentColor = System.Drawing.Color.Transparent;
            this.ilEntities.Images.SetKeyName(0, "Player_v2.png");
            this.ilEntities.Images.SetKeyName(1, "Skeleton_v1.png");
            this.ilEntities.Images.SetKeyName(2, "Arrow30x30_vFinalWest.png");
            this.ilEntities.Images.SetKeyName(3, "Arrow30x30_vFinalEast.png");
            this.ilEntities.Images.SetKeyName(4, "Arrow30x30_vFinalNorth.png");
            this.ilEntities.Images.SetKeyName(5, "Arrow30x30_vFinalSouth.png");
            this.ilEntities.Images.SetKeyName(6, "No_texture.bmp");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.pbGame);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGame;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.ImageList ilEntities;
    }
}

