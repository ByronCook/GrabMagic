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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrabMagic));
            this.FullscreenScreenshotButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GrabMagicNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.ExitContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FullscreenScreenshotButton
            // 
            this.FullscreenScreenshotButton.Font = new System.Drawing.Font("TYPOGRAPH PRO", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullscreenScreenshotButton.Location = new System.Drawing.Point(12, 12);
            this.FullscreenScreenshotButton.Name = "FullscreenScreenshotButton";
            this.FullscreenScreenshotButton.Size = new System.Drawing.Size(162, 42);
            this.FullscreenScreenshotButton.TabIndex = 0;
            this.FullscreenScreenshotButton.Text = "Fullscreen Screenshot";
            this.FullscreenScreenshotButton.UseVisualStyleBackColor = true;
            this.FullscreenScreenshotButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("TYPOGRAPH PRO", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Region Screenshot";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GrabMagicNotify
            // 
            this.GrabMagicNotify.ContextMenuStrip = this.ExitContextMenu;
            this.GrabMagicNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("GrabMagicNotify.Icon")));
            this.GrabMagicNotify.Text = "GrabMagic Screenshotting Application™";
            this.GrabMagicNotify.Visible = true;
            // 
            // ExitContextMenu
            // 
            this.ExitContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.ExitContextMenu.Name = "Exit";
            this.ExitContextMenu.Size = new System.Drawing.Size(153, 48);
            this.ExitContextMenu.Text = "Exit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Exit";
            this.toolStripMenuItem1.ToolTipText = "Exit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // GrabMagic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 146);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FullscreenScreenshotButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GrabMagic";
            this.Text = "GrabMagic";
            this.Resize += new System.EventHandler(this.GrabMagic_Resize);
            this.ExitContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FullscreenScreenshotButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon GrabMagicNotify;
        private System.Windows.Forms.ContextMenuStrip ExitContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}