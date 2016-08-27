using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoAPI.Infrastructure
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext() : base("MyTodoDatabase")
        {

        }

        public IDbSet<Models.Todo>Todos { get; set; }
    }
}