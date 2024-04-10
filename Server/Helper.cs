using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    public static class  Helper
    {
       

        public static IEnumerable<T> Load<T>()
        { 
            string path = $"{Environment.CurrentDirectory}\\Data\\Processors.json";

            if (!File.Exists(path)) return new List<T>();

            string jsonString = File.ReadAllText(path);

            List<T> deserializeData = JsonSerializer.Deserialize<List<T>>(jsonString);

            return deserializeData;
        }
    }
}
