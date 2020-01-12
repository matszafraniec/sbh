using Foundation;
using sbh.Cells;
using sbh.Classes;
using System;
using System.Collections.Generic;
using UIKit;

namespace sbh.ViewControllers
{
    public partial class MuseumVc : UIViewController
    {
        public List<Museum> ItemsList;

        public MuseumVc (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ItemsList = new List<Museum>
            {
                new Museum
                {
                    Name = "Muzeum Wojsk Lądowych",
                    Address1 = "ul. Czerkaska 2",
                    Address2 = "85-641 Bydgoszcz",
                    Address3 = "tel. 261 412 026"
                },
                new Museum
                {
                    Name = "Muzeum Okręgowe im. Leona Wyczółkowskiego w Bydgoszczy",
                    Address1 = "Dział Edukacji i Promocji, ul. Mennica 6",
                    Address2 = "85-112 Bydgoszcz",
                    Address3 = "tel. 52 5859910"
                },
                new Museum
                {
                    Name = "Izba Pamięci Adama Grzymały-Siedleckiego - Pracownia Teatrologiczna",
                    Address1 = "ul. Libelta 5",
                    Address2 = "85-080 Bydgoszcz",
                    Address3 = "tel. 573 313 566"
                },
                new Museum
                {
                    Name = "Wojewódzka i Miejska Biblioteka Publiczna im. dr. Witolda Bełzy",
                    Address1 = "ul. Stary Rynek 22-24",
                    Address2 = "85-105 Bydgoszcz",
                    Address3 = "Dział Udostępniania Zbiorów: tel. 52 3399250"
                }
            };

            TableViewMuseumItems.Source = new MuseumItemsTableViewSource(this);
            TableViewMuseumItems.ReloadData();
        }

        internal class MuseumItemsTableViewSource : UITableViewSource
        {
            MuseumVc _vc;

            public MuseumItemsTableViewSource(MuseumVc vc)
            {
                _vc = vc;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = (MuseumItemCell)tableView.DequeueReusableCell("MuseumItemCell");
                cell.Setup(_vc.ItemsList[indexPath.Row]);
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _vc.ItemsList.Count;
            }
        }
    }
}