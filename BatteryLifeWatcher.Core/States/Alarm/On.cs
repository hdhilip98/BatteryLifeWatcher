using System.Media;

namespace BatteryLifeWatcher.Core.States.Alarm {
    internal class On : IAlarmState {
        private readonly SoundPlayer _player;

        public On(SoundPlayer player) {
            _player = player;
        }

        public IAlarmState Start() {
            return this;
        }

        public IAlarmState Stop() {
            _player.Stop();
            return new Off(_player);
        }
    }
}
