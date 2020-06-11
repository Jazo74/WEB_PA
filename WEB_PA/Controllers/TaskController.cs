using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB_PA.Models;
using WEB_PA.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_PA.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        IDBService ds = new DBService();
        //// GET: api/<EventController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Tassk[] GetTasksByEventId(int id)
        {
            List<Tassk> tasks = ds.GetTasksByEvent(id);
            Tassk[] taskArray = new Tassk[tasks.Count];
            for (int i=0; i<tasks.Count; i++)
            {
                taskArray[i] = tasks[i];
            }
            return taskArray;
        }

        //// POST api/<EventController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EventController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EventController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
