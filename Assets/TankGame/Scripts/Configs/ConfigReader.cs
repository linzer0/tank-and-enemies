using Newtonsoft.Json;
using UnityEngine;

namespace TankGame
{
    public class ConfigReader
    {
        public static T ReadConfig<T>(EConfigs configs)
        {
            var path = $"EConfigs/{configs}";
            var jsonConfig = Resources.Load<TextAsset>(path);
            return JsonConvert.DeserializeObject<T>(jsonConfig.ToString());
        }
    }
}