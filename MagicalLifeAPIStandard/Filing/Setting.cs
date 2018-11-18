using Newtonsoft.Json;
using System.IO;

namespace MagicalLifeAPI.Filing
{
    /// <summary>
    /// Handles various things for a settings file.
    /// </summary>
    public class Setting<T>
    {
        /// <summary>
        /// The settings this class is wrapped around.
        /// </summary>
        public T Settings { get; set; }

        /// <summary>
        /// The path to the settings file.
        /// </summary>
        private readonly string FilePath;

        /// <summary>
        /// If the settings file is found at the specified path, then that shall be loaded and used.
        /// Otherwise, the new settings file instance shall be used.
        /// </summary>
        /// <param name="filePath">The file path where the settings should be stored.</param>
        /// <param name="settings">An instance of a brand new settings class.</param>
        public Setting(string filePath, T settings)
        {
            this.FilePath = filePath;

            if (File.Exists(filePath))
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    if (file != null)
                    {
                        this.Settings = JsonConvert.DeserializeObject<T>(file.ReadToEnd());
                    }
                }
            }
            else
            {
                this.Settings = settings;

                using (StreamWriter wr = File.CreateText(filePath))
                {
                    wr.Write(JsonConvert.SerializeObject(settings, Formatting.Indented));
                }
            }
        }

        /// <summary>
        /// Refreshes the settings to the state in file.
        /// Doesn't refresh if the data is inaccessible for some reason.
        /// </summary>
        public void Refresh()
        {
            using (StreamReader file = File.OpenText(this.FilePath))
            {
                if (file != null)
                {
                    this.Settings = JsonConvert.DeserializeObject<T>(file.ReadToEnd());
                }
            }
        }

        /// <summary>
        /// Saves the in memory version of settings to disk, completely writing over the disk version.
        /// </summary>
        public void Save()
        {
            File.Delete(this.FilePath);
            using (StreamWriter wr = File.CreateText(this.FilePath))
            {
                wr.Write(JsonConvert.SerializeObject(this.Settings, Formatting.Indented));
            }
        }
    }
}