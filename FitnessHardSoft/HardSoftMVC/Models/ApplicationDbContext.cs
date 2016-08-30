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
        public System.Data.Entity.DbSet<HardSoftMVC.Models.Tag> Tags { get; set; }
        public System.Data.Entity.DbSet<HardSoftMVC.Models.Card> Cards { get; set; }
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(a => a.Tags)
                .WithMany(a => a.Posts)
                .Map(m =>
                {
                    m.ToTable("TagPosts");
                    m.MapLeftKey("Post_Id");
                    m.MapRightKey("Tag_Id");
                });
            base.OnModelCreating(modelBuilder);
        }*/

        public System.Data.Entity.DbSet<HardSoftMVC.Models.Contact> Contacts { get; set; }
    }
}