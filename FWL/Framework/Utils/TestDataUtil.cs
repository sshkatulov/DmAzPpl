using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace FWL.Framework.Utils
{
    public static class TestDataUtil
    {
        public static JObject GetTestData(string testName)
        {
            var filePath = Directory.GetFiles(Directory.GetCurrentDirectory(), $"{testName}.json", SearchOption.AllDirectories);
            if (filePath.Length == 0) return null;
            var fileData = File.ReadAllText(new FileInfo(filePath[0]).FullName);
            return (JObject)JsonConvert.DeserializeObject(fileData);
        }

        public static string Get(JObject testData, string token) => testData[token].ToString();
    }
}