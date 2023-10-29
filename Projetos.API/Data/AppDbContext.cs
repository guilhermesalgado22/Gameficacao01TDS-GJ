using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projetos.API.Models;



namespace Projetos.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProjetoModel> Projetos { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<EquipeModel> Equipes { get; set; }
        public DbSet<MembroEquipe> Membros { get; set; }
        public DbSet<SprintModel> Sprints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cliente
            modelBuilder.Entity<ClienteModel>().ToTable("Clientes");

            // Projeto
            modelBuilder.Entity<ProjetoModel>().ToTable("Projetos");
            
            // Tarefa
            modelBuilder.Entity<TarefaModel>().ToTable("Tarefas");
            
            // Equipe
            modelBuilder.Entity<EquipeModel>().ToTable("Equipes");
            modelBuilder.Entity<EquipeModel>()
                .HasOne(e => e.Projeto)
                .WithMany(p => p.Equipes)
                .HasForeignKey(e => e.IdProjeto);

            // MembroEquipe
            modelBuilder.Entity<MembroEquipe>().ToTable("Membros");
            modelBuilder.Entity<MembroEquipe>()
                .HasOne(m => m.Equipe)
                .WithMany(e => e.Membros)
                .HasForeignKey(m => m.IdEquipe);
            
            // Sprint
            modelBuilder.Entity<SprintModel>().ToTable("Sprints");
        }
    }
}