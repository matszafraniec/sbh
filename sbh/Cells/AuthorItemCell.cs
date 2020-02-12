using Foundation;
using sbh.Classes;
using System;
using UIKit;
using WebP.Touch;

namespace sbh.Cells
{
    public partial class AuthorItemCell : UITableViewCell
    {
        WebPCodec imageDecoder;

        public AuthorItemCell (IntPtr handle) : base (handle)
        {
            imageDecoder = new WebPCodec();
        }

        public void Setup(Author item)
        {
            SetStyles();

            ImageViewAvatar.Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource(item.ImagePath, "webp"));
            LabelName.Text = item.Name;
            LabelDescription.Text = item?.Description;
        }

        private void SetStyles()
        {
            LabelName.Font = UIFont.BoldSystemFontOfSize(18);
            LabelDescription.Font = UIFont.SystemFontOfSize(15);
            ViewImageWrapper.Layer.CornerRadius = 45;
        }
    }
}