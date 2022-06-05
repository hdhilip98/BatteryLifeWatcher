namespace BatteryLifeWatcher.Core {
    public class WatcherConfig
    {
        public float MinPowerLevel { get; private set; }
        public float MaxPowerLevel { get; private set; }
        public string SoundPath { get; private set; }

        public WatcherConfig(float minPowerLevel, float maxPowerLevel, string soundPath) {
            MinPowerLevel = minPowerLevel;
            MaxPowerLevel = maxPowerLevel;
            SoundPath = soundPath;
        }
    }
}
