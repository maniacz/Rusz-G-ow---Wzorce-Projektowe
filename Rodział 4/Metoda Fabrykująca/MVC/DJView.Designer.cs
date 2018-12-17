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
            // DJView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pbrBeatBar);
            this.Controls.Add(this.lblBPMOutput);
            this.Name = "DJView";
            this.Text = "DJView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBPMOutput;
        private System.Windows.Forms.ProgressBar pbrBeatBar;
    }
}