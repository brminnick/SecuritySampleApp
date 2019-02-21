using System;
using Xamarin.Forms;

namespace SecuritySampleApp
{
    public class LanesPage : BaseContentPage
    {
        #region Constant Fields
        readonly ListView _listView;
        readonly LanesViewModel _lanesViewModel = new LanesViewModel();
        #endregion

        #region Constructors
        public LanesPage(string pageTitle)
        {
            BindingContext = _lanesViewModel;

            _listView = new ListView
            {
                RowHeight = 200,
                ItemTemplate = new DataTemplate(typeof(LanesViewCell))
            };
            _listView.ItemTapped += OnListViewItemTapped;
            _listView.SetBinding(ListView.ItemsSourceProperty, nameof(LanesViewModel.LanesList));

            Title = $"Lanes {pageTitle}";

            NavigationPage.SetTitleIcon(this, "Road_navigation");

            Content = _listView;
        }
        #endregion

        #region Methods
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _lanesViewModel.RefreshCommand?.Execute(null);
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var laneTapped = (LaneModel)e.Item;
            var listView = sender as ListView;

            await Navigation.PushAsync(new SettingsPage(laneTapped));

            listView.SelectedItem = null;
        }
        #endregion
    }
}

