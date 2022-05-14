using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        //private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;

        }

        public IEnumerable<Account> GetAccounts()
        {
            return accountRepository.GetAccounts();
        }
    }
}
