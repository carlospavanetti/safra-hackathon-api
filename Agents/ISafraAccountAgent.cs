namespace APISafra.API.Agents
{
    public interface ISafraAccountAgent
    {
        string getAccountData(string account);

        string getAccountBalance(string account);

        string getAccountTransactions(string account);

        string getAccountGraphics(string account);

        string getAccountDebtSettlementApprovement(string account);
    }
}