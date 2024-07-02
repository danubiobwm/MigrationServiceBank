using CsvHelper;
using System.Globalization;

namespace MigrationService.Utils
{
    public static class FileGenerator
    {
        public static string CreateCsvFile(IEnumerable<dynamic> data, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
            return outputPath; // Retornar o caminho do arquivo criado
        }

        public static string CreateTxtFile(IEnumerable<dynamic> data, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var record in data)
                {
                    writer.WriteLine(string.Join("|", ((IDictionary<string, object>)record).Values));
                }
            }
            return outputPath; // Retornar o caminho do arquivo criado
        }
    }
}
