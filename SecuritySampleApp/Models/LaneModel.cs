using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SecuritySampleApp
{
    public class LaneModel
    {
        string _isOpenSettingsKey;
        string _ipAddressSettingsKey;
        string _needsMaintenanceSettingsKey;

        public LaneModel(int id)
        {
            ID = id;

            _needsMaintenanceSettingsKey = $"{SettingsConstants.NeedsMaintenanceKey}{ID}";
            _isOpenSettingsKey = $"{SettingsConstants.IsOpenKey}{ID}";
            _ipAddressSettingsKey = $"{SettingsConstants.IPAddressKey}{ID}";
        }

        public int ID { get; }

        public bool IsOpen
        {
            get => AppSettings.GetValueOrDefault(_isOpenSettingsKey, SettingsConstants.DefaultBool);
            set => AppSettings.AddOrUpdateValue(_isOpenSettingsKey, value);
        }


        public bool NeedsMaintenance
        {
            get => AppSettings.GetValueOrDefault(_needsMaintenanceSettingsKey, SettingsConstants.DefaultBool);
            set => AppSettings.AddOrUpdateValue(_needsMaintenanceSettingsKey, value);
        }

        public string IPAddress
        {
            get => AppSettings.GetValueOrDefault(_ipAddressSettingsKey, SettingsConstants.DefaultString);
            set => AppSettings.AddOrUpdateValue(_ipAddressSettingsKey, value);
        }

        static ISettings AppSettings => CrossSettings.Current;
    }
}

