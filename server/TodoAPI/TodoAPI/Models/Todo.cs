using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoAPI.Models
{

    public class Todo
    {
        public int Id { get; set; }
        public string task { get; set; }
        public string priority { get; set; }
    }

}