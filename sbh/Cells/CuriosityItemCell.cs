using sbh.Classes;
using sbh.Helpers;
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
            LabelNew.Hidden = item.IsNew ? false : true;
        }

        private void SetStyles()
        {
            LabelDescription.Font = UIFont.SystemFontOfSize(16);
            LabelNew.Font = UIFont.SystemFontOfSize(16);
            LabelNew.TextColor = AppColors.NaturalBlue;
            LabelNew.Text = "Nowe";
        }
    }
}