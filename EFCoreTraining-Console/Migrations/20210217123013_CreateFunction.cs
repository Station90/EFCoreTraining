using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTraining.Migrations
{
    public partial class CreateFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"

                SET ANSI_NULLS ON
                GO
                SET QUOTED_IDENTIFIER ON
                GO
                CREATE FUNCTION [dbo].[TestFunction] (
                    @ZipCode varchar(max)
                )
                RETURNS TABLE
                AS
                RETURN
                    SELECT Id
                    FROM [PostalCodes]
                    WHERE [Code] LIKE @ZipCode
                GO";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION TestFunction");
        }
    }
}
