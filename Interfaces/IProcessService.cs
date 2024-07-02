using MigrationService.Models;

namespace MigrationService.Interfaces
{
    public interface IProcessService
    {
        Task ProcessAsync(int idProcesso, string procedureName, Dictionary<string, object> parameters, string outputPath, string outputFormat);
        Task<List<DataModel>> GetDataModelsAsync(int idProcesso);
    }
}
