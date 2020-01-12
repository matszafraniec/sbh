using Foundation;
using sbh.Cells;
using sbh.Classes;
using System;
using System.Collections.Generic;
using UIKit;

namespace sbh.ViewControllers
{
    public partial class AuthorVc : UIViewController
    {
        public List<Author> ItemsList;

        public AuthorVc (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ItemsList = new List<Author>
            {
                new Author
                {
                    Name = "Krzysztof Drozdowski",
                    Description = "Urodził się 15.03.1985 roku w Bydgoszczy. Historyk, społecznik, działacz na rzecz podniesienia świadomości historycznej w Bydgoszczy i regionie. Członek Towarzystwa Miłośników Miasta Bydgoszczy. Doprowadził do wznowienia przez IPN śledztwa w sprawie fordońskiej Doliny Śmierci.\n\nJest autorem publikacji:\n- Bitwa o Bydgoszcz 1945,\n- Bydgoszcz wita Armię,\n- Graudenz 1945. Ostatnie tchnienie,\n- Bydgoska architektura militarna w latach 1772-1945,\n- Z lotu ptaka: Bydgoszcz na fotografii lotniczej w latach 1911-1945,\n- Tajemnica Doliny Śmierci. Droga do prawdy,\n- Artylerzysta Piłsudskiego Wspomnienia gen. Jana Chmurowicza,\n- Wojenne sekrety Bydgoszczy.\n\nJest również współautorem publikacji:\n- Bitwa o Bydgoszcz 1945, walki, wspomnienia, relacje,\n- 16 Pułk Ułanów Wielkopolskich im. gen. dyw. Gustawa Orlicz-Dreszera 1918-1939,\n- Świat odosobniony. Bydgoska służba penitencjarna w latach 1920-1939.\n\nPonadto opublikował ponad 40 artykułów naukowych i popularnonaukowych.",
                    ImagePath = "Images/author"
                },
                new Author
                {
                    Name = "Sławomir Ciecierski",
                    Description = "Kierownik projektu, programista Java, kompozytor.",
                    ImagePath = "Images/developer-stan"
                }
            };

            TableViewAuthorItems.Source = new AuthorItemsTableViewSource(this);
            TableViewAuthorItems.ReloadData();
        }

        internal class AuthorItemsTableViewSource : UITableViewSource
        {
            AuthorVc _vc;

            public AuthorItemsTableViewSource(AuthorVc vc)
            {
                _vc = vc;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = (AuthorItemCell)tableView.DequeueReusableCell("AuthorItemCell");
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