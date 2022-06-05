namespace BatteryLifeWatcher.Core {
    public class WatcherConfig
    {
        public int PollingInterval { get; private set; }
        public float MinPowerLevel { get; private set; }
        public float MaxPowerLevel { get; private set; }
        public string SoundPath { get; private set; }

        public WatcherConfig(int pollingInterval, float minPowerLevel, float maxPowerLevel, string soundPath) {
            PollingInterval = pollingInterval;
            MinPowerLevel = minPowerLevel;
            MaxPowerLevel = maxPowerLevel;
            SoundPath = soundPath;
        }
    }
}
