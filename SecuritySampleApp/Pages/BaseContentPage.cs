using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SecuritySampleApp
{
    class BaseContentPage : ContentPage
    {
        public BaseContentPage() => On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
    }
}
