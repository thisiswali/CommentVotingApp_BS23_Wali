using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommentVotingApp_BS23_Wali.Models
{
    public class PostDbContext : DbContext
    {

        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<VoteEntity> Votes { get; set; }
    }


    public class PostEntity
    {
        public PostEntity()
        {
            this.Comments = new HashSet<CommentEntity>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }

        [Display(Name = "Title")]
        public string PostTitle { get; set; }

        [DataType(DataType.MultilineText), AllowHtml]
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }
    }

    public class CommentEntity
    {
        public CommentEntity()
        {
            this.Votes = new HashSet<VoteEntity>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        [ForeignKey("Posts")]
        public int PostId { get; set; }

        [DataType(DataType.MultilineText), AllowHtml]
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual PostEntity Posts { get; set; }
        public virtual ICollection<VoteEntity> Votes { get; set; }
    }

    public class VoteEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteID { get; set; }
        [ForeignKey("Comments")]
        public int CommentId { get; set; }

        public bool isVote { get; set; }
        public virtual CommentEntity Comments { get; set; }
    }
}