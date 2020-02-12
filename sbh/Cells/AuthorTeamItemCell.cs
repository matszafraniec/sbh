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

            LabelTeamHeader.Text = "Zespół testerów w składzie:";
        }
    }
}