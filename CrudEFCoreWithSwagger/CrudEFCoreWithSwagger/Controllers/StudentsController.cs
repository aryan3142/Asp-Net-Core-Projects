using CrudEFCoreWithSwagger.Context;
using CrudEFCoreWithSwagger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudEFCoreWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Operation          Http Verb 
        //C  -  Create         Post
        //R  -  Read           Get 
        //U  -  Update         Put 
        //D  -  Delete         Delete 


        private readonly CRUDContext _context;

        public StudentsController(CRUDContext context)
        {
            _context = context;
        }


        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _context.Students.SingleOrDefault(x => x.StudentId == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.StudentId == id);
            if( student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
