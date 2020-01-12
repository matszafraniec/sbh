using sbh.Classes;
using System;
using UIKit;

namespace sbh.Cells
{
    public partial class MuseumItemCell : UITableViewCell
    {
        public MuseumItemCell (IntPtr handle) : base (handle)
        {
        }

        public void Setup(Museum item)
        {
            SetStyles();

            LabelName.Text = item.Name;
            LabelAddress1.Text = item.Address1;
            LabelAddress2.Text = item.Address2;
            LabelAddress3.Text = item.Address3;
        }

        private void SetStyles()
        {
            LabelName.Font = UIFont.BoldSystemFontOfSize(18);
            LabelName.Lines = 3;
            LabelAddress1.Lines = LabelAddress3.Lines = 2;
            LabelAddress1.Font = LabelAddress2.Font = LabelAddress3.Font = UIFont.SystemFontOfSize(15);
        }
    }
}