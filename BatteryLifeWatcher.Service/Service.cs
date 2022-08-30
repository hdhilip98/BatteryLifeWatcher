using BatteryLifeWatcher.Core;

namespace BatteryLifeWatcher.Service {
    internal class Service {
        private Watcher _watcher;
        public void Start(WatcherConfig config) {
            _watcher = new Watcher(config);
            _watcher.Start();
        }

        public void Stop() {
            _watcher.Stop();
            _watcher = null;
        }
    }
}
