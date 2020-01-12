using System;
using System.Threading.Tasks;

namespace sbh.Helpers
{
    public class Timer : IDisposable
    {
        private readonly TimeSpan _interval;
        private bool _enabled;
        public Timer(TimeSpan interval)
        {
            _interval = interval;
            _enabled = false;
        }
        public event EventHandler Elapsed;
        public void Start()
        {
            _enabled = true;
            Task.Run(async () =>
            {
                while (_enabled)
                {
                    await Task.Delay(_interval);
                    Elapsed?.Invoke(this, null);
                }
            });
        }
        public void Dispose()
        {
            _enabled = false;
            Elapsed = null;
        }
    }
}