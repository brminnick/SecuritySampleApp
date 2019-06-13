using Xamarin.Forms;

namespace SecuritySampleApp
{
	public static class StylesConstants
	{
		public static Style StackLayoutStyle = new Style(typeof(StackLayout))
		{
			Setters = {
				new Setter { Property = StackLayout.HorizontalOptionsProperty, Value = LayoutOptions.CenterAndExpand},
				new Setter { Property = StackLayout.VerticalOptionsProperty, Value = LayoutOptions.CenterAndExpand}
			}
		};
	}
}

