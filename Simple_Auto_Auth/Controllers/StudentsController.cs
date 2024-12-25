using ApplicationLayer.Services;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_Auto_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentServices studentServices;

        public StudentsController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentServices.GetStudents();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(studentServices.GetStudent(id));
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            return Ok(studentServices.AddStudent(value));
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Student value)
        {
            return Ok(studentServices.UpdateStudent(value));
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(studentServices?.DeleteStudent(id));  
        }
    }
}
