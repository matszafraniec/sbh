using Foundation;
using UIKit;

namespace sbh.Helpers
{
    public class YoutubeHelper
    {
        public static void OpenYoutube(string videoIdentifier)
        {
            var youtubeUrl = new NSUrl("youtube://" + videoIdentifier);

            //Check if app exits
            if (UIApplication.SharedApplication.CanOpenUrl(youtubeUrl))
            {
                UIApplication.SharedApplication.OpenUrl(youtubeUrl);
            }
            //If not, open AppStore
            else
            {
                var appStoreURL = new NSUrl("itms-apps://itunes.apple.com/app/youtube-watch-listen-stream/id544007664");

                if (UIApplication.SharedApplication.CanOpenUrl(appStoreURL))
                {
                    UIApplication.SharedApplication.OpenUrl(appStoreURL);
                }
            }
        }
    }
}
