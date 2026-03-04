using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Blog
    {
        public Guid BlogId { get; init; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; init; }
        public string? Slug { get; set; }
        public bool IsPublished { get; set; }

        public Blog()
        {
            BlogId = Guid.NewGuid();
            CreateDate = DateTime.Now;
            IsPublished = false;
        }
    }
}
