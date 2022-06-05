using System;
using System.Threading;

namespace BatteryLifeWatcher.Core {
    public class Watcher {
        private readonly WatcherConfig _config;

        private Timer _timer;

        public Watcher(WatcherConfig config) {
            _config = config;
        }

        public void Start() {
            _timer = new Timer(OnTimerElapsed);
            _timer.Change(0, _config.PollingInterval);
        }
        public void Stop() {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer = null;
        }
        private void OnTimerElapsed(object state) {
            throw new NotImplementedException();
        }
    }
}
