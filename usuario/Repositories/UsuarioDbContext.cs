using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using usuario.Models;

namespace usuario.Repositories;

public partial class UsuarioDbContext : DbContext
{
    public DbSet<Usuario> usuarios {  get; set; }
    public DbSet<Endereco> enderecos { get; set; }

    public UsuarioDbContext() {}

    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
