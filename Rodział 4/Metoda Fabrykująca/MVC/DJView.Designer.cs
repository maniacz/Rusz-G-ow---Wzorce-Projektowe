namespace MVC
{
    partial class DJView
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
            this.lblBPMOutput = new System.Windows.Forms.Label();
            this.pbrBeatBar = new System.Windows.Forms.ProgressBar();
            this.menDJ = new System.Windows.Forms.MenuStrip();
            this.dJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menDJ.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBPMOutput
            // 
            this.lblBPMOutput.AutoSize = true;
            this.lblBPMOutput.Location = new System.Drawing.Point(168, 129);
            this.lblBPMOutput.Name = "lblBPMOutput";
            this.lblBPMOutput.Size = new System.Drawing.Size(72, 13);
            this.lblBPMOutput.TabIndex = 0;
            this.lblBPMOutput.Text = "lblBPMOutput";
            // 
            // pbrBeatBar
            // 
            this.pbrBeatBar.Location = new System.Drawing.Point(74, 75);
            this.pbrBeatBar.Name = "pbrBeatBar";
            this.pbrBeatBar.Size = new System.Drawing.Size(100, 23);
            this.pbrBeatBar.TabIndex = 1;
            // 
            // menDJ
            // 
            this.menDJ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dJToolStripMenuItem});
            this.menDJ.Location = new System.Drawing.Point(0, 0);
            this.menDJ.Name = "menDJ";
            this.menDJ.Size = new System.Drawing.Size(284, 24);
            this.menDJ.TabIndex = 2;
            this.menDJ.Text = "menuStrip1";
            // 
            // dJToolStripMenuItem
            // 
            this.dJToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.dJToolStripMenuItem.Name = "dJToolStripMenuItem";
            this.dJToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.dJToolStripMenuItem.Text = "DJ";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            // 
            // DJView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pbrBeatBar);
            this.Controls.Add(this.lblBPMOutput);
            this.Controls.Add(this.menDJ);
            this.MainMenuStrip = this.menDJ;
            this.Name = "DJView";
            this.Text = "DJView";
            this.menDJ.ResumeLayout(false);
            this.menDJ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBPMOutput;
        private System.Windows.Forms.ProgressBar pbrBeatBar;
        private System.Windows.Forms.MenuStrip menDJ;
        private System.Windows.Forms.ToolStripMenuItem dJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
    }
}