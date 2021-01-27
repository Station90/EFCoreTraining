using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTraining.Migrations
{
    public partial class StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
 
            CREATE PROCEDURE [dbo].[GetStreets]
                @ZipCode varchar(max)
            AS
            BEGIN
                SET NOCOUNT ON;
                SELECT [Name]
                FROM [Streets] s
                join [PostalCodeStreet] ps on s.Id = ps.StreetsId
                join [PostalCodes] c on c.Id = ps.PostalCodesId
                WHERE c.Code LIKE @ZipCode
            END
            GO";
            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC GetStreets");
        }
    }
}
