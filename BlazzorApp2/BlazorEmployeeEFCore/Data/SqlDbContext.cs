using BlazorEmployeeEFCore.Shared;
using Microsoft.EntityFrameworkCore;
using BlazorEmployeeEFCore.Data;
using static BlazorEmployeeEFCore.Shared.WebsiteClass;
using static BlazorEmployeeEFCore.Shared.PlaceClass;

namespace BlazorEmployeeEFCore.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }
       
        public DbSet<PlaceModel> PlaceModels { get; set; }
        public DbSet<WebsiteModel> WebsiteModels { get; set; }


    }
}
