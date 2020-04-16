using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SecuritySampleApp
{
    class LanesPage : BaseContentPage
    {
        public LanesPage(string pageTitle)
        {
            BindingContext = new LanesViewModel();

            var collectionView = new CollectionView
            {
                ItemTemplate = new LanesDataTemplate(),
                SelectionMode= SelectionMode.Single,
            };
            collectionView.SelectionChanged += HandleSelectionChanged;
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(LanesViewModel.LanesCollection));

            var refreshView = new RefreshView
            {
                Content = collectionView
            };
            refreshView.SetBinding(RefreshView.CommandProperty, nameof(LanesViewModel.RefreshCommand));
            refreshView.SetBinding(RefreshView.IsRefreshingProperty, nameof(LanesViewModel.IsRefreshing));

            Title = $"Lanes {pageTitle}";

            IconImageSource = "Road_navigation";

            Content = refreshView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Content is RefreshView refreshView)
            {
                refreshView.IsRefreshing = true;
            }
        }

        async void HandleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var collectionView = (CollectionView)sender;
            collectionView.SelectedItem = null;

            if (e.CurrentSelection.FirstOrDefault() is LaneModel laneModelTapped)
                await Navigation.PushAsync(new SettingsPage(laneModelTapped));
        }
    }
}

