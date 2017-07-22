using Xamarin.Forms;

namespace SecuritySampleApp
{
	public class GatePage : ContentPage
	{
		public GatePage(string pageTitle, int numberOfPages)
		{
			var gridView = new GateGridView(pageTitle, numberOfPages);

			Padding = GetPageThickness();

			Title = pageTitle;

			Content = gridView;
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

