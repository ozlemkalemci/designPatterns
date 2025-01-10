using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
