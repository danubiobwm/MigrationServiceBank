using MigrationService.Models;
using System.Text;

namespace MigrationService.Utils
{
    public static class FileGenerator
    {
        public static string GenerateFile(IEnumerable<DataModel> data)
        {
            var filePath = Path.Combine("Output", $"output_{DateTime.Now:yyyyMMddHHmmss}.txt");
            var content = new StringBuilder();

            foreach (var item in data)
            {
                content.AppendLine($"{item.Field1},{item.Field2}");
            }

            File.WriteAllText(filePath, content.ToString());
            return filePath;
        }
    }
}
