using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext ctx { get; set; }
        public AccountRepository(BankingDbContext bankingDbContext)
        {
            ctx = bankingDbContext;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return ctx.Accounts;
        }
    }
}
