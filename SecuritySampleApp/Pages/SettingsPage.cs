using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;

namespace SecuritySampleApp
{
    class SettingsPage : BaseContentPage
    {
        public SettingsPage(LaneModel laneModelTapped)
        {
            BindingContext = new SettingsViewModel(laneModelTapped);

            IconImageSource = "cogwheel_navigation";

            Title = $"Lane {laneModelTapped.ID + 1} Settings";
            Content = new StackLayout
            {
                Children =
                {
                    new TableView
                    {
                        Intent = TableIntent.Settings,
                        Root = new TableRoot
                        {
                            new TableSection
                            {
                                new SwitchCell { Text = "Is Open" }
                                    .Bind(SwitchCell.OnProperty, nameof(SettingsViewModel.IsOpen)),
                                new SwitchCell { Text = "Needs Maintenance" }
                                    .Bind(SwitchCell.OnProperty, nameof(SettingsViewModel.NeedsMaintenance)),
                                new EntryCell { Label = "IP Address", HorizontalTextAlignment = TextAlignment.End }
                                    .Bind(EntryCell.TextProperty, nameof(SettingsViewModel.IPAddress)),
                                new ImageCell()
                                    .Bind(ImageCell.ImageSourceProperty, nameof(SettingsViewModel.ImageCellIcon))
                            }
                        }
                    },

                    new Button()
                        .Bind(Button.CommandProperty, nameof(SettingsViewModel.IconToggleButtonCommand))
                        .Bind(Button.TextProperty, nameof(SettingsViewModel.ToggleButtonText))

                }
            };
        }
    }
}

