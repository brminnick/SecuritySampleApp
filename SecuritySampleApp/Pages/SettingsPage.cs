using Xamarin.Forms;

namespace SecuritySampleApp
{
    class SettingsPage : BaseContentPage
    {
        public SettingsPage(LaneModel laneModelTapped)
        {
            BindingContext = new SettingsViewModel(laneModelTapped);

            var isOpenSwitch = new SwitchCell
            {
                Text = "Is Open"
            };
            isOpenSwitch.SetBinding(SwitchCell.OnProperty, nameof(SettingsViewModel.IsOpen));

            var needsMaintenanceSwitch = new SwitchCell
            {
                Text = "Needs Maintenance"
            };
            needsMaintenanceSwitch.SetBinding(SwitchCell.OnProperty, nameof(SettingsViewModel.NeedsMaintenance));

            var ipAddressText = new EntryCell
            {
                Label = "IP Address",
                HorizontalTextAlignment = TextAlignment.End
            };
            ipAddressText.SetBinding(EntryCell.TextProperty, nameof(SettingsViewModel.IPAddress));

            var imageCell = new ImageCell();
            imageCell.SetBinding(ImageCell.ImageSourceProperty, nameof(SettingsViewModel.ImageCellIcon));


            var iconToggleButton = new Button();
            iconToggleButton.SetBinding(Button.CommandProperty, nameof(SettingsViewModel.IconToggleButtonCommand));
            iconToggleButton.SetBinding(Button.TextProperty, nameof(SettingsViewModel.ToggleButtonText));

            var tableView = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot
                {
                    new TableSection{
                        isOpenSwitch,
                        needsMaintenanceSwitch,
                        ipAddressText,
                        imageCell
                    }
                }
            };

            var settingsStack = new StackLayout
            {
                Children ={
                    tableView,
                    iconToggleButton
                }
            };

            IconImageSource = "cogwheel_navigation";

            Title = $"Lane {laneModelTapped.ID + 1} Settings";
            Content = settingsStack;
        }
    }
}

