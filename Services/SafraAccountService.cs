using APISafra.API.Agents;

namespace APISafra.API.Services
{

    public class SafraAccountService : ISafraAccountService
    {
        private ISafraAccountAgent accountAgent;

        public SafraAccountService(ISafraAccountAgent accountAgent)
        {
            this.accountAgent = accountAgent;
        }

        public string getAccountData(string account)
        {
            return this.accountAgent.getAccountData(account);
        }

        public string getAccountBalance(string account)
        {
            return this.accountAgent.getAccountBalance(account);
        }

        public string getAccountTransactions(string account)
        {
            return this.accountAgent.getAccountTransactions(account);
        }

        public string getAccountGraphics(string account)
        {
            return this.accountAgent.getAccountGraphics(account);
        }
    }
}