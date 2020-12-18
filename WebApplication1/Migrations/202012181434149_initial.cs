namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSubjectAttendances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        CountMissed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        GroupNumber = c.String(),
                        CourseNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjectAttendances", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjectAttendances", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentSubjectAttendances", new[] { "StudentId" });
            DropIndex("dbo.StudentSubjectAttendances", new[] { "SubjectId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.StudentSubjectAttendances");
        }
    }
}
