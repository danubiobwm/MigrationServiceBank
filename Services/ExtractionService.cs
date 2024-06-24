using Microsoft.EntityFrameworkCore;
using MigrationService.Data;
using MigrationService.Models;
using MigrationService.Utils;

namespace MigrationService.Services
{
    public interface IExtractionService
    {
        Task<IEnumerable<DataModel>> FetchDataAsync();
        Task<IEnumerable<DataModel>> ReadDataAsync();
        Task<string> GenerateFileAsync();
    }

    public class ExtractionService : IExtractionService
    {
        private readonly DatabaseContext _context;

        public ExtractionService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DataModel>> FetchDataAsync()
        {
            return await _context.Data.ToListAsync();
        }

        public async Task<IEnumerable<DataModel>> ReadDataAsync()
        {
            var query = await File.ReadAllTextAsync("Data/Queries/QueryCHG_APC_DISPONIBILIDADES.sql");
            return await _context.Data.FromSqlRaw(query).ToListAsync();
        }

        public async Task<string> GenerateFileAsync()
        {
            var data = await FetchDataAsync();
            var filePath = FileGenerator.GenerateFile(data);
            return filePath;
        }

        public async Task<List<DataModel>> GetDataAsync()
        {
            return await _context.Data.ToListAsync();
        }
    }
}
