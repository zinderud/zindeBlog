using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.Entities
{
    public class User : IEntityBase
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
