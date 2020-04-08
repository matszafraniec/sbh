// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace sbh.Cells
{
	[Register ("PhotoItemCell")]
	partial class PhotoItemCell
	{
		[Outlet]
		UIKit.UIImageView ImageViewPhoto { get; set; }

		[Outlet]
		UIKit.UILabel LabelDescription { get; set; }

		[Outlet]
		UIKit.UILabel LabelNew { get; set; }

		[Outlet]
		UIKit.UILabel LabelPhotoNumber { get; set; }

		[Outlet]
		UIKit.UIView ViewPhotoNumberWrapper { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageViewPhoto != null) {
				ImageViewPhoto.Dispose ();
				ImageViewPhoto = null;
			}

			if (LabelDescription != null) {
				LabelDescription.Dispose ();
				LabelDescription = null;
			}

			if (LabelPhotoNumber != null) {
				LabelPhotoNumber.Dispose ();
				LabelPhotoNumber = null;
			}

			if (ViewPhotoNumberWrapper != null) {
				ViewPhotoNumberWrapper.Dispose ();
				ViewPhotoNumberWrapper = null;
			}

			if (LabelNew != null) {
				LabelNew.Dispose ();
				LabelNew = null;
			}
		}
	}
}
