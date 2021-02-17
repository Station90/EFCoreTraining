using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTraining.Migrations
{
    public partial class StoredProcedureInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
 
            CREATE PROCEDURE [dbo].[InsertProcedure]
                @InsertName varchar(max)
                ,@InsertNumber int
            AS
            BEGIN
                INSERT INTO [dbo].[InsertProcedureTemplates]
                ([InsertName]
                ,[InsertNumber])
                VALUES
                (@InsertName
                ,@InsertNumber)
            END
            GO";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC InsertProcedure");
        }
    }
}
