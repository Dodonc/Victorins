using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Victorins
{
   
    internal class CJsonQuestSaver : ISaveList<List<CQuest>>
    {
        private readonly JsonSerializerOptions _options;

        public CJsonQuestSaver()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new CQuestConvertor() }
            };
        }

        public List<CQuest> Load(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                return JsonSerializer.Deserialize<List<CQuest>>(json, _options) ?? new List<CQuest>();
            }

            return new List<CQuest>();
        }

        public void Save(List<CQuest> data, string path)
        {
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(path, json);
        }
    }
}
