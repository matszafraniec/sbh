using CoreGraphics;
using CoreImage;
using Foundation;
using sbh.Cells;
using sbh.Classes;
using sbh.Helpers;
using System;
using System.Collections.Generic;
using UIKit;
using WebP.Touch;

namespace sbh.ViewControllers
{
    public partial class PhotosVc : UIViewController
    {
        WebPCodec imageDecoder;
        public List<Photo> ItemsList;
        public event EventHandler<bool> PhotoZooming;

        public PhotosVc(IntPtr handle) : base(handle)
        {
            imageDecoder = new WebPCodec();            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetStyles();

            ItemsList = new List<Photo>
            {
                new Photo
                {
                    Id = 1,
                    Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/photo1", "webp")),
                    Description = "Powitanie pierwszych oddziałów wojska polskiego po wkroczeniu do miasta w dniu 20 stycznia 1920r.  Na środku stoi ppłk Witold Butler dowódca oddziału saperów oraz pierwszy wojskowy komendant miasta. Przed nim stoją przedstawiciele władz miasta i Podkomisariatu Naczelnej Rady Ludowej."
                },
                new Photo
                {
                    Id = 2,
                    Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/photo2", "webp")),
                    Description = "Pierwsze oddziały 15 Dywizji Piechoty oraz 16 Pułku Ułanów Wielkopolskich po wkroczeniu na płytę Starego Rynku.",
                },
                new Photo
                {
                    Id = 3,
                    Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/photo3", "webp")),
                    Description = "Orkiestra 16 Pułku Ułanów Wielkopolskich podczas defilady na ul. Gdańskiej w dniu 22 stycznia 1920 roku. Defiladę przyjmował dowódca Frontu Wielkopolskiego gen. Józef Dowbor-Muśnicki.",
                },
                new Photo
                {
                    Id = 4,
                    Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/photo4", "webp")),
                    Description = "22 stycznia 1920r. Zebrane wojska wielkopolskie na płycie Starego Rynku podczas polowej mszy świętej.",
                },
                new Photo
                {
                    Id = 5,
                    Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/photo5", "webp")),
                    Description = "Jan Biziel podczas przemówienia do zebranych mieszkańców miasta w trakcie powitania gen. Józefa Dowbora-Muśnickiego w dniu 22 stycznia 1920r.",
                },
                new Photo
                {
                    Id = 6,
                    Image = imageDecoder.Decode(NSBundle.MainBundle.PathForResource("Images/photo6", "webp")),
                    Description = "Generał Józef Dowbor-Muśnicki w trakcie przemówienia po mszy św. polowej odprawionej na płycie Starego Rynku w dniu 22 stycznia 1920r.",
                },
            };

            TableViewPhotoItems.Source = new PhotoItemsTableViewSource(this);
            TableViewPhotoItems.ReloadData();

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
        }

        private void SetStyles()
        {
            LabelSourceInfo.Text = "Zdjęcia pochodzą z Muzeum Wojsk Lądowych.";
            LabelSourceInfo.TextColor = AppColors.DarkRed;
            LabelSourceInfo.Font = UIFont.ItalicSystemFontOfSize(15);

            ScrollViewImageZooming.Hidden = ViewOverlay.Hidden = true;
            ScrollViewImageZooming.MinimumZoomScale = 1.0f;
            ScrollViewImageZooming.MaximumZoomScale = 5.0f;

            ViewOverlay.BackgroundColor = AppColors.NaturalBlack;
            ViewOverlay.Alpha = ScrollViewImageZooming.Alpha = 0.3f;
        }

        internal class PhotoItemsTableViewSource : UITableViewSource
        {
            PhotosVc _vc;

            public PhotoItemsTableViewSource(PhotosVc vc)
            {
                _vc = vc;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = (PhotoItemCell)tableView.DequeueReusableCell("PhotoItemCell");
                cell.Setup(_vc.ItemsList[indexPath.Row]);
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _vc.ItemsList.Count;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.DeselectRow(indexPath, true);

                _vc.ImageViewZooming.Image = _vc.ItemsList[indexPath.Row].Image;

                _vc.ScrollViewImageZooming.Hidden = _vc.ViewOverlay.Hidden = false;

                UIView.Animate(0.4, () =>
                {
                    _vc.ScrollViewImageZooming.Alpha = 1;
                    _vc.ViewOverlay.Alpha = 0.85f;
                    _vc.View.LayoutIfNeeded();
                }); 
                _vc.PhotoZooming?.Invoke(this, true);
            }
        }
    }
}