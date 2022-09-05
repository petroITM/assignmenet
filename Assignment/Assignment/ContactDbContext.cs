using Assignment.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment
{
    public class ContactDbContext : DbContext
    { 
        //public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        //{ 
        //    this.Database.EnsureCreated();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("SqlConnection");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<SecondaryEmail> SecondaryEmails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactDbContext).Assembly);
        }
    }
};
