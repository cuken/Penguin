using Newtonsoft.Json;

namespace Penguin
{
    public class GlobalSettings
    {
        [JsonProperty("resolution")]
        public static string resolution { get; internal set; } = "1920x1080";
        [JsonProperty("catchIcon_X")]
        public static int catchIcon_X { get; internal set; } = 1065;
        [JsonProperty("catchIcon_Y")]
        public static int catchIcon_Y { get; internal set; } = 94;
        [JsonProperty("catchIcon_R")]
        public static int catchIcon_R { get; internal set; } = 240;
        [JsonProperty("catchIcon_G")]
        public static int catchIcon_G { get; internal set; } = 214;
        [JsonProperty("catchIcon_B")]
        public static int catchIcon_B { get; internal set; } = 104;
        [JsonProperty("catchIcon_Fuzzy")]
        public static int catchIcon_Fuzzy { get; internal set; } = 2;

        [JsonProperty("biteToCatchTimer")]
        public static int biteToCatchTimer { get; internal set; } = 2;

        [JsonProperty("lootDelay")]
        public static int lootDealy { get; internal set; } = 500;


        [JsonProperty("CatchDelay")]
        public static int catchDelay { get; internal set; } = 1000;

    }
}
