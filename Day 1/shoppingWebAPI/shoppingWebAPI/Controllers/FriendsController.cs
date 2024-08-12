using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private static List<string> friends = new List<string>();


        [HttpGet]
        [Route("friends")]
        public IActionResult ShowAllfriends()
        {
            return Ok(friends);
        }

        [HttpGet]
        [Route("friends/count")]
        public IActionResult Totalfriends()
        {
            int total = friends.Count;
            return Ok(total);
        }

        [HttpPost]
        [Route("friends/add/{friendName}")]
        public IActionResult AddNewFriend(string friendName)
        {
            friends.Add(friendName);
            return Created("", friendName + " added to your friends list");
        }
        [HttpPut]
        [Route("friends/edit/{newFriendName}/{position}")]
        public IActionResult EditFriendsName(string newFriendName, int position)
        {
            friends[position] = newFriendName;
            return Accepted("Friends Name edited successfully");
        }
        [HttpDelete]
        [Route("friends/unfriend/{position}")]
        public IActionResult DeleteAFriend(int position)
        {
            //handle exception here before returning the value
            friends.RemoveAt(position);
            return Accepted(" Friend deleted successfully");
        }


        
       
    }
}
