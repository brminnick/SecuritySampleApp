using Xamarin.Forms;

namespace SecuritySampleApp
{
	public class SettingsPage : BaseContentPage
    {
		public SettingsPage(LaneModel laneModelTapped)
		{
			var viewModel = new SettingsViewModel(laneModelTapped);
			BindingContext = viewModel;

			var isOpenSwitch = new SwitchCell
			{
				Text = "Is Open"
			};
			isOpenSwitch.SetBinding(SwitchCell.OnProperty, nameof(viewModel.IsOpen));

			var needsMaintenanceSwitch = new SwitchCell
			{
				Text = "Needs Maintenance"
			};
			needsMaintenanceSwitch.SetBinding(SwitchCell.OnProperty, nameof(viewModel.NeedsMaintenance));

			var ipAddressText = new EntryCell
			{
				Label = "IP Address",
				HorizontalTextAlignment = TextAlignment.End
			};
			ipAddressText.SetBinding(EntryCell.TextProperty, nameof(viewModel.IPAddress));

			var imageCell = new ImageCell();
			imageCell.SetBinding(ImageCell.ImageSourceProperty, nameof(viewModel.ImageCellIcon));

		
			var iconToggleButton = new Button();
			iconToggleButton.SetBinding(Button.CommandProperty, nameof(viewModel.IconToggleButtonCommand));
			iconToggleButton.SetBinding(Button.TextProperty, nameof(viewModel.ToggleButtonText));

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

			NavigationPage.SetTitleIcon(this, "cogwheel_navigation");

			Title = $"Lane {laneModelTapped.ID + 1} Settings";
			Content = settingsStack;
		}
	}
}

