using Microsoft.EntityFrameworkCore;
using MindCareWeb.Models;

namespace MindCareWeb.Data
{
    public class MindCareDbContext : DbContext
    {
        public MindCareDbContext(DbContextOptions<MindCareDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Tarefa> Tarefas => Set<Tarefa>();
        public DbSet<UsuarioTarefa> UsuarioTarefas => Set<UsuarioTarefa>();
        public DbSet<HistoricoMood> Historicos => Set<HistoricoMood>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_USUARIO").ValueGeneratedOnAdd();
                entity.Property(e => e.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasColumnName("EMAIL").HasMaxLength(150);
                entity.Property(e => e.DataInscricao).HasColumnName("DATA_INSCRICAO").ValueGeneratedOnAdd();
                entity.Property(e => e.UltimaAtualizacao).HasColumnName("ULTIMA_ATUALIZACAO");
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.ToTable("TAREFA");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_TAREFA").ValueGeneratedOnAdd();
                entity.Property(e => e.NomeTarefa).HasColumnName("NOME_TAREFA").HasMaxLength(150).IsRequired();
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO").HasMaxLength(400);
                entity.Property(e => e.CriadorId).HasColumnName("ID_USUARIO_CRIADOR");
            });

            modelBuilder.Entity<UsuarioTarefa>(entity =>
            {
                entity.ToTable("USUARIO_TAREFA");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_USUARIO_TAREFA").ValueGeneratedOnAdd();
                entity.Property(e => e.UsuarioId).HasColumnName("ID_USUARIO");
                entity.Property(e => e.TarefaId).HasColumnName("ID_TAREFA");
                entity.Property(e => e.Conquista).HasColumnName("CONQUISTA").HasMaxLength(1).HasDefaultValue("0");
                entity.Property(e => e.DataInicio).HasColumnName("DATA_INICIO").ValueGeneratedOnAdd();
                entity.Property(e => e.DataFim).HasColumnName("DATA_FIM");
                entity.Property(e => e.ProgressoPercentual).HasColumnName("PROGRESSO_PERCENTUAL").HasDefaultValue(0);

                entity.HasOne(ut => ut.Usuario).WithMany(u => u.UsuarioTarefas).HasForeignKey(ut => ut.UsuarioId);
                entity.HasOne(ut => ut.Tarefa).WithMany().HasForeignKey(ut => ut.TarefaId);
            });

            modelBuilder.Entity<HistoricoMood>(entity =>
            {
                entity.ToTable("HISTORICO_MOOD");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_HISTORICO").ValueGeneratedOnAdd();
                entity.Property(e => e.UsuarioId).HasColumnName("ID_USUARIO");
                entity.Property(e => e.Humor).HasColumnName("HUMOR");
                entity.Property(e => e.DataRegistro).HasColumnName("DATA_REGISTRO").ValueGeneratedOnAdd();
                entity.Property(e => e.Observacao).HasColumnName("OBSERVACAO").HasMaxLength(400);

                entity.HasOne(h => h.Usuario).WithMany(u => u.Historicos).HasForeignKey(h => h.UsuarioId);
            });
        }
    }
}
