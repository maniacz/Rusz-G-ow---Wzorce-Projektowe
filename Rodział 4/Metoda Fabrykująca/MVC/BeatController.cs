using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC
{
    public class BeatController : IController
    {
        IBeatModel model;
        DJView djView;
        DJSteering djSteering;

        public void Start()
        {
            model.Start();
            djSteering.DeactivateStartMenuItem();
            djSteering.ActivateStopMenuItem();
        }

        public void Stop()
        {
            model.Stop();
            djSteering.DeactivateStopMenuItem();
            djSteering.ActivateStartMenuItem();
        }

        public void IncreaseBPM()
        {
            int bpm = model.GetBPM();
            model.SetBPM(++bpm);
        }

        public void DecreaseBPM()
        {
            int bpm = model.GetBPM();
            model.SetBPM(--bpm);
        }

        public void SetBPM(int bpm)
        {
            model.SetBPM(bpm);
        }
    }
}
