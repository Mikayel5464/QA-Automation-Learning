using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TxtToJsonTest
{
    public class TxtToJsonConverter
    {
        public void ConvertValidationDataToJson(string txtPath, string jsonPath)
        {
            var dict = new Dictionary<string, string>();

            foreach (var line in File.ReadAllLines(txtPath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var parts = line.Split(':', 2);

                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                    dict[key] = value;
                }
            }

            var json = JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);

            Console.WriteLine("JSON Created: " + jsonPath);
        }
    }
}
