using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TxtToJsonTest
{
    public class SchedulePair
    {
        public Dictionary<string, string> Target {  get; set; }
        public Dictionary<string, string> Source { get; set; }
    }

    public class NewConverter
    {
        public void ConvertValidationDataToJson(string txtPath, string jsonPath)
        {
            var lines = File.ReadAllLines(txtPath);
            var headers = lines[0].Split('\t');
            var result = new List<SchedulePair>();

            for (int i = 1; i < lines.Length; i += 2)
            {
                if (i + 1 >= lines.Length) break;

                var trgValues = lines[i].Split('\t');
                var srcValues = lines[i + 1].Split('\t');

                var target = new Dictionary<string, string>();
                var source = new Dictionary<string, string>();

                for (int j = 0; j < headers.Length && j < trgValues.Length; j++)
                    target[headers[j].Trim()] = trgValues[j].Trim();

                for (int j = 0; j < headers.Length && j < srcValues.Length; j++)
                    source[headers[j].Trim()] = srcValues[j].Trim();

                result.Add(new SchedulePair { Target = target, Source = source });
            }

            var json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);
            Console.WriteLine($"JSON written to: {jsonPath}");
        }
    }
}
