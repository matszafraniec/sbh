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
	[Register ("AuthorTeamItemCell")]
	partial class AuthorTeamItemCell
	{
		[Outlet]
		UIKit.UILabel LabelTeamHeader { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LabelTeamHeader != null) {
				LabelTeamHeader.Dispose ();
				LabelTeamHeader = null;
			}
		}
	}
}
