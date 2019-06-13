using Xamarin.Forms;

namespace SecuritySampleApp
{
	class GatePage : BaseContentPage
    {
		public GatePage(string pageTitle, int numberOfPages)
		{
			var gateGridView = new GateGridView(pageTitle, numberOfPages);

			Padding = GetPageThickness();

			Title = pageTitle;

			Content = gateGridView;
		}

		Thickness GetPageThickness()
		{
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					return new Thickness(10, 30, 10, 5);
				default:
					return new Thickness(10, 10, 10, 5);
			}
		}
	}
}

