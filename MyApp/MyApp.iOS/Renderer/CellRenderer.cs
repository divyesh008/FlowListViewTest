using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CellRenderer))]
namespace MyApp.iOS.Renderer
{
    public class CellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {

            //   reusableCell.EditingAccessory = UITableViewCellAccessory.DisclosureIndicator;
            var cell = base.GetCell(item, reusableCell, tv);
            cell.Accessory = UITableViewCellAccessory.None;

            return cell;
        }
    }
}
