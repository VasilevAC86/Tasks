using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class JsonHelper
    {
        public static string SerializedObj<T> (T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static T DeserializeObj<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static void SaveToFile<T>(T obj, string path)
        {
            var json = SerializedObj(obj);
            File.WriteAllText(path, json);
        }
        public static T LoadFromFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            return DeserializeObj<T>(json);
        }
    }
}
