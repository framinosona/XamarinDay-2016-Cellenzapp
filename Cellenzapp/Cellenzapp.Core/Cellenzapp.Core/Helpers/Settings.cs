// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Cellenzapp.Core.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings {
            get {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string TwitterSynchroKey = "twitter_synchro";
        private static readonly bool TwitterSynchroDefault = false;

        #endregion


        public static bool TwitterSynchro {
            get { return AppSettings.GetValueOrDefault<bool>(TwitterSynchroKey, TwitterSynchroDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(TwitterSynchroKey, value); }
        }


    }
}