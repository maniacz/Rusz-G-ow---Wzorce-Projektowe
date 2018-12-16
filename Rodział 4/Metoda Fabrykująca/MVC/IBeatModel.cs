using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC
{
    public interface IBeatModel
    {
        void Init();
        void Start();
        void Stop();
        void SetBPM();

        int GetBPM();
        void RegisterObserver(IBeatObserver o);
        void DeregisterObserver(IBeatObserver o);
        void RegisterObserver(IBPMObserver o);
        void DeregisterObserver(IBPMObserver o);
    }
}
