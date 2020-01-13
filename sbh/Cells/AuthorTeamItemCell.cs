using Foundation;
using System;
using UIKit;

namespace sbh.Cells
{
    public partial class AuthorTeamItemCell : UITableViewCell
    {
        public AuthorTeamItemCell (IntPtr handle) : base (handle)
        {
        }

        public void Setup()
        {
            LabelTeamHeader.Font = UIFont.BoldSystemFontOfSize(18);
            LabelTeamDescription.Font = UIFont.SystemFontOfSize(15);

            LabelTeamHeader.Text = "Zespół testerów:";
            LabelTeamDescription.Text = "Konrad Stankiewicz,\nMarcin Hyba,\nPaweł Cymbaluk.";
        }
    }
}