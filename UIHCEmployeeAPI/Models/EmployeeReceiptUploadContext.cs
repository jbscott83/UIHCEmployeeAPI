using Microsoft.EntityFrameworkCore;

namespace UIHCEmployeeAPI.Models
{
    public class EmployeeReceiptUploadContext : DbContext
    {
        public EmployeeReceiptUploadContext(DbContextOptions<EmployeeReceiptUploadContext> options) : base(options)
        {
        }

        public DbSet<EmployeeReceipt> EmployeeReceipt { get; set; } = null!;
    }
}
