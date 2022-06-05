﻿using BatteryLifeWatcher.Core.Helpers;
using BatteryLifeWatcher.Core.Services;

namespace BatteryLifeWatcher.Core.States.Battery {
    internal class Low : IBatteryState {
        private readonly WatcherConfig _config;

        public Low(WatcherConfig config) {
            _config = config;
        }

        public IBatteryState GetNextState() {
            if (IsNormal())
                return new Normal(_config);

            return this;
        }

        public void ProcessAlarm(AlarmService alarm) {
            if (BatteryHelpers.IsNotPluggedIn())
                alarm.Start();
            else
                alarm.Stop();
        }

        private bool IsNormal() => BatteryHelpers.GetBatteryLifePercent() > _config.MinPowerLevel;
    }
}
