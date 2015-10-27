using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WinFwk.UITools.Settings
{
    public static class UISettingsMgr<T> where T : UISettings, new()
    {
        private static XmlSerializer xml;

        public static void Init(string applicationName)
        {
            List<Type> types = WinFwkHelper.GetDerivedTypes(typeof (UISettings));
            xml = new XmlSerializer(typeof (T), types.ToArray());
            UISettings.InitSettings(Load(applicationName));
        }
        public static T Load(string applicationName)
        {
            string configPath = GetConfigPath(applicationName);
            if (!File.Exists(configPath))
            {
                return new T();
            }
            FileInfo fi = new FileInfo(configPath);
            if (fi.Length == 0)
            {
                return new T();
            }
            using (var reader = new StreamReader(configPath))
            {
                var configObj = xml.Deserialize(reader);
                var config = configObj as T;
                return config;
            }
        }

        public static void Save(string applicationName, T uiSettings)
        {
            string configPath = GetConfigPath(applicationName);
            var dir = Path.GetDirectoryName(configPath);
            if (dir != null && ! Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (var reader = new StreamWriter(configPath))
            {
                xml.Serialize(reader, uiSettings);
            }
        }

        private static string GetConfigPath(string applicationName)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var configPath = Path.Combine(appDataPath, applicationName);
            configPath = Path.Combine(configPath, applicationName);
            configPath = Path.ChangeExtension(configPath, "config");
            return configPath;
        }
    }
}