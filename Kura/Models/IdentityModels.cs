using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Koora.Models.MyModels;
using System.ComponentModel.DataAnnotations;
using System;

namespace Koora.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AspNetUser : IdentityUser
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Display(Name ="Gender")]
        public string Gender { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AspNetUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<AspNetUser>
    {
        //public DbSet<Student> Students { get; set; }
        public DbSet<EuiEmail> EuiEmails { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Nominee> Nominees { get; set; }  
        public DbSet<CastVote> CastVotes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<PostionResult> PostionResult { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Rate> Ratings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class EuiEmail
    {
        public int id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Boolean Taken { get; set; }
    }
}