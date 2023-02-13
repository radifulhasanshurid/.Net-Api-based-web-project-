using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmplloyeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _EmplloyeeRepository = employeeRepository;  
        }

        [HttpGet]
        public List<Employee> GetEmployees() 
        {
            try 
            {
                var employees = _EmplloyeeRepository.GetEmployees();
                if (employees != null)
                {

                    return employees;
                }
                else
                {
                    var employee = new List<Employee>();
                    return employee;
                }
                
            }
            catch(Exception ex) 
            {
                //return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
                //return null;
                var employee= new List<Employee>();
                return employee;
            }
        }

        [HttpGet]

        public ActionResult GetEmployeeById( int Id)
        {
            try
            {
                var employee = _EmplloyeeRepository.GetEmployee(Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]

        public ActionResult AddEmployee(Employee employee)
        {
            try
            { 
                var addedEmployee = _EmplloyeeRepository.AddEmployee(employee);
                return Ok(addedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
    }

  
}
