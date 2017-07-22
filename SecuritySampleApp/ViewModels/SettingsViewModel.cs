using System.Windows.Input;
using System.Threading.Tasks;

using Xamarin.Forms;
using System;

namespace SecuritySampleApp
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Constant Fields
        const string _iconToggleDisabled = "Icon Toggle Disabled";
        const string _iconToggleEnabled = "Icon Toggle Enabled";
        const string _roadIconName = "Road";
        const string _aboutIconName = "About";
        #endregion

        #region Fields
        bool _timerEnabled;
        string _imageCellIcon, _toggleButtonText = _iconToggleDisabled;
        LaneModel laneModel;
        ICommand _iconToggleButtonCommand;
        #endregion

        #region Constructors
        public SettingsViewModel(LaneModel laneModelTapped)
        {
            laneModel = laneModelTapped;

            _toggleButtonText = _iconToggleDisabled;
            _imageCellIcon = _aboutIconName;
        }
        #endregion

        #region Properties
        public ICommand IconToggleButtonCommand => _iconToggleButtonCommand ??
            (_iconToggleButtonCommand = new Command(async () => await ExecuteIconToggleButtonCommand()));

        public bool IsOpen
        {
            get => laneModel.IsOpen;
            set => laneModel.IsOpen = value;
        }

        public bool NeedsMaintenance
        {
            get => laneModel.NeedsMaintenance;
            set => laneModel.NeedsMaintenance = value;
        }

        public string IPAddress
        {
            get => laneModel.IPAddress;
            set => laneModel.IPAddress = value;
        }

        public string ImageCellIcon
        {
            get => _imageCellIcon;
            set => SetProperty(ref _imageCellIcon, value);
        }

        public string ToggleButtonText
        {
            get => _toggleButtonText;
            set => SetProperty(ref _toggleButtonText, value);
        }
        #endregion

        #region Methods
        async Task ToggleImage()
        {
            while (_timerEnabled)
            {
                if (ImageCellIcon == _aboutIconName)
                    ImageCellIcon = _roadIconName;
                else
                    ImageCellIcon = _aboutIconName;
                await Task.Delay(2000);
            }
        }

        async Task ExecuteIconToggleButtonCommand()
        {
            _timerEnabled = !_timerEnabled;

            if (_timerEnabled)
                ToggleButtonText = _iconToggleEnabled;
            else
                ToggleButtonText = _iconToggleDisabled;

            await ToggleImage();
        }
        #endregion
    }
}
