using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using SecuritySampleApp;
using SecuritySampleApp.iOS;

[assembly: ExportRenderer(typeof(LanesViewCell), typeof(LanesViewCellCustomRenderer))]
namespace SecuritySampleApp.iOS
{
	public class LanesViewCellCustomRenderer : ViewCellRenderer
	{
		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell(item, reusableCell, tv);

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}
	}
}
