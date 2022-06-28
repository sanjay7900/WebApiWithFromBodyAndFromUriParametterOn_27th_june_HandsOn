using Microsoft.AspNetCore.Mvc;

namespace WebApiWithFromUriAndFromBodyParameter27thJuneHandsOn.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> _employees = new List<Employee>();
        [HttpPost]
        public IActionResult AddNewEmployee([System.Web.Http.FromBody] Employee employee)
        {
            _employees.Add(employee);
            return Ok("Employee Added");
        }

        [HttpDelete]
        public ActionResult DeleteAnEmployee([System.Web.Http.FromBody] int id)
        {
            var delEmp = _employees.Where(x => x.id == id).FirstOrDefault();
            if (delEmp != null)
            {
                _employees.Remove(delEmp);
            }
            else
            {
                return Ok($"Record Not found To Delete With Id = {id}");
            }
            return Ok(" Record Delete Successfully");
        }
        [HttpPut]
        public ActionResult UpdateEmployee(int id,[System.Web.Http.FromBody] Employee UpdateEmployee)
        {
            var updatemp = _employees.Where(x => x.id == id).FirstOrDefault();
            if (updatemp != null)
            {
                updatemp.id = UpdateEmployee.id;
                updatemp.name = UpdateEmployee.name;    
                updatemp.age = UpdateEmployee.age;  
                updatemp.address= UpdateEmployee.address;   
            }
            else
            {
                return Ok($"Record Not found To Update With Id = {id}");
            }
            return Ok($"Record Updated With Id = {id}");

        }
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            if (_employees != null)
            {
                return Ok(_employees);
            }
            return BadRequest("No Data Available");
        }
        [HttpPost]
        public async Task<IActionResult> PutEmployeDetailUsingFromQuery([FromQuery] Employee employee)
        {
            _employees.Add(employee);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PutEmployeDetailUsingFromHeader([FromHeader] Employee employee)
        {

            _employees.Add(employee);

            return NoContent();
        }
        [HttpPost("{id}/{name}/{age}/{address}")]
        public async Task<IActionResult> PutEmployeDetailUsingFromRoute([FromRoute] Employee employee)
        {
            _employees.Add(employee);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> SaveEmpAndEdu(SaveEmployeeAndEducation saveEmployeeAndEducation)
        {
            _employees.Add(saveEmployeeAndEducation.Employee);
            EmpEducationController.EmpEducations.Add(saveEmployeeAndEducation.EmpEducation);
            
            return NoContent();
        }
        [HttpGet]
        public  async Task<IActionResult> FromHeadrExample([FromHeader] string name ,[FromHeader] Employee employee)
        {
            return Ok($"my name is {name} and my is {employee.name} {employee.id} {employee.address} {employee.age}");
        }



    }
}
