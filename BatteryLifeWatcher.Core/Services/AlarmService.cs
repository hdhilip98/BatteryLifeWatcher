using BatteryLifeWatcher.Core.States.Alarm;
using System.Media;

namespace BatteryLifeWatcher.Core.Services {
    internal class AlarmService {
        private readonly SoundPlayer _player;
        private IAlarmState _currentState;

        public AlarmService(string soundPath) {
            _player = new SoundPlayer(soundPath);
            _currentState = new Off(_player);
        }

        public void Start() {
            _currentState = _currentState.Start();
        }

        public void Stop() {
            _currentState = _currentState.Stop();
        }
    }
}
