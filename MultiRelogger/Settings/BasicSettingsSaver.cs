using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BigSister
{
    using System.Windows.Forms;

    internal class BasicSettingsSaver
    {
        public string SavePath;

        public BasicSettingsSaver(string filename)
        {
            SavePath = filename + "\\basicSettings.BSC";
        }


        public bool Exists()
        {
            return (File.Exists(SavePath));
        }

        public BasicSettings Load()
        {
            var sets = new BasicSettings();
            if (File.Exists(SavePath))
            {
                var read = new XmlSerializer(sets.GetType());
                TextReader r = new StreamReader(SavePath);
                sets = (BasicSettings)read.Deserialize(r);
                r.Close();
            }
            return sets;
        }

        public void Save(BasicSettings sets)
        {
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