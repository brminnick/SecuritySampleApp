using Xamarin.Forms;

namespace SecuritySampleApp
{
    class AboutPage : BaseContentPage
    {
        public AboutPage(in string pageTitle)
        {
            IconImageSource = "About_navigation";

            Padding = GetPageThickness();

            Title = $"About {pageTitle}";

            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Sample App Made By" },
                    new Image { Source = "xamarinlogo" }
                }
            };
        }

        Thickness GetPageThickness() => Device.RuntimePlatform switch
        {
            Device.iOS => new Thickness(10, 30, 10, 5),
            _ => new Thickness(10, 10, 10, 5),
        };
    }
}

