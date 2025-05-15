using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using TraversalApi.DAL.Entities;

namespace TraversalApi.DAL.Context
{
    public class VisitorContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-SPH64FM\\;initial " +
                "catalog=TraversalDBApi;integrated security=true;");
            
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
