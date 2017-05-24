using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SecuritySampleApp
{
	public class LanesPage : ContentPage
	{
		readonly LanesViewModel _viewModel;
		readonly ListView _listView;

		public LanesPage(string pageTitle)
		{
			_viewModel = new LanesViewModel();
			BindingContext = _viewModel;

			_listView = new ListView
			{
				RowHeight = 200,
				ItemTemplate = new DataTemplate(typeof(LanesViewCell))
			};
			_listView.IsPullToRefreshEnabled = true;
			_listView.SetBinding(ListView.ItemsSourceProperty, nameof(_viewModel.LanesList));

			Title = $"Lanes {pageTitle}";

			NavigationPage.SetTitleIcon(this, "Road_navigation");

			Content = _listView;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			_listView.ItemTapped += OnListViewItemTapped;
			_listView.Refreshing += HandleRefreshing;

			RefreshListView();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			_listView.ItemTapped -= OnListViewItemTapped;
			_listView.Refreshing -= HandleRefreshing;
		}

		async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
		{
			var laneTapped = (LaneModel)e.Item;
			await Navigation.PushAsync(new SettingsPage(laneTapped));
		}

		void HandleRefreshing(object sender, EventArgs e)
		{
			RefreshListView();
			_listView.EndRefresh();
		}

		void RefreshListView()
		{
			_listView.ItemsSource = null;
			_listView.SetBinding(ListView.ItemsSourceProperty, "LanesList");
		}
	}
}

