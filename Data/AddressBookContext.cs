using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KendoUiPractice.Models;

#nullable disable

namespace KendoUiPractice.Data
{
    public partial class AddressBookContext : DbContext
    {
        public AddressBookContext()
        {
        }

        public AddressBookContext(DbContextOptions<AddressBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactCategory> ContactCategories { get; set; }
        public virtual DbSet<ContactWiseContactCategory> ContactWiseContactCategories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=MSI;database=AddressBook;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("BloodGroup");

                entity.HasIndex(e => e.BloodGroupName, "IX_BloodGroup")
                    .IsUnique();

                entity.Property(e => e.BloodGroupId).HasColumnName("BloodGroupID");

                entity.Property(e => e.BloodGroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Stdcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STDCode");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BloodGroupId).HasColumnName("BloodGroupID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Profession)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK_Contact_BloodGroup");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Contact_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Contact_Country");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Contact_State");
            });

            modelBuilder.Entity<ContactCategory>(entity =>
            {
                entity.ToTable("ContactCategory");

                entity.HasIndex(e => e.ContactCategoryName, "IX_ContactCategory")
                    .IsUnique();

                entity.Property(e => e.ContactCategoryId).HasColumnName("ContactCategoryID");

                entity.Property(e => e.ContactCategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactWiseContactCategory>(entity =>
            {
                entity.ToTable("ContactWiseContactCategory");

                entity.Property(e => e.ContactWiseContactCategoryId).HasColumnName("ContactWiseContactCategoryID");

                entity.Property(e => e.ContactCategoryId).HasColumnName("ContactCategoryID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.HasOne(d => d.ContactCategory)
                    .WithMany(p => p.ContactWiseContactCategories)
                    .HasForeignKey(d => d.ContactCategoryId)
                    .HasConstraintName("FK_ContactWiseContactCategory_ContactCategory");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactWiseContactCategories)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_ContactWiseContactCategory_Contact");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Country");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
