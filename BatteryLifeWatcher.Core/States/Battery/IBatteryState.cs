using BatteryLifeWatcher.Core.Services;

namespace BatteryLifeWatcher.Core.States.Battery {
    internal interface IBatteryState {
        IBatteryState GetNextState();
        void ProcessAlarm(AlarmService alarm);
    }
}
