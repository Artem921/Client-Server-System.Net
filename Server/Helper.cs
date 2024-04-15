using System.Text.Encodings.Web;
using System.Text.Json;

namespace Server
{
    public static class  Helper
    {
       static string path = $"{Environment.CurrentDirectory}\\Data\\Employees.json";

        public static IEnumerable<T> Load<T>()
        { 
            if (!File.Exists(path)) return new List<T>();

            string jsonString = File.ReadAllText(path);

            List<T> deserializeData = JsonSerializer.Deserialize<List<T>>(jsonString);

            return deserializeData;
        }

        public static void Save(object data)
        {

            var option = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

                WriteIndented = true,
            };

            string serializeData = JsonSerializer.Serialize(data, option);

            if (!File.Exists(path))

                File.Create(path).Close();

            File.WriteAllText(path, serializeData);

        }
    }
}
