using BatteryLifeWatcher.Core;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using Topshelf;

namespace BatteryLifeWatcher.Service {
    internal class Program {
        static float _min = 0.2f;
        static float _max = 0.8f;
        static string _serviceDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string _configPath = Path.Combine(_serviceDir, "WatcherConfig.json");
        static string _soundPath = Path.Combine(_serviceDir, @"Sounds\default.wav");

        static void Main(string[] args) {
            var rc = HostFactory.Run(x => {
                x.Service<Service>(s => {
                    s.ConstructUsing(_ => new Service());
                    s.WhenStarted(tc => {
                        var config = LoadConfiguration();
                        tc.Start(config);
                    });
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

                x.AddCommandLineDefinition("min", v => _min = float.Parse(v) / 100);
                x.AddCommandLineDefinition("max", v => _max = float.Parse(v) / 100);

                x.AfterInstall(() => {
                    DeleteConfiguration();
                    CreateDefaultConfiguration();
                });

                x.AfterUninstall(() => {
                    DeleteConfiguration();
                });
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }

        static void DeleteConfiguration() {
            if (File.Exists(_configPath)) File.Delete(_configPath);
        }

        static WatcherConfig LoadConfiguration() {
            if(!File.Exists(_configPath)) {
                return CreateDefaultConfiguration();
            }

            var json = File.ReadAllText(_configPath);
            return JsonConvert.DeserializeObject<WatcherConfig>(json);
        }

        static WatcherConfig CreateDefaultConfiguration() {
            var config = new WatcherConfig(_min, _max, _soundPath);
            File.WriteAllText(_configPath, JsonConvert.SerializeObject(config));
            return config;
        }
    }
}
