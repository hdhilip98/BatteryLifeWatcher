using System;
using Topshelf;

namespace BatteryLifeWatcher.Service {
    internal class Program {
        static void Main(string[] args) {
            var rc = HostFactory.Run(x => {
                x.Service<Service>(s => {
                    s.ConstructUsing(_ => new Service());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.EnableServiceRecovery(r => {
                    r.RestartService(1);
                    r.OnCrashOnly();
                    r.SetResetPeriod(1);
                });

                x.SetDescription("Alerts the user when battery level falls above or below the user defined level.");
                x.SetDisplayName("Battery Life Watcher");
                x.SetServiceName("BatteryLifeWatcher");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
