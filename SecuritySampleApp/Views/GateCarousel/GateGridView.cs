using System;

using Xamarin.Forms;

namespace SecuritySampleApp
{
    public class GateGridView : ContentView
    {
        #region Constant Fields
        const int relativeLayoutPadding = 10;
        readonly GateGridViewImageButton _lanesButton, _aboutButton;
        readonly string _contentTitle;
        #endregion

        #region Constructors
        public GateGridView(string pageNumber, int numberOfPages)
        {
            _contentTitle = pageNumber;

            var lanesLabel = new GateGridViewLabel("Lanes");

            _lanesButton = new GateGridViewImageButton("Road");
            _lanesButton.Clicked += OnLanesButtonClicked;

            var aboutLabel = new GateGridViewLabel("About");

            _aboutButton = new GateGridViewImageButton("About");
            _aboutButton.Clicked += OnAboutButtonClicked;

            var titleLabel = new GateGridViewLabel($"{pageNumber} of {numberOfPages}");

            var enableSwitchText = new GateGridViewLabel("Disable Buttons");

            var enableSwitchButton = new Switch
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent
            };
            enableSwitchButton.Toggled += ToggleAllButtons;

            var switchStackHorizontal = new StackLayout
            {
                Style = StylesConstants.StackLayoutStyle,
                Orientation = StackOrientation.Horizontal,
                Children = {
                    enableSwitchText,
                    enableSwitchButton
                }
            };

            var mainRelativeLayout = new RelativeLayout();

            mainRelativeLayout.Children.Add(lanesLabel,
                                            Constraint.RelativeToParent((parent) => parent.Width / 8),
                                            Constraint.RelativeToParent((parent) => parent.Y + relativeLayoutPadding),
                                            Constraint.RelativeToParent((parent) => parent.Width / 4));
            mainRelativeLayout.Children.Add(_lanesButton,
                                            Constraint.RelativeToParent((parent) => parent.Width / 8),
                                            Constraint.RelativeToView(lanesLabel, (parent, view) => view.Y + view.Height + relativeLayoutPadding),
                                            Constraint.RelativeToParent((parent) => parent.Width / 4),
                                            Constraint.Constant(100));
            mainRelativeLayout.Children.Add(aboutLabel,
                                            Constraint.RelativeToParent((parent) => parent.Width * 5 / 8),
                                            Constraint.RelativeToParent((parent) => parent.Y + relativeLayoutPadding),
                                            Constraint.RelativeToParent((parent) => parent.Width / 4));
            mainRelativeLayout.Children.Add(_aboutButton,
                                            Constraint.RelativeToParent((parent) => parent.Width * 5 / 8),
                                            Constraint.RelativeToView(lanesLabel, (parent, view) => view.Y + view.Height + relativeLayoutPadding),
                                            Constraint.RelativeToParent((parent) => parent.Width / 4),
                                            Constraint.Constant(100));
            mainRelativeLayout.Children.Add(switchStackHorizontal,
                                            Constraint.RelativeToParent((parent) => parent.Width / 2 - getswitchStackHorizonalWidth(parent) / 2),
                                            Constraint.RelativeToView(_lanesButton, (parent, view) => view.Y + view.Height + relativeLayoutPadding * 4));
            mainRelativeLayout.Children.Add(titleLabel,
                                            Constraint.RelativeToParent((parent) => parent.Width / 2 - getTitleLabelWidth(parent) / 2),
                                            Constraint.RelativeToView(switchStackHorizontal, (parent, view) => view.Y + view.Height + relativeLayoutPadding * 4));

            Content = mainRelativeLayout;

            double getswitchStackHorizonalWidth(RelativeLayout p) => switchStackHorizontal.Measure(p.Width, p.Height).Request.Width;
            double getTitleLabelWidth(RelativeLayout p) => titleLabel.Measure(p.Width, p.Height).Request.Width;
        }
        #endregion

        #region Methods
        void ToggleAllButtons(object sender, EventArgs e)
        {
            _aboutButton.IsEnabled = !_aboutButton.IsEnabled;
            _lanesButton.IsEnabled = !_lanesButton.IsEnabled;
        }

        async void OnLanesButtonClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new LanesPage(_contentTitle));

        async void OnAboutButtonClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new AboutPage(_contentTitle));
        #endregion

        #region Classes
        class GateGridViewLabel : Label
        {
            public GateGridViewLabel(string text)
            {
                Text = text;
                HorizontalOptions = LayoutOptions.Center;
                BackgroundColor = Color.Transparent;
            }
        }

        class GateGridViewImageButton : ImageButton
        {
            public GateGridViewImageButton(string iconImageSource)
            {
                Source = iconImageSource;
                HorizontalOptions = LayoutOptions.CenterAndExpand;
                BackgroundColor = Color.Transparent;
            }
        }
        #endregion
    }
}

