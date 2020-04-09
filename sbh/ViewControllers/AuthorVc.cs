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

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
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
                    ImagePath = "Images/Authors/author"
                },
                new Author
                {
                    Name = "Sławomir Ciecierski",
                    Description = "Kierownik projektu, programista Java, kompozytor. Wersja aplikacji na Android.",
                    ImagePath = "Images/Authors/developer-stan"
                },
                new Author
                {
                    Name = "Mateusz Szafraniec",
                    Description = "Programista aplikacji mobilnych. Wersja aplikacji na iOS.",
                    ImagePath = "Images/Authors/developer-mat"
                },
                new Author
                {
                    Name = "Konrad Stankiewicz",
                    ImagePath = "Images/Authors/tester-ks"
                },
                new Author
                {
                    Name = "Paweł Cymbaluk",
                    ImagePath = "Images/Authors/tester-pc"
                },
                new Author
                {
                    Name = "Łukasz Kamiński",
                    ImagePath = "Images/Authors/tester-lk"
                },
                new Author
                {
                    Name = "Ewelina Sierżańska",
                    ImagePath = "Images/Authors/tester-es"
                },
                new Author
                {
                    Name = "Marcin Hyba",
                    ImagePath = "Images/Authors/tester-mh"
                }
            };

            TableViewAuthorItems.Source = new AuthorItemsTableViewSource(this);
            TableViewAuthorItems.ReloadData();
        }

        internal class AuthorItemsTableViewSource : UITableViewSource
        {
            AuthorVc vc;
            private readonly List<Item> plainItems;
            public enum ItemType { Author, Team }
            public class Item
            {
                public ItemType Type { get; set; }
                public Author Author { get; set; }
            }

            public AuthorItemsTableViewSource(AuthorVc vc)
            {
                this.vc = vc;

                plainItems = new List<Item>();

                for (int i = 0; i <= 2; i++)
                    plainItems.Add(new Item { Type = ItemType.Author, Author = vc.ItemsList[i] });

                plainItems.Add(new Item { Type = ItemType.Team });

                for (int i = 3; i <= 7; i++)
                    plainItems.Add(new Item { Type = ItemType.Author, Author = vc.ItemsList[i] });
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                if (plainItems[indexPath.Row].Type == ItemType.Author)
                {
                    var cell = (AuthorItemCell)tableView.DequeueReusableCell("AuthorItemCell");
                    cell.Setup(plainItems[indexPath.Row].Author);
                    return cell;
                }
                else
                {
                    var cell = (AuthorTeamItemCell)tableView.DequeueReusableCell("AuthorTeamItemCell");
                    cell.Setup();
                    return cell;
                }
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return plainItems.Count;
            }
        }
    }
}