using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrainStationDemo.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string CommentName { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
    }
}
