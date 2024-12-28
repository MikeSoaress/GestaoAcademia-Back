using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace importaModels.Models;

public partial class AcademiaContext : DbContext
{
    public AcademiaContext()
    {
    }

    public AcademiaContext(DbContextOptions<AcademiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthMenu> AuthMenus { get; set; }

    public virtual DbSet<AuthPerfil> AuthPerfils { get; set; }

    public virtual DbSet<AuthPerfilMenu> AuthPerfilMenus { get; set; }

    public virtual DbSet<AuthPerfilUsuario> AuthPerfilUsuarios { get; set; }

    public virtual DbSet<AuthSubMenu> AuthSubMenus { get; set; }

    public virtual DbSet<AuthUsuario> AuthUsuarios { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MIKE;Database=Academia;User ID=sa;Password=epilef;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthMenu>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Menu");

            entity.ToTable("AuthMenu");

            entity.Property(e => e.chr_legenda)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_path_icone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_url).IsUnicode(false);
        });

        modelBuilder.Entity<AuthPerfil>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_PerfilUsuario");

            entity.ToTable("AuthPerfil");

            entity.Property(e => e.chr_descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuthPerfilMenu>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_PermissaoPerfilUsuario");

            entity.ToTable("AuthPerfilMenu");

            entity.HasOne(d => d.id_menuNavigation).WithMany(p => p.AuthPerfilMenus)
                .HasForeignKey(d => d.id_menu)
                .HasConstraintName("FK_PermissaoPerfilUsuario_Menu");

            entity.HasOne(d => d.id_perfil_usuarioNavigation).WithMany(p => p.AuthPerfilMenus)
                .HasForeignKey(d => d.id_perfil_usuario)
                .HasConstraintName("FK_PermissaoPerfilUsuario_PerfilUsuario");
        });

        modelBuilder.Entity<AuthPerfilUsuario>(entity =>
        {
            entity.ToTable("AuthPerfilUsuario");

            entity.HasOne(d => d.id_perfilNavigation).WithMany(p => p.AuthPerfilUsuarios)
                .HasForeignKey(d => d.id_perfil)
                .HasConstraintName("FK_AuthPerfilUsuario_AuthPerfil");

            entity.HasOne(d => d.id_usuarioNavigation).WithMany(p => p.AuthPerfilUsuarios)
                .HasForeignKey(d => d.id_usuario)
                .HasConstraintName("FK_AuthPerfilUsuario_AuthUsuario");
        });

        modelBuilder.Entity<AuthSubMenu>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_SubMenu");

            entity.ToTable("AuthSubMenu");

            entity.Property(e => e.chr_url).IsUnicode(false);

            entity.HasOne(d => d.id_menuNavigation).WithMany(p => p.AuthSubMenus)
                .HasForeignKey(d => d.id_menu)
                .HasConstraintName("FK_SubMenu_Menu");
        });

        modelBuilder.Entity<AuthUsuario>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Usuario");

            entity.ToTable("AuthUsuario");

            entity.Property(e => e.chr_login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_senha_hash).IsUnicode(false);

            entity.HasOne(d => d.id_pessoaNavigation).WithMany(p => p.AuthUsuarios)
                .HasForeignKey(d => d.id_pessoa)
                .HasConstraintName("FK_Usuario_Pessoa");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.ToTable("Endereco");

            entity.Property(e => e.chr_bairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_cep)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_cidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_logradouro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_numero)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.id_pessoaNavigation).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.id_pessoa)
                .HasConstraintName("FK_Endereco_Pessoa");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.ToTable("Pessoa");

            entity.Property(e => e.chr_cpf)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_fone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.chr_path_foto).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
