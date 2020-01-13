using CoreGraphics;
using Foundation;
using sbh.Classes.Enums;
using sbh.Helpers;
using System;
using System.ComponentModel;
using UIKit;
using WebP.Touch;

namespace sbh.CustomControls
{
    public partial class SideMenu : UIView, IComponent
    {
        public ISite Site { get; set; }
        public event EventHandler Disposed;

        public event EventHandler<PageName> MenuItemSelected;
        public event EventHandler ClickedOutside;
        private Action _backgroundClickAction;

        public SideMenu (IntPtr handle) : base (handle)
        {
        }

        public void SetupBackgroundClickAction(Action action = null) => _backgroundClickAction = action;

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if ((Site != null) && Site.DesignMode)
                return;

            NSBundle.MainBundle.LoadNib("SideMenu", this, null);
            RootView.Frame = new CGRect(0, 0, RootView.Frame.Width, Superview.Frame.Height);
            AddSubview(RootView);

            var imageDecoder = new WebPCodec();
            ImageViewBackground.Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/background", "webp"));

            ViewMenuHome.AddGestureRecognizer(new UITapGestureRecognizer((obj) =>
            {
                ViewMenuHome.BackgroundColor = AppColors.DarkGray.ChangeAlpha(0.3f);
                ViewMenuPhotos.BackgroundColor = ViewMenuCuriosities.BackgroundColor = ViewMenuAuthor.BackgroundColor = ViewMenuMuseum.BackgroundColor = UIColor.Clear;
                MenuItemSelected?.Invoke(this, PageName.Home);
            }));
            ViewMenuPhotos.AddGestureRecognizer(new UITapGestureRecognizer((obj) =>
            {
                ViewMenuPhotos.BackgroundColor = AppColors.DarkGray.ChangeAlpha(0.3f);
                ViewMenuHome.BackgroundColor = ViewMenuCuriosities.BackgroundColor = ViewMenuAuthor.BackgroundColor = ViewMenuMuseum.BackgroundColor = UIColor.Clear;
                MenuItemSelected?.Invoke(this, PageName.Photos);
            }));
            ViewMenuCuriosities.AddGestureRecognizer(new UITapGestureRecognizer((obj) =>
            {
                ViewMenuCuriosities.BackgroundColor = AppColors.DarkGray.ChangeAlpha(0.3f);
                ViewMenuHome.BackgroundColor = ViewMenuPhotos.BackgroundColor = ViewMenuAuthor.BackgroundColor = ViewMenuMuseum.BackgroundColor = UIColor.Clear;
                MenuItemSelected?.Invoke(this, PageName.Curiosities);
            }));
            ViewMenuAuthor.AddGestureRecognizer(new UITapGestureRecognizer((obj) =>
            {
                ViewMenuAuthor.BackgroundColor = AppColors.DarkGray.ChangeAlpha(0.3f);
                ViewMenuHome.BackgroundColor = ViewMenuPhotos.BackgroundColor = ViewMenuCuriosities.BackgroundColor = ViewMenuMuseum.BackgroundColor = UIColor.Clear;
                MenuItemSelected?.Invoke(this, PageName.Author);
            }));
            ViewMenuMuseum.AddGestureRecognizer(new UITapGestureRecognizer((obj) =>
            {
                ViewMenuMuseum.BackgroundColor = AppColors.DarkGray.ChangeAlpha(0.3f);
                ViewMenuHome.BackgroundColor = ViewMenuPhotos.BackgroundColor = ViewMenuCuriosities.BackgroundColor = ViewMenuAuthor.BackgroundColor = UIColor.Clear;
                MenuItemSelected?.Invoke(this, PageName.Museum);
            }));

            SetStyles();
        }

        private void SetStyles()
        {
            LabelHeader.Text = "Sekrety bydgoskiej historii";
            LabelHome.Text = "Główna";
            LabelPhotos.Text = "Fotografie";
            LabelCuriosities.Text = "Ciekawostki";
            LabelUseful.Text = "Przydatne";
            LabelAuthor.Text = "Zespół autorski";
            LabelMuseum.Text = "Odwiedź koniecznie";
            LabelSubheader.Text = "100-lecie powrotu miasta do Macierzy";

            LabelHeader.Font = UIFont.BoldSystemFontOfSize(16);
            LabelHome.Font = LabelPhotos.Font = LabelCuriosities.Font = LabelUseful.Font = LabelAuthor.Font = LabelMuseum.Font = UIFont.SystemFontOfSize(15);
            LabelSubheader.Font = UIFont.SystemFontOfSize(13);

            LabelHeader.TextColor = LabelSubheader.TextColor = AppColors.WhiteSmoke;
            LabelUseful.TextColor = ViewSeparator.BackgroundColor = AppColors.DarkGray;
            ViewSeparator.Alpha = 0.6f;
            LabelHome.TextColor = LabelPhotos.TextColor = LabelCuriosities.TextColor = LabelAuthor.TextColor = LabelMuseum.TextColor = AppColors.NaturalBlack;

            ViewMenuHome.BackgroundColor = AppColors.DarkGray.ChangeAlpha(0.3f);
            ViewHeader.BackgroundColor = AppColors.DarkRed;
        }

        public override UIView HitTest(CGPoint point, UIEvent uievent)
        {
            if (point.X > Bounds.Width)
                ClickedOutside?.Invoke(this, null);

            return base.HitTest(point, uievent);
        }
    }
}