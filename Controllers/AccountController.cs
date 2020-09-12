using APISafra.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISafra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ISafraAccountService accountService;

        public AccountController(ISafraAccountService accountService)
        {
            this.accountService = accountService;
        }


        // GET api/account/5
        [HttpGet("{id}")]
        public IActionResult GetAccountData(string id)
        {
            return Ok(accountService.getAccountData(id));
        }

        // GET api/account/5/balances
        [HttpGet("{id}/balances")]
        public IActionResult GetAccountBalances(string id)
        {
            return Ok(accountService.getAccountBalance(id));
        }

        // GET api/account/5/transactions
        [HttpGet("{id}/transactions")]
        public IActionResult GetAccountTransactions(string id)
        {
            return Ok(accountService.getAccountTransactions(id));
        }
    }
}
