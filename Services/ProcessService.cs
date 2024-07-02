using MigrationService.Interfaces;
using MigrationService.Models;


namespace MigrationService.Services
{
    public class ProcessService : IProcessService
    {
        private static readonly List<DataModel> MockData = new List<DataModel>
        {
            new DataModel { IdProcesso = 1, Data = "2023-07-01", Value = "Sample Data 1" },
            new DataModel { IdProcesso = 1, Data = "2023-07-02", Value = "Sample Data 2" },
            // Adicione mais dados de mock conforme necessário
        };

        public async Task ProcessAsync(int idProcesso, string procedureName, Dictionary<string, object> parameters, string outputPath, string outputFormat)
        {
            var data = MockData.Where(md => md.IdProcesso == idProcesso).ToList();

            // Verifique se o diretório de saída existe, caso contrário, crie-o
            var directory = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (outputFormat.ToLower() == "csv")
            {
                await WriteToCsv(data, outputPath);
            }
            else if (outputFormat.ToLower() == "txt")
            {
                await WriteToTxt(data, outputPath);
            }
        }

        public Task<List<DataModel>> GetDataModelsAsync(int idProcesso)
        {
            var data = MockData.Where(md => md.IdProcesso == idProcesso).ToList();
            return Task.FromResult(data);
        }

        private async Task WriteToCsv(List<DataModel> data, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath))
            {
                await writer.WriteLineAsync("IdProcesso,Data,Value");
                foreach (var item in data)
                {
                    await writer.WriteLineAsync($"{item.IdProcesso},{item.Data},{item.Value}");
                }
            }
        }

        private async Task WriteToTxt(List<DataModel> data, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var item in data)
                {
                    await writer.WriteLineAsync($"{item.IdProcesso} {item.Data} {item.Value}");
                }
            }
        }
    }
}
