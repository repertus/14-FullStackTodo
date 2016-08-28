using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoAPI.Models
{

    public class Todo
    {

        public Todo() { }
        //Properties
        public int Id { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public bool Complete { get; set; }

        public int GroupRefId { get; set; }

        [ForeignKey("GroupRefId")]
        public virtual Group Group { get; set; }
    }

    public class Group
    {
        public Group()
        {
            var TodosList = new List<Todo>();
        }
        public int GroupId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }

}