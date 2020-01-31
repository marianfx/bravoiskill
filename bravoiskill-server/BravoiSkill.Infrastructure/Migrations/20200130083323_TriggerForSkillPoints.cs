using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class TriggerForSkillPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"USE BravoiSkill
go

IF OBJECT_ID(N'insert_skill_points', N'TR') IS NOT NULL
exec sp_executesql N'DROP TRIGGER insert_skill_points';
GO

CREATE TRIGGER insert_skill_points
ON BravoiSkill.dbo.SkillReviews
AFTER INSERT
--FOR EACH ROW
AS

declare @points int
declare @userid int
declare @skillId int
SELECT @points = SUM(sr.ReviewPoints), @userid = r.ReviewedUserId, @skillId = sr.SkillId
FROM inserted i
JOIN BravoiSkill.dbo.Reviews r ON r.ReviewId = i.ReviewId
JOIN BravoiSkill.dbo.SkillReviews sr ON sr.SkillId = i.SkillId
WHERE r.ReviewedUserId IN (SELECT r2.ReviewedUserId
FROM BravoiSkill.dbo.Reviews r2
WHERE r2.ReviewId = i.ReviewId)
GROUP BY sr.SkillId, r.ReviewedUserId

BEGIN

if exists(select * from BravoiSkill.dbo.UserSkills where SkillId = @skillId AND UserId = @userid)
begin
UPDATE BravoiSkill.dbo.UserSkills
SET Points = @points
WHERE SkillId = @skillId AND UserId = @userid
end
else
begin
INSERT INTO BravoiSkill.dbo.UserSkills values (@skillId, @userid, @points)
end
END;
USE BravoiSkill
go

IF OBJECT_ID(N'update_skill_points', N'TR') IS NOT NULL
exec sp_executesql N'DROP TRIGGER update_skill_points';
GO

CREATE TRIGGER update_skill_points
ON BravoiSkill.dbo.SkillReviews
AFTER update
--FOR EACH ROW
AS

declare @points int
declare @userid int
declare @skillId int
SELECT @points = SUM(sr.ReviewPoints), @userid = r.ReviewedUserId, @skillId = sr.SkillId
FROM inserted i
JOIN BravoiSkill.dbo.Reviews r ON r.ReviewId = i.ReviewId
JOIN BravoiSkill.dbo.SkillReviews sr ON sr.SkillId = i.SkillId
WHERE r.ReviewedUserId IN (SELECT r2.ReviewedUserId
FROM BravoiSkill.dbo.Reviews r2
WHERE r2.ReviewId = i.ReviewId)
GROUP BY sr.SkillId, r.ReviewedUserId

BEGIN

if exists(select * from BravoiSkill.dbo.UserSkills where SkillId = @skillId AND UserId = @userid)
begin
UPDATE BravoiSkill.dbo.UserSkills
SET Points = @points
WHERE SkillId = @skillId AND UserId = @userid
end
else
begin
INSERT INTO BravoiSkill.dbo.UserSkills values (@skillId, @userid, @points)
end
END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER insert_skill_points; DROP TRIGGER update_skill_points");
        }
    }
}
