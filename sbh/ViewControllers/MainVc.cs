using Foundation;
using sbh.Classes.Enums;
using sbh.Helpers;
using System;
using UIKit;
using WebP.Touch;

namespace sbh.ViewControllers
{
    public partial class MainVc : UIViewController
    {
        UISwipeGestureRecognizer LeadingSwipeRecognizer;
        private PhotosVc PhotosVc;

        public MainVc (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SideMenuControl.MenuItemSelected += SideMenuControl_OnMenuItemSelected;
            SideMenuControl.ClickedOutside += SideMenuControl_OnClickedOutside;
            CustomTopBar.MenuIconActivated += CustomTopBar_OnMenuIconActivated;

            LeadingSwipeRecognizer = new UISwipeGestureRecognizer(() =>
            {
                if (_sideMenuVisibility)
                    SideMenuVisibility = false;
                else
                    SideMenuVisibility = true;
            })
            { Direction = UISwipeGestureRecognizerDirection.Right };
            View.AddGestureRecognizer(LeadingSwipeRecognizer);

            var imageDecoder = new WebPCodec();
            ImageViewBackground.Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/background", "webp"));
            SetStyles();

            PhotosVc.PhotoZooming -= PhotosVc_PhotoZooming;
            PhotosVc.PhotoZooming += PhotosVc_PhotoZooming;
        }

        private void PhotosVc_PhotoZooming(object sender, bool e)
        {
            if (e)
            {
                UIView.Animate(0.4, () =>
                {
                    ViewTopBarOverlay.Alpha = 0.85f;
                    View.LayoutIfNeeded();
                });

                ViewTopBarOverlay.Hidden = LeadingSwipeRecognizer.Enabled = false;
            }
            else
            {
                UIView.Animate(0.4, () =>
                {
                    ViewTopBarOverlay.Alpha = 0;
                    View.LayoutIfNeeded();
                });

                ViewTopBarOverlay.Hidden = LeadingSwipeRecognizer.Enabled = true;
                ViewTopBarOverlay.Alpha = 0.3f;
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "PhotosSegue")
                PhotosVc = segue.DestinationViewController as PhotosVc;
        }

        public override void ViewWillDisappear(bool animated)
        {
            if (_sideMenuVisibility)
                SideMenuVisibility = false;

            base.ViewWillDisappear(animated);
        }

        private void SetStyles()
        {
            CustomTopBar.SetTitle("Główna");
            CurrentPageTitle = "Główna";
            CustomTopBar.BackgroundColor = AppColors.DarkRed;

            SideMenuControl.BackgroundColor = AppColors.WhiteSmoke;
            ViewSideMenuOverlay.BackgroundColor = ViewTopBarOverlay.BackgroundColor = AppColors.NaturalBlack;
            ViewSideMenuOverlay.Hidden = ViewTopBarOverlay.Hidden = AuthorContainerView.Hidden = CuriositiesContainerView.Hidden = MuseumContainerView.Hidden = MediaContainerView.Hidden = PhotosContainerView.Hidden = true;
            ViewSideMenuOverlay.Alpha = ViewTopBarOverlay.Alpha = 0;

            TextViewDescription.Text = "Aplikacja ma za zadanie przybliżyć ważne wydarzenia z życia Bydgoszczy, które przez lata popadły w zapomnienie. Piękna historia miasta, nietuzinkowe postaci – przyjrzyj się uważnie tym unikalnym zdjęciom, obejrzyj filmy i wysłuchaj muzyki. To wszystko w aplikacji pod nazwą: Sekrety Bydgoskiej Historii. Projekt będzie rozwijał się o kolejne sekrety, więc wróć tu koniecznie.\n \nKrzysztof Drozdowski";
            TextViewDescription.Font = UIFont.ItalicSystemFontOfSize(16);

            MainViewWrapper.Hidden = false;
        }

        #region CustomTopBar behaviour
        private void CustomTopBar_OnMenuIconActivated(object sender, bool e)
        {
            if (_sideMenuVisibility)
                SideMenuVisibility = false;
            else
                SideMenuVisibility = true;
        }
        #endregion

        #region SideMenuControl behaviour and navigation
        private void SideMenuControl_OnClickedOutside(object sender, EventArgs e)
        {
            if (_sideMenuVisibility)
                SideMenuVisibility = false;
        }

        private void SideMenuControl_OnMenuItemSelected(object sender, PageName e)
        {
            switch(e)
            {
                case PageName.Photos:
                    MainViewWrapper.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = CuriositiesContainerView.Hidden = true;
                    PhotosContainerView.Hidden = SideMenuVisibility = false;
                    CurrentPageTitle = "Fotografie";
                    break;
                case PageName.Media:
                    MainViewWrapper.Hidden = PhotosContainerView.Hidden = AuthorContainerView.Hidden = MuseumContainerView.Hidden = CuriositiesContainerView.Hidden = true;
                    MediaContainerView.Hidden = SideMenuVisibility = false;
                    CurrentPageTitle = "Media";
                    break;
                case PageName.Museum:
                    MainViewWrapper.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = CuriositiesContainerView.Hidden = PhotosContainerView.Hidden = true;
                    MuseumContainerView.Hidden = SideMenuVisibility = false;
                    CurrentPageTitle = "Odwiedź koniecznie";
                    break;
                case PageName.Home:
                    CuriositiesContainerView.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = PhotosContainerView.Hidden = true;
                    MainViewWrapper.Hidden = SideMenuVisibility = false;
                    CurrentPageTitle = "Główna";
                    break;
                case PageName.Curiosities:
                    MainViewWrapper.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = PhotosContainerView.Hidden = true;
                    CuriositiesContainerView.Hidden = SideMenuVisibility = false;
                    CurrentPageTitle = "Ciekawostki";
                    break;
                case PageName.Author:
                    MainViewWrapper.Hidden = CuriositiesContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = PhotosContainerView.Hidden = true;
                    AuthorContainerView.Hidden = SideMenuVisibility = false;
                    CurrentPageTitle = "Autor";
                    break;
            }
        }

        private bool _sideMenuVisibility;
        private bool _sideMenuDuringAnimation;
        private string _currentPageTitle;

        private string CurrentPageTitle
        {
            get => _currentPageTitle;
            set
            {
                CustomTopBar.SetTitle(value);
                _currentPageTitle = value;
            }
        }

        private bool SideMenuVisibility
        {
            get => _sideMenuVisibility;
            set
            {
                if (_sideMenuDuringAnimation || _sideMenuVisibility == value)
                    return;
                _sideMenuDuringAnimation = true;
                _sideMenuVisibility = value;

                if (value) ViewSideMenuOverlay.Hidden = false;
                UIView.Animate(0.35, 0.0, UIViewAnimationOptions.CurveEaseOut, () =>
                {
                    if (value)
                    {
                        CustomTopBar.SetTitle("Menu");
                        CustomTopBar.IsMenuIconActivated = true;
                        SideMenuControlLeadingConstraint.Constant = 0;
                        ViewSideMenuOverlay.Alpha = 0.4f;
                    }
                    else
                    {
                        CustomTopBar.SetTitle(CurrentPageTitle);
                        CustomTopBar.IsMenuIconActivated = false;
                        SideMenuControlLeadingConstraint.Constant = -SideMenuControl.Bounds.Width - 1;
                        ViewSideMenuOverlay.Alpha = 0;
                    }
                    View.LayoutIfNeeded();
                }, () =>
                {
                    _sideMenuDuringAnimation = false;
                    if (!value) ViewSideMenuOverlay.Hidden = true;
                });
            }
        }
        #endregion
    }
}