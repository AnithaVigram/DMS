using Microsoft.EntityFrameworkCore;
using DMS.Data.EF.Models;
using Microsoft.Extensions.Options;

namespace DMS.Data.EF.Context;

public partial class DmsContext : DbContext
{
    private DBConnectionString _dbActions;

    public DmsContext(DbContextOptions<DmsContext> options, DBConnectionString dbActions) : base(options)
    {
        _dbActions = dbActions;
    }


    public virtual DbSet<DmManual> DmManuals { get; set; }

    public virtual DbSet<DmManualApprovalSetting> DmManualApprovalSettings { get; set; }

    public virtual DbSet<DmManualAttachment> DmManualAttachments { get; set; }

    public virtual DbSet<DmManualCategory> DmManualCategories { get; set; }

    public virtual DbSet<DmManualLog> DmManualLogs { get; set; }

    public virtual DbSet<DmManualStatus> DmManualStatuses { get; set; }

    public virtual DbSet<DmManualVsl> DmManualVsls { get; set; }

    public virtual DbSet<DmManualVslAck> DmManualVslAcks { get; set; }

    public virtual DbSet<GenErrorHqLog> GenErrorHqLogs { get; set; }

    public virtual DbSet<GenErrorVslLog> GenErrorVslLogs { get; set; }

    public virtual DbSet<HqUser> HqUsers { get; set; }

    public virtual DbSet<VVessel> VVessels { get; set; }

    public virtual DbSet<VslStaff> VslStaffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_dbActions.DefaultConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmManual>(entity =>
        {
            entity.ToTable("DM_Manual");

            entity.Property(e => e.DmManualId)
                .ValueGeneratedNever()
                .HasColumnName("DM_ManualID");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DmManualCategoryId).HasColumnName("DM_ManualCategoryID");
            entity.Property(e => e.DmManualStatusId).HasColumnName("DM_ManualStatusID");
            entity.Property(e => e.FinalisedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FinalisedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(0);
            entity.Property(e => e.ManualCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ManualName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<DmManualApprovalSetting>(entity =>
        {
            entity.HasKey(e => e.DmApprovalSettingsId).HasName("PK_DM_ApprovalSettings");

            entity.ToTable("DM_Manual_ApprovalSettings");

            entity.Property(e => e.DmApprovalSettingsId)
                .ValueGeneratedNever()
                .HasColumnName("DM_ApprovalSettingsID");
            entity.Property(e => e.CanAddEmailApprovalLink).HasDefaultValue(0);
            entity.Property(e => e.DmManualId).HasColumnName("DM_ManualID");
            entity.Property(e => e.DmStatusId).HasColumnName("DM_StatusID");
            entity.Property(e => e.Hqdept)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("HQDept");
            entity.Property(e => e.IsDisabled).HasDefaultValue(0);
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.SendBackDmStatusId)
                .HasDefaultValue(-1L)
                .HasColumnName("SendBack_DM_StatusID");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<DmManualAttachment>(entity =>
        {
            entity.HasKey(e => e.DmManualAttachmentsId).HasName("PK_DM_ManualAttachments");

            entity.ToTable("DM_Manual_Attachments");

            entity.Property(e => e.DmManualAttachmentsId)
                .ValueGeneratedNever()
                .HasColumnName("DM_ManualAttachmentsID");
            entity.Property(e => e.AddedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BlobContents).HasColumnType("image");
            entity.Property(e => e.DmManualId).HasColumnName("DM_ManualID");
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<DmManualCategory>(entity =>
        {
            entity.HasKey(e => e.DmManualCategoryId).HasName("PK_DM_ManualCategory");

            entity.ToTable("DM_Manual_Category");

            entity.Property(e => e.DmManualCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("DM_ManualCategoryID");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IsDisabled).HasDefaultValue(0);
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<DmManualLog>(entity =>
        {
            entity.HasKey(e => e.DmManualLogId).HasName("PK_DM_ManualLog");

            entity.ToTable("DM_Manual_Log");

            entity.Property(e => e.DmManualLogId)
                .ValueGeneratedNever()
                .HasColumnName("DM_ManualLogID");
            entity.Property(e => e.Activity)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.DmManualId).HasColumnName("DM_ManualID");
            entity.Property(e => e.Logdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MachineWinLoginName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI")
                .HasColumnName("Machine_WinLogin_Name");
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.UserRank)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<DmManualStatus>(entity =>
        {
            entity.HasKey(e => e.DmManualStatusId).HasName("PK_DM_ManualStatus");

            entity.ToTable("DM_Manual_Status");

            entity.Property(e => e.DmManualStatusId)
                .ValueGeneratedNever()
                .HasColumnName("DM_ManualStatusID");
            entity.Property(e => e.IsDisabled).HasDefaultValue(0);
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder).HasDefaultValue(-1);
            entity.Property(e => e.StatusCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.StatusName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<DmManualVsl>(entity =>
        {
            entity.ToTable("DM_Manual_Vsl");

            entity.Property(e => e.DmManualVslId)
                .ValueGeneratedNever()
                .HasColumnName("DM_Manual_VslID");
            entity.Property(e => e.DmManualId).HasColumnName("DM_ManualID");
            entity.Property(e => e.IsActive).HasDefaultValue(0);
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.UserRank)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<DmManualVslAck>(entity =>
        {
            entity.ToTable("DM_Manual_VslAck");

            entity.Property(e => e.DmManualVslAckId)
                .ValueGeneratedNever()
                .HasColumnName("DM_Manual_VslAckID");
            entity.Property(e => e.AckDate).HasColumnType("datetime");
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DmManualId).HasColumnName("DM_ManualID");
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserRank)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<GenErrorHqLog>(entity =>
        {
            entity.ToTable("Gen_Error_HQ_Log");

            entity.Property(e => e.GenErrorHqLogId)
                .ValueGeneratedNever()
                .HasColumnName("Gen_Error_HQ_LogID");
            entity.Property(e => e.AddedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ApplicationName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.LoggedInUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI")
                .HasColumnName("LoggedInUserID");
            entity.Property(e => e.MachineWinLoginName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI")
                .HasColumnName("Machine_WinLogin_Name");
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.PageName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.TextContents)
                .UseCollation("Latin1_General_CI_AI")
                .HasColumnType("text");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<GenErrorVslLog>(entity =>
        {
            entity.HasKey(e => new { e.GenErrorVslLogId, e.VesselId });

            entity.ToTable("Gen_Error_VSL_Log");

            entity.Property(e => e.GenErrorVslLogId).HasColumnName("Gen_Error_VSL_LogID");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
            entity.Property(e => e.AddedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ApplicationName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.LoggedInUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI")
                .HasColumnName("LoggedInUserID");
            entity.Property(e => e.MachineWinLoginName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI")
                .HasColumnName("Machine_WinLogin_Name");
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.PageName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.TextContents)
                .UseCollation("Latin1_General_CI_AI")
                .HasColumnType("text");
        });

        modelBuilder.Entity<HqUser>(entity =>
        {
            entity.HasKey(e => e.HqUsersId);

            entity.ToTable("HQ_Users");

            entity.Property(e => e.HqUsersId)
                .ValueGeneratedNever()
                .HasColumnName("HQ_UsersID");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateDisabled).HasColumnType("datetime");
            entity.Property(e => e.Designation)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("EMail");
            entity.Property(e => e.EmpId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("EmpID");
            entity.Property(e => e.Hqdept)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("HQDept");
            entity.Property(e => e.IsDisabled).HasDefaultValue(0);
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        modelBuilder.Entity<VVessel>(entity =>
        {
            entity.ToTable("V_Vessel");

            entity.Property(e => e.VVesselId)
                .ValueGeneratedNever()
                .HasColumnName("V_VesselID");
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
            entity.Property(e => e.VslCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.VslName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VslStaff>(entity =>
        {
            entity.HasKey(e => new { e.VslStaffId, e.VesselId });

            entity.ToTable("Vsl_Staff");

            entity.Property(e => e.VslStaffId).HasColumnName("Vsl_StaffID");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
            entity.Property(e => e.Origin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AI");
            entity.Property(e => e.UserDept)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserRank).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
