using Xamarin.Forms;

namespace SecuritySampleApp
{
    class AboutPage : BaseContentPage
    {
        public AboutPage(in string pageTitle)
        {
            var aboutLabel = new Label
            {
                Text = "Sample App Made By"
            };
            var xamarinImage = new Image
            {
                Source = "xamarinlogo"
            };

            var aboutStack = new StackLayout
            {
                Children = {
                    aboutLabel,
                    xamarinImage
                }
            };

            IconImageSource = "About_navigation";

            Padding = GetPageThickness();

            Title = $"About {pageTitle}";

            Content = aboutStack;
        }

        Thickness GetPageThickness() => Device.RuntimePlatform switch
        {
            Device.iOS => new Thickness(10, 30, 10, 5),
            _ => new Thickness(10, 10, 10, 5),
        };
    }
}

