namespace CommentVotingApp_BS23_Wali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentEntities",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Comment = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.PostEntities", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.PostEntities",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        Content = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.VoteEntities",
                c => new
                    {
                        VoteID = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        isVote = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VoteID)
                .ForeignKey("dbo.CommentEntities", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoteEntities", "CommentId", "dbo.CommentEntities");
            DropForeignKey("dbo.CommentEntities", "PostId", "dbo.PostEntities");
            DropIndex("dbo.VoteEntities", new[] { "CommentId" });
            DropIndex("dbo.CommentEntities", new[] { "PostId" });
            DropTable("dbo.VoteEntities");
            DropTable("dbo.PostEntities");
            DropTable("dbo.CommentEntities");
        }
    }
}
