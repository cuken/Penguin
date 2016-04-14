using Newtonsoft.Json;
using System.IO;

namespace Penguin
{
    public class GlobalSettings
    {
        private const string path = "./config/settings.json";
        private static GlobalSettings _instance = new GlobalSettings();

        public static void Save()
        {
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(stream))
                writer.Write(JsonConvert.SerializeObject(_instance, Formatting.Indented));
        }

        public static void Load()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"{path} is missing.");
            _instance = JsonConvert.DeserializeObject<GlobalSettings>(File.ReadAllText(path));
        }

        public class GeneralSettings
        {
            [JsonProperty("resolution")]
            public string resolution;
        }
        [JsonProperty("general")]
        private GeneralSettings _general = new GeneralSettings();
        public static GeneralSettings General => _instance._general;

        public class CatchSettings
        {
            [JsonProperty("catchIcon_X")]
            public int catchIcon_X;
            [JsonProperty("catchIcon_Y")]
            public int catchIcon_Y;
            [JsonProperty("catchIcon_R")]
            public int catchIcon_R;
            [JsonProperty("catchIcon_G")]
            public int catchIcon_G;
            [JsonProperty("catchIcon_B")]
            public int catchIcon_B;
            [JsonProperty("catchIcon_Fuzzy")]
            public int catchIcon_Fuzzy;
        }
        [JsonProperty("catch")]
        private CatchSettings _catch = new CatchSettings();
        public static CatchSettings Catch => _instance._catch;

        public class TimerSettings
        {
            [JsonProperty("biteToCatchTimer")]
            public int biteToCatchTimer;
            [JsonProperty("lootDelay")]
            public int lootDelay;
            [JsonProperty("catchDelay")]
            public int catchDelay;
            [JsonProperty("waitForCatchIdle")]
            public int waitForCatchIdle;
        }
        [JsonProperty("timer")]
        private TimerSettings _timer = new TimerSettings();
        public static TimerSettings Timer => _instance._timer;

        public class OCRSettings
        {
            [JsonProperty("colorPixel_X")]
            public int colorPixel_X;
            [JsonProperty("colorPixel_Y")]
            public int colorPixel_Y;
            [JsonProperty("ocrWidth")]
            public int ocrWidth;
            [JsonProperty("ocrHeight")]
            public int ocrHeight;
            [JsonProperty("ocr_X")]
            public int ocr_X;
            [JsonProperty("ocr_Y")]
            public int ocr_Y;
        }
        [JsonProperty("ocr")]
        private OCRSettings _ocr = new OCRSettings();
        public static OCRSettings OCR => _instance._ocr;
        
        public class ColorSettings
        {
            [JsonProperty("gray_R")]
            public int gray_R;
            [JsonProperty("gray_G")]
            public int gray_G;
            [JsonProperty("gray_B")]
            public int gray_B;
            [JsonProperty("gray_Thresh")]
            public int gray_Thresh;

            [JsonProperty("teal_R")]
            public int teal_R;
            [JsonProperty("teal_G")]
            public int teal_G;
            [JsonProperty("teal_B")]
            public int teal_B;
            [JsonProperty("teal_Thresh")]
            public int teal_Thresh;

            [JsonProperty("purple_R")]
            public int purple_R;
            [JsonProperty("purple_G")]
            public int purple_G;
            [JsonProperty("purple_B")]
            public int purple_B;
            [JsonProperty("purple_Thresh")]
            public int purple_Thresh;

            [JsonProperty("red_R")]
            public int red_R;
            [JsonProperty("red_G")]
            public int red_G;
            [JsonProperty("red_B")]
            public int red_B;
            [JsonProperty("red_Thresh")]
            public int red_Thresh;

            [JsonProperty("green_R")]
            public int green_R;
            [JsonProperty("green_G")]
            public int green_G;
            [JsonProperty("green_B")]
            public int green_B;
            [JsonProperty("green_Thresh")]
            public int green_Thresh;

            [JsonProperty("white_R")]
            public int white_R;
            [JsonProperty("white_G")]
            public int white_G;
            [JsonProperty("white_B")]
            public int white_B;
            [JsonProperty("white_Thresh")]
            public int white_Thresh;
        }
        [JsonProperty("color")]
        private ColorSettings _color = new ColorSettings();
        public static ColorSettings Color => _instance._color;
    }
}
