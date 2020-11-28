using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrainStationDemo.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostText { get; set; }
        public DateTime Date { get; set; }
        public int? TotalComments { get; set; }
        public List<Comment> Comments { get; set; }
        public string UserName { get; set; }  

    }
}
