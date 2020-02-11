using CoreGraphics;
using Foundation;
using sbh.Cells;
using sbh.Classes;
using sbh.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using WebP.Touch;

namespace sbh
{
    public partial class MediaVc : UIViewController
    {
        public List<Media> ItemsList;

        public MediaVc (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ItemsList = new List<Media>
            {
                new Media
                {
                    Id = 1,
                    Description = "W drodze do wolności. Bydgoszcz w 1920 roku",
                    Image = UIImage.FromBundle("Images/image-movie-1"),
                    ContentIdentifier = "http://www.youtube.com/watch?v=JD5ths5Jusg",
                    Type = "Filmy"
                },
                new Media
                {
                    Id = 2,
                    Description = "Wkroczenie Wojska Polskiego do Bydgoszczy styczeń 1920 rekonstrukcja",
                    Image = UIImage.FromBundle("Images/image-movie-2"),
                    ContentIdentifier = "http://www.youtube.com/watch?v=ZpCPobW187k",
                    Type = "Filmy"
                },
                new Media
                {
                    Id = 3,
                    Description = "Makieta Starego Rynku w Bydgoszczy 1920 rok",
                    Image = UIImage.FromBundle("Images/image-movie-3"),
                    ContentIdentifier = "http://www.youtube.com/watch?v=WfSphW3-hzs",
                    Type = "Filmy"
                },
                new Media
                {
                    Id = 4,
                    Description = "Bydgoszcz100 Tryptyk",
                    Image = UIImage.FromBundle("Images/image-music-1"),
                    ContentIdentifier = "https://soundcloud.com/ciecierski/sets/bydgoszcz100",
                    Type = "Muzyka"
                }
            };

            TableViewMediaItems.Source = new MediaItemsTableViewSource(this);
            TableViewMediaItems.ReloadData();
        }

        internal class MediaItemsTableViewSource : UITableViewSource
        {
            MediaVc vc;
            private Dictionary<Tuple<int, string>, bool> sectionsTitles;

            public MediaItemsTableViewSource(MediaVc vc)
            {
                this.vc = vc;
                sectionsTitles = new Dictionary<Tuple<int, string>, bool>();

                var index = 0;
                foreach(var category in vc.ItemsList.Select(x => x.Type).Distinct())
                {
                    sectionsTitles.Add(new Tuple<int, string>(index, category), true);
                    index++;
                }

            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var list = vc.ItemsList.Where(x => x.Type == sectionsTitles.Keys.FirstOrDefault(y => y.Item1 == indexPath.Section).Item2).ToList();

                var cell = (MediaItemCell)tableView.DequeueReusableCell("MediaItemCell");
                cell.Setup(list[indexPath.Row]);
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                if (sectionsTitles.FirstOrDefault(x => x.Key.Item1 == section).Value == true)
                {
                    var key = sectionsTitles.FirstOrDefault(x => x.Key.Item1 == section).Key.Item2;
                    return vc.ItemsList.Count(x => x.Type == key);
                }

                return 0;
            }

            public override nint NumberOfSections(UITableView tableView)
            {
                return sectionsTitles.Count;
            }

            public override nfloat GetHeightForHeader(UITableView tableView, nint section)
            {
                return 45;
            }

            public override UIView GetViewForHeader(UITableView tableView, nint section)
            {
                var headerView = new UIView(new CGRect(0, 0, tableView.Frame.Width, 45))
                {
                    BackgroundColor = UIColor.Clear,
                    Tag = section
                };

                var headerString = new UILabel(new CGRect(20, 5, tableView.Frame.Width - 60, 30));
                headerString.Font = UIFont.BoldSystemFontOfSize(25);
                headerString.TextColor = AppColors.NaturalBlack;
                headerString.Text = sectionsTitles.FirstOrDefault(x => x.Key.Item1 == section).Key.Item2;
                headerView.Add(headerString);

                var headerTapped = new UITapGestureRecognizer((UITapGestureRecognizer tap) => {

                    var tapView = tap.View;

                    var collapsed = sectionsTitles.FirstOrDefault(x => x.Key.Item1 == tapView.Tag).Value;
                    collapsed = !collapsed;
                    sectionsTitles[sectionsTitles.FirstOrDefault(x => x.Key.Item1 == tapView.Tag).Key] = collapsed;

                    var sectionToReload = NSIndexSet.FromIndex(tapView.Tag);
                    tableView.ReloadSections(sectionToReload, UITableViewRowAnimation.Fade);
                });
                headerView.AddGestureRecognizer(headerTapped);

                return headerView;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.DeselectRow(indexPath, true);

                var list = vc.ItemsList.Where(x => x.Type == sectionsTitles.Keys.FirstOrDefault(y => y.Item1 == indexPath.Section).Item2).ToList();

                UIApplication.SharedApplication.OpenUrl(new NSUrl(list[indexPath.Row].ContentIdentifier));
            }
        }
    }
}