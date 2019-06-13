using Xamarin.Forms;

namespace SecuritySampleApp
{
    class LanesPage : BaseContentPage
    {
        #region Constant Fields
        readonly ListView _listView;
        #endregion

        #region Constructors
        public LanesPage(string pageTitle)
        {
            BindingContext = new LanesViewModel();

            _listView = new ListView
            {
                RowHeight = 200,
                ItemTemplate = new DataTemplate(typeof(LanesViewCell)),
                IsPullToRefreshEnabled = true,
            };
            _listView.ItemTapped += OnListViewItemTapped;
            _listView.SetBinding(ListView.ItemsSourceProperty, nameof(LanesViewModel.LanesList));
            _listView.SetBinding(ListView.IsRefreshingProperty, nameof(LanesViewModel.IsRefreshing));
            _listView.SetBinding(ListView.RefreshCommandProperty, nameof(LanesViewModel.RefreshCommand));

            Title = $"Lanes {pageTitle}";

            NavigationPage.SetTitleIconImageSource(this, "Road_navigation");

            Content = _listView;
        }
        #endregion

        #region Methods
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _listView.BeginRefresh();
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView listView)
                listView.SelectedItem = null;

            if (e.Item is LaneModel laneModelTapped)
                await Navigation.PushAsync(new SettingsPage(laneModelTapped));
        }
        #endregion
    }
}

