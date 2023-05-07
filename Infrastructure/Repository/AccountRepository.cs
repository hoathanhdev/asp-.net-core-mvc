using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EF;
using Infrastructure.Entities;
using Infrastructure.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {

    }
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(EXDbContext context) : base(context)
        {
        }
    }
}
