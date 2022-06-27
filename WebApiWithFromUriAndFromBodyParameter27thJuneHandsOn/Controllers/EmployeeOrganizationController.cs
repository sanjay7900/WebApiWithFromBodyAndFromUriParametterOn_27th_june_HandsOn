using Microsoft.AspNetCore.Mvc;

namespace WebApiWithFromUriAndFromBodyParameter27thJuneHandsOn.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeOrganizationController : ControllerBase
    {
        public static List<EmployeeOrganization> Organizations=new List<EmployeeOrganization>();
        [HttpPost]
        public IActionResult AddNewOrganization([System.Web.Http.FromUri] int id , [System.Web.Http.FromUri] string name)
        {
            EmployeeOrganization employeeOrganization = new EmployeeOrganization { Id=id,Name=name};
            Organizations.Add(employeeOrganization);
            return Ok("Added");

        }
        [HttpDelete]
        public IActionResult DeleteOrgainzation([System.Web.Http.FromUri] int id)
        {
            var org=Organizations.Where(r=>r.Id==id).FirstOrDefault();
            if (org != null)
            {
                Organizations.Remove(org);
            }
            else
            {
                return Ok("record Not Found");
            }
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateOrganization([System.Web.Http.FromUri] int id,[System.Web.Http.FromUri] string name)
        {
            var org=Organizations.Where(r=>r.Id==id).FirstOrDefault();
            if(org != null)
            {
                org.Id =id;
                org.Name=name;  
            }
            else
            {
                return Ok("Not found");

            }
            return Ok("Updated");
        }
        [HttpPatch]
        public IActionResult ShowAllOrganization()
        {
            return Ok(Organizations);
        }
    }
}
