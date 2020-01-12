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
	[Register ("PhotosVc")]
	partial class PhotosVc
	{
		[Outlet]
		UIKit.UIImageView ImageViewZooming { get; set; }

		[Outlet]
		UIKit.UILabel LabelSourceInfo { get; set; }

		[Outlet]
		UIKit.UIScrollView ScrollViewImageZooming { get; set; }

		[Outlet]
		UIKit.UITableView TableViewPhotoItems { get; set; }

		[Outlet]
		UIKit.UIView ViewOverlay { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageViewZooming != null) {
				ImageViewZooming.Dispose ();
				ImageViewZooming = null;
			}

			if (LabelSourceInfo != null) {
				LabelSourceInfo.Dispose ();
				LabelSourceInfo = null;
			}

			if (ScrollViewImageZooming != null) {
				ScrollViewImageZooming.Dispose ();
				ScrollViewImageZooming = null;
			}

			if (TableViewPhotoItems != null) {
				TableViewPhotoItems.Dispose ();
				TableViewPhotoItems = null;
			}

			if (ViewOverlay != null) {
				ViewOverlay.Dispose ();
				ViewOverlay = null;
			}
		}
	}
}
