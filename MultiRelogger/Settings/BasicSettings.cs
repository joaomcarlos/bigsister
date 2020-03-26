using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BigSister
{
    public class BasicSettings
    {
        public string LastUsedProfile;
        public bool AutoRun;
        public bool TopMost;
        public bool CheckForWarden;

        public bool StopIfNoInternetConn;
        public int RestartIfNoInternetConnAfter = 5;

        public bool HasStopCondition;
        public int StopAfter;
        public eStopCondition StopCondition = eStopCondition.Nothing;

        public enum eStopCondition
        {
            Nothing,
            Sleep,
            Shutdown
        }


        // Screen options
        public int WowWindowWidth;
        public int WowWindowHeight;
        public int WowWindowSpacingWidth;
        public int WowWindowSpacingHeight;
        public int WowWindowGridColumns;
        public int WowWindowGridRows;
        public int WowFanOutWidth;
        public int WowFanOutHeight;
        public int WowWindowScreenNumber;
        public int WowWindowGridCountPerScreen;
        public int WowWindowScreenOffset;

        public bool WowWindowAutoArrange;
        public bool WowWindowArrangeWowWindows;
        public bool WowWindowArrangeBotWindows;
    }
}