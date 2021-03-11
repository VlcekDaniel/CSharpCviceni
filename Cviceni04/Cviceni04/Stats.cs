using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni04
{
    class Stats
    {
        public int Correct { get; private set; }
        public int Missed { get;private set; }
        public int Accurancy { get;private set; }

        public event UpdatedStatsEventHandler UpdatedStats;

        public delegate void UpdatedStatsEventHandler(object sender, EventArgs e);
        
        private void OnUpdatedStats()
        {
            UpdatedStatsEventHandler handler = UpdatedStats;
            if (handler != null)
                handler(this, new EventArgs());
        }

        public void Update(bool correctKey) {            
            if (correctKey)
            {
                Correct++;
            }
            else {
                Missed++;
            }
            Accurancy = Correct*100 / (Correct + Missed);
            OnUpdatedStats();
        }
    }
}
