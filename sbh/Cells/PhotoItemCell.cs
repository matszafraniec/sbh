using CoreAnimation;
using sbh.Classes;
using sbh.Helpers;
using System;
using UIKit;

namespace sbh.Cells
{
    public partial class PhotoItemCell : UITableViewCell
    {
   
        public PhotoItemCell (IntPtr handle) : base (handle)
        {
            
        }

        public void Setup(Photo item)
        {
            SetStyles();

            ImageViewPhoto.Image = item.Image;
            LabelPhotoNumber.Text = item.Id.ToString();
            LabelDescription.Text = item.Description;
            LabelNew.Hidden = item.IsNew ? false : true;
        }

        private void SetStyles()
        {
            LabelPhotoNumber.TextColor = AppColors.NaturalWhite;
            LabelPhotoNumber.Font = UIFont.BoldSystemFontOfSize(13);
            LabelDescription.Font = UIFont.SystemFontOfSize(15);

            ViewPhotoNumberWrapper.BackgroundColor = AppColors.DarkRed;
            ViewPhotoNumberWrapper.Layer.CornerRadius = 20;
            ViewPhotoNumberWrapper.Layer.MaskedCorners = CACornerMask.MinXMinYCorner;

            LabelNew.Font = UIFont.SystemFontOfSize(16);
            LabelNew.TextColor = AppColors.NaturalBlue;
            LabelNew.Text = "Nowe";

            SelectionStyle = UITableViewCellSelectionStyle.None;
        }
    }
}