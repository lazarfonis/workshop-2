using Faculty.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty.Data;

public class FacultyDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public virtual DbSet<Subject> Subjects { get; set; }

    public FacultyDbContext(DbContextOptions<FacultyDbContext> options) : base(options)
    {
        Database.Migrate();
    }
}
