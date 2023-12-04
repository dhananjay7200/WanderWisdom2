using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wander_wisdom.Models;

public partial class WanderWisdomContext : DbContext
{
    public WanderWisdomContext()
    {
    }

    public WanderWisdomContext(DbContextOptions<WanderWisdomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CommentsDetail> CommentsDetails { get; set; }

    public virtual DbSet<LikesDetail> LikesDetails { get; set; }

    public virtual DbSet<PostDetail> PostDetails { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CVC222;Initial Catalog=WanderWisdom;Persist Security Info=True;User ID=sa;Password=cybage@123456;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommentsDetail>(entity =>
        {
            entity.HasKey(e => e.CmtId).HasName("Cmt_cmtId_Pk");

            entity.ToTable("Comments_Details");

            entity.Property(e => e.CmtId).HasColumnName("Cmt_Id");
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.PostCmtFk).HasColumnName("Post_cmt_fk");

            entity.HasOne(d => d.PostCmtFkNavigation).WithMany(p => p.CommentsDetails)
                .HasForeignKey(d => d.PostCmtFk)
                .HasConstraintName("Likes_Post_cmt_fk");
        });

        modelBuilder.Entity<LikesDetail>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("Like_likeId_Pk");

            entity.ToTable("Likes_Details");

            entity.Property(e => e.LikeId).HasColumnName("Like_Id");
            entity.Property(e => e.LikesCount).HasColumnName("Likes_count");
            entity.Property(e => e.PostLikesFk).HasColumnName("Post_Likes_fk");

            entity.HasOne(d => d.PostLikesFkNavigation).WithMany(p => p.LikesDetails)
                .HasForeignKey(d => d.PostLikesFk)
                .HasConstraintName("Likes_Post_likes_fk");
        });

        modelBuilder.Entity<PostDetail>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("Post_postId_Pk");

            entity.ToTable("Post_details");

            entity.Property(e => e.PostId).HasColumnName("Post_Id");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.PostDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Post_Description");
            entity.Property(e => e.PostTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Post_Title");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserIdPk).HasName("User_UserId_Pk");

            entity.HasIndex(e => e.UserEmail, "User_User_uq").IsUnique();

            entity.Property(e => e.UserIdPk).HasColumnName("UserId_pk");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.UserCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPhonenumber).HasMaxLength(50);
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
