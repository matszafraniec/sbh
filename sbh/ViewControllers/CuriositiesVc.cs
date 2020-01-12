using Foundation;
using System;
using sbh.Cells;
using sbh.Classes;
using System.Collections.Generic;
using UIKit;

namespace sbh.ViewControllers
{
    public partial class CuriositiesVc : UIViewController
    {
        public List<Curiosity> ItemsList;

        public CuriositiesVc (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ItemsList = new List<Curiosity>
            {
                new Curiosity { Description = "2 sierpnia 1914 r. w Bydgoszczy ogłoszono stan wojenny. Na lazarety zamieniono większość dużych obiektów w mieście, takich jak choćby sale gimnastyczne. Miesiąc od rozpoczęcia wojny w mieście istniało 10 lazaretów. Do końca 1914 roku ten stan powiększono o 100%, w których to lazaretach leczono jednocześnie nawet 3000 rannych żołnierzy." },
                new Curiosity { Description = "Przygotowania do powitania Wojska Polskiego w Bydgoszczy trwały już od lipca 1919 roku. Prace dekoracyjne w mieście zlecono bydgoskiemu architektowi Teofilowi Biernackiemu." },
                new Curiosity { Description = "Przed 1 kwietnia 1920 miasto składało się z pięciu zasadniczych części:\nStare Miasto: Miasto, Zamek, Wyspa Młyńska (dawniej Okole), Przedmieście Kujawskie,\nCzęść północna: Ludwikowo(Jachcice), Stacja kolejowa, Bocianowo I (Wielkie), Bocianowo II (Małe), Przedmieście Gdańskie, Grodztwo Zachodnie, Grodztwo Wschodnie, Cmentarze północne, Koszary północne, Koszary leśne, Szkoła wojenna, Boisko sportowe,\nCzęść zachodnia: Okole (dzisiejsze), Koszary ułańskie, Przedmieście Poznańskie,\nCzęść południowa: Szwederowo, Nowy Dwór, Bielice,\nCzęść wschodnia: Przedmieście Toruńskie, Probostwo, Wzgórze Wolności, Żupy\n\nRejony o największej powierzchni to: Grodztwo Wschodnie – 145 ha, Ludwikowo – 63,5 ha, Bocianowo I (Wielkie) – 60 ha." },
                new Curiosity { Description = "Nocą z 10 na 11 listopada 1918r. w mieście doszło do starcia grupki niemieckich żołnierzy z patrolem Rady Żołnierskiej. Incydent zakończył kilkoma ofiarami śmiertelnymi i kilkoma rannymi. Bunt wśród jednostek bydgoskiego garnizonu rozgorzał najpierw w 14 Pułku Piechoty im. Hrabiego von Schwerin (3 Pomorski)." },
                new Curiosity { Description = "Naczelna Rada Ludowa na miasto Bydgoszcz została powołana 16 listopada 1918 roku. Prezesem został wybrany Jan Biziel, sekretarzem Jan Teska, skarbnikiem Józef Milchert, a członkami zarządu Władysław Kużaj i Antoni Czarnecki." },
                new Curiosity { Description = "20 maja 1919 r. do restauracji Sikorskiego znajdującej się przy u. Gdańskiej wtargnęli członkowie Grenzschutzu i obrzucili granatami znajdujących się we wnętrzu zebranych Polaków.\n30 maja 1919 r. trzech żołnierzy Grenzschutzu wtargnęło na teren kościoła farnego i obrzucili kamieniami grotę Matki Boskiej z Lourdes.\nOd 18 stycznia 1919 r. do 21 stycznia 1920 roku trwała Konferencja Pokojowa w Paryżu.\n18 lutego 1919 r., doszło do potyczki pod Rynarzewem, która zakończyła się zdobyciem niemieckiego pociągu pancernego Panzerzug 22, który następnie został przemianowany na „Danuta”.\n25 listopada 1919 r.podpisano umowę o wycofaniu wojsk z odstąpionych obszarów oraz przekazaniu w ręce polskie zarządu cywilnego nad tymi obszarami." },
                new Curiosity { Description = "W nocy z 19 na 20 stycznia 1920r. przemalowano w biało-czerwone barwy wszystkie budki strażnicze stojące przy bramach koszarowych i ważniejszych wojskowych obiektach. Środki na zakup farby pochodziły z licznych zbiórek funduszy, w których hojnie uczestniczyli mieszkańcy Bydgoszczy" },
                new Curiosity { Description = "W bardzo krótkim czasie Bydgoszcz z typowo pruskiego miasta przerodziła się w pełnoprawną polską metropolię. Jeszcze dziesięć lat wcześniej Bydgoszcz była zamieszkiwana przez 19 % Polaków. Według danych z przełomu 1928/1929 r. Polacy stanowili 92% populacji miasta." },
                new Curiosity { Description = "Bydgoskie więzienie zostało przejęte przez podprokuratora przy Sądzie Okręgowym Jarosława Czarlińskiego oraz prokuratora krajowego Alfreda Jossè" },
                new Curiosity { Description = "Z gabinetu przeznaczonego dla Prezydenta usunięto portret Fryderyka II i zawieszono obraz przedstawiający poznański ratusz. Oczywiście uczyniono to z powodu braku portretów polskich przywódców, a nie uwielbienia do Poznania." },
                new Curiosity { Description = "20 stycznia 1920 roku w godzinach przedpołudniowych po ponad wiekowej niewoli w granice miasta wkroczyli pierwsi polscy żołnierze. Na Stary Rynek oddział ppłk. Witolda Butlera  wkroczył wraz z 3 szwadronem 2 Pułku Ułanów Wielkopolskich pod dowództwem rtm. Stanisława Zakrzewskiego  punktualnie o godz. 12.00. 22 stycznia 1920r. po uroczystościach na Rynku odbyła się defilada wojsk ulicą Gdańską przed Generałem Muśnickim, który stał na placu Wolności (Weltziena) w otoczeniu swego sztabu i licznej świty." }
            };

            TableViewCuriosityItems.Source = new CuriosityItemsTableViewSource(this);
            TableViewCuriosityItems.ReloadData();
        }

        internal class CuriosityItemsTableViewSource : UITableViewSource
        {
            CuriositiesVc _vc;

            public CuriosityItemsTableViewSource(CuriositiesVc vc)
            {
                _vc = vc;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = (CuriosityItemCell)tableView.DequeueReusableCell("CuriosityItemCell");
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