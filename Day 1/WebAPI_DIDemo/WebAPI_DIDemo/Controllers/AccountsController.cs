using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_DIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        // GET: api/Account
        [HttpGet]
        public ActionResult<IEnumerable<Bankaccountinfo>> GetAccounts()
        {
            return Bankaccountinfo.Accounts;
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public ActionResult<Bankaccountinfo> GetAccount(int id)
        {
            var account = Bankaccountinfo.Accounts.FirstOrDefault(a => a.AccNo == id);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        // POST: api/Account
        [HttpPost]
        public ActionResult<Bankaccountinfo> PostAccount(Bankaccountinfo account)
        {
            Bankaccountinfo.AddAccount(account);
            return CreatedAtAction("GetAccount", new { id = account.AccNo }, account);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public IActionResult PutAccount(int id, Bankaccountinfo account)
        {
            if (id != account.AccNo)
            {
                return BadRequest();
            }

            Bankaccountinfo.UpdateAccount(id, account);
            return NoContent();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public ActionResult<Bankaccountinfo> DeleteAccount(int id)
        {
            var account = Bankaccountinfo.Accounts.FirstOrDefault(a => a.AccNo == id);
            if (account == null)
            {
                return NotFound();
            }

            Bankaccountinfo.DeleteAccount(id);
            return account;
        }
    }
}
