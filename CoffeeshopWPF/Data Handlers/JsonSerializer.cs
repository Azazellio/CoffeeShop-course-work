using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Restaurant1.DataHandlers;

namespace CoffeeShop.Data_Handlers
{
    class JsonSerializer : IContractSerializer
    {
        private const string dirname = "Json Serialization";
        public object Deserialize(dynamic unDeserialized, Type type)
        {
            string path = unDeserialized;
            var deserealizedObjLines = ReadFrom(string.Format("{0}/{1}",dirname, path));
            int lol = 1;
            Type smth = lol.GetType();
            object deserializedObj = JsonConvert.DeserializeObject(deserealizedObjLines, type);
            return deserializedObj;
        }
        public void Serialize(object objectToSerialize, string path)
        {
            EnsureDirectoryExists(dirname);
            var settingsjson = new JsonSerializerSettings() { ContractResolver = new MyContractResolver() };
            var json = JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented, settingsjson);
            WriteTo(json, string.Format("{0}/{1}", dirname, path));
        }
        private static void EnsureDirectoryExists(string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
        }
        public static void WriteTo(string lines, string fileName)
        {
            try
            {
                using (StreamWriter Swriter = new StreamWriter(fileName, append: true))
                {
                    Swriter.Write(lines);
                }
            }
            catch { }
        }
        public static string ReadFrom(string path)
        {
            var lines = "";
            using (StreamReader reader = new StreamReader(path))
            {
                while (true)
                {
                    var line = "";
                    line = reader.ReadLine();
                    lines += line + "\n";
                    if (line == null)
                    {
                        break;
                    }
                }
            }
            return lines;
        }
    }
}
