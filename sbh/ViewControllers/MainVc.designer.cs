// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace sbh.ViewControllers
{
	[Register ("MainVc")]
	partial class MainVc
	{
		[Outlet]
		UIKit.UIView AuthorContainerView { get; set; }

		[Outlet]
		UIKit.UIView CuriositiesContainerView { get; set; }

		[Outlet]
		sbh.CustomControls.CustomTopBar CustomTopBar { get; set; }

		[Outlet]
		UIKit.UIImageView ImageViewBackground { get; set; }

		[Outlet]
		UIKit.UIView MainViewWrapper { get; set; }

		[Outlet]
		UIKit.UIView MediaContainerView { get; set; }

		[Outlet]
		UIKit.UIView MuseumContainerView { get; set; }

		[Outlet]
		UIKit.UIView PhotosContainerView { get; set; }

		[Outlet]
		sbh.CustomControls.SideMenu SideMenuControl { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint SideMenuControlLeadingConstraint { get; set; }

		[Outlet]
		UIKit.UITextView TextViewDescription { get; set; }

		[Outlet]
		UIKit.UIView ViewPreviewContentTypeOverlay { get; set; }

		[Outlet]
		UIKit.UIView ViewSideMenuOverlay { get; set; }

		[Outlet]
		UIKit.UIView ViewTopBarOverlay { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AuthorContainerView != null) {
				AuthorContainerView.Dispose ();
				AuthorContainerView = null;
			}

			if (CuriositiesContainerView != null) {
				CuriositiesContainerView.Dispose ();
				CuriositiesContainerView = null;
			}

			if (CustomTopBar != null) {
				CustomTopBar.Dispose ();
				CustomTopBar = null;
			}

			if (ImageViewBackground != null) {
				ImageViewBackground.Dispose ();
				ImageViewBackground = null;
			}

			if (MainViewWrapper != null) {
				MainViewWrapper.Dispose ();
				MainViewWrapper = null;
			}

			if (MediaContainerView != null) {
				MediaContainerView.Dispose ();
				MediaContainerView = null;
			}

			if (MuseumContainerView != null) {
				MuseumContainerView.Dispose ();
				MuseumContainerView = null;
			}

			if (PhotosContainerView != null) {
				PhotosContainerView.Dispose ();
				PhotosContainerView = null;
			}

			if (SideMenuControl != null) {
				SideMenuControl.Dispose ();
				SideMenuControl = null;
			}

			if (SideMenuControlLeadingConstraint != null) {
				SideMenuControlLeadingConstraint.Dispose ();
				SideMenuControlLeadingConstraint = null;
			}

			if (TextViewDescription != null) {
				TextViewDescription.Dispose ();
				TextViewDescription = null;
			}

			if (ViewSideMenuOverlay != null) {
				ViewSideMenuOverlay.Dispose ();
				ViewSideMenuOverlay = null;
			}

			if (ViewTopBarOverlay != null) {
				ViewTopBarOverlay.Dispose ();
				ViewTopBarOverlay = null;
			}

			if (ViewPreviewContentTypeOverlay != null) {
				ViewPreviewContentTypeOverlay.Dispose ();
				ViewPreviewContentTypeOverlay = null;
			}
		}
	}
}
