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
        public virtual DbSet<ProfilAddress> ProfilAddresses { get; set; } = null!;
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-UUE8G7T;Database=ProjectHRM;Trusted_Connection=True;");
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

            modelBuilder.Entity<ProfilAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__ProfilAd__091C2A1BFF1CE67A");

                entity.ToTable("ProfilAddress");

                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdministrativeUnit)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId)
                    .HasName("PK__tblEduca__4BBE38E5E6A40B30");

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
                    .HasName("PK__tblHolid__2D35D59A1E6FA784");

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
                    .HasConstraintName("FK__tblHolida__IDuse__4E88ABD4");
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.HasKey(e => e.PermissionsId)
                    .HasName("PK__tblPermi__1EDAF848D9A250ED");

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
                    .HasConstraintName("FK__tblPermis__IDrol__2B3F6F97");
            });

            modelBuilder.Entity<TblProfil>(entity =>
            {
                entity.HasKey(e => e.ProfilId)
                    .HasName("PK__tblProfi__5E0A2D9DBF7103DA");

                entity.ToTable("tblProfil");

                entity.HasIndex(e => e.ProfilUsername, "UQ__tblProfi__98FB20E3C6704521")
                    .IsUnique();

                entity.Property(e => e.ProfilId)
                    .HasColumnName("ProfilID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdprofilAddress).HasColumnName("IDProfilAddress");

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

                entity.HasOne(d => d.IdprofilAddressNavigation)
                    .WithMany(p => p.TblProfils)
                    .HasForeignKey(d => d.IdprofilAddress)
                    .HasConstraintName("FK__tblProfil__IDPro__4AB81AF0");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.TblProfils)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK__tblProfil__IDuse__49C3F6B7");
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__tblProje__761ABED09B5F18F1");

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
                    .HasName("PK__tblRole__8AFACE3A04DD5509");

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
                    .HasName("PK__tblUser__1788CCAC48DE1133");

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
                        l => l.HasOne<TblEducation>().WithMany().HasForeignKey("EducationId").HasConstraintName("FK__tblUserEd__Educa__38996AB5"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK__tblUserEd__UserI__37A5467C"),
                        j =>
                        {
                            j.HasKey("UserId", "EducationId").HasName("PK__tblUserE__53332FCC82687860");

                            j.ToTable("tblUserEducation");
                        });

                entity.HasMany(d => d.IdRoles)
                    .WithMany(p => p.IdUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TblUserRole",
                        l => l.HasOne<TblRole>().WithMany().HasForeignKey("IdRole").HasConstraintName("FK__tblUserRo__idRol__34C8D9D1"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("IdUser").HasConstraintName("FK__tblUserRo__idUse__33D4B598"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdRole").HasName("PK__tblUserR__69478C47D60D000B");

                            j.ToTable("tblUserRole");

                            j.IndexerProperty<Guid>("IdUser").HasColumnName("idUser");

                            j.IndexerProperty<Guid>("IdRole").HasColumnName("idRole");
                        });

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "TblUserProject",
                        l => l.HasOne<TblProject>().WithMany().HasForeignKey("ProjectId").HasConstraintName("FK__tblUserPr__Proje__3C69FB99"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK__tblUserPr__UserI__3B75D760"),
                        j =>
                        {
                            j.HasKey("UserId", "ProjectId").HasName("PK__tblUserP__00E967A3EB776637");

                            j.ToTable("tblUserProject");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
