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
    }
}
