﻿using System.Windows.Input;
using System.Threading.Tasks;

using AsyncAwaitBestPractices.MVVM;

namespace SecuritySampleApp
{
    class SettingsViewModel : BaseViewModel
    {
        const string _iconToggleDisabled = "Icon Toggle Disabled";
        const string _iconToggleEnabled = "Icon Toggle Enabled";
        const string _roadIconName = "Road";
        const string _aboutIconName = "About";
        readonly LaneModel _laneModel;

        bool _timerEnabled;
        string _imageCellIcon, _toggleButtonText = _iconToggleDisabled;
        ICommand? _iconToggleButtonCommand;

        public SettingsViewModel(LaneModel laneModelTapped)
        {
            _laneModel = laneModelTapped;

            _toggleButtonText = _iconToggleDisabled;
            _imageCellIcon = _aboutIconName;
        }

        public ICommand IconToggleButtonCommand => _iconToggleButtonCommand ??= new AsyncCommand(ExecuteIconToggleButtonCommand);

        public bool IsOpen
        {
            get => _laneModel.IsOpen;
            set => _laneModel.IsOpen = value;
        }

        public bool NeedsMaintenance
        {
            get => _laneModel.NeedsMaintenance;
            set => _laneModel.NeedsMaintenance = value;
        }

        public string IPAddress
        {
            get => _laneModel.IPAddress;
            set => _laneModel.IPAddress = value;
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

        async Task ToggleImage()
        {
            while (_timerEnabled)
            {
                if (ImageCellIcon is _aboutIconName)
                    ImageCellIcon = _roadIconName;
                else
                    ImageCellIcon = _aboutIconName;

                await Task.Delay(2000).ConfigureAwait(false);
            }
        }

        Task ExecuteIconToggleButtonCommand()
        {
            _timerEnabled = !_timerEnabled;

            if (_timerEnabled)
                ToggleButtonText = _iconToggleEnabled;
            else
                ToggleButtonText = _iconToggleDisabled;

            return ToggleImage();
        }
    }
}
