using BatteryLifeWatcher.Core.States.Alarm;
using System;
using System.IO;
using System.Media;

namespace BatteryLifeWatcher.Core.Services {
    internal class AlarmService {
        private readonly SoundPlayer _player;
        private IAlarmState _currentState;

        public AlarmService(string soundPath) {
            if (string.IsNullOrEmpty(soundPath))
                throw new ArgumentNullException();

            if (!File.Exists(soundPath))
                throw new ArgumentException("Sound file does not exist.");

            if (Path.GetExtension(soundPath) != ".wav")
                throw new ArgumentException("Invalid sound format. Only .wav files are supported");

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
