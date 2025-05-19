using BizFlow.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.API.Infrastructure.Persistence;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<WalletTransaction> WalletTransactions { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
}
