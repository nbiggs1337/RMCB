using Microsoft.EntityFrameworkCore;

namespace RMCB.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        
        //INSERT ALL MODELS NEEDED
        public DbSet<User> Users {get;set;}
        
        public DbSet<Review> Reviews {get;set;}
        
        public DbSet<Bootcamp> Bootcamps {get;set;}
        
        public DbSet<Location> Locations {get;set;}
        
        public DbSet<State> States {get;set;}
        
        public DbSet<Course> Courses {get;set;}
        
        public DbSet<CourseCat> CourseCats {get;set;}
        
    }
}