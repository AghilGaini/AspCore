using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.EFCore.Migrations
{
    public partial class AddVwUserRolePermision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE VIEW VwUserRolePermision AS 
                                    SELECT 
                                    u.id AS userId,
                                    u.UserName,
                                    u.IsAdmin,
                                    r.id AS roleId,
                                    r.Name AS roleName,
                                    p.ID AS permisionId,
                                    p.Value AS PermisionValue
                                    FROM 
                                    AppCoreDB.dbo.AspNetUsers u WITH(NOLOCK)
                                    INNER JOIN AppCoreDB.dbo.AspNetUserRoles ur WITH(NOLOCK) ON u.Id = ur.UserId
                                    INNER JOIN AppCoreDB.dbo.AspNetRoles r WITH(NOLOCK) ON r.Id = ur.RoleId
                                    INNER JOIN AppCoreDB.dbo.RolePermisions rp WITH(NOLOCK) ON rp.RoleId = r.Id
                                    INNER JOIN AppCoreDB.dbo.Permisions p WITH(NOLOCK) ON p.ID = rp.PermisionId
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.VwUserRolePermision ");
        }
    }
}
