#region usings

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using WoWLib;

#endregion

namespace BigSister
{
    internal partial class BabySitter
    {



        #region helpers

        private AutomationElementCollection FindElementFromAutomationID(AutomationElement targetApp, string automationID)
        {
            return targetApp.FindAll(
                TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationID));
        }

        private bool checkRights()
        {
            bool isElevated = false;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            if (identity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return isElevated;
        }
        private void ChangeConfig2(string wowExe, string realmName, int charIndex ,string realmRegion)
        {
            Log("Alternative Renaming Method...");
            // WTF Pfad ermitteln
            string wtfpath = "";
            try
            {
                string[] pathsplit = wowExe.Split('\\');

                for (int i = 0; i < pathsplit.Length - 1; i++)
                    wtfpath += pathsplit[i] + "\\";
                wtfpath += "WTF\\Config.wtf";

                wtfpath = wowExe; // CHANGE THIS LATER HHHHHHHHHHHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            }
            catch
            {
                Log("no config wtf found");
            }
            try
            {
                StreamReader sr = new StreamReader(wtfpath, true);
                String configText = sr.ReadToEnd();
                String searchRealmNameText = "SET realmName ";
                String newConfigText = "";

                // Search for the realm name and replace with new one.
                if (configText.Contains(searchRealmNameText))
                {
                    // Then we need to change the realmName to the one we want.
                    // +1 for the " at the start.
                    int indexOfStartOfRealm = configText.IndexOf(searchRealmNameText) + searchRealmNameText.Length + 1;
                    // -1 for the " at the end
                    int indexOfEndOfRealm = configText.IndexOf('"', indexOfStartOfRealm);
                    newConfigText = configText.Substring(0, indexOfStartOfRealm);
                    newConfigText += realmName;
                    int charactersLeftToReadAfterRealm = configText.Length - indexOfEndOfRealm;
                    newConfigText += configText.Substring(indexOfEndOfRealm, charactersLeftToReadAfterRealm);
                }
                configText += "\nSET lastCharacterIndex \"" + Convert.ToString(Convert.ToInt32(charIndex) - 1) + "\"";
                newConfigText += "\nSET realmName \"" + realmName + "\"";
                newConfigText += "\nSET readTOS \"1\"";
                newConfigText += "\nSET readEULA \"1\"";
                newConfigText += "\nSET readScanning \"1\"";
                newConfigText += "\nSET readContest \"0\"";
                newConfigText += "\nSET AutoInteract \"1\"";
                newConfigText += "\nSET autoSelfCast \"1\"";

                configText += newConfigText;
                newConfigText = "";

                Log("pre-selecting Realm");
                // this.classlog.Items.Add("pre-selecting Realm");

                // Search for select character index and set new one
                //  if (configText.Contains(searchCharacterIndex))

                // {
                // Then we need to change the realmName to the one we want.
                // +1 for the " at the start.
                // int indexOfStartOfCharacterSelect = configText.IndexOf(searchCharacterIndex) + searchCharacterIndex.Length + 1;
                // -1 for the " at the end
                // int indexOfEndOfCharacterSelect = configText.IndexOf('"', indexOfStartOfCharacterSelect);
                // newConfigText = configText.Substring(0, indexOfStartOfCharacterSelect);
                //newConfigText += Convert.ToString(Convert.ToInt32(Sessions[SessionID].wowcharnr) - 1);
                //int charactersLeftToReadAfterCharacterSelect = configText.Length - indexOfEndOfCharacterSelect;
                //newConfigText += configText.Substring(indexOfEndOfCharacterSelect, charactersLeftToReadAfterCharacterSelect);
                //  }



                Log("pre-selecting wowchar");
                // this.classlog.Items.Add("pre-selecting Realm");

                sr.Close();


                StreamWriter sw = new StreamWriter(wtfpath, false);
                {
                    sw.Write(configText);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Output.LogToFile: " + ex.Message);
            }
        }
        private void ChangeConfig(string path, string realmName, string realmRegion)
        {
            if(!String.IsNullOrEmpty(path))
                if (!String.IsNullOrEmpty(realmName))
                    if (!String.IsNullOrEmpty(realmRegion))
                    {
                        Log("Updating Config.wtf file ...");
                        string realm1 = "SET realmName \"" + realmName + "\"";

                        string currentRealm = "";
                        string currentPortal = "";

                        string fullconfigfile = "";
                        StreamReader re = File.OpenText(path);
                        string input = null;
                        while ((input = re.ReadLine()) != null)
                        {
                            fullconfigfile += input + "\n";
                            if (input.Contains("realmName"))
                                currentRealm = input;
                            if (input.Contains("portal"))
                                currentPortal = input;
                        }
                        re.Close();

                        //MessageBox.Show("currentrealm: " + currentRealm + "replaced by: " + realm1);

                        string readTOS = "SET readTOS";
                        string readEULA = "SET readEULA";
                        string readScanning = "SET readScanning";
                        string readTermination = "SET readTerminationWithoutNotice";
                        string checkAddon = "SET checkAddonVersion";
                        string movie = "SET movie";
                        string portal = "SET portal";
                        string window = "SET gxWindow";

                        try
                        {
                            fullconfigfile = SafeReplace(fullconfigfile, currentRealm, realm1);
                            fullconfigfile = SafeReplace(fullconfigfile, currentPortal, portal + " \"" + realmRegion + "\"");
                            fullconfigfile = SafeReplace(fullconfigfile, To0(readTOS), To1(readTOS));
                            fullconfigfile = SafeReplace(fullconfigfile, To0(readEULA), To1(readEULA));
                            fullconfigfile = SafeReplace(fullconfigfile, To0(readScanning),To1( readScanning));
                            fullconfigfile = SafeReplace(fullconfigfile, To0(readTermination), To1(readTermination));
                            fullconfigfile = SafeReplace(fullconfigfile, To1(checkAddon), To0(checkAddon));
                            fullconfigfile = SafeReplace(fullconfigfile, To0(movie), To1(movie));
                            fullconfigfile = SafeReplace(fullconfigfile, To0(window), To1(window));
                           
                        }catch(Exception e)
                        {
                            Log("Error replacing lines in Config.wtf file, probably wrong language or values. Should be safe to ignore.");
                        }finally
                        {
                            bool canWrite = false;
                            FileStream fs = File.OpenWrite(path);
                            Log("Can I write to Config.wtf? " + fs.CanWrite);
                            canWrite = fs.CanWrite;
                            fs.Close();
                            if (canWrite)
                            {
                                // create a writer and open the file
                                StreamWriter tw = new StreamWriter(path);
                                tw.AutoFlush = true;
                                // write a line of text to the file
                                tw.Write(fullconfigfile);
                                // close the stream
                                tw.Close();
                                Log("Update to Config.wtf complete ...");
                            }
                            else
                                Log("I cant write to Config.wtf file :/");

                            ChangeConfig2(path,realmName,0,""); //force it!
                        }
                        return;
                    }
            Log("Path || RealmName || realmRegion was null or empty.");
        }
        private string To1(string key)
        {
            return key + " \"1\"";
        }
        private string To0(string key)
        {
            return key + " \"0\"";
        }
        private string SafeReplace(string source, string find, string text)
        {
            if (source.Contains(find))
            {
                source.Replace(find, text);
                Log("Replaced: '"+find+"' with '"+text+"'");
                //ReplaceInFile(Sets.WoWConfigPath,find,text);
            }
            else
                Log("Couldnt find: " + find + " so no replace was done to Config.wtf on that line");
            return source;
        }
        /// <summary>
        /// Replaces text in a file.
        /// </summary>
        /// <param name="filePath">Path of the text file.</param>
        /// <param name="searchText">Text to search for.</param>
        /// <param name="replaceText">Text to replace the search text.</param>
        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();
        }

        private string findNewestHBLog(string botPath)
        {
            string filePath = botPath.Substring(0, botPath.LastIndexOf("\\")) + "\\Logs\\";

            string correctFile = "";
            DirectoryInfo di = new DirectoryInfo(filePath);
            FileInfo[] rgFiles = di.GetFiles("*.txt");
            foreach (FileInfo fi in rgFiles)
            {
                if (string.IsNullOrEmpty(correctFile))
                {
                    correctFile = fi.FullName;
                    continue;
                }
                if (fi.LastWriteTime.CompareTo(File.GetLastWriteTime(correctFile)) > 0)
                    correctFile = fi.FullName;
            }

            return correctFile;
        }

        #endregion
    }
}