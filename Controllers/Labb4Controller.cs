using Labb_4_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb_4_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Labb4Controller : ControllerBase
    {
        private IPersonInterests _personInterests;
        public Labb4Controller(IPersonInterests personInterests)
        {
            _personInterests = personInterests;
        }
        [HttpGet("/GetAllPeople/")]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                var result = await _personInterests.GetAllPeople();
                return Ok(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }
        [HttpGet("/GetInterests/")]
        public async Task<IActionResult> GetAllInterestsByPerson(int personID)
        {
            try
            {
                var result = _personInterests.GetInterestByPersonID(personID);
                return Ok(await result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        [HttpGet("/GetLinks/")]
        public async Task<IActionResult> GetAllLinksByPerson(int personId)
        {
            try
            {
                var result = _personInterests.GetLinksById(personId);
                return Ok(await result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        [HttpPost("/AddLink")]
        public async Task<IActionResult> AddLink(string url, string personName , string interestName)
        {
            try
            {
                var result = await _personInterests.AddLink(url, personName, interestName);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        
        
        [HttpPost("/AddInterest")]
        public async Task<IActionResult> AddInterest(int personID, int interestID)
        {
            try
            {
                var result = await _personInterests.AddIntersest(personID, interestID);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }


    }
}
