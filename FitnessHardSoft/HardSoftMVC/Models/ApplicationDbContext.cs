using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HardSoftMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HardSoftMVC.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<HardSoftMVC.Models.Trainer> Trainers { get; set; }

        public System.Data.Entity.DbSet<HardSoftMVC.Models.Contact> Contacts { get; set; }
    }
}