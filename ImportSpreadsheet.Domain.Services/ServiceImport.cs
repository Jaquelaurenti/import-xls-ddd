using ImportSpreadsheet.Domain.Core.Interfaces.Repositorys;
using ImportSpreadsheet.Domain.Core.Interfaces.Services;
using ImportSpreadsheet.Domain.Entitys;

namespace ImportSpreadsheet.Domain.Services
{
    public class ServiceImport : ServiceBase<Import>, IServiceImport
    {
        private readonly IRepositoryImport repositorImport;

        public ServiceImport(IRepositoryImport repositorImport)
            : base(repositorImport)
        {
            this.repositorImport = repositorImport;
        }
    }
}