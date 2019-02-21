using Xamarin.Essentials;

namespace SecuritySampleApp
{
    public class LaneModel
    {
        readonly string _isOpenKey;
        readonly string _ipAddressKey;
        readonly string _needsMaintenanceKey;

        public LaneModel(int id)
        {
            ID = id;

            _needsMaintenanceKey = $"{nameof(NeedsMaintenance)}{ID}";
            _isOpenKey = $"{nameof(IsOpen)}{ID}";
            _ipAddressKey = $"{nameof(IPAddress)}{ID}";
        }

        public int ID { get; }

        public bool IsOpen
        {
            get => Preferences.Get(_isOpenKey, false);
            set => Preferences.Set(_isOpenKey, value);
        }


        public bool NeedsMaintenance
        {
            get => Preferences.Get(_needsMaintenanceKey, false);
            set => Preferences.Set(_needsMaintenanceKey, value);
        }

        public string IPAddress
        {
            get => Preferences.Get(_ipAddressKey, string.Empty);
            set => Preferences.Set(_ipAddressKey, value);
        }
    }
}

