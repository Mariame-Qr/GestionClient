using System;
using GestionClient.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionClient.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> option) : base(option) { }
    public DbSet<Client> Clients { get; set; }
    }
}
