using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace WebAPI_DIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        BranchInfo branchInfo;

        public BranchController(BranchInfo _branchObjREF)
        {
          branchInfo = _branchObjREF;
        }


        [HttpGet]
        [Route("/branches/list")]
        public IActionResult GetBranches()
        {
            return Ok();
        }
        [HttpPost]
        [Route("/branches/add")]
        public IActionResult AddBranch([FromBody]BranchInfo newBranch)
        {
            string result = branchInfo.AddBranch(newBranch);
            return Created("", result);
        }
        [HttpPut]
        [Route("/branches/edit")]
        public IActionResult PutBranch(BranchInfo newBranch) 
        {
            string result = branchInfo.EditBranch(newBranch);
            return Accepted(result);
        }

        [HttpDelete]
        [Route("/branches/delete")]
        public IActionResult DeleteBranch(BranchInfo newBranch) 
        {
            string result = branchInfo.RemoveBranch(newBranch);
            return Accepted(result);
        }
    }
}
