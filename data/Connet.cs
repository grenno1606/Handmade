using Microsoft.EntityFrameworkCore;
using Handmade_Dotnet.Models;
using handmade.models;

namespace handmade.data
{
    public class Connet : DbContext
    {
        public Connet(DbContextOptions<Connet> options) : base(options)
        {

        }
        public DbSet<sanpham_model> products { get; set; }
        public DbSet<user_models> users { get; set; }
        public DbSet<huongdan_model> tutorials { get; set; }
    }
}
