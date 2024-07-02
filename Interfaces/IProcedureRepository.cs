using MigrationService.Models;


namespace MigrationService.Interfaces
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<dynamic>> ExecuteProcedureAsync(string procedureName, Dictionary<string, object> parameters);
        Task<IEnumerable<DataModel>> GetDataModelsAsync(int idProcesso);
    }
}
