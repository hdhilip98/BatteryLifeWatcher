using BatteryLifeWatcher.Core.Services;
using System.Threading;

namespace BatteryLifeWatcher.Core {
    public class Watcher {
        private const int POLLING_INTERVAL = 2000;
        private readonly BatteryService _batteryService;

        private Timer _timer;

        public Watcher(WatcherConfig config) {
            _batteryService = new BatteryService(config);
        }

        public void Start() {
            _timer = new Timer(OnTimerElapsed);
            _timer.Change(0, POLLING_INTERVAL);
        }

        public void Stop() {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer = null;
        }

        private void OnTimerElapsed(object state) {
            _batteryService.CheckBatteryLife();
        }
    }
}
