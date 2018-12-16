using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC
{
    class BeatModel : IBeatModel
    {
        Sequencer sequencer;
        List<IBeatObserver> beatObservers = new List<IBeatObserver>();
        List<IBPMObserver> beatObservers = new List<IBPMObserver>();
        int bpm = 90;

        public void Init()
        {
            ConfigureMidi();
            BuildPathAndBegin();
        }

        public void Start()
        {
            sequencer.Start();
            SetBPM(90);
        }

        public void Stop()
        {
            SetBPM(0);
            sequencer.Stop();
        }

        public void SetBPM(int bpm)
        {
            this.bpm = bpm;
            sequencer.SetTempoInBPM(GetBPM());
            NotifyBPMObservers();
        }


        public int GetBPM()
        {
            return bpm;
        }

        void BeatEvent()
        {
            NotifyBeatObservers();
        }

        #region Rejestrowanie i powiadamianie obserwatorów 
        public void RegisterObserver(IBeatObserver o)
        {
            throw new NotImplementedException();
        }

        public void DeregisterObserver(IBeatObserver o)
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IBPMObserver o)
        {
            throw new NotImplementedException();
        }

        public void DeregisterObserver(IBPMObserver o)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
