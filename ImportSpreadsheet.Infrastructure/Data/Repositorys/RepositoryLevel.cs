using ImportSpreadsheet.Domain.Core.Interfaces.Repositorys;
using ImportSpreadsheet.Domain.Entitys;

namespace ImportSpreadsheet.Infrastructure.Data.Repositorys
{
    public class RepositoryImport : RepositoryBase<Import>, IRepositoryImport
    {
        private readonly SqlContext sqlContext;

        public RepositoryImport(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}