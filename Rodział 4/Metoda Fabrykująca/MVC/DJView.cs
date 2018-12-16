using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVC
{
    public partial class DJView : Form, IBeatObserver, IBPMObserver
    {
        IBeatModel model;
        IController controller;

        public DJView()
        {
            InitializeComponent();
        }

        public DJView(IController controller, IBeatModel model) : this()
        {
            this.controller = controller;
            this.model = model;
            model.RegisterObserver((IBeatObserver)this);
            model.RegisterObserver((IBPMObserver)this);
        }

        public void UpdateBPM()
        {
            int bpm = model.GetBPM();
            if (bpm == 0)
                lblBPMOutput.Text = "offline";
            else
                lblBPMOutput.Text = "Bieżąca wartość BPM :" + model.GetBPM();
        }

        public void UpdateBeat()
        {
            pbrBeatBar.Value = 100;
        }

        public void ActivateStopMenuItem()
        {
            stopToolStripMenuItem.Enabled = true;
        }

        public void DeactivateStopMenuItem()
        {
            stopToolStripMenuItem.Enabled = false;
        }

        public void ActivateStartMenuItem()
        {
            startToolStripMenuItem.Enabled = true;
        }

        public void DeactivateStartMenuItem()
        {
            startToolStripMenuItem.Enabled = false;
        }
    }
}
