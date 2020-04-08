// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace sbh.CustomControls
{
	[Register ("CustomTopBar")]
	partial class CustomTopBar
	{
		[Outlet]
		UIKit.UIImageView ImageViewMenuIcon { get; set; }

		[Outlet]
		UIKit.UILabel LabelContentType { get; set; }

		[Outlet]
		UIKit.UILabel LabelTitle { get; set; }

		[Outlet]
		UIKit.UIView RootView { get; set; }

		[Outlet]
		UIKit.UIView ViewBackground { get; set; }

		[Outlet]
		UIKit.UIView ViewContentType { get; set; }

		[Outlet]
		UIKit.UIView ViewMenuIcon { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageViewMenuIcon != null) {
				ImageViewMenuIcon.Dispose ();
				ImageViewMenuIcon = null;
			}

			if (LabelContentType != null) {
				LabelContentType.Dispose ();
				LabelContentType = null;
			}

			if (LabelTitle != null) {
				LabelTitle.Dispose ();
				LabelTitle = null;
			}

			if (RootView != null) {
				RootView.Dispose ();
				RootView = null;
			}

			if (ViewBackground != null) {
				ViewBackground.Dispose ();
				ViewBackground = null;
			}

			if (ViewMenuIcon != null) {
				ViewMenuIcon.Dispose ();
				ViewMenuIcon = null;
			}

			if (ViewContentType != null) {
				ViewContentType.Dispose ();
				ViewContentType = null;
			}
		}
	}
}
