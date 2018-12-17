namespace MVC
{
    partial class DJSteering
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
            this.menDJ = new System.Windows.Forms.MenuStrip();
            this.dJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIncreaseBPM = new System.Windows.Forms.Button();
            this.btnDecreaseBPM = new System.Windows.Forms.Button();
            this.btnSetBPM = new System.Windows.Forms.Button();
            this.lblBPM = new System.Windows.Forms.Label();
            this.tbxBPM = new System.Windows.Forms.TextBox();
            this.menDJ.SuspendLayout();
            this.SuspendLayout();
            // 
            // menDJ
            // 
            this.menDJ.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dJToolStripMenuItem});
            this.menDJ.Location = new System.Drawing.Point(0, 0);
            this.menDJ.Name = "menDJ";
            this.menDJ.Size = new System.Drawing.Size(284, 24);
            this.menDJ.TabIndex = 3;
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
            this.startToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            // 
            // btnIncreaseBPM
            // 
            this.btnIncreaseBPM.Location = new System.Drawing.Point(112, 174);
            this.btnIncreaseBPM.Name = "btnIncreaseBPM";
            this.btnIncreaseBPM.Size = new System.Drawing.Size(75, 23);
            this.btnIncreaseBPM.TabIndex = 4;
            this.btnIncreaseBPM.Text = ">>";
            this.btnIncreaseBPM.UseVisualStyleBackColor = true;
            this.btnIncreaseBPM.Click += new System.EventHandler(this.btnIncreaseBPM_Click);
            // 
            // btnDecreaseBPM
            // 
            this.btnDecreaseBPM.Location = new System.Drawing.Point(31, 174);
            this.btnDecreaseBPM.Name = "btnDecreaseBPM";
            this.btnDecreaseBPM.Size = new System.Drawing.Size(75, 23);
            this.btnDecreaseBPM.TabIndex = 5;
            this.btnDecreaseBPM.Text = "<<";
            this.btnDecreaseBPM.UseVisualStyleBackColor = true;
            this.btnDecreaseBPM.Click += new System.EventHandler(this.btnDecreaseBPM_Click);
            // 
            // btnSetBPM
            // 
            this.btnSetBPM.Location = new System.Drawing.Point(31, 145);
            this.btnSetBPM.Name = "btnSetBPM";
            this.btnSetBPM.Size = new System.Drawing.Size(156, 23);
            this.btnSetBPM.TabIndex = 6;
            this.btnSetBPM.Text = "Ustaw";
            this.btnSetBPM.UseVisualStyleBackColor = true;
            this.btnSetBPM.Click += new System.EventHandler(this.btnSetBPM_Click);
            // 
            // lblBPM
            // 
            this.lblBPM.AutoSize = true;
            this.lblBPM.Location = new System.Drawing.Point(31, 126);
            this.lblBPM.Name = "lblBPM";
            this.lblBPM.Size = new System.Drawing.Size(33, 13);
            this.lblBPM.TabIndex = 7;
            this.lblBPM.Text = "BPM:";
            // 
            // tbxBPM
            // 
            this.tbxBPM.Location = new System.Drawing.Point(70, 123);
            this.tbxBPM.Name = "tbxBPM";
            this.tbxBPM.Size = new System.Drawing.Size(116, 20);
            this.tbxBPM.TabIndex = 8;
            // 
            // DJSteering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbxBPM);
            this.Controls.Add(this.lblBPM);
            this.Controls.Add(this.btnSetBPM);
            this.Controls.Add(this.btnDecreaseBPM);
            this.Controls.Add(this.btnIncreaseBPM);
            this.Controls.Add(this.menDJ);
            this.Name = "DJSteering";
            this.Text = "DJSteering";
            this.menDJ.ResumeLayout(false);
            this.menDJ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menDJ;
        private System.Windows.Forms.ToolStripMenuItem dJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.Button btnIncreaseBPM;
        private System.Windows.Forms.Button btnDecreaseBPM;
        private System.Windows.Forms.Button btnSetBPM;
        private System.Windows.Forms.Label lblBPM;
        private System.Windows.Forms.TextBox tbxBPM;
    }
}