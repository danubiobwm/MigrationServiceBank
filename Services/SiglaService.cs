using MigrationService.Data;
using MigrationService.Interfaces;
using MigrationService.Models;

namespace MigrationService.Services
{
    public class SiglaService : ISiglaService
    {
        private readonly DatabaseContext _context;

        public SiglaService(DatabaseContext context)
        {
            _context = context;
        }

        public SiglaModel? GetSigla(string sigla)
        {
            return _context.Siglas.FirstOrDefault(c => c.Sigla == sigla);
        }

        public List<SiglaModel> GetAllSiglas()
        {
            return _context.Siglas.ToList();
        }
    }
}
