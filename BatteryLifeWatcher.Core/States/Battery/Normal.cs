using BatteryLifeWatcher.Core.Helpers;
using BatteryLifeWatcher.Core.Services;

namespace BatteryLifeWatcher.Core.States.Battery {
    internal class Normal : IBatteryState {
        private readonly WatcherConfig _config;

        public Normal(WatcherConfig config) {
            _config = config;
        }

        public IBatteryState GetNextState() {
            if (IsLow())
                return new Low(_config);

            if (IsHigh())
                return new High(_config);

            return this;
        }

        public void ProcessAlarm(AlarmService alarm) {
            alarm.Stop();
        }

        private bool IsLow() => BatteryHelpers.GetBatteryLifePercent() <= _config.MinPowerLevel;

        private bool IsHigh() => BatteryHelpers.GetBatteryLifePercent() >= _config.MaxPowerLevel;
    }
}
