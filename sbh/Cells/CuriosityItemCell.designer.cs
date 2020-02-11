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
	[Register ("CuriosityItemCell")]
	partial class CuriosityItemCell
	{
		[Outlet]
		UIKit.UILabel LabelDescription { get; set; }

		[Outlet]
		UIKit.UILabel LabelNew { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LabelDescription != null) {
				LabelDescription.Dispose ();
				LabelDescription = null;
			}

			if (LabelNew != null) {
				LabelNew.Dispose ();
				LabelNew = null;
			}
		}
	}
}
