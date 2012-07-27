using Paralect.Config.Settings;

namespace Newbly
{
    public class Settings
    {
        [SettingsProperty("mongodbConnectionString")]
        public string MongoConnectionString { get; set; }
    }
}
