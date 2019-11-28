using Xamarin.Forms;

namespace SecuritySampleApp
{
    class LanesPage : BaseContentPage
    {
        public LanesPage(string pageTitle)
        {
            BindingContext = new LanesViewModel();

            var listView = new ListView
            {
                RowHeight = 200,
                ItemTemplate = new DataTemplate(typeof(LanesViewCell)),
                IsPullToRefreshEnabled = true,
            };
            listView.ItemTapped += OnListViewItemTapped;
            listView.SetBinding(ListView.ItemsSourceProperty, nameof(LanesViewModel.LanesCollection));
            listView.SetBinding(ListView.IsRefreshingProperty, nameof(LanesViewModel.IsRefreshing));
            listView.SetBinding(ListView.RefreshCommandProperty, nameof(LanesViewModel.RefreshCommand));

            Title = $"Lanes {pageTitle}";

            IconImageSource = "Road_navigation";

            Content = listView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var listView = (ListView)Content;
            listView.BeginRefresh();
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = (ListView)sender;
            listView.SelectedItem = null;

            var laneModelTapped = (LaneModel)e.Item;
            await Navigation.PushAsync(new SettingsPage(laneModelTapped));
        }
    }
}

