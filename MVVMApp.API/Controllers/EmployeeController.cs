using Microsoft.AspNetCore.Mvc;

using MVVMApp.Model;

namespace MVVMApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(ILogger<EmployeeController> logger)
        {
        }

        [HttpGet(Name = "GetAllEmployees")]
        public IEnumerable<IEmployee> Get()
        {
            var model = new Model.Web.Model();
            return model.GetAllEmployees();
        }
    }
}
