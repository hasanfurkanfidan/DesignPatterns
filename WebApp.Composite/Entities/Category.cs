using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Composite.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int ReferenceId { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
