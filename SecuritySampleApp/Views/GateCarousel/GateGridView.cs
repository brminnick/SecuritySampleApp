using System;

using Xamarin.Forms;

namespace SecuritySampleApp
{
    public class GateGridView : ContentView
    {
        #region Constant Fields
        const int relativeLayoutPadding = 10;
        readonly Button _lanesButton, _aboutButton;
        #endregion

        #region Fields
        string _contentTitle;
        #endregion

        #region Constructors
        public GateGridView(string pageNumber, int numberOfPages)
        {
            _contentTitle = pageNumber;

            var lanesLabel = new Label
            {
                Text = "Lanes",
                Style = StylesConstants.LabelStyle
            };

            _lanesButton = new Button
            {
                Image = "Road",
                Style = StylesConstants.ButtonStyle
            };
            _lanesButton.Clicked += OnLanesButtonClicked;

            var aboutLabel = new Label
            {
                Text = "About",
                Style = StylesConstants.LabelStyle,
            };

            _aboutButton = new Button
            {
                Image = "About",
                Style = StylesConstants.ButtonStyle,
            };
            _aboutButton.Clicked += OnAboutButtonClicked;

            var titleLabel = new Label
            {
                Text = $"{pageNumber} of {numberOfPages}",
                Style = StylesConstants.LabelStyle
            };

            var enableSwitchText = new Label
            {
                Text = "Disable Buttons",
                Style = StylesConstants.LabelStyle
            };
            var enableSwitchButton = new Switch
            {
                Style = StylesConstants.ButtonStyle
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

            Func<RelativeLayout, double> getswitchStackHorizonalWidth = (p) => switchStackHorizontal.Measure(p.Width, p.Height).Request.Width;
            Func<RelativeLayout, double> getTitleLabelWidth = (p) => titleLabel.Measure(p.Width, p.Height).Request.Width;

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
        }
        #endregion

        #region Finalizers
        ~GateGridView()
        {
            _aboutButton.Clicked -= OnAboutButtonClicked;
            _lanesButton.Clicked -= OnLanesButtonClicked;
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
    }
}

