using System.Collections.Generic;
using sbh.Classes;

namespace sbh.Services
{
    public static class ContentServices
    {
        //Photos
        public static List<Photo> Bydgoszcz1920Photos { get; set; }
        public static List<Photo> Bydgoszcz1945Photos { get; set; }
        public static List<Photo> MarianRejewskiPhotos { get; set; }

        //Media
        public static List<Media> Bydgoszcz1920Media { get; set; }
        public static List<Media> Bydgoszcz1945Media { get; set; }
        public static List<Media> MarianRejewskiMedia { get; set; }

        //Curiosities
        public static List<Curiosity> Bydgoszcz1920Curiosities { get; set; }
        public static List<Curiosity> Bydgoszcz1945Curiosities { get; set; }
        public static List<Curiosity> MarianRejewskiCuriosities { get; set; }
    }
}
