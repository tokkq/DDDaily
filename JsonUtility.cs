using System.IO;
using System.Text.Json;

namespace DailyProject
{
    static class JsonUtility
    {
        public static int SaveJson<T>(T value, string saveFilePath)
            where T : new()
        {
            var extension = Path.GetExtension(saveFilePath);
            if (extension != ".json")
            {
                Utility.WriteLine($"[SaveJson][Failed]saveFilePath doesnt has json extension. [extension]{extension}[saveFilePath]{saveFilePath}");
                return -1;
            }

            var options = new JsonSerializerOptions();
            var serial = JsonSerializer.Serialize(value, options);

            using (var fileStream = File.Create(saveFilePath))
            {
                using (var writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine($"{serial}");
                }
            }

            Utility.WriteLine($"[SaveJson][value]{value}[Serial]{serial}[Path]{saveFilePath}");

            return 0;
        }

        public static T LoadJson<T>(string path, bool shouldCreateNewFileIfNoExistJson = false)
            where T : new()
        {
            var existJsonFile = File.Exists(path) == true;
            var shouldCreateNewFile = existJsonFile == false && shouldCreateNewFileIfNoExistJson == true;
            if (shouldCreateNewFile == true)
            {
                SaveJson(new T(), path);
            }

            var options = new JsonSerializerOptions();
            using (var file = File.OpenText(path))
            {
                var text = file.ReadToEnd();
                var json = JsonSerializer.Deserialize<T>(text, options);

                Utility.WriteLine($"[LoadJson][Path]{path}");

                return json;
            }
        }
    }
}
