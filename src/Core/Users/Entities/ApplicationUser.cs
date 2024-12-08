using Core.Todos.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Users.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Todo> Todos { get; set; } = new List<Todo>();
    }
}
