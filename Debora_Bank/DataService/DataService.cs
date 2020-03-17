using Microsoft.EntityFrameworkCore;
using Debora_Bank.Domain.Context;

namespace Debora_Bank.DataService
{
    public class DataService : IDataService
    {
        private readonly DeboraBankDbContext _dbContext;

        public DataService(DeboraBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeDB()
        {
            _dbContext.Database.Migrate();
        }
    }
}
