using Foundation;
using System;
using sbh.Cells;
using sbh.Classes;
using System.Collections.Generic;
using UIKit;
using sbh.Classes.Enums;
using sbh.Services;

namespace sbh.ViewControllers
{
    public partial class CuriositiesVc : UIViewController
    {
        public List<Curiosity> ItemsList;
        private ContentType chosenContentType;

        public CuriositiesVc (IntPtr handle) : base (handle)
        {
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
            if (ContentServices.Bydgoszcz1920Curiosities == null)
            {
                ContentServices.Bydgoszcz1920Curiosities = new List<Curiosity>
                {
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_1 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_2 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_3 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_4 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_5 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_6 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_7 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_8 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_9 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_10 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_11 },
                    new Curiosity { Description = AppStrings.Bydgoszcz1920_Curiosity_12 }
                };
            }

            if (ContentServices.Bydgoszcz1945Curiosities == null)
            {
                ContentServices.Bydgoszcz1945Curiosities = new List<Curiosity>
                {
                    new Curiosity { Description = AppStrings.Bydgoszcz1945_Curiosity_1, IsNew = true },
                    new Curiosity { Description = AppStrings.Bydgoszcz1945_Curiosity_2, IsNew = true },
                    new Curiosity { Description = AppStrings.Bydgoszcz1945_Curiosity_3, IsNew = true },
                    new Curiosity { Description = AppStrings.Bydgoszcz1945_Curiosity_4, IsNew = true }
                };
            }

            if (ContentServices.MarianRejewskiCuriosities == null)
            {
                ContentServices.MarianRejewskiCuriosities = new List<Curiosity>
                {
                    new Curiosity { Description = AppStrings.MarianRejewski_Curiosity_1, IsNew = true },
                    new Curiosity { Description = AppStrings.MarianRejewski_Curiosity_2, IsNew = true },
                    new Curiosity { Description = AppStrings.MarianRejewski_Curiosity_3, IsNew = true },
                    new Curiosity { Description = AppStrings.MarianRejewski_Curiosity_4, IsNew = true },
                    new Curiosity { Description = AppStrings.MarianRejewski_Curiosity_5, IsNew = true },
                    new Curiosity { Description = AppStrings.MarianRejewski_Curiosity_6, IsNew = true },
                    new Curiosity { Description = AppStrings.MarianRejewski_Curiosity_7, IsNew = true }
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
                    ItemsList = ContentServices.Bydgoszcz1945Curiosities;
                    break;
                case ContentType.MarianRejewski:
                    ItemsList = ContentServices.MarianRejewskiCuriosities;
                    break;
                default:
                    ItemsList = ContentServices.Bydgoszcz1920Curiosities;
                    break;
            }

            TableViewCuriosityItems.Source = new CuriosityItemsTableViewSource(this);
            TableViewCuriosityItems.ReloadData();

            var indexPath = NSIndexPath.FromItemSection(0, 0);
            TableViewCuriosityItems.ScrollToRow(indexPath, UITableViewScrollPosition.Top, true);
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

        internal class CuriosityItemsTableViewSource : UITableViewSource
        {
            CuriositiesVc vc;

            public CuriosityItemsTableViewSource(CuriositiesVc vc)
            {
                this.vc = vc;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = (CuriosityItemCell)tableView.DequeueReusableCell("CuriosityItemCell");
                cell.Setup(vc.ItemsList[indexPath.Row]);
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return vc.ItemsList.Count;
            }
        }
    }
}