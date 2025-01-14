using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=GamerHubDB;integrated security=true;TrustServerCertificate=True;");
        }
        
        DbSet<Game> Games{get;set;}
        DbSet<Genre>Genres{get;set;}
        DbSet<Comment> Comments{get;set;}
    }
}