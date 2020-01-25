using sbh.Helpers;
using System;
using UIKit;

namespace sbh.Cells
{
    public partial class PhotoFooterItemCell : UITableViewCell
    {
        public PhotoFooterItemCell (IntPtr handle) : base (handle)
        {
        }

        public void Setup()
        {
            LabelSourceInfo.Text = "Zdjęcia pochodzą z Muzeum Wojsk Lądowych.";
            LabelSourceInfo.TextColor = AppColors.DarkRed;
            LabelSourceInfo.Font = UIFont.ItalicSystemFontOfSize(15);

            SelectionStyle = UITableViewCellSelectionStyle.None;
        }
    }
}