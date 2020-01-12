using System;
using UIKit;

namespace sbh.Helpers
{
    public static class Stylization
    {
        public static UIView AddAlfaAnimationTap(this UIView view)
        {
            view.AddGestureRecognizer(new ViewTouchRecognizer(() => view.Alpha = 0.7f, () => view.Alpha = 1.0f));
            return view;
        }
    }
}
