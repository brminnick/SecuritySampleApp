using System;

using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace SecuritySampleApp
{
    public class GateGridView : RelativeLayout
    {
        const int relativeLayoutPadding = 10;
        readonly GateGridViewImageButton _lanesButton, _aboutButton;
        readonly string _contentTitle;

        public GateGridView(in string pageNumber, in int numberOfPages)
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
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    enableSwitchText,
                    enableSwitchButton
                }
            }.CenterExpand();

            Children.Add(lanesLabel,
                Constraint.RelativeToParent((parent) => parent.Width / 8),
                Constraint.RelativeToParent((parent) => parent.Y + relativeLayoutPadding),
                Constraint.RelativeToParent((parent) => parent.Width / 4));
            Children.Add(_lanesButton,
                Constraint.RelativeToParent((parent) => parent.Width / 8),
                Constraint.RelativeToView(lanesLabel, (parent, view) => view.Y + view.Height + relativeLayoutPadding),
                Constraint.RelativeToParent((parent) => parent.Width / 4),
                Constraint.Constant(100));
            Children.Add(aboutLabel,
                Constraint.RelativeToParent((parent) => parent.Width * 5 / 8),
                Constraint.RelativeToParent((parent) => parent.Y + relativeLayoutPadding),
                Constraint.RelativeToParent((parent) => parent.Width / 4));
            Children.Add(_aboutButton,
                Constraint.RelativeToParent((parent) => parent.Width * 5 / 8),
                Constraint.RelativeToView(lanesLabel, (parent, view) => view.Y + view.Height + relativeLayoutPadding),
                Constraint.RelativeToParent((parent) => parent.Width / 4),
                Constraint.Constant(100));
            Children.Add(switchStackHorizontal,
                Constraint.RelativeToParent((parent) => parent.Width / 2 - getWidth(parent, switchStackHorizontal) / 2),
                Constraint.RelativeToView(_lanesButton, (parent, view) => view.Y + view.Height + relativeLayoutPadding * 4));
            Children.Add(titleLabel,
                Constraint.RelativeToParent((parent) => parent.Width / 2 - getWidth(parent, titleLabel) / 2),
                Constraint.RelativeToView(switchStackHorizontal, (parent, view) => view.Y + view.Height + relativeLayoutPadding * 4));

            static double getWidth(RelativeLayout p, View view) => view.Measure(p.Width, p.Height).Request.Width;
        }

        void ToggleAllButtons(object sender, EventArgs e)
        {
            _aboutButton.IsEnabled = !_aboutButton.IsEnabled;
            _lanesButton.IsEnabled = !_lanesButton.IsEnabled;
        }

        async void OnLanesButtonClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new LanesPage(_contentTitle));

        async void OnAboutButtonClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new AboutPage(_contentTitle));

        class GateGridViewLabel : Label
        {
            public GateGridViewLabel(in string text)
            {
                Text = text;
                HorizontalOptions = LayoutOptions.Center;
                BackgroundColor = Color.Transparent;
            }
        }

        class GateGridViewImageButton : ImageButton
        {
            public GateGridViewImageButton(in string iconImageSource)
            {
                Source = iconImageSource;
                HorizontalOptions = LayoutOptions.CenterAndExpand;
                BackgroundColor = Color.Transparent;
            }
        }
    }
}

