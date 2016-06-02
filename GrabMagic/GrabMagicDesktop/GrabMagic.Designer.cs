namespace GrabMagicDesktop
{
    partial class GrabMagic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrabMagic));
            this.FullscreenScreenshotButton = new System.Windows.Forms.Button();
            this.RegionButton = new System.Windows.Forms.Button();
            this.CheckRun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // FullscreenScreenshotButton
            // 
            this.FullscreenScreenshotButton.Font = new System.Drawing.Font("TYPOGRAPH PRO", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullscreenScreenshotButton.Location = new System.Drawing.Point(12, 12);
            this.FullscreenScreenshotButton.Name = "FullscreenScreenshotButton";
            this.FullscreenScreenshotButton.Size = new System.Drawing.Size(203, 42);
            this.FullscreenScreenshotButton.TabIndex = 0;
            this.FullscreenScreenshotButton.Text = "Fullscreen Screenshot";
            this.FullscreenScreenshotButton.UseVisualStyleBackColor = true;
            this.FullscreenScreenshotButton.Click += new System.EventHandler(this.FullscreenScreenshotButton_Click);
            // 
            // RegionButton
            // 
            this.RegionButton.Font = new System.Drawing.Font("TYPOGRAPH PRO", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegionButton.Location = new System.Drawing.Point(12, 90);
            this.RegionButton.Name = "RegionButton";
            this.RegionButton.Size = new System.Drawing.Size(203, 42);
            this.RegionButton.TabIndex = 1;
            this.RegionButton.Text = "Region Screenshot";
            this.RegionButton.UseVisualStyleBackColor = true;
            this.RegionButton.Click += new System.EventHandler(this.RegionButton_Click);
            // 
            // CheckRun
            // 
            this.CheckRun.AutoSize = true;
            this.CheckRun.Font = new System.Drawing.Font("TYPOGRAPH PRO", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckRun.Location = new System.Drawing.Point(12, 63);
            this.CheckRun.Name = "CheckRun";
            this.CheckRun.Size = new System.Drawing.Size(107, 18);
            this.CheckRun.TabIndex = 2;
            this.CheckRun.Text = "Run at startup";
            this.CheckRun.UseVisualStyleBackColor = true;
            this.CheckRun.CheckedChanged += new System.EventHandler(this.CheckRun_CheckedChanged);
            // 
            // GrabMagic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 146);
            this.Controls.Add(this.CheckRun);
            this.Controls.Add(this.RegionButton);
            this.Controls.Add(this.FullscreenScreenshotButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GrabMagic";
            this.Text = "GrabMagic";
            this.Resize += new System.EventHandler(this.GrabMagic_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FullscreenScreenshotButton;
        private System.Windows.Forms.Button RegionButton;
        private System.Windows.Forms.CheckBox CheckRun;
    }
}