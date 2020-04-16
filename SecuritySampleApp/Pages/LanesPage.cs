using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace SecuritySampleApp
{
    class LanesPage : BaseContentPage
    {
        public LanesPage(string pageTitle)
        {
            BindingContext = new LanesViewModel();

            Title = $"Lanes {pageTitle}";

            IconImageSource = "Road_navigation";

            Content = new RefreshView
            {
                Content = new CollectionView
                {
                    ItemTemplate = new LanesDataTemplate(),
                    SelectionMode = SelectionMode.Single,
                }.Assign(out CollectionView collectionView)
                 .Bind(CollectionView.ItemsSourceProperty, nameof(LanesViewModel.LanesCollection))

            }.Bind(RefreshView.CommandProperty, nameof(LanesViewModel.RefreshCommand))
             .Bind(RefreshView.IsRefreshingProperty, nameof(LanesViewModel.IsRefreshing));

            collectionView.SelectionChanged += HandleSelectionChanged;
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

