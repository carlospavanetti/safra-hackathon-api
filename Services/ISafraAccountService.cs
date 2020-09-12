namespace APISafra.API.Services
{
    public interface ISafraAccountService
    {
        string getAccountBalance(string account);
        string getAccountData(string account);
        string getAccountTransactions(string account);
        string getAccountGraphics(string account);
        string getAccountDebtSettlementApprovement(string account);
    }
}