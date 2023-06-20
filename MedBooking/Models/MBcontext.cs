using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace MedBooking.Models
{
    public partial class MBcontext : DbContext
    {
        public MBcontext()
        {
        }

        public MBcontext(DbContextOptions<MBcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }
        
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Slot> Slot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=laptop-80e5h12k\\sqlexpress;Initial Catalog=MedBooking;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e._id_consulta);

                entity.ToTable("tb_consulta");

                entity.HasIndex(e => e._id_paciente)
                    .HasName("id_paciente");
                entity.HasIndex(e => e._id_medico)
                    .HasName("id_medico");
                entity.HasIndex(e => e.id_slot)
                    .HasName("id_slot");

                entity.Property(e => e._id_consulta).HasColumnName("id_consulta");

                entity.Property(e => e._id_paciente).HasColumnName("id_paciente");

                entity.Property(e => e._id_medico).HasColumnName("id_medico");

                entity.Property(e => e.id_slot).HasColumnName("id_slot");

                entity.Property(e => e.notas).HasColumnName("notas");

                entity.Property(e => e.status).HasColumnName("status");
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.id_conta);

                entity.ToTable("tb_conta");

                entity.HasIndex(e => e._id_user)
                    .HasName("id_user");

                entity.Property(e => e.id_conta).HasColumnName("id_conta");

                entity.Property(e => e._id_user).HasColumnName("id_user");

                entity.Property(e => e.tipo_conta).HasColumnName("tipo_conta");

                entity.Property(e => e.nome).HasColumnName("nome");

                entity.Property(e => e.telefone).HasColumnName("telefone");

                entity.Property(e => e.especialidade).HasColumnName("especialidade");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e._id_user);

                entity.ToTable("tb_user");

                entity.Property(e => e._id_user).HasColumnName("id_user");

                entity.Property(e => e._username).HasColumnName("username");

                entity.Property(e => e._senha).HasColumnName("senha");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.HasKey(e => e._id_slot);

                entity.ToTable("tb_slot");

                entity.Property(e => e._id_slot).HasColumnName("id_slot");

                entity.Property(e => e.Data_consulta).HasColumnName("data_consulta");

                entity.Property(e => e.Hora_consulta).HasColumnName("hora_consulta");
            }); 
        }       
    }
}
