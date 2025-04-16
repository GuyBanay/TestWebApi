using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        public static List<TestAPI> testAPIs = new()
        {
            new TestAPI { Id=1, FirstName="Tom", LastName="Starlen"},
            new TestAPI { Id=2, FirstName="Ann", LastName="Mary"},
            new TestAPI { Id=3, FirstName="Peter", LastName="Silva"}
        };

        [HttpGet]
        public IActionResult GetAllTestAPIs()
        {
            return Ok(testAPIs);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var testAPI = testAPIs.Find(x => x.Id == id);
            if (testAPI == null)
            {
                return NotFound("testAPI not found");
            }
            return Ok(testAPI);
        }

        [HttpPost]
        public IActionResult CreateTestAPI(TestAPI testAPI)
        {
            testAPIs.Add(testAPI);
            return Ok(testAPI);
        }

        [HttpPut]
        public IActionResult UpdateTestAPI(TestAPI testAPI)
        {
            var testAPIInList = testAPIs.Find(x => x.Id == testAPI.Id);
            if (testAPIInList == null)
            {
                return NotFound("Invalid testAPI details");
            }
            testAPIInList.FirstName = testAPI.FirstName;
            testAPIInList.LastName = testAPI.LastName;
            
            return Ok(testAPIInList);
        }

        [HttpDelete]
        public IActionResult DeleteTestAPI(int id)
        {
            var testAPI = testAPIs.Find(x => x.Id == id);
            if (testAPI == null)
            {
                return NotFound("Invalid testAPI details");
            }
            testAPIs.Remove(testAPI);
            return Ok(testAPIs);
        }

    }
}
