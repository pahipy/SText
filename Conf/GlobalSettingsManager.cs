﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using Newtonsoft.Json.Linq;
using Newtonsoft;

namespace SText.Conf
{
    public class GlobalSettingsManager
    {

        public GlobalSettingsManager(string settingspath, SettingsTemplate settings)
        {
            Settings = settings;

            if (settingspath != null)
            {
                defaultSettingPath = settingspath;
            }
            else
            {
                defaultSettingPath = "config.json";
            }

            string dirpath = DirectoryConf;


            currentSettingPath = $"{dirpath}/{defaultSettingPath}";

            try
            {
                if (File.Exists(currentSettingPath))
                {
                    LoadConfig();
                }
                else
                {
                    File.Create(currentSettingPath).Close();
                    SaveConfig();
                }
            }
            catch (Exception ex)
            {
                //Dialogs.DialogManager.ShowWarningDialogWithText(ex.Message);
            }

        }

        private const string GENT = "Generated by SText; do not edit";

        private string defaultSettingPath;
        public string DefaultSettingPath { get => defaultSettingPath; }

        public static string DirectoryConf
        {
            get
            {
                string dirpath = $"/tmp/{ProgramSets.DirectoryConfName}";

                try
                {
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        string username = Environment.UserName;
                        dirpath = $@"C:\Users\{username}\{ProgramSets.DirectoryConfName}";
                        if (!Directory.Exists(dirpath))
                            Directory.CreateDirectory(dirpath);
                    }
                }
                catch (Exception ex)
                {
                    //Dialogs.DialogManager.ShowWarningDialogWithText(ex.Message);
                }
                

                return dirpath;
            }
        }

        public SettingsTemplate Settings;

        private string currentSettingPath;

        private void LoadConfig()
        {
            StreamReader streamReader = new StreamReader(currentSettingPath);
            string json = streamReader.ReadToEnd();
            streamReader.Close();
            
            JObject obj = (JObject)JsonConvert.DeserializeObject(json);

            Settings.CurrentTheme = (int)obj["SText"]["Theme"] == 0 ? Theme.Default :
                (int)obj["SText"]["Theme"] == 1 ? Theme.Dark : (int)obj["SText"]["Theme"] == 2 ? Theme.Blue : Theme.ClassicalDark;

            Settings.ShowStatusBar = (bool)obj["SText"]["ShowStatusBar"];
            Settings.WordWrap = (bool)obj["SText"]["WordWrap"];
            Settings.FontSize = (float)obj["SText"]["FontSize"];
            Settings.FontFamily = (string)obj["SText"]["FontFamily"];
            Settings.FontStyle = (int)obj["SText"]["FontStyle"];
            Settings.WindowState = (int)obj["SText"]["WindowState"];
            Settings.WindowPosition = new Point(0, 0);
            Settings.WindowPosition.X = (int)obj["SText"]["WindowPosition"][0];
            Settings.WindowPosition.Y = (int)obj["SText"]["WindowPosition"][1];
            Settings.WindowSize = new Size(0, 0);
            Settings.WindowSize.Width = (int)obj["SText"]["WindowSize"][0];
            Settings.WindowSize.Height = (int)obj["SText"]["WindowSize"][1];

 
        }

        public void SaveConfig()
        {
            int[] WindowPosition = new int[]
                {
                    Settings.WindowPosition.X,
                    Settings.WindowPosition.Y
                };

            int[] WindowSize = new int[]
            {
                    Settings.WindowSize.Width,
                    Settings.WindowSize.Height
            };
            
            JObject obj = new JObject(new JProperty("SText", new JObject(
                new JProperty("_generated", GENT),
                new JProperty("Theme", (int)Settings.CurrentTheme),
                new JProperty("ShowStatusBar", Settings.ShowStatusBar),
                new JProperty("WordWrap", Settings.WordWrap),
                new JProperty("FontSize", Settings.FontSize),
                new JProperty("FontFamily", Settings.FontFamily),
                new JProperty("FontStyle", Settings.FontStyle),
                new JProperty("WindowState", Settings.WindowState),
                new JProperty("WindowPosition", new JArray(WindowPosition)),
                new JProperty("WindowSize", new JArray(WindowSize)))));

            string json = obj.ToString();

            try
            {
                StreamWriter sw = new StreamWriter(currentSettingPath);
                sw.Write(json);
                sw.Close();
            }
            catch { }
            

        }

    }

    public struct SettingsTemplate
    {
        public Theme CurrentTheme;
        public bool ShowStatusBar;
        public bool WordWrap;
        public float FontSize;
        public string FontFamily;
        public int FontStyle;
        public int WindowState;
        public Point WindowPosition;
        public Size WindowSize;
    };

    
}
