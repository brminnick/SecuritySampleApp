using Xamarin.Forms;

namespace SecuritySampleApp
{
	class AboutPage : BaseContentPage
    {
		public AboutPage(string pageTitle)
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

			NavigationPage.SetTitleIconImageSource(this, "About_navigation");

			Padding = GetPageThickness();

			Title = $"About {pageTitle}";

			Content = aboutStack;
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

