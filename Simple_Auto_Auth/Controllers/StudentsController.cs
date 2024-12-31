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
        public async Task<IActionResult> Get()
        {
            var students = await Task.Run(() => studentServices.GetStudents().ToList());
            return Ok(students);
        }


        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await studentServices.GetStudent(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }


        // POST api/<StudentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student value)
        {
            var student = await studentServices.AddStudent(value);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await studentServices.DeleteStudent(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Student value)
        {
            return Ok(studentServices.UpdateStudent(value));
        }

   
    }
}
