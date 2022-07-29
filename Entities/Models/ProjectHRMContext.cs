using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class ProjectHRMContext : DbContext
    {
        public ProjectHRMContext()
        {
        }

        public ProjectHRMContext(DbContextOptions<ProjectHRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankHoliday> BankHolidays { get; set; } = null!;
        public virtual DbSet<TblEducation> TblEducations { get; set; } = null!;
        public virtual DbSet<TblHoliday> TblHolidays { get; set; } = null!;
        public virtual DbSet<TblPermission> TblPermissions { get; set; } = null!;
        public virtual DbSet<TblProfil> TblProfils { get; set; } = null!;
        public virtual DbSet<TblProject> TblProjects { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ETE4PHS;Database=ProjectHRM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankHoliday>(entity =>
            {
                entity.ToTable("BankHoliday");

                entity.Property(e => e.BankHolidayId)
                    .HasColumnName("BankHolidayID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BankHolidayFinishDate).HasColumnType("date");

                entity.Property(e => e.BankHolidayStartDate).HasColumnType("date");

                entity.Property(e => e.BankHolidayTitle)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId)
                    .HasName("PK__tblEduca__4BBE38E5EF28EFB9");

                entity.ToTable("tblEducation");

                entity.Property(e => e.EducationId)
                    .HasColumnName("EducationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Course)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EducationEndDate).HasColumnType("date");

                entity.Property(e => e.EducationInstitute)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EducationStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<TblHoliday>(entity =>
            {
                entity.HasKey(e => e.HolidayId)
                    .HasName("PK__tblHolid__2D35D59A3914AE46");

                entity.ToTable("tblHoliday");

                entity.Property(e => e.HolidayId)
                    .HasColumnName("HolidayID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.HolidayFinishDate).HasColumnType("date");

                entity.Property(e => e.HolidayStartDate).HasColumnType("date");

                entity.Property(e => e.HolidayType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Iduser).HasColumnName("IDuser");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.TblHolidays)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK__tblHolida__IDuse__49C3F6B7");
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.HasKey(e => e.PermissionsId)
                    .HasName("PK__tblPermi__1EDAF8485AAB7AB8");

                entity.ToTable("tblPermissions");

                entity.Property(e => e.PermissionsId)
                    .HasColumnName("PermissionsID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idrole).HasColumnName("IDrole");

                entity.Property(e => e.PermissionsLabel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.TblPermissions)
                    .HasForeignKey(d => d.Idrole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPermis__IDrol__2E1BDC42");
            });

            modelBuilder.Entity<TblProfil>(entity =>
            {
                entity.HasKey(e => e.ProfilId)
                    .HasName("PK__tblProfi__5E0A2D9DB3E3C9B4");

                entity.ToTable("tblProfil");

                entity.HasIndex(e => e.ProfilUsername, "UQ__tblProfi__98FB20E3E7AE50A3")
                    .IsUnique();

                entity.Property(e => e.ProfilId)
                    .HasColumnName("ProfilID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Iduser).HasColumnName("IDuser");

                entity.Property(e => e.ProfilAddress)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilDescription).HasColumnType("text");

                entity.Property(e => e.ProfilPhone2)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.TblProfils)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK__tblProfil__IDuse__45F365D3");
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__tblProje__761ABED0A380CCA9");

                entity.ToTable("tblProject");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ProjectEndDate).HasColumnType("date");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tblRole__8AFACE3AF9602CA4");

                entity.ToTable("tblRole");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUser__1788CCAC5DC4D044");

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(60)
                    .IsFixedLength();

                entity.Property(e => e.UserPhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasMany(d => d.Educations)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "TblUserEducation",
                        l => l.HasOne<TblEducation>().WithMany().HasForeignKey("EducationId").HasConstraintName("FK__tblUserEd__Educa__3D5E1FD2"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK__tblUserEd__UserI__3C69FB99"),
                        j =>
                        {
                            j.HasKey("UserId", "EducationId").HasName("PK__tblUserE__53332FCC7DBB5989");

                            j.ToTable("tblUserEducation");
                        });

                entity.HasMany(d => d.IdRoles)
                    .WithMany(p => p.IdUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TblUserRole",
                        l => l.HasOne<TblRole>().WithMany().HasForeignKey("IdRole").HasConstraintName("FK__tblUserRo__idRol__38996AB5"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("IdUser").HasConstraintName("FK__tblUserRo__idUse__37A5467C"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdRole").HasName("PK__tblUserR__69478C479058E0C3");

                            j.ToTable("tblUserRole");

                            j.IndexerProperty<Guid>("IdUser").HasColumnName("idUser");

                            j.IndexerProperty<Guid>("IdRole").HasColumnName("idRole");
                        });

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "TblUserProject",
                        l => l.HasOne<TblProject>().WithMany().HasForeignKey("ProjectId").HasConstraintName("FK__tblUserPr__Proje__412EB0B6"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK__tblUserPr__UserI__403A8C7D"),
                        j =>
                        {
                            j.HasKey("UserId", "ProjectId").HasName("PK__tblUserP__00E967A398DBB490");

                            j.ToTable("tblUserProject");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
