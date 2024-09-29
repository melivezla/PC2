using Microsoft.EntityFrameworkCore;
using Banco.Models;
public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options)
        : base(options) { }

    public DbSet<CuentaBancaria> CuentasBancarias { get; set; }
}
