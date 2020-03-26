namespace WoWLib
{
    public enum LocalPlayer
    {
        LocalPlayerName = 0x00C79D18, // 3.3.5 //0x00BB4428,            // 3.3.3
        //0x00C79D10
    }

    public enum Relogger
    {

        LastGlueScreen = 0x00B6A9E0,            // 3.3.5
        SelectCharacterIndex = 0xAC436C,//3.3.5 //0x00A9CB7C,      // 3.3.3
        IsLoadingOrConnecting = 0x00B6AA38,     // 3.3.5
        IsInGame = 0x00BD078A, // 3.3.5  0x00C4EB2A, // 3.3.3 right below GetZoneText more or less ^^
        //0xBEBA40
        NumAccountsPointer = 0x00BB43FC,        // 3.3.3
        NumAccountsOffset = 0x1188,             // 3.3.3
    }
  

    public enum WoWGlueScreen
    {
        None,
        Login,
        Realmwizard,
        Charcreate,
        Charselect
    }
}
