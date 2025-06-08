using System.Collections.Generic;

namespace IntervalTimerApp.Models
{
    public class TimerTemplate
    {
        public string Name { get; set; } = string.Empty;
        public List<TimerInterval> Intervals { get; set; } = new();
        public int Repetitions { get; set; }
    }
}
