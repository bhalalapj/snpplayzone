using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SnpPlayzone.EfCore.Models;

namespace SnpPlayzone.EfCore.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<EventManagement> EventManagements { get; set; }

    public virtual DbSet<Guardian> Guardians { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<ParentalEngagement> ParentalEngagements { get; set; }

    public virtual DbSet<SafetyMonitoring> SafetyMonitorings { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<VisitHistory> VisitHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=Admin@26983;Database=snp_playzone");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("snp", "uuid-ossp");

        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.ChildId).HasName("child_pkey");

            entity.ToTable("child", "snp");

            entity.Property(e => e.ChildId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("child_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Allergies).HasColumnName("allergies");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(20)
                .HasColumnName("emergency_contact");
            entity.Property(e => e.GuardianName)
                .HasMaxLength(255)
                .HasColumnName("guardian_name");
            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Preferences).HasColumnName("preferences");
            entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Membership).WithMany(p => p.Children)
                .HasForeignKey(d => d.MembershipId)
                .HasConstraintName("child_membership_id_fkey");
        });

        modelBuilder.Entity<EventManagement>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("event_management_pkey");

            entity.ToTable("event_management", "snp");

            entity.Property(e => e.EventId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("event_id");
            entity.Property(e => e.ChildId).HasColumnName("child_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .HasColumnName("event_name");
            entity.Property(e => e.GuardianId).HasColumnName("guardian_id");
            entity.Property(e => e.PackageType)
                .HasMaxLength(255)
                .HasColumnName("package_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Child).WithMany(p => p.EventManagements)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("event_management_child_id_fkey");

            entity.HasOne(d => d.Guardian).WithMany(p => p.EventManagements)
                .HasForeignKey(d => d.GuardianId)
                .HasConstraintName("event_management_guardian_id_fkey");
        });

        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.HasKey(e => e.GuardianId).HasName("guardian_pkey");

            entity.ToTable("guardian", "snp");

            entity.HasIndex(e => e.Email, "guardian_email_key").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "guardian_phone_number_key").IsUnique();

            entity.Property(e => e.GuardianId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("guardian_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Membership).WithMany(p => p.Guardians)
                .HasForeignKey(d => d.MembershipId)
                .HasConstraintName("guardian_membership_id_fkey");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("inventory_pkey");

            entity.ToTable("inventory", "snp");

            entity.Property(e => e.InventoryId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("inventory_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .HasColumnName("item_name");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_updated");
            entity.Property(e => e.LowStockAlert)
                .HasDefaultValue(false)
                .HasColumnName("low_stock_alert");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("membership_pkey");

            entity.ToTable("membership", "snp");

            entity.Property(e => e.MembershipId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("membership_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Discount)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("discount");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<ParentalEngagement>(entity =>
        {
            entity.HasKey(e => e.EngagementId).HasName("parental_engagement_pkey");

            entity.ToTable("parental_engagement", "snp");

            entity.Property(e => e.EngagementId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("engagement_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GuardianId).HasColumnName("guardian_id");
            entity.Property(e => e.MessageContent).HasColumnName("message_content");
            entity.Property(e => e.MessageType)
                .HasMaxLength(20)
                .HasColumnName("message_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Guardian).WithMany(p => p.ParentalEngagements)
                .HasForeignKey(d => d.GuardianId)
                .HasConstraintName("parental_engagement_guardian_id_fkey");
        });

        modelBuilder.Entity<SafetyMonitoring>(entity =>
        {
            entity.HasKey(e => e.IncidentId).HasName("safety_monitoring_pkey");

            entity.ToTable("safety_monitoring", "snp");

            entity.Property(e => e.IncidentId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("incident_id");
            entity.Property(e => e.ChildId).HasColumnName("child_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IncidentDescription).HasColumnName("incident_description");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Child).WithMany(p => p.SafetyMonitorings)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("safety_monitoring_child_id_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.SafetyMonitorings)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("safety_monitoring_staff_id_fkey");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("staff_pkey");

            entity.ToTable("staff", "snp");

            entity.Property(e => e.StaffId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("staff_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PerformanceReview).HasColumnName("performance_review");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.ShiftSchedule).HasColumnName("shift_schedule");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("transactions_pkey");

            entity.ToTable("transactions", "snp");

            entity.Property(e => e.TransactionId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GuardianId).HasColumnName("guardian_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .HasColumnName("transaction_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Guardian).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.GuardianId)
                .HasConstraintName("transactions_guardian_id_fkey");
        });

        modelBuilder.Entity<VisitHistory>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("visit_history_pkey");

            entity.ToTable("visit_history", "snp");

            entity.Property(e => e.VisitId)
                .HasDefaultValueSql("snp.uuid_generate_v4()")
                .HasColumnName("visit_id");
            entity.Property(e => e.CheckInTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("check_in_time");
            entity.Property(e => e.CheckOutTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("check_out_time");
            entity.Property(e => e.ChildId).HasColumnName("child_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EntryType)
                .HasMaxLength(20)
                .HasColumnName("entry_type");
            entity.Property(e => e.GuardianId).HasColumnName("guardian_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Child).WithMany(p => p.VisitHistories)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("visit_history_child_id_fkey");

            entity.HasOne(d => d.Guardian).WithMany(p => p.VisitHistories)
                .HasForeignKey(d => d.GuardianId)
                .HasConstraintName("visit_history_guardian_id_fkey");

            entity.HasOne(d => d.Payment).WithMany(p => p.VisitHistories)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("visit_history_payment_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
