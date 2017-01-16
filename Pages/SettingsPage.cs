using Xamarin.Forms;

namespace SecuritySampleApp
{
	public class SettingsPage : ContentPage
	{
		public SettingsPage(LaneModel laneModelTapped)
		{
			var viewModel = new SettingsViewModel(laneModelTapped);
			BindingContext = viewModel;

			#region create the IsOpen Switch
			var isOpenSwitch = new SwitchCell
			{
				Text = "Is Open"
			};
			isOpenSwitch.SetBinding<SettingsViewModel>(SwitchCell.OnProperty, vm => vm.IsOpen);
			#endregion

			#region Create the Needs Maintenance Switch
			var needsMaintenanceSwitch = new SwitchCell
			{
				Text = "Needs Maintenance"
			};
			needsMaintenanceSwitch.SetBinding<SettingsViewModel>(SwitchCell.OnProperty, vm => vm.NeedsMaintenance);
			#endregion

			#region create the IP Address Entry
			var ipAddressText = new EntryCell
			{
				Label = "IP Address",
				HorizontalTextAlignment = TextAlignment.End
			};
			ipAddressText.SetBinding<SettingsViewModel>(EntryCell.TextProperty, vm => vm.IPAddress);
			#endregion

			#region Create Image Cell
			var imageCell = new ImageCell();
			imageCell.SetBinding<SettingsViewModel>(ImageCell.ImageSourceProperty, vm => vm.ImageCellIcon);
			#endregion

			#region Create the Icon Toggle Button
			var iconToggleButton = new Button();
			iconToggleButton.SetBinding<SettingsViewModel>(Button.CommandProperty, vm => vm.IconToggleButtonTapped);
			iconToggleButton.SetBinding<SettingsViewModel>(Button.TextProperty, vm => vm.ToggleButtonText);
			#endregion

			#region create the TableView
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
			#endregion

			#region Create StackLayout to Include a Button
			var settingsStack = new StackLayout
			{
				Children ={
					tableView,
					iconToggleButton
				}
			};
			#endregion

			NavigationPage.SetTitleIcon(this, "cogwheel_navigation");

			Title = $"Lane {laneModelTapped.ID + 1} Settings";
			Content = settingsStack;
		}
	}
}

