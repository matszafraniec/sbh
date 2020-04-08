using CoreAnimation;
using sbh.Classes;
using sbh.Helpers;
using System;
using UIKit;

namespace sbh.Cells
{
    public partial class MediaItemCell : UITableViewCell
    {
        public MediaItemCell (IntPtr handle) : base (handle)
        {
        }

        public void Setup(Media item)
        {
            SetStyles();

            ImageViewMediaPhoto.Image = item.Image;
            LabelMediaNumber.Text = item.Id.ToString();
            LabelDescription.Text = item.Description;
            LabelNew.Hidden = item.IsNew ? false : true;
        }

        private void SetStyles()
        {
            LabelMediaNumber.TextColor = AppColors.NaturalWhite;
            LabelMediaNumber.Font = UIFont.BoldSystemFontOfSize(13);
            LabelDescription.Font = UIFont.SystemFontOfSize(15);

            ViewMediaNumberWrapper.BackgroundColor = AppColors.DarkRed;
            ViewMediaNumberWrapper.Layer.CornerRadius = 20;
            ViewMediaNumberWrapper.Layer.MaskedCorners = CACornerMask.MinXMinYCorner;

            LabelNew.Font = UIFont.SystemFontOfSize(16);
            LabelNew.TextColor = AppColors.NaturalBlue;
            LabelNew.Text = "Nowe";

            SelectionStyle = UITableViewCellSelectionStyle.Blue;
        }
    }
}