using CoreGraphics;
using Foundation;
using sbh.Cells;
using sbh.Classes;
using sbh.Classes.Enums;
using sbh.Helpers;
using sbh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using WebP.Touch;

namespace sbh
{
    public partial class MediaVc : UIViewController
    {
        readonly WebPCodec imageDecoder;
        public List<Media> ItemsList;
        private ContentType chosenContentType;

        public MediaVc (IntPtr handle) : base (handle)
        {
            imageDecoder = new WebPCodec();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeData();

            PopulateData();

            //init with Bydgoszcz1920
            ChosenContentType = ContentType.Bydgoszcz1920;
        }

        private void InitializeData()
        {
            if (ContentServices.Bydgoszcz1920Media == null)
            {
                ContentServices.Bydgoszcz1920Media = new List<Media>
                {
                    new Media
                    {
                        Id = 1,
                        Description = AppStrings.Bydgoszcz1920_Media_1,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1920/media1", "webp")),
                        ContentIdentifier = "http://www.youtube.com/watch?v=JD5ths5Jusg",
                        Type = "Filmy"
                    },
                    new Media
                    {
                        Id = 2,
                        Description = AppStrings.Bydgoszcz1920_Media_2,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1920/media2", "webp")),
                        ContentIdentifier = "http://www.youtube.com/watch?v=ZpCPobW187k",
                        Type = "Filmy"
                    },
                    new Media
                    {
                        Id = 3,
                        Description = AppStrings.Bydgoszcz1920_Media_3,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1920/media3", "webp")),
                        ContentIdentifier = "http://www.youtube.com/watch?v=WfSphW3-hzs",
                        Type = "Filmy"
                    },
                    new Media
                    {
                        Id = 4,
                        Description = AppStrings.Bydgoszcz1920_Media_4,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1920/media4", "webp")),
                        ContentIdentifier = "https://soundcloud.com/ciecierski/sets/bydgoszcz100",
                        Type = "Muzyka"
                    }
                };
            }

            if (ContentServices.Bydgoszcz1945Media == null)
            {
                ContentServices.Bydgoszcz1945Media = new List<Media>
                {
                    new Media
                    {
                        Id = 1,
                        Description = AppStrings.Bydgoszcz1945_Media_1,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1945/media1", "webp")),
                        ContentIdentifier = "https://youtu.be/HnIS2twdA_0",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 2,
                        Description = AppStrings.Bydgoszcz1945_Media_2,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1945/media2", "webp")),
                        ContentIdentifier = "https://youtu.be/E_hUIuWVBGw",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 3,
                        Description = AppStrings.Bydgoszcz1945_Media_3,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1945/media3", "webp")),
                        ContentIdentifier = "https://youtu.be/I5ILcG_oAek",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 4,
                        Description = AppStrings.Bydgoszcz1945_Media_4,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Bydgoszcz1945/media4", "webp")),
                        ContentIdentifier = "https://m.soundcloud.com/ciecierski/bydgoszcz1945",
                        Type = "Muzyka",
                        IsNew = true
                    }
                };
            }

            if (ContentServices.MarianRejewskiMedia == null)
            {
                ContentServices.MarianRejewskiMedia = new List<Media>
                {
                    new Media
                    {
                        Id = 1,
                        Description = AppStrings.MarianRejewski_Media1,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media1", "webp")),
                        ContentIdentifier = "https://youtu.be/rGRu-D8j6ts",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 2,
                        Description = AppStrings.MarianRejewski_Media2,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media2", "webp")),
                        ContentIdentifier = "https://youtu.be/E53FkqwpHd0",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 3,
                        Description = AppStrings.MarianRejewski_Media3,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media3", "webp")),
                        ContentIdentifier = "https://youtu.be/UBlVONSA5ms",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 4,
                        Description = AppStrings.MarianRejewski_Media4,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media4", "webp")),
                        ContentIdentifier = "https://youtu.be/JQk7AuJMIjE",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 5,
                        Description = AppStrings.MarianRejewski_Media5,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media5", "webp")),
                        ContentIdentifier = "https://vod.tvp.pl/website/tajemnica-enigmy,40536155",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 6,
                        Description = AppStrings.MarianRejewski_Media6,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media6", "webp")),
                        ContentIdentifier = "https://vod.tvp.pl/video/z-bliska,polscy-pogromcy-enigmy-26122018,40794274",
                        Type = "Filmy",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 7,
                        Description = AppStrings.MarianRejewski_Media7,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media7", "webp")),
                        ContentIdentifier = "https://m.soundcloud.com/ciecierski/enigma",
                        Type = "Muzyka",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 8,
                        Description = AppStrings.MarianRejewski_Media8,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media8", "webp")),
                        ContentIdentifier = "https://www.bydgoszcz.pl/aktualnosci/tresc/marian-rejewski-uhonorowany-w-krakowie/",
                        Type = "WWW",
                        IsNew = true
                    },
                    new Media
                    {
                        Id = 9,
                        Description = AppStrings.MarianRejewski_Media9,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/Rejewski/media9", "webp")),
                        ContentIdentifier = "https://www.polskieradio.pl/39/156/Artykul/1488658,Kryptolog-Jak-Marian-Rejewski-zlamal-kod-Enigmy",
                        Type = "WWW",
                        IsNew = true
                    }
                };
            }
        }

        public void PopulateData(ContentType contentType = ContentType.FirstLoad)
        {
            if (chosenContentType == contentType && chosenContentType != ContentType.FirstLoad)
                return;

            chosenContentType = contentType;

            switch (contentType)
            {
                case ContentType.Bydgoszcz1945:
                    ItemsList = ContentServices.Bydgoszcz1945Media;
                    break;
                case ContentType.MarianRejewski:
                    ItemsList = ContentServices.MarianRejewskiMedia;
                    break;
                default:
                    ItemsList = ContentServices.Bydgoszcz1920Media;
                    break;
            }

            TableViewMediaItems.Source = new MediaItemsTableViewSource(this);
            TableViewMediaItems.ReloadData();

            var indexPath = NSIndexPath.FromItemSection(0, 0);
            TableViewMediaItems.ScrollToRow(indexPath, UITableViewScrollPosition.Top, true);
        }

        public ContentType ChosenContentType
        {
            get => chosenContentType;
            set
            {
                switch (value)
                {
                    case ContentType.Bydgoszcz1945:
                        PopulateData(ContentType.Bydgoszcz1945);
                        break;
                    case ContentType.MarianRejewski:
                        PopulateData(ContentType.MarianRejewski);
                        break;
                    default:
                        PopulateData(ContentType.Bydgoszcz1920);
                        break;
                }

                chosenContentType = value;
            }
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