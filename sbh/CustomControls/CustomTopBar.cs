using CoreGraphics;
using Foundation;
using sbh.Helpers;
using System;
using System.ComponentModel;
using UIKit;

namespace sbh.CustomControls
{
    public partial class CustomTopBar : UIView, IComponent
    {
        public ISite Site { get; set; }
        public event EventHandler Disposed;

        public EventHandler<bool> MenuIconActivated;
        public bool IsMenuIconActivated;

        public CustomTopBar (IntPtr handle) : base (handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if ((Site != null) && Site.DesignMode)
                return;

            NSBundle.MainBundle.LoadNib("CustomTopBar", this, null);
            //RootView.Frame = new CGRect(0, 0, Superview.Frame.Width, RootView.Frame.Height);
            AddSubview(RootView);

            ViewMenuIcon.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                if (!IsMenuIconActivated)
                    MenuIconActivated?.Invoke(this, true);
                else
                    MenuIconActivated?.Invoke(this, false);
            }));

            SetStyles();
        }

        private void SetStyles()
        {
            LabelTitle.TextColor = AppColors.NaturalWhite;
            LabelTitle.Font = UIFont.BoldSystemFontOfSize(16);
            ViewBackground.BackgroundColor = AppColors.DarkRed;
        }

        public void SetTitle(string title)
        {
            LabelTitle.Text = title;
        }
    }
}