using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Repository;

namespace Infrastructure.Service
{
    public interface IAccountService
    {
        IQueryable<Account> GetAccounts();
        Account GetAccount(int id);
        void InsertAccount(Account acc);
        void UpdateAccount(Account acc);
        void DeleteAccount(Account acc);
    }
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        

        public void DeleteAccount(Account acc)
        {
            accountRepository.Delete(acc);
        }


        public Account GetAccount(int id)
        {
            return accountRepository.GetById(id);
        }

        public IQueryable<Account> GetAccounts()
        {
            return accountRepository.GetAll();
        }

      

        public void InsertAccount(Account acc)
        {
            accountRepository.Insert(acc);
        }

        

        public void UpdateAccount(Account acc)
        {
            accountRepository.Update(acc);
        }
    }
}
