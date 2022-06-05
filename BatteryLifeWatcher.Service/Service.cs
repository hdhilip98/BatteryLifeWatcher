using BatteryLifeWatcher.Core;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace BatteryLifeWatcher.Service {
    internal class Service {
        private Watcher _watcher;
        public void Start() {
            var config = LoadConfiguration();
            _watcher = new Watcher(config);
            _watcher.Start();
        }

        public void Stop() {
            _watcher.Stop();
            _watcher = null;
        }

        private WatcherConfig LoadConfiguration() {
            var serviceDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var configPath = Path.Combine(serviceDir, "WatcherConfig.json");
            var json = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<WatcherConfig>(json);
        }
    }
}
