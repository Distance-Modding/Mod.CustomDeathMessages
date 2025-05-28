using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JsonFx.Json;
using JsonFx.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CustomDeathMessages
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public sealed class Mod : BaseUnityPlugin
    {
        //Mod Details
        private const string modGUID = "Distance.CustomDeathMessages";
        private const string modName = "Custom Death Messages";
        private const string modVersion = "1.0.1";

        //Config Entry Strings

        //Config Entries

        //Public Varibles
        public Dictionary<string, string[]> MessagesDictionary = new Dictionary<string, string[]>();

        //Other
        private static readonly Harmony harmony = new Harmony(modGUID);
        public static ManualLogSource Log = new ManualLogSource(modName);
        public static Mod Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Log = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            Logger.LogInfo("Thanks for using Custom Death Messages");

            LoadMessages();

            //Apply Patches
            Logger.LogInfo("Loading...");
            harmony.PatchAll();
            Logger.LogInfo("Loaded!");
        }

        private void SaveMessages()
        {
            string fileName = "CustomDeathMessages.json";
            string rootDirectory = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            DataWriterSettings st = new DataWriterSettings { PrettyPrint = true };
            JsonWriter writer = new JsonWriter(st);

            try
            {
                using (var sw = new StreamWriter(Path.Combine(rootDirectory, fileName), false))
                {
                    sw.WriteLine(writer.Write(MessagesDictionary));
                }
            }
            catch (Exception e)
            {
                Log.LogWarning(e);
            }
        }

        private void LoadMessages()
        {
            string RootDirectory = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            string filePath = Path.Combine(RootDirectory, "CustomDeathMessages.json");

            if (File.Exists(filePath))
            {
                try
                {
                    using (var sr = new StreamReader(filePath))
                    {
                        string json = sr.ReadToEnd();
                        JsonReader reader = new JsonReader();

                        Dictionary<string, string[]> messageDictionary = reader.Read<Dictionary<string, string[]>>(json);

                        MessagesDictionary = messageDictionary;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogWarning("Failed to load custom death messages. Using Defaults");
                    Log.LogWarning(ex);
                    MessagesDictionary.Clear();
                    AddDefaultsToDicationary();
                }
            }
            else
            {
                Log.LogWarning("CustomDeathMessages.json doesn't exist. Using Defaults, generating a new file");
                AddDefaultsToDicationary();
                SaveMessages();
            }
        }

        private void AddDefaultsToDicationary()
        {
            string[] KillGrid = new string[]
                            {
                                "The laser grid was not cool with {0}",
                                "{0} have touched the forbiden grid"
                            };
            MessagesDictionary.Add("KillGrid", KillGrid);

            string[] SelfTermination = new string[]
                            {
                                "{0} pressed the reset button",
                                "{0} commited sudoku"
                            };
            MessagesDictionary.Add("SelfTermination", SelfTermination);

            string[] LaserOverheated = new string[]
                            {
                                "{0} don't know how to drive without wheels",
                                "{0} was too hot"
                            };
            MessagesDictionary.Add("LaserOverheated", LaserOverheated);

            string[] Impact = new string[]
                            {
                                "{0} kissed a wall",
                                "The ground facepalmed {0}"
                            };
            MessagesDictionary.Add("Impact", Impact);

            string[] Overheated = new string[]
                            {
                                "{0} needs to stop boosting sometimes"
                            };
            MessagesDictionary.Add("Overheated", Overheated);

            string[] AntiTunnelSquish = new string[]
                            {
                                "{0} got unitied"
                            };
            MessagesDictionary.Add("AntiTunnelSquish", AntiTunnelSquish);

            string[] StuntCollect = new string[]
                            {
                                "{0} looted a x{1} multiplier!"
                            };
            MessagesDictionary.Add("StuntCollect", StuntCollect);

            string[] KickNoLevel = new string[]
                            {
                                "{0} is too poor to have this level",
                                "[FF0000]{0} is sad because he can't load the level[-]"
                            };
            MessagesDictionary.Add("KickNoLevel", KickNoLevel);

            string[] Finished = new string[]
                            {
                                "[FFFFFF]{0}[-] [00FF00]f[-][00FFFF]i[-][0000FF]n[-][FF00FF]i[-][FF0000]s[-][FFFF00]h[-][00FF00]e[-][00FFFF]d[-]"
                            };
            MessagesDictionary.Add("Finished", Finished);

            string[] NotReady = new string[]
                            {
                                "{0} is a little busy, try again later"
                            };
            MessagesDictionary.Add("NotReady", NotReady);

            string[] Spectate = new string[]
                            {
                                "[-]This map is too hard, {0} gave up"
                            };
            MessagesDictionary.Add("Spectate", Spectate);

            string[] TagPointsLead = new string[]
                            {
                                "[FFFFFF]{0}[-] is [00FF00]f[-][00FFFF]a[-][0000FF]b[-][FF00FF]u[-][FF0000]l[-][FFFF00]o[-][00FF00]u[-][00FFFF]s[-]!"
                            };
            MessagesDictionary.Add("TagPointsLead", TagPointsLead);
        }
    }
}
