﻿using Microsoft.EntityFrameworkCore;

namespace DemoApp;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public DbSet<Student> Students {get;set;}
}
