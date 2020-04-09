using CoreGraphics;
using Foundation;
using sbh.Classes.Enums;
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
        public EventHandler<bool> MenuContentTypeActivated;
        public bool IsMenuIconActivated;
        public bool IsMenuContentTypeActivated;
        private bool contentTypeButtonIsVisible;

        public bool ContentTypeButtonIsVisible
        {
            get => contentTypeButtonIsVisible;
            set
            {
                contentTypeButtonIsVisible = value;

                if (value)
                    ViewContentType.Hidden = false;
                else
                    ViewContentType.Hidden = true;
            }
        }


        public CustomTopBar (IntPtr handle) : base (handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if ((Site != null) && Site.DesignMode)
                return;

            NSBundle.MainBundle.LoadNib("CustomTopBar", this, null);
            RootView.Frame = new CGRect(0, 0, Superview.Frame.Width, RootView.Frame.Height);
            AddSubview(RootView);

            ViewMenuIcon.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                if (!IsMenuIconActivated)
                    MenuIconActivated?.Invoke(this, true);
                else
                    MenuIconActivated?.Invoke(this, false);
            }));

            ViewContentType.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                if (!IsMenuContentTypeActivated)
                    MenuContentTypeActivated?.Invoke(this, true);
                else
                    MenuContentTypeActivated?.Invoke(this, false);
            }));

            SetStyles();
        }

        private void SetStyles()
        {
            LabelTitle.TextColor = LabelContentType.TextColor = AppColors.NaturalWhite;
            LabelTitle.Font = UIFont.BoldSystemFontOfSize(16);
            LabelContentType.Font = UIFont.BoldSystemFontOfSize(15);
            ViewContentType.Layer.CornerRadius = 20;

            ViewBackground.BackgroundColor = AppColors.DarkRed;

            ViewOverlay.Alpha = 0.65f;
            ViewOverlay.BackgroundColor = AppColors.NaturalBlack;
            ViewOverlay.Hidden = false;

            LabelContentType.Alpha = 0;
            LabelContentType.Text = "Wybierz treści";
        }

        public void SetTitle(string title)
        {
            LabelTitle.Text = title;
        }

        public void SetContentTypeTitle(ContentType contentType)
        {
            var contentTypeTitle = "";

            switch (contentType)
            {
                case ContentType.Bydgoszcz1945:
                    contentTypeTitle = "Bydgoszcz 1945";
                    break;
                case ContentType.MarianRejewski:
                    contentTypeTitle = "Marian Rejewski";
                    break;
                default:
                    contentTypeTitle = "Bydgoszcz 1920";
                    break;
                    
            }
            LabelContentType.Text = contentTypeTitle;
        }

        public void ContentTypeSectionAnimation()
        {
            Animate(1.5, () =>
            {
                LabelContentType.Alpha = 1;
            });
        }
        public void HideContentTypeOverlay() => ViewOverlay.Hidden = true;
    }
}