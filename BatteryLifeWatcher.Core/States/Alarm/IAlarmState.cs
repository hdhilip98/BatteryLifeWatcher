namespace BatteryLifeWatcher.Core.States.Alarm {
    internal interface IAlarmState {
        IAlarmState Start();
        IAlarmState Stop();
    }
}
