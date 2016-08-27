using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class TodosController : ApiController
    {
        //Get /api/todos
        public IEnumerable<Todo> Get()
        {
            return new Todo[]
            {
                new Todo { Id = 1, task = "Wash car", priority = "c_low"},
                new Todo  { Id = 2, task = "Clean the house", priority = "a_high"}
            };
        }
    }
}
