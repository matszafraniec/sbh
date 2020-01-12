using System;
using UIKit;
using Foundation;

namespace sbh.Helpers
{
    public class ViewTouchRecognizer : UIGestureRecognizer
    {
        private Action _began;
        private Action _ended;
        private UIView _view;
        private Timer _timer;

        public ViewTouchRecognizer(Action touchesBegan, Action touchesEnded)
        {
            _began = touchesBegan;
            _ended = touchesEnded;
        }
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            _began?.Invoke();
            TouchesMoved(touches, evt);
        }
        public override void TouchesEnded(NSSet touches, UIEvent evt) => _ended.Invoke();
        public override void TouchesCancelled(NSSet touches, UIEvent evt) => _ended.Invoke();
        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            if (_timer != null)
                _timer.Dispose();
            _timer = null;
            _timer = new Timer(TimeSpan.FromMilliseconds(300));
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }
        void _timer_Elapsed(object sender, EventArgs e)
        {
            if (_timer != null)
                _timer.Dispose();
            _timer = null;
            InvokeOnMainThread(_ended.Invoke);
        }
    }
}