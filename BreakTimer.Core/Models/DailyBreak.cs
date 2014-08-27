using System;

namespace BreakTimer.Core.Models
{
    public enum Reason
    {
        Coffee,
        Stretch,
        Snack
    };

    public class DailyBreak
    {
        public Reason Reason { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        public bool Enabled { get; set; }
    }
}
