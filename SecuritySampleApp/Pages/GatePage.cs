using Xamarin.Forms;

namespace SecuritySampleApp
{
    class GatePage : BaseContentPage
    {
        public GatePage(in string pageTitle, in int numberOfPages)
        {
            Padding = GetPageThickness();

            Title = pageTitle;

            Content = new GateGridView(pageTitle, numberOfPages);
        }

        Thickness GetPageThickness() => Device.RuntimePlatform switch
        {
            Device.iOS => new Thickness(10, 30, 10, 5),
            _ => new Thickness(10, 10, 10, 5),
        };
    }
}

