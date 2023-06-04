using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.Database.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserFavorite> UsersFavorites { get; set;} = new List<UserFavorite>();
        public virtual ICollection<Event> UsersEvents { get; set; } = null!;
    }
}
