using System.Media;

namespace BatteryLifeWatcher.Core.States.Alarm {
    internal class Off : IAlarmState {
        private readonly SoundPlayer _player;

        public Off(SoundPlayer player) {
            _player = player;
        }

        public IAlarmState Start() {
            _player.PlayLooping();
            return new On(_player);
        }

        public IAlarmState Stop() {
            return this;
        }
    }
}
