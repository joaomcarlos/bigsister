using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BigSister
{
    using System.Windows.Forms;

    public class SaveSettings
    {
        public string SavePath;

        public SaveSettings(string filename)
        {
            SavePath = filename;
        }


        public bool Exists()
        {
            return (File.Exists(SavePath) && Load().Count > 0);
        }

        public List<Settings> Load()
        {
            var sets = new List<Settings>();
            if (File.Exists(SavePath))
            {
                var read = new XmlSerializer(sets.GetType());
                TextReader r = new StreamReader(SavePath);
                sets = (List<Settings>) read.Deserialize(r);
                foreach (Settings set in sets)
                {
                    set.LightMode = true;
                }
                r.Close();
            }
            return sets;
        }

        public void Save(List<Settings> sets)
        {
            /*
            foreach (var _sets in sets)
            {
                // fix old settings
                string wowpath = _sets.WoWPath;
                while (wowpath.Contains("WoW.exe"))
                    wowpath = wowpath.Replace("\\WoW.exe", "");
                while (wowpath.Contains("Wow.exe"))
                    wowpath = wowpath.Replace("\\Wow.exe", "");
                while (wowpath.Contains("wow.exe"))
                    wowpath = wowpath.Replace("\\wow.exe", "");
                _sets.WoWPath = wowpath;
            }*/
            if (sets == null)
            {
                MessageBox.Show("Error trying to save settings: null settings");
                return;
            }
            var writer = new XmlSerializer(sets.GetType());
            var file = new StreamWriter(SavePath);
            writer.Serialize(file, sets);
            file.Close();
        }
    }
}