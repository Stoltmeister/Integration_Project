using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
