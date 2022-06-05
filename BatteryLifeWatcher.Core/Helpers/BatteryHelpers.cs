using System.Windows.Forms;

namespace BatteryLifeWatcher.Core.Helpers {
    internal static class BatteryHelpers {
        public static float GetBatteryLifePercent() {
            return SystemInformation.PowerStatus.BatteryLifePercent;
        }
        public static bool IsPluggedIn() {
            return SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online;
        }
        public static bool IsNotPluggedIn() {
            return !IsPluggedIn();
        }
    }
}
