using APISafra.API.Agents;

namespace APISafra.API.Services
{
    public class SafraMorningCallsService : ISafraMorningCallsService
    {
        private ISafraMorningCallsAgent morningCallsAgent;

        public SafraMorningCallsService(ISafraMorningCallsAgent morningCallsAgent)
        {
            this.morningCallsAgent = morningCallsAgent;
        }

        public string getMorningCalls()
        {
            return this.morningCallsAgent.getMorningCalls();
        }
    }
}