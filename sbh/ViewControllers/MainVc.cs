using Foundation;
using sbh.Classes.Enums;
using sbh.Helpers;
using System;
using System.Threading.Tasks;
using UIKit;
using WebP.Touch;

namespace sbh.ViewControllers
{
    public partial class MainVc : UIViewController
    {
        UISwipeGestureRecognizer LeadingSwipeRecognizer;
        private PhotosVc PhotosVc;
        private MediaVc MediaVc;
        private CuriositiesVc CuriositiesVc;

        public MainVc (IntPtr handle) : base (handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            SideMenuControl.MenuItemSelected += SideMenuControl_OnMenuItemSelected;
            SideMenuControl.ClickedOutside += SideMenuControl_OnClickedOutside;
            CustomTopBar.MenuIconActivated += CustomTopBar_OnMenuIconActivated;
            CustomTopBar.MenuContentTypeActivated += CustomTopBar_OnMenuContentTypeActivated;

            LeadingSwipeRecognizer = new UISwipeGestureRecognizer(() =>
            {
                if (sideMenuVisibility)
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

            ViewPreviewContentTypeOverlay.Alpha = 0.65f;
            ViewPreviewContentTypeOverlay.Hidden = false;
            CustomTopBar.ContentTypeSectionAnimation();
            await Task.Delay(2000);
            CustomTopBar.SetContentTypeTitle(ContentType.Bydgoszcz1920);
            CustomTopBar.HideContentTypeOverlay();
            ViewPreviewContentTypeOverlay.Hidden = true;
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
            else if (segue.Identifier == "MediaSegue")
                MediaVc = segue.DestinationViewController as MediaVc;
            else if (segue.Identifier == "CuriositiesSegue")
                CuriositiesVc = segue.DestinationViewController as CuriositiesVc;
        }

        public override void ViewWillDisappear(bool animated)
        {
            if (sideMenuVisibility)
                SideMenuVisibility = false;

            base.ViewWillDisappear(animated);
        }

        private void SetStyles()
        {
            CustomTopBar.SetTitle("Główna");
            CurrentPageTitle = "Główna";
            CustomTopBar.BackgroundColor = AppColors.DarkRed;
            CustomTopBar.ContentTypeButtonIsVisible = true;

            SideMenuControl.BackgroundColor = AppColors.WhiteSmoke;
            ViewSideMenuOverlay.BackgroundColor = ViewTopBarOverlay.BackgroundColor = ViewPreviewContentTypeOverlay.BackgroundColor = AppColors.NaturalBlack;
            ViewSideMenuOverlay.Hidden = ViewTopBarOverlay.Hidden = ViewPreviewContentTypeOverlay.Hidden = AuthorContainerView.Hidden = CuriositiesContainerView.Hidden = MuseumContainerView.Hidden = MediaContainerView.Hidden = PhotosContainerView.Hidden = true;
            ViewSideMenuOverlay.Alpha = ViewTopBarOverlay.Alpha = ViewPreviewContentTypeOverlay.Alpha = 0;

            TextViewDescription.Text = "100 lat Bydgoszczy w Polsce" + AppStrings.Main_Introduction;
            TextViewDescription.Font = UIFont.ItalicSystemFontOfSize(16);

            MainViewWrapper.Hidden = false;
        }

        private void ChangeContentType(ContentType contentType)
        {
            PhotosVc.ChosenContentType = contentType;
            MediaVc.ChosenContentType = contentType;
            CuriositiesVc.ChosenContentType = contentType;
        }

        #region CustomTopBar behaviour
        private void CustomTopBar_OnMenuIconActivated(object sender, bool e)
        {
            if (sideMenuVisibility)
                SideMenuVisibility = false;
            else
                SideMenuVisibility = true;
        }

        private void CustomTopBar_OnMenuContentTypeActivated(object sender, bool e)
        {
            if(e)
            {
                var alert = UIAlertController.Create("Wybierz treści", "", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Bydgoszcz 1920", UIAlertActionStyle.Default,
                    action =>
                    {
                        ChangeContentType(ContentType.Bydgoszcz1920);
                        CustomTopBar.SetContentTypeTitle(ContentType.Bydgoszcz1920);
                        SideMenuControl.SetSideMenuSubHeader(ContentType.Bydgoszcz1920);
                        TextViewDescription.Text = AppStrings.ContentDescription_Bydgoszcz1920 + AppStrings.Main_Introduction;

                        if (CurrentPageTitle == "Główna")
                            SideMenuVisibility = true;
                    }));
                alert.AddAction(UIAlertAction.Create("Bydgoszcz 1945", UIAlertActionStyle.Default,
                    action =>
                    {
                        ChangeContentType(ContentType.Bydgoszcz1945);
                        CustomTopBar.SetContentTypeTitle(ContentType.Bydgoszcz1945);
                        SideMenuControl.SetSideMenuSubHeader(ContentType.Bydgoszcz1945);
                        TextViewDescription.Text = AppStrings.ContentDescription_Bydgoszcz1945 + AppStrings.Main_Introduction;

                        if (CurrentPageTitle == "Główna")
                            SideMenuVisibility = true;
                    }));
                alert.AddAction(UIAlertAction.Create("Marian Rejewski", UIAlertActionStyle.Default,
                    action =>
                    {
                        ChangeContentType(ContentType.MarianRejewski);
                        CustomTopBar.SetContentTypeTitle(ContentType.MarianRejewski);
                        SideMenuControl.SetSideMenuSubHeader(ContentType.MarianRejewski);
                        TextViewDescription.Text = AppStrings.ContentDescription_MarianRejewski + AppStrings.Main_Introduction;

                        if (CurrentPageTitle == "Główna")
                            SideMenuVisibility = true;
                    }));

                alert.AddAction(UIAlertAction.Create("Anuluj", UIAlertActionStyle.Cancel,
                    action => {  }));
                PresentViewController(alert, true, null);
            }
        }
        #endregion

        #region SideMenuControl behaviour and navigation
        private void SideMenuControl_OnClickedOutside(object sender, EventArgs e)
        {
            if (sideMenuVisibility)
                SideMenuVisibility = false;
        }

        private void SideMenuControl_OnMenuItemSelected(object sender, PageName e)
        {
            switch(e)
            {
                case PageName.Photos:
                    MainViewWrapper.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = CuriositiesContainerView.Hidden = true;
                    PhotosContainerView.Hidden = SideMenuVisibility = false;
                    CustomTopBar.ContentTypeButtonIsVisible = true;
                    CurrentPageTitle = "Fotografie";
                    break;
                case PageName.Media:
                    MainViewWrapper.Hidden = PhotosContainerView.Hidden = AuthorContainerView.Hidden = MuseumContainerView.Hidden = CuriositiesContainerView.Hidden = true;
                    MediaContainerView.Hidden = SideMenuVisibility = false;
                    CustomTopBar.ContentTypeButtonIsVisible = true;
                    CurrentPageTitle = "Media";
                    break;
                case PageName.Museum:
                    MainViewWrapper.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = CuriositiesContainerView.Hidden = PhotosContainerView.Hidden = true;
                    MuseumContainerView.Hidden = SideMenuVisibility = CustomTopBar.ContentTypeButtonIsVisible = false;
                    CurrentPageTitle = "Odwiedź koniecznie";
                    break;
                case PageName.Home:
                    CuriositiesContainerView.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = PhotosContainerView.Hidden = true;
                    MainViewWrapper.Hidden = SideMenuVisibility = false;
                    CustomTopBar.ContentTypeButtonIsVisible = true;
                    CurrentPageTitle = "Główna";
                    break;
                case PageName.Curiosities:
                    MainViewWrapper.Hidden = AuthorContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = PhotosContainerView.Hidden = true;
                    CuriositiesContainerView.Hidden = SideMenuVisibility = false;
                    CustomTopBar.ContentTypeButtonIsVisible = true;
                    CurrentPageTitle = "Ciekawostki";
                    break;
                case PageName.Author:
                    MainViewWrapper.Hidden = CuriositiesContainerView.Hidden = MediaContainerView.Hidden = MuseumContainerView.Hidden = PhotosContainerView.Hidden = true;
                    AuthorContainerView.Hidden = SideMenuVisibility = CustomTopBar.ContentTypeButtonIsVisible = false;
                    CurrentPageTitle = "Autor";
                    break;
            }
        }

        private bool sideMenuVisibility;
        private bool sideMenuDuringAnimation;
        private string currentPageTitle;

        private string CurrentPageTitle
        {
            get => currentPageTitle;
            set
            {
                CustomTopBar.SetTitle(value);
                currentPageTitle = value;
            }
        }

        private bool SideMenuVisibility
        {
            get => sideMenuVisibility;
            set
            {
                if (sideMenuDuringAnimation || sideMenuVisibility == value)
                    return;
                sideMenuDuringAnimation = true;
                sideMenuVisibility = value;

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
                    sideMenuDuringAnimation = false;
                    if (!value) ViewSideMenuOverlay.Hidden = true;
                });
            }
        }
        #endregion
    }
}