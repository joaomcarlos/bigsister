namespace BigSister
{
    public class Settings
    {
        #region BotTypeEnum enum

        public enum BotTypeEnum
        {
            GatherBuddy,
            HonnorBuddySmall,
            HonnorBuddyBig,
            HonnorBuddy2
        }

        #endregion

        public string BotName;
        public string BotPath;
        public BotTypeEnum BotType;
        public int WoWAccountCharNumber;
        public bool WoWAccountIsMulti;
        public int WoWbNetIndex;
        public string WoWAccountName;
        public string WoWAccountPass;
        public string WoWName;
        public string WoWPath;
        public string Alias;
        public string RealmName;
        public string RealmRegion;
        public string WoWConfigPath;
        public double SleepMultiplier;
        public bool LightMode;


        public void SetSettings(Settings sets)
        {
            this.BotName = sets.BotName;
            this.BotPath = sets.BotPath;
            this.BotType = sets.BotType;
            this.WoWAccountCharNumber = sets.WoWAccountCharNumber;
            this.WoWAccountIsMulti = sets.WoWAccountIsMulti;
            this.WoWAccountName = sets.WoWAccountName;
            this.WoWAccountPass = sets.WoWAccountPass;
            this.WoWName = sets.WoWName;
            this.WoWPath = sets.WoWPath;
            this.WoWbNetIndex = sets.WoWbNetIndex;
            this.Alias = sets.Alias;
            this.RealmName = sets.RealmName;

            this.RealmRegion = sets.RealmRegion;
            this.WoWConfigPath = sets.WoWConfigPath;
            this.SleepMultiplier = sets.SleepMultiplier;
            this.LightMode = sets.LightMode;
        }
    }
}