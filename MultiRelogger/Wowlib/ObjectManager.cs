using System.Diagnostics;
using System.Linq;
using Magic;

namespace WoWLib
{
    using System;

    public class ObjectManager
    {
        internal BlackMagic Memory { get; set; }
        internal Pulsator Pulsator { get; set; }
        public Process Process { get; private set; }

        private ObjectManager(BlackMagic memory)
        {
            Memory = memory;
            Pulsator = new Pulsator();
            Process = Process.GetProcesses().Where(p => p.Id == Memory.ProcessId).FirstOrDefault();
            Process.Exited += Process_Exited;
        }

        void Process_Exited(object sender, System.EventArgs e)
        {
            if (OnProcessExited != null)
                OnProcessExited();
        }

        public ObjectManager(int pid) : this(new BlackMagic(pid))
        {
        }


        public delegate void ProcessExitedDelegate();
        public event ProcessExitedDelegate OnProcessExited;

        /// <summary>
        /// Returns a boolean indicating if you are in the game
        /// </summary>
        public bool IsInGame { get { return Memory.Read<bool>((uint)Relogger.IsInGame); } }
        
        /// <summary>
        /// Returns a string with the name of the local player
        /// </summary>
        public string LocalPlayerName { get { return Memory.Read<string>((uint) LocalPlayer.LocalPlayerName); } }
        
        /// <summary>
        /// Returns a integer based on the selected character at the WoWGlueScreen.Charselect screen
        /// </summary>
        public int SelectedCharacterIndex { get { return Memory.Read<int>((uint) Relogger.SelectCharacterIndex); } }
        
        /// <summary>
        /// Returns true if you are waiting in a queue for a realm or connecting
        /// </summary>
        public bool IsLoadingOrConnecting { get { return Memory.Read<bool>((uint) Relogger.IsLoadingOrConnecting); } }
        
        /// <summary>
        /// Returns the last visited gluescreen if you are ingame it will return WoWGlueScreen.CharSelect
        /// </summary>
        public WoWGlueScreen LastGlueScreen
        {
            get
            {
                var val = CurrentGameState;//Memory.Read<string>((uint) Relogger.LastGlueScreen);

                switch (val.ToLower())
                {
                    case "login":
                        return WoWGlueScreen.Login; 
                    case "charcreate":
                        return WoWGlueScreen.Charcreate;
                    case "charselect":
                        return WoWGlueScreen.Charselect;
                    case "realmwizard":
                        return WoWGlueScreen.Realmwizard;
                    
                    default:
                        return WoWGlueScreen.None;
                }
            }
        }
        public string CurrentGameState
        {
            get
            {
                string state = Memory.ReadASCIIString((uint) Relogger.LastGlueScreen, 100);
                return state;
            }
        }


        /// <summary>
        /// Returns a boolean indicating if you are at the Charcreate glue
        /// </summary>
        public bool IsAtCharcreate { get { return LastGlueScreen == WoWGlueScreen.Charcreate; } }

        /// <summary>
        /// Returns a boolean indicating if you are at the Charselect glue
        /// </summary>
        public bool IsAtCharselect { get { return LastGlueScreen == WoWGlueScreen.Charselect; } }

        /// <summary>
        /// Returns a boolean indicating if you are at the Login glue
        /// </summary>
        public bool IsAtLoginScreen { get { return LastGlueScreen == WoWGlueScreen.Login; } }
        
        /// <summary>
        /// Returns a boolean indicating if you are at the Realmwizard glue
        /// </summary>
        public bool IsAtRealmWizard { get { return LastGlueScreen == WoWGlueScreen.Realmwizard; } }
    }
}