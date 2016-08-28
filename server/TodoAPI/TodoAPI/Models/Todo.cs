using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoAPI.Models
{

    public class Todo
    {
        //Properties
        public int Id { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public bool Complete { get; set; }
    }

}