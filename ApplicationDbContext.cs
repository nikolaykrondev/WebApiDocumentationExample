using Microsoft.EntityFrameworkCore;

namespace WebApiDocumentationExample;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}