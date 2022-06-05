using BatteryLifeWatcher.Core.States.Battery;

namespace BatteryLifeWatcher.Core.Services {
    internal class BatteryService {
        private readonly AlarmService _alarmService;
        private IBatteryState _currentState;

        public BatteryService(WatcherConfig config) {
            _alarmService = new AlarmService(config.SoundPath);
            _currentState = new Normal(config);
        }

        public void CheckBatteryLife() {
            _currentState = _currentState.GetNextState();
            _currentState.ProcessAlarm(_alarmService);
        }
    }
}
