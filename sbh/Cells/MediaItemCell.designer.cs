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
	[Register ("MediaItemCell")]
	partial class MediaItemCell
	{
		[Outlet]
		UIKit.UIImageView ImageViewMediaPhoto { get; set; }

		[Outlet]
		UIKit.UILabel LabelDescription { get; set; }

		[Outlet]
		UIKit.UILabel LabelMediaNumber { get; set; }

		[Outlet]
		UIKit.UIView ViewMediaNumberWrapper { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageViewMediaPhoto != null) {
				ImageViewMediaPhoto.Dispose ();
				ImageViewMediaPhoto = null;
			}

			if (ViewMediaNumberWrapper != null) {
				ViewMediaNumberWrapper.Dispose ();
				ViewMediaNumberWrapper = null;
			}

			if (LabelMediaNumber != null) {
				LabelMediaNumber.Dispose ();
				LabelMediaNumber = null;
			}

			if (LabelDescription != null) {
				LabelDescription.Dispose ();
				LabelDescription = null;
			}
		}
	}
}
