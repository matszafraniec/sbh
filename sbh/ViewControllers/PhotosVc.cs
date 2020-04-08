using Foundation;
using sbh.Cells;
using sbh.Classes;
using sbh.Classes.Enums;
using sbh.Helpers;
using sbh.Services;
using System;
using System.Collections.Generic;
using UIKit;
using WebP.Touch;

namespace sbh.ViewControllers
{
    public partial class PhotosVc : UIViewController
    {
        readonly WebPCodec imageDecoder;
        private List<Photo> ItemsList;
        public event EventHandler<bool> PhotoZooming;
        private ContentType chosenContentType;

        public PhotosVc(IntPtr handle) : base(handle)
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

            ScrollViewImageZooming.ViewForZoomingInScrollView += (UIScrollView scrollView) => { return ImageViewZooming; };

            ScrollViewImageZooming.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {              
                UIView.Animate(0.4, () =>
                {
                    ViewOverlay.Alpha = ScrollViewImageZooming.Alpha = 0;
                    View.LayoutIfNeeded();
                });

                ScrollViewImageZooming.Hidden = ViewOverlay.Hidden = true;
                ViewOverlay.Alpha = ScrollViewImageZooming.Alpha = 0.4f;
                ScrollViewImageZooming.ZoomScale = 1;
                PhotoZooming?.Invoke(this, false);
            }));

            SetStyles();
        }

        private void SetStyles()
        {
            ScrollViewImageZooming.Hidden = ViewOverlay.Hidden = true;
            ScrollViewImageZooming.MinimumZoomScale = 1.0f;
            ScrollViewImageZooming.MaximumZoomScale = 5.0f;

            ViewOverlay.BackgroundColor = AppColors.NaturalBlack;
            ViewOverlay.Alpha = ScrollViewImageZooming.Alpha = 0.3f;
        }

        public void PopulateData(ContentType contentType = ContentType.FirstLoad)
        {
            if (chosenContentType == contentType && chosenContentType != ContentType.FirstLoad)
                return;

            chosenContentType = contentType;

            switch(contentType)
            {
                case ContentType.Bydgoszcz1945:
                    ItemsList = ContentServices.Bydgoszcz1945Photos;
                    break;
                case ContentType.MarianRejewski:
                    ItemsList = ContentServices.MarianRejewskiPhotos;
                    break;
                default:
                    ItemsList = ContentServices.Bydgoszcz1920Photos;
                    break;
            }

            TableViewPhotoItems.Source = new PhotoItemsTableViewSource(this);
            TableViewPhotoItems.ReloadData();

            var indexPath = NSIndexPath.FromItemSection(0, 0);
            TableViewPhotoItems.ScrollToRow(indexPath, UITableViewScrollPosition.Top, true);
        }

        private void InitializeData()
        {
            if(ContentServices.Bydgoszcz1920Photos == null)
            {
                ContentServices.Bydgoszcz1920Photos = new List<Photo>
                {
                    new Photo
                    {
                        Id = 1,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1920_photo1", "webp")),
                        Description = AppStrings.Bydgoszcz1920_Photo_1
                    },
                    new Photo
                    {
                        Id = 2,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1920_photo2", "webp")),
                        Description = AppStrings.Bydgoszcz1920_Photo_2
                    },
                    new Photo
                    {
                        Id = 3,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1920_photo3", "webp")),
                        Description = AppStrings.Bydgoszcz1920_Photo_3
                    },
                    new Photo
                    {
                        Id = 4,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1920_photo4", "webp")),
                        Description = AppStrings.Bydgoszcz1920_Photo_4
                    },
                    new Photo
                    {
                        Id = 5,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1920_photo5", "webp")),
                        Description = AppStrings.Bydgoszcz1920_Photo_5
                    },
                    new Photo
                    {
                        Id = 6,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1920_photo6", "webp")),
                        Description = AppStrings.Bydgoszcz1920_Photo_6,
                    }
                };
            }

            if (ContentServices.Bydgoszcz1945Photos == null)
            {
                ContentServices.Bydgoszcz1945Photos = new List<Photo>
                {
                    new Photo
                    {
                        Id = 1,
                        Image = UIImage.FromBundle("Images/bydgoszcz1945_photo1"),
                        Description = AppStrings.Bydgoszcz1945_Photo_1,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 2,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1945_photo2", "webp")),
                        Description = AppStrings.Bydgoszcz1945_Photo_2,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 3,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1945_photo3", "webp")),
                        Description = AppStrings.Bydgoszcz1945_Photo_3,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 4,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1945_photo4", "webp")),
                        Description = AppStrings.Bydgoszcz1945_Photo_4,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 5,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1945_photo5", "webp")),
                        Description = AppStrings.Bydgoszcz1945_Photo_5,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 6,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1945_photo6", "webp")),
                        Description = AppStrings.Bydgoszcz1945_Photo_6,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 7,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/bydgoszcz1945_photo7", "webp")),
                        Description = AppStrings.Bydgoszcz1945_Photo_7,
                        IsNew = true
                    }
                };
            }

            if (ContentServices.MarianRejewskiPhotos == null)
            {
                ContentServices.MarianRejewskiPhotos = new List<Photo>
                {
                    new Photo
                    {
                        Id = 1,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/rejewski_photo1", "webp")),
                        Description = AppStrings.MarianRejewski_Photo_1,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 2,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/rejewski_photo2", "webp")),
                        Description = AppStrings.MarianRejewski_Photo_2,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 3,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/rejewski_photo3", "webp")),
                        Description = AppStrings.MarianRejewski_Photo_3,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 4,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/rejewski_photo4", "webp")),
                        Description = AppStrings.MarianRejewski_Photo_4,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 5,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/rejewski_photo5", "webp")),
                        Description = AppStrings.MarianRejewski_Photo_5,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 6,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/rejewski_photo6", "webp")),
                        Description = AppStrings.MarianRejewski_Photo_6,
                        IsNew = true
                    },
                    new Photo
                    {
                        Id = 7,
                        Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/rejewski_photo7", "webp")),
                        Description = AppStrings.MarianRejewski_Photo_7,
                        IsNew = true
                    }
                };
            }
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

        internal class PhotoItemsTableViewSource : UITableViewSource
        {
            readonly PhotosVc vc;
            private readonly List<Item> plainItems;
            public enum ItemType { Photo, Footer }
            public class Item
            {
                public ItemType Type { get; set; }
                public Photo Photo { get; set; }
            }
            

            public PhotoItemsTableViewSource(PhotosVc vc)
            {
                this.vc = vc;

                plainItems = new List<Item>();

                foreach(var photo in vc.ItemsList)
                    plainItems.Add(new Item { Type = ItemType.Photo, Photo = photo });

                if(vc.chosenContentType == ContentType.FirstLoad || vc.chosenContentType == ContentType.Bydgoszcz1920)
                    plainItems.Add(new Item { Type = ItemType.Footer });
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                if(plainItems[indexPath.Row].Type == ItemType.Photo)
                {
                    var cell = (PhotoItemCell)tableView.DequeueReusableCell("PhotoItemCell");
                    cell.Setup(vc.ItemsList[indexPath.Row]);
                    return cell;
                }
                else
                {
                    var cell = (PhotoFooterItemCell)tableView.DequeueReusableCell("PhotoFooterItemCell");
                    cell.Setup();
                    return cell;
                }
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                if (vc.chosenContentType == ContentType.FirstLoad || vc.chosenContentType == ContentType.Bydgoszcz1920)
                    return vc.ItemsList.Count + 1;
                else
                    return vc.ItemsList.Count;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.DeselectRow(indexPath, true);

                if (plainItems[indexPath.Row].Type == ItemType.Footer)
                    return;

                vc.ImageViewZooming.Image = vc.ItemsList[indexPath.Row].Image;
                vc.ScrollViewImageZooming.Hidden = vc.ViewOverlay.Hidden = false;

                UIView.Animate(0.4, () =>
                {
                    vc.ScrollViewImageZooming.Alpha = 1;
                    vc.ViewOverlay.Alpha = 0.85f;
                    vc.View.LayoutIfNeeded();
                }); 
                vc.PhotoZooming?.Invoke(this, true);
            }
        }
    }
}