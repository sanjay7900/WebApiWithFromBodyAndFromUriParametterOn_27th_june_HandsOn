using Microsoft.AspNetCore.Mvc;

namespace WebApiWithFromUriAndFromBodyParameter27thJuneHandsOn.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpEducationController : ControllerBase
    {
        public static List<EmpEducation> EmpEducations=new List<EmpEducation>();
        [HttpPost]
        public IActionResult AddNewEducation([System.Web.Http.FromUri] int id, [System.Web.Http.FromUri] string name, [System.Web.Http.FromUri] int passing, [System.Web.Http.FromUri] int marks)
        {
            EmpEducation empEducations = new EmpEducation
            {
                empId = id,
                empEducation= name,
                passingYear = passing,
                marksPercentage = marks
            };

            EmpEducations.Add(empEducations);
            return Ok("Added");

        }
        [HttpDelete]
        public IActionResult DeleteEducation([System.Web.Http.FromUri] int id)
        {
            var edu = EmpEducations.Where(r => r.empId == id).FirstOrDefault();
            if (edu != null)
            {
                EmpEducations.Remove(edu);
            }
            else
            {
                return Ok("record Not Found");
            }
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateEducation([System.Web.Http.FromUri] int id, [System.Web.Http.FromUri] string name, [System.Web.Http.FromUri] int passing, [System.Web.Http.FromUri] int marks)
        {
            var updateedu = EmpEducations.Where(r => r.empId == id).FirstOrDefault();
            if (updateedu != null)
            {
                updateedu.empId = id;
                updateedu.empEducation = name;
                updateedu.marksPercentage = marks;
                updateedu.passingYear = passing;
            }
            else
            {
                return Ok("Not found");

            }
            return Ok("Updated");
        }
        [HttpPatch]
        public IActionResult ShowAllEducation()
        {
            return Ok(EmpEducations);
        }


    }
}
