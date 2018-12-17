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
    public partial class DJSteering : Form, IBeatObserver, IBPMObserver
    {
        IBeatModel model;
        IController controller;

        public DJSteering(IBeatModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;
            model.RegisterObserver((IBeatObserver)this);
            model.RegisterObserver((IBPMObserver)this);
        }

        public DJSteering()
        {
            InitializeComponent();
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

        private void btnSetBPM_Click(object sender, EventArgs e)
        {
            int bpmValue;
            if (Int32.TryParse(tbxBPM.Text, out bpmValue))
                controller.SetBPM(bpmValue);
            else
                MessageBox.Show("Nieprawidłowa wartość BPM");
        }

        private void btnIncreaseBPM_Click(object sender, EventArgs e)
        {
            controller.IncreaseBPM();
        }

        private void btnDecreaseBPM_Click(object sender, EventArgs e)
        {
            controller.DecreaseBPM();
        }
    }
}
