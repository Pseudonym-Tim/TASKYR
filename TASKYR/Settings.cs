using System;
using System.Collections.Generic;

namespace TASKYR
{
    public class Settings
    {
        public Dictionary<DayOfWeek, (TimeSpan, TimeSpan)?> Schedule { get; set; }
        public string DefaultBrowser { get; set; }
        public bool UseSchedule { get; set; }
        public List<string> BlockedPrograms { get; set; }
        public List<string> BlockedWebsites { get; set; }
    }
}
