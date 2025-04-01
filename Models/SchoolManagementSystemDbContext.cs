using System;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementsystem.Models;

public class SchoolManagementSystemDbContext:DbContext
{
    public DbSet<Student> Students {get;set;}

    public SchoolManagementSystemDbContext(DbContextOptions<SchoolManagementSystemDbContext> options)
    :base(options)
    {
        
    }
}
