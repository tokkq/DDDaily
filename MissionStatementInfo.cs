using System.Collections.Generic;

namespace DailyProject
{
    public class MissionStatementInfo
    {
        public IList<string> MissionsToMe { get; set; } = new List<string>();
        public IList<string> MissionsToOpponent { get; set; } = new List<string>();
    }
}