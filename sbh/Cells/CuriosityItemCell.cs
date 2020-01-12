using sbh.Classes;
using System;
using UIKit;

namespace sbh.Cells
{
    public partial class CuriosityItemCell : UITableViewCell
    {
        public CuriosityItemCell (IntPtr handle) : base (handle)
        {
        }

        public void Setup(Curiosity item)
        {
            SetStyles();

            LabelDescription.Text = item.Description;
        }

        private void SetStyles()
        {
            LabelDescription.Font = UIFont.SystemFontOfSize(16);
        }
    }
}